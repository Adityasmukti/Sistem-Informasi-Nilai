using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Pengajar
{
    /// بسم الله الرحمن الرحيم
    /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
    /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
    public partial class FKelas : Form
    {
        private List<string> kodekelas;
        public FKelas()
        {
            InitializeComponent();
            this.SetControlFrom();
            tbhalaman.SetHalaman(bprev, ldarihalaman, bnext, Loaddb);
            CbTahunAjaran.LoadTahunAjaran(S.GetKodeGuru());
            TbCari.TextChanged += LoadingData;
            CbTahunAjaran.SelectedIndexChanged += LoadingData;
            CbKelas.SelectedIndexChanged += LoadingData;
        }
        private void LoadingData(object sender, EventArgs e)
        {
            tbhalaman.Text = "1";
            Loaddb();
        }
        private bool Loaddb()
        {
            if (CbKelas.SelectedIndex >= 0 && CbTahunAjaran.SelectedIndex >= 0)
            {
                A.SetSelect("SELECT `nis`, `namasiswa`, `jeniskelamin`, `angkatan` ");
                A.SetFrom("FROM `tb_ruangan` `R` LEFT JOIN `m_siswa` `S` ON `S`.`kode_siswa`=`R`.`kode_siswa` ");
                A.SetWhere("WHERE  `tahunajaran`= '"+CbTahunAjaran.Text+"' AND `R`.`kode_kelas`= '"+kodekelas[CbKelas.SelectedIndex]+"' ");
                A.SetOrderby("ORDER BY `namasiswa` ASC ");
                A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetOrderby() + tbhalaman.LimitQ(ldarihalaman, LJData, A.GetFrom(), A.GetWhere()) + ";");
                A.SetLQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetGroupby() + A.GetOrderby());
                Dg.QueriToDg();
            }
            return true;
        }
        private void CbKelas_DropDown(object sender, EventArgs e)
        {
            if (CbTahunAjaran.SelectedIndex >= 0)
                kodekelas = CbKelas.LoadKelas(S.GetKodeGuru(), CbTahunAjaran.Text);
        }
        private void BOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BExport_Click(object sender, EventArgs e)
        {
            if (Dg.Rows.Count > 0)
            {
                string judul = "Data Kelas " + CbKelas.Text + " Tahun Ajaran " + CbTahunAjaran.Text + " " + DateTime.Now.ToString("dd/MM/yyyy");
                Dg.ExportExcel(A.GetLQueri(), judul);
            }
            else
                MessageBox.Show("Data kosong!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
