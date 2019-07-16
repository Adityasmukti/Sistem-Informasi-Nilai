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
    public partial class FSettingStiker : Form
    {
        private List<string> Pengaturan;
        public FSettingStiker()
        {
            InitializeComponent();
            this.SetControlFrom();
            this.Load += FLoad;
            this.KeyDown += F_KeyDown;
            lbdata.Click += Lbdata_Click;
            BTambah.Click += BTambah_Click;
            BHapus.Click += BHapus_Click;
            BSimpan.Click += BSimpan_Click;
            Pengaturan = new List<string>();
        }
        private void FSettingKertas_FormClosing(object sender, FormClosingEventArgs e)
        {
            //idkertasawal.KertasBarcodeSetting();
        }
        private void BSimpan_Click(object sender, EventArgs e)
        {
            bool adakosong = false;
            foreach(Control c in groupBox2.Controls)
            {
                if (c is TextBox)
                { if (((TextBox)c).Text.Length <= 0)
                        adakosong = true;
                }
                else if(c is ComboBox)
                {
                    if (((ComboBox)c).SelectedIndex < 0)
                        adakosong = true;
                }
            }
            if (adakosong)
                MessageBox.Show("Ada field yang masih kosong!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             else
            {
                if (BTambah.Text == "BATAL")
                {
                    string kodepengaturan = A.KodePengaturan();
                    A.SetInsert("INSERT INTO `r_pengaturankertas` ( `kertas`, `pengaturan`, `namapengaturan`, `values` ) ");
                    A.SetValues("VALUES ('STIKER','" + kodepengaturan + "','namakertas','" + TbNamaKertas.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','namafont','" + CbNamaFont.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','sizefontdepan','" + TbSizeFOntDepan.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','panjangkertas','" + TbPanjangKertas.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','tinggikertas','" + TbTinggiKertas.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','margintop','" + TbMarginTop.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','marginbottom','" + TbMarginBottom.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','marginleft','" + TbMarginLeft.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','marginright','" + TbMarginRight.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','topno','" + TbTopNoOrder.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','leftno','" + TbLeftNoOrder.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','toppengiriman','" + TbTopPengiriman.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','leftpengiriman','" + TbLeftPengiriman.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','topimgbarcode','" + TbTopImageBarcode.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','leftimgbarcode','" + TbLeftImageBarcode.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','toptextbarcode','" + TbTopTextBarcode.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','lefttextbarcode','" + TbLeftTextBarcode.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','topnama','" + TbTopNama.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','leftnama','" + TbLeftNama.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','topalamat','" + TbTopAlamat.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','leftalamat','" + TbLeftAlamat.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','topphone','" + TbTopPhone.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','leftphone','" + TbLeftPhone.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','topinvoice','" + TbTopInvoice.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','leftinvoice','" + TbLeftInvoice.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','sizefontbelakang','" + TbSizeFontBelakang.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','backgroundbarcode','" + TbWarnaBgBarcode.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','foregroundbarcode','" + TbWarnaFGBarcode.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','foregroundtext','" + TbWarnaText.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','panjangimgbarcode','" + TbPanjangBarcode.Text + "'), " +
                        "('STIKER','" + kodepengaturan + "','tinggiimgbarcode','" + TbTinggiBarcode.Text + "') ");
                    A.SetQueri(A.GetInsert() + A.GetValues() + ";");
                    if (A.GetQueri().DBCreate())
                    {
                        Properties.Settings.Default.selectstiker = kodepengaturan;
                        Properties.Settings.Default.Save();
                        A.SetKertasStiker(kodepengaturan);
                    }
                }
                else
                {
                    if (lbdata.SelectedItems.Count <= 0)
                        MessageBox.Show("Pilih Data Dahulu!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        A.SetUpdate("UPDATE `r_pengaturankertas` ");
                        A.SetSet("SET `values` = '" + TbNamaKertas.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'namakertas'");
                        A.SetQueri(A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + CbNamaFont.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'namafont'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbSizeFOntDepan.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'sizefontdepan'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbPanjangKertas.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'panjangkertas'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTinggiKertas.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'tinggikertas'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbMarginTop.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'margintop'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbMarginBottom.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'marginbottom'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbMarginLeft.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'marginleft'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbMarginRight.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'marginright'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTopNoOrder.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'topno'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbLeftNoOrder.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'leftno'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTopPengiriman.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'toppengiriman'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbLeftPengiriman.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'leftpengiriman'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTopImageBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'topimgbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbLeftImageBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'leftimgbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTopTextBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'toptextbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbLeftTextBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'lefttextbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTopNama.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'topnama'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbLeftNama.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'leftnama'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTopAlamat.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'topalamat'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbLeftAlamat.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'leftalamat'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTopPhone.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'topphone'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbLeftPhone.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'leftphone'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTopInvoice.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'topinvoice'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbLeftInvoice.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'leftinvoice'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbSizeFontBelakang.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'sizefontbelakang'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbWarnaBgBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'backgroundbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbWarnaFGBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'foregroundbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbWarnaText.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'foregroundtext'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbPanjangBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'panjangimgbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        A.SetSet("SET `values` = '" + TbTinggiBarcode.Text + "' ");
                        A.SetWhere("WHERE `kertas` = 'STIKER' AND `pengaturan` = '" + Pengaturan[lbdata.SelectedIndex] + "' AND `namapengaturan` = 'tinggiimgbarcode'");
                        A.SetQueri(A.GetQueri() + A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        if (A.GetQueri().DBUpdate())
                        {
                            if (CbDefault.Checked)
                            {
                                Properties.Settings.Default.selectstiker = Pengaturan[lbdata.SelectedIndex];
                                Properties.Settings.Default.Save();
                                A.SetKertasStiker(Pengaturan[lbdata.SelectedIndex]);
                            }
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
            if(lbdata.SelectedItems.Count >0)
            {
                if(MessageBox.Show("Hapus?","Pertanyaan",MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    A.SetQueri("DELETE FROM `r_pengaturankertas` WHERE `pengaturan` = '"+Pengaturan[lbdata.SelectedIndex]+"';");
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
                TbWarnaBgBarcode.BackColor = Color.White;
                TbWarnaFGBarcode.BackColor = Color.White;
                TbWarnaText.BackColor = Color.White;
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
            A.SetWhere("WHERE  `kertas`='STIKER' AND `namapengaturan`='namakertas' ");
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
                if (!string.IsNullOrEmpty(font.Name))
                    CbNamaFont.Items.Add(font.Name);
            LoadList();
        }
        private bool Loaddb(string pengaturan)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            A.SetSelect("SELECT `namapengaturan`, `values` ");
            A.SetFrom("FROM `r_pengaturankertas` ");
            A.SetWhere("WHERE `kertas`='STIKER' AND`pengaturan`='" + pengaturan + "' ");
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + ";");
            foreach (DataRow b in A.GetQueri().GetData().Rows)
            {
                data.Add(b["namapengaturan"].ToString(), b["values"].ToString());
            }
            TbNamaKertas.Text = data["namakertas"].ToString();
            CbNamaFont.Text = data["namafont"].ToString();
            TbWarnaBgBarcode.Text = data["backgroundbarcode"].ToString();
            TbWarnaFGBarcode.Text = data["foregroundbarcode"].ToString();
            TbWarnaText.Text = data["foregroundtext"].ToString();
            TbWarnaBgBarcode.BackColor = data["backgroundbarcode"].StringToColor();
            TbWarnaFGBarcode.BackColor = data["foregroundbarcode"].StringToColor();
            TbWarnaText.BackColor = data["foregroundtext"].StringToColor();

            TbSizeFOntDepan.Text = data["sizefontdepan"].StringToFloat();
            TbPanjangKertas.Text = data["panjangkertas"].StringToFloat();
            TbTinggiKertas.Text = data["tinggikertas"].StringToFloat();
            TbMarginTop.Text = data["margintop"].StringToFloat();
            TbMarginBottom.Text = data["marginbottom"].StringToFloat();
            TbMarginLeft.Text = data["marginleft"].StringToFloat();
            TbMarginRight.Text = data["marginright"].StringToFloat();
            TbTopNoOrder.Text = data["topno"].StringToFloat();
            TbLeftNoOrder.Text = data["leftno"].StringToFloat();
            TbTopPengiriman.Text = data["toppengiriman"].StringToFloat();
            TbLeftPengiriman.Text = data["leftpengiriman"].StringToFloat();
            TbTopImageBarcode.Text = data["topimgbarcode"].StringToFloat();
            TbLeftImageBarcode.Text = data["leftimgbarcode"].StringToFloat();
            TbTopTextBarcode.Text = data["toptextbarcode"].StringToFloat();
            TbLeftTextBarcode.Text = data["lefttextbarcode"].StringToFloat();
            TbTopNama.Text = data["topnama"].StringToFloat();
            TbLeftNama.Text = data["leftnama"].StringToFloat();
            TbTopAlamat.Text = data["topalamat"].StringToFloat();
            TbLeftAlamat.Text = data["leftalamat"].StringToFloat();
            TbTopPhone.Text = data["topphone"].StringToFloat();
            TbLeftPhone.Text = data["leftphone"].StringToFloat();
            TbTopInvoice.Text = data["topinvoice"].StringToFloat();
            TbLeftInvoice.Text = data["leftinvoice"].StringToFloat();
            TbSizeFontBelakang.Text = data["sizefontbelakang"].StringToFloat();
            TbPanjangBarcode.Text = data["panjangimgbarcode"].StringToFloat();
            TbTinggiBarcode.Text = data["tinggiimgbarcode"].StringToFloat();

            if (pengaturan == Properties.Settings.Default.selectstiker)
                CbDefault.Checked = true;
            else
                CbDefault.Checked = false;
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
        private void BBgBarcode_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog
            {
                AllowFullOpen = true,
                FullOpen = true
            };
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TbWarnaBgBarcode.Text = colorDialog1.Color.ColorToString();
                TbWarnaBgBarcode.BackColor = colorDialog1.Color;
            }
        }
        private void TbFgBarcode_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog
            {
                AllowFullOpen = true,
                FullOpen = true
            };
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TbWarnaFGBarcode.Text = colorDialog1.Color.ColorToString();
                TbWarnaFGBarcode.BackColor = colorDialog1.Color;
            }
        }
        private void BWarnaText_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog
            {
                AllowFullOpen = true,
                FullOpen = true
            };
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TbWarnaText.Text = colorDialog1.Color.ColorToString();
                TbWarnaText.BackColor = colorDialog1.Color;
            }
        }
        private void SetSetting()
        {
            A.SettingStiker = new Dictionary<string, string>
            {
                { "namakertas", TbNamaKertas.Text },
                { "namafont", CbNamaFont.Text },
                { "sizefontdepan", TbSizeFOntDepan.Text },
                { "panjangkertas", TbPanjangKertas.Text },
                { "tinggikertas", TbTinggiKertas.Text },
                { "margintop", TbMarginTop.Text },
                { "marginbottom", TbMarginBottom.Text },
                { "marginleft", TbMarginLeft.Text },
                { "marginright", TbMarginRight.Text },
                { "topno", TbTopNoOrder.Text },
                { "leftno", TbLeftNoOrder.Text },
                { "toppengiriman", TbTopPengiriman.Text },
                { "leftpengiriman", TbLeftPengiriman.Text },
                { "topimgbarcode", TbTopImageBarcode.Text },
                { "leftimgbarcode", TbLeftImageBarcode.Text },
                { "toptextbarcode", TbTopTextBarcode.Text },
                { "lefttextbarcode", TbLeftTextBarcode.Text },
                { "topnama", TbTopNama.Text },
                { "leftnama", TbLeftNama.Text },
                { "topalamat", TbTopAlamat.Text },
                { "leftalamat", TbLeftAlamat.Text },
                { "topphone", TbTopPhone.Text },
                { "leftphone", TbLeftPhone.Text },
                { "topinvoice", TbTopInvoice.Text },
                { "leftinvoice", TbLeftInvoice.Text },
                { "sizefontbelakang", TbSizeFontBelakang.Text },
                { "backgroundbarcode", TbWarnaBgBarcode.Text },
                { "foregroundbarcode", TbWarnaFGBarcode.Text },
                { "foregroundtext", TbWarnaText.Text },
                { "panjangimgbarcode", TbPanjangBarcode.Text },
                { "tinggiimgbarcode", TbTinggiBarcode.Text }
            };
        }
        private void BViewDepan_Click(object sender, EventArgs e)
        {
            bool adakosong = false;
            foreach (Control c in groupBox2.Controls)
            {
                if (c is TextBox)
                {
                    if (((TextBox)c).Text.Length <= 0)
                        adakosong = true;
                }
                else if (c is ComboBox)
                {
                    if (((ComboBox)c).SelectedIndex < 0)
                        adakosong = true;
                }
            }
            if (adakosong)
                MessageBox.Show("Ada field yang masih kosong!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SetSetting();
                Dictionary<string, string> data = new Dictionary<string, string>
                {
                    { "barcode", "123456789" },
                    { "nomororder", "01" },
                    { "pengiriman", "Kurir" },
                    { "nama", "Contoh" },
                    { "alamat", "Alamat Saat ini" },
                    { "kontak", "081234567890" },
                    { "produk", "Produk Produk produk" }
                };
                PrintDocument PDD = new PrintDocument();
                Margins margins = new Margins(A.Getpx(A.SettingStiker["marginleft"].ToFloat()), A.Getpx(A.SettingStiker["marginright"].ToFloat()),
                    A.Getpx(A.SettingStiker["margintop"].ToFloat()), A.Getpx(A.SettingStiker["marginbottom"].ToFloat()));
                PDD.DefaultPageSettings.Margins = margins;
                PDD.DefaultPageSettings.PaperSize = A.CalculatePaperSize(A.SettingStiker["panjangkertas"].ToFloat(), A.SettingStiker["tinggikertas"].ToFloat());
                //PDD.PrintPage += (sender1, e1) => data.PrintPageDepan(sender1, e1);
                PrintPreviewDialog printPreview = new PrintPreviewDialog
                {
                    Document = PDD
                };
                ((Form)printPreview).WindowState = FormWindowState.Maximized;
                printPreview.ShowDialog();
            }
        }
        private void BViewBelakang_Click(object sender, EventArgs e)
        {
            bool adakosong = false;
            foreach (Control c in groupBox2.Controls)
            {
                if (c is TextBox)
                {
                    if (((TextBox)c).Text.Length <= 0)
                        adakosong = true;
                }
                else if (c is ComboBox)
                {
                    if (((ComboBox)c).SelectedIndex < 0)
                        adakosong = true;
                }
            }
            if (adakosong)
                MessageBox.Show("Ada field yang masih kosong!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SetSetting();
                PrintDocument PDB = new PrintDocument();
                Margins margins = new Margins(A.Getpx(A.SettingStiker["marginleft"].ToFloat()), A.Getpx(A.SettingStiker["marginright"].ToFloat()),
                       A.Getpx(A.SettingStiker["margintop"].ToFloat()), A.Getpx(A.SettingStiker["marginbottom"].ToFloat()));
                PDB.DefaultPageSettings.Margins = margins;
                PDB.DefaultPageSettings.PaperSize = A.CalculatePaperSize(A.SettingStiker["panjangkertas"].ToFloat(), A.SettingStiker["tinggikertas"].ToFloat());
                string isibelakang = string.Format("Admin by : {0}\n" +
                    "Packing by : {1}\n" +
                    "Tgl OD : {12}\n" +
                    "Tgl TO : {2}\n" +
                    "Tgl PR : {3}\n" +
                    "{4}\n{5}\n{6}\n{7}\n{8}\n{9}\n" +
                    "Produk : {10}\n{11}", "Admin 1", "Packer 1 (Packer)",
                    DateTime.Now.ToString("dd-MM-yyyy HH:mm"), DateTime.Now.ToString("dd-MM-yyyy HH:mm"), "Slip : 10000",
                    "Voucher : 10000", "Keep : 10000", "10000", "Keterangan Diskon", "Keterangan order", "Nama brand", "produk produk", DateTime.Now.ToString("dd-MM-yyyy HH:mm"));
                //End Format Cetakan Bagian Belakang stiker
                //PDB.PrintPage += (sender1, e1) => A.PrintPageBelakang("123456789", isibelakang, sender1, e1);
                PrintPreviewDialog printPreview = new PrintPreviewDialog
                {
                    Document = PDB
                };
                ((Form)printPreview).WindowState = FormWindowState.Maximized;
                printPreview.ShowDialog();
            }
        }
    }
}
