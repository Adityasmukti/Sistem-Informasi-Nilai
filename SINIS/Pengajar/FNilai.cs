using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Pengajar
{
    public partial class FNilai : Form
    {
        private string query = "";
        private List<string> kodekelas;
        private List<string> kodepelajaran;
        private List<string> kodejenisnilai;
        public FNilai()
        {
            InitializeComponent();
            this.SetControlFrom();
            tbhalaman.SetHalaman(bnext, ldarihalaman, bnext, Loaddb);
        }
        private void dgnilai_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbpelajaran_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            query = "SELECT id_jadwal FROM tbl_jadwal WHERE tahunajaran='" + CbTahunAjaran.Text +
                "' AND id_guru=" + idguru +
                " AND id_kelas=" + listidkelas[CbKelas.SelectedIndex] +
                " AND id_pelajaran=" + listidpelajaran[CbMataPelajaran.SelectedIndex] + " LIMIT 1";
            //idjadwal = DM.singeldata(query);

            Loaddb();
        }

        private void FInputNilai_Load(object sender, EventArgs e)
        {



        }

        private bool Loaddb()
        {
            if (CbMataPelajaran.SelectedIndex >= 0 && CbKelas.SelectedIndex >= 0 &&
                CbJenisNilai.SelectedIndex >= 0 && CbTahunAjaran.SelectedIndex >= 0)
            {
                query = "SELECT IF(IFNULL(id_nilai,0)>0,1,0) dapat, siswa_nama, siswa_nis, siswa_jk, tbl_ruangan.id_siswa, tbl_ruangan.id_ruangan, " +
                    "IFNULL(id_nilai, 0) id_nilai, IFNULL(nilai, 0) nilai,IFNULL(tgl,'-') tgl, ketnilai, ketsiswa, IFNULL(id_jadwal, 0) id_jadwal " +
                    "FROM tbl_ruangan LEFT JOIN tm_siswa ON tbl_ruangan.id_siswa = tm_siswa.id " +
                    "LEFT JOIN (SELECT * FROM tbl_nilai WHERE id_jenisnilai=" + listidjenisnilai[CbJenisNilai.SelectedIndex] +
                    " AND id_jadwal=" + idjadwal +
                    ") tbl_nilai ON tbl_nilai.id_ruangan = tbl_ruangan.id_ruangan " +
                    "WHERE tbl_ruangan.id_kelas = " + listidkelas[CbKelas.SelectedIndex] +
                    " AND tbl_ruangan.tahunajaran = '" + CbTahunAjaran.Text + "'";
             
            }
            return true;
        }

        private void Dg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Dg.GetColumnIndexByHeader("INPUT"))
            {
                string values = Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("NILAI")].Value.ToString();
                if (A.InputBoxNumber("Input", "Nilai", ref values) == DialogResult.OK)
                {
                    A.ManipulasiData("INSERT INTO tbl_nilai (nilai, id_jadwal, id_ruangan, id_jenisnilai, tahunajaran, ketnilai,tgl) " +
                        "VALUES ( " + values + ", " + idjadwal + ", " + idruangan + ", " + listidjenisnilai[cbjenisnilai.SelectedIndex] +
                        ", '" + cbtahunajaran.Text + "', '" + tbketnilai.Text + "', '" + dtptgl.Value.ToString("yyyy-MM-dd HH:mm:ss") + "')");
                    Dg.LoadIndex(Loaddb, e.ColumnIndex);
                }
            }
            else if (e.ColumnIndex == Dg.GetColumnIndexByHeader("KETERANGAN"))
            {
                string values = Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("KETERANGAN")].Value.ToString();
                if (Dg.CurrentRow.Cells[DB.GetColumnIndexByHeader(Dg, "INPUT")].Value.ToString() == "HAPUS")
                {
                    if (A.InputRichTextBox("Input", "Keterangan", ref values) == DialogResult.OK)
                    {
                        A.ManipulasiData("UPDATE tbl_nilai SET ketsiswa='" + values + "' WHERE id_nilai=" + Dg.CurrentRow.Cells[DB.GetColumnIndexByHeader(Dg, "ID NILAI")].Value.ToString());
                        Dg.LoadIndex(Loaddb, e.ColumnIndex);
                    }
                }
                else
                    MessageBox.Show("Tidak dapet memberi keterangan ketika nilai belum di berikan!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
