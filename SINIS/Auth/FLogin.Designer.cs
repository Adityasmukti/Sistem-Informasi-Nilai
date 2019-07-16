namespace AtelierAngelinaApps.Modul_HRD
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
            this.btlogin = new System.Windows.Forms.Button();
            this.tbpassword = new System.Windows.Forms.TextBox();
            this.tbusername = new System.Windows.Forms.TextBox();
            this.bclose = new System.Windows.Forms.Button();
            this.cbsaveusername = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.linkLabel1.Size = new System.Drawing.Size(351, 57);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "LOGIN";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Crimson;
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(536, 57);
            this.flowLayoutPanel1.TabIndex = 87;
            // 
            // btlogin
            // 
            this.btlogin.BackColor = System.Drawing.Color.SteelBlue;
            this.btlogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btlogin.Font = new System.Drawing.Font("Microsoft PhagsPa", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btlogin.ForeColor = System.Drawing.Color.White;
            this.btlogin.Location = new System.Drawing.Point(92, 168);
            this.btlogin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btlogin.Name = "btlogin";
            this.btlogin.Size = new System.Drawing.Size(176, 51);
            this.btlogin.TabIndex = 4;
            this.btlogin.Text = "LOGIN";
            this.btlogin.UseVisualStyleBackColor = false;
            this.btlogin.Click += new System.EventHandler(this.Blogin_Click);
            // 
            // tbpassword
            // 
            this.tbpassword.BackColor = System.Drawing.Color.White;
            this.tbpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpassword.ForeColor = System.Drawing.Color.DimGray;
            this.tbpassword.Location = new System.Drawing.Point(92, 89);
            this.tbpassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.Size = new System.Drawing.Size(368, 38);
            this.tbpassword.TabIndex = 2;
            this.tbpassword.Text = "Password";
            this.tbpassword.Enter += new System.EventHandler(this.Tbpassword_Enter);
            this.tbpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tbpassword_KeyPress);
            this.tbpassword.Leave += new System.EventHandler(this.Tbpassword_Leave);
            // 
            // tbusername
            // 
            this.tbusername.BackColor = System.Drawing.Color.White;
            this.tbusername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbusername.ForeColor = System.Drawing.Color.DimGray;
            this.tbusername.Location = new System.Drawing.Point(92, 32);
            this.tbusername.Margin = new System.Windows.Forms.Padding(4);
            this.tbusername.Name = "tbusername";
            this.tbusername.Size = new System.Drawing.Size(368, 38);
            this.tbusername.TabIndex = 0;
            this.tbusername.Text = "Username";
            this.tbusername.Enter += new System.EventHandler(this.Tbusername_Enter);
            this.tbusername.Leave += new System.EventHandler(this.Tbusername_Leave);
            // 
            // bclose
            // 
            this.bclose.BackColor = System.Drawing.Color.SteelBlue;
            this.bclose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bclose.Font = new System.Drawing.Font("Microsoft PhagsPa", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bclose.ForeColor = System.Drawing.Color.White;
            this.bclose.Location = new System.Drawing.Point(284, 168);
            this.bclose.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.bclose.Name = "bclose";
            this.bclose.Size = new System.Drawing.Size(176, 51);
            this.bclose.TabIndex = 5;
            this.bclose.Text = "KELUAR";
            this.bclose.UseVisualStyleBackColor = false;
            // 
            // cbsaveusername
            // 
            this.cbsaveusername.AutoSize = true;
            this.cbsaveusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbsaveusername.ForeColor = System.Drawing.Color.SteelBlue;
            this.cbsaveusername.Location = new System.Drawing.Point(335, 134);
            this.cbsaveusername.Name = "cbsaveusername";
            this.cbsaveusername.Size = new System.Drawing.Size(127, 21);
            this.cbsaveusername.TabIndex = 3;
            this.cbsaveusername.Text = "Ingat Username";
            this.cbsaveusername.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbsaveusername);
            this.panel3.Controls.Add(this.bclose);
            this.panel3.Controls.Add(this.tbusername);
            this.panel3.Controls.Add(this.tbpassword);
            this.panel3.Controls.Add(this.btlogin);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(536, 260);
            this.panel3.TabIndex = 15;
            // 
            // FLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(533, 317);
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
            this.Text = "MEMBER LOGIN";
            this.Load += new System.EventHandler(this.FLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FLogin_KeyDown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btlogin;
        private System.Windows.Forms.TextBox tbpassword;
        private System.Windows.Forms.TextBox tbusername;
        private System.Windows.Forms.Button bclose;
        private System.Windows.Forms.CheckBox cbsaveusername;
        private System.Windows.Forms.Panel panel3;
    }
}