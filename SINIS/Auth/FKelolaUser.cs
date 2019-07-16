using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace AtelierAngelinaApps.Modul_HRD
{
    public partial class FKelolaUser : Form
    {
        private List<string> idakses;
        public FKelolaUser()
        {
            InitializeComponent();
            this.SetControlFrom();
            Text = "Tambah";
            bsimpan.Click += Bsimpan_ClickTambah;
            bbatal.Click += Bbatal_Click;
        }
        private void Bbatal_Click(object sender, EventArgs e) => Close();
        private string oldpass, IdUser;
        public FKelolaUser(string iduser)
        {
            InitializeComponent();
            this.SetControlFrom();
            Text = "Ubah";
            IdUser = iduser;
            bsimpan.Click += Bsimpan_ClickUbah;
        }
        private void Bsimpan_ClickTambah(object sender, EventArgs e)
        {
            A.SetQueri("SELECT COUNT(*) FROM `m_user` WHERE `userdelete`='N' AND `username`='" + tbusername.Text + "'");
            if (A.GetQueri().SingelData().ToInteger() > 0)
                MessageBox.Show("Nama Username telah digunakan!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (tbusername.Text == string.Empty)
                MessageBox.Show("Username Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (tbpassword.Text == string.Empty)
                MessageBox.Show("Password Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (cbhakakses.Text == string.Empty)
                MessageBox.Show("Hak Akses Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (tbnama.Text == string.Empty)
                MessageBox.Show("Nama Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (tbjabatan.Text == string.Empty)
                MessageBox.Show("Jabatan Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (tbpassword.Text != tbpass2.Text)
                MessageBox.Show("Password Tidak sesuai!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (tbpassword.Text.Length <= 3)
                MessageBox.Show("Password Harus Lebih dari 3 Karakter", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (MessageBox.Show("Simpan data ini?", "Pertanyaan?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    A.SetQueri("INSERT INTO `m_user` (`id_akses`,`username`,`password`,`nama`,`jabatan`,`noadmin`,`device`, `ppic`) VALUES" +
                    "( " + idakses[cbhakakses.SelectedIndex] + ", '" + tbusername.Text + "', MD5('" + tbpassword.Text +
                    "'), '" + tbnama.Text + "', '" + tbjabatan.Text + "', '" + tbnoadmin.Text + "', '" + A.GetMACAddress() + "', " + S.GetUserid() + ")");
                    if (A.GetQueri().ManipulasiData())
                    {
                        MessageBox.Show("Berhasil Di Simpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ClearControl();
                    }
                    else
                        MessageBox.Show("Gagal Menyimpan!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Bsimpan_ClickUbah(object sender, EventArgs e)
        {
            A.SetQueri("SELECT COUNT(*) FROM `m_user` WHERE `userdelete`='N' AND `username`='" + tbusername.Text + "' AND `id_user`<>'" + IdUser + "'");
            if (A.GetQueri().SingelData().ToInteger() > 1)
                MessageBox.Show("Nama Username telah digunakan Orang lain!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (tbusername.Text == string.Empty)
                MessageBox.Show("Username Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (tbpassword.Text == string.Empty)
                MessageBox.Show("Password Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (cbhakakses.Text == string.Empty)
                MessageBox.Show("Hak Akses Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (tbnama.Text == string.Empty)
                MessageBox.Show("Nama Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (tbjabatan.Text == string.Empty)
                MessageBox.Show("Jabatan Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (tbpassword.Text.Length <= 3)
                MessageBox.Show("Password Harus Lebih dari 3 Karakter", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (tbpassword.Text != oldpass && tbpassword.Text != tbpass2.Text)
                MessageBox.Show("Password Tidak Sesuai!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (MessageBox.Show("Simpan data ini?", "Pertanyaan?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string pass = "";
                    if (tbpass2.TextLength > 0)
                        if (tbpassword.Text == tbpass2.Text)
                            pass = ", `password` = MD5('" + tbpassword.Text + "')";
                    A.SetQueri("UPDATE `m_user` SET `id_akses` = " + idakses[cbhakakses.SelectedIndex] +
                        ", `username` = '" + tbusername.Text + "' " + pass + ", `nama` = '" + tbnama.Text + "', `jabatan` = '" + tbjabatan.Text +
                        "', `noadmin` = '" + tbnoadmin.Text + "' WHERE `id_user` =" + IdUser + ";");
                    if (A.GetQueri().ManipulasiData())
                    {
                        MessageBox.Show("Berhasil Di Simpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (IdUser == S.GetUserid())
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
        }
        private void Bbatal_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void FKelolaUser_Load(object sender, EventArgs e)
        {
            cbhakakses.Items.Clear();
            idakses = new List<string>();
            A.SetQueri("SELECT * FROM `m_akses` ORDER BY `nama_akses` DESC");
            foreach (DataRow b in A.GetQueri().GetData().Rows)
            {
                idakses.Add(b["id_akses"].ToString());
                cbhakakses.Items.Add(b["nama_akses"].ToString());
            }
            cbhakakses.SelectedIndex = 0;

            if (Text == "UBAH")
            {
                A.SetSelect("SELECT * ");
                A.SetFrom(" FROM `m_user` U ");
                A.SetWhere(" WHERE `U`.`userdelete`='N' AND `U`.`id_user`=" + IdUser);
                A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere());
                foreach (DataRow b in A.GetQueri().GetData().Rows)
                {
                    tbusername.Text = b["username"].ToString();
                    tbpassword.Text = b["password"].ToString();
                    oldpass = b["password"].ToString();
                    cbhakakses.SelectedIndex = idakses.FindIndex(x => x.Equals(b["id_akses"].ToString()));
                    tbnama.Text = b["nama"].ToString();
                    tbjabatan.Text = b["jabatan"].ToString();
                    tbnoadmin.Text = b["noadmin"].ToString();
                }
            }

            cbhakakses.Enabled = false;
            if (S.GetUseracces() == "1")
                cbhakakses.Enabled = true;
        }
    }
}