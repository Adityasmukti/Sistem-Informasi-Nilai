namespace Project_SINS.Penjadwalan
{
    partial class FPengajaran
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
            this.dgpengajaran = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbkelas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbguru = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbtahunajaran = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgpengajaran)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgpengajaran
            // 
            this.dgpengajaran.AllowUserToAddRows = false;
            this.dgpengajaran.AllowUserToDeleteRows = false;
            this.dgpengajaran.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgpengajaran.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgpengajaran.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgpengajaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgpengajaran.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column5,
            this.Column7,
            this.Column3,
            this.Column4});
            this.dgpengajaran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgpengajaran.Location = new System.Drawing.Point(0, 96);
            this.dgpengajaran.Name = "dgpengajaran";
            this.dgpengajaran.RowHeadersVisible = false;
            this.dgpengajaran.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgpengajaran.Size = new System.Drawing.Size(958, 408);
            this.dgpengajaran.TabIndex = 4;
            this.dgpengajaran.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgpengajaran_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "JADWAL";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ID PELAJARAN";
            this.Column6.Name = "Column6";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "PELAJARAN";
            this.Column2.Name = "Column2";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "OLEH";
            this.Column5.Name = "Column5";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "ID JADWAL";
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ID KELAS";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ID GURU";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbkelas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbguru);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbtahunajaran);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 96);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(702, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "KELAS";
            // 
            // cbkelas
            // 
            this.cbkelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbkelas.FormattingEnabled = true;
            this.cbkelas.Location = new System.Drawing.Point(772, 58);
            this.cbkelas.Name = "cbkelas";
            this.cbkelas.Size = new System.Drawing.Size(164, 28);
            this.cbkelas.TabIndex = 4;
            this.cbkelas.SelectedIndexChanged += new System.EventHandler(this.cbtahunajaran_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "GURU";
            // 
            // cbguru
            // 
            this.cbguru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbguru.FormattingEnabled = true;
            this.cbguru.Location = new System.Drawing.Point(432, 58);
            this.cbguru.Name = "cbguru";
            this.cbguru.Size = new System.Drawing.Size(230, 28);
            this.cbguru.TabIndex = 2;
            this.cbguru.SelectedIndexChanged += new System.EventHandler(this.cbtahunajaran_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 61);
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
            this.cbtahunajaran.Location = new System.Drawing.Point(158, 58);
            this.cbtahunajaran.Name = "cbtahunajaran";
            this.cbtahunajaran.Size = new System.Drawing.Size(180, 28);
            this.cbtahunajaran.TabIndex = 0;
            this.cbtahunajaran.SelectedIndexChanged += new System.EventHandler(this.cbtahunajaran_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(958, 52);
            this.panel2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(505, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "PENGATURAN JADWAL MENGAJAR";
            // 
            // FPengajaran
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(958, 504);
            this.Controls.Add(this.dgpengajaran);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FPengajaran";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jadwal Mengajar";
            this.Load += new System.EventHandler(this.FPengajaran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgpengajaran)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgpengajaran;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbkelas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbguru;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbtahunajaran;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
    }
}