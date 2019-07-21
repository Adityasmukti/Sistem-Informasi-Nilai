using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.TU
{
    public partial class FMasterGuru : Form
    {
        public FMasterGuru()
        {
            InitializeComponent();
            this.SetControlFrom();
            tbhalaman.SetHalaman(bprev, ldarihalaman, bnext, Loaddb);
        }
        private void BTambah_Click(object sender, EventArgs e)
        {
            FInputGuru f = new FInputGuru();
            f.ShowDialog();
            Loaddb();
        }
        private bool Loaddb()
        {
            A.SetSelect("SELECT `kode_guru`, `nidn`, `nik`, `nosk`, CONCAT(IF(`gelardepan` IS NULL,'', CONCAT(`gelardepan`,' ')), `namaguru`, ' ', " +
                "IF(`gelarbelakang` IS NULL, '', CONCAT(`gelarbelakang`,' '))) `namaguru`, `jeniskelamin`, CONCAT(IF(`tempatlahir`='','-', `tempatlahir`), ', ', DATE_FORMAT(`tgllahir`,'%d/%m/%Y')) `ttl`, " +
                "`nohp`, `email`, `alamat`, `golongan`, `jabatanstruktural`, `jabatanfungsional`, DATE_FORMAT(`masuk`,'%d/%m/%Y') `masuk`, `status` ");
            A.SetFrom("FROM `m_guru` ");
            A.SetWhere("WHERE `hapus`='N' ");
            TbCari.GenerateQueriCari(new List<string>() { "nidn", "nik", "nosk", "namaguru", "gelardepan", "gelarbelakang", "golongan", "nohp", "email", });
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + tbhalaman.LimitQ(ldarihalaman, A.GetFrom(), A.GetWhere()) + ";");
            Dg.QueriToDg();
            return true;
        }
        private void BOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FMasterGuru_Load(object sender, EventArgs e)
        {
            Loaddb();
        }

        private void BUbah_Click(object sender, EventArgs e)
        {
            FInputGuru f = new FInputGuru(Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("KODE GURU")].Value.ToString());
            f.ShowDialog();
            Dg.LoadIndex(Loaddb, 1);
        }
    }
}
