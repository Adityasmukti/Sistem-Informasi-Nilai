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
            this.bbatal = new System.Windows.Forms.Button();
            this.bsimpan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbpassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbhakakses = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbusername = new System.Windows.Forms.TextBox();
            this.tbnama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpass2 = new System.Windows.Forms.TextBox();
            this.lnoadmin = new System.Windows.Forms.Label();
            this.tbjabatan = new System.Windows.Forms.TextBox();
            this.tbnoadmin = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bbatal
            // 
            this.bbatal.BackColor = System.Drawing.Color.Crimson;
            this.bbatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bbatal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbatal.ForeColor = System.Drawing.Color.White;
            this.bbatal.Location = new System.Drawing.Point(266, 28);
            this.bbatal.Margin = new System.Windows.Forms.Padding(4);
            this.bbatal.Name = "bbatal";
            this.bbatal.Size = new System.Drawing.Size(129, 45);
            this.bbatal.TabIndex = 10;
            this.bbatal.Text = "Batal";
            this.bbatal.UseVisualStyleBackColor = false;
            this.bbatal.Click += new System.EventHandler(this.Bbatal_Click_1);
            // 
            // bsimpan
            // 
            this.bsimpan.BackColor = System.Drawing.Color.Crimson;
            this.bsimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bsimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsimpan.ForeColor = System.Drawing.Color.White;
            this.bsimpan.Location = new System.Drawing.Point(55, 28);
            this.bsimpan.Margin = new System.Windows.Forms.Padding(4);
            this.bsimpan.Name = "bsimpan";
            this.bsimpan.Size = new System.Drawing.Size(129, 45);
            this.bsimpan.TabIndex = 8;
            this.bsimpan.Text = "Simpan";
            this.bsimpan.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bsimpan);
            this.groupBox1.Controls.Add(this.bbatal);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 86);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TOOLS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "USERNAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "PASSWORD";
            // 
            // tbpassword
            // 
            this.tbpassword.Location = new System.Drawing.Point(195, 57);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.PasswordChar = '*';
            this.tbpassword.Size = new System.Drawing.Size(200, 26);
            this.tbpassword.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "JABATAN";
            // 
            // cbhakakses
            // 
            this.cbhakakses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbhakakses.FormattingEnabled = true;
            this.cbhakakses.Items.AddRange(new object[] {
            "USER",
            "CS",
            "PACKER",
            "CHECKER",
            "MANAGER",
            "ADMIN"});
            this.cbhakakses.Location = new System.Drawing.Point(195, 121);
            this.cbhakakses.MaxLength = 50;
            this.cbhakakses.Name = "cbhakakses";
            this.cbhakakses.Size = new System.Drawing.Size(200, 28);
            this.cbhakakses.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "HAK AKSES";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "NAMA";
            // 
            // tbusername
            // 
            this.tbusername.Location = new System.Drawing.Point(195, 25);
            this.tbusername.Name = "tbusername";
            this.tbusername.Size = new System.Drawing.Size(200, 26);
            this.tbusername.TabIndex = 0;
            // 
            // tbnama
            // 
            this.tbnama.Location = new System.Drawing.Point(195, 157);
            this.tbnama.Name = "tbnama";
            this.tbnama.Size = new System.Drawing.Size(200, 26);
            this.tbnama.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "ULANG PASS";
            // 
            // tbpass2
            // 
            this.tbpass2.Location = new System.Drawing.Point(195, 89);
            this.tbpass2.Name = "tbpass2";
            this.tbpass2.PasswordChar = '*';
            this.tbpass2.Size = new System.Drawing.Size(200, 26);
            this.tbpass2.TabIndex = 2;
            // 
            // lnoadmin
            // 
            this.lnoadmin.AutoSize = true;
            this.lnoadmin.Location = new System.Drawing.Point(54, 224);
            this.lnoadmin.Name = "lnoadmin";
            this.lnoadmin.Size = new System.Drawing.Size(88, 20);
            this.lnoadmin.TabIndex = 46;
            this.lnoadmin.Text = "NO ADMIN";
            // 
            // tbjabatan
            // 
            this.tbjabatan.Location = new System.Drawing.Point(195, 189);
            this.tbjabatan.Name = "tbjabatan";
            this.tbjabatan.Size = new System.Drawing.Size(200, 26);
            this.tbjabatan.TabIndex = 47;
            // 
            // tbnoadmin
            // 
            this.tbnoadmin.Location = new System.Drawing.Point(195, 221);
            this.tbnoadmin.MaxLength = 3;
            this.tbnoadmin.Name = "tbnoadmin";
            this.tbnoadmin.Size = new System.Drawing.Size(200, 26);
            this.tbnoadmin.TabIndex = 48;
            this.tbnoadmin.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbnoadmin);
            this.panel1.Controls.Add(this.tbjabatan);
            this.panel1.Controls.Add(this.lnoadmin);
            this.panel1.Controls.Add(this.tbpass2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbnama);
            this.panel1.Controls.Add(this.tbusername);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbhakakses);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbpassword);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 271);
            this.panel1.TabIndex = 31;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Crimson;
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(449, 57);
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
            this.linkLabel1.Text = "KELOLA PENGGUNA";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // FKelolaUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(449, 414);
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
            this.Text = "TAMBAH";
            this.Load += new System.EventHandler(this.FKelolaUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bbatal;
        private System.Windows.Forms.Button bsimpan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbpassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbhakakses;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbusername;
        private System.Windows.Forms.TextBox tbnama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbpass2;
        private System.Windows.Forms.Label lnoadmin;
        private System.Windows.Forms.TextBox tbjabatan;
        private System.Windows.Forms.TextBox tbnoadmin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}