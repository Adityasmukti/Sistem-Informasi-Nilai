using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SINIS.TU
{
    /// بسم الله الرحمن الرحيم
    /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
    /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
    public partial class FMasterSiswa : Form
    {
        public FMasterSiswa()
        {
            InitializeComponent();
            this.SetControlFrom();
            tbhalaman.SetHalaman(bprev, ldarihalaman, bnext, Loaddb);
            CbAngkatan.SelectedIndexChanged += LoadingData;
            Dtp1.ValueChanged += LoadingData;
            Dtp2.ValueChanged += LoadingData;
        }

        private void LoadingData(object sender, EventArgs e)
        {
            tbhalaman.Text = "1";
            Loaddb();
        }

        private void FMasterSiswa_Load(object sender, EventArgs e)
        {
            CbAngkatan.LoadAngkatan();
            Loaddb();
        }
        private void BTambah_Click(object sender, EventArgs e)
        {

            FInputSiswa f = new FInputSiswa();
            f.ShowDialog();
            Loaddb();
        }
        private bool Loaddb()
        {
            A.SetSelect("SELECT `kode_siswa`, `nis`, `namasiswa`, `jeniskelamin`, CONCAT(IF(`tempatlahir`='','-', `tempatlahir`),', ', `tgllahir`) `tll`, `kontak`, `email`, " +
                "`alamat`, `ayah`, `ibu`, DATE_FORMAT(`masuk`,'%d-%m-%Y') `masuk`,`angkatan`, `status`, `keterangan` ");
            A.SetFrom("FROM `m_siswa` ");
            A.SetWhere("WHERE `hapus`='N' ");
            Dtp1.GenerateQueriDate(Dtp2, "masuk");
            CbAngkatan.GenerateQueriValue("angkatan");
            TbCari.GenerateQueriCari(new List<string>() { "nis", "namasiswa", "tempatlahir", "kontak", "email", "ayah", "ibu" });
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + tbhalaman.LimitQ(ldarihalaman, A.GetFrom(), A.GetWhere()) + ";");
            Dg.QueriToDg();
            return true;
        }
        private void BOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BUbah_Click(object sender, EventArgs e)
        {
            if (Dg.Rows.Count >= 0)
            {
                if (Dg.SelectedRows.Count > 0)
                {
                    FInputSiswa f = new FInputSiswa(Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("KODE SISWA")].Value.ToString());
                    f.ShowDialog();
                    Dg.LoadIndex(Loaddb, 1);
                }
            }
            else MessageBox.Show("Data Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
