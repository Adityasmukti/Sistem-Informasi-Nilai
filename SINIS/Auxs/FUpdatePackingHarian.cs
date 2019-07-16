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

namespace AtelierAngelinaApps.Auxs
{
    public partial class FUpdatePackingHarian : Form
    {
        public FUpdatePackingHarian()
        {
            InitializeComponent();
            this.SetControlFrom();
            Dtp.ValueChanged += LoadingData;
        }

        private void LoadingData(object sender, EventArgs e)
        {
            Loaddb();
        }

        private void FUpdatePackingHarian_Load(object sender, EventArgs e)
        {
            Loaddb();
        }
        private void Loaddb()
        {
            A.SetQueri("SELECT CONCAT('*Update Packing Harian*\n*', DATE_FORMAT('"+Dtp.Value.ToStringDate()+"', '%W, %d %M %Y'),'*\n', " +
                "IFNULL((SELECT GROUP_CONCAT(`openorder`,' : ', `jumlah` SEPARATOR '\n') FROM (SELECT `openorder`, COUNT(*) `jumlah` FROM `f_order`  " +
                "WHERE `paket`='Y' AND `tglpaket` LIKE '" + Dtp.Value.ToStringDate() + "%' GROUP BY `openorder` ORDER BY `openorder`) a),''), '\n*Total seluruh ', " +
                "IFNULL((SELECT COUNT(*) FROM `f_order` WHERE `paket`='Y' AND `tglpaket` LIKE '" + Dtp.Value.ToStringDate() + "%'),''),' paket*\n\n', " +
                "IFNULL((SELECT GROUP_CONCAT('*',`kurir`, ' : ', `jumlah`,'*' SEPARATOR '\n') FROM (SELECT `kurir`, COUNT(*) `jumlah` FROM `f_order` `O` " +
                "LEFT JOIN `r_kurir` `KR` ON `KR`.`id_kurir`=`O`.`id_kurir` " +
                "WHERE `kirim`='Y' AND `tglpaket` LIKE '" + Dtp.Value.ToStringDate() + "%' GROUP BY `O`.`id_kurir`) c),''),'\nTotal pickup : ', " +
                "IFNULL((SELECT COUNT(*) FROM `f_order` `O` LEFT JOIN `r_kurir` `KR` ON `KR`.`id_kurir`=`O`.`id_kurir` WHERE `kirim`='Y' AND `tglpaket` LIKE '" + Dtp.Value.ToStringDate() + "%'),''), ' paket');");
            //A.GetQueri().SaveTextSQL();
            TbText.Text = A.GetQueri().SingelData();
        }

        private void BCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TbText.Text);
            MessageBox.Show("Telah diSalin ke Clipboard!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
