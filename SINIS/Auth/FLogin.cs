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
            tbusername.KeyDown += Tbusername_KeyDown;
            bclose.Click += Bclose_Click;
            this.Activated += FLogin_Activated;
            tbusername.ForeColor = Color.DimGray;
            tbpassword.ForeColor = Color.DimGray;

        }
        private void FLogin_Activated(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.loginsaveusername)
            {
                tbpassword.Focus();
                tbpassword.ForeColor = Color.Black;
                tbpassword.Text = string.Empty;
                tbpassword.PasswordChar = '*';
            }
            else
                tbusername.Focus();
        }
        private void Bclose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Tbusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbpassword.Focus();
        }
        private void Tbusername_Enter(object sender, EventArgs e)
        {
            if (tbusername.Text == "Username" && tbusername.ForeColor == Color.DimGray)
            {
                tbusername.Text = string.Empty;
                tbusername.ForeColor = Color.Black;
            }
        }
        private void Tbusername_Leave(object sender, EventArgs e)
        {
            if (tbusername.Text == string.Empty)
            {
                tbusername.ForeColor = Color.DimGray;
                tbusername.Text = "Username";
            }
        }
        private void Tbpassword_Leave(object sender, EventArgs e)
        {
            if (tbpassword.Text == string.Empty)
            {
                tbpassword.ForeColor = Color.DimGray;
                tbpassword.Text = "Password";
                tbpassword.PasswordChar = '\0';
            }
        }
        private void Tbpassword_Enter(object sender, EventArgs e)
        {
            if (tbpassword.Text == "Password" && tbpassword.ForeColor == Color.DimGray)
            {
                tbpassword.ForeColor = Color.Black;
                tbpassword.Text = string.Empty;
                tbpassword.PasswordChar = '*';
            }
        }
        private void Blogin_Click(object sender, EventArgs e)
        {
            if (tbpassword.ForeColor == Color.DimGray || tbusername.ForeColor == Color.DimGray)
                MessageBox.Show("User dan Password harus di isi!!", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                A.SetQueri("SELECT `id_user`, `id_akses`, `username`, `nama` " +
                    "FROM `m_user` WHERE `hapus`='N' AND `username`='" + tbusername.Text +
                    "' AND `password`=MD5('" + tbpassword.Text + "') LIMIT 1");
                bool ada = false;

                foreach (DataRow baris in A.GetQueri().GetData().Rows)
                {
                    S.SetUsername(baris["username"].ToString().EncodeUtf8());
                    S.SetUseracces(baris["id_akses"].ToString());
                    S.SetUserid(baris["id_user"].ToString());
                    S.SetUsernama(baris["nama"].ToString());
                    ada = true;
                }

                if (ada)
                {
                    tbpassword.Clear();
                    tbusername.Clear();
                    Tbusername_Leave(sender, e);
                    Tbpassword_Leave(sender, e);
                    this.ShowInTaskbar = false;
                    this.Hide();
                    A.SetLogin();
                    Properties.Settings.Default.loginsaveusername = cbsaveusername.Checked;
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
                            tbusername.Text = S.GetUsername().DecodeUtf8();
                            tbusername.ForeColor = Color.Black;
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
                cbsaveusername.Checked = true;
                tbusername.Text = Properties.Settings.Default.username.DecodeUtf8();
                tbusername.ForeColor = Color.Black;
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