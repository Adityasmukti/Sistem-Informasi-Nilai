using Microsoft.Win32;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using ExtensionMethods;

namespace AtelierAngelinaApps
{
    public partial class FSettingDb : Form
    {
        public FSettingDb()
        {
            InitializeComponent();
        }
        private void FSettingDb_Load(object sender, EventArgs e)
        {
            TbHost.Text = Properties.Settings.Default.mysqlhost;
            TbDatabase.Text = Properties.Settings.Default.mysqldatabase;
            TbUsername.Text = Properties.Settings.Default.mysqluser;
            TbPassword.Text = Properties.Settings.Default.mysqlpassword;
            TbPort.Text = Properties.Settings.Default.mysqlport;
        }
        public MySqlConnection koneksi;
        public bool Cekstatus()
        {
            koneksi = new MySqlConnection("Server=" + TbHost.Text + ";Database=" + TbDatabase.Text + ";Uid=" + TbUsername.Text + ";pwd=" + TbPassword.Text + ";port="+TbPort.Text+ ";SslMode=none");
            try
            {
                koneksi.Open();
            }
            catch (Exception) { }

            if (koneksi.State == ConnectionState.Open)
            {
                koneksi.Close();
                return true;
            }
            else
                return false;
        }

        private void BTes_Click(object sender, EventArgs e)
        {
            if (Cekstatus())
                MessageBox.Show("Koneksi Sukses!");
            else
                MessageBox.Show("Koneksi Gagal!");
        }

        private void BSimpan_Click(object sender, EventArgs e)
        {
            if (Cekstatus())
            {
                if (MessageBox.Show("Simpan pengaturan MYSQL?","Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Properties.Settings.Default.mysqlhost = TbHost.Text;
                    Properties.Settings.Default.mysqldatabase = TbDatabase.Text;
                    Properties.Settings.Default.mysqluser = TbUsername.Text;
                    Properties.Settings.Default.mysqlpassword = TbPassword.Text;
                    Properties.Settings.Default.mysqlport = TbPort.Text;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Database telah tersimpan, Aplikasi akan memulai ulang!!", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                    Environment.Exit(0);
                }
            }
            else
                MessageBox.Show("Masih Belum Terkoneksi!!", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
