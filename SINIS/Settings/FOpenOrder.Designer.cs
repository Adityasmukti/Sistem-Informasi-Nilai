namespace AtelierAngelinaApps.Applications
{
    partial class FOpenOrder
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lbs_waktu = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbs_nama = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbshakakses = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbs_datang = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CbOPenOrder = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Dtp1 = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.LOpenOrderJumlah = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.linkLabel1.Size = new System.Drawing.Size(921, 53);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "DATA ORDER";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // lbs_waktu
            // 
            this.lbs_waktu.ActiveLinkColor = System.Drawing.Color.Red;
            this.lbs_waktu.ForeColor = System.Drawing.Color.White;
            this.lbs_waktu.LinkColor = System.Drawing.Color.White;
            this.lbs_waktu.Name = "lbs_waktu";
            this.lbs_waktu.Size = new System.Drawing.Size(178, 17);
            this.lbs_waktu.Text = "Semoga Harimu Menyenangkan";
            // 
            // lbs_nama
            // 
            this.lbs_nama.ForeColor = System.Drawing.Color.White;
            this.lbs_nama.Name = "lbs_nama";
            this.lbs_nama.Size = new System.Drawing.Size(799, 17);
            this.lbs_nama.Spring = true;
            this.lbs_nama.Text = "Aplikasi Butik Atelier Angelina";
            // 
            // lbshakakses
            // 
            this.lbshakakses.AutoSize = false;
            this.lbshakakses.ForeColor = System.Drawing.Color.White;
            this.lbshakakses.Name = "lbshakakses";
            this.lbshakakses.Size = new System.Drawing.Size(200, 17);
            this.lbshakakses.Text = "toolStripStatusLabel1";
            // 
            // lbs_datang
            // 
            this.lbs_datang.ForeColor = System.Drawing.Color.White;
            this.lbs_datang.Name = "lbs_datang";
            this.lbs_datang.Size = new System.Drawing.Size(90, 17);
            this.lbs_datang.Text = "Selamat Datang";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "TGL ODR";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CbOPenOrder);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Dtp1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 148);
            this.panel1.TabIndex = 104;
            // 
            // CbOPenOrder
            // 
            this.CbOPenOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbOPenOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbOPenOrder.FormattingEnabled = true;
            this.CbOPenOrder.Items.AddRange(new object[] {
            "Semua",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.CbOPenOrder.Location = new System.Drawing.Point(443, 18);
            this.CbOPenOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CbOPenOrder.Name = "CbOPenOrder";
            this.CbOPenOrder.Size = new System.Drawing.Size(247, 28);
            this.CbOPenOrder.TabIndex = 53;
            this.CbOPenOrder.SelectedIndexChanged += new System.EventHandler(this.CbOPenOrder_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 52;
            this.label6.Text = "OPEN ORDER";
            // 
            // Dtp1
            // 
            this.Dtp1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Dtp1.CustomFormat = "dd/MM/yyyy";
            this.Dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp1.Location = new System.Drawing.Point(113, 20);
            this.Dtp1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Dtp1.Name = "Dtp1";
            this.Dtp1.ShowCheckBox = true;
            this.Dtp1.Size = new System.Drawing.Size(200, 26);
            this.Dtp1.TabIndex = 26;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(76)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbs_datang,
            this.lbshakakses,
            this.lbs_nama,
            this.lbs_waktu});
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1284, 22);
            this.statusStrip1.TabIndex = 107;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Crimson;
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1284, 57);
            this.flowLayoutPanel1.TabIndex = 108;
            // 
            // LOpenOrderJumlah
            // 
            this.LOpenOrderJumlah.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LOpenOrderJumlah.Font = new System.Drawing.Font("Microsoft Sans Serif", 200F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOpenOrderJumlah.ForeColor = System.Drawing.Color.Maroon;
            this.LOpenOrderJumlah.Location = new System.Drawing.Point(0, 205);
            this.LOpenOrderJumlah.Name = "LOpenOrderJumlah";
            this.LOpenOrderJumlah.Size = new System.Drawing.Size(1284, 434);
            this.LOpenOrderJumlah.TabIndex = 111;
            this.LOpenOrderJumlah.Text = "0";
            this.LOpenOrderJumlah.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1284, 87);
            this.label1.TabIndex = 56;
            this.label1.Text = "Open Order";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // FOpenOrder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.LOpenOrderJumlah);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FOpenOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OPEN ORDER";
            this.Load += new System.EventHandler(this.FOpenOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbs_waktu;
        private System.Windows.Forms.ToolStripStatusLabel lbs_nama;
        private System.Windows.Forms.ToolStripStatusLabel lbshakakses;
        private System.Windows.Forms.ToolStripStatusLabel lbs_datang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CbOPenOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker Dtp1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label LOpenOrderJumlah;
        private System.Windows.Forms.Label label1;
    }
}