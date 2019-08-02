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

namespace SINIS.Settings
{
    /// بسم الله الرحمن الرحيم
    /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
    /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
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
            TbJumlahBaris.KeyPress += A.NumberOnly_KeyPress;
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
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbPesanStatus.Text.EncodeToBase64String() + "' WHERE `pengaturan` = 'statusstripmessage';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbJumlahBaris.Text + "' WHERE `pengaturan` = 'divs';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbPanelJuduBg.Text + "' WHERE `pengaturan` = 'colorpaneljudul';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbStatusbarBg.Text + "' WHERE `pengaturan` = 'statusstripmaincolor';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbStatusbarFg.Text + "' WHERE `pengaturan` = 'statusstripaksencolor';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbLabelJudul.Text + "' WHERE `pengaturan` = 'colorlabeljudul';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbDatagridFg.Text + "' WHERE `pengaturan` = 'datagridviewaksencolor';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbTombolBg.Text + "' WHERE `pengaturan` = 'buttonmaincolor';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbTombolFg.Text + "' WHERE `pengaturan` = 'buttonaksencolor';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbFg.Text + "' WHERE `pengaturan` = 'forecolor';");
                A.SetQueri(A.GetQueri() + "UPDATE `r_settings` SET `nilai` = '" + TbBg.Text + "' WHERE `pengaturan` = 'backcolor';");

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
        private void FSettingApps_Load(object sender, EventArgs e)
        {
            A.SetQueri("SELECT `pengaturan`, `nilai` FROM `r_settings`");
            foreach (DataRow b in A.GetQueri().GetData().Rows)
            {
                string nilai = b["nilai"].ToString();
                string pengaturan = b["pengaturan"].ToString();
                switch (pengaturan)
                {
                    case "statusstripmessage":
                        TbPesanStatus.Text = nilai.DecodeFromBase64String();
                        break;
                    case "divs":
                        TbJumlahBaris.Text = nilai;
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
