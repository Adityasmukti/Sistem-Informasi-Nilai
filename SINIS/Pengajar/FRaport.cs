using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Pengajar
{
    public partial class FRaport : Form
    {
        /// بسم الله الرحمن الرحيم
        /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
        /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
        public FRaport()
        {
            InitializeComponent();
            listidkelas = new List<string>();
            listidsiswa = new List<string>();
            listidjenisnilai = new List<string>();
            datatabel = new DataTable();
        }

        private DataTable datatabel;
        private string query = "";
        private List<string> listidkelas, listidsiswa, listidjenisnilai;
        private string namaguru, nip, kelamin, idguru;

        private void cbkelas_SelectedIndexChanged(object sender, EventArgs e)
        {

            #region isi combobox siswa
            query = "SELECT id, siswa_nama, siswa_nis FROM tbl_ruangan LEFT JOIN tm_siswa ON id=id_siswa " +
                "WHERE tahunajaran='" + cbtahunajaran.Text + "' AND id_kelas=" + listidkelas[cbkelas.SelectedIndex] + " ORDER BY siswa_nama ASC";
            cbsiswa.Items.Clear();
            listidsiswa.Clear();
            //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    listidsiswa.Add(br["id"].ToString());
            //    cbsiswa.Items.Add(br["siswa_nama"].ToString() + " [" + br["siswa_nis"].ToString() + "]");
            //}
            #endregion
            loaddb();
        }

        private void cbjenisnilai_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void cblaporan_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbsiswa.SelectedIndex = -1;
            cbjenisnilai.SelectedIndex = -1;
            dglaporan.Columns.Clear();
            if (cblaporan.SelectedIndex == 0)
            {
                cbsiswa.Enabled = false;
                cbjenisnilai.Enabled = true;
            }
            else if (cblaporan.SelectedIndex == 1)
            {
                cbsiswa.Enabled = true;
                cbjenisnilai.Enabled = false;
            }
        }

        private void cbsiswa_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void cbtahunajaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Isi Combobox Kelas
            dglaporan.Columns.Clear();
            query = "SELECT DISTINCT(id_kelas) id, kelas_nama FROM tbl_ruangan LEFT JOIN " +
                "tm_kelas ON tm_kelas.id=id_kelas WHERE id_guru=" + idguru +
                " AND tahunajaran='" + cbtahunajaran.Text + "' ORDER BY kelas_nama ASC";
            cbkelas.Items.Clear();
            listidkelas.Clear();
            //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    listidkelas.Add(br["id"].ToString());
            //    cbkelas.Items.Add(br["kelas_nama"].ToString());
            //}
            #endregion
        }

        private void bexport_Click(object sender, EventArgs e)
        {
            //ModulExcel EM = new ModulExcel();
            //if (dglaporan.Rows.Count > 0)
            //{
            //    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //    saveFileDialog1.Filter = "Excel Document (.xlsx)|*.xlsx";
            //    saveFileDialog1.FilterIndex = 0;
            //    saveFileDialog1.RestoreDirectory = true;
            //    saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMddHHmm") + "-"+this.Text+".xlsx";
            //    saveFileDialog1.Title = "Simpan File SpreadSheet";

            //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //    {
            //        Cursor.Current = Cursors.WaitCursor;
            //        DataRaport dr = new DataRaport();
            //        dr.filename = saveFileDialog1.FileName;
            //        dr.jenisnilai = cbjenisnilai.Text;
            //        dr.kelas = cbkelas.Text;
            //        dr.tahunajarn = cbtahunajaran.Text;
            //        dr.jenislaporan = cblaporan.Text;
            //        dr.siswa = cbsiswa.Text;

            //        if (EM.exportlaporanraport(datatabel, dr) != "succes")
            //            MessageBox.Show("Gagal Di Export!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        Cursor.Current = Cursors.Default;
            //    }
            //}
            //else
            //    MessageBox.Show("Tidak Ada Data!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void loaddb()
        {
            DataTable db = new DataTable();
            db = null;
            if (cbkelas.SelectedIndex >= 0 && cbtahunajaran.SelectedIndex >= 0 && 
                cblaporan.SelectedIndex >= 0)
            {
                query = "SELECT * FROM tm_pelajaran ORDER BY pelajaran_nama ASC";
                string pivot = "";
                //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
                //{
                //    string hilangkantanda = Regex.Replace(br["pelajaran_nama"].ToString().ToUpper(), " ", "_");
                //    hilangkantanda = hilangkantanda.Replace('.', '_');
                //    pivot += ", SUM(IF(id_pelajaran=" + br["id"].ToString() + ", nilai, 0)) " + hilangkantanda;
                //}

                if (cblaporan.SelectedIndex == 0)
                {
                    if (cbjenisnilai.SelectedIndex >= 0)
                    {
                        query = "SELECT (SELECT siswa_nama FROM tm_siswa WHERE tm_siswa.id=tbl_ruangan.id_siswa ) NAMA," +
                            "(SELECT siswa_nis FROM tm_siswa WHERE tm_siswa.id=tbl_ruangan.id_siswa) NIS, " +
                            "(SELECT siswa_jk FROM tm_siswa WHERE tm_siswa.id=tbl_ruangan.id_siswa) JK " + pivot +
                            " FROM tbl_ruangan LEFT JOIN tbl_jadwal ON tbl_jadwal.id_kelas = tbl_ruangan.id_kelas " +
                            "LEFT JOIN tbl_nilai ON tbl_nilai.id_jadwal = tbl_jadwal.id_jadwal AND tbl_nilai.id_ruangan = tbl_ruangan.id_ruangan " +
                            "WHERE tbl_ruangan.id_kelas = " + listidkelas[cbkelas.SelectedIndex] + 
                            " AND tbl_ruangan.tahunajaran = '" + cbtahunajaran.Text +
                            "' AND id_jenisnilai = " + listidjenisnilai[cbjenisnilai.SelectedIndex] + " GROUP BY id_siswa";
                        //db = DM.GetData(query).Tables[0];
                    }
                }
                else if (cblaporan.SelectedIndex == 1)
                {
                    if (cbsiswa.SelectedIndex >= 0)
                    {
                        query = "SELECT (SELECT jenisnilai_nama FROM tm_jenisnilai WHERE tm_jenisnilai.id = id_jenisnilai) JENIS_NILAI, " +
                            "ketnilai KETERANGAN_NILAI "+pivot+
                            " FROM tbl_ruangan LEFT JOIN tbl_jadwal ON tbl_jadwal.id_kelas = tbl_ruangan.id_kelas " +
                            "LEFT JOIN tbl_nilai ON tbl_nilai.id_jadwal = tbl_jadwal.id_jadwal " +
                            "AND tbl_nilai.id_ruangan = tbl_ruangan.id_ruangan " +
                            "WHERE tbl_ruangan.tahunajaran = '" + cbtahunajaran.Text +
                            "' AND id_siswa = "+listidsiswa[cbsiswa.SelectedIndex]+" GROUP BY id_jenisnilai ";
                        //db = DM.GetData(query).Tables[0];
                    }
                }
            }

            //dglaporan.DataSource = db;
            if (db is null || db == null)
            {}
            else
            {
                datatabel = db;
                dglaporan.Columns.Clear();
                foreach (DataColumn cl in db.Columns)
                {
                    dglaporan.Columns.Add(cl.ColumnName, Regex.Replace(cl.ColumnName, "_", " "));
                }

                foreach (DataRow br in db.Rows)
                {
                    dglaporan.Rows.Add(br.ItemArray);
                }
            }
        }

        private void FRaport_Load(object sender, EventArgs e)
        {

            #region Isi data informasi pengajar
            query = "SELECT * FROM tm_guru WHERE id=" + S.GetUserid();
            //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    idguru = br["id"].ToString();
            //    namaguru = br["guru_nama"].ToString();
            //    nip = br["guru_nip"].ToString();
            //    kelamin = br["guru_jk"].ToString();
            //}
           
            #endregion

            #region Isi Combobox Tahun Ajaran
            int nows = int.Parse(DateTime.Now.ToString("yyyy"));
            int next = nows + 1;
            cbtahunajaran.Items.Clear();
            while (nows >= 1990)
            {
                cbtahunajaran.Items.Add(nows + "/" + next);
                nows--;
                next--;
            }
            #endregion

            #region isi combobox jenis nilai
            listidjenisnilai.Clear();
            cbjenisnilai.Items.Clear();
            query = "SELECT * FROM tm_jenisnilai ORDER BY jenisnilai_nama ASC";
            //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    listidjenisnilai.Add(br["id"].ToString());
            //    cbjenisnilai.Items.Add(br["jenisnilai_nama"].ToString());
            //}
            #endregion
        }
    }
}

public class DataRaport
{
    public string jenisnilai { get; set; }
    public string tahunajarn { get; set; }
    public string kelas { get; set; }
    public string walikelas { get; set; }
    public string jenislaporan { get; set; }
    public string siswa { get; set; }
    public string filename { get; set; }
}
