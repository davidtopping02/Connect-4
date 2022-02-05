namespace connect4Assignment
{
    partial class connect4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(connect4));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnReset = new System.Windows.Forms.Button();
            this.TxtPlayerTurnInfo = new System.Windows.Forms.TextBox();
            this.txtBoxWin = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.rulesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(941, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.rulesToolStripMenuItem.Text = "Rules";
            this.rulesToolStripMenuItem.Click += new System.EventHandler(this.rulesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnReset.Location = new System.Drawing.Point(837, 700);
            this.BtnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(73, 46);
            this.BtnReset.TabIndex = 1;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // TxtPlayerTurnInfo
            // 
            this.TxtPlayerTurnInfo.BackColor = System.Drawing.Color.RoyalBlue;
            this.TxtPlayerTurnInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPlayerTurnInfo.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPlayerTurnInfo.ForeColor = System.Drawing.SystemColors.Window;
            this.TxtPlayerTurnInfo.Location = new System.Drawing.Point(139, 42);
            this.TxtPlayerTurnInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtPlayerTurnInfo.Name = "TxtPlayerTurnInfo";
            this.TxtPlayerTurnInfo.Size = new System.Drawing.Size(347, 47);
            this.TxtPlayerTurnInfo.TabIndex = 2;
            this.TxtPlayerTurnInfo.TextChanged += new System.EventHandler(this.TxtPlayerTurnInfo_TextChanged);
            // 
            // txtBoxWin
            // 
            this.txtBoxWin.Location = new System.Drawing.Point(445, 53);
            this.txtBoxWin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxWin.Name = "txtBoxWin";
            this.txtBoxWin.Size = new System.Drawing.Size(140, 22);
            this.txtBoxWin.TabIndex = 3;
            this.txtBoxWin.TextChanged += new System.EventHandler(this.txtBoxWin_TextChanged);
            // 
            // connect4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(941, 823);
            this.Controls.Add(this.txtBoxWin);
            this.Controls.Add(this.TxtPlayerTurnInfo);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "connect4";
            this.Text = "Connect 4 (play)";
            this.Load += new System.EventHandler(this.connect4_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.TextBox TxtPlayerTurnInfo;
        private System.Windows.Forms.TextBox txtBoxWin;
    }
}

