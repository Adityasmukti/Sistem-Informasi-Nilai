namespace SINIS.Pengajar
{
    partial class FLaporanNilai
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.bprint = new System.Windows.Forms.Button();
            this.bexport = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbsiswa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbjenisnilai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cblaporan = new System.Windows.Forms.ComboBox();
            this.linformasi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbkelas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbpelajaran = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbtahunajaran = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.dglaporan = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglaporan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bprint);
            this.panel2.Controls.Add(this.bexport);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbsiswa);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbjenisnilai);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cblaporan);
            this.panel2.Controls.Add(this.linformasi);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbkelas);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbpelajaran);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbtahunajaran);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 271);
            this.panel2.TabIndex = 14;
            // 
            // bprint
            // 
            this.bprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bprint.BackColor = System.Drawing.Color.MidnightBlue;
            this.bprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bprint.ForeColor = System.Drawing.Color.White;
            this.bprint.Location = new System.Drawing.Point(678, 99);
            this.bprint.Name = "bprint";
            this.bprint.Size = new System.Drawing.Size(94, 35);
            this.bprint.TabIndex = 21;
            this.bprint.Text = "PRINT";
            this.bprint.UseVisualStyleBackColor = false;
            this.bprint.Visible = false;
            // 
            // bexport
            // 
            this.bexport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bexport.BackColor = System.Drawing.Color.MidnightBlue;
            this.bexport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bexport.ForeColor = System.Drawing.Color.White;
            this.bexport.Location = new System.Drawing.Point(678, 58);
            this.bexport.Name = "bexport";
            this.bexport.Size = new System.Drawing.Size(94, 35);
            this.bexport.TabIndex = 20;
            this.bexport.Text = "EXPORT";
            this.bexport.UseVisualStyleBackColor = false;
            this.bexport.Click += new System.EventHandler(this.bexport_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(313, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "SISWA";
            // 
            // cbsiswa
            // 
            this.cbsiswa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsiswa.Enabled = false;
            this.cbsiswa.FormattingEnabled = true;
            this.cbsiswa.Location = new System.Drawing.Point(381, 124);
            this.cbsiswa.Name = "cbsiswa";
            this.cbsiswa.Size = new System.Drawing.Size(199, 21);
            this.cbsiswa.TabIndex = 18;
            this.cbsiswa.SelectedIndexChanged += new System.EventHandler(this.cbsiswa_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "NILAI";
            // 
            // cbjenisnilai
            // 
            this.cbjenisnilai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbjenisnilai.Enabled = false;
            this.cbjenisnilai.FormattingEnabled = true;
            this.cbjenisnilai.Location = new System.Drawing.Point(181, 205);
            this.cbjenisnilai.Name = "cbjenisnilai";
            this.cbjenisnilai.Size = new System.Drawing.Size(199, 21);
            this.cbjenisnilai.TabIndex = 16;
            this.cbjenisnilai.SelectedIndexChanged += new System.EventHandler(this.cbjenisnilai_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "LAPORAN";
            // 
            // cblaporan
            // 
            this.cblaporan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cblaporan.FormattingEnabled = true;
            this.cblaporan.Items.AddRange(new object[] {
            "PERSISWA",
            "PERNILAI",
            "SEMUA"});
            this.cblaporan.Location = new System.Drawing.Point(110, 124);
            this.cblaporan.Name = "cblaporan";
            this.cblaporan.Size = new System.Drawing.Size(199, 21);
            this.cblaporan.TabIndex = 14;
            this.cblaporan.SelectedIndexChanged += new System.EventHandler(this.cblaporan_SelectedIndexChanged);
            // 
            // linformasi
            // 
            this.linformasi.AutoSize = true;
            this.linformasi.Location = new System.Drawing.Point(240, 60);
            this.linformasi.Name = "linformasi";
            this.linformasi.Size = new System.Drawing.Size(126, 13);
            this.linformasi.TabIndex = 13;
            this.linformasi.Text = "INFORMASI PENGAJAR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "INFORMASI PENGAJAR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "KELAS";
            // 
            // cbkelas
            // 
            this.cbkelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbkelas.FormattingEnabled = true;
            this.cbkelas.Location = new System.Drawing.Point(381, 90);
            this.cbkelas.Name = "cbkelas";
            this.cbkelas.Size = new System.Drawing.Size(199, 21);
            this.cbkelas.TabIndex = 10;
            this.cbkelas.SelectedIndexChanged += new System.EventHandler(this.cbkelas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "MAPEL";
            // 
            // cbpelajaran
            // 
            this.cbpelajaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbpelajaran.FormattingEnabled = true;
            this.cbpelajaran.Location = new System.Drawing.Point(181, 171);
            this.cbpelajaran.Name = "cbpelajaran";
            this.cbpelajaran.Size = new System.Drawing.Size(199, 21);
            this.cbpelajaran.TabIndex = 8;
            this.cbpelajaran.SelectedIndexChanged += new System.EventHandler(this.cbpelajaran_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "TAHUN AJARAN";
            // 
            // cbtahunajaran
            // 
            this.cbtahunajaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtahunajaran.FormattingEnabled = true;
            this.cbtahunajaran.ItemHeight = 13;
            this.cbtahunajaran.Location = new System.Drawing.Point(110, 90);
            this.cbtahunajaran.Name = "cbtahunajaran";
            this.cbtahunajaran.Size = new System.Drawing.Size(199, 21);
            this.cbtahunajaran.TabIndex = 6;
            this.cbtahunajaran.SelectedIndexChanged += new System.EventHandler(this.cbtahunajaran_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 52);
            this.panel3.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(333, 31);
            this.label9.TabIndex = 0;
            this.label9.Text = "LAPORAN NILAI SISWA";
            // 
            // dglaporan
            // 
            this.dglaporan.AllowUserToAddRows = false;
            this.dglaporan.AllowUserToDeleteRows = false;
            this.dglaporan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dglaporan.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dglaporan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dglaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglaporan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dglaporan.Location = new System.Drawing.Point(0, 271);
            this.dglaporan.Name = "dglaporan";
            this.dglaporan.ReadOnly = true;
            this.dglaporan.RowHeadersVisible = false;
            this.dglaporan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dglaporan.Size = new System.Drawing.Size(784, 290);
            this.dglaporan.TabIndex = 15;
            // 
            // FLaporanNilai
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dglaporan);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FLaporanNilai";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laporan Nilai";
            this.Load += new System.EventHandler(this.FLaporanNilai_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglaporan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbsiswa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbjenisnilai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cblaporan;
        private System.Windows.Forms.Label linformasi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbkelas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbpelajaran;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbtahunajaran;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bprint;
        private System.Windows.Forms.Button bexport;
        private System.Windows.Forms.DataGridView dglaporan;
    }
}