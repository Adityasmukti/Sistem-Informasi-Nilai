using System;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Auth
{
    public partial class FUser : Form
    {
        public FUser()
        {
            InitializeComponent();
            
            this.SetControlFrom();
            tbhalaman.SetHalaman(bprev, ldarihalaman, bnext, Loaddb);
            btambah.Click += Btambah_Click;
            bubah.Click += Bubah_Click;
            bhakakses.Click += Bhakakses_Click;
            bdelete.Click += Bdelete_Click;
        }
        private void Bdelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hapus penggguna?","Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if (A.DBHapus("UPDATE `m_user` SET `userdelete` = 'Y' WHERE `id_user` = '" + Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("ID USER")].Value.ToString() + "';"))
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
        private void Btambah_Click(object sender, EventArgs e)
        {
            FKelolaUser f = new FKelolaUser();
            f.ShowDialog();
            Loaddb();
        }        
        private void FUser_Load(object sender, EventArgs e)
        {
            btambah.Enabled = false;
            bdelete.Enabled = false;
            bhakakses.Enabled = false;
            if(S.GetUseracces()=="1")
            {
                btambah.Enabled = true;
                bdelete.Enabled = true;
                bhakakses.Enabled = true;
            }
            Loaddb();
        }
        private bool Loaddb()
        {
            try
            {
                A.SetSelect("SELECT `id_user`, `nama_akses`, `username` , `nama`, `jabatan`, IF(`noadmin`=0,'-', `noadmin`) `noadmin` ");
                A.SetFrom("FROM `m_user` `U` LEFT JOIN `m_akses` `A` ON `A`.`id_akses`=`U`.`id_akses` ");
                A.SetWhere("WHERE `userdelete`='N' ");
                if (S.GetUseracces() != "1")
                {
                    A.SetWhere(A.GetWhere() + "AND `id_user`='"+S.GetUserid()+"' ");
                }
                A.SetOrderby(" ORDER BY `nama_akses` ASC, `nama` ASC ");
                A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetOrderby() + tbhalaman.LimitQ(ldarihalaman, A.GetFrom(), A.GetWhere()));
                Dg.QueriToDg();
                return true;
            }
            catch(Exception ex)
            {
                ex.LogError(A.GetCurrentMethod(), Text);
                return false;
            }
        }        
    }
}
