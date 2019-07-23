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
    public partial class FMasterJenisNilai : Form
    {
        public FMasterJenisNilai()
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
        private void BSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbJenisNilai.Text))
                MessageBox.Show("Jenis nilai kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (Dg.Enabled)
                {
                    if (MessageBox.Show("Simpan jenis nilai baru?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        A.SetInsert("INSERT INTO `r_jenisnilai` (`kode_jenisnilai`, `namajenisnilai`, `keterangan`)");
                        A.SetValues("VALUES('" + A.GenerateKode("JN", "r_jenisnilai", "kode_jenisnilai") + "', '" + TbJenisNilai.Text + "', " +
                            "'" + TbKeterangan.StrEscape() + "')");
                        A.SetQueri(A.GetInsert() + A.GetValues() + ";");
                        if (A.GetQueri().ManipulasiData())
                        {
                            MessageBox.Show("Data telah ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TbJenisNilai.Clear();
                            TbKeterangan.Clear();
                            Loaddb();
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Simpan perubahan jenis nilai?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        A.SetUpdate("UPDATE `r_jenisnilai` ");
                        A.SetSet("SET `namajenisnilai` = '" + TbJenisNilai.Text + "', `keterangan` = '" + TbKeterangan.StrEscape() + "' ");
                        A.SetWhere("WHERE `kode_jenisnilai` = '" + Dg.CurrentRow.Cells[0].Value.ToString() + "' ");
                        A.SetQueri(A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        if (A.GetQueri().ManipulasiData())
                        {
                            MessageBox.Show("Data telah diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TbJenisNilai.Clear();
                            TbKeterangan.Clear();
                            Dg.LoadIndex(Loaddb, 1);
                        }
                    }
                }
            }
        }

        private bool Loaddb()
        {
            A.SetSelect("SELECT `kode_jenisnilai`, `namajenisnilai`, `keterangan` ");
            A.SetFrom("FROM `r_jenisnilai` ");
            A.SetWhere("WHERE `hapus`='N' ");
            TbCari.GenerateQueriCari(new List<string>() { "kode_jenisnilai", "namajenisnilai", "keterangan", });
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + tbhalaman.LimitQ(ldarihalaman, A.GetFrom(), A.GetWhere()) + ";");
            Dg.QueriToDg();
            return true;
        }
        private void BOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FMasterJenisNilai_Load(object sender, EventArgs e)
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
                    TbJenisNilai.Text = Dg.Rows[e.RowIndex].Cells[Dg.GetColumnIndexByHeader("JENIS NILAI")].Value.ToString();
                    TbKeterangan.Text = Dg.Rows[e.RowIndex].Cells[Dg.GetColumnIndexByHeader("KETERANGAN")].Value.ToString();
                }
                else if (e.ColumnIndex == Dg.GetColumnIndexByHeader("HAPUS"))
                {
                    if (MessageBox.Show("Hapus mata pelajaran?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (A.DBHapus("UPDATE `r_jenisnilai` SET `hapus` = 'Y' WHERE `kode_jenisnilai` = '" + Dg.Rows[e.RowIndex].Cells[0].Value.ToString() + "';"))
                            Loaddb();
                }
            }
        }

        private void BBatal_Click(object sender, EventArgs e)
        {
            if (Dg.Enabled)
                Close();
            else
            {
                Dg.Enabled = !Dg.Enabled;
                TbJenisNilai.Clear();
                TbKeterangan.Clear();
            }
        }
    }
}
