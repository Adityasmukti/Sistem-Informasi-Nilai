namespace AtelierAngelinaApps.Auxs
{
    partial class FDeskripsi
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.BOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbs_waktu = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbs_nama = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbshakakses = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbs_datang = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TbText = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Crimson;
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1023, 57);
            this.flowLayoutPanel1.TabIndex = 106;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(3, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(819, 57);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "CARI DATA ORDER";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // BOk
            // 
            this.BOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BOk.BackColor = System.Drawing.Color.Crimson;
            this.BOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BOk.ForeColor = System.Drawing.Color.White;
            this.BOk.Location = new System.Drawing.Point(902, 8);
            this.BOk.Margin = new System.Windows.Forms.Padding(4);
            this.BOk.Name = "BOk";
            this.BOk.Size = new System.Drawing.Size(108, 35);
            this.BOk.TabIndex = 44;
            this.BOk.Text = "OK";
            this.BOk.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 521);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1023, 49);
            this.panel1.TabIndex = 104;
            // 
            // lbs_waktu
            // 
            this.lbs_waktu.ActiveLinkColor = System.Drawing.Color.Red;
            this.lbs_waktu.ForeColor = System.Drawing.Color.White;
            this.lbs_waktu.LinkColor = System.Drawing.Color.White;
            this.lbs_waktu.Name = "lbs_waktu";
            this.lbs_waktu.Size = new System.Drawing.Size(178, 17);
            this.lbs_waktu.Text = "Semoga Harimu Menyenangkan";
            // 
            // lbs_nama
            // 
            this.lbs_nama.ForeColor = System.Drawing.Color.White;
            this.lbs_nama.Name = "lbs_nama";
            this.lbs_nama.Size = new System.Drawing.Size(540, 17);
            this.lbs_nama.Spring = true;
            this.lbs_nama.Text = "Aplikasi Butik Atelier Angelina";
            // 
            // lbshakakses
            // 
            this.lbshakakses.AutoSize = false;
            this.lbshakakses.ForeColor = System.Drawing.Color.White;
            this.lbshakakses.Name = "lbshakakses";
            this.lbshakakses.Size = new System.Drawing.Size(200, 17);
            this.lbshakakses.Text = "toolStripStatusLabel1";
            // 
            // lbs_datang
            // 
            this.lbs_datang.ForeColor = System.Drawing.Color.White;
            this.lbs_datang.Name = "lbs_datang";
            this.lbs_datang.Size = new System.Drawing.Size(90, 17);
            this.lbs_datang.Text = "Selamat Datang";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(76)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbs_datang,
            this.lbshakakses,
            this.lbs_nama,
            this.lbs_waktu});
            this.statusStrip1.Location = new System.Drawing.Point(0, 570);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1023, 22);
            this.statusStrip1.TabIndex = 105;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TbText
            // 
            this.TbText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbText.Location = new System.Drawing.Point(0, 57);
            this.TbText.Margin = new System.Windows.Forms.Padding(20);
            this.TbText.Name = "TbText";
            this.TbText.Size = new System.Drawing.Size(1023, 464);
            this.TbText.TabIndex = 107;
            this.TbText.Text = "";
            // 
            // FDeskripsi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1023, 592);
            this.Controls.Add(this.TbText);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FDeskripsi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DESKRIPSI";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button BOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel lbs_waktu;
        private System.Windows.Forms.ToolStripStatusLabel lbs_nama;
        private System.Windows.Forms.ToolStripStatusLabel lbshakakses;
        private System.Windows.Forms.ToolStripStatusLabel lbs_datang;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.RichTextBox TbText;
    }
}