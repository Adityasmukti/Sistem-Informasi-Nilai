using System;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Auth
{
    public partial class FUser : Form
    {
        /// بسم الله الرحمن الرحيم
        /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
        /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
        public FUser()
        {
            InitializeComponent();
            this.SetControlFrom();
            tbhalaman.SetHalaman(bprev, ldarihalaman, bnext, Loaddb);
            bubah.Click += Bubah_Click;
            bhakakses.Click += Bhakakses_Click;
        }
        private void Bdelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hapus penggguna?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (A.DBHapus("UPDATE `m_user` SET `hapus` = 'Y' WHERE `id_user` = '" + Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("ID USER")].Value.ToString() + "';"))
                    Loaddb();

            }
        }
        private void Bhakakses_Click(object sender, EventArgs e)
        {
            try
            {
                FHakAkses f = new FHakAkses();
                f.ShowDialog();
                Loaddb();
            }
            catch (Exception) { }
        }
        private void Bubah_Click(object sender, EventArgs e)
        {
            FKelolaUser f = new FKelolaUser(Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("ID USER")].Value.ToString());
            f.ShowDialog();
            Loaddb();
        }
        private void FUser_Load(object sender, EventArgs e)
        {
            bhakakses.Visible = false;
            if (S.GetUseracces() == "1")
                bhakakses.Visible = true;
            Loaddb();
        }
        private bool Loaddb()
        {
            A.SetSelect("SELECT `id_user`, `nama_akses`, `username` ");
            A.SetFrom("FROM `m_user` `U` LEFT JOIN `m_akses` `A` ON `A`.`id_akses`=`U`.`id_akses` ");
            A.SetWhere("WHERE `hapus`='N' ");
            if (S.GetUseracces() != "1")
                A.SetWhere(A.GetWhere() + "AND `id_user`='" + S.GetUserid() + "' ");
            A.SetOrderby(" ORDER BY `id_user` ");
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetOrderby() + tbhalaman.LimitQ(ldarihalaman, A.GetFrom(), A.GetWhere()));
            Dg.QueriToDg();
            return true;
        }
    }
}
