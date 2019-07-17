namespace SINIS.TU
{
    partial class FRuangKelas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbkelas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbthunmasuk = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbtahunajaran = new System.Windows.Forms.ComboBox();
            this.dgsiswa = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cbguru = new System.Windows.Forms.ComboBox();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsiswa)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbguru);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbkelas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbthunmasuk);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbtahunajaran);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1211, 95);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1211, 52);
            this.panel2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(426, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "PENGATURAN RUANG KELAS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(586, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "KELAS";
            // 
            // cbkelas
            // 
            this.cbkelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbkelas.FormattingEnabled = true;
            this.cbkelas.Location = new System.Drawing.Point(656, 58);
            this.cbkelas.Name = "cbkelas";
            this.cbkelas.Size = new System.Drawing.Size(119, 28);
            this.cbkelas.TabIndex = 4;
            this.cbkelas.SelectedIndexChanged += new System.EventHandler(this.cbkelas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "TAHUN MASUK";
            // 
            // cbthunmasuk
            // 
            this.cbthunmasuk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbthunmasuk.FormattingEnabled = true;
            this.cbthunmasuk.Location = new System.Drawing.Point(461, 58);
            this.cbthunmasuk.Name = "cbthunmasuk";
            this.cbthunmasuk.Size = new System.Drawing.Size(119, 28);
            this.cbthunmasuk.TabIndex = 2;
            this.cbthunmasuk.SelectedIndexChanged += new System.EventHandler(this.cbthunmasuk_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "TAHUN AJARAN";
            // 
            // cbtahunajaran
            // 
            this.cbtahunajaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtahunajaran.FormattingEnabled = true;
            this.cbtahunajaran.ItemHeight = 20;
            this.cbtahunajaran.Location = new System.Drawing.Point(144, 58);
            this.cbtahunajaran.Name = "cbtahunajaran";
            this.cbtahunajaran.Size = new System.Drawing.Size(180, 28);
            this.cbtahunajaran.TabIndex = 0;
            this.cbtahunajaran.SelectedIndexChanged += new System.EventHandler(this.cbtahunajaran_SelectedIndexChanged);
            // 
            // dgsiswa
            // 
            this.dgsiswa.AllowUserToAddRows = false;
            this.dgsiswa.AllowUserToDeleteRows = false;
            this.dgsiswa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgsiswa.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgsiswa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgsiswa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgsiswa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4,
            this.Column8,
            this.Column9,
            this.Column7});
            this.dgsiswa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsiswa.Location = new System.Drawing.Point(0, 95);
            this.dgsiswa.Name = "dgsiswa";
            this.dgsiswa.ReadOnly = true;
            this.dgsiswa.RowHeadersVisible = false;
            this.dgsiswa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgsiswa.Size = new System.Drawing.Size(1211, 407);
            this.dgsiswa.TabIndex = 2;
            this.dgsiswa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsiswa_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(791, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "WALI KELAS";
            // 
            // cbguru
            // 
            this.cbguru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbguru.FormattingEnabled = true;
            this.cbguru.Location = new System.Drawing.Point(902, 58);
            this.cbguru.Name = "cbguru";
            this.cbguru.Size = new System.Drawing.Size(245, 28);
            this.cbguru.TabIndex = 7;
            this.cbguru.SelectedIndexChanged += new System.EventHandler(this.cbguru_SelectedIndexChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "RUANGAN";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column4.HeaderText = "TANGGAL MASUK";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "KELAS";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "WALI KELAS";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "ID RUANGAN";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // FRuangKelas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1211, 502);
            this.Controls.Add(this.dgsiswa);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FRuangKelas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ruang Kelas";
            this.Load += new System.EventHandler(this.FRuangKelas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsiswa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbkelas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbthunmasuk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbtahunajaran;
        private System.Windows.Forms.DataGridView dgsiswa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbguru;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}