﻿namespace SINIS.TU
{
    partial class FMasterGuru
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.BOk = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ldarihalaman = new System.Windows.Forms.Label();
            this.bnext = new System.Windows.Forms.Button();
            this.tbhalaman = new System.Windows.Forms.TextBox();
            this.bprev = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgsiswa = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LInfo = new System.Windows.Forms.Label();
            this.TbCari = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BTambah = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgsiswa)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BTambah);
            this.panel2.Controls.Add(this.BOk);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 489);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 50);
            this.panel2.TabIndex = 98;
            // 
            // BOk
            // 
            this.BOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BOk.BackColor = System.Drawing.Color.Crimson;
            this.BOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BOk.ForeColor = System.Drawing.Color.White;
            this.BOk.Location = new System.Drawing.Point(663, 8);
            this.BOk.Margin = new System.Windows.Forms.Padding(4);
            this.BOk.Name = "BOk";
            this.BOk.Size = new System.Drawing.Size(108, 35);
            this.BOk.TabIndex = 48;
            this.BOk.Text = "OK";
            this.BOk.UseVisualStyleBackColor = false;
            this.BOk.Click += new System.EventHandler(this.BOk_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(76)))));
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 97;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(3, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(706, 57);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "[form]";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Crimson;
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(784, 57);
            this.flowLayoutPanel1.TabIndex = 96;
            // 
            // dgsiswa
            // 
            this.dgsiswa.AllowUserToAddRows = false;
            this.dgsiswa.AllowUserToDeleteRows = false;
            this.dgsiswa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgsiswa.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgsiswa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgsiswa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgsiswa.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgsiswa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgsiswa.Location = new System.Drawing.Point(0, 124);
            this.dgsiswa.Name = "dgsiswa";
            this.dgsiswa.ReadOnly = true;
            this.dgsiswa.RowHeadersVisible = false;
            this.dgsiswa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgsiswa.Size = new System.Drawing.Size(784, 365);
            this.dgsiswa.TabIndex = 95;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TbCari);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.LInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 67);
            this.panel1.TabIndex = 94;
            // 
            // LInfo
            // 
            this.LInfo.Location = new System.Drawing.Point(12, 7);
            this.LInfo.Name = "LInfo";
            this.LInfo.Size = new System.Drawing.Size(760, 13);
            this.LInfo.TabIndex = 18;
            this.LInfo.Text = "-";
            // 
            // TbCari
            // 
            this.TbCari.Location = new System.Drawing.Point(50, 23);
            this.TbCari.Name = "TbCari";
            this.TbCari.Size = new System.Drawing.Size(722, 20);
            this.TbCari.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "CARI";
            // 
            // BTambah
            // 
            this.BTambah.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTambah.BackColor = System.Drawing.Color.Crimson;
            this.BTambah.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTambah.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTambah.ForeColor = System.Drawing.Color.White;
            this.BTambah.Location = new System.Drawing.Point(547, 8);
            this.BTambah.Margin = new System.Windows.Forms.Padding(4);
            this.BTambah.Name = "BTambah";
            this.BTambah.Size = new System.Drawing.Size(108, 35);
            this.BTambah.TabIndex = 49;
            this.BTambah.Text = "TAMBAH";
            this.BTambah.UseVisualStyleBackColor = false;
            this.BTambah.Click += new System.EventHandler(this.BTambah_Click);
            // 
            // FMasterGuru
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgsiswa);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FMasterGuru";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GURU";
            this.Load += new System.EventHandler(this.FMasterGuru_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgsiswa)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgsiswa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label ldarihalaman;
        private System.Windows.Forms.Button bnext;
        private System.Windows.Forms.TextBox tbhalaman;
        private System.Windows.Forms.Button bprev;
        private System.Windows.Forms.Button BOk;
        private System.Windows.Forms.Label LInfo;
        private System.Windows.Forms.TextBox TbCari;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTambah;
    }
}