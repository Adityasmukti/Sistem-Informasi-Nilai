using System;
using System.Data;
using System.Windows.Forms;

namespace Project_SINS.Master
{
    public partial class FInputSiswa : Form
    {
        public FInputSiswa()
        {
            InitializeComponent();
            this.Text = "TAMBAH";
            IdSiswa = "0";
        }

        private string query = "";
        private string IdSiswa = "";
        ModulData DM = new ModulData();
        public FInputSiswa(string idsiswa)
        {
            InitializeComponent();
            IdSiswa = idsiswa;
            this.Text = "UBAH";
        }

        private void bsimpan_Click(object sender, EventArgs e)
        {
            if (this.Text == "TAMBAH")
            {
                if (tbanama.Text == "" || tbnis.Text=="" || tbalamat.Text=="")
                    MessageBox.Show("Tidak Boleh ada yang kosong!!");
                else if (cbjk.SelectedIndex<0)
                    MessageBox.Show("Tidak Boleh ada yang kosong!!");
                else
                {
                    query = "INSERT INTO tm_siswa (siswa_nama, siswa_nis, siswa_jk, siswa_alamat, siswa_tempatlahir, " +
                        "siswa_tanggallahir, siswa_tanggalmasuk) VALUES ('" +
                        tbanama.Text + "', '" +
                        tbnis.Text + "', '" +
                        cbjk.Text + "', '" +
                        tbalamat.Text + "', '" +
                        tbtempatlahir.Text + "', '" +
                        dtptgllahir.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                        dtptglmasuk.Value.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                    DM.ManipulasiData(query);
                    MessageBox.Show("Data Tersimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if( MessageBox.Show("Simpan perubahan yang telah dibuat?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    query = "UPDATE tm_siswa SET siswa_nama='"+tbanama.Text+"', siswa_nis='"+tbnis.Text+
                        "', siswa_jk='"+cbjk.Text+"', siswa_alamat='"+tbalamat.Text+"', siswa_tempatlahir='"+tbtempatlahir+"', " +
                        "siswa_tanggallahir='"+dtptgllahir.Value.ToString("yyyy-MM-dd HH:mm:ss")+
                        "', siswa_tanggalmasuk='"+dtptglmasuk.Value.ToString("yyyy-MM-dd HH:mm:ss") +"' WHERE id=" + IdSiswa;
                    DM.ManipulasiData(query);
                    Close();
                }
            }
        }

        private void bbatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FInputSiswa_Load(object sender, EventArgs e)
        {
            if(IdSiswa!="0")
            {
                query = "SELECT * FROM tm_siswa WHERE id="+IdSiswa;
                foreach(DataRow br in DM.GetData(query).Tables[0].Rows)
                {
                    tbanama.Text = br["siswa_nama"].ToString();
                    tbnis.Text = br["siswa_nis"].ToString();
                    tbalamat.Text = br["siswa_alamat"].ToString();
                    cbjk.SelectedIndex = cbjk.FindStringExact(br["siswa_jk"].ToString());
                    tbtempatlahir.Text = br["siswa_tempatlahir"].ToString();
                    dtptgllahir.Value = DateTime.Parse(br["siswa_tanggallahir"].ToString());
                    dtptglmasuk.Value = DateTime.Parse(br["siswa_tanggalmasuk"].ToString());
                }
            }
        }
    }
}
