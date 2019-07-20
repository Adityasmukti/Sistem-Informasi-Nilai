using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Pengajar
{
    public partial class FKelas : Form
    {
        private string query = "";
        private List<string> listidkelas;
        private List<string> listidpelajaran;
        private string namaguru, nip, kelamin, idguru;

        public FKelas()
        {
            InitializeComponent();
            listidkelas = new List<string>();
            listidpelajaran = new List<string>();
        }

        private void cbkelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "SELECT guru_nama,guru_nip  FROM tbl_ruangan" +
                " LEFT JOIN tm_guru ON id=id_guru WHERE tahunajaran='" + cbtahunajaran.Text +
                "' AND id_kelas=" + listidkelas[cbkelas.SelectedIndex] + " LIMIT 1";
            //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    lwali.Text = br["guru_nama"].ToString().ToUpper() + "[" + br["guru_nip"].ToString() + "]";
            //}
            loaddb();
        }

        private void loaddb()
        {
            if (cbkelas.SelectedIndex >= 0 && cbtahunajaran.SelectedIndex >= 0)
            {
                query = "SELECT tm_siswa.* FROM tbl_ruangan LEFT JOIN tm_siswa " +
                    "ON id_siswa=id WHERE  tahunajaran='" + cbtahunajaran.Text +
                    "' AND id_kelas=" + listidkelas[cbkelas.SelectedIndex]+" ORDER BY siswa_nama ASC";
                dgsiswa.Rows.Clear();
                //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
                //{
                //    dgsiswa.Rows.Add(br["id"].ToString(), br["siswa_nama"].ToString(),
                //        br["siswa_nis"].ToString(), br["siswa_jk"].ToString(), br["siswa_tanggalmasuk"]);
                //}
            }
        }

        private void cbtahunajaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgsiswa.Rows.Clear();
            #region Isi Combobox Kelas
            query = "SELECT DISTINCT(id_kelas) id, kelas_nama FROM tbl_jadwal " +
                "LEFT JOIN tm_kelas ON tm_kelas.id=id_kelas WHERE id_guru=" + idguru +
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

        private void FKelas_Load(object sender, EventArgs e)
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
        }
    }
}
