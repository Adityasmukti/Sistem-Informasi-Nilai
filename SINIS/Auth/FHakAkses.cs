using System;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace AtelierAngelinaApps.Modul_HRD
{
    public partial class FHakAkses : Form
    {
        
        public FHakAkses()
        {
            InitializeComponent();
            
            this.SetControlFrom();
        }
        private void FHakAkses_Load(object sender, EventArgs e)
        {
            Loaddb();
            Dg.CellClick += Dg_CellClick;
            bkeluar.Click += Bkeluar_Click;
            bsimpan.Click += Bsimpan_Click;
        }
        private void Bsimpan_Click(object sender, EventArgs e)
        {
            if (Dg.SelectedRows.Count > 0)
            {
                A.SetQueri("UPDATE `m_akses` SET `nama_akses`='" +tbhakakses.Text+"', `ket_akses`='"+tbket.Text+"' WHERE `id_akses`="+
                    Dg.CurrentRow.Cells[Dg.GetColumnIndexByHeader("ID HAK AKSES")].Value.ToString());
                if (A.GetQueri().ManipulasiData())
                {
                    AutoClosingMessageBox.Show("Data berhasil di simpan!", "Informasi", 2000);
                    tbket.Clear();
                    tbhakakses.Clear();
                    Loaddb();
                }
            }
        }
        private void Bkeluar_Click(object sender, EventArgs e) => Close();
        private void Dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dg.SelectedRows.Count > 0 && e.RowIndex>=0)
            {
                tbket.Text = Dg.Rows[e.RowIndex].Cells[Dg.GetColumnIndexByHeader("KETERANGAN")].Value.ToString();
                tbhakakses.Text = Dg.Rows[e.RowIndex].Cells[Dg.GetColumnIndexByHeader("HAK AKSES")].Value.ToString();
            }
        }
        private bool Loaddb()
        {
            A.SetQueri("SELECT * FROM `m_akses` ORDER BY `id_akses` ASC");
            Dg.Rows.Clear();
            foreach (DataRow b in A.GetQueri().GetData().Rows)
            {
                Dg.Rows.Add(b["id_akses"], b["nama_akses"],b["ket_akses"].ToString());
            }
            return true;
        }
    }
}
