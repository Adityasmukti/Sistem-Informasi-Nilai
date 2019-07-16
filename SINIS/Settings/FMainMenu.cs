using System;
using System.Windows.Forms;
using ExtensionMethods;

namespace AtelierAngelinaApps.Applications
{
    public partial class FMainMenu : Form
    {
        #region InitializeComponent
        // ============================== InitializeComponent ==============================
        public FMainMenu()
        {
            InitializeComponent();
            this.SetControlFrom();
            this.Load += LoadForm;
            this.Activated += ActivatedForm;
            this.FormClosing += ClosingForm;
            TbCatatan.TextChanged += (s, e) =>
            {
                TbCatatan.SaveNote();
            };
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            //code
        }
        private async void GetCallActivity()
        {
            string txtaktivitas = "";
            if (S.GetUseracces() == "1")//super admin
            {
                txtaktivitas = await A.GetStringValues("SET @id='" + S.GetUserid() + "'; SELECT CONCAT( 'Keterangan aktivitas yang di kerjakan oleh ', " +
                       "(SELECT CONCAT(`nama`, ' ', `jabatan`,' ', `noadmin`) FROM `m_user` WHERE `id_user`=@ID), '\n\nOPEN ORDER\n~~~~~~~~~~~\n', " +
                       "IFNULL((SELECT GROUP_CONCAT(`openorder`, '\t ', `input`,' input, ', `ubah`,' ubah, ', `jual`, ' to, ', `paket`, ' paket, ', `kirim`,' kirim' SEPARATOR '\n') `prosespo` " +
                       "FROM (SELECT `openorder`, SUM(IF(`id_input`<>0,1,0)) `input`, SUM(IF(`id_ubah`<>0,1,0)) `ubah`, SUM(IF(`id_jual`<>0,1,0)) `jual`, SUM(IF(`id_paket`<>0,1,0)) `paket`, " +
                       "SUM(IF(`id_kirim`<>0,1,0)) `kirim` FROM `f_order` WHERE `tglorder`>='2018-06-01 00:00:00' AND `openorder` IS NOT NULL AND `openorder`<>'' GROUP BY `openorder` " +
                       "ORDER BY `tglorder` DESC ) AS tmp),'-'), IFNULL((SELECT CONCAT( '\n\nSEMUA JENIS ORDER\n~~~~~~~~~~~~~~~~~\n', 'LINE Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' " +
                       "AND `jenisorder`='LINE' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'LINE Bulanan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' " +
                       "AND `jenisorder`='LINE' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'LINE Tahunan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='LINE' " +
                       "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', 'WEB Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='WEB' " +
                       "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'WEB Bulanan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='WEB' " +
                       "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'WEB Tahunan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='WEB' " +
                       "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', 'GIVEAWAY Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='GIVEAWAY' " +
                       "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'GIVEAWAY Bulanan\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='GIVEAWAY' " +
                       "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'GIVEAWAY Tahunan\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='GIVEAWAY' " +
                       "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', 'RETUR Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='RETUR' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'RETUR Bulanan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='RETUR' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'RETUR Tahunan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='RETUR' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', 'OTHER Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='OTHER' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'OTHER Bulanan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='OTHER' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'OTHER Tahunan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='OTHER' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', '\nSEMUA INPUT\n~~~~~~~~~~~\n', 'Harian ',SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', " +
                       "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', " +
                       "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', " +
                       "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', COUNT(*),' order / ', SUM(`qty`),' produk', '\n\nSEMUA BATAL\n~~~~~~~~~~~\n', 'Harian '," +
                       "SUM(IF(`cancel`='Y' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`cancel`='Y' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', SUM(IF(`cancel`='Y' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', " +
                       "SUM(IF(`cancel`='Y' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`cancel`='Y' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', SUM(IF(`cancel`='Y' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', " +
                       "SUM(IF(`cancel`='Y',1,0)),' order / ', SUM(IF(`cancel`='Y',`qty`,0)),' produk', '\n\nSEMUA TRANSFER\n~~~~~~~~~~~~~~\n', 'Harian ',SUM(IF(`transfer`='Y' AND `cancel`='N' " +
                       "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', " +
                       "SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', SUM(IF(`transfer`='Y' AND `cancel`='N',1,0)),' order / ', " +
                       "SUM(IF(`transfer`='Y' AND `cancel`='N',`qty`,0)),' produk', '\n\nSEMUA TO\n~~~~~~~~\n', 'Harian ',SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', " +
                       "SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', " +
                       "SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', SUM(IF(`jual`='Y' AND `cancel`='N',1,0)),' order / ', " +
                       "SUM(IF(`jual`='Y' AND `cancel`='N',`qty`,0)),' produk', '\n\nSEMUA KIRIM\n~~~~~~~~~~~\n', 'Harian ',SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', " +
                       "SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', " +
                       "SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', SUM(IF(`kirim`='Y' AND `cancel`='N',1,0)),' order / ', " +
                       "SUM(IF(`kirim`='Y' AND `cancel`='N',`qty`,0)),' produk', '\n\nTRANSFER BELUM TERKIRIM\n~~~~~~~~~~~~~~~~~~~~~~~\n', 'Harian ',SUM(IF(`transfer`='Y' AND `kirim`='N' " +
                       "AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                       "LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N',1,0)),' order / ', SUM(IF(`transfer`='Y' " +
                       "AND `kirim`='N' AND `cancel`='N',`qty`,0)),' produk' ) aktivitas FROM `f_order` `O` LEFT JOIN (SELECT `kode_fakturorder`, SUM(`qty`) `qty` FROM `t_orderitems` " +
                       "GROUP BY `kode_fakturorder`) `OI` ON `OI`.`kode_fakturorder`=`O`.`kode_fakturorder` WHERE `expireorder`='N'),'-') ) AS `deskripsi`; ");
            }
            else if (S.GetUseracces() == "2")//admin chat
            {
                txtaktivitas = await A.GetStringValues("SET @id='" + S.GetUserid() + "'; SELECT CONCAT( 'Keterangan aktivitas yang di kerjakan oleh ', (SELECT CONCAT(`nama`, ' ', `jabatan`,' ', `noadmin`) " +
                    "FROM `m_user` WHERE `id_user`=@id), '\n\nOPEN ORDER\n~~~~~~~~~~~\n', (SELECT GROUP_CONCAT(`openorder`, '\t ', `input`,' input, ', `ubah`,' ubah, ', `jual`, ' to, ', " +
                    "`paket`, ' paket, ', `kirim`,' kirim' SEPARATOR '\n') `prosespo` FROM (SELECT `openorder`, SUM(IF(`id_input`=@id,1,0)) `input`, SUM(IF(`id_ubah`=@id,1,0)) `ubah`, " +
                    "SUM(IF(`id_jual`=@id,1,0)) `jual`,  SUM(IF(`id_paket`=@id,1,0)) `paket`, SUM(IF(`id_kirim`=@id,1,0)) `kirim` FROM `f_order` WHERE `tglorder`>='2018-06-01 00:00:00' " +
                    "AND `openorder` IS NOT NULL AND `openorder`<>'' GROUP BY `openorder` ORDER BY `tglorder` DESC LIMIT 5 ) AS tmp), '\n\nINPUT\n~~~~~~\n', (SELECT CONCAT('Harian '," +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', " +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', " +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', COUNT(*),' order / ', " +
                    "SUM(`qty`),' produk' ) aktivitas FROM `f_order` `O` LEFT JOIN (SELECT `kode_fakturorder`, SUM(`qty`) `qty` FROM `t_orderitems` GROUP BY `kode_fakturorder`) `OI` " +
                    "ON `OI`.`kode_fakturorder`=`O`.`kode_fakturorder` WHERE `id_input`=@id), '\n\nTO\n~~~\n', (SELECT CONCAT('Harian ',SUM(IF(`tglorder` LIKE " +
                    "DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', " +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', " +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', " +
                    "COUNT(*),' order / ', SUM(`qty`),' produk' ) aktivitas FROM `f_order` `O` LEFT JOIN (SELECT `kode_fakturorder`, SUM(`qty`) `qty` FROM `t_orderitems` " +
                    "GROUP BY `kode_fakturorder`) `OI` ON `OI`.`kode_fakturorder`=`O`.`kode_fakturorder` WHERE `id_jual`=@id), '\n\nPAKET\n~~~~~~\n', (SELECT CONCAT('Harian '," +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', " +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', " +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', " +
                    "COUNT(*),' order / ', SUM(`qty`),' produk' ) aktivitas FROM `f_order` `O` LEFT JOIN (SELECT `kode_fakturorder`, SUM(`qty`) `qty` FROM `t_orderitems` " +
                    "GROUP BY `kode_fakturorder`) `OI` ON `OI`.`kode_fakturorder`=`O`.`kode_fakturorder` WHERE `id_paket`=@id)  ) AS `deskripsi`; ");
            }
            else if (S.GetUseracces() == "3")//admin komputer
            {
                txtaktivitas = await A.GetStringValues("SET @id='" + S.GetUserid() + "'; SELECT CONCAT( 'Keterangan aktivitas yang di kerjakan oleh ', " +
                    "(SELECT CONCAT(`nama`, ' ', `jabatan`,' ', `noadmin`) FROM `m_user` WHERE `id_user`=@ID), '\n\nOPEN ORDER\n~~~~~~~~~~~\n', " +
                    "IFNULL((SELECT GROUP_CONCAT(`openorder`, '\t ', `input`,' input, ', `ubah`,' ubah, ', `jual`, ' to, ', `paket`, ' paket, ', `kirim`,' kirim' SEPARATOR '\n') `prosespo` " +
                    "FROM (SELECT `openorder`, SUM(IF(`id_input`<>0,1,0)) `input`, SUM(IF(`id_ubah`<>0,1,0)) `ubah`, SUM(IF(`id_jual`<>0,1,0)) `jual`, SUM(IF(`id_paket`<>0,1,0)) `paket`, " +
                    "SUM(IF(`id_kirim`<>0,1,0)) `kirim` FROM `f_order` WHERE `tglorder`>='2018-06-01 00:00:00' AND `openorder` IS NOT NULL AND `openorder`<>'' GROUP BY `openorder` " +
                    "ORDER BY `tglorder` DESC ) AS tmp),'-'), IFNULL((SELECT CONCAT( '\n\nSEMUA JENIS ORDER\n~~~~~~~~~~~~~~~~~\n', 'LINE Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' " +
                    "AND `jenisorder`='LINE' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'LINE Bulanan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' " +
                    "AND `jenisorder`='LINE' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'LINE Tahunan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='LINE' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', 'WEB Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='WEB' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'WEB Bulanan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='WEB' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'WEB Tahunan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='WEB' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', 'GIVEAWAY Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='GIVEAWAY' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'GIVEAWAY Bulanan\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='GIVEAWAY' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'GIVEAWAY Tahunan\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='GIVEAWAY' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', 'RETUR Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='RETUR' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'RETUR Bulanan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='RETUR' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'RETUR Tahunan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='RETUR' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', 'OTHER Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='OTHER' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'OTHER Bulanan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='OTHER' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'OTHER Tahunan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='OTHER' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', '\nSEMUA INPUT\n~~~~~~~~~~~\n', 'Harian ',SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', " +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', " +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', " +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', COUNT(*),' order / ', SUM(`qty`),' produk', '\n\nSEMUA BATAL\n~~~~~~~~~~~\n', 'Harian '," +
                    "SUM(IF(`cancel`='Y' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`cancel`='Y' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', SUM(IF(`cancel`='Y' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', " +
                    "SUM(IF(`cancel`='Y' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`cancel`='Y' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', SUM(IF(`cancel`='Y' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', " +
                    "SUM(IF(`cancel`='Y',1,0)),' order / ', SUM(IF(`cancel`='Y',`qty`,0)),' produk', '\n\nSEMUA TRANSFER\n~~~~~~~~~~~~~~\n', 'Harian ',SUM(IF(`transfer`='Y' AND `cancel`='N' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', " +
                    "SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', SUM(IF(`transfer`='Y' AND `cancel`='N',1,0)),' order / ', " +
                    "SUM(IF(`transfer`='Y' AND `cancel`='N',`qty`,0)),' produk', '\n\nSEMUA TO\n~~~~~~~~\n', 'Harian ',SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', " +
                    "SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', " +
                    "SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', SUM(IF(`jual`='Y' AND `cancel`='N',1,0)),' order / ', " +
                    "SUM(IF(`jual`='Y' AND `cancel`='N',`qty`,0)),' produk', '\n\nSEMUA KIRIM\n~~~~~~~~~~~\n', 'Harian ',SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', " +
                    "SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', " +
                    "SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', SUM(IF(`kirim`='Y' AND `cancel`='N',1,0)),' order / ', " +
                    "SUM(IF(`kirim`='Y' AND `cancel`='N',`qty`,0)),' produk', '\n\nTRANSFER BELUM TERKIRIM\n~~~~~~~~~~~~~~~~~~~~~~~\n', 'Harian ',SUM(IF(`transfer`='Y' AND `kirim`='N' " +
                    "AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N',1,0)),' order / ', SUM(IF(`transfer`='Y' " +
                    "AND `kirim`='N' AND `cancel`='N',`qty`,0)),' produk' ) aktivitas FROM `f_order` `O` LEFT JOIN (SELECT `kode_fakturorder`, SUM(`qty`) `qty` FROM `t_orderitems` " +
                    "GROUP BY `kode_fakturorder`) `OI` ON `OI`.`kode_fakturorder`=`O`.`kode_fakturorder` WHERE `expireorder`='N'),'-') ) AS `deskripsi`; ");
            }
            else if (S.GetUseracces() == "4")//packer
            {
                txtaktivitas = await A.GetStringValues("SET @id='" + S.GetUserid() + "'; " +
                   @"SELECT CONCAT(
                    'Keterangan aktivitas yang di kerjakan oleh ',
                    (SELECT CONCAT(`nama`, ' ', `jabatan`, ' ', `noadmin`) FROM `m_user` WHERE `id_user`= @ID),

                    IFNULL(CONCAT('\n\nPRODUK MASUK\n~~~~~~~~~~~~\n', (SELECT GROUP_CONCAT(a SEPARATOR '\n') FROM(SELECT
                    CONCAT(`nama_series`, '\t Harian : ',
                    SUM(IF(`tglbeli` LIKE DATE_FORMAT(NOW(), '%Y-%m-%d%'),`qty`, 0)), ' / Bulanan : ',
                    SUM(IF(`tglbeli` LIKE DATE_FORMAT(NOW(), '%Y-%m%'),`qty`, 0)), ' / Tahunan : ',
                    SUM(IF(`tglbeli` LIKE DATE_FORMAT(NOW(), '%Y%'),`qty`, 0)), ' / Semua : ',
                    SUM(`qty`), ' ') a
                    FROM
                    `t_pembelian` `PB` LEFT JOIN `f_beli` `B` ON `B`.`kode_fakturbeli`=`PB`.`kode_fakturbeli`
                    LEFT JOIN `r_series` `SR` ON `SR`.`id_series`=`PB`.`id_series`
                    GROUP BY `PB`.`id_series`
                    ORDER BY `tglbeli` DESC
                    LIMIT 5) temp)), '-'),

                    IFNULL(CONCAT('\n\nPRODUK KELUAR\n~~~~~~~~~~~~~\n', (SELECT GROUP_CONCAT(a SEPARATOR '\n') FROM(SELECT
                    CONCAT(`nama_series`, '\t Harian : ',
                    SUM(IF(`tgljual` LIKE DATE_FORMAT(NOW(), '%Y-%m-%d%'),`qty`, 0)), ' / Bulanan : ',
                    SUM(IF(`tgljual` LIKE DATE_FORMAT(NOW(), '%Y-%m%'),`qty`, 0)), ' / Tahunan : ',
                    SUM(IF(`tgljual` LIKE DATE_FORMAT(NOW(), '%Y%'),`qty`, 0)), ' / Semua : ',
                    SUM(`qty`), ' ') a
                    FROM
                    `t_penjualan` `PJ` LEFT JOIN `f_jual` `J` ON `J`.`kode_fakturjual`=`PJ`.`kode_fakturjual`
                    LEFT JOIN `r_series` `SR` ON `SR`.`id_series`=`PJ`.`id_series`
                    GROUP BY `PJ`.`id_series`
                    ORDER BY `tgljual` DESC
                    LIMIT 5) temp)), '-'),

                    '\n\nSISA STOCK SERIES\n~~~~~~~~~~~~~~~~~\n',
                    IFNULL((SELECT GROUP_CONCAT(`nama_series`, ' :\t ', `beli`-`jual`, ' produk' SEPARATOR '\n') `stock` FROM(SELECT `id_series`, SUM(`qty`) `beli` FROM `t_pembelian` GROUP BY `id_series`) `B`
                    LEFT JOIN(SELECT `id_series`, SUM(`qty`) `jual` FROM `t_penjualan` GROUP BY `id_series`) `J` ON `J`.`id_series`=`B`.`id_series`
                    LEFT  JOIN `r_series` `SR` ON `SR`.`id_series`=`B`.`id_series` 
                    WHERE `hapus`= 'N' AND `aktif`= 'Y'
                    ORDER BY `tgl_series` DESC),'-'),

                    IFNULL((SELECT
                    CONCAT(
                    '\n\nSEMUA TO\n~~~~~~~~\n',
                    'Harian ', SUM(IF(`jual`= 'Y' AND `cancel`= 'N' AND `tglorder` LIKE DATE_FORMAT(NOW(), '%Y-%m-%d%'), 1, 0)), ' order / ',
                    SUM(IF(`jual`= 'Y' AND `cancel`= 'N' AND `tglorder` LIKE DATE_FORMAT(NOW(), '%Y-%m-%d%'), `qty`, 0)), ' produk\nBulanan ',
                    SUM(IF(`jual`= 'Y' AND `cancel`= 'N' AND `tglorder` LIKE DATE_FORMAT(NOW(), '%Y-%m%'), 1, 0)), ' order / ',
                    SUM(IF(`jual`= 'Y' AND `cancel`= 'N' AND `tglorder` LIKE DATE_FORMAT(NOW(), '%Y-%m%'), `qty`, 0)), ' produk\nTahunan ',
                    SUM(IF(`jual`= 'Y' AND `cancel`= 'N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', 
                    SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ',
                    SUM(IF(`jual`='Y' AND `cancel`='N',1,0)),' order / ', 
                    SUM(IF(`jual`='Y' AND `cancel`='N',`qty`,0)),' produk',

                    '\n\nSEMUA KIRIM\n~~~~~~~~~~~\n',
                    'Harian ',SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', 
                    SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ',
                    SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', 
                    SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ',
                    SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', 
                    SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ',
                    SUM(IF(`kirim`='Y' AND `cancel`='N',1,0)),' order / ', 
                    SUM(IF(`kirim`='Y' AND `cancel`='N',`qty`,0)),' produk',

                    '\n\nTRANSFER BELUM TERKIRIM\n~~~~~~~~~~~~~~~~~~~~~~~\n',
                    'Harian ',SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', 
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ',
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', 
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ',
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', 
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ',
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N',1,0)),' order / ', 
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N',`qty`,0)),' produk'

                    ) aktivitas
                    FROM `f_order` `O` 
                    LEFT JOIN (SELECT `kode_fakturorder`, SUM(`qty`) `qty` FROM `t_orderitems` GROUP BY `kode_fakturorder`) `OI` ON `OI`.`kode_fakturorder`=`O`.`kode_fakturorder`
                    WHERE `expireorder`='N'),'-')

                    ) AS `deskripsi`;");
            }
            else if (S.GetUseracces() == "5")//cs
            {
                txtaktivitas = await A.GetStringValues("SET @id='" + S.GetUserid() + "'; SELECT CONCAT( 'Keterangan aktivitas yang di kerjakan oleh ', " +
                    "(SELECT CONCAT(`nama`, ' ', `jabatan`,' ', `noadmin`) FROM `m_user` WHERE `id_user`=@ID), '\n\nOPEN ORDER\n~~~~~~~~~~~\n', " +
                    "IFNULL((SELECT GROUP_CONCAT(`openorder`, '\t ', `input`,' input, ', `ubah`,' ubah, ', `jual`, ' to, ', `paket`, ' paket, ', `kirim`,' kirim' SEPARATOR '\n') `prosespo` " +
                    "FROM (SELECT `openorder`, SUM(IF(`id_input`<>0,1,0)) `input`, SUM(IF(`id_ubah`<>0,1,0)) `ubah`, SUM(IF(`id_jual`<>0,1,0)) `jual`, SUM(IF(`id_paket`<>0,1,0)) `paket`, " +
                    "SUM(IF(`id_kirim`<>0,1,0)) `kirim` FROM `f_order` WHERE `tglorder`>='2018-06-01 00:00:00' AND `openorder` IS NOT NULL AND `openorder`<>'' GROUP BY `openorder` " +
                    "ORDER BY `tglorder` DESC LIMIT 5 ) AS tmp),'-'), IFNULL((SELECT CONCAT( '\n\nSEMUA JENIS ORDER\n~~~~~~~~~~~~~~~~~\n', 'LINE Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' " +
                    "AND `jenisorder`='LINE' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'LINE Bulanan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' " +
                    "AND `jenisorder`='LINE' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'LINE Tahunan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='LINE' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', 'WEB Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='WEB' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'WEB Bulanan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='WEB' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'WEB Tahunan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='WEB' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', 'GIVEAWAY Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='GIVEAWAY' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'GIVEAWAY Bulanan\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='GIVEAWAY' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'GIVEAWAY Tahunan\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='GIVEAWAY' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', 'RETUR Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='RETUR' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'RETUR Bulanan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='RETUR' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'RETUR Tahunan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='RETUR' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', 'OTHER Harian\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='OTHER' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order\n', 'OTHER Bulanan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='OTHER' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order\n', 'OTHER Tahunan\t\t',SUM(IF(`cancel`='N' AND `transfer`='Y' AND `jenisorder`='OTHER' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order\n', '\nSEMUA INPUT\n~~~~~~~~~~~\n', 'Harian ',SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', " +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', " +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', " +
                    "SUM(IF(`tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', COUNT(*),' order / ', SUM(`qty`),' produk', '\n\nSEMUA BATAL\n~~~~~~~~~~~\n', 'Harian '," +
                    "SUM(IF(`cancel`='Y' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`cancel`='Y' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', SUM(IF(`cancel`='Y' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', " +
                    "SUM(IF(`cancel`='Y' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`cancel`='Y' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', SUM(IF(`cancel`='Y' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', " +
                    "SUM(IF(`cancel`='Y',1,0)),' order / ', SUM(IF(`cancel`='Y',`qty`,0)),' produk', '\n\nSEMUA TRANSFER\n~~~~~~~~~~~~~~\n', 'Harian ',SUM(IF(`transfer`='Y' AND `cancel`='N' " +
                    "AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', " +
                    "SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', SUM(IF(`transfer`='Y' AND `cancel`='N',1,0)),' order / ', " +
                    "SUM(IF(`transfer`='Y' AND `cancel`='N',`qty`,0)),' produk', '\n\nSEMUA TO\n~~~~~~~~\n', 'Harian ',SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', " +
                    "SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', " +
                    "SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', SUM(IF(`jual`='Y' AND `cancel`='N',1,0)),' order / ', " +
                    "SUM(IF(`jual`='Y' AND `cancel`='N',`qty`,0)),' produk', '\n\nSEMUA KIRIM\n~~~~~~~~~~~\n', 'Harian ',SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', " +
                    "SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', " +
                    "SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', SUM(IF(`kirim`='Y' AND `cancel`='N',1,0)),' order / ', " +
                    "SUM(IF(`kirim`='Y' AND `cancel`='N',`qty`,0)),' produk', '\n\nTRANSFER BELUM TERKIRIM\n~~~~~~~~~~~~~~~~~~~~~~~\n', 'Harian ',SUM(IF(`transfer`='Y' AND `kirim`='N' " +
                    "AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` " +
                    "LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ', SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N',1,0)),' order / ', SUM(IF(`transfer`='Y' " +
                    "AND `kirim`='N' AND `cancel`='N',`qty`,0)),' produk' ) aktivitas FROM `f_order` `O` LEFT JOIN (SELECT `kode_fakturorder`, SUM(`qty`) `qty` FROM `t_orderitems` " +
                    "GROUP BY `kode_fakturorder`) `OI` ON `OI`.`kode_fakturorder`=`O`.`kode_fakturorder` WHERE `expireorder`='N'),'-'), " +
                    "IFNULL((SELECT CONCAT( '\n\nKOMPLAIN DIPROSES CS\n~~~~~~~~~~~~~~~~~~~\n', 'Harian ',SUM(IF(`K`.`id_user`=@ID AND `tglkomplain` " +
                    "LIKE DATE_FORMAT(NOW(), '%Y-%m-%d%'),1,0)),' konsumen\n', 'Bulanan ',SUM(IF(`K`.`id_user`=@ID AND `tglkomplain` " +
                    "LIKE DATE_FORMAT(NOW(), '%Y-%m%'),1,0)),' konsumen\n', 'Tahunan ',SUM(IF(`K`.`id_user`=@ID AND `tglkomplain` LIKE DATE_FORMAT(NOW(), '%Y%'),1,0)),' konsumen\n', 'Semua '," +
                    "SUM(IF(`K`.`id_user`=@ID, 1,0)),' konsumen\n', 'Ditutup ',SUM(IF(`K`.`id_user`=@ID AND `tutup`='Y', 1, 0)),' konsumen\n', 'Komplain Belum Retur ',SUM(IF(`K`.`id_user`=@ID " +
                    "AND `diretur`='Y' AND `tutup` ='N' AND `kode_returkonsumen` IS NULL, 1,0)), '\n\nSEMUA KOMPLAIN\n~~~~~~~~~~~~~~\n', 'Harian ',SUM(IF(`tglkomplain` " +
                    "LIKE DATE_FORMAT(NOW(), '%Y-%m-%d%'),1,0)),' konsumen\n', 'Bulanan ',SUM(IF(`tglkomplain` LIKE DATE_FORMAT(NOW(), '%Y-%m%'),1,0)),' konsumen\n', 'Tahunan '," +
                    "SUM(IF(`tglkomplain` LIKE DATE_FORMAT(NOW(), '%Y%'),1,0)),' konsumen\n', 'Semua ',COUNT(*),' konsumen\n', 'Ditutup '," +
                    "SUM(IF(`tutup`='Y', 1, 0)),' konsumen\n', 'Komplain Belum Retur ',SUM(IF(`diretur`='Y' AND `tutup` ='N' AND `kode_returkonsumen` IS NULL, 1,0)) ) FROM `d_komplain` `K` " +
                    "LEFT JOIN `f_returkonsumen` `R` ON `R`.`id_komplain`=`K`.`id_komplain`),'-'), IFNULL((SELECT CONCAT( '\n\nRETUR DIPROSES CS\n~~~~~~~~~~~~~~~~\n', 'Harian '," +
                    "SUM(IF(`id_user`=@ID AND `tglretur` LIKE DATE_FORMAT(NOW(), '%Y-%m-%d%'),1,0)),' order\n', 'Bulanan ',SUM(IF(`id_user`=@ID AND `tglretur` " +
                    "LIKE DATE_FORMAT(NOW(), '%Y-%m%'),1,0)),' order\n', 'Tahunan ',SUM(IF(`id_user`=@ID AND `tglretur` " +
                    "LIKE DATE_FORMAT(NOW(), '%Y%'),1,0)),' order\n', 'Semua ',IF(`id_user`=@ID,1,0),' order\n', '\nSEMUA RETUR\n~~~~~~~~~~~\n', 'Harian ',SUM(IF(`tglretur` " +
                    "LIKE DATE_FORMAT(NOW(), '%Y-%m-%d%'),1,0)),' order\n', 'Bulanan ',SUM(IF(`tglretur` LIKE DATE_FORMAT(NOW(), '%Y-%m%'),1,0)),' order\n', 'Tahunan '," +
                    "SUM(IF(`tglretur` LIKE DATE_FORMAT(NOW(), '%Y%'),1,0)),' order\n', 'Semua ',COUNT(*),' order\n', '\nJENIS RETUR\n~~~~~~~~~~~\n', 'Retur produk '," +
                    "SUM(IF(`jenisretur`='RETUR PRODUK',1,0)),' retur\n' 'Refund retur ',SUM(IF(`jenisretur`='REFUND RETUR',1,0)),' retur\n' 'Kembali uang (refund) '," +
                    "SUM(IF(`jenisretur`='KEMBALI UANG (REFUND)',1,0)),' retur\n' 'Kembali barang dan uang '," +
                    "SUM(IF(`jenisretur`='KEMBALI BARANG DAN UANG (RETUR&REFUND)',1,0)),' retur\n' 'Simpan uang ',SUM(IF(`jenisretur`='SIMPAN UANG (KEEP)',1,0)),' retur\n' ) " +
                    "FROM `f_returkonsumen`),'-') ) AS `deskripsi`; ");
            }
            else if (S.GetUseracces() == "6")//manager
            {
                txtaktivitas = "I'm Manager!!";
            }
            else if (S.GetUseracces() == "7")//finance
            {
                txtaktivitas = await A.GetStringValues("SET @id='" + S.GetUserid() + "'; " +
                    @"SELECT CONCAT(
                    'Keterangan aktivitas yang di kerjakan oleh ',
                    (SELECT CONCAT(`nama`, ' ', `jabatan`, ' ', `noadmin`) FROM `m_user` WHERE `id_user`= @ID),

                    '\n\nPENJUALAN\n~~~~~~~~~~~~~\n',
                    IFNULL((SELECT GROUP_CONCAT(a SEPARATOR '\n') FROM (SELECT CONCAT(
                    IF(`openorder` ='','Kosong',`openorder`),'\t Total Rp ', 
                    FORMAT(SUM(`total`),0),' / no Rp ',
                    FORMAT(SUM(`nomororder`),0),' / ongkir Rp ',
                    FORMAT(SUM(`ongkir`),0),' / kurang tf Rp ',
                    FORMAT(SUM(`kurangtf`),0)) `a`
                    FROM
                      `f_order`
                      WHERE `transfer`='Y'
                    GROUP BY `openorder`
                    ORDER BY `tglorder` DESC) tmp),'-'),


                    '\n\nSISA STOCK SERIES\n~~~~~~~~~~~~~~~~~\n',
                    IFNULL((SELECT GROUP_CONCAT(`nama_series`, ' :\t ', `beli`-`jual`, ' produk' SEPARATOR '\n') `stock` FROM(SELECT `id_series`, SUM(`qty`) `beli` FROM `t_pembelian` GROUP BY `id_series`) `B`
                    LEFT JOIN(SELECT `id_series`, SUM(`qty`) `jual` FROM `t_penjualan` GROUP BY `id_series`) `J` ON `J`.`id_series`=`B`.`id_series`
                    LEFT  JOIN `r_series` `SR` ON `SR`.`id_series`=`B`.`id_series` 
                    WHERE `hapus`= 'N' AND `aktif`= 'Y'
                    ORDER BY `tgl_series` DESC),'-'),

                    IFNULL((SELECT
                    CONCAT(
                    '\n\nSEMUA TO\n~~~~~~~~\n',
                    'Harian ', SUM(IF(`jual`= 'Y' AND `cancel`= 'N' AND `tglorder` LIKE DATE_FORMAT(NOW(), '%Y-%m-%d%'), 1, 0)), ' order / ',
                    SUM(IF(`jual`= 'Y' AND `cancel`= 'N' AND `tglorder` LIKE DATE_FORMAT(NOW(), '%Y-%m-%d%'), `qty`, 0)), ' produk\nBulanan ',
                    SUM(IF(`jual`= 'Y' AND `cancel`= 'N' AND `tglorder` LIKE DATE_FORMAT(NOW(), '%Y-%m%'), 1, 0)), ' order / ',
                    SUM(IF(`jual`= 'Y' AND `cancel`= 'N' AND `tglorder` LIKE DATE_FORMAT(NOW(), '%Y-%m%'), `qty`, 0)), ' produk\nTahunan ',
                    SUM(IF(`jual`= 'Y' AND `cancel`= 'N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', 
                    SUM(IF(`jual`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ',
                    SUM(IF(`jual`='Y' AND `cancel`='N',1,0)),' order / ', 
                    SUM(IF(`jual`='Y' AND `cancel`='N',`qty`,0)),' produk',

                    '\n\nSEMUA KIRIM\n~~~~~~~~~~~\n',
                    'Harian ',SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', 
                    SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ',
                    SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', 
                    SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ',
                    SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', 
                    SUM(IF(`kirim`='Y' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ',
                    SUM(IF(`kirim`='Y' AND `cancel`='N',1,0)),' order / ', 
                    SUM(IF(`kirim`='Y' AND `cancel`='N',`qty`,0)),' produk',

                    '\n\nTRANSFER BELUM TERKIRIM\n~~~~~~~~~~~~~~~~~~~~~~~\n',
                    'Harian ',SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), 1, 0)),' order / ', 
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m-%d%'), `qty`,0)), ' produk\nBulanan ',
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), 1, 0)),' order / ', 
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y-%m%'), `qty`,0)), ' produk\nTahunan ',
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), 1, 0)),' order / ', 
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N' AND `tglorder` LIKE DATE_FORMAT(NOW(),'%Y%'), `qty`,0)), ' produk\nSemua ',
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N',1,0)),' order / ', 
                    SUM(IF(`transfer`='Y' AND `kirim`='N' AND `cancel`='N',`qty`,0)),' produk'

                    ) aktivitas
                    FROM `f_order` `O` 
                    LEFT JOIN (SELECT `kode_fakturorder`, SUM(`qty`) `qty` FROM `t_orderitems` GROUP BY `kode_fakturorder`) `OI` ON `OI`.`kode_fakturorder`=`O`.`kode_fakturorder`
                    WHERE `expireorder`='N'),'-')

                    ) AS `deskripsi`;");
            }

