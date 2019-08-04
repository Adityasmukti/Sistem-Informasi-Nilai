namespace SINIS.Pengajar
{
    partial class FLKelas
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
            this.TbCari = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CbKelas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CbMapel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CbTahunAjaran = new System.Windows.Forms.ComboBox();
            this.Dg = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ldarihalaman = new System.Windows.Forms.Label();
            this.bnext = new System.Windows.Forms.Button();
            this.tbhalaman = new System.Windows.Forms.TextBox();
            this.bprev = new System.Windows.Forms.Button();
            this.BExport = new System.Windows.Forms.Button();
            this.BOk = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dg)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TbCari);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.LInfo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.CbKelas);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.CbMapel);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.CbTahunAjaran);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 83);
            this.panel2.TabIndex = 14;
            // 
            // TbCari
            // 
            this.TbCari.Location = new System.Drawing.Point(46, 52);
            this.TbCari.Name = "TbCari";
            this.TbCari.Size = new System.Drawing.Size(722, 20);
            this.TbCari.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 55);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "KELAS";
            // 
            // CbKelas
            // 
            this.CbKelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbKelas.FormattingEnabled = true;
            this.CbKelas.Location = new System.Drawing.Point(337, 25);
            this.CbKelas.Name = "CbKelas";
            this.CbKelas.Size = new System.Drawing.Size(180, 21);
            this.CbKelas.TabIndex = 10;
            this.CbKelas.DropDown += new System.EventHandler(this.CbKelas_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(523, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "MAPEL";
            // 
            // CbMapel
            // 
            this.CbMapel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbMapel.FormattingEnabled = true;
            this.CbMapel.Location = new System.Drawing.Point(572, 25);
            this.CbMapel.Name = "CbMapel";
            this.CbMapel.Size = new System.Drawing.Size(196, 21);
            this.CbMapel.TabIndex = 8;
            this.CbMapel.DropDown += new System.EventHandler(this.CbMapel_DropDown);
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
            // CbTahunAjaran
            // 
            this.CbTahunAjaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbTahunAjaran.FormattingEnabled = true;
            this.CbTahunAjaran.ItemHeight = 13;
            this.CbTahunAjaran.Location = new System.Drawing.Point(104, 25);
            this.CbTahunAjaran.Name = "CbTahunAjaran";
            this.CbTahunAjaran.Size = new System.Drawing.Size(180, 21);
            this.CbTahunAjaran.TabIndex = 6;
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
            this.Dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dg.Location = new System.Drawing.Point(0, 140);
            this.Dg.Name = "Dg";
            this.Dg.ReadOnly = true;
            this.Dg.RowHeadersVisible = false;
            this.Dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dg.Size = new System.Drawing.Size(784, 350);
            this.Dg.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.BExport);
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
            // BExport
            // 
            this.BExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BExport.BackColor = System.Drawing.Color.Crimson;
            this.BExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BExport.ForeColor = System.Drawing.Color.White;
            this.BExport.Location = new System.Drawing.Point(11, 8);
            this.BExport.Margin = new System.Windows.Forms.Padding(4);
            this.BExport.Name = "BExport";
            this.BExport.Size = new System.Drawing.Size(108, 35);
            this.BExport.TabIndex = 46;
            this.BExport.Text = "Export";
            this.BExport.UseVisualStyleBackColor = false;
            this.BExport.Click += new System.EventHandler(this.BExport_Click);
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
            this.BOk.Click += new System.EventHandler(this.BOk_Click);
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
            // FLKelas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Dg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FLKelas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAPORAN NILAI KELAS";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CbKelas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbMapel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CbTahunAjaran;
        private System.Windows.Forms.DataGridView Dg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BOk;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label LInfo;
        private System.Windows.Forms.TextBox TbCari;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BExport;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label ldarihalaman;
        private System.Windows.Forms.Button bnext;
        private System.Windows.Forms.TextBox tbhalaman;
        private System.Windows.Forms.Button bprev;
    }
}