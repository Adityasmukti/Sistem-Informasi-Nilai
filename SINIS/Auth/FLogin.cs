using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ExtensionMethods;
using System.Collections.Generic;

namespace SINIS.Auth
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();

            S.SetSettings();
            this.SetControlFrom();
            TbUsername.KeyDown += Tbusername_KeyDown;
            BKeluar.Click += Bclose_Click;
            this.Activated += FLogin_Activated;
            TbUsername.ForeColor = Color.DimGray;
            TbPassword.ForeColor = Color.DimGray;

        }
        private void FLogin_Activated(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.loginsaveusername)
            {
                TbPassword.Focus();
                TbPassword.ForeColor = Color.Black;
                TbPassword.Text = string.Empty;
                TbPassword.PasswordChar = '*';
            }
            else
                TbUsername.Focus();
        }
        private void Bclose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Tbusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TbPassword.Focus();
        }
        private void Tbusername_Enter(object sender, EventArgs e)
        {
            if (TbUsername.Text == "Username" && TbUsername.ForeColor == Color.DimGray)
            {
                TbUsername.Text = string.Empty;
                TbUsername.ForeColor = Color.Black;
            }
        }
        private void Tbusername_Leave(object sender, EventArgs e)
        {
            if (TbUsername.Text == string.Empty)
            {
                TbUsername.ForeColor = Color.DimGray;
                TbUsername.Text = "Username";
            }
        }
        private void Tbpassword_Leave(object sender, EventArgs e)
        {
            if (TbPassword.Text == string.Empty)
            {
                TbPassword.ForeColor = Color.DimGray;
                TbPassword.Text = "Password";
                TbPassword.PasswordChar = '\0';
            }
        }
        private void Tbpassword_Enter(object sender, EventArgs e)
        {
            if (TbPassword.Text == "Password" && TbPassword.ForeColor == Color.DimGray)
            {
                TbPassword.ForeColor = Color.Black;
                TbPassword.Text = string.Empty;
                TbPassword.PasswordChar = '*';
            }
        }
        private void Blogin_Click(object sender, EventArgs e)
        {
            if (TbPassword.ForeColor == Color.DimGray || TbUsername.ForeColor == Color.DimGray)
                MessageBox.Show("User dan Password harus di isi!!", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                A.SetQueri("SELECT `id_user`, `id_akses`, `username`, `kode_ref` " +
                    "FROM `m_user` WHERE `hapus`='N' AND `username`='" + TbUsername.Text +
                    "' AND `password`=MD5('" + TbPassword.Text + "') LIMIT 1");
                bool ada = false;

                foreach (DataRow baris in A.GetQueri().GetData().Rows)
                {
                    S.SetUsername(baris["username"].ToString().EncodeUtf8());
                    S.SetUseracces(baris["id_akses"].ToString());
                    S.SetUserid(baris["id_user"].ToString());
                    S.SetKodeGuru(baris["kode_ref"].ToString());
                    S.SetKodesiswa(baris["kode_ref"].ToString());
                    ada = true;
                }

                if (ada)
                {
                    if (S.GetUseracces() == "1" || S.GetUseracces() == "2")
                        S.SetUsernama(A.SingelData("SELECT `namaguru` FROM `m_guru` WHERE `kode_guru`='" + S.GetKodeGuru() + "';"));
                    else if (S.GetUseracces() == "3")
                        S.SetUsernama(A.SingelData("SELECT `namasiswa` FROM `m_siswa` WHERE  `kode_siswa`='" + S.GetKodesiswa() + "';"));

                    TbPassword.Clear();
                    TbUsername.Clear();
                    Tbusername_Leave(sender, e);
                    Tbpassword_Leave(sender, e);
                    this.ShowInTaskbar = false;
                    this.Hide();
                    A.SetLogin();
                    Properties.Settings.Default.loginsaveusername = CbSaveUsername.Checked;
                    Properties.Settings.Default.username = S.GetUsername();
                    Properties.Settings.Default.Save();
                    FMainMenu f = new FMainMenu();
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        List<Form> openForms = new List<Form>();
                        foreach (Form form in Application.OpenForms)
                            openForms.Add(form);

                        foreach (Form ff in openForms)
                        {
                            if (ff.Name != "FLogin")
                                ff.Close();
                        }

                        this.Show();
                        this.ShowInTaskbar = true;
                        if (Properties.Settings.Default.loginsaveusername)
                        {
                            TbUsername.Text = S.GetUsername().DecodeUtf8();
                            TbUsername.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        A.SetLogout();
                        Close();
                    }
                }
                else
                    MessageBox.Show("Username / Password Salah!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Tbpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                Blogin_Click(sender, e);
        }
        private void FLogin_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.loginsaveusername)
            {
                CbSaveUsername.Checked = true;
                TbUsername.Text = Properties.Settings.Default.username.DecodeUtf8();
                TbUsername.ForeColor = Color.Black;
            }
        }
        private void FLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                Settings.FSettingDb f = new Settings.FSettingDb();
                f.Show();
            }
        }
    }
}