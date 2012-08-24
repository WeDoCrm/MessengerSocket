using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        [DllImport("user32")]
        private static extern int FlashWindow(System.IntPtr hdl, int bInvert);

        private int iFileTransCnt = 0;
        private int iPnlHeight = 0;
        private int iPnlLeft = 0;
        private int iFileTransCntRcv = 0;
        private int iPnlHeightRcv = 0;
        private int iPnlLeftRcv = 0;
        private static int iLabelGap = 1;
        private static int iShortFIleNameLegnth = 5;
        FileTransferPanel mPanelSender;
        FileTransferPanel mPanelReceiver;
        FileTransferPanel mPanelReceiver2;


        public Form1()
        {
            InitializeComponent();
            mPanelSender = new FileTransferPanel(FileTransferPanel.JobMode.Send, this.pnlFileList, this.chatBox);
            //mPanelReceiver = new FileTransferPanel(FileTransferPanel.JobMode.Receive, this.pnlFileListRcv, this.chatBox2);
            mPanelReceiver2 = new FileTransferPanel(FileTransferPanel.JobMode.Receive, this.pnlFileListRcv2, this.chatBox2);
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            for (int i = 0; i < fileNames.Length; i++)
            {
                Debug.WriteLine("Dropped" + fileNames[i]);
            }


            //Point pt = new Point(e.X, e.Y);
            //pt = this.PointToClient(pt);
            //Label label = new Label();
            //label.Text = e.Data.GetData(DataFormats.Text).ToString();
            //label.BorderStyle = BorderStyle.FixedSingle;
            //label.AutoSize = true;
            //this.Controls.Add(label);
            //label.Location = new Point(pt.X, pt.Y);
        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            //Debug.WriteLine("DragOver");
            e.Effect = DragDropEffects.All;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            Debug.WriteLine("treeView1 DragDrop:" + sender.ToString() + ":" + treeView1.SelectedNode.Text);


            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string tempFilename = "";
            for (int i = 0; i < fileNames.Length; i++)
            {
                tempFilename = fileNames[i].Substring(fileNames[i].LastIndexOf("\\") + 1, fileNames[i].Length - (fileNames[i].LastIndexOf("\\") + 1));
                Debug.WriteLine("Dropped" + fileNames[i]);
                chatBox.AppendText("sendfile to " + treeView1.SelectedNode.Text + ":" + tempFilename + "\n");

                mPanelSender.addEntry(FileTransferPanel.JobMode.Send, fileNames[i]);
                mPanelReceiver2.addEntry(FileTransferPanel.JobMode.Receive, fileNames[i]);
                
                //if (i % 2 == 0)
                //{
                //    mPanelSender.addEntry(FileTransferPanel.JobMode.Send, fileNames[i]);
                //    mPanelReceiver.addEntry(FileTransferPanel.JobMode.Receive, fileNames[i]);
                //}
                //else
                //{
                //    mPanelSender.addEntry(FileTransferPanel.JobMode.Receive, fileNames[i]);
                //    mPanelReceiver.addEntry(FileTransferPanel.JobMode.Send, fileNames[i]);
                //}

                //addFileTransfer(tempFilename, treeView1.SelectedNode.Text);
                //addFileTransferRcv(tempFilename, treeView1.SelectedNode.Text);
            }
            //chatBox. ;
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            Point pos = treeView1.PointToClient(new Point(e.X, e.Y));
            TreeNode node = (TreeNode)treeView1.GetNodeAt(pos);
            treeView1.HideSelection = false;
            treeView1.SelectedNode =node;

            if (! node.IsExpanded)
            {
                node.Expand();
            }
            e.Effect = DragDropEffects.All;
        }

        private void treeView1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            Debug.WriteLine("treeView1_NodeMouseHover:" + e.Node.ToString());
        }

        private void treeView1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            Debug.WriteLine("treeView1_GiveFeedback:" + sender.ToString());
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
        //    string regex = @"^.*\s+\[\d+\]$";
        //    if (Regex.IsMatch(e.Node.Text, regex, RegexOptions.Compiled))
        //    {
        //        if (e.Node.IsSelected)
        //        string[] parts = e.Node.Text.Split(' ');
        //        if (parts.Length > 1)
        //        {
        //            string count = parts[parts.Length - 1];
        //            string text = " " + string.Join(" ", parts, 0, parts.Length - 1);
        //            Font normalFont = e.Node.TreeView.Font;

        //            float textWidth = e.Graphics.MeasureString(text, normalFont).Width;
        //            e.Graphics.DrawString(text,
        //                                  normalFont,
        //                                  SystemBrushes.WindowText,
        //                                  e.Bounds);

        //            using (Font boldFont = new Font(normalFont, FontStyle.Bold))
        //            {
        //                e.Graphics.DrawString(count,
        //                                      boldFont,
        //                                      SystemBrushes.WindowText,
        //                                      e.Bounds.Left + textWidth,
        //                                      e.Bounds.Top);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        e.DrawDefault = true;
        //    }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FlashWindow(this.Handle, 1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Image img = imageList1.Images[0];//Image.("img_notice_e.png");
            Clipboard.SetImage(img);

            chatBox.SelectionStart = 0;
            chatBox.Paste();

            Clipboard.Clear();
            timer1.Start();

            ProgressBar prgBar1 = new ProgressBar();
            //prgBar1.Location = new Point(0,0); //CalculateLocationOfControl();
            //prgBar1.Location = chatBox.get
            prgBar1.Size = new Size(80, 20);
            chatBox.Controls.Add(prgBar1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Increment the value of the ProgressBar a value of one each time.
            progressBar1.Value = 50;
            //progressBar1.Increment(1);
            
            //if (progressBar1.Value == progressBar1.Maximum)
            //    // Stop the timer.
            //    timer1.Stop();
        }

        private void addFileTransfer(string fileName, string userName)
        {
            iFileTransCnt++;
            Panel panel = new Panel();
            Label label = new Label();
            label.Name = "lblFileTransfer" + iFileTransCnt;
            label.Text = fileName + "\n" + "전송대기";

            ProgressBar progressBar = new ProgressBar();
            progressBar.Name = "pgbFileTransfer" + iFileTransCnt;
            panel.Controls.Add(label);
            panel.Controls.Add(progressBar);

            pnlFileList.Controls.Add(panel);
            panel.Top = iLabelGap + iPnlHeight;
            panel.Height = 25;
            panel.Width = 6 + 265;

            label.Top  = iLabelGap;// + iPnlHeight;
            label.Left = 3 + iPnlLeft;
            label.Height = 23;
            label.Width = 100;
            label.BackColor = System.Drawing.Color.Aqua;
            label.Font = new Font("굴림", 9, FontStyle.Regular);

            progressBar.Top = iLabelGap;// +iPnlHeight;
            progressBar.Height = 23;
            progressBar.Width = 165;
            progressBar.Left = 3 + label.Width;
            //progressBar.Hide();

            setShortFileName(label, fileName);
            
            chatBox2.AppendText("Height="+label.Height+" : Top="+label.Top+"\n");

            iPnlHeight += panel.Height;

            if (!pnlFileStatus.Visible)
            {
                pnlFileStatus.Visible = true;
            }
        }

        private void addFileTransferRcv(string fileName, string userName)
        {
            iFileTransCntRcv++;

            string sRCV = "RCV";
            Label label = new Label();
            label.Name = "lblFileTransfer" + sRCV + iFileTransCntRcv;
            label.Text = fileName + "\n" + "전송대기";

            ProgressBar progressBar = new ProgressBar();
            progressBar.Name = "pgbFileTransfer" + sRCV + iFileTransCntRcv;
            pnlFileListRcv.Controls.Add(label);
            pnlFileListRcv.Controls.Add(progressBar);

            label.Top = iLabelGap + iPnlHeightRcv;
            label.Left = 3 + iPnlLeftRcv;
            label.Height = 25;
            label.BackColor = System.Drawing.Color.Aqua;
            label.Font = new Font("굴림", 9, FontStyle.Regular);

            progressBar.Top = iLabelGap + iPnlHeightRcv;
            progressBar.Left = 3 + label.Left;
            progressBar.Hide();

            Button btnOk = new Button();
            btnOk.Text = "수신";
            btnOk.Click += new EventHandler(btnOkClick);
            btnOk.Top = iLabelGap + iPnlHeightRcv;
            btnOk.Left = 3 + label.Width;
            btnOk.Height = 18;
            btnOk.Width = 45;
            btnOk.Font = new Font("굴림", 8, FontStyle.Regular);

            Button btnCancel = new Button();
            btnCancel.Text = "거부";
            btnCancel.Click += new EventHandler(btnCancelClick);
            btnCancel.Top = iLabelGap + iPnlHeightRcv;
            btnCancel.Left = 3 + label.Width + btnOk.Width + 3;
            btnCancel.Height = 18;
            btnCancel.Width = 45;
            btnCancel.Font = new Font("굴림", 8, FontStyle.Regular);

            pnlFileListRcv.Controls.Add(btnOk);
            pnlFileListRcv.Controls.Add(btnCancel);
            btnOk.BringToFront();
            btnCancel.BringToFront();

            setShortFileName(label, fileName);

            chatBox2.AppendText("Height=" + label.Height + " : Top=" + label.Top + "\n");

            iPnlHeightRcv += label.Height;

            if (!pnlFileStatus.Visible)
            {
                pnlFileStatus.Visible = true;
            }
        }

        private void btnOkClick(object sender, EventArgs e)
        {
            MessageBox.Show("File transfer Ok.");
        }

        private void btnCancelClick(object sender, EventArgs e)
        {
            MessageBox.Show("File transfer Refuse.");
        }

        private void setShortFileName(object sender, string fileName)
        {
            Label label = (Label)sender;
            // 텍스트 박스로부터 Graphics 객체를 얻는다.
            Graphics textGraphics = Graphics.FromHwnd(label.Handle);

            // 텍스트 박스의 내용(문자열)의 사이즈를 얻는다.

            StringFormat sf = new StringFormat( StringFormat.GenericTypographic ); 
            SizeF stringSize = textGraphics.MeasureString(label.Text, label.Font, 500, sf);
            /*stringSize.Width는 문자열의 폭이되고 stringSize.Height는 문자열의 높이가 된답니다. */

            // 텍스트박스의 Width와 문자열의 Width를 비교한다.
            if (stringSize.Width > 140 || fileName.Length > 10)//label.ClientSize.Width)
            {
                int lastIndex = fileName.LastIndexOf(".");
                label.Text = fileName.Substring(0, 5) + "..." + fileName.Substring(lastIndex, fileName.Length - lastIndex) + "\n" + "전송대기";
                ToolTip labelsToolTip = new System.Windows.Forms.ToolTip(new System.ComponentModel.Container());
                labelsToolTip.SetToolTip(label, fileName);
                //labelsToolTip. = "tip" + label.Name;
            }
            else
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mPanelSender.hide();
            //pnlFileStatus.Hide();
        }

        private void btnFileRcvClose_Click(object sender, EventArgs e)
        {
            mPanelReceiver2.hide();
            //pnlFileStatusRcv.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mPanelReceiver2.Dispose();
            //mPanelReceiver.Dispose();
            mPanelSender.Dispose();
        }
    }
}
