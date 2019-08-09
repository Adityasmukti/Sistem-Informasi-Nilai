using System;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Pengajar
{
    /// بسم الله الرحمن الرحيم
    /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
    /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
    public partial class FPelajaran : Form
    {
        public FPelajaran()
        {
            InitializeComponent();
            this.SetControlFrom();
            tbhalaman.SetHalaman(bprev, ldarihalaman, bnext, Loaddb);
            CbTahunAjaran.LoadTahunAjaran(S.GetKodeGuru());
            TbCari.TextChanged += LoadingData;
            CbTahunAjaran.SelectedIndexChanged += LoadingData;
        }
        private void LoadingData(object sender, EventArgs e)
        {
            tbhalaman.Text = "1";
            Loaddb();
        }
        private bool Loaddb()
        {
            if (CbTahunAjaran.SelectedIndex >= 0)
            {
                A.SetSelect("SELECT `namakelas`, `kodemapel`, `namapelajaran`, `hari`, DATE_FORMAT(`waktu`, '%h:%i') `waktu`, `totaljam` ");
                A.SetFrom("FROM `tb_jadwal` `J` LEFT JOIN `tb_waktupelajaran` `W` ON `W`.`kode_jadwal`=`J`.`kode_jadwal` " +
                    "LEFT JOIN `r_matapelajaran` `MP` ON `MP`.`kodepelajaran`=`J`.`kode_pelajaran` " +
                    "LEFT JOIN `r_kelas` `K` ON `K`.`kode_kelas`=`J`.`kode_kelas` ");
                A.SetWhere("WHERE `J`.`kode_guru`='"+S.GetKodeGuru()+"' AND tahunajaran = '"+CbTahunAjaran.Text+"' ");
                A.SetOrderby("ORDER BY `namakelas`, `namapelajaran` ASC ");
                A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetOrderby() + tbhalaman.LimitQ(ldarihalaman, LJData, A.GetFrom(), A.GetWhere()) + ";");
                A.SetLQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetGroupby() + A.GetOrderby());
                Dg.QueriToDg();
            }
            return true;
        }
        private void BOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BExport_Click(object sender, EventArgs e)
        {
            if (Dg.Rows.Count > 0)
            {
                string judul = "Data Pelajaran Tahun Ajaran " + CbTahunAjaran.Text + " " + DateTime.Now.ToString("dd/MM/yyyy");
                Dg.ExportExcel(judul);
            }
            else
                MessageBox.Show("Data kosong!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
