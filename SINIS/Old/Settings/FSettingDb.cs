using Microsoft.Win32;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Project_SINS
{
    public partial class FSettingDb : Form
    {
        public FSettingDb()
        {
            InitializeComponent();
            //this.BackColor = Properties.Settings.Default.color1;
        }
                    
        //const string userRoot = "HKEY_CURRENT_USER";
        //const string subkey = "CODEAS";
        //const string keyName = userRoot + "\\" + subkey;
        private void FSettingDb_Load(object sender, EventArgs e)
        {
            //tb_host.Text = (string)Registry.GetValue(keyName, "host", "");
            //tb_database.Text = (string)Registry.GetValue(keyName, "database", "");
            //tb_username.Text = (string)Registry.GetValue(keyName, "user", "");
            //tb_password.Text = (string)Registry.GetValue(keyName, "pass", "");
            //tbPort.Text = (string)Registry.GetValue(keyName, "port", "");

            tb_host.Text = Properties.Settings.Default.mysqlhost;
            tb_database.Text = Properties.Settings.Default.mysqldb;
            tb_username.Text = Properties.Settings.Default.mysqluser;
            tb_password.Text = Properties.Settings.Default.mysqlpass;
            tbPort.Text = Properties.Settings.Default.mysqlport;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cekstatus())
            {
                //simpanreg(tb_host.Text, tb_database.Text, tb_username.Text, tb_password.Text, tbPort.Text);
                Properties.Settings.Default.mysqlhost = tb_host.Text;
                Properties.Settings.Default.mysqldb = tb_database.Text;
                Properties.Settings.Default.mysqluser = tb_username.Text;
                Properties.Settings.Default.mysqlpass = tb_password.Text;
                Properties.Settings.Default.mysqlport = tbPort.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Database telah tersimpan!!", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
                Environment.Exit(0);
            }
            else
                MessageBox.Show("Masih Belum Terkoneksi!!", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //public void simpanreg(string host, string database, string user, string pass, string port)
        //{
        //    try
        //    {
        //        Registry.SetValue(keyName, "host", host);
        //        Registry.SetValue(keyName, "database", database);
        //        Registry.SetValue(keyName, "user", user);
        //        Registry.SetValue(keyName, "pass", pass);
        //        Registry.SetValue(keyName, "port", port);
        //    }
        //    catch (Exception) { }
        //}

        private void btn_Print_Click(object sender, EventArgs e)
        {
            //simpanreg(tb_host.Text, tb_database.Text, tb_username.Text, tb_password.Text);
         
            if (cekstatus())
                MessageBox.Show("Koneksi Sukses!");
            else
                MessageBox.Show("Koneksi Gagal!");
        }


        public MySqlConnection koneksi;
        public bool cekstatus()
        {
            koneksi = new MySqlConnection("Server=" + tb_host.Text + ";Database=" + tb_database.Text + ";Uid=" + tb_username.Text + ";pwd=" + tb_password.Text + ";port="+tbPort.Text+ ";SslMode=none");
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
    }
}
