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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LInfo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbsiswa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbjenisnilai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cblaporan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbkelas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbpelajaran = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbtahunajaran = new System.Windows.Forms.ComboBox();
            this.dglaporan = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ldarihalaman = new System.Windows.Forms.Label();
            this.bnext = new System.Windows.Forms.Button();
            this.tbhalaman = new System.Windows.Forms.TextBox();
            this.bprev = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BOk = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglaporan)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.LInfo);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbsiswa);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbjenisnilai);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cblaporan);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbkelas);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbpelajaran);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbtahunajaran);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 110);
            this.panel2.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(46, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(722, 20);
            this.textBox1.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "CARI";
            // 
            // LInfo
            // 
            this.LInfo.Location = new System.Drawing.Point(8, 9);
            this.LInfo.Name = "LInfo";
            this.LInfo.Size = new System.Drawing.Size(760, 13);
            this.LInfo.TabIndex = 22;
            this.LInfo.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(523, 28);
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
            this.cbsiswa.Location = new System.Drawing.Point(571, 25);
            this.cbsiswa.Name = "cbsiswa";
            this.cbsiswa.Size = new System.Drawing.Size(180, 21);
            this.cbsiswa.TabIndex = 18;
            this.cbsiswa.SelectedIndexChanged += new System.EventHandler(this.cbsiswa_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(493, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "NILAI";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // cbjenisnilai
            // 
            this.cbjenisnilai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbjenisnilai.Enabled = false;
            this.cbjenisnilai.FormattingEnabled = true;
            this.cbjenisnilai.Location = new System.Drawing.Point(533, 52);
            this.cbjenisnilai.Name = "cbjenisnilai";
            this.cbjenisnilai.Size = new System.Drawing.Size(180, 21);
            this.cbjenisnilai.TabIndex = 16;
            this.cbjenisnilai.SelectedIndexChanged += new System.EventHandler(this.cbjenisnilai_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 55);
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
            this.cblaporan.Location = new System.Drawing.Point(72, 52);
            this.cblaporan.Name = "cblaporan";
            this.cblaporan.Size = new System.Drawing.Size(180, 21);
            this.cblaporan.TabIndex = 14;
            this.cblaporan.SelectedIndexChanged += new System.EventHandler(this.cblaporan_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "KELAS";
            // 
            // cbkelas
            // 
            this.cbkelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbkelas.FormattingEnabled = true;
            this.cbkelas.Location = new System.Drawing.Point(337, 25);
            this.cbkelas.Name = "cbkelas";
            this.cbkelas.Size = new System.Drawing.Size(180, 21);
            this.cbkelas.TabIndex = 10;
            this.cbkelas.SelectedIndexChanged += new System.EventHandler(this.cbkelas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "MAPEL";
            // 
            // cbpelajaran
            // 
            this.cbpelajaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbpelajaran.FormattingEnabled = true;
            this.cbpelajaran.Location = new System.Drawing.Point(307, 52);
            this.cbpelajaran.Name = "cbpelajaran";
            this.cbpelajaran.Size = new System.Drawing.Size(180, 21);
            this.cbpelajaran.TabIndex = 8;
            this.cbpelajaran.SelectedIndexChanged += new System.EventHandler(this.cbpelajaran_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 28);
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
            this.cbtahunajaran.Location = new System.Drawing.Point(104, 25);
            this.cbtahunajaran.Name = "cbtahunajaran";
            this.cbtahunajaran.Size = new System.Drawing.Size(180, 21);
            this.cbtahunajaran.TabIndex = 6;
            this.cbtahunajaran.SelectedIndexChanged += new System.EventHandler(this.cbtahunajaran_SelectedIndexChanged);
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
            this.dglaporan.Location = new System.Drawing.Point(0, 167);
            this.dglaporan.Name = "dglaporan";
            this.dglaporan.ReadOnly = true;
            this.dglaporan.RowHeadersVisible = false;
            this.dglaporan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dglaporan.Size = new System.Drawing.Size(784, 323);
            this.dglaporan.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.BOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 49);
            this.panel1.TabIndex = 107;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.Controls.Add(this.ldarihalaman);
            this.panel4.Controls.Add(this.bnext);
            this.panel4.Controls.Add(this.tbhalaman);
            this.panel4.Controls.Add(this.bprev);
            this.panel4.Location = new System.Drawing.Point(292, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 35);
            this.panel4.TabIndex = 48;
            // 
            // ldarihalaman
            // 
            this.ldarihalaman.Dock = System.Windows.Forms.DockStyle.Right;
            this.ldarihalaman.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ldarihalaman.Location = new System.Drawing.Point(99, 0);
            this.ldarihalaman.Name = "ldarihalaman";
            this.ldarihalaman.Size = new System.Drawing.Size(61, 35);
            this.ldarihalaman.TabIndex = 10;
            this.ldarihalaman.Text = "/ 9999";
            this.ldarihalaman.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bnext
            // 
            this.bnext.BackColor = System.Drawing.Color.Crimson;
            this.bnext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnext.Dock = System.Windows.Forms.DockStyle.Right;
            this.bnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnext.ForeColor = System.Drawing.Color.White;
            this.bnext.Location = new System.Drawing.Point(160, 0);
            this.bnext.Margin = new System.Windows.Forms.Padding(4);
            this.bnext.Name = "bnext";
            this.bnext.Size = new System.Drawing.Size(40, 35);
            this.bnext.TabIndex = 7;
            this.bnext.Text = ">";
            this.bnext.UseVisualStyleBackColor = false;
            // 
            // tbhalaman
            // 
            this.tbhalaman.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbhalaman.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbhalaman.Location = new System.Drawing.Point(47, 8);
            this.tbhalaman.Name = "tbhalaman";
            this.tbhalaman.Size = new System.Drawing.Size(40, 20);
            this.tbhalaman.TabIndex = 11;
            this.tbhalaman.Text = "1";
            // 
            // bprev
            // 
            this.bprev.BackColor = System.Drawing.Color.Crimson;
            this.bprev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bprev.Dock = System.Windows.Forms.DockStyle.Left;
            this.bprev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bprev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bprev.ForeColor = System.Drawing.Color.White;
            this.bprev.Location = new System.Drawing.Point(0, 0);
            this.bprev.Margin = new System.Windows.Forms.Padding(4);
            this.bprev.Name = "bprev";
            this.bprev.Size = new System.Drawing.Size(40, 35);
            this.bprev.TabIndex = 6;
            this.bprev.Text = "<";
            this.bprev.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Crimson;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(127, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 35);
            this.button2.TabIndex = 47;
            this.button2.Text = "Print";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(11, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 35);
            this.button1.TabIndex = 46;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = false;
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
            // FLaporanNilai
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dglaporan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FLaporanNilai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAPORAN NILAI";
            this.Load += new System.EventHandler(this.FLaporanNilai_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglaporan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbsiswa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbjenisnilai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cblaporan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbkelas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbpelajaran;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbtahunajaran;
        private System.Windows.Forms.DataGridView dglaporan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BOk;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label LInfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label ldarihalaman;
        private System.Windows.Forms.Button bnext;
        private System.Windows.Forms.TextBox tbhalaman;
        private System.Windows.Forms.Button bprev;
    }
}