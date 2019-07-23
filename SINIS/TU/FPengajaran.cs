using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.TU
{
    /// بسم الله الرحمن الرحيم
    /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
    /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
    public partial class FPengajaran : Form
    {
        private string query = "";
        private List<string> listidkelas;
        private List<string> listidguru;
        public FPengajaran()
        {
            InitializeComponent();
            listidkelas = new List<string>();
            listidguru = new List<string>();
        }

        private void FPengajaran_Load(object sender, EventArgs e)
        {
            loadingawal();
            loaddb();
        }

        private void loaddb()
        {
            if (cbkelas.SelectedIndex >= 0)
            {
                query = "SELECT tm_pelajaran.*,IF(IFNULL(id_jadwal, 0) > 0, 1, 0) jadwal, " +
                    "IFNULL(id_jadwal,0) id_jadwal, IFNULL(id_kelas,0) id_kelas, id_guru," +
                    "IFNULL((SELECT guru_nama FROM tm_guru WHERE tm_guru.id=tbl_jadwal.id_guru),'-') guru_nama " +
                    "FROM tm_pelajaran LEFT JOIN (SELECT * FROM tbl_jadwal WHERE id_kelas=" +
                    listidkelas[cbkelas.SelectedIndex] + " AND tahunajaran='" + cbtahunajaran.Text +
                    "') tbl_jadwal ON id_pelajaran=id ORDER BY pelajaran_nama ASC";

                //dgpengajaran.Rows.Clear();
                //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
                //{
                //   string ruangan = "BELUM";
                //    if (Convert.ToUInt32(br["jadwal"].ToString()) == 1)
                //        ruangan = "SUDAH";
                //    dgpengajaran.Rows.Add(ruangan, br["id"].ToString(), br["pelajaran_nama"].ToString()
                //        , br["guru_nama"].ToString(), br["id_jadwal"].ToString(), 
                //        br["id_kelas"].ToString(), br["id_guru"].ToString());
                //}
            }
        }

        private void loadingawal()
        {
            //#region Isi Combobox Kelas
            //query = "SELECT * FROM tm_kelas ORDER BY kelas_nama ASC";
            //cbkelas.Items.Clear();
            //listidkelas.Clear();
            //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    listidkelas.Add(br["id"].ToString());
            //    cbkelas.Items.Add(br["kelas_nama"].ToString());
            //}
            //cbkelas.SelectedIndex = 0;
            //#endregion

            //#region Isi Combobox Guru
            //query = "SELECT * FROM tm_guru WHERE deleted=0 ORDER BY guru_nama ASC";
            //cbguru.Items.Clear();
            //listidguru.Clear();
            //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    listidguru.Add(br["id"].ToString());
            //    cbguru.Items.Add(br["guru_nama"].ToString()+"["+br["guru_nip"].ToString()+"]");
            //}
            //cbguru.SelectedIndex = 0;
            //#endregion

            //#region Isi Combobox Tahun Ajaran
            //int nows = int.Parse(DateTime.Now.ToString("yyyy"));
            //int next = nows + 1;
            //cbtahunajaran.Items.Clear();
            //while (nows >= 1980)
            //{
            //    cbtahunajaran.Items.Add(nows + "/" + next);
            //    nows--;
            //    next--;
            //}
            //cbtahunajaran.SelectedIndex = 0;
            //#endregion
        }

        private void cbtahunajaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void dgpengajaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    int index = dgpengajaran.CurrentRow.Index;
            //    if (dgpengajaran.CurrentRow.Cells[0].Value.ToString() == "SUDAH")
            //    {
            //        query = "DELETE FROM tbl_jadwal WHERE id_jadwal=" +
            //            dgpengajaran.CurrentRow.Cells[A.GetColumnIndexByHeader(dgpengajaran, "ID JADWAL")].Value.ToString();
            //        DM.ManipulasiData(query);
            //        loaddb();
            //        dgpengajaran.ClearSelection();
            //        dgpengajaran.Rows[index].Cells[0].Selected = true;
            //    }
            //    else
            //    {
            //        bool belumdapat = true;
            //        string idguru = "0";
            //        query = "SELECT * FROM tbl_jadwal WHERE tahunajaran='" + cbtahunajaran.Text + "' AND id_kelas=" +
            //            dgpengajaran.CurrentRow.Cells[A.GetColumnIndexByHeader(dgpengajaran, "ID KELAS")].Value.ToString()+
            //            " AND id_pelajaran="+ dgpengajaran.CurrentRow.Cells[A.GetColumnIndexByHeader(dgpengajaran, "ID PELAJARAN")].Value.ToString();
            //        foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //        {
            //            idguru = br["id_guru"].ToString();
            //            belumdapat = false;
            //        }

            //        if (belumdapat)
            //        {
            //            query = "INSERT INTO tbl_jadwal (id_pelajaran, id_kelas,id_guru, tahunajaran) VALUES (" +
            //                dgpengajaran.CurrentRow.Cells[A.GetColumnIndexByHeader(dgpengajaran, "ID PELAJARAN")].Value.ToString() + ", " +
            //                listidkelas[cbkelas.SelectedIndex] + ", "+listidguru[cbguru.SelectedIndex]+", '" + cbtahunajaran.Text + "')";
            //            DM.ManipulasiData(query);
            //            loaddb();
            //            dgpengajaran.ClearSelection();
            //            dgpengajaran.Rows[index].Cells[0].Selected = true;
            //        }
            //        else
            //        {
            //            string guru = cbguru.Items[listidguru.IndexOf(idguru)].ToString();
            //            MessageBox.Show("Guru "+guru+" Telah mengajar di Kelas ini!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //}
        }
    }
}
