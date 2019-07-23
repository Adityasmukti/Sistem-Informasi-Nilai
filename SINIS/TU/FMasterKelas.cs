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

namespace SINIS.TU
{
    /// بسم الله الرحمن الرحيم
    /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
    /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
    public partial class FMasterKelas : Form
    {
        public FMasterKelas()
        {
            InitializeComponent();
            this.SetControlFrom();
            tbhalaman.SetHalaman(bprev, ldarihalaman, bnext, Loaddb);
            TbCari.TextChanged += TbCari_TextChanged;
        }
        private void TbCari_TextChanged(object sender, EventArgs e)
        {
            tbhalaman.Text = "1";
            Loaddb();
        }
        private bool Loaddb()
        {
            A.SetSelect("SELECT `kode_kelas`, `namakelas`, `keterangan` ");
            A.SetFrom("FROM `r_kelas` ");
            A.SetWhere("WHERE `hapus`='N' ");
            TbCari.GenerateQueriCari(new List<string>() { "namakelas", "keterangan"});
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + tbhalaman.LimitQ(ldarihalaman, A.GetFrom(), A.GetWhere()) + ";");
            Dg.QueriToDg();
            return true;
        }
        private void BOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FMasterKelas_Load(object sender, EventArgs e)
        {
            Loaddb();
        }
        private void Dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == Dg.GetColumnIndexByHeader("UBAH"))
                {
                    Dg.Enabled = false;
                    TbKelas.Text = Dg.Rows[e.RowIndex].Cells[Dg.GetColumnIndexByHeader("KELAS")].Value.ToString();
                    TbKeterangan.Text = Dg.Rows[e.RowIndex].Cells[Dg.GetColumnIndexByHeader("KETERANGAN")].Value.ToString();
                }
                else if (e.ColumnIndex == Dg.GetColumnIndexByHeader("HAPUS"))
                {
                    if (MessageBox.Show("Hapus mata pelajaran?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (A.DBHapus("UPDATE `r_kelas` SET `hapus` = 'Y' WHERE `kode_kelas` = '" + Dg.Rows[e.RowIndex].Cells[0].Value.ToString() + "';"))
                            Loaddb();
                }
            }
        }
        private void BBatal_Click(object sender, EventArgs e)
        {
            if(Dg.Enabled)
                Close();
            else
            {
                Dg.Enabled = !Dg.Enabled;
                TbKelas.Clear();
                TbKeterangan.Clear();
            }
        }
        private void BSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbKelas.Text))
                MessageBox.Show("Nama kelas kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (Dg.Enabled)
                {
                    if (MessageBox.Show("Simpan kelas baru?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        A.SetInsert("INSERT INTO `r_kelas` (`kode_kelas`, `namakelas`, `keterangan`)");
                        A.SetValues("VALUES('" + A.GenerateKode("KL", "r_kelas", "kode_kelas") + "', '" + TbKelas.Text + "', " +
                            "'" + TbKeterangan.StrEscape() + "')");
                        A.SetQueri(A.GetInsert() + A.GetValues() + ";");
                        if (A.GetQueri().ManipulasiData())
                        {
                            MessageBox.Show("Data telah ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TbKelas.Clear();
                            TbKeterangan.Clear();
                            Loaddb();
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Simpan perubahan kelas?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        A.SetUpdate("UPDATE `r_kelas` ");
                        A.SetSet("SET `namakelas` = '" + TbKelas.Text + "', `keterangan` = '" + TbKeterangan.StrEscape() + "' ");
                        A.SetWhere("WHERE `kode_kelas` = '" + Dg.CurrentRow.Cells[0].Value.ToString() + "' ");
                        A.SetQueri(A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        if (A.GetQueri().ManipulasiData())
                        {
                            MessageBox.Show("Data telah diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TbKelas.Clear();
                            TbKeterangan.Clear();
                            Dg.LoadIndex(Loaddb, 1);
                        }
                    }
                }
            }
        }
    }
}
