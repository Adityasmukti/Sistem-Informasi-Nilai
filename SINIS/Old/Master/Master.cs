using System;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace Project_SINS.Master
{
    public partial class Master : Form
    {
        private string query = "";
        private ModulData DM = new ModulData();
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
                foreach(DataRow br in DM.GetData(query).Tables[0].Rows)
                {
                    dgkelas.Rows.Add(br["id"].ToString(), br["kelas_nama"].ToString());
                }
            }
            //PELAJARAN
            else if (indextab == 1)
            {
                dgpelajaran.Rows.Clear();
                query = "SELECT * FROM tm_pelajaran WHERE pelajaran_nama LIKE '"+tbcaripelajaran.Text+"%' ORDER BY pelajaran_nama ASC";
                foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
                {
                    dgpelajaran.Rows.Add(br["id"].ToString(),br["pelajaran_nama"].ToString());
                }
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
                foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
                {
                    dgguru.Rows.Add(br["id"].ToString(), br["guru_nama"].ToString(), br["guru_nuptk"].ToString(), 
                        br["guru_nip"].ToString(), br["guru_jk"].ToString(), br["guru_tempatlahir"].ToString(),
                        br["guru_tanggallahir"], br["guru_statuspegawai"].ToString(), br["guru_jenisptk"].ToString(), 
                        br["guru_alamat"].ToString(), br["guru_kontak"].ToString(), br["akses"].ToString());
                }
            }
            //SISWA
            else if (indextab == 3)
            {
                dgsiswa.Rows.Clear();
                query = "SELECT * FROM tm_siswa WHERE deleted=0 AND siswa_tanggalmasuk LIKE '"+cbtahunsiswa.Text+
                    "%' AND (siswa_nama LIKE '%"+tbcarisiswa.Text+
                    "%' OR siswa_nis LIKE '%" + tbcarisiswa.Text + "%' ) ORDER BY siswa_nama ASC";
                foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
                {
                    dgsiswa.Rows.Add(br["id"].ToString(), br["siswa_nama"].ToString(), br["siswa_nis"].ToString(),
                        br["siswa_jk"].ToString(), br["siswa_tempatlahir"].ToString(), br["siswa_tanggallahir"], 
                        br["siswa_alamat"].ToString(), br["siswa_tanggalmasuk"]);
                }
            }
            else if(indextab==4)
            {
                dgjenisnilai.Rows.Clear();
                query = "SELECT * FROM tm_jenisnilai WHERE jenisnilai_nama LIKE '"+tbcarijenisnilai.Text+"%'";
                foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
                {
                    dgjenisnilai.Rows.Add(br["id"].ToString(), br["jenisnilai_nama"].ToString());
                }
            }
        }

        private void Master_Load(object sender, EventArgs e)
        {
            query = "SELECT LEFT(MIN(siswa_tanggalmasuk),4) FROM tm_siswa WHERE deleted=0";
            int nows = int.Parse(DateTime.Now.ToString("yyyy"));
            int tahun = nows;
            try
            {
                string hasil = DM.singeldata(query);
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

            tabControl1.SelectedIndex=Properties.Settings.Default.mastertabcontrolidx;

            loaddb();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void Master_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.mastertabcontrolidx = tabControl1.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void Master_Activated(object sender, EventArgs e)
        {
            loaddb();
        }

        #region kelas
        private void bsimpankelas_Click(object sender, EventArgs e)
        {
            if (gbtambahkelas.Text == "TAMBAH")
            {
                query = "INSERT INTO tm_kelas (kelas_nama) VALUES ('" + tbtambahkelas.Text + "')";
                DM.ManipulasiData(query);
                MessageBox.Show("Kelas Telah Tersimpan!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddb();
            }
            else
            {
                query = "UPDATE tm_kelas SET kelas_nama='" + tbtambahkelas.Text + "' WHERE id=" +
                    dgkelas.CurrentRow.Cells[DB.GetColumnIndexByName(dgkelas, "ID KELAS")].Value.ToString();
                DM.ManipulasiData(query);
                dgkelas.CurrentRow.Cells[DB.GetColumnIndexByName(dgkelas, "KELAS")].Value = tbtambahkelas.Text;
                dgkelas.Enabled = true;
                gbtambahkelas.Text = "TAMBAH";
                MessageBox.Show("Kelas Telah Diubah!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tbtambahkelas.Clear();
        }

        private void tbcarikelas_TextChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void dgkelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==DB.GetColumnIndexByName(dgkelas, "UBAH"))
            {
                gbtambahkelas.Text = "UBAH";
                tbtambahkelas.Text = dgkelas.CurrentRow.Cells[DB.GetColumnIndexByName(dgkelas,"KELAS")].Value.ToString();
                dgkelas.Enabled = false;
            }
            else if(e.ColumnIndex == DB.GetColumnIndexByName(dgkelas, "HAPUS"))
            {
                string id = dgkelas.CurrentRow.Cells[DB.GetColumnIndexByName(dgkelas, "ID KELAS")].Value.ToString();
                if (MessageBox.Show("Hapus Data?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    query = "DELETE FROM tm_kelas WHERE id="+id ;
                    DM.ManipulasiData(query);
                    loaddb();
                    MessageBox.Show("Data di hapus!", "Informasi", MessageBoxButtons.OK , MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region pelajaran
        private void bsimpanpelajaran_Click(object sender, EventArgs e)
        {
            if (gbtambahpelajaran.Text == "TAMBAH")
            {
                query = "INSERT INTO tm_pelajaran (pelajaran_nama) VALUES ('" + tbtambahpelajaran.Text + "')";
                DM.ManipulasiData(query);
                loaddb();
                MessageBox.Show("Pelajaran Telah Tersimpan!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                query = "UPDATE tm_pelajaran SET pelajaran_kelas='" + tbtambahpelajaran.Text + "' WHERE id=" +
                    dgpelajaran.CurrentRow.Cells[DB.GetColumnIndexByName(dgpelajaran, "ID PELAJARAN")].Value.ToString();
                DM.ManipulasiData(query);
                dgpelajaran.Enabled = true;
                gbtambahpelajaran.Text = "TAMBAH";
                dgpelajaran.CurrentRow.Cells[DB.GetColumnIndexByName(dgpelajaran, "PELAJARAN")].Value = tbtambahpelajaran.Text;
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
            if (e.ColumnIndex == DB.GetColumnIndexByName(dgpelajaran, "UBAH"))
            {
                gbtambahpelajaran.Text = "UBAH";
                tbtambahpelajaran.Text = dgpelajaran.CurrentRow.Cells[DB.GetColumnIndexByName(dgpelajaran, "PELAJARAN")].Value.ToString();
                dgpelajaran.Enabled = false;
            }
            else if (e.ColumnIndex == DB.GetColumnIndexByName(dgpelajaran, "HAPUS"))
            {
                string id = dgpelajaran.CurrentRow.Cells[DB.GetColumnIndexByName(dgpelajaran, "ID PELAJARAN")].Value.ToString();
                if (MessageBox.Show("Hapus Data?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = "DELETE FROM tm_pelajaran WHERE id=" +id;
                    DM.ManipulasiData(query);
                    loaddb();
                    MessageBox.Show("Data di hapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region Guru
        private void tbcariguru_TextChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void dgguru_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DB.GetColumnIndexByName(dgguru, "UBAH"))
            {
                FInputGuru f = new FInputGuru(dgguru.CurrentRow.Cells[DB.GetColumnIndexByName(dgguru, "ID GURU")].Value.ToString());
                f.ShowDialog();
            }
            else if (e.ColumnIndex == DB.GetColumnIndexByName(dgguru, "HAPUS"))
            {
                if (MessageBox.Show("Hapus Data?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string akses = dgguru.CurrentRow.Cells[DB.GetColumnIndexByName(dgguru, "HAK AKSES")].Value.ToString();
                    query = "SELECT COUNT(user_akses) FROM tm_user WHERE deleted=0 AND user_akses='ADMIN' ";
                    string adminada = DM.singeldata(query);
                    if (adminada == "1" && akses == "ADMIN")
                    {
                        MessageBox.Show("Tidak dapat Hapus user dengan akses ADMIN jika hanya 1 orang!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        query = "UPDATE tm_guru SET deleted=1 WHERE id=" +
                            dgguru.CurrentRow.Cells[DB.GetColumnIndexByName(dgguru, "ID GURU")].Value.ToString() +
                            "; UPDATE tm_user SET deleted=1 WHERE user_idacc=" +
                            dgguru.CurrentRow.Cells[DB.GetColumnIndexByName(dgguru, "ID GURU")].Value.ToString() +
                            " AND (user_akses = 'GURU' OR user_akses = 'ADMIN');";

                        DM.ManipulasiData(query);
                        loaddb();
                        MessageBox.Show("Data di hapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btambahguru_Click(object sender, EventArgs e)
        {
            FInputGuru f = new FInputGuru();
            f.ShowDialog();
        }
        #endregion

        #region siswa
        private void tbcarisiswa_TextChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void btambahsiswa_Click(object sender, EventArgs e)
        {
            FInputSiswa f = new FInputSiswa();
            f.ShowDialog();
        }

        private void dgsiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DB.GetColumnIndexByName(dgsiswa, "UBAH"))
            {
                FInputSiswa f = new FInputSiswa(dgsiswa.CurrentRow.Cells[DB.GetColumnIndexByName(dgsiswa, "ID SISWA")].Value.ToString());
                f.ShowDialog();
            }
            else if (e.ColumnIndex == DB.GetColumnIndexByName(dgsiswa, "HAPUS"))
            {
                string id = dgsiswa.CurrentRow.Cells[DB.GetColumnIndexByName(dgsiswa, "ID SISWA")].Value.ToString();
                if (MessageBox.Show("Hapus Data?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = "UPDATE tm_siswa SET deleted=1 WHERE id=" +id;
                    DM.ManipulasiData(query);
                    loaddb();
                    MessageBox.Show("Data di hapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region Jenis Nilai
        private void bsimpanjenisnilai_Click(object sender, EventArgs e)
        {
            if (gbtambahjenisnilai.Text == "TAMBAH")
            {
                query = "INSERT INTO tm_jenisnilai (jenisnilai_nama) VALUES ('" + tbsimpanjenisnilai.Text + "')";
                DM.ManipulasiData(query);
                loaddb();
                MessageBox.Show("Jenis Nilai Telah Tersimpan!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                query = "UPDATE tm_kelas SET kelas_nama='" + tbsimpanjenisnilai.Text + "' WHERE id=" +
                    dgjenisnilai.CurrentRow.Cells[DB.GetColumnIndexByName(dgjenisnilai, "ID JENIS NILAI")].Value.ToString();
                DM.ManipulasiData(query);
                dgjenisnilai.Enabled = true;
                gbtambahjenisnilai.Text = "TAMBAH";
                dgjenisnilai.CurrentRow.Cells[DB.GetColumnIndexByName(dgjenisnilai, "JENIS NILAI")].Value = tbsimpanjenisnilai.Text;
                MessageBox.Show("Jenis Nilai Telah Diubah!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tbsimpanjenisnilai.Clear();
        }

        private void tbcarijenisnilai_TextChanged(object sender, EventArgs e)
        {
            loaddb();
        }

        private void dgjenisnilai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DB.GetColumnIndexByName(dgjenisnilai, "UBAH"))
            {
                gbtambahjenisnilai.Text = "UBAH";
                tbsimpanjenisnilai.Text = dgjenisnilai.CurrentRow.Cells[DB.GetColumnIndexByName(dgjenisnilai, "JENIS NILAI")].Value.ToString();
                dgjenisnilai.Enabled = false;
            }
            else if (e.ColumnIndex == DB.GetColumnIndexByName(dgjenisnilai, "HAPUS"))
            {

                string idnilai = dgjenisnilai.CurrentRow.Cells[DB.GetColumnIndexByName(dgjenisnilai, "ID JENIS NILAI")].Value.ToString();
                if (idnilai == "1")
                {
                    MessageBox.Show("Id Jenis Nilai 1 tidak dapat di hapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Hapus Data?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = "DELETE FROM tm_jenisnilai WHERE id=" + idnilai;
                        DM.ManipulasiData(query);
                        loaddb();
                        MessageBox.Show("Data di hapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        #endregion
    }
}
