using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Pengajar
{
    public partial class FLRaport : Form
    {
        /// بسم الله الرحمن الرحيم
        /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
        /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
        private List<string> KodeKelas, KodePelajaran;
        public FLRaport()
        {
            InitializeComponent();
            this.SetControlFrom();
            tbhalaman.SetHalaman(bprev, ldarihalaman, bnext, Loaddb);
            CbTahunAjaran.LoadTahunAjaran();

            CbTahunAjaran.SelectedIndexChanged += LoadingData;
            CbKelas.SelectedIndexChanged += LoadingData;
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
        private void BOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BExport_Click(object sender, EventArgs e)
        {
            Dg.ExportExcel(Text);
        }
        /// <summary>
        /// Loding data
        /// </summary>
        /// <returns>boolean</returns>
        private bool Loaddb()
        {
            if (CbTahunAjaran.SelectedIndex >= 0 && CbKelas.SelectedIndex >= 0)
            {
                Dg.Columns.Clear();
                Dg.Columns.Add("Column0", "NIS");
                Dg.Columns.Add("Column1", "SISWA");
                Dg.Columns.Add("Column2", "JK");
                int a = Dg.Columns.Count;

                string tempselelct = "";
                A.SetSelect("SELECT `kode_pelajaran`, `namapelajaran` ");
                A.SetFrom("FROM `tb_nilai` `N` INNER JOIN `tb_ruangan` `R` ON `R`.`kode_ruangan`=`N`.`kode_ruangan` INNER JOIN `tb_jadwal` `J` ON `J`.`kode_jadwal`=`N`.`kode_jadwal` INNER JOIN `r_walikelas` `W` ON `W`.`kode_kelas`=`R`.`kode_kelas` AND `W`.`tahunajaran`=`R`.`tahunajaran` LEFT JOIN `r_matapelajaran` `MP` ON `MP`.`kodepelajaran`=`J`.`kode_pelajaran` LEFT JOIN  `m_siswa` `S` ON `S`.`kode_siswa`=`R`.`kode_siswa` ");
                A.SetWhere("WHERE `N`.`kode_jenisnilai`='JN0000000000001' AND `W`.`kode_guru`='GR1501907290001' AND `J`.`tahunajaran`='2019/2020' AND `J`.`kode_kelas`='KL1011907230001' ");
                A.SetGroupby("GROUP BY `kode_pelajaran` ");
                A.SetOrderby("ORDER BY `namapelajaran` ");
                A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetGroupby() + A.GetOrderby() + ";");
                foreach (DataRow b in A.GetQueri().GetData().Rows)
                {
                    tempselelct += ", SUM(IF(`kode_pelajaran`= '" + b["kode_pelajaran"] + "', `nilai`, '-')) `" + b["namapelajaran"] + "`";
                    Dg.Columns.Add("Column1" + a, b["namapelajaran"].ToString());
                    a++;
                }

                A.SetSelect("SELECT `nis`, `namasiswa`, `jeniskelamin`" + tempselelct);
                A.SetGroupby("GROUP BY `R`.`kode_siswa` ");
                A.SetOrderby("ORDER BY `namasiswa` ");
                A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetGroupby() + A.GetOrderby() +
                    tbhalaman.LimitQ(ldarihalaman, A.GetFrom(), A.GetWhere(), A.GetGroupby()) + "");
                A.SetLQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetOrderby());
                Dg.QueriToDg();
            }
            return true;
        }
    }
}
