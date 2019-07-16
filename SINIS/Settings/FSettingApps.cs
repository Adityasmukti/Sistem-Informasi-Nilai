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

namespace AtelierAngelinaApps.Applications
{
    public partial class FSettingApps : Form
    {
        List<string> idsubdistrict, idcity;
        private ColorDialog colorDialog1 = new ColorDialog
        {
            AllowFullOpen = true,
            FullOpen = true
        };
        public FSettingApps()
        {
            InitializeComponent();
            this.SetControlFrom();
            TbBatasExpire.KeyPress += A.NumberOnly_KeyPress;
            TbBatasCancel.KeyPress += A.NumberOnly_KeyPress;
            TbJumlahBaris.KeyPress += A.NumberOnly_KeyPress;
            TbWaktuSelesai.KeyPress += A.NumberOnly_KeyPress;
        }
        private bool CekControl(Control C, bool result = false)
        {
            foreach (var c in C.Controls)
            {
                if (c is TextBox tb)
                {
                    if (string.IsNullOrEmpty(tb.Text))
                        result = true;
                }
                else if (c is RichTextBox rtb)
                {
                    if (string.IsNullOrEmpty(rtb.Text))
                        result = true;
                }
                else if (c is ComboBox cb)
                {
                    if (cb.SelectedIndex < 0)
                        result = true;
                }
                else if (c is Panel pn)
                {
                    result= CekControl(pn, result);
                }
                else if (c is GroupBox gb)
                {
                    result = CekControl(gb, result);
                }
            }
            return result;
        }
        private void BSimpan_Click(object sender, EventArgs e)
        {
            if (CekControl(this))
                MessageBox.Show("Ada field yang kosong!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                A.SetQueri("UPDATE `r_settings` SET `nilai` = '" + TbOrderMessage.Text.EncodeUtf8() + "' WHERE `pengaturan` = 'replaymessage';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbPesanStatus.Text.EncodeUtf8() + "' WHERE `pengaturan` = 'statusstripmessage';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbBatasCancel.Text + "' WHERE `pengaturan` = 'canceltime';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbBatasExpire.Text + "' WHERE `pengaturan` = 'expiretime';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbWaktuSelesai.Text + "' WHERE `pengaturan` = 'selesaitime';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + CbDefaultKurir.Text + "' WHERE `pengaturan` = 'defaultkurir';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + CbDefaultService.Text + "' WHERE `pengaturan` = 'defaultservice';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + idsubdistrict[CbKecamatanAsal.SelectedIndex] + "' WHERE `pengaturan` = 'originsubdistrict';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + idcity[CbKotaAsal.SelectedIndex] + "' WHERE `pengaturan` = 'origincity';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbJumlahBaris.Text + "' WHERE `pengaturan` = 'divs';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbLinkCekingOrder.Text.EncodeUtf8() + "' WHERE `pengaturan` = 'cekorder';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbKetKodeKeep.Text.EncodeUtf8() + "' WHERE `pengaturan` = 'kodekeep';");

                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbPanelJuduBg.Text + "' WHERE `pengaturan` = 'colorpaneljudul';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbStatusbarBg.Text + "' WHERE `pengaturan` = 'statusstripmaincolor';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbStatusbarFg.Text + "' WHERE `pengaturan` = 'statusstripaksencolor';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbLabelJudul.Text + "' WHERE `pengaturan` = 'colorlabeljudul';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbDatagridFg.Text + "' WHERE `pengaturan` = 'datagridviewaksencolor';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbTombolBg.Text + "' WHERE `pengaturan` = 'buttonmaincolor';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbTombolFg.Text + "' WHERE `pengaturan` = 'buttonaksencolor';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbFg.Text + "' WHERE `pengaturan` = 'forecolor';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbBg.Text + "' WHERE `pengaturan` = 'backcolor';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + CbStatusStock.SelectedIndex + "' WHERE `pengaturan` = 'getstock';");

                if (CbTypeAsal.SelectedIndex == 0)
                    A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = 'subdistrict' WHERE `pengaturan` = 'origintype';");
                else
                    A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = 'city' WHERE `pengaturan` = 'origintype';");
                if (CbCoceng.SelectedIndex == 0)
                    A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '1' WHERE `pengaturan` = 'switchproduk';");//switchproduk
                else if (CbCoceng.SelectedIndex == 1)
                    A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '0' WHERE `pengaturan` = 'switchproduk';");//switchproduk
                if (A.GetQueri().DBUpdate())
                {
                    S.SetSettings();
                }
            }
        }
        private void BBatal_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BPengaturanAhli_Click(object sender, EventArgs e)
        {
            FSettings f = new FSettings();
            f.ShowDialog();
        }
        private void CbKecamatanAsal_DropDown(object sender, EventArgs e)
        {
            if(CbKotaAsal.SelectedIndex>=0)
            {
                idsubdistrict = CbKecamatanAsal.LoadSubdistrict(out List<string> kodepos, idcity[CbKotaAsal.SelectedIndex], false);
            }
        }
        private void FSettingApps_Load(object sender, EventArgs e)
        {
            idcity = CbKotaAsal.LoadCity(out List<string> kodepos);
            string kecamatan = "";
            CbDefaultKurir.LoadKurir("1", false);
            CbDefaultService.LoadLayanan("", false);

            A.SetQueri("SELECT `pengaturan`, `nilai` FROM `r_settings`");
            foreach (DataRow b in A.GetQueri().GetData().Rows)
            {
                string nilai = b["nilai"].ToString();
                string pengaturan = b["pengaturan"].ToString();
                switch (pengaturan)
                {
                    case "replaymessage":
                        TbOrderMessage.Text = nilai.DecodeUtf8();
                        break;
                    case "statusstripmessage":
                        TbPesanStatus.Text = nilai.DecodeUtf8();
                        break;
                    case "getstock":
                        CbStatusStock.SelectedIndex = nilai.ToInteger();
                        break;
                    case "canceltime":
                        TbBatasCancel.Text = nilai;
                        break;
                    case "expiretime":
                        TbBatasExpire.Text = nilai;
                        break;
                    case "selesaitime":
                        TbWaktuSelesai.Text = nilai;
                        break;
                    case "defaultkurir":
                        CbDefaultKurir.Text = nilai;
                        break;
                    case "defaultservice":
                        CbDefaultService.Text = nilai;
                        break;
                    case "originsubdistrict":
                        kecamatan = nilai;
                        break;
                    case "origincity":
                        CbKotaAsal.SelectedIndex = idcity.FindIndex(x => x.Equals(nilai));
                        break;
                    case "divs":
                        TbJumlahBaris.Text = nilai;
                        break;
                    case "cekorder":
                        TbLinkCekingOrder.Text = nilai.DecodeUtf8();
                        break;
                    case "kodekeep":
                        TbKetKodeKeep.Text = nilai.DecodeUtf8();
                        break;
                    case "origintype":
                        {
                            if (nilai == "city")
                                CbTypeAsal.SelectedIndex = 1;
                            else
                                CbTypeAsal.SelectedIndex = 0;
                        }
                        break;
                    case "switchproduk":
                        {
                            if (nilai == "1")
                                CbCoceng.SelectedIndex = 0;
                            else
                                CbCoceng.SelectedIndex = 1;
                        }
                        break;
                    case "colorpaneljudul":
                        {
                            PnPanelJudulBg.BackColor = nilai.StringToColor();
                            TbPanelJuduBg.Text = nilai;
                        }
                        break;
                    case "statusstripmaincolor":
                        {
                            PnStatusbarBg.BackColor = nilai.StringToColor();
                            TbStatusbarBg.Text = nilai;
                        }
                        break;
                    case "statusstripaksencolor":
                        {
                            PnStatusbarFg.BackColor = nilai.StringToColor();
                            TbStatusbarFg.Text = nilai;
                        }
                        break;
                    case "colorlabeljudul":
                        {
                            PnLabelJudul.BackColor = nilai.StringToColor();
                            TbLabelJudul.Text = nilai;
                        }
                        break;
                    case "datagridviewaksencolor":
                        {
                            PnDatagridFg.BackColor = nilai.StringToColor();
                            TbDatagridFg.Text = nilai;
                        }
                        break;
                    case "buttonmaincolor":
                        {
                            PnTombolBg.BackColor = nilai.StringToColor();
                            TbTombolBg.Text = nilai;
                        }
                        break;
                    case "buttonaksencolor":
                        {
                            PnTombolFg.BackColor = nilai.StringToColor();
                            TbTombolFg.Text = nilai;
                        }
                        break;
                    case "forecolor":
                        {
                            PnFg.BackColor = nilai.StringToColor();
                            TbFg.Text = nilai;
                        }
                        break;
                    case "backcolor":
                        {
                            PnBg.BackColor = nilai.StringToColor();
                            TbBg.Text = nilai;
                        }
                        break;
                }
                if (CbKotaAsal.SelectedIndex >= 0)
                {
                    idsubdistrict = CbKecamatanAsal.LoadSubdistrict(out kodepos, idcity[CbKotaAsal.SelectedIndex], false);
                    CbKecamatanAsal.SelectedIndex = idsubdistrict.FindIndex(x => x.Equals(kecamatan));
                }
            }
        }
        private void PnPanelJudulBg_Click(object sender, EventArgs e)
        {
            LoadWarna(PnPanelJudulBg, TbPanelJuduBg);
        }
        private void PnLabelJudul_Click(object sender, EventArgs e)
        {
            LoadWarna(PnLabelJudul, TbLabelJudul);
        }
        private void PnTombolFg_Click(object sender, EventArgs e)
        {
            LoadWarna(PnTombolFg, TbTombolFg);
        }
        private void PnStatusbarBg_Click(object sender, EventArgs e)
        {
            LoadWarna(PnStatusbarBg, TbStatusbarBg);
        }
        private void PnDatagridFg_Click(object sender, EventArgs e)
        {
            LoadWarna(PnDatagridFg, TbDatagridFg);
        }
        private void PnBg_Click(object sender, EventArgs e)
        {
            LoadWarna(PnBg, TbBg);
        }
        private void PnStatusbarFg_Click(object sender, EventArgs e)
        {
            LoadWarna(PnStatusbarFg, TbStatusbarFg);
        }
        private void PnTombolBg_Click(object sender, EventArgs e)
        {
            LoadWarna(PnTombolBg, TbTombolBg);
        }
        private void PnFg_Click(object sender, EventArgs e)
        {
            LoadWarna(PnFg, TbFg);
        }
        private void LoadWarna(Panel pn, TextBox tb)
        {
            colorDialog1.Color = tb.Text.StringToColor();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                tb.Text = colorDialog1.Color.ColorToString();
                pn.BackColor = colorDialog1.Color;
            }
        }
    }
}
