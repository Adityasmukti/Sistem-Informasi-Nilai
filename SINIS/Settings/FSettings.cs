using System;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace AtelierAngelinaApps.Applications
{
    public partial class FSettings : Form
    {
        public FSettings()
        {
            InitializeComponent();
            this.SetControlFrom();
            this.KeyDown += F_KeyDown;
            tbhalaman.SetHalaman(bprev, ldarihalaman, bnext, Loaddb);
            TbCari.TextChanged += ValueChanged;
            CbKategori.SelectedIndexChanged += ValueChanged;
            Dg.CellDoubleClick += Dg_CellDoubleClick;
        }
        private void Dg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("ID")].Value.ToString();
            if(e.ColumnIndex==Dg.GetColumnIndexByHeader("NILAI"))
            {
                string values=Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("NILAI")].Value.ToString();
                string types = Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("TIPE")].Value.ToString();
                if (types.ToLower() == "string")
                {
                    if(A.InputTextBox("Nilai ","Nilai ",ref values)==DialogResult.OK)
                    {
                        A.SetUpdate("UPDATE `r_settings` ");
                        A.SetSet("SET `nilai` = '" + values + "' ");
                        A.SetWhere("WHERE `id` = '" +id+"'; ");
                        A.SetQueri(A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        if (A.GetQueri().ManipulasiData())
                        {
                            AutoClosingMessageBox.Show("Berhasil Di simpan","Informasi", 2000);
                            Dg.LoadIndex(Loaddb, Dg.GetColumnIndexByHeader("NILAI"));
                        }
                    }
                }
                else if (types.ToLower() == "int")
                {
                    if (A.InputBoxNumber("Nilai ", "Nilai ", ref values) == DialogResult.OK)
                    {
                        A.SetUpdate("UPDATE `r_settings` ");
                        A.SetSet("SET `nilai` = '" + values + "' ");
                        A.SetWhere("WHERE `id` = '" + id + "'; ");
                        A.SetQueri(A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        if (A.GetQueri().ManipulasiData())
                        {
                            AutoClosingMessageBox.Show("Berhasil Di simpan", "Informasi", 2000);
                            Dg.LoadIndex(Loaddb, Dg.GetColumnIndexByHeader("NILAI"));
                        }
                    }
                }
                else if (types.ToLower() == "long")
                {
                    if (A.InputBoxNumber("Nilai ", "Nilai ", ref values) == DialogResult.OK)
                    {
                        A.SetUpdate("UPDATE `r_settings` ");
                        A.SetSet("SET `nilai` = '" + values + "' ");
                        A.SetWhere("WHERE `id` = '" + id + "'; ");
                        A.SetQueri(A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        if (A.GetQueri().ManipulasiData())
                        {
                            AutoClosingMessageBox.Show("Berhasil Di simpan", "Informasi", 2000);
                            Dg.LoadIndex(Loaddb, Dg.GetColumnIndexByHeader("NILAI"));
                        }
                    }
                }
                else if (types.ToLower() == "color")
                {
                    ColorDialog colorDialog1 = new ColorDialog
                    {
                        AllowFullOpen = true,
                        FullOpen = true,
                        Color = values.StringToColor()
                    };
                    if (colorDialog1.ShowDialog() == DialogResult.OK)
                    {
                        A.SetUpdate("UPDATE `r_settings` ");
                        A.SetSet("SET `nilai` = '" + colorDialog1.Color.ColorToString() + "' ");
                        A.SetWhere("WHERE `id` = '" + id + "'; ");
                        A.SetQueri(A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        if (A.GetQueri().ManipulasiData())
                        {
                            AutoClosingMessageBox.Show("Berhasil Di simpan", "Informasi", 2000);
                            Dg.LoadIndex(Loaddb, Dg.GetColumnIndexByHeader("NILAI"));
                        }
                    }
                }
                else if (types.ToLower() == "datetime")
                {
                    if (A.InputTanggal("Nilai ", "Nilai ", ref values) == DialogResult.OK)
                    {
                        A.SetUpdate("UPDATE `r_settings` ");
                        A.SetSet("SET `nilai` = '" +values+"' ");
                        A.SetWhere("WHERE `id` = '" + id + "'; ");
                        A.SetQueri(A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        if (A.GetQueri().ManipulasiData())
                        {
                            AutoClosingMessageBox.Show("Berhasil Di simpan", "Informasi", 2000);
                            Dg.LoadIndex(Loaddb, Dg.GetColumnIndexByHeader("NILAI"));
                        }
                    }
                }
            }
            else if(e.ColumnIndex== Dg.GetColumnIndexByHeader("KETERANGAN"))
            {
                string values=Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("KETERANGAN")].Value.ToString();
                if (A.InputTextBox("Keterangan ", "Keterangan ", ref values) == DialogResult.OK)
                {
                    A.SetUpdate("UPDATE `r_settings` ");
                    A.SetSet("SET `keterangan` = '" + values + "' ");
                    A.SetWhere("WHERE `id` = '" + id + "'; ");
                    A.SetQueri(A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                    if (A.GetQueri().ManipulasiData())
                    {
                        AutoClosingMessageBox.Show("Berhasil Di simpan", "Informasi", 2000);
                        Dg.LoadIndex(Loaddb, Dg.GetColumnIndexByHeader("NILAI"));
                    }
                }
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
        private void ValueChanged(object sender, EventArgs e)
        {
            tbhalaman.Text = "1";
            Loaddb();
        }
        private bool Loaddb()
        {
            A.SetSelect("SELECT `id`,  `pengaturan`, `kategori`,`nama_pangaturan`, `nilai`, `type`, `keterangan` ");
            A.SetFrom("FROM `r_settings` ");
            A.SetWhere("WHERE (`nama_pangaturan` LIKE '"+TbCari.StrEscape()+ "%' OR `nilai` LIKE '" + TbCari.StrEscape() + "%' OR `type` LIKE '" + TbCari.StrEscape() + "%') ");
            if (CbKategori.SelectedIndex > 0)
                A.SetWhere(A.GetWhere() + "AND `kategori`='"+CbKategori.Text+"' ");
            A.SetOrderby("ORDER BY `kategori` ASC ");
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + A.GetOrderby() + tbhalaman.LimitQ(ldarihalaman, A.GetFrom(), A.GetWhere()) + ";");
            Dg.Rows.Clear();
            foreach (DataRow b in A.GetQueri().GetData().Rows)
            {
                DataGridViewRow dr = new DataGridViewRow();
                foreach (object a in b.ItemArray)
                {
                    dr.Cells.Add(new DataGridViewTextBoxCell { Value = a });
                }
                Dg.Rows.Add(dr);
            }
            return true;
        }
        private void FSettings_Load(object sender, EventArgs e)
        {
            Loaddb();
        }
    }
}
