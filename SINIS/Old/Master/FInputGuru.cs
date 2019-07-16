using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_SINS.Master
{
    public partial class FInputGuru : Form
    {
        private string IdGuru = "0";
        private string idakses = "";
        private string query = "";
        private ModulData DM = new ModulData();
        public FInputGuru()
        {
            InitializeComponent();
            IdGuru = "0";
            this.Text = "TAMBAH";

        }

        public FInputGuru(string idguru)
        {
            InitializeComponent();
            IdGuru = idguru;
            this.Text = "UBAH";
        }

        private void FInputGuru_Load(object sender, EventArgs e)
        {
            isicombobox();
            if (IdGuru != "0")
            {
                query = "SELECT id, user_akses FROM tm_user WHERE (user_akses='ADMIN' OR user_akses='GURU') AND user_idacc=" + IdGuru;
                foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
                {
                    idakses = br[0].ToString();
                    cbhakakses.SelectedIndex = cbhakakses.FindStringExact(br[1].ToString());
                }

                query = "SELECT * FROM tm_guru WHERE id=" + IdGuru;
                foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
                {
                    tbnama.Text = br["guru_nama"].ToString();
                    tbnuptk.Text = br["guru_nuptk"].ToString();
                    tbnip.Text = br["guru_nip"].ToString();
                    cbjk.SelectedIndex = cbjk.FindStringExact(br["guru_jk"].ToString());
                    tbalamat.Text = br["guru_alamat"].ToString();
                    tbkontak.Text = br["guru_kontak"].ToString();
                    tbtempatlahir.Text = br["guru_tempatlahir"].ToString();
                    dtptgllahir.Value = DateTime.Parse(br["guru_tanggallahir"].ToString());
                    cbkepegawaian.SelectedIndex = cbkepegawaian.FindStringExact(br["guru_statuspegawai"].ToString());
                    cbsptk.SelectedIndex = cbsptk.FindStringExact(br["guru_jenisptk"].ToString());
                }
            }
        }

        private void isicombobox()
        {
            query = "SELECT DISTINCT(guru_statuspegawai) FROM tm_guru WHERE deleted=0";
            cbkepegawaian.Items.Clear();
            foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            {
                if (br[0].ToString() != "")
                    cbkepegawaian.Items.Add(br[0].ToString());
            }
            cbkepegawaian.SelectedIndex = -1;

            query = "SELECT DISTINCT(guru_jenisptk) FROM tm_guru WHERE deleted=0";
            cbsptk.Items.Clear();
            foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            {
                if (br[0].ToString() != "")
                    cbsptk.Items.Add(br[0].ToString());
            }
            cbsptk.SelectedIndex = -1;

            cbhakakses.SelectedIndex = 0;
        }

        private void bsimpan_Click(object sender, EventArgs e)
        {

            if (this.Text == "TAMBAH")
            {
                if (tbnama.Text == "" || tbnuptk.Text == "" || tbnip.Text == "" || tbkontak.Text == "" || tbalamat.Text == "")
                    MessageBox.Show("Tidak Boleh ada yang kosong!!");
                else if (cbjk.SelectedIndex < 0)
                    MessageBox.Show("Tidak Boleh ada yang kosong!!");
                else
                {
                    IdGuru = DM.singeldata("SELECT MAX(id)+1 FROM tm_guru");

                    query = "INSERT INTO tm_guru (id, guru_nama, guru_nuptk, guru_nip, guru_jk, guru_alamat, guru_kontak" +
                        ", guru_tempatlahir, guru_tanggallahir, guru_statuspegawai, guru_jenisptk) VALUES (" + IdGuru + ", '" +
                        tbnama.Text + "', '" + tbnuptk.Text + "', '" + tbnip.Text + "', '" + cbjk.Text + "','" +
                        tbalamat.Text + "','" + tbkontak.Text + "', '" + tbtempatlahir.Text + "', '" + dtptgllahir.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" +
                        cbkepegawaian.Text + "', '" + cbsptk.Text + "');" +
                        "INSERT INTO tm_user (user_akses, user_name, user_idacc, user_pwd) VALUES ('" + cbhakakses.Text +
                        "', '" + tbnip.Text + "'," + IdGuru + ", MD5('123456'))";
                    DM.ManipulasiData(query);
                    MessageBox.Show("Data Tersimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IdGuru = "0";
                    isicombobox();
                }
            }
            else
            {
                if (MessageBox.Show("Simpan perubahan yang telah dibuat?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = "UPDATE tm_guru SET guru_nama='" + tbnama.Text + "', " +
                        "guru_nuptk='" + tbnuptk.Text + "', " +
                        "guru_nip='" + tbnip.Text + "', " +
                        "guru_jk='" + cbjk.Text + "', " +
                        "guru_alamat='" + tbalamat.Text + "', " +
                        "guru_kontak='" + tbkontak.Text + "', " +
                        "guru_tempatlahir='" + tbtempatlahir.Text + "', " +
                        "guru_tanggallahir='" + dtptgllahir.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                        "guru_statuspegawai='" + cbkepegawaian.Text + "', " +
                        "guru_jenisptk='" + cbsptk.Text + "' WHERE id=" + IdGuru + ";" +
                        "UPDATE tm_user SET user_akses='" + cbhakakses.Text + "' WHERE id=" + idakses;
                    DM.ManipulasiData(query);
                    Close();
                }
            }
        }

        private void bbatal_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
