namespace SINIS.TU
{
    partial class FKelolaPengajaran
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.BSimpan = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BBatal = new System.Windows.Forms.Button();
            this.BHapus = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Dg = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CbJumlahJam = new System.Windows.Forms.ComboBox();
            this.CbMenit = new System.Windows.Forms.ComboBox();
            this.CbJam = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CbHari = new System.Windows.Forms.ComboBox();
            this.TbKelas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CbGuru = new System.Windows.Forms.ComboBox();
            this.TbTahunAjaran = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TbKodeMapel = new System.Windows.Forms.TextBox();
            this.TbKeterangan = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TbPelajaran = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dg)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.linkLabel1.Size = new System.Drawing.Size(755, 57);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "[form]";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // BSimpan
            // 
            this.BSimpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BSimpan.BackColor = System.Drawing.Color.Crimson;
            this.BSimpan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSimpan.ForeColor = System.Drawing.Color.White;
            this.BSimpan.Location = new System.Drawing.Point(660, 8);
            this.BSimpan.Margin = new System.Windows.Forms.Padding(4);
            this.BSimpan.Name = "BSimpan";
            this.BSimpan.Size = new System.Drawing.Size(108, 35);
            this.BSimpan.TabIndex = 44;
            this.BSimpan.Text = "Simpan";
            this.BSimpan.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BBatal);
            this.panel3.Controls.Add(this.BHapus);
            this.panel3.Controls.Add(this.BSimpan);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 428);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(772, 49);
            this.panel3.TabIndex = 112;
            // 
            // BBatal
            // 
            this.BBatal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BBatal.BackColor = System.Drawing.Color.Crimson;
            this.BBatal.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBatal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBatal.ForeColor = System.Drawing.Color.White;
            this.BBatal.Location = new System.Drawing.Point(15, 8);
            this.BBatal.Margin = new System.Windows.Forms.Padding(4);
            this.BBatal.Name = "BBatal";
            this.BBatal.Size = new System.Drawing.Size(108, 35);
            this.BBatal.TabIndex = 46;
            this.BBatal.Text = "Batal";
            this.BBatal.UseVisualStyleBackColor = false;
            this.BBatal.Click += new System.EventHandler(this.BBatal_Click);
            // 
            // BHapus
            // 
            this.BHapus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BHapus.BackColor = System.Drawing.Color.Crimson;
            this.BHapus.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BHapus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BHapus.ForeColor = System.Drawing.Color.White;
            this.BHapus.Location = new System.Drawing.Point(544, 8);
            this.BHapus.Margin = new System.Windows.Forms.Padding(4);
            this.BHapus.Name = "BHapus";
            this.BHapus.Size = new System.Drawing.Size(108, 35);
            this.BHapus.TabIndex = 45;
            this.BHapus.Text = "Hapus";
            this.BHapus.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Crimson;
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(772, 57);
            this.flowLayoutPanel1.TabIndex = 111;
            // 
            // Dg
            // 
            this.Dg.AllowUserToAddRows = false;
            this.Dg.AllowUserToDeleteRows = false;
            this.Dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dg.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dg.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dg.Location = new System.Drawing.Point(0, 179);
            this.Dg.Name = "Dg";
            this.Dg.RowHeadersVisible = false;
            this.Dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dg.Size = new System.Drawing.Size(772, 249);
            this.Dg.TabIndex = 116;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID WAKTU";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "HARI";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "WAKTU";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "JUMLAH JAM";
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column6.HeaderText = "HAPUS";
            this.Column6.Name = "Column6";
            this.Column6.Width = 69;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.TbPelajaran);
            this.panel1.Controls.Add(this.TbKeterangan);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.TbKodeMapel);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CbJumlahJam);
            this.panel1.Controls.Add(this.CbMenit);
            this.panel1.Controls.Add(this.CbJam);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CbHari);
            this.panel1.Controls.Add(this.TbKelas);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CbGuru);
            this.panel1.Controls.Add(this.TbTahunAjaran);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 122);
            this.panel1.TabIndex = 115;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 140;
            this.label7.Text = "KETERANGAN";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(699, 90);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 25);
            this.button1.TabIndex = 139;
            this.button1.Text = "Tambah";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(459, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 138;
            this.label6.Text = "JUMLAH JAM";
            // 
            // CbJumlahJam
            // 
            this.CbJumlahJam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbJumlahJam.FormattingEnabled = true;
            this.CbJumlahJam.Location = new System.Drawing.Point(539, 90);
            this.CbJumlahJam.Name = "CbJumlahJam";
            this.CbJumlahJam.Size = new System.Drawing.Size(153, 21);
            this.CbJumlahJam.TabIndex = 137;
            // 
            // CbMenit
            // 
            this.CbMenit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbMenit.FormattingEnabled = true;
            this.CbMenit.Location = new System.Drawing.Point(369, 90);
            this.CbMenit.Name = "CbMenit";
            this.CbMenit.Size = new System.Drawing.Size(84, 21);
            this.CbMenit.TabIndex = 136;
            // 
            // CbJam
            // 
            this.CbJam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbJam.FormattingEnabled = true;
            this.CbJam.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.CbJam.Location = new System.Drawing.Point(279, 90);
            this.CbJam.Name = "CbJam";
            this.CbJam.Size = new System.Drawing.Size(84, 21);
            this.CbJam.TabIndex = 135;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "JAM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 133;
            this.label1.Text = "HARI";
            // 
            // CbHari
            // 
            this.CbHari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbHari.FormattingEnabled = true;
            this.CbHari.Items.AddRange(new object[] {
            "SENIN",
            "SELASA",
            "RABU",
            "KAMIS",
            "JUMAT",
            "SABTU",
            "MINGGU"});
            this.CbHari.Location = new System.Drawing.Point(50, 90);
            this.CbHari.Name = "CbHari";
            this.CbHari.Size = new System.Drawing.Size(189, 21);
            this.CbHari.TabIndex = 132;
            // 
            // TbKelas
            // 
            this.TbKelas.Location = new System.Drawing.Point(287, 6);
            this.TbKelas.Name = "TbKelas";
            this.TbKelas.Size = new System.Drawing.Size(215, 20);
            this.TbKelas.TabIndex = 131;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 126;
            this.label5.Text = "TAHUN AJARAN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 129;
            this.label3.Text = "KELAS";
            // 
            // CbGuru
            // 
            this.CbGuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbGuru.FormattingEnabled = true;
            this.CbGuru.Location = new System.Drawing.Point(553, 6);
            this.CbGuru.Name = "CbGuru";
            this.CbGuru.Size = new System.Drawing.Size(210, 21);
            this.CbGuru.TabIndex = 127;
            // 
            // TbTahunAjaran
            // 
            this.TbTahunAjaran.Location = new System.Drawing.Point(104, 6);
            this.TbTahunAjaran.Name = "TbTahunAjaran";
            this.TbTahunAjaran.Size = new System.Drawing.Size(130, 20);
            this.TbTahunAjaran.TabIndex = 130;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 128;
            this.label2.Text = "GURU";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 142;
            this.label8.Text = "KODE MAPEL";
            // 
            // TbKodeMapel
            // 
            this.TbKodeMapel.Location = new System.Drawing.Point(104, 32);
            this.TbKodeMapel.Name = "TbKodeMapel";
            this.TbKodeMapel.Size = new System.Drawing.Size(259, 20);
            this.TbKodeMapel.TabIndex = 143;
            // 
            // TbKeterangan
            // 
            this.TbKeterangan.Location = new System.Drawing.Point(104, 58);
            this.TbKeterangan.Name = "TbKeterangan";
            this.TbKeterangan.Size = new System.Drawing.Size(659, 20);
            this.TbKeterangan.TabIndex = 144;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(369, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 145;
            this.label9.Text = "PELAJARAN";
            // 
            // TbPelajaran
            // 
            this.TbPelajaran.Location = new System.Drawing.Point(444, 32);
            this.TbPelajaran.Name = "TbPelajaran";
            this.TbPelajaran.Size = new System.Drawing.Size(319, 20);
            this.TbPelajaran.TabIndex = 146;
            // 
            // FKelolaPengajaran
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(772, 477);
            this.Controls.Add(this.Dg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FKelolaPengajaran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KELOLA JADWAL";
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button BSimpan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView Dg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BHapus;
        private System.Windows.Forms.Button BBatal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CbJumlahJam;
        private System.Windows.Forms.ComboBox CbMenit;
        private System.Windows.Forms.ComboBox CbJam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbHari;
        private System.Windows.Forms.TextBox TbKelas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CbGuru;
        private System.Windows.Forms.TextBox TbTahunAjaran;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TbKodeMapel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TbPelajaran;
        private System.Windows.Forms.TextBox TbKeterangan;
    }
}