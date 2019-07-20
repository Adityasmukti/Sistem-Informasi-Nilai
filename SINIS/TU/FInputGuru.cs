using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.TU
{
    public partial class FInputGuru : Form
    {
        private List<string> IdHakAkses;
        public FInputGuru()
        {
            InitializeComponent();
            this.SetControlFrom();
            IdHakAkses = CbHakAkses.LoadAkses();
            LInfo.Text = "  * Data yang telah disimpan dapat login dengan Username : NIP dan Password : 123456 sesuai hakakses yang diberikan\n" +
                "  * Mohon untuk pengguna(guru) untuk segera menganti password";
            BSimpan.Click += (sender, e) =>
            {
                if (string.IsNullOrEmpty(TbNidn.Text))
                    MessageBox.Show("NIDN kosog!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(TbNama.Text))
                    MessageBox.Show("Nama kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(TbKontak.Text))
                    MessageBox.Show("Kontak kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (CbHakAkses.SelectedIndex<0)
                    MessageBox.Show("Hak Akses harus dipilih!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (MessageBox.Show("Simpa data guru?","Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string kodeguru = A.GenerateKode("GR", "m_guru", "kode_guru");
                        A.SetInsert("INSERT INTO `m_guru` (`kode_guru`, `nidn`, `nik`, `nosk`, `namaguru`, `jeniskelamin`, `nohp`, `email`, `alamat`, " +
                            "`tempatlahir`, `tgllahir`, `gelardepan`, `gelarbelakang`, `masuk`, `golongan`, `jabatanstruktural`, `jabatanfungsional`, `status`) ");
                        A.SetValues("VALUES ('" + kodeguru + "', '" + TbNidn.Text + "', '" + TbNik.Text + "', '" + TbNoSk.Text + "', " +
                            "'" + TbNama.StrEscape() + "', '" + CbJenisKelamin.Text + "', '" + TbKontak.Text + "', '" + TbEmail.Text + "', '" + TbAlamat.StrEscape() + "', " +
                            "'" + TbTempatLahir.StrEscape() + "', '" + DtpLahir.ToStringDate() + "', '" + TbGelarDepan.StrEscape() + "', '" + TbGelarBelakang.StrEscape() + "', " +
                            "'" + DtpMasuk.ToStringDate() + "', '" + TbGolongan.StrEscape() + "', '" + TbJabatanStruktural.StrEscape() + "', " +
                            "'" + TbJabatanFungsional.StrEscape() + "', '" + CbStatus.Text + "')");
                        A.SetQueri(A.GetInsert() + A.GetValues() + ";");

                        A.SetInsert("INSERT INTO `m_user` (`id_akses`, `kode_ref`, `username`, `password`, `device`, `ppic`) ");
                        A.SetValues("VALUES ('"+IdHakAkses[CbHakAkses.SelectedIndex]+"', '"+kodeguru+"', '"+TbNidn.Text+"', " +
                            "MD5('123456'), '"+A.GetMACAddress()+ "', '" + S.GetUserid() + "')");
                        A.SetQueri(A.GetQueri() + A.GetInsert() + A.GetValues() + ";");

                        if (A.GetQueri().ManipulasiData())
                        {
                            MessageBox.Show("Data telah tersimpan","Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                }
            };
        }
        public FInputGuru(string kodeguru)
        {
            InitializeComponent();
            this.SetControlFrom();
            LInfo.Text = "  * Data yang telah disimpan dapat login dengan Username : NIP dan Password : 123456 sesuai hakakses yang diberikan\n" +
                "  * Mohon untuk pengguna(guru) untuk segera menganti password";
            A.SetSelect("SELECT `nidn`, `nik`, `nosk`, `namaguru`, `nohp`, `email`, `alamat`, `masuk`, `status`, `jeniskelamin`, `gelardepan`,  " +
                "`gelarbelakang`, `tempatlahir`, `tgllahir`, `jabatanstruktural`, `jabatanfungsional`, `golongan` ");
            A.SetFrom("FROM `m_guru` ");
            A.SetWhere("WHERE `kode_guru`='" + kodeguru + "'");
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + ";");
            foreach (DataRow b in A.GetQueri().GetData().Rows)
            {
                TbNidn.Text = b["nidn"].ToString();
                TbNik.Text = b["nik"].ToString();
                TbNoSk.Text = b["nosk"].ToString();
                TbNama.Text = b["namaguru"].ToString();
                TbKontak.Text = b["nohp"].ToString();
                TbEmail.Text = b["email"].ToString();
                TbAlamat.Text = b["alamat"].ToString();
                DtpMasuk.Value = b["masuk"].ToString().ToDateTime();
                CbStatus.Text = b["status"].ToString();
                CbJenisKelamin.Text = b["jeniskelamin"].ToString();
                TbGelarDepan.Text = b["gelardepan"].ToString();
                TbGelarBelakang.Text = b["gelarbelakang"].ToString();
                TbTempatLahir.Text = b["tempatlahir"].ToString();
                DtpLahir.Value = b["tgllahir"].ToString().ToDateTime();
                TbJabatanStruktural.Text = b["jabatanstruktural"].ToString();
                TbJabatanFungsional.Text = b["jabatanfungsional"].ToString();
                TbGolongan.Text = b["golongan"].ToString();
            }

            string id_user = "", username = "";
            A.SetSelect("SELECT `id_user`, `id_akses`, `username` ");
            A.SetFrom("FROM `m_user` ");
            A.SetWhere("WHERE `kode_ref`='" + kodeguru + "'");
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + ";");
            foreach (DataRow b in A.GetQueri().GetData().Rows)
            {
                id_user = b["id_user"].ToString();
                username = b["username"].ToString();
                CbHakAkses.SelectedItem = IdHakAkses.FindIndex(c => c.Equals(b["id_akses"].ToString());
            }

            BSimpan.Click += (sender, e) =>
            {
                if (string.IsNullOrEmpty(TbNidn.Text))
                    MessageBox.Show("NIDN kosog!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(TbNama.Text))
                    MessageBox.Show("Nama kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(TbKontak.Text))
                    MessageBox.Show("Kontak kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (CbHakAkses.SelectedIndex < 0)
                    MessageBox.Show("Hak Akses harus dipilih!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (MessageBox.Show("Simpa data guru?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        A.SetUpdate("");
                        A.SetSet("");
                        A.SetWhere("");
                        A.SetQueri(A.GetUpdate()+A.GetSet()+A.GetWhere() + ";");

                        A.SetUpdate("");
                        A.SetSet("");
                        A.SetWhere("");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");

                        if (A.GetQueri().ManipulasiData())
                        {
                            MessageBox.Show("Data telah tersimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                }
            };
        }
        private void BBatal_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
