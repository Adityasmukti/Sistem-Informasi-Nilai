using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ExtensionMethods;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using IniParser;
using IniParser.Model;

namespace AtelierAngelinaApps.Applications
{
    public partial class FTes : Form
    {
        public FTes()
        {
            InitializeComponent();
            S.SetSettings();
            this.SetControlFrom();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var con = new MySqlConnection("server = " + AtelierAngelinaApps.Properties.Settings.Default.mysqlhost + ";" +
            "database=aadev;" +
            "uid=" + AtelierAngelinaApps.Properties.Settings.Default.mysqluser + ";" +
            "pwd=" + AtelierAngelinaApps.Properties.Settings.Default.mysqlpassword + ";" +
            "port=" + AtelierAngelinaApps.Properties.Settings.Default.mysqlport + ";" +
            "SslMode=none;" +
            "Pooling=true;" +
            "Min Pool Size=0;" +
            "Max Pool Size=150;" +
            "Persist Security Info=True;" +
            "respect binary flags=false;Allow User Variables=True;");
            var com = new MySqlCommand(@"
SET @date='2019-06-01 00:00:00';
SET @s:=(SELECT `saldoawal`+IFNULL(SUM(IF(`tipe`='Pemasukan',`nominal`,0)),0)-IFNULL(SUM(IF(`tipe`='Pengeluaran',`nominal`,0)),0) `saldoawal`
FROM
  `r_bukukas` `B`
  LEFT JOIN `m_keuangan` `K`
    ON `B`.`id_buku` = `K`.`id_buku` AND `tanggal`<@date);
SELECT `tipe`, DATE_FORMAT(`tanggal`,'%d') `tanggal`, `id_kategori`, `deskripsi`, `nominal`, @s:=@s+IF(`tipe`='Pemasukan', `nominal`, 0)-IF(`tipe`='Pengeluaran', `nominal`, 0) AS Saldo FROM `m_keuangan` 
WHERE `tanggal`>= @date AND `tanggal`<= LAST_DAY(STR_TO_DATE(@date, '%Y-%m-%d %H:%i:%s'));
            ", con);
            con.Open();
            var adapter = new MySqlDataAdapter(com);
            var ds = new DataSet();
            adapter.Fill(ds, "a");

            var reader = com.ExecuteReader();
            while(reader.Read())
            {
               // richTextBox1.Text += reader.GetString(0);
            }

            con.Close();
        }

        private void FTes_Load(object sender, EventArgs e)
        {
            A.SetQueri(@"select
  `kode_fakturorder`,
  `kode_barcode`,
  `jenisorder`
from
  `aa`.`f_order`
where `kode_barcode`='KOSONG'
");
            dataGridView1.DataSource = A.GetQueri().GetData();
        }

        private async void Button1_Click_2(object sender, EventArgs e)
        {

            Task<int> taskrunning = Longrunnginoperating();
            int result = await taskrunning;
            MessageBox.Show(result+"");
        }

        public async Task<int> Longrunnginoperating()
        {
            progressBar1.Maximum = dataGridView1.Rows.Count;
            foreach(DataRow b in dataGridView1.Rows)
            {
                await Task.Delay(100);
                //await MessageBox.Show("");
                progressBar1.Value += 1;
            }
            return 1;
        }


        private void BackgroundWorkers()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.RunWorkerAsync();
            bw.DoWork += (sender, e) =>
            {
                int a = 1;
                foreach (DataGridViewRow b in dataGridView1.Rows)
                {
                    SetControlPropertyValue(progressBar1, "Value", a);
                    a++;
                }
            };
            progressBar1.Maximum = dataGridView1.Rows.Count;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            BackgroundWorkers();
        }
        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);
        private void SetControlPropertyValue(Control oControl, string propName, object propValue)
        {
            if (oControl.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                oControl.Invoke(d, new object[] { oControl, propName, propValue });
            }
            else
            {
                Type t = oControl.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo p in props)
                {
                    if (p.Name.ToUpper() == propName.ToUpper())
                    {
                        p.SetValue(oControl, propValue, null);
                    }
                }
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            var data = new IniData();
            var parser = new FileIniDataParser();
            data["UI"]["fullscreen"] = "true";
            data["UI"]["fullscreen1"] = "true";
            parser.WriteFile("Configuration.ini", data);


            data["UI"]["fullscreen2"] = "true";
            data["UI"]["fullscreen3"] = "true";
            parser.WriteFile("Configuration.ini", data);
        }

        private void Button1_Click_3(object sender, EventArgs e)
        {
            ModulCryptography R = new ModulCryptography();
            MessageBox.Show(R.AMEncrip(textBox1.Text));
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ModulCryptography R = new ModulCryptography();
            textBox3.Text = R.AMDecrip(textBox2.Text);

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ModulCryptography R = new ModulCryptography();
            textBox2.Text = R.AMEncrip(textBox1.Text);
        }
    }
}
