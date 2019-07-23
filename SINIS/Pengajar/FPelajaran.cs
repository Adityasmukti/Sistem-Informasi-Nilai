using System;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Pengajar
{
    /// بسم الله الرحمن الرحيم
    /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
    /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
    public partial class FPelajaran : Form
    {
        private string query = "";
        private string namaguru, nip, kelamin, idguru;
        public FPelajaran()
        {
            InitializeComponent();
        }

        private void FPelajaran_Load(object sender, EventArgs e)
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
            cbtahunajaran.SelectedIndex = 0;
            #endregion
        }

        private void cbtahunajaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void loaddb()
        {
            query = "SELECT id_pelajaran, pelajaran_nama, (SELECT kelas_nama FROM tm_kelas WHERE id_kelas=id) kelas_nama " +
                "FROM tbl_jadwal LEFT JOIN tm_pelajaran ON id_pelajaran=id WHERE id_guru="+idguru+
                " AND tahunajaran='"+cbtahunajaran.Text+"' ORDER BY pelajaran_nama ASC";
            dgpelajaran.Rows.Clear();
            //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    dgpelajaran.Rows.Add( br["id_pelajaran"], br["pelajaran_nama"], br["kelas_nama"]);
            //}
        }
    }
}
