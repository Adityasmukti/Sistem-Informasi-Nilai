using System;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS
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
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            //code
        }
        private void ActivatedForm(object sender, EventArgs e)
        {
            //code
            TbInfo.LoadNote(false);
            TbCatatan.LoadNote();

        }
        private void LoadForm(object sender, EventArgs e)
        {
            //code
          
            Cursor.Current = Cursors.WaitCursor;
            if (S.GetUseracces() == "1")//super admin
            {
                BSales.Visible = true;
                BWebSale.Visible = true;
                BFinance.Visible = true;
                BCostumerService.Visible = true;
                BMaster.Visible = true;
                BSettings.Visible = true;
            }
            else if (S.GetUseracces()=="2")//admin chat
            {}
            else if (S.GetUseracces() == "3")//admin kkomputer
            {
                BSales.Visible = true;
                BWebSale.Visible = true;
                BMaster.Visible = true;
                BSettings.Visible = true;
            }
            else if (S.GetUseracces() == "4")//packer
            {
                BMaster.Visible = true;
                BSettings.Visible = true;
            }
            else if (S.GetUseracces() == "5")//cs
            {
                BSales.Visible = true;
                BCostumerService.Visible = true;
                BSettings.Visible = true;
            }
            else if (S.GetUseracces() == "6")//manager
            {
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
        #region Sales
        // ============================== Sales ==============================
        private void BSCekTransfer_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BSSettingHarga_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BSInfoAdmin_Click(object sender, EventArgs e)
        {
            //code
           
        }
        private void BSPermintaanProduk_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BSExpireUpdate_Click(object sender, EventArgs e)
        {
            //code
           
        }
        private void BPWaitingList_Click(object sender, EventArgs e)
        {
        }
        private void BSHPindahProduk_Click(object sender, EventArgs e)
        {
        }
        private void BSHUbahOrder_Click(object sender, EventArgs e)
        {
        }

        // ============================== Sales ==============================
        #endregion
        #region Web
        // ============================== Web ==============================
        private void BWCekTransferWeb_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BWProdukCode_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BWImport_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BWExport_Click(object sender, EventArgs e)
        {
            //code
        }
        // ============================== Web ==============================
        #endregion
        #region Finance
        // ============================== Finance ==============================
        private void BFOrder_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BFSettingHarga_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BFKalkulasiData_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BFPendapatan_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BFBukuKas_Click(object sender, EventArgs e)
        {
        }
        // ============================== Finance ==============================
        #endregion
        #region  Costumer Service
        // ============================== Costumer Service ==============================       
        private void BCKomplain_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BCReturKonsumen_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BCStatusPengiriman_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BCSettingHarga_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BCRefund_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BCKeep_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BCVoucher_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BCUpdateJNEResi_Click(object sender, EventArgs e)
        {
        }
        // ============================== Costumer Service ==============================
        #endregion
        #region Public Acces
        // ============================== Public Acces ==============================
        private void BPDataPengiriman_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BPDataOrder_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BPDataFavorit_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BPDefaultPrinter_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BPDataProcessing_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BPPerkiraanOpenOrder_Click(object sender, EventArgs e)
        {
        }
        private void BPDataProduk_Click(object sender, EventArgs e)
        {
        }
        private void BPKetersediaanProduk_Click(object sender, EventArgs e)
        {
        }
        private void BPDataSlip_Click(object sender, EventArgs e)
        {
        }
        private void BPUpdatePackingHarian_Click(object sender, EventArgs e)
        {
        }
        // ============================== Public Acces ==============================
        #endregion
        #region Laporan
        // ============================== Laporan ==============================
        private void BRStock_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BRPerwaktu_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BRPengiriman_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BRDetailTransaksi_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BRKomplain_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BRRetur_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BRTransaksi_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BRPenjualan_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BRKekurangan_Click(object sender, EventArgs e)
        {
        }
        private void BRPengirimanOrder_Click(object sender, EventArgs e)
        {
        }
        private void BRPickup_Click(object sender, EventArgs e)
        {
        }
        // ============================== Laporan ==============================
        #endregion
        #region Master
        // ============================== Master ==============================
        private void BMBrand_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BMKategori_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BMProduk_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BMSize_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BMWarna_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BMSeries_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BMSupplier_Click(object sender, EventArgs e)
        {
            //code
        }
        // ============================== Master ==============================
        #endregion
        #region Pengaturan
        // ============================== Pengaturan ==============================
        private void BSTAplikasi_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BSTDatabase_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BSTLabel_Click(object sender, EventArgs e)
        {
            //code
        }
        private void BSTStiker_Click(object sender, EventArgs e)
        {
            //code
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
        }
        private void BFTransaksi_Click(object sender, EventArgs e)
        {
        }
        private void BFUtang_Click(object sender, EventArgs e)
        {
        }
        private void BITransferStockSeries_Click(object sender, EventArgs e)
        {
        }
        private void BIDataTransferStockSeries_Click(object sender, EventArgs e)
        {
        }
        private void BPDataInputOrder_Click(object sender, EventArgs e)
        {
        }
    }
}
