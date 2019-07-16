using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtensionMethods;

namespace AtelierAngelinaApps.Applications
{
    public partial class FSettingLabel : Form
    {
        private List<string> Pengaturan;
        public FSettingLabel()
        {
            InitializeComponent();
            this.SetControlFrom();
            this.Load += FLoad;
            this.KeyDown += F_KeyDown;
            lbdata.Click += Lbdata_Click;
            BTambah.Click += BTambah_Click;
            BHapus.Click += BHapus_Click;

            TbJumlahKolom.KeyPress += A.OnlyNumberDecimal;
            TbJumlahBaris.KeyPress += A.OnlyNumberDecimal;
            TbPanjangKertas.KeyPress += A.OnlyNumberDecimal;
            TbTinggiKertas.KeyPress += A.OnlyNumberDecimal;
            TbMarginTop.KeyPress += A.OnlyNumberDecimal;
            TbMarginLeft.KeyPress += A.OnlyNumberDecimal;
            TbMarginBottom.KeyPress += A.OnlyNumberDecimal;
            TbMarginRight.KeyPress += A.OnlyNumberDecimal;
            TbPanjangKolom.KeyPress += A.OnlyNumberDecimal;
            TbTinggiBaris.KeyPress += A.OnlyNumberDecimal;
            TbSizeFontBrand.KeyPress += A.OnlyNumberDecimal;
            TbTopBrand.KeyPress += A.OnlyNumberDecimal;
            TbLeftBrand.KeyPress += A.OnlyNumberDecimal;
            TbFontSku.KeyPress += A.OnlyNumberDecimal;
            TbTopSku.KeyPress += A.OnlyNumberDecimal;
            TbLeftSku.KeyPress += A.OnlyNumberDecimal;
            TbPanjangBarcode.KeyPress += A.OnlyNumberDecimal;
            TbTinggiBarcode.KeyPress += A.OnlyNumberDecimal;
            TbTopImageBarcode.KeyPress += A.OnlyNumberDecimal;
            TbLeftImageBarcode.KeyPress += A.OnlyNumberDecimal;
            TbSizeFontBarcode.KeyPress += A.OnlyNumberDecimal;
            TbTopTextBarcode.KeyPress += A.OnlyNumberDecimal;
            TbLeftTextBarcode.KeyPress += A.OnlyNumberDecimal;
        }
        private void FSettingKertas_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void BSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbNamaKertas.Text))
                MessageBox.Show("Nama kertas Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(CbNamaFont.Text))
                MessageBox.Show("Nama font Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbPanjangKertas.Text))
                MessageBox.Show("Panjang Kertas Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTinggiKertas.Text))
                MessageBox.Show("Tinggi Kertas Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbMarginTop.Text))
                MessageBox.Show("Margin Top Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbMarginLeft.Text))
                MessageBox.Show("Margin Left Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbMarginBottom.Text))
                MessageBox.Show("Margin Bottom Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbMarginRight.Text))
                MessageBox.Show("Margin Right Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbJumlahKolom.Text))
                MessageBox.Show("Jumlah Kolom Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbJumlahBaris.Text))
                MessageBox.Show("Jumlah Baris Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbPanjangKolom.Text))
                MessageBox.Show("Panjang Kolom Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTinggiBaris.Text))
                MessageBox.Show("TInggi Baris Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbSizeFontBrand.Text))
                MessageBox.Show("Size Font Brand Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTopBrand.Text))
                MessageBox.Show("Top Brand Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbLeftBrand.Text))
                MessageBox.Show("Left Brand Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbFontSku.Text))
                MessageBox.Show("Size Font SKU Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTopSku.Text))
                MessageBox.Show("Top SKU Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbLeftSku.Text))
                MessageBox.Show("Left SKU Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbPanjangBarcode.Text))
                MessageBox.Show("Panjang BarcodeKosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTinggiBarcode.Text))
                MessageBox.Show("Tinggi Barcode Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTopImageBarcode.Text))
                MessageBox.Show("Top  Image Barcode Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbLeftImageBarcode.Text))
                MessageBox.Show("Left Image Barcode Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbSizeFontBarcode.Text))
                MessageBox.Show("Size Font Text Barcode Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTopTextBarcode.Text))
                MessageBox.Show("Topt Text Barcode  Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbLeftTextBarcode.Text))
                MessageBox.Show("Left Text Barcode Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbWarna.Text))
                MessageBox.Show("Warna Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
            else
            {
                if (BTambah.Text == "BATAL")
                {
                    string kodepengaturan = A.KodePengaturan();
                    A.SetInsert("INSERT INTO `r_pengaturankertas` ( `kertas`, `pengaturan`, `namapengaturan`, `values` ) ");
                    A.SetValues("VALUES ('LABEL','" + kodepengaturan + "','namakertas','" + TbNamaKertas.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','jlhkolom','" + TbJumlahKolom.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','jlhbaris','" + TbJumlahBaris.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','panjangkolom','" + TbPanjangKolom.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','tinggibaris','" + TbTinggiBaris.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','sizefontbrand','" + TbSizeFontBrand.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','sizefontsku','" + TbFontSku.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','sizefontbarcode','" + TbSizeFontBarcode.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','warnabarcode','" + TbWarna.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','panjangbarcode','" + TbPanjangBarcode.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','tinggibarcode','" + TbTinggiBarcode.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','topbrand','" + TbTopBrand.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','leftbrand','" + TbLeftBrand.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','topsku','" + TbTopSku.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','leftsku','" + TbLeftSku.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','topimgbarcode','" + TbTopImageBarcode.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','leftimgbarcode','" + TbLeftImageBarcode.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','topbarcode','" + TbTopTextBarcode.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','leftbarcode','" + TbLeftTextBarcode.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','panjangkertas','" + TbPanjangKertas.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','tinggikertas','" + TbTinggiKertas.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','margintop','" + TbMarginTop.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','marginbottom','" + TbMarginBottom.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','marginleft','" + TbMarginLeft.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','marginright','" + TbMarginRight.Text + "'), " +
                        "('LABEL','" + kodepengaturan + "','namafont','" + CbNamaFont.Text + "')");
                    A.SetQueri(A.GetInsert() + A.GetValues() + ";");
                    if (A.GetQueri().DBCreate())
                    {
                        
                    }
                }
                else
                {
                    if (lbdata.SelectedItems.Count < 1)
                        MessageBox.Show("Pilih Data dahulu!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        A.SetUpdate("UPDATE `r_pengaturankertas` ");
                        A.SetSet("SET `values` = '" + TbNamaKertas.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'namakertas'");
                        A.SetQueri(A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbJumlahKolom.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'jlhkolom'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbJumlahBaris.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'jlhbaris'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbPanjangKolom.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'panjangkolom'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTinggiBaris.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'tinggibaris'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbSizeFontBrand.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'sizefontbrand'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbFontSku.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'sizefontsku'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbSizeFontBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'sizefontbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + CbNamaFont.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'namafont'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbWarna.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'warnabarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbPanjangBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'panjangbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTinggiBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'tinggibarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTopBrand.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'topbrand'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbLeftBrand.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'leftbrand'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTopSku.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'topsku'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbLeftSku.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'leftsku'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTopImageBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'topimgbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbLeftImageBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'leftimgbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTopTextBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'topbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbLeftTextBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'leftbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbPanjangKertas.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'panjangkertas'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTinggiKertas.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'tinggikertas'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbMarginTop.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'margintop'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbMarginBottom.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'marginbottom'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbMarginLeft.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'marginleft'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbMarginRight.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'LABEL' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'marginright'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");

                        if (A.GetQueri().DBUpdate())
                        {
                            
                        }
                    }
                }
                lbdata.Enabled = true;
                BTambah.Text = "Tambah";
                LoadList();
            }
        }
        private void BHapus_Click(object sender, EventArgs e)
        {
            if (lbdata.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Hapus?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    A.SetQueri("DELETE FROM `r_pengaturankertas` WHERE `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "';");
                    A.GetQueri().DBHapus();
                    LoadList();
                }
            }
        }
        private void BTambah_Click(object sender, EventArgs e)
        {
            if (BTambah.Text == "Tambah")
            {
                BHapus.Enabled = false;
                BTambah.Text = "BATAL";
                lbdata.Enabled = false;
                BSimpan.Enabled = true;
                this.ClearControl();
                TbWarna.BackColor = Color.White;
            }
            else
            {
                BHapus.Enabled = true;
                BTambah.Text = "Tambah";
                lbdata.Enabled = true;
            }
            
        }
        private void Lbdata_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbdata.SelectedItems.Count > 0)
                    Loaddb(Pengaturan[lbdata.SelectedIndex]);
            }
            catch (Exception) { }
        }
        private void LoadList()
        {
            A.SetSelect("SELECT `pengaturan`, `values` ");
            A.SetFrom("FROM `r_pengaturankertas` ");
            A.SetWhere("WHERE  `kertas`='LABEL' AND `namapengaturan`='namakertas' ");
            A.SetOrderby("ORDER BY `namapengaturan` ASC ");
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetOrderby() + ";");
            Pengaturan = new List<string>();
            lbdata.Items.Clear();
            foreach (DataRow b in A.GetQueri().GetData().Rows)
            {
                Pengaturan.Add(b["pengaturan"].ToString());
                lbdata.Items.Add(b["values"].ToString());
            }

            if (lbdata.Items.Count < 1)
            {
                BSimpan.Enabled = false;
                BHapus.Enabled = false;
            }
            else
            {
                BSimpan.Enabled = true;
                BHapus.Enabled = true;
            }
        }
        private void FLoad(object sender, EventArgs e)
        {
            CbNamaFont.Items.Clear();
            foreach (FontFamily font in FontFamily.Families)
                if(!string.IsNullOrEmpty(font.Name))
                CbNamaFont.Items.Add(font.Name);
            LoadList();
        }
        private bool Loaddb(string pengaturan)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            A.SetSelect("SELECT `namapengaturan`, `values` ");
            A.SetFrom("FROM `r_pengaturankertas` ");
            A.SetWhere("WHERE `kertas`='LABEL' AND`pengaturan`='" + pengaturan + "' ");
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + ";");
            foreach (DataRow b in A.GetQueri().GetData().Rows)
            {
                data.Add(b["namapengaturan"].ToString(), b["values"].ToString());
            }
            TbNamaKertas.Text = data["namakertas"].ToString();
            CbNamaFont.Text = data["namafont"].ToString();
            TbWarna.Text = data["warnabarcode"].ToString();
            TbWarna.BackColor = data["warnabarcode"].ToString().StringToColor();
            TbJumlahKolom.Text = data["jlhkolom"].ToString();
            TbJumlahBaris.Text = data["jlhbaris"].ToString();

            TbPanjangKertas.Text = data["panjangkertas"].StringToFloat();
            TbTinggiKertas.Text = data["tinggikertas"].StringToFloat();
            TbMarginTop.Text = data["margintop"].StringToFloat();
            TbMarginLeft.Text = data["marginleft"].StringToFloat();
            TbMarginBottom.Text = data["marginbottom"].StringToFloat();
            TbMarginRight.Text = data["marginright"].StringToFloat();
            TbPanjangKolom.Text = data["panjangkolom"].StringToFloat();
            TbTinggiBaris.Text = data["tinggibaris"].StringToFloat();
            TbSizeFontBrand.Text = data["sizefontbrand"].StringToFloat();
            TbTopBrand.Text = data["topbrand"].StringToFloat();
            TbLeftBrand.Text = data["leftbrand"].StringToFloat();
            TbFontSku.Text = data["sizefontsku"].StringToFloat();
            TbTopSku.Text = data["topsku"].StringToFloat();
            TbLeftSku.Text = data["leftsku"].StringToFloat();
            TbPanjangBarcode.Text = data["panjangbarcode"].StringToFloat();
            TbTinggiBarcode.Text = data["tinggibarcode"].StringToFloat();
            TbTopImageBarcode.Text = data["topimgbarcode"].StringToFloat();
            TbLeftImageBarcode.Text = data["leftimgbarcode"].StringToFloat();
            TbSizeFontBarcode.Text = data["sizefontbarcode"].StringToFloat();
            TbTopTextBarcode.Text = data["topbarcode"].StringToFloat();
            TbLeftTextBarcode.Text = data["leftbarcode"].StringToFloat();
            return true;
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
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void BView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbNamaKertas.Text))
                MessageBox.Show("Nama kertas Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(CbNamaFont.Text))
                MessageBox.Show("Nama font Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbPanjangKertas.Text))
                MessageBox.Show("Panjang Kertas Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTinggiKertas.Text))
                MessageBox.Show("Tinggi Kertas Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbMarginTop.Text))
                MessageBox.Show("Margin Top Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbMarginLeft.Text))
                MessageBox.Show("Margin Left Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbMarginBottom.Text))
                MessageBox.Show("Margin Bottom Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbMarginRight.Text))
                MessageBox.Show("Margin Right Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbJumlahKolom.Text))
                MessageBox.Show("Jumlah Kolom Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbJumlahBaris.Text))
                MessageBox.Show("Jumlah Baris Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbPanjangKolom.Text))
                MessageBox.Show("Panjang Kolom Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTinggiBaris.Text))
                MessageBox.Show("TInggi Baris Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbSizeFontBrand.Text))
                MessageBox.Show("Size Font Brand Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTopBrand.Text))
                MessageBox.Show("Top Brand Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbLeftBrand.Text))
                MessageBox.Show("Left Brand Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbFontSku.Text))
                MessageBox.Show("Size Font SKU Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTopSku.Text))
                MessageBox.Show("Top SKU Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbLeftSku.Text))
                MessageBox.Show("Left SKU Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbPanjangBarcode.Text))
                MessageBox.Show("Panjang BarcodeKosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTinggiBarcode.Text))
                MessageBox.Show("Tinggi Barcode Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTopImageBarcode.Text))
                MessageBox.Show("Top  Image Barcode Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbLeftImageBarcode.Text))
                MessageBox.Show("Left Image Barcode Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbSizeFontBarcode.Text))
                MessageBox.Show("Size Font Text Barcode Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbTopTextBarcode.Text))
                MessageBox.Show("Topt Text Barcode  Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbLeftTextBarcode.Text))
                MessageBox.Show("Left Text Barcode Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(TbWarna.Text))
                MessageBox.Show("Warna Kosong!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                A.SettingLabel = new Dictionary<string, string>
                {
                    { "namakertas", TbNamaKertas.Text },
                    { "namafont", CbNamaFont.Text },
                    { "warnabarcode", TbWarna.Text },
                    { "jlhkolom", TbJumlahKolom.Text },
                    { "jlhbaris", TbJumlahBaris.Text },
                    { "panjangkertas", TbPanjangKertas.Text },
                    { "tinggikertas", TbTinggiKertas.Text },
                    { "margintop", TbMarginTop.Text },
                    { "marginleft", TbMarginLeft.Text },
                    { "marginbottom", TbMarginBottom.Text },
                    { "marginright", TbMarginRight.Text },
                    { "panjangkolom", TbPanjangKolom.Text },
                    { "tinggibaris", TbTinggiBaris.Text },
                    { "sizefontbrand", TbSizeFontBrand.Text },
                    { "topbrand", TbTopBrand.Text },
                    { "leftbrand", TbLeftBrand.Text },
                    { "sizefontsku", TbFontSku.Text },
                    { "topsku", TbTopSku.Text },
                    { "leftsku", TbLeftSku.Text },
                    { "panjangbarcode", TbPanjangBarcode.Text },
                    { "tinggibarcode", TbTinggiBarcode.Text },
                    { "topimgbarcode", TbTopImageBarcode.Text },
                    { "leftimgbarcode", TbLeftImageBarcode.Text },
                    { "sizefontbarcode", TbSizeFontBarcode.Text },
                    { "topbarcode", TbTopTextBarcode.Text },
                    { "leftbarcode", TbLeftTextBarcode.Text }
                };

                PrintDocument PDD = new PrintDocument();
                Margins margins = new Margins(A.Getpx(A.SettingLabel["marginleft"].ToFloat()), A.Getpx(A.SettingLabel["marginright"].ToFloat()),
                   A.Getpx(A.SettingLabel["margintop"].ToFloat()), A.Getpx(A.SettingLabel["marginbottom"].ToFloat()));
                PDD.DefaultPageSettings.Margins = margins;
                PDD.DefaultPageSettings.PaperSize = A.CalculatePaperSize(A.SettingLabel["panjangkertas"].ToFloat(), A.SettingLabel["tinggikertas"].ToFloat());
                //PDD.PrintPage += (sender1, e1) => barcode.PrintPageBarcode(brand, sku, sender1, e1);
                PrintPreviewDialog printPreview = new PrintPreviewDialog
                {
                    Document = PDD
                };
                ((Form)printPreview).WindowState = FormWindowState.Maximized;
                printPreview.ShowDialog();
            }
        }
        private void BPilihWarna_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog
            {
                AllowFullOpen = true,
                FullOpen = true
            };
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TbWarna.Text = colorDialog1.Color.ColorToString();
                TbWarna.BackColor = colorDialog1.Color;
            }
        }
    }
}
