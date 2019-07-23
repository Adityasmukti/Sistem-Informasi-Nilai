using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ExtensionMethods;

namespace SINIS.TU
{
    /// بسم الله الرحمن الرحيم
    /// Bismi-llāhi ar-raḥmāni ar-raḥīmi
    /// "Dengan menyebut nama Allah Yang Maha Pemurah lagi Maha Penyayang"
    public partial class FRuangKelas : Form
    {
        public FRuangKelas()
        {
            InitializeComponent();
            CbTahunAjaran.LoadTahunAjaran();
            CbMasuk.LoadAngkatan();
            CbKelas.LoadKelas();
            CbWaliKelas.load
        }

        private void FRuangKelas_Load(object sender, EventArgs e)
        {
            
        }

        private bool loaddb()
        {
            if (CbKelas.SelectedIndex >= 0 && CbTahunAjaran.SelectedIndex>=0 &&
                CbMasuk.SelectedIndex>=0 && CbWaliKelas.SelectedIndex>=0)
            {
                A.SetSelect("SELECT `SW`.`kode_siswa`, `kode_ruangan`, IF(`kode_ruangan` IS NULL, 'BELUM', 'SUDAH') `pilih`, `namakelas`, `nis`, " +
                    "`namasiswa`,`jeniskelamin`,`masuk` ");
                A.SetFrom("FROM `m_siswa` `SW` LEFT JOIN(SELECT * FROM `tb_ruangan` WHERE `tahunajaran`= '"+CbTahunAjaran.Text+"') `R` " +
                    "ON `R`.`kode_siswa` = `SW`.`kode_siswa` LEFT JOIN `r_kelas` `K` ON `K`.`kode_kelas`=`R`.`kode_kelas` ");
                A.SetWhere("WHERE `SW`.`hapus` = 'N' AND `tanggal` LIKE '"+CbMasuk.Text+"%' ");
                A.SetOrderby("ORDER BY `SW`.`namasiswa` ASC ");
                A.SetQueri(A.GetSelect() + A.GetFrom() + A.GetWhere() + ";");
                Dg.QueriToDg();
            }
            return true;
        }
        
        private void cbtahunajaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region isi combobox tahun siswa
            int tahunawal = listtahunajaran[CbTahunAjaran.SelectedIndex];
            int tahunakhir = tahunawal;
            try
            {
                query = "SELECT LEFT(MIN(siswa_tanggalmasuk),4) FROM tm_siswa WHERE deleted=0";
                string hasil = query.SingelData();
                if (hasil != "")
                    tahunakhir = int.Parse(hasil);
            }
            catch (Exception) { }
            CbMasuk.Items.Clear();
            while (tahunawal >= tahunakhir)
            {
                CbMasuk.Items.Add(tahunawal);
                tahunawal--;
            }
            CbKelas.Items.Clear();
            CbWaliKelas.Items.Clear();
            Dg.Rows.Clear();
            #endregion
        }

        private void dgsiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int index = Dg.CurrentRow.Index;
                if (Dg.CurrentRow.Cells[0].Value.ToString() == "SUDAH")
                {
                    query = "DELETE FROM tbl_ruangan WHERE id_ruangan=" +
                        Dg.CurrentRow.Cells[A.GetColumnIndexByHeader(Dg, "ID RUANGAN")].Value.ToString();
                    //DM.ManipulasiData(query);
                    loaddb();
                    Dg.ClearSelection();
                    Dg.Rows[index].Cells[0].Selected = true;
                }
                else
                {
                    bool belumdapat = true;
                    string idkelas = "0";
                    query = "SELECT * FROM tbl_ruangan WHERE tahunajaran='"+CbTahunAjaran.Text+"' AND id_siswa=" +
                        Dg.CurrentRow.Cells[A.GetColumnIndexByHeader(Dg, "ID SISWA")].Value.ToString();
                    //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
                    //{
                    //    idkelas = br["id_kelas"].ToString();
                    //    belumdapat = false;
                    //}

                    if (belumdapat)
                    {
                        query = "INSERT INTO tbl_ruangan (id_siswa, id_kelas, tahunajaran, id_guru) VALUES (" +
                            Dg.CurrentRow.Cells[A.GetColumnIndexByHeader(Dg, "ID SISWA")].Value.ToString() + ", " +
                            listidkelas[CbKelas.SelectedIndex] + ", '" + CbTahunAjaran.Text + "'," +
                            listidguru[CbWaliKelas.SelectedIndex]+")";
                        //DM.ManipulasiData(query);
                        loaddb();
                        Dg.ClearSelection();
                        Dg.Rows[index].Cells[0].Selected = true;
                    }
                    else
                    {
                        string nis = Dg.CurrentRow.Cells[A.GetColumnIndexByHeader(Dg, "NIS")].Value.ToString();
                        string kelas = CbKelas.Items[listidkelas.IndexOf(idkelas)].ToString();
                        MessageBox.Show("Siswa dengan NIS "+nis+
                            " Telah ada di Kelas "+kelas+"!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void cbkelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dg.Rows.Clear();
            #region isi combobox guru
            string sudahwali = "";
            int waliada = -1; ;
            query = "SELECT COUNT(id_guru) jumlah, IFNULL(id_guru,0) id_guru FROM tbl_ruangan WHERE id_kelas = "+listidkelas[CbKelas.SelectedIndex]+
                " AND tahunajaran = '"+CbTahunAjaran.Text+"'";
            //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    if(br["jumlah"].ToString()!="0")
            //    {
            //        sudahwali = " AND id="+ br["id_guru"].ToString();
            //        waliada = 0;
            //    }
            //}

            CbWaliKelas.Items.Clear();
            listidguru.Clear();
            query = "SELECT * FROM tm_guru WHERE 1=1 "+sudahwali;
            //foreach(DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    listidguru.Add(br["id"].ToString());
            //    cbguru.Items.Add(br["guru_nama"].ToString()+"["+ br["guru_nip"].ToString() + "]");
            //}
            CbWaliKelas.SelectedIndex = waliada;
            #endregion
        }

        private void cbthunmasuk_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM tm_kelas ORDER BY kelas_nama ASC";
            CbKelas.Items.Clear();
            listidkelas.Clear();
            //foreach (DataRow br in DM.GetData(query).Tables[0].Rows)
            //{
            //    listidkelas.Add(br["id"].ToString());
            //    cbkelas.Items.Add(br["kelas_nama"].ToString());
            //}
            Dg.Rows.Clear();
        }

        private void cbguru_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddb();
        }
    }
}
