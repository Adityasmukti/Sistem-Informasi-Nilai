using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.TU
{
    /// بسم الله الرحمن الرحيم
    /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
    /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
    public partial class FRuangKelas : Form
    {
        private List<string> KodeKelas;
        public FRuangKelas()
        {
            InitializeComponent();
            this.SetControlFrom();
            CbTahunAjaran.LoadTahunAjaran();
            CbMasuk.LoadAngkatan();
            KodeKelas = CbKelas.LoadKelas();

            CbTahunAjaran.SelectedIndexChanged += LoadingData;
            CbMasuk.SelectedIndexChanged += LoadingData;
            CbKelas.SelectedIndexChanged += LoadingData;
            TbCari.TextChanged += LoadingData;
        }
        private void LoadingData(object sender, EventArgs e)
        {
            loaddb();
        }
        private bool loaddb()
        {
            if (CbKelas.SelectedIndex >= 0 && CbTahunAjaran.SelectedIndex >= 0 && CbMasuk.SelectedIndex >= 0)
            {
                A.SetSelect("SELECT `SW`.`kode_siswa`, `kode_ruangan`, IF(`kode_ruangan` IS NULL, 'BELUM', 'SUDAH') `pilih`, `namakelas`, `nis`, " +
                    "`namasiswa`,`jeniskelamin`,`masuk`, `R`.`keterangan` ");
                A.SetFrom("FROM `m_siswa` `SW` LEFT JOIN (SELECT * FROM `tb_ruangan` `R` WHERE `tahunajaran`= '" + CbTahunAjaran.Text + "') `R` " +
                    "ON `R`.`kode_siswa` = `SW`.`kode_siswa` LEFT JOIN `r_kelas` `K` ON `K`.`kode_kelas`=`R`.`kode_kelas` ");
                A.SetWhere("WHERE `SW`.`hapus` = 'N' AND `masuk` LIKE '" + CbMasuk.Text + "%' ");
                TbCari.GenerateQueriCari(new List<string>() { "namakelas", "nis", "namasiswa" });
                A.SetOrderby("ORDER BY `SW`.`namasiswa` ASC ");
                A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + ";");
                Dg.QueriToDg();
            }
            return true;
        } 
        private void Dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == Dg.GetColumnIndexByHeader("PILIH"))
                {
                    int index = Dg.CurrentRow.Index;
                    if (Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("PILIH")].Value.ToString().Equals("SUDAH"))
                    {
                        if (MessageBox.Show("Hapus Kelas?","Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (A.ManipulasiData("DELETE FROM `tb_ruangan` " +
                                "WHERE `kode_ruangan` = '" + Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("KODE RUANGAN")].Value.ToString() + "'"))
                                Dg.LoadIndex(loaddb, 2);
                        }
                    }
                    else
                    {
                        string value = "";
                        A.InputRichTextBox("Keterangan", "Input", ref value);
                        A.SetInsert("INSERT INTO `tb_ruangan` (`kode_ruangan`,`kode_kelas`,`kode_siswa`,`tahunajaran`,`keterangan`,`tanggal`,`id_user`) ");
                        A.SetValues("VALUES ('" + A.GenerateKode("RG", "tb_ruangan", "kode_ruangan") + "', '" + KodeKelas[CbKelas.SelectedIndex] + "', " +
                            "'" + Dg.Rows[e.RowIndex].Cells[0].Value.ToString() + "', '" + CbTahunAjaran.Text + "', '" + value + "', NOW(), '" + S.GetUserid() + "')");
                        A.SetQueri(A.GetInsert() + A.GetValues() + ";");
                        if (A.GetQueri().ManipulasiData())
                            Dg.LoadIndex(loaddb, 2);
                    }
                }
            }
        }
    }
}
