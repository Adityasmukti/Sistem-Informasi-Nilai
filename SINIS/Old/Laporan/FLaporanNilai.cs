using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Project_SINS.Laporan
{
    public partial class FLaporanNilai : Form
    {
        private ModulData DM = new ModulData();
        private string query = "";
        private List<string> listidkelas, listidpelajaran, listidjenisnilai, listidsiswa;
        private string namaguru, nip, kelamin, idguru, idjadwal;
        private DataTable datatabel;
        public FLaporanNilai()
        {
            InitializeComponent();
            listidkelas = new List<string>();
            listidpelajaran = new List<string>();
            listidjenisnilai = new List<string>();
            listidsiswa = new List<string>();
            idjadwal = "";
            datatabel = new DataTable();
        }

        private void cbjenisnilai_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void bexport_Click(object sender, EventArgs e)
        {
            ModulExcel EM = new ModulExcel();
            if (dglaporan.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel Document (.xlsx)|*.xlsx";
                saveFileDialog1.FilterIndex = 0;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMddHHmm") + "-"+this.Text+".xlsx";
                saveFileDialog1.Title = "Simpan File SpreadSheet";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    DataLaporanNilai dr = new DataLaporanNilai();
                    dr.filename = saveFileDialog1.FileName;
                    dr.tahunajarn = cbtahunajaran.Text;
                    dr.kelas = cbkelas.Text;
                    dr.mapel = cbpelajaran.Text;
                    dr.jenislaporan = cblaporan.Text;
                    if (cblaporan.SelectedIndex == 0)
                        dr.siswanilai = cbsiswa.Text;
                    else if (cblaporan.SelectedIndex == 1)
                        dr.siswanilai = cbjenisnilai.Text;
                    else
                        dr.siswanilai = "";

                    if (EM.exportlaporannilai(datatabel, dr) != "succes")
                        MessageBox.Show("Gagal Di Export!!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cursor.Current = Cursors.Default;
                }
            }
            else
                MessageBox.Show("Tidak Ada Data!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbsiswa_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void cbpelajaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void cblaporan_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbjenisnilai.SelectedIndex = -1;
            cbsiswa.SelectedIndex = -1;
            if(cblaporan.SelectedIndex==0)
            {
                cbjenisnilai.Enabled = false;
                cbsiswa.Enabled = true;
            }
            else if (cblaporan.SelectedIndex == 1)
            {
                cbjenisnilai.Enabled = true;
                cbsiswa.Enabled = false;
            }
            else if (cblaporan.SelectedIndex == 2)
            {
                cbjenisnilai.Enabled = false;
                cbsiswa.Enabled = false;
            }
            loaddb();
        }
        
        private void cbtahunajaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Isi Combobox Kelas
            dglaporan.Columns.Clear();
            query = "SELECT DISTINCT(id_kelas) id, kelas_nama FROM tbl_jadwal LEFT JOIN tm_kelas ON tm_kelas.id=id_kelas WHERE id_guru=" + idguru +
                " AND tahunajaran='" + cbtahunajaran.Text + "' ORDER BY kelas_nama ASC";
            cbpelajaran.Items.Clear();
            cbkelas.Items.Clear();
            listidkelas.Clear();
            foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            {
                listidkelas.Add(br["id"].ToString());
                cbkelas.Items.Add(br["kelas_nama"].ToString());
            }
            #endregion
        }

        private void cbkelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Isi Combobox Pelajaran
            query = "SELECT DISTINCT(id_pelajaran) id, pelajaran_nama FROM tbl_jadwal LEFT JOIN tm_pelajaran ON tm_pelajaran.id=id_pelajaran " +
                "WHERE tahunajaran='" + cbtahunajaran.Text + "' AND id_guru=" + idguru +
                " AND id_kelas=" + listidkelas[cbkelas.SelectedIndex] + " ORDER BY pelajaran_nama ASC";
            cbpelajaran.Items.Clear();
            listidpelajaran.Clear();
            foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            {
                listidpelajaran.Add(br["id"].ToString());
                cbpelajaran.Items.Add(br["pelajaran_nama"].ToString());
            }
            #endregion

            #region isi combobox siswa
            query = "SELECT id, siswa_nama, siswa_nis FROM tbl_ruangan LEFT JOIN tm_siswa ON id=id_siswa " +
                "WHERE tahunajaran='"+cbtahunajaran.Text+"' AND id_kelas="+listidkelas[cbkelas.SelectedIndex]+" ORDER BY siswa_nama ASC";
            cbsiswa.Items.Clear();
            listidsiswa.Clear();
            foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            {
                listidsiswa.Add(br["id"].ToString());
                cbsiswa.Items.Add(br["siswa_nama"].ToString()+" ["+ br["siswa_nis"].ToString() + "]");
            }
            #endregion
        }

        private void FLaporanNilai_Load(object sender, EventArgs e)
        {
            #region Isi data informasi pengajar
            query = "SELECT * FROM tm_guru WHERE id=" + Properties.Settings.Default.useridacces;
            foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            {
                idguru = br["id"].ToString();
                namaguru = br["guru_nama"].ToString();
                nip = br["guru_nip"].ToString();
                kelamin = br["guru_jk"].ToString();
            }
            if (kelamin == "L")
                linformasi.Text = "BAPAK " + namaguru.ToUpper() + " NIP " + nip;
            else
                linformasi.Text = "IBU " + namaguru.ToUpper() + " NIP " + nip;
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
            foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            {
                listidjenisnilai.Add(br["id"].ToString());
                cbjenisnilai.Items.Add(br["jenisnilai_nama"].ToString());
            }
            #endregion
        }

        private void loaddb()
        {
            DataTable db = new DataTable();
            db = null;
            if (cbkelas.SelectedIndex >= 0 && cbtahunajaran.SelectedIndex >= 0 &&
                cbpelajaran.SelectedIndex >= 0 && cblaporan.SelectedIndex >= 0)
            {
                query = "SELECT id_jadwal FROM tbl_jadwal WHERE id_guru=" + idguru + " AND id_pelajaran= " + listidpelajaran[cbpelajaran.SelectedIndex] +
                    " AND tahunajaran='"+cbtahunajaran.Text+"' AND id_kelas="+listidkelas[cbkelas.SelectedIndex];
                idjadwal = DM.singeldata(query);
                //laporan per siswa
                if (cblaporan.SelectedIndex == 0)
                {
                    if (cbsiswa.SelectedIndex >= 0)
                    {
                        query = "SELECT id_ruangan FROM tbl_ruangan WHERE id_kelas="+listidkelas[cbkelas.SelectedIndex]+
                            " AND id_siswa="+listidsiswa[cbsiswa.SelectedIndex];
                        string idruangan = DM.singeldata(query);

                        query = "SELECT jenisnilai_nama JENIS_NILAI, IFNULL(nilai,0) NILAI, ketnilai KETERANGAN_NILAI, ketsiswa KETERANGAN_SISWA, tgl TANGGAL FROM tm_jenisnilai LEFT JOIN (SELECT * FROM tbl_nilai WHERE id_ruangan = "+idruangan+
                            " AND id_jadwal = "+idjadwal+") tbl_nilai ON id_jenisnilai = id  ORDER BY id ASC ";
                        db = DM.GetData(query).Tables[0];
                    }
                }
                else if (cblaporan.SelectedIndex == 1)
                {
                    if (cbjenisnilai.SelectedIndex >= 0)
                    {
                        query = "SELECT siswa_nama NAMA, siswa_nis NIS,siswa_jk JK, IFNULL(nilai,0) NILAI, ketsiswa KETERANGAN " +
                             "FROM tm_siswa LEFT JOIN tbl_ruangan ON id = tbl_ruangan.id_siswa LEFT JOIN " +
                             "(SELECT * FROM tbl_nilai WHERE id_jadwal= " + idjadwal + " AND id_jenisnilai = " +
                             listidjenisnilai[cbjenisnilai.SelectedIndex] + ") tbl_nilai " +
                             "ON tbl_ruangan.id_ruangan = tbl_nilai.id_ruangan " +
                             "WHERE deleted = 0 AND tbl_ruangan.tahunajaran = '" + cbtahunajaran.Text +
                             "' AND id_kelas = " + listidkelas[cbkelas.SelectedIndex] + " ORDER BY siswa_nama ASC ";
                        db = DM.GetData(query).Tables[0];
                    }
                }
                else if (cblaporan.SelectedIndex == 2)
                {
                    query = "SELECT * FROM tm_jenisnilai ORDER BY id ASC";
                    string pivot = "";
                    foreach(DataRow br in DM.GetData(query).Tables[0].Rows)
                    {
                        pivot += ", SUM(IF(id_jenisnilai=" + br["id"].ToString() +", nilai, 0)) "+Regex.Replace(br["jenisnilai_nama"].ToString().ToUpper(), " ", "_");
                    }

                    query = "SELECT siswa_nama NAMA, siswa_nis NIS, siswa_jk JK "+pivot+" FROM tm_siswa LEFT JOIN tbl_ruangan ON id_siswa = id LEFT JOIN " +
                        "(SELECT * FROM tbl_nilai WHERE id_jadwal= "+idjadwal+") tbl_nilai ON tbl_nilai.id_ruangan = tbl_ruangan.id_ruangan " +
                        "WHERE deleted=0 AND id_kelas = "+listidkelas[cbkelas.SelectedIndex]+
                        " AND tbl_ruangan.tahunajaran = '"+cbtahunajaran.Text+"' GROUP BY id";
                    db = DM.GetData(query).Tables[0];
                }
            }
            //dglaporan.DataSource = db;
            if (db is null || db == null)
            {
            }
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
    }
}

public class DataLaporanNilai
{
    public string filename { get; set; }
    public string jenislaporan { get; set; }
    public string tahunajarn { get; set; }
    public string kelas { get; set; }
    public string mapel { get; set; }
    public string siswanilai { get; set; }
}