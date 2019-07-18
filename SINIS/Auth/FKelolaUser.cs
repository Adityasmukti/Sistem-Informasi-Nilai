using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Auth
{
    public partial class FKelolaUser : Form
    {
        private List<string> idakses;      
        public FKelolaUser(string iduser)
        {
            InitializeComponent();
            this.SetControlFrom();
            this.Load += (sender, e) =>
            {
                idakses = CbHakAkses.LoadAkses();
                CbHakAkses.SelectedIndex = 0;

                foreach (DataRow b in A.GetData("SELECT `username`,`password`,`id_akses` FROM `m_user` WHERE `id_user`=" + iduser).Rows)
                {
                    TbUsername.Text = b["username"].ToString();
                    TbPassword.Text = b["password"].ToString();
                    CbHakAkses.SelectedIndex = idakses.FindIndex(x => x.Equals(b["id_akses"].ToString()));
                }

                CbHakAkses.Enabled = false;
                if (S.GetUseracces() == "1")
                    CbHakAkses.Enabled = true;
            };

            BSimpan.Click += (sender,e)=> {
                A.SetQueri("SELECT COUNT(*) FROM `m_user` WHERE `userdelete`='N' AND `username`='" + TbUsername.Text + "' AND `id_user`<>'" + iduser + "'");
                if (A.GetQueri().SingelData().ToInteger() > 1)
                    MessageBox.Show("Nama Username telah digunakan Orang lain!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (TbUsername.Text == string.Empty)
                    MessageBox.Show("Username Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (TbPassword.Text == string.Empty)
                    MessageBox.Show("Password Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (CbHakAkses.Text == string.Empty)
                    MessageBox.Show("Hak Akses Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (TbPassword.Text.Length <= 3)
                    MessageBox.Show("Password Harus Lebih dari 3 Karakter", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (TbPassword.Text != TbUlangPassword.Text)
                    MessageBox.Show("Password Tidak Sesuai!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (MessageBox.Show("Simpan data ini?", "Pertanyaan?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string pass = "";
                        if (TbUlangPassword.TextLength > 0)
                            if (TbPassword.Text == TbUlangPassword.Text)
                                pass = ", `password` = MD5('" + TbPassword.Text + "')";
                        A.SetQueri("UPDATE `m_user` SET `id_akses` = '" + idakses[CbHakAkses.SelectedIndex] + "', `username` = '" + TbUsername.Text + "' " + pass + " WHERE `id_user` =" + iduser + ";");
                        if (A.GetQueri().ManipulasiData())
                        {
                            MessageBox.Show("Berhasil Di Simpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (iduser == S.GetUserid())
                            {
                                Application.Restart();
                                Environment.Exit(0);
                            }
                            else
                                Close();
                        }
                        else
                            MessageBox.Show("Gagal Menyimpan!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };
        }
    }
}