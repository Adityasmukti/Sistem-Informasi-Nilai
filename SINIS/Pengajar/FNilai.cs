using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Pengajar
{
    /// بسم الله الرحمن الرحيم
    /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
    /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
    public partial class FNilai : Form
    {
        private List<string> KodeJenisNilai = new List<string>(), KodeKelas = new List<string>(), KodePelajaran = new List<string>();
        public FNilai()
        {
            InitializeComponent();
            this.SetControlFrom();
            tbhalaman.SetHalaman(bnext, ldarihalaman, bnext, Loaddb);

            CbTahunAjaran.LoadTahunAjaran(S.GetKodeGuru());
            KodeJenisNilai = CbJenisNilai.LoadJenisNilai();

            CbTahunAjaran.SelectedIndexChanged += LoadingData;
            CbJenisNilai.SelectedIndexChanged += LoadingData;
            CbKelas.SelectedIndexChanged += LoadingData;
            CbMataPelajaran.SelectedIndexChanged += LoadingData;
            TbCari.TextChanged += LoadingData;
        }
        private void LoadingData(object sender, EventArgs e)
        {
            tbhalaman.Text = "1";
            Loaddb();
        }
        private void CbKelas_DropDown(object sender, EventArgs e)
        {
            if (CbTahunAjaran.SelectedIndex >= 0)
                KodeKelas = CbKelas.LoadKelas(S.GetKodeGuru(), CbTahunAjaran.Text);
        }
        private void CbMataPelajaran_DropDown(object sender, EventArgs e)
        {
            if (CbTahunAjaran.SelectedIndex >= 0 && CbKelas.SelectedIndex >= 0)
                KodePelajaran = CbMataPelajaran.LoadPelajaran(S.GetKodeGuru(), CbTahunAjaran.Text, KodeKelas[CbKelas.SelectedIndex]);
        }
        private void BOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool Loaddb()
        {
            if (CbKelas.SelectedIndex >= 0 && CbJenisNilai.SelectedIndex >= 0 && CbTahunAjaran.SelectedIndex >= 0 && CbMataPelajaran.SelectedIndex >= 0)
            {
                A.SetSelect("SELECT IFNULL(`kode_nilai`, '0') `kode_nilai` , `R`.`kode_ruangan`, " +
                    "IF(`kode_nilai` IS NULL, 'INPUT', 'HAPUS') `input`, `nis`, `S`.`namasiswa`, `jeniskelamin`, `namakelas`, " +
                    "`N`.`tanggal`, IFNULL(`nilai`,'-') `nilai`, IFNULL(`N`.`keterangan`,'') `keterangan` ");
                A.SetFrom("FROM `tb_ruangan` `R` LEFT JOIN `m_siswa` `S` ON `R`.`kode_siswa` = `S`.`kode_siswa` " +
                    "LEFT JOIN `r_kelas` `K` ON `K`.`kode_kelas`=`R`.`kode_kelas`LEFT JOIN (SELECT * FROM `tb_nilai` `N` " +
                    "WHERE `N`.`kode_jenisnilai`='" + KodeJenisNilai[CbJenisNilai.SelectedIndex] + "' " +
                    "AND `N`.`kode_jadwal`=(SELECT `kode_jadwal` FROM `tb_jadwal` WHERE `kode_guru`='" + S.GetKodeGuru() + "' " +
                    "AND `kode_kelas`='" + KodeKelas[CbKelas.SelectedIndex] + "' AND `kode_pelajaran`= '" + KodePelajaran[CbMataPelajaran.SelectedIndex] + "' " +
                    "AND `tahunajaran`= '" + CbTahunAjaran.Text + "')) `N` ON `N`.`kode_ruangan` = `R`.`kode_ruangan` ");
                A.SetWhere("WHERE `R`.`kode_kelas` =  '" + KodeKelas[CbKelas.SelectedIndex] + "' AND `R`.`tahunajaran` = '" + CbTahunAjaran.Text + "'");
                TbCari.GenerateQueriCari(new List<string>() { "nis", "namasiswa", "namakelas", "`N`.`keterangan`" });
                A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + tbhalaman.LimitQ(ldarihalaman, A.GetFrom(), A.GetWhere()) + ";");
                Dg.QueriToDg();
            }
            return true;
        }
        private void Dg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Dg.GetColumnIndexByHeader("INPUT"))
            {
                if (Dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("INPUT"))
                {
                    string nilai = Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("NILAI")].Value.ToString();
                    if (A.InputTextBox("Input", "Nilai", ref nilai) == DialogResult.OK)
                    {
                        string keterangan = Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("KETERANGAN")].Value.ToString();
                        A.InputRichTextBox("Keterangan", "Input", ref keterangan);

                        A.SetQueri("INSERT INTO `tb_nilai` (`kode_nilai`, `kode_jenisnilai`, `kode_ruangan`, `kode_jadwal`, `tanggal`, `id_user`, `nilai`, `keterangan`) " +
                            "VALUES ('" + A.GenerateKode("NL", "tb_nilai", "kode_nilai") + "', '" + KodeJenisNilai[CbJenisNilai.SelectedIndex] + "', " +
                            "'" + Dg.Rows[e.RowIndex].Cells[Dg.GetColumnIndexByHeader("KODE RUANGAN")].Value.ToString() + "', " +
                            "(SELECT `kode_jadwal` FROM `tb_jadwal` WHERE `kode_guru`='" + S.GetKodeGuru() + "' " +
                            "AND `kode_kelas`='" + KodeKelas[CbKelas.SelectedIndex] + "' AND `kode_pelajaran`= '" + KodePelajaran[CbMataPelajaran.SelectedIndex] + "' " +
                            "AND `tahunajaran`= '" + CbTahunAjaran.Text + "'), NOW(), '" + S.GetUserid() + "', '" + nilai + "', '" + keterangan + "');");
                        if (A.GetQueri().ManipulasiData())
                            Dg.LoadIndex(Loaddb, e.ColumnIndex);
                    }
                }
                else
                {
                    if (MessageBox.Show("Hapus data nilai?", "Pertanyaan", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (A.DBHapus("DELETE FROM `tb_nilai` WHERE `kode_nilai` = '" + Dg.Rows[e.RowIndex].Cells[Dg.GetColumnIndexByHeader("KODE NILAI")].Value.ToString() + "';"))
                            Loaddb();
                    }
                }
            }
            else if (e.ColumnIndex == Dg.GetColumnIndexByHeader("NILAI"))
            {
                if (Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("INPUT")].Value.ToString().Equals("INPUT"))
                    MessageBox.Show("Klik input!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string nilai = Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("NILAI")].Value.ToString();
                    if (A.InputTextBox("Input", "Nilai", ref nilai) == DialogResult.OK)
                    {
                        if (A.ManipulasiData("UPDATE `tb_nilai` SET `nilai` = '" + nilai + "' " +
                            "WHERE `kode_nilai` = '" + Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("KODE NILAI")].Value.ToString() + "';"))
                            Dg.LoadIndex(Loaddb, e.ColumnIndex);
                    }
                }
            }
            else if (e.ColumnIndex == Dg.GetColumnIndexByHeader("KETERANGAN"))
            {
                if (Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("INPUT")].Value.ToString().Equals("INPUT"))
                    MessageBox.Show("Klik input!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string nilai = Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("KETERANGAN")].Value.ToString();
                    if (A.InputRichTextBox("Input", "Keterangan", ref nilai) == DialogResult.OK)
                    {
                        if (A.ManipulasiData("UPDATE `tb_nilai` SET `keterangan` = '" + nilai + "' " +
                           "WHERE `kode_nilai` = '" + Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("KODE NILAI")].Value.ToString() + "';"))
                            Dg.LoadIndex(Loaddb, e.ColumnIndex);
                    }
                }
            }
        }
    }
}