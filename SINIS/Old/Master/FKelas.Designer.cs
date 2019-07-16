namespace Project_SINS.Master
{
    partial class FKelas
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lwali = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linformasi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbkelas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbtahunajaran = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgsiswa = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsiswa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "INFORMASI KELAS";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lwali);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.linformasi);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbkelas);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbtahunajaran);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1010, 133);
            this.panel2.TabIndex = 6;
            // 
            // lwali
            // 
            this.lwali.AutoSize = true;
            this.lwali.Location = new System.Drawing.Point(715, 93);
            this.lwali.Name = "lwali";
            this.lwali.Size = new System.Drawing.Size(0, 20);
            this.lwali.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(604, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "WALI KELAS";
            // 
            // linformasi
            // 
            this.linformasi.AutoSize = true;
            this.linformasi.Location = new System.Drawing.Point(240, 60);
            this.linformasi.Name = "linformasi";
            this.linformasi.Size = new System.Drawing.Size(190, 20);
            this.linformasi.TabIndex = 13;
            this.linformasi.Text = "INFORMASI PENGAJAR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "INFORMASI PENGAJAR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "KELAS";
            // 
            // cbkelas
            // 
            this.cbkelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbkelas.FormattingEnabled = true;
            this.cbkelas.Location = new System.Drawing.Point(403, 90);
            this.cbkelas.Name = "cbkelas";
            this.cbkelas.Size = new System.Drawing.Size(164, 28);
            this.cbkelas.TabIndex = 10;
            this.cbkelas.SelectedIndexChanged += new System.EventHandler(this.cbkelas_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "TAHUN AJARAN";
            // 
            // cbtahunajaran
            // 
            this.cbtahunajaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtahunajaran.FormattingEnabled = true;
            this.cbtahunajaran.ItemHeight = 20;
            this.cbtahunajaran.Location = new System.Drawing.Point(150, 90);
            this.cbtahunajaran.Name = "cbtahunajaran";
            this.cbtahunajaran.Size = new System.Drawing.Size(180, 28);
            this.cbtahunajaran.TabIndex = 6;
            this.cbtahunajaran.SelectedIndexChanged += new System.EventHandler(this.cbtahunajaran_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 52);
            this.panel1.TabIndex = 2;
            // 
            // dgsiswa
            // 
            this.dgsiswa.AllowUserToAddRows = false;
            this.dgsiswa.AllowUserToDeleteRows = false;
            this.dgsiswa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgsiswa.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgsiswa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgsiswa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsiswa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4});
            this.dgsiswa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsiswa.Location = new System.Drawing.Point(0, 133);
            this.dgsiswa.Name = "dgsiswa";
            this.dgsiswa.ReadOnly = true;
            this.dgsiswa.RowHeadersVisible = false;
            this.dgsiswa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgsiswa.Size = new System.Drawing.Size(1010, 370);
            this.dgsiswa.TabIndex = 7;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ID SISWA";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "NAMA";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "NIS";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "JENIS KELAMIN";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "TANGGAL MASUK";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // FKelas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1010, 503);
            this.Controls.Add(this.dgsiswa);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FKelas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kelas";
            this.Load += new System.EventHandler(this.FKelas_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsiswa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label linformasi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbkelas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbtahunajaran;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgsiswa;
        private System.Windows.Forms.Label lwali;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}