using System;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace AtelierAngelinaApps.Auxs
{
    public partial class FShowProduk : Form
    {
        string KodeOrder = "";
        public FShowProduk(string kodeorder)
        {
            InitializeComponent();
            this.SetControlFrom();
            KodeOrder = kodeorder;
            Dg.Rows.Clear();
            foreach (DataRow b in A.GetData("SELECT `barcode`, `nama_series`, `nama_produk`, `nama_kategori`, `nama_size`, `nama_warna`, `qty`, `realqty`, " +
                "IF(`komplete`='Y','KOMPLIT','BELUM KOMPLIT') `komplete` FROM `t_orderitems` `OI` LEFT JOIN `r_series` `SR` ON `SR`.`id_series` = `OI`.`id_series` " +
                "LEFT JOIN `m_produk` `P` ON `P`.`kode_produk` = `OI`.`kode_produk` LEFT JOIN `r_size` `S` ON `S`.`id_size` = `P`.`id_size` " +
                "LEFT JOIN `r_warna` `W` ON `W`.`id_warna` = `P`.`id_warna` LEFT JOIN `r_kategori` `K` ON `K`.`id_kategori` = `P`.`id_kategori` " +
                "WHERE `kode_fakturorder`='" + kodeorder + "'; ").Rows)
                Dg.Rows.Add(b[0], b[1], b[2], b[3], b[4], b[5], b[6], b[7], b[8]);
        }

        private void FShowProduk_Load(object sender, EventArgs e)
        {
            
        }

        private void BPrintProduk_Click(object sender, EventArgs e)
        {
            KodeOrder.CetakStikerProduk();
        }
    }
}
