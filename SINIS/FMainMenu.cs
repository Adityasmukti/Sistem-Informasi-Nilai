﻿using System;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS
{
    public partial class FMainMenu : Form
    {
        #region InitializeComponent
        // ============================== InitializeComponent ==============================
        public FMainMenu()
        {
            InitializeComponent();
            this.SetControlFrom();
            this.Load += LoadForm;
            this.Activated += ActivatedForm;
            this.FormClosing += ClosingForm;
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            //code
        }
        private void ActivatedForm(object sender, EventArgs e)
        {
            //code
        }
        private void LoadForm(object sender, EventArgs e)
        {
            //code
            Cursor.Current = Cursors.WaitCursor;
            if (S.GetUseracces() == "1")//Tata Usaha
            {
                BSiswa.Visible = true;
                BGuru.Visible = true;
                BTataUsaha.Visible = true;
                BMaster.Visible = true;
                BSettings.Visible = true;
                BLaporan.Visible = true;
            }
            else if (S.GetUseracces()=="2")//Guru
            {
                BGuru.Visible = true;
                BLaporan.Visible = true;
            }
            else if (S.GetUseracces() == "3")//Siswa
            {
                BSiswa.Visible = true;
            }

            Cursor.Current = Cursors.Default;
        }
        // ============================== InitializeComponent ==============================
        #endregion
      
        #region Pengaturan
        // ============================== Pengaturan ==============================
        private void BSTAplikasi_Click(object sender, EventArgs e)
        {
            //code
            Settings.FSettingApps f = new Settings.FSettingApps();
            f.ShowDialog();
        }
        private void BSTDatabase_Click(object sender, EventArgs e)
        {
            //code
            Settings.FSettingDb f = new Settings.FSettingDb();
            f.ShowDialog();
        }
        private void BSTTentang_Click(object sender, EventArgs e)
        {
            //code
            FTentang f = new FTentang();
            f.Show();
        }
        // ============================== Pengaturan ==============================
        #endregion
        #region User
        // ============================== User ==============================
        private void BUser_Click(object sender, EventArgs e)
        {
            //code
            Auth.FUser f = new Auth.FUser();
            f.ShowDialog();
        }
        private void BLogout_Click(object sender, EventArgs e)
        {
            A.SetLogout();
            DialogResult =DialogResult.OK;
        }
        // ============================== User ==============================
        #endregion

        private void BGKelas_Click(object sender, EventArgs e)
        {
            Pengajar.FKelas f = new Pengajar.FKelas();
            f.Show();
        }

        private void BGNilai_Click(object sender, EventArgs e)
        {
            Pengajar.FNilai f = new Pengajar.FNilai();
            f.Show();
        }

        private void BGPelajaran_Click(object sender, EventArgs e)
        {
            Pengajar.FPelajaran f = new Pengajar.FPelajaran();
            f.Show();
        }

        private void BTURuangKelas_Click(object sender, EventArgs e)
        {
            TU.FRuangKelas f = new TU.FRuangKelas();
            f.Show();
        }

        private void BTUPengajaran_Click(object sender, EventArgs e)
        {
            TU.FPengajaran f = new TU.FPengajaran();
            f.Show();
        }

        private void BMGuru_Click(object sender, EventArgs e)
        {
            TU.FMasterGuru f = new TU.FMasterGuru();
            f.Show();
        }
    }
}
