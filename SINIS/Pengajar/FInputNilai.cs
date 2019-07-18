using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.Pengajar
{
    public partial class FInputNilai : Form
    {
        private string query = "";
        private List<string> listidkelas;
        private List<string> listidpelajaran;
        private List<string> listidjenisnilai;
        private string namaguru, nip, kelamin,idguru;
        private string idjadwal, idruangan;
        public FInputNilai()
        {
            InitializeComponent();
            listidkelas = new List<string>();
            listidpelajaran = new List<string>();
            listidjenisnilai = new List<string>();
            idjadwal = "";
            idruangan = "";
        }

        private void cbtahunajaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgnilai.Rows.Clear();
            #region Isi Combobox Kelas
            query = "SELECT DISTINCT(id_kelas) id, kelas_nama FROM tbl_jadwal LEFT JOIN tm_kelas ON tm_kelas.id=id_kelas WHERE id_guru=" + idguru +
                " AND tahunajaran='" + cbtahunajaran.Text + "' ORDER BY kelas_nama ASC";
            cbkelas.Items.Clear();
            listidkelas.Clear();
            //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    listidkelas.Add(br["id"].ToString());
            //    cbkelas.Items.Add(br["kelas_nama"].ToString());
            //}
            #endregion
            cbpelajaran.Items.Clear();
        }

        private void cbkelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Isi Combobox Pelajaran
            query = "SELECT DISTINCT(id_pelajaran) id, pelajaran_nama FROM tbl_jadwal LEFT JOIN tm_pelajaran ON tm_pelajaran.id=id_pelajaran " +
                "WHERE tahunajaran='" + cbtahunajaran.Text + "' AND id_guru=" + idguru + 
                " AND id_kelas="+listidkelas[cbkelas.SelectedIndex]+" ORDER BY pelajaran_nama ASC";
            cbpelajaran.Items.Clear();
            listidpelajaran.Clear();
            //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    listidpelajaran.Add(br["id"].ToString());
            //    cbpelajaran.Items.Add(br["pelajaran_nama"].ToString());
            //}
            #endregion
        }

        private void tbketnilai_Leave(object sender, EventArgs e)
        {
            loaddb();
        }

        private void dgnilai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == DB.GetColumnIndexByHeader(dgnilai, "INPUT"))
            //{
            //    if (dgnilai.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgnilai, "INPUT")].Value.ToString() == "HAPUS")
            //    {
            //        if (MessageBox.Show("Yakin hapus nilai?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            //        {
            //            query = "DELETE FROM tbl_nilai WHERE id_nilai=" + dgnilai.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgnilai, "ID NILAI")].Value.ToString(); ;
            //            DM.ManipulasiData(query);
            //        }
            //    }
            //    else
            //    {
            //        query = "SELECT id_ruangan FROM tbl_ruangan WHERE id_siswa=" + dgnilai.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgnilai, "ID SISWA")].Value.ToString()+
            //        " AND id_kelas=" + listidkelas[cbkelas.SelectedIndex]+" LIMIT 1";
            //        idruangan = DM.singeldata(query) ;
            //        string values = dgnilai.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgnilai, "NILAI")].Value.ToString();
            //        if (StringExtensions.InputBox("Input", "Nilai", ref values) == DialogResult.OK)
            //        {
            //            query = "INSERT INTO tbl_nilai (nilai, id_jadwal, id_ruangan, id_jenisnilai, tahunajaran, ketnilai,tgl) " +
            //                "VALUES ( "+values+", "+idjadwal+", "+idruangan+", "+listidjenisnilai[cbjenisnilai.SelectedIndex]+
            //                ", '"+cbtahunajaran.Text+"', '"+tbketnilai.Text+"', '"+dtptgl.Value.ToString("yyyy-MM-dd HH:mm:ss")+"')";
            //            DM.ManipulasiData(query);
            //        }
            //    }
            //    loaddb();
            //}
            //else if (e.ColumnIndex == DB.GetColumnIndexByHeader(dgnilai, "KETERANGAN"))
            //{
            //    string values = dgnilai.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgnilai, "KETERANGAN")].Value.ToString();
            //    if (dgnilai.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgnilai, "INPUT")].Value.ToString() == "HAPUS")
            //    {
            //        if (StringExtensions.InputTextBox("Input", "Keterangan", ref values) == DialogResult.OK)
            //        {
            //            query = "UPDATE tbl_nilai SET ketsiswa='" + values + "' WHERE id_nilai=" + dgnilai.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgnilai, "ID NILAI")].Value.ToString();
            //            DM.ManipulasiData(query);
            //            dgnilai.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgnilai, "KETERANGAN")].Value = values;
            //        }
            //    }
            //    else
            //        MessageBox.Show("Tidak dapet memberi keterangan ketika nilai belum di berikan!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void cbpelajaran_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            query = "SELECT id_jadwal FROM tbl_jadwal WHERE tahunajaran='" +cbtahunajaran.Text+
                "' AND id_guru=" +idguru+
                " AND id_kelas=" +listidkelas[cbkelas.SelectedIndex]+
                " AND id_pelajaran="+listidpelajaran[cbpelajaran.SelectedIndex]+" LIMIT 1";
            //idjadwal = DM.singeldata(query);

            loaddb();
        }

        private void FInputNilai_Load(object sender, EventArgs e)
        {
            #region Isi data informasi pengajar
            //query = "SELECT * FROM tm_guru WHERE id=" + Properties.Settings.Default.useridacces;
            //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    idguru = br["id"].ToString();
            //    namaguru = br["guru_nama"].ToString();
            //    nip = br["guru_nip"].ToString();
            //    kelamin = br["guru_jk"].ToString();
            //}
            if(kelamin=="L")
            linformasi.Text = "BAPAK "+namaguru.ToUpper()+" NIP "+ nip;
            else
            linformasi.Text = "IBU "+namaguru.ToUpper()+" NIP "+ nip;
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
            query="SELECT * FROM tm_jenisnilai ORDER BY jenisnilai_nama ASC";
            //foreach(DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    listidjenisnilai.Add(br["id"].ToString());
            //    cbjenisnilai.Items.Add(br["jenisnilai_nama"].ToString());
            //}
            #endregion
        }

        private void loaddb()
        {
            if (cbpelajaran.SelectedIndex >= 0 && cbkelas.SelectedIndex >= 0 && 
                cbjenisnilai.SelectedIndex>=0 && cbtahunajaran.SelectedIndex >= 0)
            {
                dgnilai.Rows.Clear();
                query = "SELECT IF(IFNULL(id_nilai,0)>0,1,0) dapat, siswa_nama, siswa_nis, siswa_jk, tbl_ruangan.id_siswa, tbl_ruangan.id_ruangan, " +
                    "IFNULL(id_nilai, 0) id_nilai, IFNULL(nilai, 0) nilai,IFNULL(tgl,'-') tgl, ketnilai, ketsiswa, IFNULL(id_jadwal, 0) id_jadwal " +
                    "FROM tbl_ruangan LEFT JOIN tm_siswa ON tbl_ruangan.id_siswa = tm_siswa.id " +
                    "LEFT JOIN (SELECT * FROM tbl_nilai WHERE id_jenisnilai=" + listidjenisnilai[cbjenisnilai.SelectedIndex] +
                    " AND id_jadwal=" +idjadwal+
                    ") tbl_nilai ON tbl_nilai.id_ruangan = tbl_ruangan.id_ruangan " +
                    "WHERE tbl_ruangan.id_kelas = "+listidkelas[cbkelas.SelectedIndex]+ 
                    " AND tbl_ruangan.tahunajaran = '" + cbtahunajaran.Text+"'";
                //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
                //{
                //    string dapat = "BERI";
                //    if (Convert.ToUInt32(br["dapat"].ToString()) == 1)
                //        dapat = "HAPUS";
                //    dgnilai.Rows.Add(dapat, cbjenisnilai.Text, br["nilai"].ToString(), br["ketsiswa"].ToString(), 
                //        br["id_siswa"].ToString(), br["siswa_nama"].ToString(), br["siswa_nis"].ToString(), 
                //        br["siswa_jk"].ToString(), cbkelas.Text, cbpelajaran.Text,namaguru,
                //        br["tgl"], br["ketnilai"].ToString(), br["id_ruangan"].ToString(), br["id_jadwal"].ToString(),
                //        br["id_nilai"].ToString());
                //}
            }
        }
    }
}
