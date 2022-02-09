namespace connect4Assignment
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.playerVsPlayer = new System.Windows.Forms.Button();
            this.playerVsComputer = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::connect4Assignment.Properties.Resources.mainLogo;
            this.pictureBox1.Location = new System.Drawing.Point(-42, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1014, 288);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // playerVsPlayer
            // 
            this.playerVsPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playerVsPlayer.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerVsPlayer.ForeColor = System.Drawing.SystemColors.Control;
            this.playerVsPlayer.Location = new System.Drawing.Point(368, 393);
            this.playerVsPlayer.Name = "playerVsPlayer";
            this.playerVsPlayer.Size = new System.Drawing.Size(251, 103);
            this.playerVsPlayer.TabIndex = 1;
            this.playerVsPlayer.Text = "Player Vs Player";
            this.playerVsPlayer.UseVisualStyleBackColor = true;
            this.playerVsPlayer.Click += new System.EventHandler(this.playerVsPlayer_Click);
            // 
            // playerVsComputer
            // 
            this.playerVsComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playerVsComputer.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerVsComputer.ForeColor = System.Drawing.SystemColors.Control;
            this.playerVsComputer.Location = new System.Drawing.Point(368, 542);
            this.playerVsComputer.Name = "playerVsComputer";
            this.playerVsComputer.Size = new System.Drawing.Size(251, 103);
            this.playerVsComputer.TabIndex = 2;
            this.playerVsComputer.Text = "Player Vs Computer";
            this.playerVsComputer.UseVisualStyleBackColor = true;
            this.playerVsComputer.Click += new System.EventHandler(this.playerVsComputer_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnExit.Location = new System.Drawing.Point(406, 683);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(179, 82);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(941, 823);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.playerVsComputer);
            this.Controls.Add(this.playerVsPlayer);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect 4 (Menu)";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button playerVsPlayer;
        private System.Windows.Forms.Button playerVsComputer;
        private System.Windows.Forms.Button BtnExit;
    }

}