namespace SINIS
{
    partial class FMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMainMenu));
            this.menu = new System.Windows.Forms.ToolStrip();
            this.BSiswa = new System.Windows.Forms.ToolStripDropDownButton();
            this.BSNilai = new System.Windows.Forms.ToolStripMenuItem();
            this.BGuru = new System.Windows.Forms.ToolStripDropDownButton();
            this.BGKelas = new System.Windows.Forms.ToolStripMenuItem();
            this.BGNilai = new System.Windows.Forms.ToolStripMenuItem();
            this.BGPelajaran = new System.Windows.Forms.ToolStripMenuItem();
            this.BTataUsaha = new System.Windows.Forms.ToolStripDropDownButton();
            this.BTURuangKelas = new System.Windows.Forms.ToolStripMenuItem();
            this.BTUPengajaran = new System.Windows.Forms.ToolStripMenuItem();
            this.BLaporan = new System.Windows.Forms.ToolStripDropDownButton();
            this.BLRaport = new System.Windows.Forms.ToolStripMenuItem();
            this.BMaster = new System.Windows.Forms.ToolStripDropDownButton();
            this.BMSiswa = new System.Windows.Forms.ToolStripMenuItem();
            this.BMGuru = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BMPelajaran = new System.Windows.Forms.ToolStripMenuItem();
            this.BMKelas = new System.Windows.Forms.ToolStripMenuItem();
            this.BMJenisNilai = new System.Windows.Forms.ToolStripMenuItem();
            this.BSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.BSTAplikasi = new System.Windows.Forms.ToolStripMenuItem();
            this.BSTDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BSTTentang = new System.Windows.Forms.ToolStripMenuItem();
            this.BUser = new System.Windows.Forms.ToolStripButton();
            this.BLogout = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TbCatatan = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TbInfo = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TbAktivitas = new System.Windows.Forms.RichTextBox();
            this.menu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BSiswa,
            this.BGuru,
            this.BTataUsaha,
            this.BLaporan,
            this.BMaster,
            this.BSettings,
            this.BUser,
            this.BLogout});
            this.menu.Location = new System.Drawing.Point(0, 57);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(784, 45);
            this.menu.TabIndex = 0;
            this.menu.Text = "toolStrip1";
            // 
            // BSiswa
            // 
            this.BSiswa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BSiswa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BSNilai});
            this.BSiswa.Image = ((System.Drawing.Image)(resources.GetObject("BSiswa.Image")));
            this.BSiswa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BSiswa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BSiswa.Name = "BSiswa";
            this.BSiswa.Size = new System.Drawing.Size(45, 42);
            this.BSiswa.Tag = "SISWA";
            this.BSiswa.Text = "SISWA";
            // 
            // BSNilai
            // 
            this.BSNilai.Name = "BSNilai";
            this.BSNilai.Size = new System.Drawing.Size(180, 26);
            this.BSNilai.Text = "Nilai";
            // 
            // BGuru
            // 
            this.BGuru.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BGuru.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BGKelas,
            this.BGNilai,
            this.BGPelajaran});
            this.BGuru.Image = ((System.Drawing.Image)(resources.GetObject("BGuru.Image")));
            this.BGuru.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BGuru.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BGuru.Name = "BGuru";
            this.BGuru.Size = new System.Drawing.Size(45, 42);
            this.BGuru.Tag = "GURU";
            this.BGuru.Text = "GURU";
            // 
            // BGKelas
            // 
            this.BGKelas.Name = "BGKelas";
            this.BGKelas.Size = new System.Drawing.Size(180, 26);
            this.BGKelas.Text = "Kelas";
            this.BGKelas.Click += new System.EventHandler(this.BGKelas_Click);
            // 
            // BGNilai
            // 
            this.BGNilai.Name = "BGNilai";
            this.BGNilai.Size = new System.Drawing.Size(180, 26);
            this.BGNilai.Text = "Nilai";
            this.BGNilai.Click += new System.EventHandler(this.BGNilai_Click);
            // 
            // BGPelajaran
            // 
            this.BGPelajaran.Name = "BGPelajaran";
            this.BGPelajaran.Size = new System.Drawing.Size(180, 26);
            this.BGPelajaran.Text = "Pelajaran";
            this.BGPelajaran.Click += new System.EventHandler(this.BGPelajaran_Click);
            // 
            // BTataUsaha
            // 
            this.BTataUsaha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTataUsaha.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTURuangKelas,
            this.BTUPengajaran});
            this.BTataUsaha.Image = ((System.Drawing.Image)(resources.GetObject("BTataUsaha.Image")));
            this.BTataUsaha.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTataUsaha.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTataUsaha.Name = "BTataUsaha";
            this.BTataUsaha.Size = new System.Drawing.Size(45, 42);
            this.BTataUsaha.Tag = "TATA USAHA";
            this.BTataUsaha.Text = "TATA USAHA";
            // 
            // BTURuangKelas
            // 
            this.BTURuangKelas.Name = "BTURuangKelas";
            this.BTURuangKelas.Size = new System.Drawing.Size(180, 26);
            this.BTURuangKelas.Text = "Ruang Kelas";
            this.BTURuangKelas.Click += new System.EventHandler(this.BTURuangKelas_Click);
            // 
            // BTUPengajaran
            // 
            this.BTUPengajaran.Name = "BTUPengajaran";
            this.BTUPengajaran.Size = new System.Drawing.Size(180, 26);
            this.BTUPengajaran.Text = "Pengajaran";
            this.BTUPengajaran.Click += new System.EventHandler(this.BTUPengajaran_Click);
            // 
            // BLaporan
            // 
            this.BLaporan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BLaporan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BLRaport});
            this.BLaporan.Image = ((System.Drawing.Image)(resources.GetObject("BLaporan.Image")));
            this.BLaporan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BLaporan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BLaporan.Name = "BLaporan";
            this.BLaporan.Size = new System.Drawing.Size(45, 42);
            this.BLaporan.Tag = "LAPORAN";
            this.BLaporan.Text = "LAPORAN";
            // 
            // BLRaport
            // 
            this.BLRaport.Name = "BLRaport";
            this.BLRaport.Size = new System.Drawing.Size(180, 26);
            this.BLRaport.Text = "Raport";
            // 
            // BMaster
            // 
            this.BMaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BMaster.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BMSiswa,
            this.BMGuru,
            this.toolStripSeparator1,
            this.BMPelajaran,
            this.BMKelas,
            this.BMJenisNilai});
            this.BMaster.Image = ((System.Drawing.Image)(resources.GetObject("BMaster.Image")));
            this.BMaster.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BMaster.Name = "BMaster";
            this.BMaster.Size = new System.Drawing.Size(45, 42);
            this.BMaster.Tag = "MASTER";
            this.BMaster.Text = "MASTER";
            // 
            // BMSiswa
            // 
            this.BMSiswa.Name = "BMSiswa";
            this.BMSiswa.Size = new System.Drawing.Size(180, 26);
            this.BMSiswa.Text = "Siswa";
            // 
            // BMGuru
            // 
            this.BMGuru.Name = "BMGuru";
            this.BMGuru.Size = new System.Drawing.Size(180, 26);
            this.BMGuru.Text = "Guru";
            this.BMGuru.Click += new System.EventHandler(this.BMGuru_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // BMPelajaran
            // 
            this.BMPelajaran.Name = "BMPelajaran";
            this.BMPelajaran.Size = new System.Drawing.Size(180, 26);
            this.BMPelajaran.Text = "Pelajaran";
            // 
            // BMKelas
            // 
            this.BMKelas.Name = "BMKelas";
            this.BMKelas.Size = new System.Drawing.Size(180, 26);
            this.BMKelas.Text = "Kelas";
            // 
            // BMJenisNilai
            // 
            this.BMJenisNilai.Name = "BMJenisNilai";
            this.BMJenisNilai.Size = new System.Drawing.Size(180, 26);
            this.BMJenisNilai.Text = "Jenis Nilai";
            // 
            // BSettings
            // 
            this.BSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BSTAplikasi,
            this.BSTDatabase,
            this.toolStripSeparator2,
            this.BSTTentang});
            this.BSettings.Image = ((System.Drawing.Image)(resources.GetObject("BSettings.Image")));
            this.BSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BSettings.Name = "BSettings";
            this.BSettings.Size = new System.Drawing.Size(45, 42);
            this.BSettings.Tag = "SETTINGS";
            this.BSettings.Text = "SETTINGS";
            // 
            // BSTAplikasi
            // 
            this.BSTAplikasi.Name = "BSTAplikasi";
            this.BSTAplikasi.Size = new System.Drawing.Size(144, 26);
            this.BSTAplikasi.Text = "Aplikasi";
            this.BSTAplikasi.Click += new System.EventHandler(this.BSTAplikasi_Click);
            // 
            // BSTDatabase
            // 
            this.BSTDatabase.Name = "BSTDatabase";
            this.BSTDatabase.Size = new System.Drawing.Size(144, 26);
            this.BSTDatabase.Text = "Database";
            this.BSTDatabase.Click += new System.EventHandler(this.BSTDatabase_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // BSTTentang
            // 
            this.BSTTentang.Name = "BSTTentang";
            this.BSTTentang.Size = new System.Drawing.Size(144, 26);
            this.BSTTentang.Text = "Tentang";
            this.BSTTentang.Click += new System.EventHandler(this.BSTTentang_Click);
            // 
            // BUser
            // 
            this.BUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BUser.Image = ((System.Drawing.Image)(resources.GetObject("BUser.Image")));
            this.BUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BUser.Name = "BUser";
            this.BUser.Size = new System.Drawing.Size(36, 42);
            this.BUser.Tag = "USER";
            this.BUser.Text = "USER";
            this.BUser.Click += new System.EventHandler(this.BUser_Click);
            // 
            // BLogout
            // 
            this.BLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BLogout.Image = ((System.Drawing.Image)(resources.GetObject("BLogout.Image")));
            this.BLogout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BLogout.Name = "BLogout";
            this.BLogout.Size = new System.Drawing.Size(36, 42);
            this.BLogout.Tag = "LOGOUT";
            this.BLogout.Text = "LOGOUT";
            this.BLogout.Click += new System.EventHandler(this.BLogout_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Crimson;
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(784, 57);
            this.flowLayoutPanel1.TabIndex = 88;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(3, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(721, 57);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "[form]";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 146);
            this.panel1.TabIndex = 90;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TbCatatan);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(388, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(396, 146);
            this.groupBox5.TabIndex = 89;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "CATATAN";
            // 
            // TbCatatan
            // 
            this.TbCatatan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TbCatatan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbCatatan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbCatatan.Location = new System.Drawing.Point(3, 22);
            this.TbCatatan.Name = "TbCatatan";
            this.TbCatatan.Size = new System.Drawing.Size(390, 121);
            this.TbCatatan.TabIndex = 15;
            this.TbCatatan.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TbInfo);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(388, 146);
            this.panel2.TabIndex = 92;
            // 
            // TbInfo
            // 
            this.TbInfo.BackColor = System.Drawing.SystemColors.Control;
            this.TbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbInfo.Location = new System.Drawing.Point(0, 20);
            this.TbInfo.Name = "TbInfo";
            this.TbInfo.ReadOnly = true;
            this.TbInfo.Size = new System.Drawing.Size(388, 126);
            this.TbInfo.TabIndex = 91;
            this.TbInfo.Text = "";
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(388, 20);
            this.label7.TabIndex = 90;
            this.label7.Text = "INFORMASI";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(76)))));
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 91;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TbAktivitas);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(493, 102);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(291, 291);
            this.groupBox4.TabIndex = 92;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "AKTIVITAS";
            // 
            // TbAktivitas
            // 
            this.TbAktivitas.BackColor = System.Drawing.Color.White;
            this.TbAktivitas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbAktivitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbAktivitas.Location = new System.Drawing.Point(3, 22);
            this.TbAktivitas.Name = "TbAktivitas";
            this.TbAktivitas.Size = new System.Drawing.Size(285, 266);
            this.TbAktivitas.TabIndex = 0;
            this.TbAktivitas.Text = "";
            this.TbAktivitas.WordWrap = false;
            // 
            // FMainMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAIN MENU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripDropDownButton BSiswa;
        private System.Windows.Forms.ToolStripDropDownButton BSettings;
        private System.Windows.Forms.ToolStripDropDownButton BTataUsaha;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox TbCatatan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox TbInfo;
        private System.Windows.Forms.ToolStripButton BLogout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem BSTAplikasi;
        private System.Windows.Forms.ToolStripMenuItem BSTDatabase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton BMaster;
        private System.Windows.Forms.ToolStripDropDownButton BLaporan;
        private System.Windows.Forms.ToolStripButton BUser;
        private System.Windows.Forms.ToolStripDropDownButton BGuru;
        private System.Windows.Forms.ToolStripMenuItem BSTTentang;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox TbAktivitas;
        private System.Windows.Forms.ToolStripMenuItem BSNilai;
        private System.Windows.Forms.ToolStripMenuItem BGKelas;
        private System.Windows.Forms.ToolStripMenuItem BGNilai;
        private System.Windows.Forms.ToolStripMenuItem BGPelajaran;
        private System.Windows.Forms.ToolStripMenuItem BTURuangKelas;
        private System.Windows.Forms.ToolStripMenuItem BTUPengajaran;
        private System.Windows.Forms.ToolStripMenuItem BLRaport;
        private System.Windows.Forms.ToolStripMenuItem BMSiswa;
        private System.Windows.Forms.ToolStripMenuItem BMGuru;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem BMPelajaran;
        private System.Windows.Forms.ToolStripMenuItem BMKelas;
        private System.Windows.Forms.ToolStripMenuItem BMJenisNilai;
    }
}