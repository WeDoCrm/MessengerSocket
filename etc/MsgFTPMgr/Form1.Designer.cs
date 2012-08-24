namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("노드1");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("노드2");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("노드5");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("노드6");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("노드7");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("노드3", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("노드4");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("노드0", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode22,
            treeNode23});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chatBox2 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.btnSend = new System.Windows.Forms.PictureBox();
            this.ReBox = new System.Windows.Forms.TextBox();
            this.pnlFileStatus = new System.Windows.Forms.Panel();
            this.pnlFileList = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlFileStatusRcv = new System.Windows.Forms.Panel();
            this.pnlFileListRcv = new System.Windows.Forms.Panel();
            this.btnFileRcvClose = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pnlFileListRcv2 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).BeginInit();
            this.pnlFileStatus.SuspendLayout();
            this.pnlFileStatusRcv.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Location = new System.Drawing.Point(12, 4);
            this.treeView1.Name = "treeView1";
            treeNode17.Name = "노드1";
            treeNode17.Text = "노드1";
            treeNode18.Name = "노드2";
            treeNode18.Text = "노드2";
            treeNode19.Name = "노드5";
            treeNode19.Text = "노드5";
            treeNode20.Name = "노드6";
            treeNode20.Text = "노드6";
            treeNode21.Name = "노드7";
            treeNode21.Text = "노드7";
            treeNode22.Name = "노드3";
            treeNode22.Text = "노드3";
            treeNode23.Name = "노드4";
            treeNode23.Text = "노드4";
            treeNode24.Name = "노드0";
            treeNode24.Text = "노드0";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode24});
            this.treeView1.Size = new System.Drawing.Size(183, 207);
            this.treeView1.TabIndex = 0;
            this.treeView1.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.treeView1_GiveFeedback);
            this.treeView1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView1_DrawNode);
            this.treeView1.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeView1_NodeMouseHover);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(201, 4);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(283, 257);
            this.chatBox.TabIndex = 2;
            this.chatBox.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 292);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(192, 18);
            this.progressBar1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "img_notice_e.png");
            // 
            // timer1
            // 
            this.timer1.Interval = 3;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chatBox2
            // 
            this.chatBox2.Location = new System.Drawing.Point(506, 4);
            this.chatBox2.Name = "chatBox2";
            this.chatBox2.Size = new System.Drawing.Size(283, 227);
            this.chatBox2.TabIndex = 5;
            this.chatBox2.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(120, 316);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(96, 345);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(165, 23);
            this.progressBar2.TabIndex = 7;
            // 
            // btnSend
            // 
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(420, 371);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(61, 58);
            this.btnSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSend.TabIndex = 9;
            this.btnSend.TabStop = false;
            // 
            // ReBox
            // 
            this.ReBox.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.ReBox.Location = new System.Drawing.Point(201, 374);
            this.ReBox.Multiline = true;
            this.ReBox.Name = "ReBox";
            this.ReBox.Size = new System.Drawing.Size(214, 51);
            this.ReBox.TabIndex = 8;
            // 
            // pnlFileStatus
            // 
            this.pnlFileStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFileStatus.Controls.Add(this.pnlFileList);
            this.pnlFileStatus.Controls.Add(this.button3);
            this.pnlFileStatus.Location = new System.Drawing.Point(202, 265);
            this.pnlFileStatus.Name = "pnlFileStatus";
            this.pnlFileStatus.Size = new System.Drawing.Size(278, 74);
            this.pnlFileStatus.TabIndex = 10;
            // 
            // pnlFileList
            // 
            this.pnlFileList.AutoScroll = true;
            this.pnlFileList.Location = new System.Drawing.Point(0, 14);
            this.pnlFileList.Name = "pnlFileList";
            this.pnlFileList.Size = new System.Drawing.Size(276, 56);
            this.pnlFileList.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(263, -1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(14, 14);
            this.button3.TabIndex = 0;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(-8, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "한글내자....jpg:\r\n전송대기";
            // 
            // pnlFileStatusRcv
            // 
            this.pnlFileStatusRcv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFileStatusRcv.Controls.Add(this.pnlFileListRcv2);
            this.pnlFileStatusRcv.Controls.Add(this.pnlFileListRcv);
            this.pnlFileStatusRcv.Controls.Add(this.btnFileRcvClose);
            this.pnlFileStatusRcv.Location = new System.Drawing.Point(511, 236);
            this.pnlFileStatusRcv.Name = "pnlFileStatusRcv";
            this.pnlFileStatusRcv.Size = new System.Drawing.Size(278, 193);
            this.pnlFileStatusRcv.TabIndex = 11;
            // 
            // pnlFileListRcv
            // 
            this.pnlFileListRcv.AutoScroll = true;
            this.pnlFileListRcv.Location = new System.Drawing.Point(0, 14);
            this.pnlFileListRcv.Name = "pnlFileListRcv";
            this.pnlFileListRcv.Size = new System.Drawing.Size(276, 56);
            this.pnlFileListRcv.TabIndex = 1;
            // 
            // btnFileRcvClose
            // 
            this.btnFileRcvClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileRcvClose.Image = ((System.Drawing.Image)(resources.GetObject("btnFileRcvClose.Image")));
            this.btnFileRcvClose.Location = new System.Drawing.Point(263, -1);
            this.btnFileRcvClose.Name = "btnFileRcvClose";
            this.btnFileRcvClose.Size = new System.Drawing.Size(14, 14);
            this.btnFileRcvClose.TabIndex = 0;
            this.btnFileRcvClose.UseVisualStyleBackColor = true;
            this.btnFileRcvClose.Click += new System.EventHandler(this.btnFileRcvClose_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("굴림", 8F);
            this.button4.Location = new System.Drawing.Point(295, 342);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(45, 18);
            this.button4.TabIndex = 12;
            this.button4.Text = "수신";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("굴림", 8F);
            this.button5.Location = new System.Drawing.Point(344, 342);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(45, 18);
            this.button5.TabIndex = 13;
            this.button5.Text = "취소";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // pnlFileListRcv2
            // 
            this.pnlFileListRcv2.AutoScroll = true;
            this.pnlFileListRcv2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlFileListRcv2.Location = new System.Drawing.Point(2, 77);
            this.pnlFileListRcv2.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFileListRcv2.Name = "pnlFileListRcv2";
            this.pnlFileListRcv2.Size = new System.Drawing.Size(273, 114);
            this.pnlFileListRcv2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 434);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pnlFileStatusRcv);
            this.Controls.Add(this.pnlFileStatus);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.ReBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chatBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Form1_DragOver);
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).EndInit();
            this.pnlFileStatus.ResumeLayout(false);
            this.pnlFileStatusRcv.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox chatBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar2;
        public System.Windows.Forms.PictureBox btnSend;
        public System.Windows.Forms.TextBox ReBox;
        private System.Windows.Forms.Panel pnlFileStatus;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlFileList;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlFileStatusRcv;
        private System.Windows.Forms.Panel pnlFileListRcv;
        private System.Windows.Forms.Button btnFileRcvClose;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FlowLayoutPanel pnlFileListRcv2;
    }
}

