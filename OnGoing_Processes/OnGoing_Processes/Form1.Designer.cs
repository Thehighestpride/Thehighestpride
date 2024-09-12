namespace OnGoing_Processes
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pBSet = new System.Windows.Forms.PictureBox();
			this.pBClose = new System.Windows.Forms.PictureBox();
			this.lblmem = new System.Windows.Forms.Label();
			this.lblogProc = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.닫기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.즐겨찾기저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listView1 = new System.Windows.Forms.ListView();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pBSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pBClose)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Controls.Add(this.pBSet);
			this.panel1.Controls.Add(this.pBClose);
			this.panel1.Controls.Add(this.lblmem);
			this.panel1.Controls.Add(this.lblogProc);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(350, 47);
			this.panel1.TabIndex = 1;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
			this.pictureBox2.Image = global::OnGoing_Processes.Properties.Resources.즐겨찾기_6;
			this.pictureBox2.Location = new System.Drawing.Point(185, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(55, 47);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 10;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// pBSet
			// 
			this.pBSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.pBSet.Dock = System.Windows.Forms.DockStyle.Right;
			this.pBSet.Image = global::OnGoing_Processes.Properties.Resources.설정버튼;
			this.pBSet.Location = new System.Drawing.Point(240, 0);
			this.pBSet.Name = "pBSet";
			this.pBSet.Size = new System.Drawing.Size(55, 47);
			this.pBSet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pBSet.TabIndex = 9;
			this.pBSet.TabStop = false;
			this.pBSet.Click += new System.EventHandler(this.pBSet_Click);
			// 
			// pBClose
			// 
			this.pBClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.pBClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.pBClose.Image = global::OnGoing_Processes.Properties.Resources.btnDel;
			this.pBClose.Location = new System.Drawing.Point(295, 0);
			this.pBClose.Name = "pBClose";
			this.pBClose.Size = new System.Drawing.Size(55, 47);
			this.pBClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pBClose.TabIndex = 8;
			this.pBClose.TabStop = false;
			this.pBClose.Click += new System.EventHandler(this.pBClose_Click);
			// 
			// lblmem
			// 
			this.lblmem.AutoSize = true;
			this.lblmem.Location = new System.Drawing.Point(12, 32);
			this.lblmem.Name = "lblmem";
			this.lblmem.Size = new System.Drawing.Size(38, 12);
			this.lblmem.TabIndex = 6;
			this.lblmem.Text = "label1";
			// 
			// lblogProc
			// 
			this.lblogProc.AutoSize = true;
			this.lblogProc.Location = new System.Drawing.Point(12, 9);
			this.lblogProc.Name = "lblogProc";
			this.lblogProc.Size = new System.Drawing.Size(38, 12);
			this.lblogProc.TabIndex = 5;
			this.lblogProc.Text = "label1";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.닫기ToolStripMenuItem,
            this.즐겨찾기저장ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(151, 48);
			// 
			// 닫기ToolStripMenuItem
			// 
			this.닫기ToolStripMenuItem.Name = "닫기ToolStripMenuItem";
			this.닫기ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.닫기ToolStripMenuItem.Text = "닫기";
			this.닫기ToolStripMenuItem.Click += new System.EventHandler(this.닫기ToolStripMenuItem_Click);
			// 
			// 즐겨찾기저장ToolStripMenuItem
			// 
			this.즐겨찾기저장ToolStripMenuItem.Name = "즐겨찾기저장ToolStripMenuItem";
			this.즐겨찾기저장ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.즐겨찾기저장ToolStripMenuItem.Text = "즐겨찾기 저장";
			this.즐겨찾기저장ToolStripMenuItem.Click += new System.EventHandler(this.즐겨찾기저장ToolStripMenuItem_Click);
			// 
			// listView1
			// 
			this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 111);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(350, 309);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Image = global::OnGoing_Processes.Properties.Resources.내리기;
			this.pictureBox1.Location = new System.Drawing.Point(0, 47);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(350, 64);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// timer2
			// 
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(350, 420);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.listView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Form1";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pBSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pBClose)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblmem;
        private System.Windows.Forms.Label lblogProc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pBSet;
        private System.Windows.Forms.PictureBox pBClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 닫기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 즐겨찾기저장ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer timer2;
    }
}

