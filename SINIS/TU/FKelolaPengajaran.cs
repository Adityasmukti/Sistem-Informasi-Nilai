using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                else if (item.Key.Equals("guru"))
                    CbGuru.Text = item.Value;
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

                        A.SetUpdate("UPDATE `tb_waktupelajaran` ");
                        A.SetValues("SET `totaljam` = '" + CbJumlahJam.Text + "', `hari` = '" + CbHari.Text + "', " +
                            "`waktu` = '" + CbJam.Text + ":" + CbMenit.Text + ":00' ");
                        A.SetWhere("WHERE `idwaktupelajaran` = '" + b.Cells[0].Value.ToString() + "' ");
                        A.SetQueri(A.GetQueri() + A.GetInsert() + A.GetValues() + ";");
                    }

                    if (A.GetQueri().ManipulasiData())
                    {

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
            foreach (DataRow b in A.GetData("").Rows)
            {
                TbTahunAjaran.Text = b[""].ToString();
                TbKelas.Text = b[""].ToString();
                CbGuru.Text = b[""].ToString();
                TbKodeMapel.Text = b[""].ToString();
                TbPelajaran.Text = b[""].ToString();
                TbKeterangan.Text = b[""].ToString();
                kodekelas = b[""].ToString();
                kodepelajaran = b[""].ToString();
            }
            A.SetQueri("");
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

                    if (A.GetQueri().ManipulasiData())
                    {

                    }
                }
            };

            BHapus.Click += (sende, e) =>
            {

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
                CbJam.Items.Add(i);
            }

            CbMenit.Items.Clear();
            for (int i = 1; i <= 60 ; i++)
            {
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
    }
}
