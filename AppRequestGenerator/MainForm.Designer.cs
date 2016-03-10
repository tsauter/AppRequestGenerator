namespace AppRequestGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButtonNewRequest = new System.Windows.Forms.ToolStripSplitButton();
            this.bnmhgToolStripMenuItemNewHttpRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.sMTPToolStripMenuItemNewSmtpRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonBookmarkTab = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 594);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1051, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1051, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButtonNewRequest,
            this.toolStripSeparator1,
            this.toolStripButtonBookmarkTab});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1051, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButtonNewRequest
            // 
            this.toolStripSplitButtonNewRequest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnmhgToolStripMenuItemNewHttpRequest,
            this.sMTPToolStripMenuItemNewSmtpRequest});
            this.toolStripSplitButtonNewRequest.Image = global::AppRequestGenerator.Properties.Resources.Expand_16xLG;
            this.toolStripSplitButtonNewRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonNewRequest.Name = "toolStripSplitButtonNewRequest";
            this.toolStripSplitButtonNewRequest.Size = new System.Drawing.Size(108, 22);
            this.toolStripSplitButtonNewRequest.Text = "New Request";
            this.toolStripSplitButtonNewRequest.ButtonClick += new System.EventHandler(this.toolStripSplitButtonNewRequest_ButtonClick);
            // 
            // bnmhgToolStripMenuItemNewHttpRequest
            // 
            this.bnmhgToolStripMenuItemNewHttpRequest.Name = "bnmhgToolStripMenuItemNewHttpRequest";
            this.bnmhgToolStripMenuItemNewHttpRequest.Size = new System.Drawing.Size(145, 22);
            this.bnmhgToolStripMenuItemNewHttpRequest.Text = "&HTTP/HTTPS";
            this.bnmhgToolStripMenuItemNewHttpRequest.Click += new System.EventHandler(this.bnmhgToolStripMenuItemNewHttpRequest_Click);
            // 
            // sMTPToolStripMenuItemNewSmtpRequest
            // 
            this.sMTPToolStripMenuItemNewSmtpRequest.Name = "sMTPToolStripMenuItemNewSmtpRequest";
            this.sMTPToolStripMenuItemNewSmtpRequest.Size = new System.Drawing.Size(145, 22);
            this.sMTPToolStripMenuItemNewSmtpRequest.Text = "&SMTP";
            this.sMTPToolStripMenuItemNewSmtpRequest.Click += new System.EventHandler(this.sMTPToolStripMenuItemNewSmtpRequest_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonBookmarkTab
            // 
            this.toolStripButtonBookmarkTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBookmarkTab.Image = global::AppRequestGenerator.Properties.Resources.bookmark_003_16xLG_debugger;
            this.toolStripButtonBookmarkTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBookmarkTab.Name = "toolStripButtonBookmarkTab";
            this.toolStripButtonBookmarkTab.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBookmarkTab.Text = "Bookmark Tab";
            this.toolStripButtonBookmarkTab.Click += new System.EventHandler(this.toolStripButtonBookmarkTab_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1051, 545);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(350, 545);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(697, 545);
            this.tabControl1.TabIndex = 0;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Bookmark files|*.argb|All files|*.*";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Bookmark files|*.argb|All files|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 616);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "App Request Generator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripButton toolStripButtonBookmarkTab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonNewRequest;
        private System.Windows.Forms.ToolStripMenuItem bnmhgToolStripMenuItemNewHttpRequest;
        private System.Windows.Forms.ToolStripMenuItem sMTPToolStripMenuItemNewSmtpRequest;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