            A.SetControlPropertyValue(TbAktivitas, "Text", txtaktivitas);
        }
        private void ActivatedForm(object sender, EventArgs e)
        {
            GetCallActivity();
            //code
            TbInfo.LoadNote(false);
            TbCatatan.LoadNote();

        }
        private void LoadForm(object sender, EventArgs e)
        {
            //code
            if (!A.SetKertasStiker(Properties.Settings.Default.selectstiker))
            {
                AutoClosingMessageBox.Show("Kertas Stiker Belum Di-Setting!!", "Peringatan", 2000);
            }
            Cursor.Current = Cursors.WaitCursor;
            if (S.GetUseracces() == "1")//super admin
            {
                BInventory.Visible = true;
                BSales.Visible = true;
                BWebSale.Visible = true;
                BFinance.Visible = true;
                BCostumerService.Visible = true;
                BMaster.Visible = true;
                BSettings.Visible = true;
                A.ExpireUpdate();
            }
            else if (S.GetUseracces()=="2")//admin chat
            {}
            else if (S.GetUseracces() == "3")//admin kkomputer
            {
                BSales.Visible = true;
                BWebSale.Visible = true;
                BMaster.Visible = true;
                BSettings.Visible = true;
                A.ExpireUpdate();
            }
            else if (S.GetUseracces() == "4")//packer
            {
                BInventory.Visible = true;
                BMaster.Visible = true;
                BSettings.Visible = true;
            }
            else if (S.GetUseracces() == "5")//cs
            {
                BInventory.Visible = true;
                BSales.Visible = true;
                BCostumerService.Visible = true;
                BSettings.Visible = true;
                A.SelesaiUpdate();
            }
            else if (S.GetUseracces() == "6")//manager
            {
                BInventory.Visible = true;
                BSales.Visible = true;
                BWebSale.Visible = true;
                BFinance.Visible = true;
                BCostumerService.Visible = true;
                BSettings.Visible = true;
            }
            else if (S.GetUseracces() == "7")//finance
            {
                BSales.Visible = true;
                BFinance.Visible = true;
                BSettings.Visible = true;
            }

            if (!LoadData.InitializeAll())
            {
                MessageBox.Show("Data tidak dapat di muat seluruhnya!!, Aplikasi akan menutup otomatis!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            Cursor.Current = Cursors.Default;
        }
        // ============================== InitializeComponent ==============================
        #endregion
        #region Point Of Sale
        // ============================== Point Of Sale ==============================
        private void BPOrder_Click(object sender, EventArgs e)
        {
            //code
            Modul_POS.FInputOrder f = new Modul_POS.FInputOrder();
            f.Show();
        }
        private void BPUbahOrder_Click(object sender, EventArgs e)
        {
            //code
            Modul_POS.FPerbaikanOrder f = new Modul_POS.FPerbaikanOrder();
            f.Show();
        }
        private void BPTransaksiKeluar_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FTransaksiKeluar f = new Modul_Inventory.FTransaksiKeluar();
            f.Show();
        }
        private void BPVerifikasiPaket_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FTransaksiTerpaket f = new Modul_Inventory.FTransaksiTerpaket();
            f.Show();
        }
        private void BPVerifikasiTerkirim_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FTransaksiTerkirim f = new Modul_Inventory.FTransaksiTerkirim();
            f.Show();
        }
        private void BPOrderGiveaway_Click(object sender, EventArgs e)
        {
            //code
            Modul_POS.FInputOrder f = new Modul_POS.FInputOrder("GIVEAWAY");
            f.Show();
        }
        private void BPOrderOther_Click(object sender, EventArgs e)
        {
            //code
            Modul_POS.FInputOrder f = new Modul_POS.FInputOrder("OTHER");
            f.Show();
        }
        // ============================== Point Of Sale ==============================
        #endregion
        #region Inventory
        // ============================== Inventory ==============================
        private void BITransaksiKeluar_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FTransaksiKeluar f = new Modul_Inventory.FTransaksiKeluar();
            f.Show();
        }
        private void BITransaksiMasuk_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FTransaksiMasuk f = new Modul_Inventory.FTransaksiMasuk();
            f.Show();
        }
        private void BIOpname_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FTransaksiOpname f = new Modul_Inventory.FTransaksiOpname();
            f.Show();
        }
        private void BIReturProdusen_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FTransaksiReturProdusen f = new Modul_Inventory.FTransaksiReturProdusen();
            f.Show();
        }
        
        private void BIUbahTransaksiMasuk_Click(object sender, EventArgs e)
        {
            Modul_Inventory.FListTransaksiMasuk f = new Modul_Inventory.FListTransaksiMasuk();
            f.Show();
        }

        private void BIDataOpname_Click(object sender, EventArgs e)
        {
            Modul_Inventory.FDataOpname f = new Modul_Inventory.FDataOpname();
            f.Show();
        }

        private void BIDataReturProdusen_Click(object sender, EventArgs e)
        {
            Modul_Inventory.FDataReturProdusen f = new Modul_Inventory.FDataReturProdusen();
            f.Show();
        }
        // ============================== Inventory ==============================
        #endregion
        #region Sales
        // ============================== Sales ==============================
        private void BSCekTransfer_Click(object sender, EventArgs e)
        {
            //code
            Modul_Sales.FCekTransfer f = new Modul_Sales.FCekTransfer();
            f.Show();
        }
        private void BSSettingHarga_Click(object sender, EventArgs e)
        {
            //code
            Modul_Sales.FSettingsHarga F = new Modul_Sales.FSettingsHarga();
            F.Show();
        }
        private void BSInfoAdmin_Click(object sender, EventArgs e)
        {
            //code
            RichTextBox tb = new RichTextBox();
            tb.LoadNote(false);
            string values = tb.Text;
            if (A.InputRichTextBox("Catatan", "Catatan", ref values) == DialogResult.OK)
            {
                tb.Text = values;
                tb.SaveNote(false);
                AutoClosingMessageBox.Show("Informasi untuk seluruh admin telah tersimpan!!", "Informasi", 2000);
            }
        }
        private void BSPermintaanProduk_Click(object sender, EventArgs e)
        {
            //code
            Modul_Sales.FPermintaanProduk f = new Modul_Sales.FPermintaanProduk();
            f.Show();
        }
        private void BSExpireUpdate_Click(object sender, EventArgs e)
        {
            //code
            if (MessageBox.Show("Update Order yang telah lewat transfer?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                A.BatalUpdate();
            }
        }
        private void BPWaitingList_Click(object sender, EventArgs e)
        {
            Modul_Sales.FLWaitingList f = new Modul_Sales.FLWaitingList();
            f.Show();
        }
        private void BSHPindahProduk_Click(object sender, EventArgs e)
        {
            Modul_Sales.FHistoryPindahProduk f = new Modul_Sales.FHistoryPindahProduk();
            f.Show();
        }
        private void BSHUbahOrder_Click(object sender, EventArgs e)
        {
            Auxs.FHistoryUbahOrder f = new Auxs.FHistoryUbahOrder();
            f.Show();
        }

        // ============================== Sales ==============================
        #endregion
        #region Web
        // ============================== Web ==============================
        private void BWCekTransferWeb_Click(object sender, EventArgs e)
        {
            //code
            Modul_Sales.FCekTransferWeb f = new Modul_Sales.FCekTransferWeb();
            f.Show();
        }
        private void BWProdukCode_Click(object sender, EventArgs e)
        {
            //code
            Modul_Sales.FProdukKodeGenerator f = new Modul_Sales.FProdukKodeGenerator();
            f.Show();
        }
        private void BWImport_Click(object sender, EventArgs e)
        {
            //code
            Modul_POS.FInputOrderWeb f = new Modul_POS.FInputOrderWeb();
            f.Show();
        }
        private void BWExport_Click(object sender, EventArgs e)
        {
            //code
            Modul_Sales.FOutputOrderWeb f = new Modul_Sales.FOutputOrderWeb();
            f.Show();
        }
        // ============================== Web ==============================
        #endregion
        #region Finance
        // ============================== Finance ==============================
        private void BFOrder_Click(object sender, EventArgs e)
        {
            //code
            Modul_POS.FInputOrder f = new Modul_POS.FInputOrder("OTHER");
            f.Show();
        }
        private void BFSettingHarga_Click(object sender, EventArgs e)
        {
            //code
            Modul_Finansial.FHarga f = new Modul_Finansial.FHarga();
            f.Show();
        }
        private void BFKalkulasiData_Click(object sender, EventArgs e)
        {
            //code
            Modul_Finansial.FDataKalkulasi f = new Modul_Finansial.FDataKalkulasi();
            f.Show();
        }
        private void BFPendapatan_Click(object sender, EventArgs e)
        {
            //code
            Modul_Finansial.FPendapatan f = new Modul_Finansial.FPendapatan();
            f.ShowDialog();
        }
        private void BFBukuKas_Click(object sender, EventArgs e)
        {
            Modul_Finansial.FBukuKas f = new Modul_Finansial.FBukuKas();
            f.Show();
        }
        // ============================== Finance ==============================
        #endregion
        #region  Costumer Service
        // ============================== Costumer Service ==============================       
        private void BCKomplain_Click(object sender, EventArgs e)
        {
            //code
            Modul_Invoice.FKomplain f = new Modul_Invoice.FKomplain();
            f.Show();
        }
        private void BCReturKonsumen_Click(object sender, EventArgs e)
        {
            //code
            Modul_Invoice.FRetur F = new Modul_Invoice.FRetur();
            F.Show();
        }
        private void BCStatusPengiriman_Click(object sender, EventArgs e)
        {
            //code
            Modul_Invoice.FStatusPengiriman F = new Modul_Invoice.FStatusPengiriman();
            F.Show();
        }
        private void BCSettingHarga_Click(object sender, EventArgs e)
        {
            //code
            Modul_Sales.FSettingsHarga F = new Modul_Sales.FSettingsHarga();
            F.Show();
        }
        private void BCRefund_Click(object sender, EventArgs e)
        {
            //code
            Modul_Invoice.FRefund f = new Modul_Invoice.FRefund();
            f.Show();
        }
        private void BCKeep_Click(object sender, EventArgs e)
        {
            //code
            Modul_Invoice.FKeep f = new Modul_Invoice.FKeep();
            f.Show();
        }
        private void BCVoucher_Click(object sender, EventArgs e)
        {
            //code
            Modul_Invoice.FVoucher f = new Modul_Invoice.FVoucher();
            f.Show();
        }
        private void BCUpdateJNEResi_Click(object sender, EventArgs e)
        {
            Modul_Invoice.FImportJNE f = new Modul_Invoice.FImportJNE();
            f.Show();
        }
        // ============================== Costumer Service ==============================
        #endregion
        #region Public Acces
        // ============================== Public Acces ==============================
        private void BPDataPengiriman_Click(object sender, EventArgs e)
        {
            //code
            Modul_Sales.FDataPengiriman f = new Modul_Sales.FDataPengiriman();
            f.Show();
        }
        private void BPDataOrder_Click(object sender, EventArgs e)
        {
            //code
            Modul_Sales.FDataOrder f = new Modul_Sales.FDataOrder();
            f.Show();
        }
        private void BPDataFavorit_Click(object sender, EventArgs e)
        {
            //code
            Modul_Sales.FDataFavorit f = new Modul_Sales.FDataFavorit();
            f.Show();
        }
        private void BPDefaultPrinter_Click(object sender, EventArgs e)
        {
            //code
            FSelectDefaultPrinter f = new FSelectDefaultPrinter();
            f.ShowDialog();
        }
        private void BPDataProcessing_Click(object sender, EventArgs e)
        {
            //code
            Modul_Sales.FLProcessing f = new Modul_Sales.FLProcessing();
            f.Show();
        }
        private void BPPerkiraanOpenOrder_Click(object sender, EventArgs e)
        {
            Modul_Sales.FOrderPacking f = new Modul_Sales.FOrderPacking();
            f.Show();
        }
        private void BPDataProduk_Click(object sender, EventArgs e)
        {
            Modul_Sales.FDataProduk f = new Modul_Sales.FDataProduk();
            f.Show();
        }
        private void BPKetersediaanProduk_Click(object sender, EventArgs e)
        {
            Modul_Sales.FDataKetersediaanProduk f = new Modul_Sales.FDataKetersediaanProduk();
            f.Show();
        }
        private void BPDataSlip_Click(object sender, EventArgs e)
        {
            Modul_Sales.FDataSlip f = new Modul_Sales.FDataSlip();
            f.Show();
        }
        private void BPUpdatePackingHarian_Click(object sender, EventArgs e)
        {
            Auxs.FUpdatePackingHarian f = new Auxs.FUpdatePackingHarian();
            f.Show();
        }
        // ============================== Public Acces ==============================
        #endregion
        #region Laporan
        // ============================== Laporan ==============================
        private void BRStock_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FLStock f = new Modul_Inventory.FLStock();
            f.Show();
        }
        private void BRPerwaktu_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FLPerWaktu F = new Modul_Inventory.FLPerWaktu();
            F.Show();
        }
        private void BRPengiriman_Click(object sender, EventArgs e)
        {
            //code
            Modul_Sales.FLPengiriman f = new Modul_Sales.FLPengiriman();
            f.Show();
        }
        private void BRDetailTransaksi_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FLDetailTransaksi f = new Modul_Inventory.FLDetailTransaksi();
            f.Show();
        }
        private void BRKomplain_Click(object sender, EventArgs e)
        {
            //code
            Modul_Invoice.FLKomplain f = new Modul_Invoice.FLKomplain();
            f.Show();
        }
        private void BRRetur_Click(object sender, EventArgs e)
        {
            //code
            Modul_Invoice.FLReturKonsumen f = new Modul_Invoice.FLReturKonsumen();
            f.Show();
        }
        private void BRTransaksi_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FLTransaksi f = new Modul_Inventory.FLTransaksi();
            f.Show();
        }
        private void BRPenjualan_Click(object sender, EventArgs e)
        {
            //code
            Modul_Sales.FLPenjualan f = new Modul_Sales.FLPenjualan();
            f.Show();
        }
        private void BRKekurangan_Click(object sender, EventArgs e)
        {
            Modul_Inventory.FLKekurangan f = new Modul_Inventory.FLKekurangan();
            f.Show();
        }
        private void BRPengirimanOrder_Click(object sender, EventArgs e)
        {
            Modul_Sales.FLPengirimanOrder f = new Modul_Sales.FLPengirimanOrder();
            f.Show();
        }
        private void BRPickup_Click(object sender, EventArgs e)
        {
            Modul_Sales.FLPickup f = new Modul_Sales.FLPickup();
            f.Show();
        }
        // ============================== Laporan ==============================
        #endregion
        #region Master
        // ============================== Master ==============================
        private void BMBrand_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FMasterBrand f = new Modul_Inventory.FMasterBrand();
            f.Show();
        }
        private void BMKategori_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FMasterKategori f = new Modul_Inventory.FMasterKategori();
            f.Show();
        }
        private void BMProduk_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FMasterProduk f = new Modul_Inventory.FMasterProduk();
            f.Show();
        }
        private void BMSize_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FMasterSize f = new Modul_Inventory.FMasterSize();
            f.Show();
        }
        private void BMWarna_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FMasterWarna f = new Modul_Inventory.FMasterWarna();
            f.Show();
        }
        private void BMSeries_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FMasterSeries f = new Modul_Inventory.FMasterSeries();
            f.Show();
        }
        private void BMSupplier_Click(object sender, EventArgs e)
        {
            //code
            Modul_Inventory.FMasterSupplier f = new Modul_Inventory.FMasterSupplier();
            f.Show();
        }
        // ============================== Master ==============================
        #endregion
        #region Pengaturan
        // ============================== Pengaturan ==============================
        private void BSTAplikasi_Click(object sender, EventArgs e)
        {
            //code
            FSettingApps f = new FSettingApps();
            f.Show();
        }
        private void BSTDatabase_Click(object sender, EventArgs e)
        {
            //code
            FSettingDb f = new FSettingDb();
            f.Show();
        }
        private void BSTLabel_Click(object sender, EventArgs e)
        {
            //code
            FSettingLabel f = new FSettingLabel();
            f.Show();
        }
        private void BSTStiker_Click(object sender, EventArgs e)
        {
            //code
            FSettingStiker f = new FSettingStiker();
            f.Show();
        }
        private void BSTTentang_Click(object sender, EventArgs e)
        {
            //code
            FTentang f = new FTentang();
            f.Show();
        }
        // ============================== Pengaturan ==============================
        #endregion
        #region User
        // ============================== User ==============================
        private void BUser_Click(object sender, EventArgs e)
        {
            //code
            Modul_HRD.FUser f = new Modul_HRD.FUser();
            f.Show();
        }
        private void BLogout_Click(object sender, EventArgs e)
        {
            A.SetLogout();
            DialogResult =DialogResult.OK;
        }
        // ============================== User ==============================
        #endregion
        private void BFKategoriBukuKas_Click(object sender, EventArgs e)
        {
            Modul_Finansial.FKategoriBukuKas f = new Modul_Finansial.FKategoriBukuKas();
            f.Show();
        }
        private void BFTransaksi_Click(object sender, EventArgs e)
        {
            Modul_Finansial.FTransaksi f = new Modul_Finansial.FTransaksi();
            f.Show();
        }
        private void BFUtang_Click(object sender, EventArgs e)
        {
            Modul_Finansial.FUtang f = new Modul_Finansial.FUtang();
            f.Show();
        }
        private void BITransferStockSeries_Click(object sender, EventArgs e)
        {
            Modul_Inventory.FTransferStockSeries f = new Modul_Inventory.FTransferStockSeries();
            f.Show();
        }
        private void BIDataTransferStockSeries_Click(object sender, EventArgs e)
        {
            Modul_Inventory.FDataTransferStockSeries f = new Modul_Inventory.FDataTransferStockSeries();
            f.Show();
        }
        private void BPDataInputOrder_Click(object sender, EventArgs e)
        {
            FOpenOrder f = new FOpenOrder();
            f.Show();
        }
    }
}
