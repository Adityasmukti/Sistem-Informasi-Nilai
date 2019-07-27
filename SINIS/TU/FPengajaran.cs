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
    /// بسم الله الرحمن الرحيم
    /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
    /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
    public partial class FPengajaran : Form
    {
        private string query = "";
        private List<string> kodekelas, kodeguru;
        public FPengajaran()
        {
            InitializeComponent();
            this.SetControlFrom();
            tbhalaman.SetHalaman(bprev, ldarihalaman, bnext, Loaddb);

            CbTahunAjaran.LoadTahunAjaran();
            kodekelas = CbKelas.LoadKelas();
            kodeguru = CbGuru.LoadGuru();

            CbTahunAjaran.SelectedIndexChanged += LoadingData;
            CbKelas.SelectedIndexChanged += LoadingData;
            CbGuru.SelectedIndexChanged += LoadingData;
            TbCari.TextChanged += LoadingData;
        }

        private void LoadingData(object sender, EventArgs e)
        {
            tbhalaman.Text = "1";
            Loaddb();
        }

        private void FPengajaran_Load(object sender, EventArgs e)
        {
            Loaddb();
        }

        private bool Loaddb()
        {
            if (CbKelas.SelectedIndex >= 0)
            {
                A.SetSelect("SELECT IFNULL(`J`.`kode_jadwal`,'0') `kodejadwal`, `kodepelajaran`, " +
                    "IF(`J`.`kode_jadwal` IS NULL, 'BELUM', 'SUDAH') `pilih`, `kodemapel`, `namapelajaran`, `namaguru`, `keterangan`, `jadwal` ");
                A.SetFrom("FROM `r_matapelajaran` `MP` LEFT JOIN (SELECT `J`.`kode_jadwal`, `J`.`kode_pelajaran`, " +
                    "CONCAT(`nidn`,' (',IF(`gelardepan`='','',CONCAT(`gelardepan`,' ')), `namaguru`, " +
                    "IF(`gelarbelakang`='','',CONCAT(`gelarbelakang`,' ')),')') `namaguru`, `J`.`keterangan` FROM `tb_jadwal` `J` " +
                    "LEFT JOIN `m_guru` `G` ON `G`.`kode_guru`=`J`.`kode_guru`WHERE `kode_kelas`='" + kodekelas[CbKelas.SelectedIndex] + "' " +
                    "AND tahunajaran='" + CbTahunAjaran.Text + "') `J` ON `J`.`kode_pelajaran`=`MP`.`kodepelajaran` " +
                    "LEFT JOIN (SELECT`kode_jadwal`,  GROUP_CONCAT(`hari`,',',`waktu`,',',`totaljam`,';' SEPARATOR '\n') `jadwal` " +
                    "FROM  `tb_waktupelajaran`GROUP BY `kode_jadwal`) `W` ON `W`.`kode_jadwal`=`J`.`kode_jadwal`");
                A.SetWhere("WHERE `status`='Y' AND `hapus`='N' ");
                TbCari.GenerateQueriCari(new List<string>() { "kodemapel", "namapelajaran", "namaguru" });
                A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + tbhalaman.LimitQ(ldarihalaman, A.GetFrom(), A.GetWhere()) + ";");
                Dg.QueriToDg();
                return true;
            }
            return false;
        }
        private void Dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == Dg.GetColumnIndexByHeader("PILIH"))
                {
                    if(Dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("BELUM"))
                    {
                        FKelolaPengajaran f = new FKelolaPengajaran(CbTahunAjaran.Text, 
                            Dg.Rows[e.RowIndex].Cells[Dg.GetColumnIndexByHeader("KODE PELAJARAN")].Value.ToString(), 
                            kodeguru[CbGuru.SelectedIndex]);
                        f.ShowDialog();
                        Loaddb();
                    }
                    else
                    {
                        FKelolaPengajaran f = new FKelolaPengajaran(Dg.Rows[e.RowIndex].Cells[Dg.GetColumnIndexByHeader("KODE JADWAL")].Value);
                        f.ShowDialog();
                        Dg.LoadIndex(Loaddb, e.ColumnIndex);
                    }
                }
            }
        }
    }
}
