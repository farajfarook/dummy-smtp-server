namespace dummy_smtp_server
{
    partial class FormMain
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.lblServerStatus = new System.Windows.Forms.ToolStripLabel();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabMail = new System.Windows.Forms.TabPage();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.lbxConsole = new System.Windows.Forms.ListBox();
            this.lbxEmails = new System.Windows.Forms.ListBox();
            this.toolStrip1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabMail.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStart,
            this.lblServerStatus,
            this.btnStop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 360);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(281, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnStart
            // 
            this.btnStart.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStart.Image = global::dummy_smtp_server.Properties.Resources.icon_play;
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(23, 22);
            this.btnStart.Text = "toolStripButton1";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(81, 22);
            this.lblServerStatus.Text = "server status...";
            // 
            // btnStop
            // 
            this.btnStop.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = global::dummy_smtp_server.Properties.Resources.icon_pause;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(23, 22);
            this.btnStop.Text = "toolStripButton2";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabMail);
            this.tabControlMain.Controls.Add(this.tabConsole);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.ItemSize = new System.Drawing.Size(58, 25);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.Padding = new System.Drawing.Point(10, 3);
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(281, 360);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabMail
            // 
            this.tabMail.Controls.Add(this.lbxEmails);
            this.tabMail.Location = new System.Drawing.Point(4, 29);
            this.tabMail.Name = "tabMail";
            this.tabMail.Padding = new System.Windows.Forms.Padding(3);
            this.tabMail.Size = new System.Drawing.Size(273, 327);
            this.tabMail.TabIndex = 0;
            this.tabMail.Text = "Emails Recieved";
            this.tabMail.UseVisualStyleBackColor = true;
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.lbxConsole);
            this.tabConsole.Location = new System.Drawing.Point(4, 29);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(273, 327);
            this.tabConsole.TabIndex = 1;
            this.tabConsole.Text = "Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // lbxConsole
            // 
            this.lbxConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxConsole.FormattingEnabled = true;
            this.lbxConsole.Location = new System.Drawing.Point(3, 3);
            this.lbxConsole.Name = "lbxConsole";
            this.lbxConsole.Size = new System.Drawing.Size(267, 321);
            this.lbxConsole.TabIndex = 0;
            // 
            // lbxEmails
            // 
            this.lbxEmails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxEmails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxEmails.FormattingEnabled = true;
            this.lbxEmails.Location = new System.Drawing.Point(3, 3);
            this.lbxEmails.Name = "lbxEmails";
            this.lbxEmails.Size = new System.Drawing.Size(267, 321);
            this.lbxEmails.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 385);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Dummy SMTP Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabMail.ResumeLayout(false);
            this.tabConsole.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripLabel lblServerStatus;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabMail;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.ListBox lbxConsole;
        private System.Windows.Forms.ListBox lbxEmails;



    }
}

