using ExtensionMethods;
using System;
using System.Windows.Forms;

namespace AtelierAngelinaApps.Auxs
{
    public partial class FListProduk : Form
    {
        public FListProduk(string KodeOrder)
        {
            InitializeComponent();
            this.SetControlFrom();
            this.KeyDown += F_KeyDown;
            A.SetSelect("SELECT `qty`, `nama_series`, `nama_brand`, `nama_kategori`, `nama_produk`, `nama_size`, `nama_warna`, `berat`, `hargajual` ");
            A.SetFrom("FROM `t_orderitems` `OI` LEFT JOIN `r_series` `SR` ON `SR`.`id_series`=`OI`.`id_series` LEFT JOIN `m_produk` `P` ON `P`.`kode_produk`=`OI`.`kode_produk` " +
                "LEFT JOIN `r_brand` `B` ON `B`.`id_brand`=`P`.`id_brand` LEFT JOIN `r_kategori` `K` ON `K`.`id_kategori`=`P`.`id_kategori` " +
                "LEFT JOIN `r_size` `S` ON `S`.`id_size`=`P`.`id_size` LEFT JOIN `r_warna` `W` ON `W`.`id_warna`=`P`.`id_warna` " +
                "LEFT JOIN `m_harga` `H` ON `H`.`kode_produk`=`OI`.`kode_produk` AND `H`.`id_series`=`OI`.`id_series` ");
            A.SetWhere("WHERE `kode_fakturorder`='"+KodeOrder+"' ");
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + ";");
            this.Load += FListProduk_Load;
        }

        private void FListProduk_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(A.GetQueri()))
            {
                Dg.QueriToDg();
            }
        }

        private void F_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
            }
            else if (e.KeyCode == Keys.F2)
            {
            }
            else if (e.KeyCode == Keys.F3)
            {
            }
            else if (e.KeyCode == Keys.F4)
            {
            }
            else if (e.KeyCode == Keys.F5)
            {
            }
            else if (e.KeyCode == Keys.F6)
            {
            }
            else if (e.KeyCode == Keys.F7)
            {
            }
            else if (e.KeyCode == Keys.F8)
            {
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
