using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_SINS
{
    public partial class Menu : Form
    {
            ModulData DM = new ModulData();
        public Menu()
        {
            InitializeComponent();
        }

        private void loadawal()
        {
            Timer tm = new Timer();
            tm.Tick += Tm_Tick;
            tm.Enabled = true;

            string nama = "";
            string nip = "";
            string kelamin = "" ;

            foreach(DataRow br in DM.GetData("SELECT * FROM tm_guru WHERE id="+Properties.Settings.Default.useridacces).Tables[0].Rows)
            {
                nama = br["guru_nama"].ToString();
                nip = br["guru_nip"].ToString();
                kelamin = br["guru_jk"].ToString();
            }
            if (kelamin == "P")
                lselamatdatang.Text = "Selamat Datang Ibu " + nama + "["+nip+"] Sebagai " + Properties.Settings.Default.useracces;
            else
                lselamatdatang.Text = "Selamat Datang Bapak " + nama + "["+nip+"] Sebagai " + Properties.Settings.Default.useracces;

            if (Properties.Settings.Default.useracces=="ADMIN")
            {
                bruangkelas.Enabled = true;
                bpengajaran.Enabled = true;
                bmaster.Enabled = true;
            }
            else if(Properties.Settings.Default.useracces=="GURU")
            {
                bruangkelas.Enabled = false;
                bpengajaran.Enabled = false;
                bmaster.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadawal();
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            jam.Text = DateTime.Now.ToString("yyyy MMM dd HH:mm:ss");
        }

        private void blapnilai_Click(object sender, EventArgs e)
        {
            Laporan.FLaporanNilai f = new Laporan.FLaporanNilai();
            f.ShowDialog();
        }

        private void binputnilai_Click(object sender, EventArgs e)
        {
            Laporan.FInputNilai f = new Laporan.FInputNilai();
            f.ShowDialog();
        }

        private void bkelas_Click(object sender, EventArgs e)
        {
            Master.FKelas f = new Master.FKelas();
            f.ShowDialog();
        }

        private void bmaster_Click(object sender, EventArgs e)
        {
            Master.Master f = new Master.Master();
            f.ShowDialog();
        }

        private void bubahuser_Click(object sender, EventArgs e)
        {
            Auth.FKelolaUser f = new Auth.FKelolaUser();
            f.ShowDialog();
        }

        private void bruangkelas_Click(object sender, EventArgs e)
        {
            Penjadwalan.FRuangKelas f = new Penjadwalan.FRuangKelas();
            f.ShowDialog();
        }

        private void bpengajaran_Click(object sender, EventArgs e)
        {
            Penjadwalan.FPengajaran f = new Penjadwalan.FPengajaran();
            f.ShowDialog();
        }

        private void braport_Click(object sender, EventArgs e)
        {
            Laporan.FRaport f = new Laporan.FRaport();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FTentang f = new FTentang();
            f.ShowDialog();
        }

        private void bpelajaran_Click(object sender, EventArgs e)
        {
            Master.FPelajaran f = new Master.FPelajaran();
            f.ShowDialog();
        }
    }
}
