using System;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace Project_SINS.Master
{
    public partial class Master : Form
    {
        private string query = "";
        public Master()
        {
            InitializeComponent();
        }

        private void loaddb()
        {
            int indextab = tabControl1.SelectedIndex;
            //KELAS
            if(indextab==0)
            {
                dgkelas.Rows.Clear();
                query = "SELECT * FROM tm_kelas WHERE kelas_nama LIKE '"+tbcarikelas.Text+"%' ORDER BY kelas_nama ASC";
                foreach(DataRow br in query.GetData().Rows)
                {
                    dgkelas.Rows.Add(br["id"].ToString(), br["kelas_nama"].ToString());
                }
            }
            //PELAJARAN
            else if (indextab == 1)
            {
                dgpelajaran.Rows.Clear();
                query = "SELECT * FROM tm_pelajaran WHERE pelajaran_nama LIKE '"+tbcaripelajaran.Text+"%' ORDER BY pelajaran_nama ASC";
                
            }
            //GURU
            else if (indextab == 2)
            {
                dgguru.Rows.Clear();
                query = "SELECT *, (SELECT user_akses FROM tm_user WHERE tm_guru.id=user_idacc) akses " +
                    "FROM tm_guru WHERE deleted=0 AND (guru_nama LIKE '%"+tbcariguru.Text+
                    "%' OR guru_nuptk LIKE '" + tbcariguru.Text +
                    "%' OR guru_nip LIKE '" + tbcariguru.Text +
                    "%' OR guru_kontak LIKE '" + tbcariguru.Text + "%') ORDER BY guru_nama ASC";
                dgguru.QueriToDg();
            }
            //SISWA
            else if (indextab == 3)
            {
                dgsiswa.Rows.Clear();
                query = "SELECT * FROM tm_siswa WHERE deleted=0 AND siswa_tanggalmasuk LIKE '"+cbtahunsiswa.Text+
                    "%' AND (siswa_nama LIKE '%"+tbcarisiswa.Text+
                    "%' OR siswa_nis LIKE '%" + tbcarisiswa.Text + "%' ) ORDER BY siswa_nama ASC";
               
            }
            else if(indextab==4)
            {
                dgjenisnilai.Rows.Clear();
                query = "SELECT * FROM tm_jenisnilai WHERE jenisnilai_nama LIKE '"+tbcarijenisnilai.Text+"%'";
               
            }
        }

        private void Master_Load(object sender, EventArgs e)
        {
            query = "SELECT LEFT(MIN(siswa_tanggalmasuk),4) FROM tm_siswa WHERE deleted=0";
            int nows = int.Parse(DateTime.Now.ToString("yyyy"));
            int tahun = nows;
            try
            {
                string hasil = query.SingelData();
                if (hasil != "")
                    tahun = int.Parse(hasil);
            }
            catch (Exception) { }

            cbtahunsiswa.Items.Clear();
            while (nows>=tahun)
            {
                cbtahunsiswa.Items.Add(nows);
                nows--;
            }
            cbtahunsiswa.SelectedIndex = 0;

            loaddb();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void Master_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Master_Activated(object sender, EventArgs e)
        {
            loaddb();
        }

        #region kelas
        private void bsimpankelas_Click(object sender, EventArgs e)
        {
            //if (gbtambahkelas.Text == "TAMBAH")
            //{
            //    query = "INSERT INTO tm_kelas (kelas_nama) VALUES ('" + tbtambahkelas.Text + "')";
            //    query.ManipulasiData();
            //    MessageBox.Show("Kelas Telah Tersimpan!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    loaddb();
            //}
            //else
            //{
            //    query = "UPDATE tm_kelas SET kelas_nama='" + tbtambahkelas.Text + "' WHERE id=" +
            //        dgkelas.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgkelas, "ID KELAS")].Value.ToString();
            //    DM.ManipulasiData(query);
            //    dgkelas.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgkelas, "KELAS")].Value = tbtambahkelas.Text;
            //    dgkelas.Enabled = true;
            //    gbtambahkelas.Text = "TAMBAH";
            //    MessageBox.Show("Kelas Telah Diubah!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //tbtambahkelas.Clear();
        }

        private void tbcarikelas_TextChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void dgkelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.ColumnIndex==DB.GetColumnIndexByHeader(dgkelas, "UBAH"))
            //{
            //    gbtambahkelas.Text = "UBAH";
            //    tbtambahkelas.Text = dgkelas.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgkelas,"KELAS")].Value.ToString();
            //    dgkelas.Enabled = false;
            //}
            //else if(e.ColumnIndex == DB.GetColumnIndexByHeader(dgkelas, "HAPUS"))
            //{
            //    string id = dgkelas.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgkelas, "ID KELAS")].Value.ToString();
            //    if (MessageBox.Show("Hapus Data?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            //    {
            //        query = "DELETE FROM tm_kelas WHERE id="+id ;
            //        DM.ManipulasiData(query);
            //        loaddb();
            //        MessageBox.Show("Data di hapus!", "Informasi", MessageBoxButtons.OK , MessageBoxIcon.Information);
            //    }
            //}
        }
        #endregion

        #region pelajaran
        private void bsimpanpelajaran_Click(object sender, EventArgs e)
        {
            if (gbtambahpelajaran.Text == "TAMBAH")
            {
                query = "INSERT INTO tm_pelajaran (pelajaran_nama) VALUES ('" + tbtambahpelajaran.Text + "')";
                query.ManipulasiData();
                loaddb();
                MessageBox.Show("Pelajaran Telah Tersimpan!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                query = "UPDATE tm_pelajaran SET pelajaran_kelas='" + tbtambahpelajaran.Text + "' WHERE id=" +
                    dgpelajaran.CurrentRow.Cells[dgpelajaran.GetColumnIndexByHeader("ID PELAJARAN")].Value.ToString();
                query.ManipulasiData();
                dgpelajaran.Enabled = true;
                gbtambahpelajaran.Text = "TAMBAH";
                dgpelajaran.CurrentRow.Cells[dgpelajaran.GetColumnIndexByHeader("PELAJARAN")].Value = tbtambahpelajaran.Text;
                MessageBox.Show("Pelajaran Telah Diubah!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tbtambahpelajaran.Clear();
        }

        private void tbcaripelajaran_TextChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void dgpelajaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == DB.GetColumnIndexByHeader(dgpelajaran, "UBAH"))
            //{
            //    gbtambahpelajaran.Text = "UBAH";
            //    tbtambahpelajaran.Text = dgpelajaran.CurrentRow.Cells[dgpelajaran.GetColumnIndexByHeader("PELAJARAN")].Value.ToString();
            //    dgpelajaran.Enabled = false;
            //}
            //else if (e.ColumnIndex == DB.GetColumnIndexByHeader(dgpelajaran, "HAPUS"))
            //{
            //    string id = dgpelajaran.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgpelajaran, "ID PELAJARAN")].Value.ToString();
            //    if (MessageBox.Show("Hapus Data?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        query = "DELETE FROM tm_pelajaran WHERE id=" +id;
            //        DM.ManipulasiData(query);
            //        loaddb();
            //        MessageBox.Show("Data di hapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }
        #endregion

        #region Guru
        private void tbcariguru_TextChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void dgguru_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == DB.GetColumnIndexByHeader(dgguru, "UBAH"))
            //{
            //    FInputGuru f = new FInputGuru(dgguru.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgguru, "ID GURU")].Value.ToString());
            //    f.ShowDialog();
            //}
            //else if (e.ColumnIndex == DB.GetColumnIndexByHeader(dgguru, "HAPUS"))
            //{
            //    if (MessageBox.Show("Hapus Data?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        string akses = dgguru.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgguru, "HAK AKSES")].Value.ToString();
            //        query = "SELECT COUNT(user_akses) FROM tm_user WHERE deleted=0 AND user_akses='ADMIN' ";
            //        string adminada = DM.singeldata(query);
            //        if (adminada == "1" && akses == "ADMIN")
            //        {
            //            MessageBox.Show("Tidak dapat Hapus user dengan akses ADMIN jika hanya 1 orang!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            query = "UPDATE tm_guru SET deleted=1 WHERE id=" +
            //                dgguru.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgguru, "ID GURU")].Value.ToString() +
            //                "; UPDATE tm_user SET deleted=1 WHERE user_idacc=" +
            //                dgguru.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgguru, "ID GURU")].Value.ToString() +
            //                " AND (user_akses = 'GURU' OR user_akses = 'ADMIN');";

            //            DM.ManipulasiData(query);
            //            loaddb();
            //            MessageBox.Show("Data di hapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //}
        }

        private void btambahguru_Click(object sender, EventArgs e)
        {
            //FInputGuru f = new FInputGuru();
            //f.ShowDialog();
        }
        #endregion

        #region siswa
        private void tbcarisiswa_TextChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void btambahsiswa_Click(object sender, EventArgs e)
        {
            //FInputSiswa f = new FInputSiswa();
            //f.ShowDialog();
        }

        private void dgsiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == DB.GetColumnIndexByHeader(dgsiswa, "UBAH"))
            //{
            //    FInputSiswa f = new FInputSiswa(dgsiswa.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgsiswa, "ID SISWA")].Value.ToString());
            //    f.ShowDialog();
            //}
            //else if (e.ColumnIndex == DB.GetColumnIndexByHeader(dgsiswa, "HAPUS"))
            //{
            //    string id = dgsiswa.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgsiswa, "ID SISWA")].Value.ToString();
            //    if (MessageBox.Show("Hapus Data?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        query = "UPDATE tm_siswa SET deleted=1 WHERE id=" +id;
            //        DM.ManipulasiData(query);
            //        loaddb();
            //        MessageBox.Show("Data di hapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }
        #endregion

        #region Jenis Nilai
        private void bsimpanjenisnilai_Click(object sender, EventArgs e)
        {
            //if (gbtambahjenisnilai.Text == "TAMBAH")
            //{
            //    query = "INSERT INTO tm_jenisnilai (jenisnilai_nama) VALUES ('" + tbsimpanjenisnilai.Text + "')";
            //    DM.ManipulasiData(query);
            //    loaddb();
            //    MessageBox.Show("Jenis Nilai Telah Tersimpan!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    query = "UPDATE tm_kelas SET kelas_nama='" + tbsimpanjenisnilai.Text + "' WHERE id=" +
            //        dgjenisnilai.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgjenisnilai, "ID JENIS NILAI")].Value.ToString();
            //    DM.ManipulasiData(query);
            //    dgjenisnilai.Enabled = true;
            //    gbtambahjenisnilai.Text = "TAMBAH";
            //    dgjenisnilai.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgjenisnilai, "JENIS NILAI")].Value = tbsimpanjenisnilai.Text;
            //    MessageBox.Show("Jenis Nilai Telah Diubah!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //tbsimpanjenisnilai.Clear();
        }

        private void tbcarijenisnilai_TextChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void dgjenisnilai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == DB.GetColumnIndexByHeader(dgjenisnilai, "UBAH"))
            //{
            //    gbtambahjenisnilai.Text = "UBAH";
            //    tbsimpanjenisnilai.Text = dgjenisnilai.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgjenisnilai, "JENIS NILAI")].Value.ToString();
            //    dgjenisnilai.Enabled = false;
            //}
            //else if (e.ColumnIndex == DB.GetColumnIndexByHeader(dgjenisnilai, "HAPUS"))
            //{

            //    string idnilai = dgjenisnilai.CurrentRow.Cells[DB.GetColumnIndexByHeader(dgjenisnilai, "ID JENIS NILAI")].Value.ToString();
            //    if (idnilai == "1")
            //    {
            //        MessageBox.Show("Id Jenis Nilai 1 tidak dapat di hapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        if (MessageBox.Show("Hapus Data?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            query = "DELETE FROM tm_jenisnilai WHERE id=" + idnilai;
            //            DM.ManipulasiData(query);
            //            loaddb();
            //            MessageBox.Show("Data di hapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //}
        }
        #endregion
    }
}
