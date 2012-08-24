using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    delegate void eventDelegate();

    class FileTransferPanel
    {

        enum FileStatus
        {
            Wait = 0, Send = 1, Finished = 2, Canceled = -1, Failed = -2 
        }

        public enum JobMode
        {
            Send, Receive
        }

        const string MSG_FILE_WAITING = "전송대기";
        const string MSG_FILE_SENDING = "전송중";
        const string MSG_FILE_FINISHED = "전송완료";
        const string MSG_FILE_CANCELED = "전송취소";
        const string MSG_FILE_FAILED = "전송실패";

        const string MSG_FILE_SAVING = "파일저장중";


        const int LEN_MARGIN = 1;
        const int LEN_LABEL = 100;
        const int LEN_PROGRESSBAR = 160;
        const int LEN_PANEL = 274;
        const int LEN_BUTTON_HEIGHT = 18;
        const int LEN_BUTTON_WIDTH = 45;
        const int LEN_LABEL_HEIGHT = 23;
        const int LEN_GAP = 3;
        const string MSG_BUTTON_OK = "수신";
        const string MSG_BUTTON_CANCEL = "취소";


        ArrayList alFileList = new ArrayList();
        int mFileCnt = 0;
        int mNextTop = 0;
        JobMode mMode;
        Panel mPanel;

        RichTextBox mBox;

        public FileTransferPanel(JobMode mode, Panel parent, RichTextBox box) 
        {
            mMode = mode;
            mPanel = parent;
            mBox = box;
        }

        public void hide() 
        {
            cleanUpEntry();
            mPanel.Parent.Hide();
        }

        public void cleanUpEntry()
        {
            int i = 0;
            while (i < alFileList.Count)
            {
                if (((FileTransferEntry)alFileList[i]).isDisposable())
                {
                    ((FileTransferEntry)alFileList[i]).Dispose();
                    alFileList.RemoveAt(i);
                    mNextTop -= LEN_MARGIN + LEN_LABEL_HEIGHT + LEN_MARGIN;
                    Debug.WriteLine("nextTop=" + mNextTop);
                    mBox.AppendText("cut: nextTop=" + mNextTop+"\n");
                }
                else
                {
                    i++;
                }
            }
        }

        public void addEntry(JobMode mode, string fullFileName)
        {
            FileTransferEntry entry = new FileTransferEntry(mode, fullFileName);
            int top = 0;
            this.mPanel.Parent.Visible = true;
            entry.addToPanel(this.mPanel, mNextTop, out top);
            mNextTop = top;
            Debug.WriteLine("nextTop=" + mNextTop);
            mBox.AppendText("add: nextTop=" + mNextTop + " pos=" + entry.getPanelPosition().Y
                 + " height=" + mPanel.Height + " \n");
            alFileList.Add(entry);
            mPanel.Refresh();
            mPanel.ResumeLayout();
        }

        ~FileTransferPanel()
        {
            Dispose();
        }

        public void Dispose()
        {
            int i = 0;
            while (i < alFileList.Count)
            {
                ((FileTransferEntry)alFileList[i]).Dispose();
                alFileList.RemoveAt(i);
            }
        }

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetProgressBarCallback(int step);

        class FileTransferEntry
        {
            Panel _pnlFileEntry = null;
            Label _lblFileStatus = null;
            ProgressBar _pgbFileStatus = null;
            Button _btnOk = null;
            Button _btnCancel = null;
            ToolTip _labelsToolTip = null;
            string _filePath;
            string _fileName;
            string _shortFileName;
            FileStatus _status;
            JobMode _mode;

            long _fileSize = 0L;
            long _curFileSentSize = 0L;

            Thread _thEntry;
            Thread _thBtnOK;
            Thread _thBtnCancel;
            
            //EventHandler handler 

            public FileTransferEntry(JobMode mode, string fullFileName)
            {
                _mode = mode;
                
                setFileInfo(fullFileName);
                
                _pnlFileEntry = new Panel();
                _pnlFileEntry.BackColor = System.Drawing.SystemColors.ActiveCaption;
                _lblFileStatus = new Label();
                _lblFileStatus.Text = _fileName + "\n" + MSG_FILE_WAITING;
                _pgbFileStatus = new ProgressBar();

                if (mode == JobMode.Receive)
                {
                    _btnOk = new Button();
                    _btnCancel = new Button();
                }
                else
                {
                }
                _status = FileStatus.Wait;
            }

            public FileStatus FileStatus
            {
                get
                {
                    return this._status;
                }
                set
                {
                    this._status = value;
                }
            }

            public Point getPanelPosition()
            {
                return new Point(_pnlFileEntry.Left, _pnlFileEntry.Top);
            }

            public void addToPanel(Panel parent, int top, out int nextTop)
            {
                parent.Controls.Add(this._pnlFileEntry);
                this._pnlFileEntry.Top = top;
                this._pnlFileEntry.Left = LEN_MARGIN;
                this._pnlFileEntry.Height = LEN_MARGIN+LEN_LABEL_HEIGHT +LEN_MARGIN;
                this._pnlFileEntry.Width = LEN_MARGIN + LEN_LABEL + LEN_GAP + LEN_PROGRESSBAR + LEN_MARGIN;

                nextTop = top + LEN_MARGIN + LEN_LABEL_HEIGHT + LEN_MARGIN;
                addToControl();
            }

            void addToControl()
            {
                _pnlFileEntry.Controls.Add(_lblFileStatus);
                _pnlFileEntry.Controls.Add(_pgbFileStatus);

                _lblFileStatus.Left = LEN_MARGIN;
                _lblFileStatus.Top = LEN_MARGIN;
                _lblFileStatus.Height = LEN_LABEL_HEIGHT;
                _lblFileStatus.Width = LEN_LABEL;
                _lblFileStatus.BackColor = System.Drawing.Color.Aqua;
                _lblFileStatus.Font = new Font("굴림", 9, FontStyle.Regular);

                _pgbFileStatus.Left = LEN_MARGIN + LEN_LABEL + LEN_GAP;
                _pgbFileStatus.Top = LEN_MARGIN;
                _pgbFileStatus.Height = LEN_LABEL_HEIGHT;
                _pgbFileStatus.Width = LEN_PROGRESSBAR;

                _pgbFileStatus.Hide();

                if (_mode == JobMode.Send)
                {
                    //수신받은 소켓을 할당함

                }
                else
                {
                    _pnlFileEntry.Controls.Add(_btnOk);
                    _pnlFileEntry.Controls.Add(_btnCancel);
                    _btnOk.Text = MSG_BUTTON_OK;
                    _btnOk.Click += new EventHandler(_btnOkClick);
                    _btnOk.Top = LEN_MARGIN;
                    _btnOk.Left = LEN_MARGIN + LEN_LABEL + LEN_GAP;
                    _btnOk.Height = LEN_BUTTON_HEIGHT;
                    _btnOk.Width = LEN_BUTTON_WIDTH;
                    _btnOk.Font = new Font("굴림", 8, FontStyle.Regular);

                    _btnCancel.Text = MSG_BUTTON_CANCEL;
                    _btnCancel.Click += new EventHandler(_btnCancelClick);
                    _btnCancel.Top = LEN_MARGIN;
                    _btnCancel.Left = LEN_MARGIN + LEN_LABEL + LEN_GAP + LEN_BUTTON_WIDTH + LEN_GAP;
                    _btnCancel.Height = LEN_BUTTON_HEIGHT;
                    _btnCancel.Width = LEN_BUTTON_WIDTH;
                    _btnCancel.Font = new Font("굴림", 8, FontStyle.Regular);

                    _btnOk.BringToFront();
                    _btnCancel.BringToFront();

                    //소켓생성
                }

                //쓰레드를 생성하여 대기
                _thEntry = new Thread(new ThreadStart(this.DoRun));
                //스레드실행->출발
                _thEntry.Start(); 
                
                setShortFileName();

                //chatBox2.AppendText("Height=" + label.Height + " : Top=" + label.Top + "\n");
            }

            // This method is executed on the worker thread and makes
            // an unsafe call on the TextBox control.
            private void ThreadProcBtnOk()
            {
            }

            private void _btnOkClick(object sender, EventArgs e)
            {
                //MessageBox.Show("File transfer Ok.");
                _btnOk.Hide();
                _btnCancel.Hide();
                _pgbFileStatus.Visible = true;
                setFileTransferMode(FileStatus.Send);
                //쓰레드내 소켓 데이터 수신시작
    //            this.thBtnOK =
    //new Thread(new ThreadStart(this.ThreadProcBtnOk));

    //            this.thBtnOK.Start();
            }

            // This method is executed on the worker thread and makes
            // an unsafe call on the TextBox control.
            private void ThreadProcBtnCancel()
            {
            }

            private void _btnCancelClick(object sender, EventArgs e)
            {
                //MessageBox.Show("File transfer Refuse.");
                _btnOk.Hide();
                _btnCancel.Hide();
                setFileTransferMode(FileStatus.Canceled);
                //쓰레드내 소켓 데이터 거부후 해제 대기
    //            this.thBtnCancel =
    //new Thread(new ThreadStart(this.ThreadProcBtnCancel));

    //            this.thBtnCancel.Start();
            }

            void setFileInfo(string fullFileName)
            {
                int splitIndex = fullFileName.LastIndexOf("\\");

                FileInfo info = new FileInfo(fullFileName);
                _fileSize = info.Length;

                _filePath = fullFileName.Substring(0, splitIndex);
                _fileName = fullFileName.Substring(splitIndex+1, fullFileName.Length - (splitIndex + 1));
            }

            private void setShortFileName()
            {
                // 텍스트 박스로부터 Graphics 객체를 얻는다.
                Graphics textGraphics = Graphics.FromHwnd(_lblFileStatus.Handle);

                // 텍스트 박스의 내용(문자열)의 사이즈를 얻는다.

                StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
                SizeF stringSize = textGraphics.MeasureString(_lblFileStatus.Text,
                    _lblFileStatus.Font, 500, sf);
                /*stringSize.Width는 문자열의 폭이되고 stringSize.Height는 문자열의 높이가 된답니다. */

                // 텍스트박스의 Width와 문자열의 Width를 비교한다.
                if (stringSize.Width > 140 || _fileName.Length > 10)//label.ClientSize.Width)
                {
                    int lastIndex = _fileName.LastIndexOf(".");
                    _shortFileName = _fileName.Substring(0, 5)
                        + ".."
                        + _fileName.Substring(lastIndex, _fileName.Length - lastIndex);
                    //labelsToolTip. = "tip" + label.Name;
                }
                else
                {
                    _shortFileName = _fileName;
                }
                _lblFileStatus.Text = _shortFileName + "\n" + MSG_FILE_WAITING;
                _labelsToolTip = new System.Windows.Forms.ToolTip(new System.ComponentModel.Container());
                _labelsToolTip.SetToolTip(_lblFileStatus, _fileName);
            }

            public bool isDisposable()
            {
                return (_status == FileStatus.Failed
                    || _status == FileStatus.Canceled
                    || _status == FileStatus.Finished);
            }

            public void enableProgressBar()
            {
            }

            ~FileTransferEntry() 
            {
                Dispose();
            }

            public void Dispose() 
            {
                if (_pnlFileEntry != null)
                    _pnlFileEntry.Dispose();

                if (_lblFileStatus != null)
                    _lblFileStatus.Dispose();
                if (_pgbFileStatus != null)
                    _pgbFileStatus.Dispose();
                if (_btnOk != null)
                    _btnOk.Dispose();
                if (_btnCancel != null)
                    _btnCancel.Dispose();
                if (_labelsToolTip != null)
                    _labelsToolTip.Dispose();
                if (_thBtnCancel != null )
                {
                    if (_thBtnCancel.IsAlive) _thBtnCancel.Abort();
                    _thBtnCancel = null;
                }
                if (_thBtnOK != null )
                {
                    if (_thBtnOK.IsAlive) _thBtnOK.Abort();
                    _thBtnOK = null;
                }
                if (_thEntry != null) 
                {
                    if (_thEntry.IsAlive) _thEntry.Abort();
                    _thEntry = null;
                }
            }

            private void SetValue(int value)
            {
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (this._pgbFileStatus.InvokeRequired)
                {
                    SetProgressBarCallback d = new SetProgressBarCallback(SetValue);
                    this._pnlFileEntry.Invoke (d, new object[] { value });
                }
                else
                {
                    this._pgbFileStatus.Value = value;
                    if (value == 100)
                        setFileTransferMode(FileStatus.Finished);
                }
            }


            public void DoRun()
            {
                //MITER 입니다.
                int Miter = 0;

                while (true)
                {

                    if (this._status == FileStatus.Wait)
                    {
                        Console.WriteLine("thread run:"+_fileName );
                        Thread.Sleep(300);
                        continue;
                    }
                    if ( this._status == FileStatus.Failed 
                        || this._status == FileStatus.Canceled
                        || this._status == FileStatus.Finished )
                        break;

                    //랜던함수생성
                    Random rd = new Random(_pnlFileEntry.TabIndex);

                    //50~150 사이의난수발생
                    Miter += rd.Next(1, 4);

                    //transferGauge = Miter;
                    //this._pgbFileStatus.Step = Miter;
                    if (Miter > 100)
                        Miter = 100;
                    SetValue(Miter);
                    //만약500미터를지났다면
                    if (Miter == 100) break;
                    //스레드휴식
                    Thread.Sleep(300);
                }
            }

            public void setFileSentSize(long size)
            {
                _curFileSentSize = size;
                if (_status == FileStatus.Send)
                {
                    _pgbFileStatus.Value = (int)(100 * ((double)_curFileSentSize 
                        / (double)_fileSize));
                }
            }



            public void setFileTransferMode(FileStatus status) {
                _status = status;
                switch (_status)
                {
                    case FileStatus.Wait:
                        _lblFileStatus.Text = _shortFileName + "\n" + MSG_FILE_WAITING;
                        break;
                    case FileStatus.Send:
                        _lblFileStatus.Text = _shortFileName + "\n" + MSG_FILE_SENDING;
                        if (!_pgbFileStatus.Visible)
                        {
                            _pgbFileStatus.Visible = true;
                            _pgbFileStatus.BringToFront();
                        }
                        enableProgressBar();
                        //상태바노출, 파일전송상태 활성화
                        break;
                    case FileStatus.Finished:
                        _lblFileStatus.Text = _shortFileName + "\n" + MSG_FILE_FINISHED;
                        //상태바유지, 파일전송상태 완료
                        if (_pgbFileStatus.Visible) _pgbFileStatus.Hide();
                        break;
                    case FileStatus.Canceled:
                        _lblFileStatus.Text = _shortFileName + "\n" + MSG_FILE_CANCELED;
                        //취소표시
                        if (_pgbFileStatus.Visible)
                        {
                            _pgbFileStatus.Hide();
                        }
                        break;
                    case FileStatus.Failed:
                        _lblFileStatus.Text = _shortFileName + "\n" + MSG_FILE_FAILED;
                        //실패표시
                        if (_pgbFileStatus.Visible) _pgbFileStatus.Hide();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
