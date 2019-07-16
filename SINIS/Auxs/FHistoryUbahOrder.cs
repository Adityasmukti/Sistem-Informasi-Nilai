using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtensionMethods;

namespace AtelierAngelinaApps.Auxs
{
    public partial class FHistoryUbahOrder : Form
    {
        private List<string> Idpengguna;
        public FHistoryUbahOrder()
        {
            InitializeComponent();
            this.SetControlFrom();
            tbhalaman.SetHalaman(bprev, ldarihalaman, bnext, Loaddb);

            Dtp.ValueChanged += LoadingData;
            CbPengguna.SelectedIndexChanged += LoadingData;
            TbCari.TextChanged += LoadingData;
        }
        private void LoadingData(object sender, EventArgs e)
        {
            tbhalaman.Text = "1";
            Loaddb();
        }

        private void FHistoryUbahOrder_Load(object sender, EventArgs e)
        {
            CbPengguna.LoadFieldPengguna();
            Idpengguna = CbPengguna.LoadUser();

            Loaddb();
        }
        private bool Loaddb()
        {
            try
            {
                A.SetSelect("SELECT `waktu`, CONCAT(`nama`, ' ', `jabatan`, ' ', `noadmin`), `kode_barcode`, `total`, `namapembeli`, `sebelumubah`, `setelahubah` ");
                A.SetFrom("FROM `t_ubahorder` `TO` LEFT JOIN `f_order` `O` ON `O`.`kode_fakturorder`=`TO`.`kode_order` LEFT JOIN `m_user` `U` ON `U`.`id_user`=`TO`.`id_user` ");
                A.SetWhere("WHERE 1=1 ");
                if (Dtp.Checked)
                    A.SetWhere(A.GetWhere() + "AND `waktu` LIKE '" + Dtp.Value.ToStringDate() + "%' ");
                CbPengguna.GenerateQueriValue(Idpengguna, "`TO`.`id_user`");
                TbCari.GenerateQueriCari(new List<string>() { F_order.Kode_barcode, F_order.Total, F_order.Namapembeli});
                A.SetOrderby("ORDER BY `waktu` DESC ");
                A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetOrderby() + tbhalaman.LimitQ(ldarihalaman, LJData, A.GetFrom(), A.GetWhere()));
                Dg.QueriToDg();
                return true;
            }
            catch (Exception ex)
            {
                ex.LogError(A.GetCurrentMethod(), Text);
                return false;
            }
        }

        private void Dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dg.Rows.Count > 0)
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == Dg.GetColumnIndexByHeader("ASAL") || e.ColumnIndex == Dg.GetColumnIndexByHeader("JADI"))
                    {
                        FDeskripsi f = new FDeskripsi(Dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), Dg.Columns[e.ColumnIndex].HeaderText);
                        f.ShowDialog();
                    }
                }
            }
        }
    }
}
