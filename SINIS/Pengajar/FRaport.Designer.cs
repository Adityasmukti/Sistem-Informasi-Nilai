namespace SINIS.Pengajar
{
    partial class FRaport
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
            this.bprint = new System.Windows.Forms.Button();
            this.dglaporan = new System.Windows.Forms.DataGridView();
            this.bexport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cblaporan = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbjenisnilai = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbsiswa = new System.Windows.Forms.ComboBox();
            this.linformasi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbkelas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbtahunajaran = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BOk = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbhalaman = new System.Windows.Forms.TextBox();
            this.bnext = new System.Windows.Forms.Button();
            this.ldarihalaman = new System.Windows.Forms.Label();
            this.bprev = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dglaporan)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bprint
            // 
            this.bprint.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bprint.BackColor = System.Drawing.Color.MidnightBlue;
            this.bprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bprint.ForeColor = System.Drawing.Color.White;
            this.bprint.Location = new System.Drawing.Point(678, 73);
            this.bprint.Name = "bprint";
            this.bprint.Size = new System.Drawing.Size(94, 35);
            this.bprint.TabIndex = 21;
            this.bprint.Text = "PRINT";
            this.bprint.UseVisualStyleBackColor = false;
            this.bprint.Visible = false;
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
            this.dglaporan.Location = new System.Drawing.Point(0, 208);
            this.dglaporan.Name = "dglaporan";
            this.dglaporan.ReadOnly = true;
            this.dglaporan.RowHeadersVisible = false;
            this.dglaporan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dglaporan.Size = new System.Drawing.Size(784, 353);
            this.dglaporan.TabIndex = 17;
            // 
            // bexport
            // 
            this.bexport.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bexport.BackColor = System.Drawing.Color.MidnightBlue;
            this.bexport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bexport.ForeColor = System.Drawing.Color.White;
            this.bexport.Location = new System.Drawing.Point(678, 32);
            this.bexport.Name = "bexport";
            this.bexport.Size = new System.Drawing.Size(94, 35);
            this.bexport.TabIndex = 20;
            this.bexport.Text = "EXPORT";
            this.bexport.UseVisualStyleBackColor = false;
            this.bexport.Click += new System.EventHandler(this.bexport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 82);
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
            "PERNILAI",
            "PERSISWA"});
            this.cblaporan.Location = new System.Drawing.Point(150, 79);
            this.cblaporan.Name = "cblaporan";
            this.cblaporan.Size = new System.Drawing.Size(199, 21);
            this.cblaporan.TabIndex = 14;
            this.cblaporan.SelectedIndexChanged += new System.EventHandler(this.cblaporan_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbjenisnilai);
            this.panel2.Controls.Add(this.bprint);
            this.panel2.Controls.Add(this.bexport);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbsiswa);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cblaporan);
            this.panel2.Controls.Add(this.linformasi);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbkelas);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbtahunajaran);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 151);
            this.panel2.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "JENIS NILAI";
            // 
            // cbjenisnilai
            // 
            this.cbjenisnilai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbjenisnilai.FormattingEnabled = true;
            this.cbjenisnilai.Location = new System.Drawing.Point(202, 117);
            this.cbjenisnilai.Name = "cbjenisnilai";
            this.cbjenisnilai.Size = new System.Drawing.Size(199, 21);
            this.cbjenisnilai.TabIndex = 22;
            this.cbjenisnilai.SelectedIndexChanged += new System.EventHandler(this.cbjenisnilai_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(375, 82);
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
            this.cbsiswa.Location = new System.Drawing.Point(443, 79);
            this.cbsiswa.Name = "cbsiswa";
            this.cbsiswa.Size = new System.Drawing.Size(199, 21);
            this.cbsiswa.TabIndex = 18;
            this.cbsiswa.SelectedIndexChanged += new System.EventHandler(this.cbsiswa_SelectedIndexChanged);
            // 
            // linformasi
            // 
            this.linformasi.AutoSize = true;
            this.linformasi.Location = new System.Drawing.Point(249, 15);
            this.linformasi.Name = "linformasi";
            this.linformasi.Size = new System.Drawing.Size(126, 13);
            this.linformasi.TabIndex = 13;
            this.linformasi.Text = "INFORMASI PENGAJAR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "INFORMASI WALI KELAS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "KELAS";
            // 
            // cbkelas
            // 
            this.cbkelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbkelas.FormattingEnabled = true;
            this.cbkelas.Location = new System.Drawing.Point(443, 45);
            this.cbkelas.Name = "cbkelas";
            this.cbkelas.Size = new System.Drawing.Size(199, 21);
            this.cbkelas.TabIndex = 10;
            this.cbkelas.SelectedIndexChanged += new System.EventHandler(this.cbkelas_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 48);
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
            this.cbtahunajaran.Location = new System.Drawing.Point(150, 45);
            this.cbtahunajaran.Name = "cbtahunajaran";
            this.cbtahunajaran.Size = new System.Drawing.Size(199, 21);
            this.cbtahunajaran.TabIndex = 6;
            this.cbtahunajaran.SelectedIndexChanged += new System.EventHandler(this.cbtahunajaran_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.BOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 49);
            this.panel1.TabIndex = 107;
            // 
            // BOk
            // 
            this.BOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BOk.BackColor = System.Drawing.Color.Crimson;
            this.BOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BOk.ForeColor = System.Drawing.Color.White;
            this.BOk.Location = new System.Drawing.Point(672, 8);
            this.BOk.Margin = new System.Windows.Forms.Padding(4);
            this.BOk.Name = "BOk";
            this.BOk.Size = new System.Drawing.Size(108, 35);
            this.BOk.TabIndex = 44;
            this.BOk.Text = "OK";
            this.BOk.UseVisualStyleBackColor = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(76)))));
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 108;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Crimson;
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(784, 57);
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
            this.linkLabel1.Size = new System.Drawing.Size(755, 57);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "[form]";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.Controls.Add(this.tbhalaman);
            this.panel4.Controls.Add(this.bnext);
            this.panel4.Controls.Add(this.ldarihalaman);
            this.panel4.Controls.Add(this.bprev);
            this.panel4.Location = new System.Drawing.Point(289, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(207, 43);
            this.panel4.TabIndex = 45;
            // 
            // tbhalaman
            // 
            this.tbhalaman.Location = new System.Drawing.Point(58, 10);
            this.tbhalaman.Name = "tbhalaman";
            this.tbhalaman.Size = new System.Drawing.Size(40, 20);
            this.tbhalaman.TabIndex = 11;
            this.tbhalaman.Text = "1";
            // 
            // bnext
            // 
            this.bnext.BackColor = System.Drawing.Color.Crimson;
            this.bnext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnext.ForeColor = System.Drawing.Color.White;
            this.bnext.Location = new System.Drawing.Point(156, 8);
            this.bnext.Margin = new System.Windows.Forms.Padding(4);
            this.bnext.Name = "bnext";
            this.bnext.Size = new System.Drawing.Size(43, 28);
            this.bnext.TabIndex = 7;
            this.bnext.Text = ">";
            this.bnext.UseVisualStyleBackColor = false;
            // 
            // ldarihalaman
            // 
            this.ldarihalaman.AutoSize = true;
            this.ldarihalaman.Location = new System.Drawing.Point(102, 14);
            this.ldarihalaman.Name = "ldarihalaman";
            this.ldarihalaman.Size = new System.Drawing.Size(21, 13);
            this.ldarihalaman.TabIndex = 10;
            this.ldarihalaman.Text = "/ 1";
            // 
            // bprev
            // 
            this.bprev.BackColor = System.Drawing.Color.Crimson;
            this.bprev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bprev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bprev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bprev.ForeColor = System.Drawing.Color.White;
            this.bprev.Location = new System.Drawing.Point(8, 8);
            this.bprev.Margin = new System.Windows.Forms.Padding(4);
            this.bprev.Name = "bprev";
            this.bprev.Size = new System.Drawing.Size(43, 28);
            this.bprev.TabIndex = 6;
            this.bprev.Text = "<";
            this.bprev.UseVisualStyleBackColor = false;
            // 
            // FRaport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dglaporan);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FRaport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nilai Akhir Siswa";
            this.Load += new System.EventHandler(this.FRaport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dglaporan)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bprint;
        private System.Windows.Forms.DataGridView dglaporan;
        private System.Windows.Forms.Button bexport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cblaporan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label linformasi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbkelas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbtahunajaran;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbsiswa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbjenisnilai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BOk;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbhalaman;
        private System.Windows.Forms.Button bnext;
        private System.Windows.Forms.Label ldarihalaman;
        private System.Windows.Forms.Button bprev;
    }
}