using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Pengajar
{
    /// بسم الله الرحمن الرحيم
    /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
    /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
    public partial class FLKelas : Form
    {
        private List<string> KodeKelas, KodePelajaran;
        public FLKelas()
        {
            InitializeComponent();
            this.SetControlFrom();
            tbhalaman.SetHalaman(bprev, ldarihalaman, bnext, Loaddb);
            CbTahunAjaran.LoadTahunAjaran(S.GetKodeGuru());

            CbTahunAjaran.SelectedIndexChanged += LoadingData;
            CbKelas.SelectedIndexChanged += LoadingData;
            CbMapel.SelectedIndexChanged += LoadingData;
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
        private void CbMapel_DropDown(object sender, EventArgs e)
        {
            if (CbKelas.SelectedIndex >= 0)
                KodePelajaran = CbMapel.LoadPelajaran(S.GetKodeGuru(), CbTahunAjaran.Text, KodeKelas[CbKelas.SelectedIndex]);
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
            if(CbTahunAjaran.SelectedIndex>=0 && CbKelas.SelectedIndex>=0 && CbMapel.SelectedIndex>=0)
            {
                Dg.Columns.Clear();
                Dg.Columns.Add("Column0", "NIS");
                Dg.Columns.Add("Column1", "SISWA");
                Dg.Columns.Add("Column2", "JK");
                int a = Dg.Columns.Count;

                string tempselelct = "";
                A.SetSelect("SELECT `N`.`kode_jenisnilai`, `namajenisnilai` ");
                A.SetFrom("FROM `tb_nilai` `N` LEFT JOIN `r_jenisnilai` `JN` ON `JN`.`kode_jenisnilai`=`N`.`kode_jenisnilai` " +
                    "LEFT JOIN `tb_ruangan` `R` ON `R`.`kode_ruangan`=`N`.`kode_ruangan` LEFT JOIN `tb_jadwal` `J` ON `J`.`kode_jadwal`=`N`.`kode_jadwal` " +
                    "LEFT JOIN `r_kelas` `K` ON `K`.`kode_kelas`=`R`.`kode_kelas` LEFT JOIN `m_siswa` `S` ON `S`.`kode_siswa`=`R`.`kode_siswa` ");
                A.SetWhere("WHERE `J`.`kode_guru`='"+S.GetKodeGuru()+"' AND `J`.`tahunajaran`='"+CbTahunAjaran.Text+ "' " +
                    "AND `J`.`kode_pelajaran`='"+KodePelajaran[CbMapel.SelectedIndex]+"' AND `J`.`kode_kelas`='"+KodeKelas[CbKelas.SelectedIndex]+"' ");
                A.SetGroupby("GROUP BY `N`.`kode_jenisnilai` ");
                A.SetOrderby("ORDER BY `JN`.`urutan` ");
                A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetGroupby() + A.GetOrderby() + ";");
                foreach(DataRow b in A.GetQueri().GetData().Rows)
                {
                    tempselelct += ", SUM(IF(`N`.`kode_jenisnilai`= '" + b["kode_jenisnilai"] + "', `nilai`, '-')) `" + b["namajenisnilai"] + "`";
                    Dg.Columns.Add("Column1"+a, b["namajenisnilai"].ToString());
                    a++;
                }                

                A.SetSelect("SELECT `nis`, `namasiswa`, `jeniskelamin`" + tempselelct);
                A.SetGroupby("GROUP BY `S`.`kode_siswa`");
                A.SetOrderby("ORDER BY `namasiswa` ");
                A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetGroupby() + A.GetOrderby() +
                    tbhalaman.LimitQ(ldarihalaman, A.GetFrom(), A.GetWhere(), A.GetGroupby()) + "");
                A.SetLQueri(A.GetSelect()+A.GetFrom()+A.GetWhere()+A.GetOrderby());
                Dg.QueriToDg();
            }
            return true;
        }
    }
}
