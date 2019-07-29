using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SINIS.TU
{
    public partial class FKelolaPengajaran : Form
    {
        private List<string> KodeGuru;
        public FKelolaPengajaran(Dictionary<string, string> data)
        {
            InitializeComponent();
            this.SetControlFrom();
            Loadawal();
            BHapus.Visible = false;

            string kodekelas = "", kodepelajaran="";
            foreach  (KeyValuePair<string, string> item in data)
            {
                if (item.Key.Equals("tahunajaran"))
                    TbTahunAjaran.Text = item.Value;
                else if (item.Key.Equals("kodekelas"))
                    kodekelas = item.Value;
                else if (item.Key.Equals("kelas"))
                    TbKelas.Text = item.Value;
                else if (item.Key.Equals("kodepelajaran"))
                    kodepelajaran = item.Value;
                else if (item.Key.Equals("kodemapel"))
                    TbKodeMapel.Text = item.Value;
                else if (item.Key.Equals("pelajaran"))
                    TbPelajaran.Text = item.Value;
            }

            BSimpan.Click += (sender, e) =>
            {
                if (string.IsNullOrEmpty(TbTahunAjaran.Text))
                    MessageBox.Show("Tahun ajaran kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(TbKelas.Text))
                    MessageBox.Show("Kelas kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(CbGuru.Text))
                    MessageBox.Show("Guru kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(TbKodeMapel.Text))
                    MessageBox.Show("Kode mapel kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (Dg.Rows.Count <= 0)
                    MessageBox.Show("Tabel kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string kodejadwal = A.GenerateKode("JD", "tb_jadwal", "kode_jadwal");
                    A.SetInsert("INSERT INTO `tb_jadwal` (`kode_jadwal`,`kode_guru`,`kode_kelas`,`kode_pelajaran`,`tahunajaran`,`keterangan`,`tanggal`,`id_user`) ");
                    A.SetValues("VALUES ('" + kodejadwal + "', '" + KodeGuru[CbGuru.SelectedIndex] + "', '" + kodekelas + "', '" + kodepelajaran + "', " +
                        "'" + TbTahunAjaran.Text + "', '" + TbKeterangan.StrEscape() + "', NOW(), '" + S.GetUserid() + "') ");
                    A.SetQueri(A.GetInsert() + A.GetValues() + ";");

                    foreach (DataGridViewRow b in Dg.Rows)
                    {
                        A.SetInsert("INSERT INTO `tb_waktupelajaran` (`kode_jadwal`,`totaljam`,`hari`,`waktu`,`id_user`,`tanggal`) ");
                        A.SetValues("VALUES ('" + kodejadwal + "', '" + CbJumlahJam.Text + "', '" + CbHari.Text + "', " +
                            "'" + CbJam.Text + ":" + CbMenit.Text + ":00', '" + S.GetUserid() + "', NOW()) ");
                        A.SetQueri(A.GetQueri() + A.GetInsert() + A.GetValues() + ";");
                    }

                    if (A.GetQueri().ManipulasiData())
                    {
                        MessageBox.Show("Jadwal telah tersimpan!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
            };

            Dg.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == Dg.GetColumnIndexByHeader("HAPUS"))
                    {
                        Dg.Rows.RemoveAt(e.RowIndex);
                    }
                }
            };
        }

        public FKelolaPengajaran(object kodejadwal)
        {
            List<string> deletelist = new List<string>();
            InitializeComponent();
            this.SetControlFrom();
            Loadawal();
            string kodekelas = "", kodepelajaran="";
            foreach (DataRow b in A.GetData("SELECT `tahunajaran`, `namakelas`, `kode_guru`, `kodemapel`, `namapelajaran`, " +
                "`J`.`keterangan`,`J`.`kode_kelas`, `kodepelajaran` FROM `tb_jadwal` `J` " +
                "LEFT JOIN `r_kelas` `K` ON `K`.`kode_kelas`=`J`.`kode_kelas` " +
                "LEFT JOIN `r_matapelajaran` `MP` ON `MP`.`kodepelajaran` =`J`.`kode_pelajaran` ").Rows)
            {
                TbTahunAjaran.Text = b["tahunajaran"].ToString();
                TbKelas.Text = b["namakelas"].ToString();
                CbGuru.SelectedIndex = KodeGuru.FindIndex(x=>x.Equals(b["kode_guru"].ToString()));
                TbKodeMapel.Text = b["kodemapel"].ToString();
                TbPelajaran.Text = b["namapelajaran"].ToString();
                TbKeterangan.Text = b["keterangan"].ToString();
                kodekelas = b["kode_kelas"].ToString();
                kodepelajaran = b["kodepelajaran"].ToString();
            }
            A.SetQueri("SELECT `idwaktupelajaran`, `hari`, `waktu`, `totaljam` FROM `tb_waktupelajaran` WHERE `kode_jadwal`='"+ kodejadwal + "';");
            Dg.QueriToDg();

            BSimpan.Click += (sender, e) =>
            {
                if (string.IsNullOrEmpty(TbTahunAjaran.Text))
                    MessageBox.Show("Tahun ajaran kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(TbKelas.Text))
                    MessageBox.Show("Kelas kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(CbGuru.Text))
                    MessageBox.Show("Guru kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(TbKodeMapel.Text))
                    MessageBox.Show("Kode mapel kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    A.SetInsert("INSERT INTO `tb_jadwal` (`kode_jadwal`,`kode_guru`,`kode_kelas`,`kode_pelajaran`,`tahunajaran`,`keterangan`,`tanggal`,`id_user`) ");
                    A.SetValues("VALUES ('" + kodejadwal + "', '" + KodeGuru[CbGuru.SelectedIndex] + "', '" + kodekelas + "', '" + kodepelajaran + "', " +
                        "'" + TbTahunAjaran.Text + "', '" + TbKeterangan.StrEscape() + "', NOW(), '" + S.GetUserid() + "') ");
                    A.SetQueri(A.GetInsert() + A.GetValues() + ";");

                    foreach (DataGridViewRow b in Dg.Rows)
                    {
                        if (b.Cells[0].Value.ToString().Equals("0"))
                        {
                            A.SetInsert("INSERT INTO `tb_waktupelajaran` (`kode_jadwal`,`totaljam`,`hari`,`waktu`,`id_user`,`tanggal`) ");
                            A.SetValues("VALUES ('" + kodejadwal + "', '" + CbJumlahJam.Text + "', '" + CbHari.Text + "', " +
                                "'" + CbJam.Text + ":" + CbMenit.Text + ":00', '" + S.GetUserid() + "', NOW()) ");
                            A.SetQueri(A.GetQueri() + A.GetInsert() + A.GetValues() + ";");
                        }
                        else
                        {
                            A.SetUpdate("UPDATE `tb_waktupelajaran` ");
                            A.SetValues("SET `totaljam` = '" + CbJumlahJam.Text + "', `hari` = '" + CbHari.Text + "', " +
                                "`waktu` = '" + CbJam.Text + ":" + CbMenit.Text + ":00' ");
                            A.SetWhere("WHERE `idwaktupelajaran` = '" + b.Cells[0].Value.ToString() + "' ");
                            A.SetQueri(A.GetQueri() + A.GetInsert() + A.GetValues() + ";");
                        }
                    }
                    foreach (var b in deletelist)
                    {
                        A.SetQueri(A.GetQueri() + "DELETE FROM `tb_jadwal` WHERE `idwaktupelajaran` = '" + b + "';");
                    }
                    if (A.GetQueri().ManipulasiData())
                    {
                        MessageBox.Show("Jadwal telah diubah!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
            };

            BHapus.Click += (sende, e) =>
            {
                if (MessageBox.Show("Menghapus seluruh data pengajaran??", "Pertanyaan", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    A.SetQueri("DELETE FROM `tb_waktupelajaran` WHERE `kode_jadwal` = '"+kodejadwal+"';");
                    A.SetQueri(A.GetQueri() + "DELETE FROM `tb_jadwal` WHERE `kode_jadwal` = '" + kodejadwal + "'; ") ;
                    A.GetQueri().DBHapus();
                }
            };

            Dg.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == Dg.GetColumnIndexByHeader("HAPUS"))
                    {
                        if (Dg.Rows[e.RowIndex].Cells["ID WAKTU"].Value.ToString() != "0")
                            deletelist.Add(Dg.Rows[e.RowIndex].Cells["ID WAKTU"].Value.ToString());
                        Dg.Rows.RemoveAt(e.RowIndex);
                    }
                }
            };
        }
        private void Loadawal()
        {
            KodeGuru = CbGuru.LoadGuru();
            CbHari.Items.Clear();
            CbHari.Items.Add("SENIN");
            CbHari.Items.Add("SELASA");
            CbHari.Items.Add("RABU");
            CbHari.Items.Add("KAMIS");
            CbHari.Items.Add("JUMAT");
            CbHari.Items.Add("SABTU");
            CbHari.Items.Add("MINGGU");

            CbJam.Items.Clear();
            for (int i = 6; i <= 19; i++)
            {
                if(i<10)
                CbJam.Items.Add("0"+i);
                else
                CbJam.Items.Add(i);
            }

            CbMenit.Items.Clear();
            for (int i = 0; i < 60; i++)
            {
                if (i < 10)
                    CbMenit.Items.Add("0" + i);
                else
                    CbMenit.Items.Add(i);
            }

            CbJumlahJam.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                CbJumlahJam.Items.Add(i);
            }
        }
        private void BBatal_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BTambah_Click(object sender, EventArgs e)
        {
            if (CbHari.SelectedIndex < 0)
                MessageBox.Show("Hari kosong!","Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(CbJam.SelectedIndex<0)
                MessageBox.Show("Jam Kosong!","Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (CbMenit.SelectedIndex < 0)
                MessageBox.Show("Menit Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (CbJumlahJam.SelectedIndex < 0)
                MessageBox.Show("Jumlah jam Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Dg.Rows.Add("0", CbHari.Text, CbJam.Text + ":" + CbMenit.Text + ":00", CbJumlahJam.Text);
            }
        }
    }
}
