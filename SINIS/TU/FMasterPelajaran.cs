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
    public partial class FMasterPelajaran : Form
    {
        public FMasterPelajaran()
        {
            InitializeComponent();
            this.SetControlFrom();
            CbStatus.LoadYN(false);
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
            if (string.IsNullOrEmpty(TbKodeMapel.Text))
                MessageBox.Show("Kode mapel kosong!","Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(string.IsNullOrEmpty(TbMataPelajaran.Text))
                MessageBox.Show("Mata Pelajaran kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(CbStatus.SelectedIndex<0)
                MessageBox.Show("Status kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (Dg.Enabled)
                {
                    if (MessageBox.Show("Simpan pelajaran baru?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        A.SetInsert("INSERT INTO `r_matapelajaran` (`kodepelajaran`, `kodemapel`, `namapelajaran`, `status`)");
                        A.SetValues("VALUES('" + A.GenerateKode("MP", "r_matapelajaran", "kodepelajaran") + "', '" + TbKodeMapel.Text + "', " +
                            "'" + TbMataPelajaran.StrEscape() + "', '" + CbStatus.ToYN() + "')");
                        A.SetQueri(A.GetInsert() + A.GetValues() + ";");
                        if (A.GetQueri().ManipulasiData())
                        {
                            MessageBox.Show("Data telah ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TbKodeMapel.Clear();
                            TbMataPelajaran.Clear();
                            CbStatus.SelectedIndex = -1;
                            Loaddb();
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Simpan perubahan pelajaran?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        A.SetUpdate("UPDATE `r_matapelajaran` ");
                        A.SetSet("SET `kodemapel` = '" + TbKodeMapel.Text + "', `namapelajaran` = '" + TbMataPelajaran.StrEscape() + "', `status` = '" + CbStatus.ToYN() + "' ");
                        A.SetWhere("WHERE `kodepelajaran` = '" + Dg.CurrentRow.Cells[0].Value.ToString() + "' ");
                        A.SetQueri(A.GetUpdate() + A.GetSet() + A.GetWhere() + ";");
                        if (A.GetQueri().ManipulasiData())
                        {
                            MessageBox.Show("Data telah diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TbKodeMapel.Clear();
                            TbMataPelajaran.Clear();
                            CbStatus.SelectedIndex = -1;
                            Dg.LoadIndex(Loaddb, 1);
                        }
                    }
                }
            }
        }
        private bool Loaddb()
        {
            A.SetSelect("SELECT `kodepelajaran`, `kodemapel`, `namapelajaran`, IF(`status`='Y','YA','TIDAK') `status` ");
            A.SetFrom("FROM `r_matapelajaran` ");
            A.SetWhere("WHERE `hapus`='N' ");
            TbCari.GenerateQueriCari(new List<string>() { "kodemapel", "namapelajaran", "status", });
            A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + tbhalaman.LimitQ(ldarihalaman, A.GetFrom(), A.GetWhere()) + ";");
            Dg.QueriToDg();
            return true;
        }
        private void BOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FMasterPelajaran_Load(object sender, EventArgs e)
        {
            Loaddb();
        }
        private void Dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                if (e.ColumnIndex == Dg.GetColumnIndexByHeader("UBAH"))
                {
                    Dg.Enabled = false;
                    TbKodeMapel.Text = Dg.Rows[e.RowIndex].Cells[Dg.GetColumnIndexByHeader("KODE MAPEL")].Value.ToString();
                    TbMataPelajaran.Text = Dg.Rows[e.RowIndex].Cells[Dg.GetColumnIndexByHeader("MATA PELAJARAN")].Value.ToString();
                    CbStatus.Text = Dg.Rows[e.RowIndex].Cells[Dg.GetColumnIndexByHeader("AKTIF")].Value.ToString();
                }
                else if (e.ColumnIndex == Dg.GetColumnIndexByHeader("HAPUS"))
                {
                    if (MessageBox.Show("Hapus mata pelajaran?","Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (A.DBHapus("UPDATE `r_matapelajaran` SET `hapus` = 'Y' WHERE `kodepelajaran` = '" + Dg.Rows[e.RowIndex].Cells[0].Value.ToString() + "';"))
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
                TbKodeMapel.Clear();
                TbMataPelajaran.Clear();
                CbStatus.SelectedIndex = -1;
            }
        }
    }
}
