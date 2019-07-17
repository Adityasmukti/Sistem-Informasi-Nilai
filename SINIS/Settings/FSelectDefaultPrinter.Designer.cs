namespace SINIS.Settings
{
    partial class FSelectDefaultPrinter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSelectDefaultPrinter));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BSimpan = new System.Windows.Forms.Button();
            this.CbPrinter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BSimpan);
            this.groupBox1.Controls.Add(this.CbPrinter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 89);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DETAIL";
            // 
            // BSimpan
            // 
            this.BSimpan.BackColor = System.Drawing.Color.Crimson;
            this.BSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSimpan.ForeColor = System.Drawing.Color.White;
            this.BSimpan.Location = new System.Drawing.Point(432, 26);
            this.BSimpan.Margin = new System.Windows.Forms.Padding(4);
            this.BSimpan.Name = "BSimpan";
            this.BSimpan.Size = new System.Drawing.Size(124, 36);
            this.BSimpan.TabIndex = 37;
            this.BSimpan.Text = "Simpan";
            this.BSimpan.UseVisualStyleBackColor = false;
            this.BSimpan.Click += new System.EventHandler(this.BSimpan_Click);
            // 
            // CbPrinter
            // 
            this.CbPrinter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPrinter.FormattingEnabled = true;
            this.CbPrinter.Items.AddRange(new object[] {
            "SEMUA",
            "YA",
            "TIDAK"});
            this.CbPrinter.Location = new System.Drawing.Point(112, 31);
            this.CbPrinter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CbPrinter.Name = "CbPrinter";
            this.CbPrinter.Size = new System.Drawing.Size(313, 28);
            this.CbPrinter.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "PRINTER";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Crimson;
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(586, 57);
            this.flowLayoutPanel1.TabIndex = 100;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(3, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(529, 57);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "CETAK LABEL";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(586, 146);
            this.groupBox2.TabIndex = 98;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PAKET KIRIMAN TERSISA";
            // 
            // FSelectDefaultPrinter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(586, 146);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FSelectDefaultPrinter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SELECT DEFAULT PRINTER";
            this.Load += new System.EventHandler(this.FSelectDefaultPrinter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CbPrinter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BSimpan;
    }
}