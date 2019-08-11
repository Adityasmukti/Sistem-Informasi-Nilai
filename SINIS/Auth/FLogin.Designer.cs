namespace SINIS.Auth
{
    partial class FLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLogin));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CbSaveUsername = new System.Windows.Forms.CheckBox();
            this.BKeluar = new System.Windows.Forms.Button();
            this.TbUsername = new System.Windows.Forms.TextBox();
            this.TbPassword = new System.Windows.Forms.TextBox();
            this.BLogin = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(3, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(666, 57);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "[form]";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Gray;
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(751, 57);
            this.flowLayoutPanel1.TabIndex = 87;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.CbSaveUsername);
            this.panel3.Controls.Add(this.BKeluar);
            this.panel3.Controls.Add(this.TbUsername);
            this.panel3.Controls.Add(this.TbPassword);
            this.panel3.Controls.Add(this.BLogin);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(751, 455);
            this.panel3.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(277, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // CbSaveUsername
            // 
            this.CbSaveUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbSaveUsername.AutoSize = true;
            this.CbSaveUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbSaveUsername.ForeColor = System.Drawing.Color.SteelBlue;
            this.CbSaveUsername.Location = new System.Drawing.Point(434, 314);
            this.CbSaveUsername.Name = "CbSaveUsername";
            this.CbSaveUsername.Size = new System.Drawing.Size(127, 21);
            this.CbSaveUsername.TabIndex = 3;
            this.CbSaveUsername.Text = "Ingat Username";
            this.CbSaveUsername.UseVisualStyleBackColor = true;
            // 
            // BKeluar
            // 
            this.BKeluar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BKeluar.BackColor = System.Drawing.Color.Gray;
            this.BKeluar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BKeluar.Font = new System.Drawing.Font("Microsoft PhagsPa", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BKeluar.ForeColor = System.Drawing.Color.White;
            this.BKeluar.Location = new System.Drawing.Point(191, 353);
            this.BKeluar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.BKeluar.Name = "BKeluar";
            this.BKeluar.Size = new System.Drawing.Size(176, 51);
            this.BKeluar.TabIndex = 5;
            this.BKeluar.Text = "KELUAR";
            this.BKeluar.UseVisualStyleBackColor = false;
            // 
            // TbUsername
            // 
            this.TbUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TbUsername.BackColor = System.Drawing.Color.White;
            this.TbUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbUsername.ForeColor = System.Drawing.Color.DimGray;
            this.TbUsername.Location = new System.Drawing.Point(191, 212);
            this.TbUsername.Margin = new System.Windows.Forms.Padding(4);
            this.TbUsername.Name = "TbUsername";
            this.TbUsername.Size = new System.Drawing.Size(368, 38);
            this.TbUsername.TabIndex = 0;
            this.TbUsername.Text = "Username";
            this.TbUsername.Enter += new System.EventHandler(this.Tbusername_Enter);
            this.TbUsername.Leave += new System.EventHandler(this.Tbusername_Leave);
            // 
            // TbPassword
            // 
            this.TbPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TbPassword.BackColor = System.Drawing.Color.White;
            this.TbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPassword.ForeColor = System.Drawing.Color.DimGray;
            this.TbPassword.Location = new System.Drawing.Point(191, 269);
            this.TbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TbPassword.Name = "TbPassword";
            this.TbPassword.Size = new System.Drawing.Size(368, 38);
            this.TbPassword.TabIndex = 2;
            this.TbPassword.Text = "Password";
            this.TbPassword.Enter += new System.EventHandler(this.Tbpassword_Enter);
            this.TbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tbpassword_KeyPress);
            this.TbPassword.Leave += new System.EventHandler(this.Tbpassword_Leave);
            // 
            // BLogin
            // 
            this.BLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BLogin.BackColor = System.Drawing.Color.Gray;
            this.BLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLogin.Font = new System.Drawing.Font("Microsoft PhagsPa", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLogin.ForeColor = System.Drawing.Color.White;
            this.BLogin.Location = new System.Drawing.Point(383, 353);
            this.BLogin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.BLogin.Name = "BLogin";
            this.BLogin.Size = new System.Drawing.Size(176, 51);
            this.BLogin.TabIndex = 4;
            this.BLogin.Text = "LOGIN";
            this.BLogin.UseVisualStyleBackColor = false;
            this.BLogin.Click += new System.EventHandler(this.Blogin_Click);
            // 
            // FLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(751, 512);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.FLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FLogin_KeyDown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox CbSaveUsername;
        private System.Windows.Forms.Button BKeluar;
        private System.Windows.Forms.TextBox TbUsername;
        private System.Windows.Forms.TextBox TbPassword;
        private System.Windows.Forms.Button BLogin;
    }
}