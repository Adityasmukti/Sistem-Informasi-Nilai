﻿namespace SINIS.TU
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TbCari = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LInfo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CbWaliKelas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CbKelas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CbMasuk = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CbTahunAjaran = new System.Windows.Forms.ComboBox();
            this.Dg = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ldarihalaman = new System.Windows.Forms.Label();
            this.bnext = new System.Windows.Forms.Button();
            this.tbhalaman = new System.Windows.Forms.TextBox();
            this.bprev = new System.Windows.Forms.Button();
            this.bkeluar = new System.Windows.Forms.Button();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dg)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TbCari);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.LInfo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CbWaliKelas);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CbKelas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CbMasuk);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CbTahunAjaran);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 86);
            this.panel1.TabIndex = 0;
            // 
            // TbCari
            // 
            this.TbCari.Location = new System.Drawing.Point(309, 53);
            this.TbCari.Name = "TbCari";
            this.TbCari.Size = new System.Drawing.Size(459, 20);
            this.TbCari.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "CARI";
            // 
            // LInfo
            // 
            this.LInfo.Location = new System.Drawing.Point(8, 10);
            this.LInfo.Name = "LInfo";
            this.LInfo.Size = new System.Drawing.Size(760, 13);
            this.LInfo.TabIndex = 18;
            this.LInfo.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "WALI KELAS";
            // 
            // CbWaliKelas
            // 
            this.CbWaliKelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbWaliKelas.FormattingEnabled = true;
            this.CbWaliKelas.Location = new System.Drawing.Point(85, 53);
            this.CbWaliKelas.Name = "CbWaliKelas";
            this.CbWaliKelas.Size = new System.Drawing.Size(180, 21);
            this.CbWaliKelas.TabIndex = 7;
            this.CbWaliKelas.SelectedIndexChanged += new System.EventHandler(this.cbguru_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(550, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "KELAS";
            // 
            // CbKelas
            // 
            this.CbKelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbKelas.FormattingEnabled = true;
            this.CbKelas.Location = new System.Drawing.Point(597, 26);
            this.CbKelas.Name = "CbKelas";
            this.CbKelas.Size = new System.Drawing.Size(171, 21);
            this.CbKelas.TabIndex = 4;
            this.CbKelas.SelectedIndexChanged += new System.EventHandler(this.cbkelas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "MASUK";
            // 
            // CbMasuk
            // 
            this.CbMasuk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbMasuk.FormattingEnabled = true;
            this.CbMasuk.Location = new System.Drawing.Point(339, 26);
            this.CbMasuk.Name = "CbMasuk";
            this.CbMasuk.Size = new System.Drawing.Size(205, 21);
            this.CbMasuk.TabIndex = 2;
            this.CbMasuk.SelectedIndexChanged += new System.EventHandler(this.cbthunmasuk_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TAHUN AJARAN";
            // 
            // CbTahunAjaran
            // 
            this.CbTahunAjaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbTahunAjaran.FormattingEnabled = true;
            this.CbTahunAjaran.ItemHeight = 13;
            this.CbTahunAjaran.Location = new System.Drawing.Point(104, 26);
            this.CbTahunAjaran.Name = "CbTahunAjaran";
            this.CbTahunAjaran.Size = new System.Drawing.Size(171, 21);
            this.CbTahunAjaran.TabIndex = 0;
            this.CbTahunAjaran.SelectedIndexChanged += new System.EventHandler(this.cbtahunajaran_SelectedIndexChanged);
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
            this.Column6,
            this.Column7,
            this.Column1,
            this.Column8,
            this.Column3,
            this.Column2,
            this.Column5,
            this.Column4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dg.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dg.Location = new System.Drawing.Point(0, 143);
            this.Dg.Name = "Dg";
            this.Dg.ReadOnly = true;
            this.Dg.RowHeadersVisible = false;
            this.Dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dg.Size = new System.Drawing.Size(784, 346);
            this.Dg.TabIndex = 2;
            this.Dg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgsiswa_CellClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Crimson;
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(784, 57);
            this.flowLayoutPanel1.TabIndex = 89;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(3, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(754, 57);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "[form]";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(76)))));
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 92;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.bkeluar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 489);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 50);
            this.panel2.TabIndex = 93;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.Controls.Add(this.ldarihalaman);
            this.panel4.Controls.Add(this.bnext);
            this.panel4.Controls.Add(this.tbhalaman);
            this.panel4.Controls.Add(this.bprev);
            this.panel4.Location = new System.Drawing.Point(292, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 35);
            this.panel4.TabIndex = 47;
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
            // bkeluar
            // 
            this.bkeluar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bkeluar.BackColor = System.Drawing.Color.Crimson;
            this.bkeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bkeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bkeluar.ForeColor = System.Drawing.Color.White;
            this.bkeluar.Location = new System.Drawing.Point(623, 7);
            this.bkeluar.Margin = new System.Windows.Forms.Padding(4);
            this.bkeluar.Name = "bkeluar";
            this.bkeluar.Size = new System.Drawing.Size(157, 38);
            this.bkeluar.TabIndex = 10;
            this.bkeluar.Text = "Keluar";
            this.bkeluar.UseVisualStyleBackColor = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "KODE SISWA";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "KODE RUANGAN";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.HeaderText = "PILIH";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Width = 40;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "KELAS";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "NIS";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "NAMA";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "JK";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 44;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "MASUK";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 70;
            // 
            // FRuangKelas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Dg);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FRuangKelas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RUANG KELAS";
            this.Load += new System.EventHandler(this.FRuangKelas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dg)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CbKelas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbMasuk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbTahunAjaran;
        private System.Windows.Forms.DataGridView Dg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CbWaliKelas;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bkeluar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label ldarihalaman;
        private System.Windows.Forms.Button bnext;
        private System.Windows.Forms.TextBox tbhalaman;
        private System.Windows.Forms.Button bprev;
        private System.Windows.Forms.Label LInfo;
        private System.Windows.Forms.TextBox TbCari;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}