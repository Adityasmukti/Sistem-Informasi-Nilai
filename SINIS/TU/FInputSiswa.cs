using ExtensionMethods;
using System;
using System.Data;
using System.Windows.Forms;

namespace SINIS.TU
{
    public partial class FInputSiswa : Form
    {
        public FInputSiswa()
        {
            InitializeComponent();
            this.SetControlFrom();
            BHapus.Visible = false;
            LInfo.Text = "  * Data yang telah disimpan dapat login dengan Username : NIP dan Password : 123456 sesuai hakakses yang diberikan\n" +
                "  * Mohon untuk pengguna(siswa) untuk segera menganti password";
            CbAngkatan.LoadAngkatan();

            BSimpan.Click += (sender, e) =>
            {
                if (string.IsNullOrEmpty(TbNis.Text))
                    MessageBox.Show("NIS kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (A.SearchData("SELECT `nis` FROM `m_siswa` WHERE `hapus`='N' AND `nis`='" + TbNis.Text + "';"))
                    MessageBox.Show("NIS telah ada yang menggunakan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(TbNama.Text))
                    MessageBox.Show("Nama kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(TbKontak.Text))
                    MessageBox.Show("Kontak kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(CbAngkatan.Text))
                    MessageBox.Show("Angkatan kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (A.SearchData("SELECT * FROM `m_user` WHERE `hapus`= 'N' AND `username`='" + TbNis.Text + "';"))
                    MessageBox.Show("NIS untuk Username telah ada yang menggunakan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (MessageBox.Show("Simpa data guru?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string kode = A.GenerateKode("SW", "m_siswa", "kode_siswa");
                        A.SetInsert("INSERT INTO `m_siswa` (`kode_siswa`, `nis`, `namasiswa`, `alamat`, `ayah`, `ibu`, " +
                            "`kontak`, `status`, `keterangan`, `angkatan`, `masuk`, `jeniskelamin`, `tempatlahir`, `tgllahir`, `email`)");
                        A.SetValues("VALUES ('" + kode + "', '" + TbNis.Text + "', '" + TbNama.StrEscape() + "', '" + TbAlamat.StrEscape() + "', '" + TbAyah.StrEscape() + "', '" + TbIbu.StrEscape() + "', " +
                            "'" + TbKontak.Text + "', '" + CbStatus.Text + "', '" + TbKeterangan.StrEscape() + "', '" + CbAngkatan.Text + "', '" + DtpMasuk.ToStringDate() + "', '" + CbJenisKelamin.Text + "', " +
                            "'" + TbTempatLahir.StrEscape() + "', '" + DtpLahir.ToStringDate() + "', '" + TbEmail.Text + "')");
                        A.SetQueri(A.GetInsert() + A.GetValues() + ";");

                        A.SetInsert("INSERT INTO `m_user` (`id_akses`, `kode_ref`, `username`, `password`, `device`, `ppic`) ");
                        A.SetValues("VALUES ('4', '" + kode + "', '" + TbNis.Text + "', MD5('123456'), '" + A.GetMACAddress() + "', '" + S.GetUserid() + "')");
                        A.SetQueri(A.GetQueri() + A.GetInsert() + A.GetValues() + ";");

                        if (A.GetQueri().ManipulasiData())
                        {
                            MessageBox.Show("Data telah tersimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                }
            };
        }
        public FInputSiswa(string kodesiswa)
        {
            InitializeComponent();
            this.SetControlFrom();
            BHapus.Visible = true;
            LInfo.Text = "  * Data yang telah disimpan dapat login dengan Username : NIP dan Password : 123456 sesuai hakakses yang diberikan\n" +
                "  * Mohon untuk pengguna(siswa) untuk segera menganti password";
            CbAngkatan.LoadAngkatan();

            A.SetSelect("SELECT `nis`, `namasiswa`, `alamat`, `ayah`, `ibu`, `kontak`, `status`, `keterangan`, `angkatan`, `masuk`, `jeniskelamin`, `tempatlahir`, `tgllahir`, `email` ");
            A.SetFrom("FROM `m_siswa` ");
            A.SetWhere("WHERE `kode_siswa`='" + kodesiswa + "'");
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + ";");
            string oldnis = "";
            foreach (DataRow b in A.GetQueri().GetData().Rows)
            {
                TbNis.Text = b["nis"].ToString();
                oldnis = b["nis"].ToString();
                TbNama.Text = b["namasiswa"].ToString();
                TbAlamat.Text = b["alamat"].ToString();
                TbAyah.Text = b["ayah"].ToString();
                TbIbu.Text = b["ibu"].ToString();
                TbKontak.Text = b["kontak"].ToString();
                CbStatus.Text = b["status"].ToString();
                TbKeterangan.Text = b["keterangan"].ToString();
                CbAngkatan.Text = b["angkatan"].ToString();
                DtpMasuk.Value = b["masuk"].ToString().ToDateTime();
                CbJenisKelamin.Text = b["jeniskelamin"].ToString();
                TbTempatLahir.Text = b["tempatlahir"].ToString();
                DtpLahir.Value = b["tgllahir"].ToString().ToDateTime();
                TbEmail.Text = b["email"].ToString();
            }

            BSimpan.Click += (sender, e) =>
            {
                if (string.IsNullOrEmpty(TbNis.Text))
                    MessageBox.Show("NIS kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (A.SearchData("SELECT `nis` FROM `m_siswa` WHERE `hapus`='N' AND `nis`='" + TbNis.Text + "' AND `nis`<>'" + oldnis + "';"))
                    MessageBox.Show("NIS telah ada yang menggunakan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(TbNama.Text))
                    MessageBox.Show("Nama kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(TbKontak.Text))
                    MessageBox.Show("Kontak kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(CbAngkatan.Text))
                    MessageBox.Show("Angkatan kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (MessageBox.Show("Ubah data siswa?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        A.SetUpdate("UPDATE `m_siswa` ");
                        A.SetSet("SET `nis` = '" + TbNis.Text + "', `namasiswa` = '" + TbNama.StrEscape() + "', `alamat` = '" + TbAlamat.StrEscape() + "', `ayah` = '" + TbAyah.StrEscape() + "', `ibu` = '" + TbIbu.StrEscape() + "', " +
                            "`kontak` = '" + TbKontak.Text + "', `status` = '" + CbStatus.Text + "', `keterangan` = '" + TbKeterangan.StrEscape() + "', `angkatan` = '" + CbAngkatan.Text + "', `masuk` = '" + DtpMasuk.ToStringDate() + "', " +
                            "`jeniskelamin` = '" + CbJenisKelamin.Text + "', `tempatlahir` = '" + TbTempatLahir.StrEscape() + "', `tgllahir` = '" + DtpLahir.ToStringDate() + "', `email` = '" + TbEmail.Text + "'");
                        A.SetWhere("WHERE `kode_siswa` = '" + kodesiswa + "'");
                        A.SetQueri(A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");

                        if (A.GetQueri().ManipulasiData())
                        {
                            MessageBox.Show("Data telah tersimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                }
            };

            BHapus.Click += (sender, e) =>
            {
                MessageBox.Show("Menghapus data siswa akan menghapus username login!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (MessageBox.Show("Hapus data?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    A.SetQueri("UPDATE `m_siswa` SET `hapus`='Y' WHERE `kode_siswa` = '" + kodesiswa + "'; " +
                        "UPDATE `m_user` SET `hapus` = 'Y' WHERE `kode_ref` = '" + kodesiswa + "'; ");
                    if (A.GetQueri().DBHapus())
                        Close();
                }
            };
        }
    }
}