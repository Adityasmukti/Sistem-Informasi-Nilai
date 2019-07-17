using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.TU
{
    public partial class FRuangKelas : Form
    {
        private ModulData DM = new ModulData();
        private string query = "";
        private List<string> listidkelas;
        private List<string> listidguru;
        private List<int> listtahunajaran;
        public FRuangKelas()
        {
            InitializeComponent();
            listidkelas = new List<string>();
            listidguru = new List<string>();
            listtahunajaran = new List<int>();
        }

        private void FRuangKelas_Load(object sender, EventArgs e)
        {
            int nows = int.Parse(DateTime.Now.ToString("yyyy"));
            int next = nows + 1;
            listtahunajaran.Clear();
            cbtahunajaran.Items.Clear();
            while (nows >= 1980)
            {
                cbtahunajaran.Items.Add(nows + "/" + next);
                listtahunajaran.Add(nows);
                nows--;
                next--;
            }
            cbtahunajaran.SelectedIndex = 0;
        }

        private void loaddb()
        {
            if (cbkelas.SelectedIndex >= 0 && cbtahunajaran.SelectedIndex>=0 &&
                cbthunmasuk.SelectedIndex>=0 && cbguru.SelectedIndex>=0)
            {
                query = "SELECT tm_siswa.*, IF(IFNULL(id_ruangan, 0)>0, 1,0) kelas, IFNULL(id_ruangan,0) id_ruangan, " +
                    "(SELECT guru_nama FROM tm_guru WHERE tm_guru.id=id_guru) guru_nama, " +
                    "(SELECT kelas_nama FROM tm_kelas WHERE tm_kelas.id=id_kelas) kelas_nama " +
                    "FROM tm_siswa LEFT JOIN (SELECT * FROM tbl_ruangan WHERE tahunajaran='" + cbtahunajaran.Text +
                    "') tbl_ruangan ON id_siswa = id WHERE deleted = 0 AND siswa_tanggalmasuk LIKE '" + cbthunmasuk.Text + 
                    "%' ORDER BY id_kelas,siswa_nama ASC";
                dgsiswa.Rows.Clear();
                foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
                {
                    string ruangan = "BELUM";
                    if ((int)br["kelas"] == 1)
                        ruangan = "SUDAH";
                    dgsiswa.Rows.Add(ruangan, br["id"].ToString(), br["siswa_nama"].ToString(),
                        br["siswa_nis"].ToString(), br["siswa_jk"].ToString(), br["siswa_tanggalmasuk"],
                         br["kelas_nama"].ToString(), br["guru_nama"].ToString(), br["id_ruangan"].ToString());
                }
            }
        }
        
        private void cbtahunajaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region isi combobox tahun siswa
            int tahunawal = listtahunajaran[cbtahunajaran.SelectedIndex];
            int tahunakhir = tahunawal;
            try
            {
                query = "SELECT LEFT(MIN(siswa_tanggalmasuk),4) FROM tm_siswa WHERE deleted=0";
                string hasil = query.SingelData();
                if (hasil != "")
                    tahunakhir = int.Parse(hasil);
            }
            catch (Exception) { }
            cbthunmasuk.Items.Clear();
            while (tahunawal >= tahunakhir)
            {
                cbthunmasuk.Items.Add(tahunawal);
                tahunawal--;
            }
            cbkelas.Items.Clear();
            cbguru.Items.Clear();
            dgsiswa.Rows.Clear();
            #endregion
        }

        private void dgsiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int index = dgsiswa.CurrentRow.Index;
                if (dgsiswa.CurrentRow.Cells[0].Value.ToString() == "SUDAH")
                {
                    query = "DELETE FROM tbl_ruangan WHERE id_ruangan=" +
                        dgsiswa.CurrentRow.Cells[A.GetColumnIndexByHeader(dgsiswa, "ID RUANGAN")].Value.ToString();
                    DM.ManipulasiData(query);
                    loaddb();
                    dgsiswa.ClearSelection();
                    dgsiswa.Rows[index].Cells[0].Selected = true;
                }
                else
                {
                    bool belumdapat = true;
                    string idkelas = "0";
                    query = "SELECT * FROM tbl_ruangan WHERE tahunajaran='"+cbtahunajaran.Text+"' AND id_siswa=" +
                        dgsiswa.CurrentRow.Cells[A.GetColumnIndexByHeader(dgsiswa, "ID SISWA")].Value.ToString();
                    foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
                    {
                        idkelas = br["id_kelas"].ToString();
                        belumdapat = false;
                    }

                    if (belumdapat)
                    {
                        query = "INSERT INTO tbl_ruangan (id_siswa, id_kelas, tahunajaran, id_guru) VALUES (" +
                            dgsiswa.CurrentRow.Cells[A.GetColumnIndexByHeader(dgsiswa, "ID SISWA")].Value.ToString() + ", " +
                            listidkelas[cbkelas.SelectedIndex] + ", '" + cbtahunajaran.Text + "'," +
                            listidguru[cbguru.SelectedIndex]+")";
                        DM.ManipulasiData(query);
                        loaddb();
                        dgsiswa.ClearSelection();
                        dgsiswa.Rows[index].Cells[0].Selected = true;
                    }
                    else
                    {
                        string nis = dgsiswa.CurrentRow.Cells[A.GetColumnIndexByHeader(dgsiswa, "NIS")].Value.ToString();
                        string kelas = cbkelas.Items[listidkelas.IndexOf(idkelas)].ToString();
                        MessageBox.Show("Siswa dengan NIS "+nis+
                            " Telah ada di Kelas "+kelas+"!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void cbkelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgsiswa.Rows.Clear();
            #region isi combobox guru
            string sudahwali = "";
            int waliada = -1; ;
            query = "SELECT COUNT(id_guru) jumlah, IFNULL(id_guru,0) id_guru FROM tbl_ruangan WHERE id_kelas = "+listidkelas[cbkelas.SelectedIndex]+
                " AND tahunajaran = '"+cbtahunajaran.Text+"'";
            foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            {
                if(br["jumlah"].ToString()!="0")
                {
                    sudahwali = " AND id="+ br["id_guru"].ToString();
                    waliada = 0;
                }
            }

            cbguru.Items.Clear();
            listidguru.Clear();
            query = "SELECT * FROM tm_guru WHERE 1=1 "+sudahwali;
            foreach(DataRow br in DM.GetData(query).Tables[0].Rows)
            {
                listidguru.Add(br["id"].ToString());
                cbguru.Items.Add(br["guru_nama"].ToString()+"["+ br["guru_nip"].ToString() + "]");
            }
            cbguru.SelectedIndex = waliada;
            #endregion
        }

        private void cbthunmasuk_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM tm_kelas ORDER BY kelas_nama ASC";
            cbkelas.Items.Clear();
            listidkelas.Clear();
            foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            {
                listidkelas.Add(br["id"].ToString());
                cbkelas.Items.Add(br["kelas_nama"].ToString());
            }
            dgsiswa.Rows.Clear();
        }

        private void cbguru_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddb();
        }
    }
}
