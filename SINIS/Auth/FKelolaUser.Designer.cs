namespace SINIS.Auth
{
    partial class FKelolaUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FKelolaUser));
            this.BBatal = new System.Windows.Forms.Button();
            this.BSimpan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TbPassword = new System.Windows.Forms.TextBox();
            this.CbHakAkses = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TbUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TbUlangPassword = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BBatal
            // 
            this.BBatal.BackColor = System.Drawing.Color.Crimson;
            this.BBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBatal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBatal.ForeColor = System.Drawing.Color.White;
            this.BBatal.Location = new System.Drawing.Point(26, 26);
            this.BBatal.Margin = new System.Windows.Forms.Padding(4);
            this.BBatal.Name = "BBatal";
            this.BBatal.Size = new System.Drawing.Size(129, 45);
            this.BBatal.TabIndex = 10;
            this.BBatal.Text = "Batal";
            this.BBatal.UseVisualStyleBackColor = false;
            // 
            // BSimpan
            // 
            this.BSimpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BSimpan.BackColor = System.Drawing.Color.Crimson;
            this.BSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSimpan.ForeColor = System.Drawing.Color.White;
            this.BSimpan.Location = new System.Drawing.Point(211, 26);
            this.BSimpan.Margin = new System.Windows.Forms.Padding(4);
            this.BSimpan.Name = "BSimpan";
            this.BSimpan.Size = new System.Drawing.Size(129, 45);
            this.BSimpan.TabIndex = 8;
            this.BSimpan.Text = "Simpan";
            this.BSimpan.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BSimpan);
            this.groupBox1.Controls.Add(this.BBatal);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 86);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TOOLS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "USERNAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "PASSWORD";
            // 
            // TbPassword
            // 
            this.TbPassword.Location = new System.Drawing.Point(140, 48);
            this.TbPassword.Name = "TbPassword";
            this.TbPassword.PasswordChar = '*';
            this.TbPassword.Size = new System.Drawing.Size(200, 26);
            this.TbPassword.TabIndex = 1;
            // 
            // CbHakAkses
            // 
            this.CbHakAkses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbHakAkses.FormattingEnabled = true;
            this.CbHakAkses.Items.AddRange(new object[] {
            "USER",
            "CS",
            "PACKER",
            "CHECKER",
            "MANAGER",
            "ADMIN"});
            this.CbHakAkses.Location = new System.Drawing.Point(140, 112);
            this.CbHakAkses.MaxLength = 50;
            this.CbHakAkses.Name = "CbHakAkses";
            this.CbHakAkses.Size = new System.Drawing.Size(200, 28);
            this.CbHakAkses.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "HAK AKSES";
            // 
            // TbUsername
            // 
            this.TbUsername.Location = new System.Drawing.Point(140, 16);
            this.TbUsername.Name = "TbUsername";
            this.TbUsername.Size = new System.Drawing.Size(200, 26);
            this.TbUsername.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "ULANG PASS";
            // 
            // TbUlangPassword
            // 
            this.TbUlangPassword.Location = new System.Drawing.Point(140, 80);
            this.TbUlangPassword.Name = "TbUlangPassword";
            this.TbUlangPassword.PasswordChar = '*';
            this.TbUlangPassword.Size = new System.Drawing.Size(200, 26);
            this.TbUlangPassword.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TbUlangPassword);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TbUsername);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CbHakAkses);
            this.panel1.Controls.Add(this.TbPassword);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 163);
            this.panel1.TabIndex = 31;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Crimson;
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(367, 57);
            this.flowLayoutPanel1.TabIndex = 88;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(3, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(421, 57);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "[form]";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // FKelolaUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(367, 306);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FKelolaUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USER";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BBatal;
        private System.Windows.Forms.Button BSimpan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TbPassword;
        private System.Windows.Forms.ComboBox CbHakAkses;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TbUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbUlangPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}