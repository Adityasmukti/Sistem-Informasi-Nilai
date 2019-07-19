using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;
using System.Management;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ExtensionMethods
{
    public static class A
    {
        #region Variabel
        private static string strcon = "";
        private static MySqlConnection koneksi, koneksi2;
        private static MySqlCommand perintah;
        private static MySqlDataAdapter adapter;
        private static MySqlDataReader reader;
        private static readonly Random random = new Random();
        private static string Queri = "", queri = "", select = "", from = "", values = "", where = "", 
            groupby = "", orderby = "", set = "", insert = "", update = "", lQueri = "";
        private static List<string> id;
        private static PrintDocument PDD, PDB;
        private static readonly string semua = "SEMUA";

        public static string GetSemua()
        {
            return semua;
        }
        public static string GetQueri()
        {
            return queri;
        }
        public static void SetQueri(string value)
        {
            queri = value;
        }
        public static string GetSelect()
        {
            return select;
        }
        public static void SetSelect(string value)
        {
            select = value;
        }
        public static string GetFrom()
        {
            return from;
        }
        public static void SetFrom(string value)
        {
            from = value;
        }
        public static string GetValues()
        {
            return values;
        }
        public static void SetValues(string value)
        {
            values = value;
        }
        public static string GetWhere()
        {
            return where;
        }
        public static void SetWhere(string value)
        {
            where = value;
        }
        public static string GetGroupby()
        {
            return groupby;
        }
        public static void SetGroupby(string value)
        {
            groupby = value;
        }
        public static string GetOrderby()
        {
            return orderby;
        }
        public static void SetOrderby(string value)
        {
            orderby = value;
        }
        public static string GetSet()
        {
            return set;
        }
        public static void SetSet(string value)
        {
            set = value;
        }
        public static string GetInsert()
        {
            return insert;
        }
        public static void SetInsert(string value)
        {
            insert = value;
        }
        public static string GetUpdate()
        {
            return update;
        }
        public static void SetUpdate(string value)
        {
            update = value;
        }
        public static string GetLQueri()
        {
            return lQueri;
        }
        public static void SetLQueri(string value)
        {
            lQueri = value;
        }
        #endregion

        #region Koneksi Database
        public static void SetKoneksiString(string host, string uid, string pwd, string db, string port)
        {
            strcon = "server=" + host + ";database=" + db + ";uid=" + uid + ";pwd=" + pwd + ";port=" + port + ";SslMode=none;Pooling=true;Min Pool Size=0;" +
                "Max Pool Size=150;Persist Security Info=True;respect binary flags=false;Allow User Variables=True;";
            koneksi = new MySqlConnection(strcon);
            koneksi2 = new MySqlConnection(strcon);
        }
        public static string GetDataSettings(this string KeySetting)
        {
            string value = "";
            queri = "SELECT `nilai` FROM `r_settings` WHERE `pengaturan`='" + KeySetting + "' LIMIT 1";
            try
            {
                koneksi.Open();
                perintah = new MySqlCommand(queri, koneksi);
                reader = perintah.ExecuteReader();
                while (reader.Read())
                {
                    value = reader["nilai"].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.LogError(A.GetCurrentMethod(), "", queri);
            }
            finally
            {
                koneksi.Close();
            }
            return value;
        }
        public static DataTable GetData(this string q)
        {
            DataSet ds1 = new DataSet();
            ds1.Clear();
            try
            {
                if (koneksi.State == ConnectionState.Closed)
                    koneksi.Open();
                perintah = new MySqlCommand(q, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                adapter.Fill(ds1);
            }
            catch (Exception ex)
            {
                ex.LogError(A.GetCurrentMethod(), "", q);
                ds1 = null;
            }
            finally
            {
                koneksi.Close();
            }
            return ds1.Tables[0];
        }
        public static string SingelData(this string q)
        {
            string output = "";
            try
            {
                foreach (DataRow baris in GetData(q).Rows)
                {
                    output = baris[0].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                ex.LogError(A.GetCurrentMethod(), "", q);
            }
            return output;
        }
        public static bool CekstatusMysql()
        {
            try
            {
                koneksi.Open();
            }
            catch { }

            if (koneksi.State == ConnectionState.Open)
            {
                koneksi.Close();
                return true;
            }
            else
                return false;
        }
        public static bool ManipulasiData(this string q)
        {
            //sint res = 0;
            try
            {
                koneksi.Open();
                perintah = new MySqlCommand(q, koneksi);
                perintah.ExecuteNonQuery();
                koneksi.Close();
                return true;
            }
            catch (Exception ex)
            {
                ex.LogError(A.GetCurrentMethod(), "", q);
            }
            if (koneksi.State == ConnectionState.Open)
                koneksi.Close();
            return false;
        }
        public static bool ManipulasiData(this string q, out int rows)
        {
            int res = 0;
            try
            {
                koneksi.Open();
                perintah = new MySqlCommand(q, koneksi);
                res = perintah.ExecuteNonQuery();
                koneksi.Close();
                rows = res;
                return true;
            }
            catch (Exception ex)
            {
                koneksi.Close();
                ex.LogError(A.GetCurrentMethod(), "", q);
            }
            rows = res;
            return false;
        }
        public static int JumlahData(this string q)
        {
            int count = 0;
            foreach (DataRow baris in GetData(q).Rows)
                count++;
            return count;
        }
        public static bool SearchData(this string q)
        {
            bool ada = false;
            foreach (DataRow baris in GetData(q).Rows)
            {
                ada = true;
                break;
            }
            if (koneksi.State == ConnectionState.Open)
                koneksi.Close();
            return ada;
        }
        public static async Task<string> GetValue(this string q)
        {
            string result = "";
            koneksi2.Open();
            var com = new MySqlCommand(q, koneksi2);
            var reader = await com.ExecuteReaderAsync();
            while (reader.Read())
            {
                result = reader[0].ToString();
            }
            reader.Close();
            koneksi2.Close();
            return result;
        }
        #endregion

        #region Encode Decode
        public static string EncodeUtf8(this string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }
        public static string DecodeUtf8(this string input)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(input));
        }
        public static string QuoteFix(this string input)
        {
            return Regex.Replace(input, "'", "''");
        }
        #endregion End Encode Decode

        #region Generated
        public static string Barcode(this string tabel, string key)
        {
            string barcode = GenerateBarcode();
            if (barcode.CekBarcode(tabel, key))
                tabel.Barcode(key);
            return barcode;
        }
        public static bool CekBarcode(this string bar, string tabel, string key)
        {
            return SearchData("SELECT `" + key + "` FROM `" + tabel + "` WHERE `" + key + "`='" + bar + "';");
        }
        public static string GenerateBarcode()
        {
            return random.Next(6, 10).ToString() + random.Next(5, 10).ToString() + 
                random.Next(4, 10).ToString() + random.Next(0, 6).ToString() + 
                random.Next(2, 10).ToString() + random.Next(0, 6).ToString() + 
                random.Next(3, 10).ToString() + random.Next(0, 10).ToString() + 
                random.Next(5, 10).ToString() + random.Next(0, 9).ToString();
        }
        public static string GenerateKode(string prefix, string tabel, string field)
        {
            string temprefix = prefix + S.GetEndIpAddress() + DateTime.Now.ToString("yyMMdd");
            string postfix = "";
            foreach (DataRow baris in GetData("SELECT RIGHT(`" + field + "`,4) FROM `" + tabel + "` WHERE LEFT(`" + field + "`, 11) ='" + temprefix + "' ORDER BY `" + field + "` DESC LIMIT 1").Rows)
                postfix = (Convert.ToInt32(baris[0]) + 1).ToString();
            return temprefix + postfix.GeneratePostFix();
        }
        private static string GeneratePostFix(this string postfix)
        {
            if (postfix.Length == 0)
                postfix = "0001";
            else if (postfix == "9999")
                MessageBox.Show("Maksimal, Mohon Hapus Sebagian Data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (postfix.Length < 4)
            {
                int panjang = postfix.Length;
                for (int i = panjang; i < 4; i++)
                    postfix = "0" + postfix;
            }
            return postfix;
        }
        public static string GetDownloadsPath()
        {
            string path;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int hr = SHGetKnownFolderPath(ref FolderDownloads, 0, IntPtr.Zero, out IntPtr pathPtr);
                if (hr == 0)
                {
                    path = Marshal.PtrToStringUni(pathPtr);
                    Marshal.FreeCoTaskMem(pathPtr);
                    return path;
                }
            }
            path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            path = Path.Combine(path, "Downloads");
            return path;
        }
        private static Guid FolderDownloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);
        public static void SaveTextSQL(this string text)
        {
            try
            {
                string pathDestination = Path.Combine(Environment.CurrentDirectory, "Log");
                if (!Directory.Exists(pathDestination))
                    Directory.CreateDirectory(pathDestination);
                File.WriteAllText(Path.Combine(pathDestination, "sql.txt"), text);
                MessageBox.Show("File tersimpan!");
            }
            catch (Exception) { }
        }
        public static void LogError(this Exception error, string procedure, string form = "", string sql = "")
        {
            if (string.IsNullOrEmpty(sql))
                sql = GetQueri();
            var st = new StackTrace(error, true);
            var frame = st.GetFrame(0);
            var line = frame.GetFileLineNumber();
            string pathDestination = Path.Combine(Environment.CurrentDirectory, "Log");
            if (!Directory.Exists(pathDestination))
                Directory.CreateDirectory(pathDestination);
            File.AppendAllText(Path.Combine(pathDestination, "error-" + GetMACAddress() + ".log"),
                "[" + DateTime.Now.ToString() + "] [" + form + "] [" + procedure + "], INFO: " + error + ", LINE: " + line + ", SQL:{" + sql + "}" +
                Environment.NewLine + Environment.NewLine);
            MessageBox.Show("Kesalahan : " + error.Message + " Di line : " + line, "Error " + procedure, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static int GetColumnIndexByHeader(this DataGridView grid, string name)
        {
            //var grid = dgbawah;
            foreach (DataGridViewColumn col in grid.Columns)// in this line - when i debug project- i see the grid.columns is empty 
                if (col.HeaderText.ToLower().Trim() == name.ToLower().Trim())
                    return grid.Columns.IndexOf(col);
            return -1;
        }
        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from2 first card
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
        public static string GetLocalIPAddress()
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static string GetEndLocalIpAddress()
        {
            string[] tmpip = GetLocalIPAddress().Split('.');
            if (tmpip.Length == 4)
            {
                string tmpendip = tmpip[3];
                if (tmpendip.Length < 3)
                    for (int i = tmpendip.Length; i < 3; i++)
                        tmpendip += "0";
                return tmpendip;
            }
            return "000";
        }
        public static string GetPcName => Environment.MachineName;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);
            return sf.GetMethod().Name;
        }
        public static DataTable ToDataTable(this DataGridView dgv)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgv.Columns)
                dt.Columns.Add(Regex.Replace(col.HeaderText, " ", ""));

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                    dRow[cell.ColumnIndex] = cell.Value;
                dt.Rows.Add(dRow);
            }
            return dt;
        }
        private static string SelectRandomKarakter()
        {
            string value = "A";
            int a = random.Next(1, 36);
            switch (a)
            {
                case 1:
                    value = "A";
                    break;
                case 2:
                    value = "B";
                    break;
                case 3:
                    value = "C";
                    break;
                case 4:
                    value = "D";
                    break;
                case 5:
                    value = "E";
                    break;
                case 6:
                    value = "F";
                    break;
                case 7:
                    value = "G";
                    break;
                case 8:
                    value = "H";
                    break;
                case 9:
                    value = "I";
                    break;
                case 10:
                    value = "J";
                    break;
                case 11:
                    value = "K";
                    break;
                case 12:
                    value = "L";
                    break;
                case 13:
                    value = "M";
                    break;
                case 14:
                    value = "N";
                    break;
                case 15:
                    value = "O";
                    break;
                case 16:
                    value = "P";
                    break;
                case 17:
                    value = "Q";
                    break;
                case 18:
                    value = "R";
                    break;
                case 19:
                    value = "S";
                    break;
                case 20:
                    value = "T";
                    break;
                case 21:
                    value = "U";
                    break;
                case 22:
                    value = "V";
                    break;
                case 23:
                    value = "W";
                    break;
                case 24:
                    value = "X";
                    break;
                case 25:
                    value = "Y";
                    break;
                case 26:
                    value = "Z";
                    break;
                case 27:
                    value = "1";
                    break;
                case 28:
                    value = "2";
                    break;
                case 29:
                    value = "3";
                    break;
                case 30:
                    value = "4";
                    break;
                case 31:
                    value = "5";
                    break;
                case 32:
                    value = "6";
                    break;
                case 33:
                    value = "7";
                    break;
                case 34:
                    value = "8";
                    break;
                case 35:
                    value = "9";
                    break;
            }
            return value;
        }
        public static void SetHalaman(this TextBox tbhalaman, Button bprev, Label ldarihalaman, Button bnext, Func<bool> Loaddb)
        {
            string awal = "1";
            bnext.Click += (sender, e) =>
            {
                if (tbhalaman.Text.ToInteger() < ldarihalaman.Text.ToAngka().ToInteger())
                    tbhalaman.Text = (tbhalaman.Text.ToInteger() + 1).ToString();
            };

            bprev.Click += (sender, e) =>
            {
                if (tbhalaman.Text.ToInteger() > 1)
                    tbhalaman.Text = (tbhalaman.Text.ToInteger() - 1).ToString();
            };

            tbhalaman.KeyPress += (sender, e) =>
            {
                awal = (sender as TextBox).Text;
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            tbhalaman.KeyUp += (sender, e) =>
            {
                string halaman = (sender as TextBox).Text;
                if (!string.IsNullOrEmpty(halaman))
                    if ((halaman.ToInteger() > ldarihalaman.Text.ToAngka().ToInteger()) || (halaman.ToInteger() < 1))
                        (sender as TextBox).Text = awal;
            };

            tbhalaman.TextChanged += (sender, e) =>
            {
                if (!string.IsNullOrEmpty((sender as TextBox).Text))
                    Loaddb();
            };

            tbhalaman.Leave += (sender, e) =>
            {
                if (string.IsNullOrEmpty((sender as TextBox).Text))
                    (sender as TextBox).Text = awal;
            };
        }
        #endregion End Generated

        #region Logging
        public static void CreateLog(this string kodefaktur, string table, string form, string procedure, string keterangan = "")
        {
            ManipulasiData("INSERT INTO `t_log` (`kode`, `table`, `id_user`, `eksekusi`, `time`, `form`, `procedure`, `keterangan` ) " +
                "VALUES ('" + kodefaktur + "', '" + table + "', '" + S.GetUserid() + "', 'INSERT', NOW(), '" + form + "', '" + procedure + "', '" + keterangan + "');");
        }
        public static void UpdateLog(this string kodefaktur, string table, string form, string procedure, string keterangan = "")
        {
            ManipulasiData("INSERT INTO `t_log` (`kode`, `table`, `id_user`, `eksekusi`, `time`, `form`, `procedure`, `keterangan` ) " +
                "VALUES ('" + kodefaktur + "', '" + table + "', '" + S.GetUserid() + "', 'UPDATE', NOW(), '" + form + "', '" + procedure + "', '" + keterangan + "');");
        }
        public static void DeleteLog(this string kodefaktur, string table, string form, string procedure, string keterangan = "")
        {
            ManipulasiData("INSERT INTO `t_log` (`kode`, `table`, `id_user`, `eksekusi`, `time`, `form`, `procedure`, `keterangan` ) " +
                "VALUES ('" + kodefaktur + "', '" + table + "', '" + S.GetUserid() + "', 'DELETE', NOW(), '" + form + "', '" + procedure + "', '" + keterangan + "');");
            //Logging
        }
        public static void SetLogin()
        {
            try
            {
                ManipulasiData("INSERT INTO `d_login` ( `id_user`, `ipaddres`, `macaddres`, `pcname`, `time` ) VALUES " +
                    "('" + S.GetUserid() + "', '" + GetLocalIPAddress() + "', '" + GetMACAddress() + "', '" + GetPcName + "', NOW());");
            }
            catch (Exception) { }
        }
        public static void SetLogout()
        {
            try
            {
                ManipulasiData("INSERT INTO `d_login` ( `id_user`, `ipaddres`, `macaddres`, `pcname`, `time`, `state` ) VALUES " +
                "('" + S.GetUserid() + "', '" + GetLocalIPAddress() + "', '" + GetMACAddress() + "', '" + GetPcName + "', NOW(), 'LOGOUT' );");
            }
            catch (Exception) { }
        }
        #endregion End Logging

        #region Loading static data
        public static void LoadYN(this ComboBox cb, bool semua = true)
        {
            cb.Items.Clear();
            if (semua)
                cb.Items.Add(GetSemua());
            cb.Items.Add("YA");
            cb.Items.Add("TIDAK");
        }
        public static List<string> LoadUser(this ComboBox cb, bool semua = true)
        {
            id = new List<string>();
            cb.Items.Clear();
            if (semua)
            {
                cb.Items.Add(GetSemua());
                id.Add("0");
            }
            //foreach (DataRow b in LoadData.GetUser().Rows)
            //{
            //    id.Add(b["id_user"].ToString());
            //    cb.Items.Add(b["nama"]);
            //}
            return id;
        }
        public static void LoadOpenOrder(this ComboBox cb, bool semua = false)
        {
            //cb.Items.Clear();
            //if (semua)
            //    cb.Items.Add(GetSemua());
            //foreach (DataRow b in LoadData.GetOpenorder().Rows)
            //    cb.Items.Add(b[0].ToString());
        }
        #endregion End Loading static data

        #region Queri Execution
        public static bool DBCreate(this string queri)
        {
            if (ManipulasiData(queri))
            {
                MessageBox.Show("Disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
                return false;
        }
        public static bool DBUpdate(this string queri)
        {
            if (ManipulasiData(queri))
            {
                MessageBox.Show("Diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
                return false;
        }
        public static bool DBHapus(this string queri)
        {
            if (ManipulasiData(queri))
            {
                MessageBox.Show("Dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
                return false;
        }
        public static void QueriToDg(this DataGridView Dg)
        {
            Dg.Rows.Clear();
            foreach (DataRow b in GetData(GetQueri()).Rows)
            {
                int cell = 0;
                DataGridViewRow dr = new DataGridViewRow();
                foreach (object a in b.ItemArray)
                {
                    if (Dg.Columns[cell].CellType == typeof(DataGridViewCheckBoxCell))
                        dr.Cells.Add(new DataGridViewCheckBoxCell { Value = a });
                    else if (Dg.Columns[cell].CellType == typeof(DataGridViewButtonCell))
                        dr.Cells.Add(new DataGridViewButtonCell { Value = a });
                    else
                        dr.Cells.Add(new DataGridViewTextBoxCell { Value = a });
                    cell++;
                }
                Dg.Rows.Add(dr);
            }
        }
        public static void GenerateQueriYN(this ComboBox cb, string field, bool semua = true, bool nilai = false)
        {
            if (nilai)
            {
                if (semua)
                {
                    if (cb.SelectedIndex == 1)
                    {
                        if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + ">'0' ");
                        else SetWhere(GetWhere() + " AND `" + field + "`>'0' ");
                    }
                    else if (cb.SelectedIndex == 2)
                    {
                        if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + "='0' ");
                        else SetWhere(GetWhere() + " AND `" + field + "`='0' ");
                    }
                }
                else
                {
                    if (cb.SelectedIndex == 0)
                    {
                        if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + ">'0' ");
                        else SetWhere(GetWhere() + " AND `" + field + "`>'0' ");
                    }
                    else if (cb.SelectedIndex == 1)
                    {
                        if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + "='0' ");
                        else SetWhere(GetWhere() + " AND `" + field + "`='0' ");
                    }
                }
            }
            else
            {
                if (semua)
                {
                    if (cb.SelectedIndex == 1)
                    {
                        if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + "='Y' ");
                        else SetWhere(GetWhere() + " AND `" + field + "`='Y' ");
                    }
                    else if (cb.SelectedIndex == 2)
                    {
                        if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + "='N' ");
                        else SetWhere(GetWhere() + " AND `" + field + "`='N' ");
                    }
                }
                else
                {
                    if (cb.SelectedIndex == 0)
                    {
                        if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + "='Y' ");
                        else SetWhere(GetWhere() + " AND `" + field + "`='Y' ");
                    }
                    else if (cb.SelectedIndex == 1)
                    {
                        if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + "='N' ");
                        else SetWhere(GetWhere() + " AND `" + field + "`='N' ");
                    }
                }
            }
        }
        public static void GenerateQueriValue(this ComboBox cb, string field, bool semua = true)
        {
            if (semua)
            {
                if (cb.SelectedIndex > 0)
                {
                    if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + "='" + cb.Text + "' ");
                    else SetWhere(GetWhere() + " AND `" + field + "`='" + cb.Text + "' ");
                }
            }
            else
            {
                if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + "='" + cb.Text + "' ");
                else SetWhere(GetWhere() + " AND `" + field + "`='" + cb.Text + "' ");
            }
        }
        public static void GenerateQueriValue(this ComboBox cb, List<string> id, string field, bool semua = true)
        {
            if (semua)
            {
                if (cb.SelectedIndex > 0)
                {
                    if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + "='" + id[cb.SelectedIndex] + "' ");
                    else SetWhere(GetWhere() + " AND `" + field + "`='" + id[cb.SelectedIndex] + "' ");
                }
            }
            else
            {
                if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + "='" + id[cb.SelectedIndex] + "' ");
                else SetWhere(GetWhere() + " AND `" + field + "`='" + id[cb.SelectedIndex] + "' ");
            }
        }
        public static void GenerateQueriCari(this TextBox tb, List<string> fields)
        {
            if (!string.IsNullOrEmpty(tb.Text))
            {
                Queri = "AND (";
                foreach (string field in fields)
                {
                    if (Regex.IsMatch(field, "`")) Queri += " " + field + " LIKE '" + tb.StrEscape() + "%' OR ";
                    else Queri += "`" + field + "` LIKE '" + tb.StrEscape() + "%' OR ";
                }
                Queri = Queri.Substring(0, Queri.Length - 3) + ") ";
                SetWhere(GetWhere() + Queri);
            }
        }
        public static void GenerateQueriDate(this DateTimePicker dtp1, DateTimePicker dtp2, string field, bool cb = true)
        {
            if (cb)
            {
                if (dtp1.Checked)
                {
                    if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + " >= '" + dtp1.ToStringDate() + " 00:00:00' AND " + field + " <= '" + dtp2.ToStringDate() + " 23:59:59' ");
                    else SetWhere(GetWhere() + " AND `" + field + "` >= '" + dtp1.ToStringDate() + " 00:00:00' AND `" + field + "` <= '" + dtp2.ToStringDate() + " 23:59:59' ");
                }
            }
            else
            {
                if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + " >= '" + dtp1.ToStringDate() + " 00:00:00' AND " + field + " <= '" + dtp2.ToStringDate() + " 23:59:59' ");
                else SetWhere(GetWhere() + " AND `" + field + "` >= '" + dtp1.ToStringDate() + " 00:00:00' AND `" + field + "` <= '" + dtp2.ToStringDate() + " 23:59:59' ");
            }
        }
        public static void GenerateQueriDateTime(this DateTimePicker dtp1, DateTimePicker dtp2, string field, bool cb = true)
        {
            if (cb)
            {
                if (dtp1.Checked)
                {
                    if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + " >= '" + dtp1.ToStringDateTime() + ":00' AND " + field + " <= '" + dtp2.ToStringDateTime() + ":59' ");
                    else SetWhere(GetWhere() + " AND `" + field + "` >= '" + dtp1.ToStringDateTime() + ":00' AND `" + field + "` <= '" + dtp2.ToStringDateTime() + ":59' ");
                }
            }
            else
            {
                if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + " >= '" + dtp1.ToStringDateTime() + ":00' AND " + field + " <= '" + dtp2.ToStringDateTime() + ":59' ");
                else SetWhere(GetWhere() + " AND `" + field + "` >= '" + dtp1.ToStringDateTime() + ":00' AND `" + field + "` <= '" + dtp2.ToStringDateTime() + ":59' ");
            }
        }
        public static void GenerateQueriDateTimes(this DateTimePicker dtp1, DateTimePicker dtp2, string field, bool cb = true)
        {
            if (cb)
            {
                if (dtp1.Checked)
                {
                    if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + " >= '" + dtp1.ToStringDateTimes() + "' AND " + field + " <= '" + dtp2.ToStringDateTimes() + "' ");
                    else SetWhere(GetWhere() + " AND `" + field + "` >= '" + dtp1.ToStringDateTimes() + "' AND `" + field + "` <= '" + dtp2.ToStringDateTimes() + "' ");
                }
            }
            else
            {
                if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + " >= '" + dtp1.ToStringDateTimes() + "' AND " + field + " <= '" + dtp2.ToStringDateTimes() + "' ");
                else SetWhere(GetWhere() + " AND `" + field + "` >= '" + dtp1.ToStringDateTimes() + "' AND `" + field + "` <= '" + dtp2.ToStringDateTimes() + "' ");
            }
        }
        public static void GenerateQueriDate(this DateTimePicker dtp, string field, bool lebihbesar = true, bool cb = true)
        {
            string operators = "<=";
            string waktu = " 23:59:59";
            if (lebihbesar)
            {
                waktu = " 00:00:00";
                operators = ">=";
            }

            if (cb)
            {
                if (dtp.Checked)
                {
                    if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + " " + operators + " '" + dtp.ToStringDate() + waktu + "' ");
                    else SetWhere(GetWhere() + " AND `" + field + "` " + operators + " '" + dtp.ToStringDate() + waktu + "' ");
                }
            }
            else
            {
                if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + " " + operators + " '" + dtp.ToStringDate() + waktu + "' ");
                else SetWhere(GetWhere() + " AND `" + field + "` " + operators + " '" + dtp.ToStringDate() + waktu + "' ");
            }
        }
        public static void GenerateQueriDateTime(this DateTimePicker dtp, string field, bool lebihbesar = true, bool cb = true)
        {
            string operators = "<=";
            string waktu = ":59";
            if (lebihbesar)
            {
                waktu = ":00";
                operators = ">=";
            }

            if (cb)
            {
                if (dtp.Checked)
                {
                    if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + " " + operators + " '" + dtp.ToStringDateTime() + waktu + "' ");
                    else SetWhere(GetWhere() + " AND `" + field + "` " + operators + " '" + dtp.ToStringDateTime() + waktu + "' ");
                }
            }
            else
            {
                if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + " " + operators + " '" + dtp.ToStringDateTime() + waktu + "' ");
                else SetWhere(GetWhere() + " AND `" + field + "` " + operators + " '" + dtp.ToStringDateTime() + waktu + "' ");
            }
        }
        public static void GenerateQueriDateTimes(this DateTimePicker dtp, string field, bool lebihbesar = true, bool cb = true)
        {
            string operators = "<=";
            if (lebihbesar)
            {
                operators = ">=";
            }

            if (cb)
            {
                if (dtp.Checked)
                {
                    if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + " " + operators + " '" + dtp.ToStringDateTimes() + "' ");
                    else SetWhere(GetWhere() + " AND `" + field + "` " + operators + " '" + dtp.ToStringDateTimes() + "' ");
                }
            }
            else
            {
                if (Regex.IsMatch(field, "`")) SetWhere(GetWhere() + " AND " + field + " " + operators + " '" + dtp.ToStringDateTimes() + "' ");
                else SetWhere(GetWhere() + " AND `" + field + "` " + operators + " '" + dtp.ToStringDateTimes() + "' ");
            }
        }
        public static string GenerateQueriUpdate(this Dictionary<string, string> data)
        {
            string tabel = "", key = "", valuekey = "";
            string set2 = "SET ";
            foreach (KeyValuePair<string, string> entry in data)
            {
                if (entry.Key == "TABEL")
                    tabel = entry.Value;
                else if (entry.Key == "KEY")
                    key = entry.Value;
                else if (entry.Key == "VALUEKEY")
                    valuekey = entry.Value;
                else
                {
                    if (entry.Value == "NOW()")
                        set2 += "`" + entry.Key + "`=NOW(),";
                    else if (entry.Value == "NULL")
                        set2 += "`" + entry.Key + "`=NULL,";
                    else
                        set2 += "`" + entry.Key + "`='" + entry.Value + "',";
                }
            }
            return "UPDATE `" + tabel + "` " + set2.Substring(0, set2.Length - 1) + " WHERE `" + key + "` = '" + valuekey + "';";
        }
        public static string GenerateQueriInsert(this Dictionary<string, string> data)
        {
            string tmpinsert = "", tmpvalues = "";
            string values2 = "VALUES (";
            string insert2="";
            foreach (KeyValuePair<string, string> entry in data)
            {
                if (entry.Key == "TABEL")
                    insert2 = "INSERT INTO `" + entry.Value + "` (";
                else
                {
                    if (entry.Value == "NOW()")
                    {
                        tmpinsert += "`" + entry.Key + "`,";
                        tmpvalues += "NOW(),";
                    }
                    else if (entry.Value == "NULL")
                    {
                        tmpinsert += "`" + entry.Key + "`,";
                        tmpvalues += "NULL,";
                    }
                    else
                    {
                        tmpinsert += "`" + entry.Key + "`,";
                        tmpvalues += "'" + entry.Value + "',";
                    }
                }
            }
            insert2 += tmpinsert.Substring(0, tmpinsert.Length - 1) + ") ";
            values2 += tmpvalues.Substring(0, tmpvalues.Length - 1) + ") ";
            return insert2 + values2 + ";";
        }
        public static string GenerateQueriSelect(this string tabel, string where, string value, List<string> data)
        {
            string select2 = "SELECT ";
            foreach (string str in data)
                select2 += "`" + str + "`,";
            return select2.Substring(0, select2.Length - 1) + "FROM `" + tabel + "` WHERE `" + where + "`='" + value + "'" + ";";
        }
        #endregion End Queri Execution

        #region Index Note
        public static bool LoadIndex(this DataGridView Dg, Func<bool> Loaddb, int cell = 0)
        {
            try
            {
                int idx = Dg.CurrentRow.Index;
                Loaddb();
                if (idx > 0 && idx < Dg.Rows.Count)
                {
                    Dg.ClearSelection();
                    Dg.CurrentCell = Dg.Rows[idx].Cells[cell];
                    Dg.Rows[idx].Cells[cell].Selected = true;
                }
                return true;
            }
            catch (Exception) { return false; }
        }
        public static bool LoadIndex(this DataGridView Dg, int row, int cell = 0)
        {
            try
            {
                Dg.ClearSelection();
                Dg.CurrentCell = Dg.Rows[row].Cells[cell];
                Dg.Rows[row].Cells[cell].Selected = true;
                return true;
            }
            catch (Exception) { return false; }
        }
        #endregion End Note

        #region Converter
        public static string ColorToString(this Color c) => c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        public static Color StringToColor(this string s) => ColorTranslator.FromHtml("#" + s);
        public static string RGBConverter(this Color c) => "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        public static string ToRupiah(this long angka)
        {
            return string.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp {0:N0}", angka);
        }
        public static string ToRupiah(this string angka)
        {
            try
            {
                return string.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp {0:N0}", Convert.ToInt64(angka));
            }
            catch (Exception) { return angka; }
        }
        public static string ToRupiah(this object angka)
        {
            try
            {
                return string.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp {0:N0}", Convert.ToInt64(angka));
            }
            catch (Exception) { return angka.ToString(); }
        }
        public static string ToStringDate(this DateTime input)
        {
            return input.ToString("yyyy-MM-dd");
        }
        public static string ToStringDate(this DateTimePicker input)
        {
            return input.Value.ToString("yyyy-MM-dd");
        }
        public static string ToStringDateTimes(this DateTime input)
        {
            return input.ToString("yyyy-MM-dd HH:mm:dd");
        }
        public static string ToStringDateTimes(this DateTimePicker input)
        {
            return input.Value.ToString("yyyy-MM-dd HH:mm:dd");
        }
        public static string ToStringDateTime(this DateTime input)
        {
            return input.ToString("yyyy-MM-dd HH:mm");
        }
        public static string ToStringDateTime(this DateTimePicker input)
        {
            return input.Value.ToString("yyyy-MM-dd HH:mm");
        }
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
        public static DateTime ToDateTime(this object input)
        {
            return DateTime.Parse(input.ToString());
        }
        public static string ToDateFormatString(this object input, string format = "dd/MM/yyyy")
        {
            return DateTime.Parse(input.ToString()).ToString(format);
        }
        public static string ToAngka(this string rupiah) => Regex.Replace(rupiah, @",.*|\D", "");
        public static string ToAngka(this object rupiah) => Regex.Replace(rupiah.ToString(), @",.*|\D", "");
        public static string ToAngka(this TextBox rupiah) => Regex.Replace(rupiah.Text.ToString(), @",.*|\D", "");
        public static string ToAngkaWeb(this string rupiah) => Regex.Replace(rupiah, @"\D|..$", "");
        public static int ToInteger(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (int.TryParse(input, out int output))
                    return output;
                else
                {
                    int.TryParse(input.ToAngka(), out output);
                    return output;
                }
            }
            else
            {
                MessageBox.Show("Kesalahan Dalam mengubah angka!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static int ToInteger(this object input)
        {
            if (!string.IsNullOrEmpty(input.ToString()))
            {
                if (int.TryParse(input.ToString(), out int output))
                    return output;
                else
                {
                    int.TryParse(input.ToAngka(), out output);
                    return output;
                }
            }
            else
            {
                MessageBox.Show("Kesalahan Dalam mengubah angka!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static int ToInteger(this TextBox input)
        {
            if (!string.IsNullOrEmpty(input.Text))
            {
                if (int.TryParse(input.Text, out int output))
                    return output;
                else
                {
                    int.TryParse(input.Text.ToAngka(), out output);
                    return output;
                }
            }
            else
            {
                MessageBox.Show("Kesalahan Dalam mengubah angka!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static int ToInteger(this RichTextBox input)
        {
            if (!string.IsNullOrEmpty(input.Text))
            {
                if (int.TryParse(input.Text, out int output))
                    return output;
                else
                {
                    int.TryParse(input.Text.ToAngka(), out output);
                    return output;
                }
            }
            else
            {
                MessageBox.Show("Kesalahan Dalam mengubah angka!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static float ToFloat(this TextBox input)
        {
            char a = Convert.ToChar(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            string temp = input.Text;
            if (a == '.')
                temp = input.Text.Replace(',', '.');
            else if (a == ',')
                temp = input.Text.Replace('.', ',');

            float.TryParse(temp, out float output);
            return output;
        }
        public static float ToFloat(this string input)
        {
            char a = Convert.ToChar(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            string temp = input;
            if (a == '.')
                temp = input.Replace(',', '.');
            else if (a == ',')
                temp = input.Replace('.', ',');
            float.TryParse(temp, out float output);
            return output;
        }
        public static float ToFloat(this object input)
        {
            char a = Convert.ToChar(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            string temp = input.ToString();
            if (a == '.')
                temp = input.ToString().Replace(',', '.');
            else if (a == ',')
                temp = input.ToString().Replace('.', ',');

            float.TryParse(temp, out float output);
            return output;
        }
        public static string StringToFloat(this object input)
        {
            return input.ToFloat().ToString();
        }
        public static string StringToFloat(this string input)
        {
            return input.ToFloat().ToString();
        }
        public static string StringToFloat(this TextBox input)
        {
            return input.ToFloat().ToString();
        }
        public static string ToYN(this ComboBox cb)
        {
            if (cb.Text == "YA" || cb.Text == "SUDAH")
                return "Y";
            return "N";
        }
        #endregion End Converter

        #region Pencetakan
        public static PaperSize CalculatePaperSize(double WIcm, double HIcm)
        {
            int Width = Math.Round((WIcm * 0.393701) * 100, 0, MidpointRounding.AwayFromZero).ToString().ToInteger();
            int Height = Math.Round((HIcm * 0.393701) * 100, 0, MidpointRounding.AwayFromZero).ToString().ToInteger();

            PaperSize NewSize = new PaperSize
            {
                RawKind = (int)PaperKind.Custom,
                Width = Width,
                Height = Height,
                PaperName = "Stiker"
            };

            return NewSize;
        }
        public static int Getpx(this double cm)
        {
            return Math.Round(cm * 0.393700787 * 100, 0, MidpointRounding.AwayFromZero).ToString().ToInteger();
        }
        public static bool CekStatusPrinter()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            foreach (ManagementObject printer in searcher.Get())
            {
                if (((bool?)printer["Default"]) ?? false)
                {
                    if (printer["WorkOffline"].ToString().ToLower().Equals("true"))
                    {
                        MessageBox.Show("Your Plug-N-Play printer " + printer["Name"].ToString() + " is not connected.");
                        break;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool CetakLabel(this string kodeproduk, bool preview = false)
        {

            PDD = new PrintDocument();
            string barcode = "";
            string brand = "";
            string sku = "";
         
            foreach (DataRow b in GetData(Queri).Rows)
            {
                string[] tmp = { b["nama_produk"].ToString(), b["nama_size"].ToString(), b["nama_warna"].ToString() };
                brand = b["nama_brand"].ToString();
                barcode = b["barcode"].ToString();
                sku = string.Join(",", tmp).NoteCuttingLength();
            }

            Margins margins = new Margins(Getpx(SettingLabel["marginleft"].ToFloat()), Getpx(SettingLabel["marginright"].ToFloat()),
                Getpx(SettingLabel["margintop"].ToFloat()), Getpx(SettingLabel["marginbottom"].ToFloat()));
            PDD.DefaultPageSettings.Margins = margins;
            PDD.DefaultPageSettings.PaperSize = A.CalculatePaperSize(SettingLabel["panjangkertas"].ToFloat(), SettingLabel["tinggikertas"].ToFloat());
            PDD.PrintPage += (sender, e) =>
            {
                Color color = SettingLabel["warnabarcode"].StringToColor();
                int kolom = SettingLabel["jlhkolom"].ToInteger();//5
                int baris = SettingLabel["jlhbaris"].ToInteger();//8
                int panjang = Getpx(SettingLabel["panjangkolom"].ToFloat());//4
                int tinggi = Getpx(SettingLabel["tinggibaris"].ToFloat());//1.99
                int x = 0;
                int y = 0;
                Font f6 = new Font(SettingLabel["namafont"], SettingLabel["sizefontbrand"].ToFloat());//arial//6
                Font f5 = new Font(SettingLabel["namafont"], SettingLabel["sizefontsku"].ToFloat());//arial//5
                Font f8 = new Font(SettingLabel["namafont"], SettingLabel["sizefontbarcode"].ToFloat());//arial//8
                e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                for (int kl = 0; kl < kolom; kl++)
                {
                    y = 0;
                    for (int br = 0; br < baris; br++)
                    {
                        e.Graphics.DrawString(brand, f6, new SolidBrush(color), new PointF(x + Getpx(SettingLabel["leftbrand"].ToFloat()),
                            y + Getpx(SettingLabel["topbrand"].ToFloat())));//0.3//0.1
                        e.Graphics.DrawString(sku, f5, new SolidBrush(color), new PointF(x + Getpx(SettingLabel["leftsku"].ToFloat()),
                            y + f6.Height + Getpx(SettingLabel["topsku"].ToFloat())));//0.3//0.1
                        y += tinggi;
                    }
                    x += panjang;
                }
                e.HasMorePages = false;
            };

            if (preview)
            {
                PrintPreviewDialog printPreview = new PrintPreviewDialog
                {
                    Document = PDD,
                };
                printPreview.PrintPreviewControl.Zoom = 1;
                ((Form)printPreview).WindowState = FormWindowState.Maximized;
                printPreview.ShowDialog();
                return true;
            }
            else
            {
                //PDD.Print();
                if (CekStatusPrinter())
                {
                    PrintDialog pd = new PrintDialog
                    {
                        Document = PDD,
                        AllowSelection = true,
                        AllowSomePages = true
                    };
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        //PDD.PrinterSettings = pd.PrinterSettings;
                        PDD.PrinterSettings.PrinterName = pd.PrinterSettings.PrinterName;
                        PDD.PrinterSettings.Copies = pd.PrinterSettings.Copies;
                        PDD.PrinterSettings.PrintRange = pd.PrinterSettings.PrintRange;

                        PDD.Print();

                    }
                    return true;
                }
                else
                {
                    PrintDialog pd = new PrintDialog
                    {
                        Document = PDD,
                        AllowSelection = true,
                        AllowSomePages = true
                    };
                    MessageBox.Show("Pilih Printer untuk mencetak!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        MyPrinters.SetDefaultPrinter(pd.PrinterSettings.PrinterName);
                        return CetakLabel(kodeproduk, preview);
                    }
                    else
                        return false;
                }
            }
        }
        public static bool CetakStikerDepan(this object kodefaktur)
        {
            return kodefaktur.ToString().CetakStikerDepan();
        }
        public static bool CetakStikerDepan(this string kodefaktur)
        {
            if (CekStatusPrinter())
            {
                PDD = new PrintDocument();
                string barcode = "";
                string nomororder = "";
                string pengiriman = "";
                string nama = "";
                string alamat = "";
                string kontak = "";
                string produklist = "";
                foreach (DataRow item in GetData(Queri).Rows)
                {
                    string slip = "";
                    if (item["slip"].ToInteger() > 0)
                        slip = "Slip : " + item["slip"].ToRupiah() + "\n";
                    nomororder = item["nomororder"].ToString();
                    barcode = item["kode_barcode"].ToString();
                    pengiriman = item["pengiriman"].ToString() + "\n" + item["tglorder"].ToDateFormatString("dd-MM-yyyy HH:mm");
                    nama = item["namapembeli"].ToString();
                    alamat = item["alamat"].ToString();
                    kontak = item["kontak"].ToString();
                    produklist = slip + "Invoice : " + item["total"].ToString() + "\nProduk : \n" + produklist;
                }

                Margins margins = new Margins(Getpx(SettingStiker["marginleft"].ToFloat()), Getpx(SettingStiker["marginright"].ToFloat()),
                    Getpx(SettingStiker["margintop"].ToFloat()), Getpx(SettingStiker["marginbottom"].ToFloat()));
                PDD.DefaultPageSettings.Margins = margins;
                PDD.DefaultPageSettings.PaperSize = A.CalculatePaperSize(SettingStiker["panjangkertas"].ToFloat(), SettingStiker["tinggikertas"].ToFloat());
                PDD.PrintPage += (sender, e) =>
                {
                    Font printFont = new Font(SettingStiker["namafont"], SettingStiker["sizefontdepan"].ToFloat());
                    Color color = SettingStiker["foregroundtext"].StringToColor();
                    //image barcode

                    e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    e.Graphics.DrawString(barcode, printFont, new SolidBrush(color),
                        new PointF(Getpx(SettingStiker["lefttextbarcode"].ToFloat()), Getpx(SettingStiker["toptextbarcode"].ToFloat())));
                    //nomororder
                    e.Graphics.DrawString(nomororder, printFont, new SolidBrush(color),
                        new PointF(Getpx(SettingStiker["leftno"].ToFloat()), Getpx(SettingStiker["topno"].ToFloat())));
                    //pengiriman
                    e.Graphics.DrawString(pengiriman, printFont, new SolidBrush(color),
                        new PointF(Getpx(SettingStiker["leftpengiriman"].ToFloat()), Getpx(SettingStiker["toppengiriman"].ToFloat())));
                    //nama
                    e.Graphics.DrawString(nama, printFont, new SolidBrush(color),
                        new PointF(Getpx(SettingStiker["leftnama"].ToFloat()), Getpx(SettingStiker["topnama"].ToFloat())));
                    //alamat
                    var rect = new RectangleF(Getpx(SettingStiker["leftalamat"].ToFloat()),
                        Getpx(SettingStiker["topalamat"].ToFloat()),
                        Getpx(SettingStiker["panjangkertas"].ToFloat() - SettingStiker["leftalamat"].ToFloat()),
                        Getpx(SettingStiker["tinggikertas"].ToFloat() - SettingStiker["topalamat"].ToFloat()));
                    e.Graphics.DrawString(alamat, printFont, new SolidBrush(color), rect);
                    //"kontak"
                    e.Graphics.DrawString(kontak, printFont, new SolidBrush(color),
                        new PointF(Getpx(SettingStiker["leftphone"].ToFloat()), Getpx(SettingStiker["topphone"].ToFloat())));
                    //produk
                    rect = new RectangleF(Getpx(SettingStiker["leftinvoice"].ToFloat()),
                       Getpx(SettingStiker["topinvoice"].ToFloat()),
                       Getpx(SettingStiker["panjangkertas"].ToFloat() - SettingStiker["leftalamat"].ToFloat()),
                       Getpx(SettingStiker["tinggikertas"].ToFloat() - SettingStiker["topinvoice"].ToFloat()));
                    e.Graphics.DrawString(produklist, printFont, new SolidBrush(color), rect);

                    e.HasMorePages = false;
                };
                PDD.Print();
                return true;
            }
            else
            {
                PrintDialog pd = new PrintDialog
                {
                    Document = PDD,
                    AllowSelection = true,
                    AllowSomePages = true
                };
                MessageBox.Show("pastikan printer siap, Pilih Printer untuk mencetak!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    MyPrinters.SetDefaultPrinter(pd.PrinterSettings.PrinterName);
                    return CetakStikerDepan(kodefaktur);
                }
                else
                    return false;
            }
        }
        public static bool CetakStikerBelakang(this object kodefaktur)
        {
            return kodefaktur.ToString().CetakStikerBelakang();
        }
        public static bool CetakStikerBelakang(this string kodefaktur)
        {
            if (CekStatusPrinter())
            {
                PDB = new PrintDocument();
                string produklist = "";
                string isibelakang = "";

                foreach (DataRow item in GetData(Queri).Rows)
                {
                    string voucher = "";
                    string keep = "";
                    string slip = "";
                    string keterangan = "";
                    string ketdiskon = "";
                    if (item["jlhkeep"].ToInteger() > 0)
                        keep = "Keep : " + item["jlhkeep"].ToRupiah() + "\n";
                    if (item["jlhvoucher"].ToInteger() > 0)
                        voucher = "Voucher : " + item["jlhvoucher"].ToRupiah() + "\n";
                    if (item["slip"].ToInteger() > 0)
                        slip = "Slip : " + item["slip"].ToRupiah() + "\n";
                    if (!string.IsNullOrEmpty(item["keterangan"].ToString()))
                        keterangan = "Keterangan : " + item["keterangan"].ToString() + "\n";
                    if (!string.IsNullOrEmpty(item["ketdiskon"].ToString()))
                        ketdiskon = "Ket Diskon : " + item["ketdiskon"].ToString() + "\n";

                    isibelakang = "Order by : " + item["user"].ToString() + "\nTgl OD : " + item["tglorder"].ToDateFormatString("dd-MM-yyyy HH:mm") + "\n" +
                        slip + voucher + keep + ketdiskon + keterangan + "Produk : \n" + produklist;
                }

                Margins margins = new Margins(Getpx(SettingStiker["marginleft"].ToFloat()), Getpx(SettingStiker["marginright"].ToFloat()),
                 Getpx(SettingStiker["margintop"].ToFloat()), Getpx(SettingStiker["marginbottom"].ToFloat()));
                PDB.DefaultPageSettings.Margins = margins;
                PDB.DefaultPageSettings.PaperSize = A.CalculatePaperSize(SettingStiker["panjangkertas"].ToFloat(), SettingStiker["tinggikertas"].ToFloat());
                PDB.PrintPage += (sender, e) =>
                {
                    Font printFont = new Font(SettingStiker["namafont"], SettingStiker["sizefontbelakang"].ToFloat());
                    Color color = SettingStiker["foregroundtext"].StringToColor();
                    //print barcode
                    e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    e.HasMorePages = false;
                };
                PDB.Print();
                return true;
            }
            else
            {
                PrintDialog pd = new PrintDialog
                {
                    Document = PDB,
                    AllowSelection = true,
                    AllowSomePages = true
                };
                MessageBox.Show("pastikan printer siap, Pilih Printer untuk mencetak!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    MyPrinters.SetDefaultPrinter(pd.PrinterSettings.PrinterName);
                    return CetakStikerBelakang(kodefaktur);
                }
                else
                    return false;
            }
        }
        public static Dictionary<string, string> SettingStiker;
        public static Dictionary<string, string> SettingLabel;
        #endregion End Pencetakan 

        #region  Input box
        public static DialogResult InputBoxNumber(string title, string promptText, ref string value)
        {
            TextBox textBox = new TextBox();
            Form form = new Form();
            Label label = new Label();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            textBox.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };
            form.Text = title;
            label.Text = promptText;
            textBox.Text = value.ToAngka();

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor |= AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        public static DialogResult InputRichTextBox(string title, string promptText, ref string value)
        {
            RichTextBox RtextBox = new RichTextBox();
            Form form = new Form();
            Label label = new Label();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            form.Text = title;
            label.Text = promptText;
            RtextBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 5, 372, 13);
            RtextBox.SetBounds(12, 21, 372, 80);
            buttonOk.SetBounds(228, 107, 75, 23);
            buttonCancel.SetBounds(309, 107, 75, 23);

            label.AutoSize = true;
            RtextBox.Anchor |= AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 137);
            form.Controls.AddRange(new Control[] { label, RtextBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = RtextBox.StrEscape();
            return dialogResult;
        }
        public static DialogResult InputTextBoxUpper(string title, string promptText, ref string value)
        {
            TextBox textBox = new TextBox();
            Form form = new Form();
            Label label = new Label();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor |= AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox.CharacterCasing = CharacterCasing.Upper;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.StrEscape();
            return dialogResult;
        }
        public static DialogResult InputTextBox(string title, string promptText, ref string value)
        {
            TextBox textBox = new TextBox();
            Form form = new Form();
            Label label = new Label();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            form.Font = new Font("Arial", 10, FontStyle.Regular);
            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 12, 372, 13);
            textBox.SetBounds(12, 36, 372, 60);
            buttonOk.SetBounds(163, 110, 108, 28);
            buttonOk.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            buttonOk.BackColor = Color.Crimson;
            buttonOk.Cursor = Cursors.Hand;
            buttonOk.FlatStyle = FlatStyle.Flat;
            buttonOk.Font = new Font("Broadway", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            buttonOk.ForeColor = Color.White;
            buttonOk.UseVisualStyleBackColor = false;

            buttonCancel.SetBounds(277, 110, 108, 28);
            buttonCancel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            buttonCancel.BackColor = Color.Crimson;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Broadway", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            buttonCancel.ForeColor = Color.White;
            buttonCancel.UseVisualStyleBackColor = false;

            label.AutoSize = true;
            textBox.Anchor |= AnchorStyles.Right;
            textBox.Multiline = true;
            textBox.WordWrap = true;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 147);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.StrEscape();
            return dialogResult;
        }
        public static DialogResult InputTanggal(string title, string promptText, ref string value)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            Form form = new Form();
            Label label = new Label();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            form.Font = new Font("Arial", 10, FontStyle.Regular);
            form.Text = title;
            label.Text = promptText;
            dateTimePicker.Value = DateTime.Parse(value);

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 12, 372, 13);
            dateTimePicker.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(163, 68, 108, 28);
            buttonOk.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            buttonOk.BackColor = Color.Crimson;
            buttonOk.Cursor = Cursors.Hand;
            buttonOk.FlatStyle = FlatStyle.Flat;
            buttonOk.Font = new Font("Broadway", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            buttonOk.ForeColor = Color.White;
            buttonOk.UseVisualStyleBackColor = false;

            buttonCancel.SetBounds(277, 68, 108, 28);
            buttonCancel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            buttonCancel.BackColor = Color.Crimson;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Broadway", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            buttonCancel.ForeColor = Color.White;
            buttonCancel.UseVisualStyleBackColor = false;

            label.AutoSize = true;
            dateTimePicker.Anchor |= AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, dateTimePicker, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = dateTimePicker.Value.ToString("");
            return dialogResult;
        }
        public static DialogResult InputTanggal(string title, string promptText, ref DateTime value)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            Form form = new Form();
            Label label = new Label();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            form.Font = new Font("Arial", 10, FontStyle.Regular);
            form.Text = title;
            label.Text = promptText;
            dateTimePicker.Value = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 12, 372, 13);
            dateTimePicker.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(163, 68, 108, 28);
            buttonOk.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            buttonOk.BackColor = Color.Crimson;
            buttonOk.Cursor = Cursors.Hand;
            buttonOk.FlatStyle = FlatStyle.Flat;
            buttonOk.Font = new Font("Broadway", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            buttonOk.ForeColor = Color.White;
            buttonOk.UseVisualStyleBackColor = false;

            buttonCancel.SetBounds(277, 68, 108, 28);
            buttonCancel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            buttonCancel.BackColor = Color.Crimson;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Broadway", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            buttonCancel.ForeColor = Color.White;
            buttonCancel.UseVisualStyleBackColor = false;

            label.AutoSize = true;
            dateTimePicker.Anchor |= AnchorStyles.Right;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd-MM-yyyy HH:mm";
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, dateTimePicker, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = dateTimePicker.Value;
            return dialogResult;
        }
        #endregion End Input box

        #region String Converter
        public static string FirstCharToUpper(this string input)
        {
            try
            {
                if (input.Length > 0)
                {
                    input = input.ToLower();
                    string[] split = input.Split(' ');
                    int i = 0;
                    while (i < split.Length)
                    {
                        if (split[i] != "")
                        {
                            split[i] = split[i].First().ToString().ToUpper() + String.Join("", split[i].Skip(1)); ;
                        }
                        i++;
                    }
                    input = string.Join(" ", split);

                    split = input.Split('/');
                    i = 0;
                    while (i < split.Length)
                    {
                        if (split[i] != "")
                        {
                            split[i] = split[i].First().ToString().ToUpper() + String.Join("", split[i].Skip(1)); ;
                        }
                        i++;
                    }
                    input = string.Join("/", split);

                    split = input.Split('.');
                    i = 0;
                    while (i < split.Length)
                    {
                        if (split[i] != "")
                        {
                            split[i] = split[i].First().ToString().ToUpper() + String.Join("", split[i].Skip(1)); ;
                        }
                        i++;
                    }
                    input = string.Join(". ", split);

                    split = input.Split('(');
                    i = 0;
                    while (i < split.Length)
                    {
                        if (split[i] != "")
                        {
                            split[i] = split[i].First().ToString().ToUpper() + String.Join("", split[i].Skip(1)); ;
                        }
                        i++;
                    }
                    input = string.Join("(", split);

                    return input.TrimEnd();
                }
                else
                    return null;
            }
            catch (Exception) { return input; }
        }
        public static string FirstWordToUpper(this string input)
        {
            try
            {
                input = input.Trim();
                string[] perbaikan = input.Split(' ');
                for (int i = 0; i < perbaikan.Length; i++)
                {
                    if (perbaikan[i].Length > 2)
                        perbaikan[i] = perbaikan[i].Trim().FirstCharToUpper();
                    else
                        perbaikan[i] = perbaikan[i].ToUpper();
                }
                return string.Join(" ", perbaikan);
            }
            catch (Exception) { return input; }
        }
        public static string RemoveNL(this string input) => Regex.Replace(input.Trim(), @"\t|\n|\r", " ");
        public static string RemoveDoubleSpace(this string input)
        {
            input = input.Trim();
            if (Regex.IsMatch(input, "  "))
                input = Regex.Replace(input, "  ", " ").RemoveDoubleSpace();
            return input;
        }
        public static string StrEscape(this string input) => Regex.Replace(input.Replace(@"\", @"\\"), "'", "''");
        public static string StrEscape(this object input) => Regex.Replace(input.ToString().Replace(@"\", @"\\"), "'", "''");
        public static string StrEscape(this TextBox input) => Regex.Replace(input.Text.ToString().Replace(@"\", @"\\"), "'", "''");
        public static string StrEscape(this RichTextBox input) => Regex.Replace(input.Text.ToString().Replace(@"\", @"\\"), "'", "''");
        public static string NoteCuttingLength(this string note)
        {
            note = Regex.Replace(note.ToUpper(), " ", "");
            string[] notes = note.Split(',');
            string produk = notes[0];
            string size = notes[1];
            string warna = notes[2];
            string output = "[" + produk + "][" + size + "][" + warna + "]";

            if (output.Length <= 27)
                return output;
            else
            {
                if (produk.Length > warna.Length)
                {
                    produk = produk.HilangkanHuruf();
                    output = "[" + produk + "][" + size + "][" + warna + "]";
                    if (output.Length <= 27)
                        return output;
                    else
                        return (produk + "," + size + "," + warna).NoteCuttingLength();
                }
                else
                {
                    warna = warna.HilangkanHuruf();
                    output = "[" + produk + "][" + size + "][" + warna + "]";
                    if (output.Length <= 27)
                        return output;
                    else
                        return (produk + "," + size + "," + warna).NoteCuttingLength();
                }
            }
        }
        private static int JumlahHurufHidup(this string input)
        {
            int a = 0;
            foreach (char Char in input)
            {
                if (Char == 'A')
                    a++;
                else if (Char == 'I')
                    a++;
                else if (Char == 'U')
                    a++;
                else if (Char == 'E')
                    a++;
                else if (Char == 'O')
                    a++;
            }
            return a;
        }
        private static string HilangkanHuruf(this string input)
        {
            string output = input;
            if (input.Length > 3)
            {
                if (JumlahHurufHidup(input) > 0)
                {
                    int index = 0;
                    int i = 0;
                    foreach (char Char in input)
                    {
                        if (Char == 'A' || Char == 'I' || Char == 'U' || Char == 'E' || Char == 'O')
                            index = i;
                        i++;
                    }
                    if (index == input.Length - 1)
                        output = input.Substring(0, input.Length - 1);
                    else
                        output = input.Substring(0, index) + input.Substring(index + 1);
                }
                else
                    output = input.Substring(0, input.Length - 1);
            }
            return output;
        }
        private static StringBuilder words;
        private static readonly string[] m_Units = new string[10] {
            string.Empty,
            "satu", "dua", "tiga", "empat", "lima",
            "enam", "tujuh", "delapan", "sembilan"
        };
        private static readonly string[] m_Thousands = new string[5] {
            string.Empty, " ribu", " juta", " milyar", " triliun"
        };
        private static long money;
        public static string Ubahkekata(this string angka)
        {
            string kata = "";

            foreach (char huruf in angka)
            {
                switch (huruf)
                {
                    case '1':
                        kata += huruf.ToString();
                        break;
                    case '2':
                        kata += huruf.ToString();
                        break;
                    case '3':
                        kata += huruf.ToString();
                        break;
                    case '4':
                        kata += huruf.ToString();
                        break;
                    case '5':
                        kata += huruf.ToString();
                        break;
                    case '6':
                        kata += huruf.ToString();
                        break;
                    case '7':
                        kata += huruf.ToString();
                        break;
                    case '8':
                        kata += huruf.ToString();
                        break;
                    case '9':
                        kata += huruf.ToString();
                        break;
                    case '0':
                        kata += huruf.ToString();
                        break;
                    default: break;
                }
            }
            try
            {
                money = long.Parse(kata);

                words = new StringBuilder(200);

                long number = (long)money;
                if (number == 0L)
                {
                    words.Append("Nol ");
                }
                else
                {
                    // Hitung jumlah per tiga digit.
                    int digits = 0;
                    long step = 1L;
                    while (step <= number)
                    {
                        digits++;
                        step *= 1000L;
                    }

                    for (int index = (digits - 1); index >= 0; index--)
                    {
                        long counter = (long)Math.Pow(1000, index);
                        long temp = number / counter;
                        short remainder = (short)(temp % 1000L);

                        if (remainder > 0)
                        {
                            AddWords(remainder, m_Thousands[index % m_Thousands.Length]);
                            words.Append(" ");
                        }
                    }
                }

                words.Append("rupiah");

                // Apakah ada sen ?
                decimal fraction = money - decimal.Truncate(money);
                if (fraction > 0m)
                {
                    short cent = (short)(fraction * 100m);

                    words.Append(" ");
                    AddWords(cent, string.Empty);
                    words.Append(" sen");
                }

                words.Append(".");

                // Kapital huruf pertama.
                words.Replace(words[0], char.ToUpper(words[0]), 0, 1);

                return words.ToString();
            }
            catch (Exception) { return null; }
        }
        private static void AddWords(short number, string suffix)
        {
            // Three digits.
            int[] digits = new int[3];
            for (int index = 2; index >= 0; index--)
            {
                digits[index] = number % 10;
                number /= 10;
            }

            bool isLeadingZero = true;

            /* digits[0] == ratusan
             * digits[1] == puluhan
             * digits[2] == satuan
             */
            if (digits[0] > 0)
            {
                if (digits[0] == 1)
                {
                    words.Append("seratus");
                }
                else
                {
                    words.Append(m_Units[digits[0]]).Append(" ratus");
                }

                isLeadingZero = false;
            }

            if (digits[1] > 0)
            {
                if (digits[0] > 0)
                {
                    words.Append(" ");
                }

                if (digits[1] == 1)
                {
                    switch (digits[2])
                    {
                        case 0:
                            words.Append("sepuluh");
                            break;
                        case 1:
                            words.Append("sebelas");
                            break;
                        default:
                            words.Append(m_Units[digits[2]]).Append(" belas");
                            break;
                    }

                    words.Append(suffix);
                    return;
                }

                words.Append(m_Units[digits[1]]).Append(" puluh");
                isLeadingZero = false;

                if (digits[2] == 0)
                {
                    words.Append(suffix);
                    return;
                }

                words.Append(" ");
            }

            if (isLeadingZero && (digits[2] == 1) && (suffix == " ribu"))
            {
                words.Append("seribu");
                return;
            }

            words.Append(m_Units[digits[2]]).Append(suffix);
        }
        public static void TooltipShowUpperCase(this Control control, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                ToolTip toolTip1 = new ToolTip();
                var c = control;
                toolTip1.ToolTipIcon = ToolTipIcon.Warning;
                toolTip1.ToolTipTitle = "KARAKTER";
                toolTip1.Show("Harus Menggunakan Huruf Kapital", c, 15, 10, 1000);
                e.Handled = true;
            }
        }
        public static void TooltipShowNumberOnly(this Control control, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                ToolTip toolTip1 = new ToolTip();
                var c = control;
                toolTip1.ToolTipIcon = ToolTipIcon.Warning;
                toolTip1.ToolTipTitle = "KARAKTER";
                toolTip1.Show("Harus Menggunakan Angka Saja", c, 15, 10, 1000);
                e.Handled = true;
            }
        }
        #endregion

        #region Event
        public static string LimitQ(this TextBox tbhalaman, Label ldarihalaman, string from, string where, string groupby = "", int divs = 0)
        {
            if (divs == 0)
                divs = S.GetDivs();

            if (A.GetGroupby() == "")
            {
                int.TryParse(SingelData("SELECT (COUNT(*) DIV " + divs + ") divs " + from + where), out int jlhhal);
                ldarihalaman.Text = "/ " + (jlhhal + 1).ToString();
                return " LIMIT " + ((tbhalaman.Text.ToInteger() - 1) * divs).ToString() + "," + divs;
            }
            else
            {
                ldarihalaman.Text = "/ " + ((JumlahData("SELECT * " + from + where + groupby) / divs) + 1).ToString();
                return " LIMIT " + ((tbhalaman.Text.ToInteger() - 1) * divs).ToString() + "," + divs;
            }
        }
        public static string LimitQ(this TextBox tbhalaman, Label ldarihalaman, Label jumlahdata, string from, string where, string groupby = "", int divs = 0)
        {
            if (divs == 0)
                divs = S.GetDivs();

            jumlahdata.Text = "JUMLAH : 0";
            if (A.GetGroupby() == "")
            {
                jumlahdata.Text = "JUMLAH : " + SingelData("SELECT COUNT(*) " + from + where);

                int.TryParse(SingelData("SELECT (COUNT(*) DIV " + divs + ") divs " + from + where), out int jlhhal);
                ldarihalaman.Text = "/ " + (jlhhal + 1).ToString();
                return " LIMIT " + ((tbhalaman.Text.ToInteger() - 1) * divs).ToString() + "," + divs;
            }
            else
            {
                int tmpjlh = JumlahData("SELECT * " + from + where + groupby);
                jumlahdata.Text = "JUMLAH : " + tmpjlh;

                ldarihalaman.Text = "/ " + ((tmpjlh / divs) + 1).ToString();
                return " LIMIT " + ((tbhalaman.Text.ToInteger() - 1) * divs).ToString() + "," + divs;
            }
        }
        public static string LimitQ(this TextBox tbhalaman, Label ldarihalaman, Label jumlahdata, Label totaldata, string fieldsum, string from, string where, string groupby = "", int divs = 0)
        {
            if (divs == 0)
                divs = S.GetDivs();

            if (!Regex.IsMatch(fieldsum, "`"))
                fieldsum = "`" + fieldsum + "`";

            jumlahdata.Text = "JUMLAH : 0";
            totaldata.Text = "TOTAL : 0";
            if (A.GetGroupby() == "")
            {
                foreach (DataRow b in A.GetData("SELECT COUNT(*) `jumlah`, IFNULL(SUM(" + fieldsum + "),0) `total` " + from + where).Rows)
                {
                    jumlahdata.Text = "JUMLAH : " + b["jumlah"].ToString();
                    totaldata.Text = "TOTAL : " + b["total"].ToString();
                }

                int.TryParse(SingelData("SELECT (COUNT(*) DIV " + divs + ") divs " + from + where), out int jlhhal);
                ldarihalaman.Text = "/ " + (jlhhal + 1).ToString();
                return " LIMIT " + ((tbhalaman.Text.ToInteger() - 1) * divs).ToString() + "," + divs;
            }
            else
            {
                int tmpjlh = JumlahData("SELECT * " + from + where + groupby);
                jumlahdata.Text = "JUMLAH : " + tmpjlh;
                totaldata.Text = "TOTAL : " + SingelData("SELECT IFNULL(SUM(" + fieldsum + "),0) `total` " + from + where);

                ldarihalaman.Text = "/ " + ((tmpjlh / divs) + 1).ToString();
                return " LIMIT " + ((tbhalaman.Text.ToInteger() - 1) * divs).ToString() + "," + divs;
            }
        }
        public static void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        public static void LeaveToZero(object sender, EventArgs e)
        {
            if ((sender as TextBox).TextLength == 0)
                (sender as TextBox).Text = "0";
        }
        public static void OnlyNumberDecimal(object sender, KeyPressEventArgs e)
        {
            char a = Convert.ToChar(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != a)
                e.Handled = true;
        }
        #endregion

        #region Export / Import
        public static void ImportExcelDataJne(this DataGridView dg)
        {
            OpenFileDialog f = new OpenFileDialog()
            {
                Filter = "Excel Workbook (*.xlsx; *.xls)|*.xlsx;*.xls|Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2013 Workbook (*.xls)|*.xls",
                InitialDirectory = GetDownloadsPath(),
                RestoreDirectory = true,
                FilterIndex = 1,
                Title = "Cari File"
            };
            if (f.ShowDialog() != DialogResult.Cancel)
            {
                NetOffice.ExcelApi.Application app = new NetOffice.ExcelApi.Application();
                NetOffice.ExcelApi.Workbook book = null;
                app.Visible = false;
                app.ScreenUpdating = false;
                app.DisplayAlerts = false;
                NetOffice.ExcelApi.Range range;
                //string execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                try
                {
                    book = app.Workbooks.Open(f.FileName, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    //NetOffice.ExcelApi.Worksheet xlWorksheet = (NetOffice.ExcelApi.Worksheet)(book.Sheets["Sheet1"]);
                    var xlWorkSheet = (NetOffice.ExcelApi.Worksheet)book.Worksheets[1];
                    // get a range to work with
                    range = xlWorkSheet.get_Range("B3", Type.Missing);
                    range = range.get_End(NetOffice.ExcelApi.Enums.XlDirection.xlToRight);
                    // get the end of values toward the bottom, looking in the last column (will stop at first empty cell)
                    range = range.get_End(NetOffice.ExcelApi.Enums.XlDirection.xlDown);
                    // get the address of the bottom, right cell
                    string downAddress = range.get_Address(false, false, NetOffice.ExcelApi.Enums.XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
                    // Get the range, then values from a1
                    range = xlWorkSheet.get_Range("B4", downAddress);
                    object[,] values = (object[,])range.Value2;
                    dg.Rows.Clear();
                    // View the values
                    for (int i = 1; i <= values.GetLength(0); i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        for (int j = 1; j <= values.GetLength(1); j++)
                        {
                            dr.Cells.Add(new DataGridViewTextBoxCell { Value = values[i, j] });
                        }
                        dg.Rows.Add(dr);
                    }
                    MessageBox.Show("Import berhasil!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kesalahan dalam membaca file, Pastikan Format form sama!!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ex.LogError(A.GetCurrentMethod());
                }
                finally
                {
                    if (book != null)
                        book.Close(false, Missing.Value, Missing.Value);
                    if (app != null)
                        app.Quit();
                }
            }
        }
        public static void ImportExcel()
        {
            OpenFileDialog f = new OpenFileDialog()
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2013 Workbook (*.xls)|*.xls",
                InitialDirectory = GetDownloadsPath(),
                RestoreDirectory = true,
                FilterIndex = 1,
                Title = "Cari File"
            };
            if (f.ShowDialog() != DialogResult.Cancel)
            {
                NetOffice.ExcelApi.Application app = new NetOffice.ExcelApi.Application();
                NetOffice.ExcelApi.Workbook book = null;
                NetOffice.ExcelApi.Range range;
                try
                {
                    app.Visible = false;
                    app.ScreenUpdating = false;
                    app.DisplayAlerts = false;

                    string execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

                    book = app.Workbooks.Open(f.FileName, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    //NetOffice.ExcelApi.Worksheet xlWorksheet = (NetOffice.ExcelApi.Worksheet)(book.Sheets["Sheet1"]);
                    var xlWorkSheet = (NetOffice.ExcelApi.Worksheet)book.Worksheets[1];
                    // get a range to work with
                    range = xlWorkSheet.get_Range("A2", Missing.Value);
                    // get the end of values to the right (will stop at the first empty cell)
                    range = range.get_End(NetOffice.ExcelApi.Enums.XlDirection.xlToRight);
                    // get the end of values toward the bottom, looking in the last column (will stop at first empty cell)
                    range = range.get_End(NetOffice.ExcelApi.Enums.XlDirection.xlDown);
                    // get the address of the bottom, right cell
                    string downAddress = range.get_Address(false, false, NetOffice.ExcelApi.Enums.XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
                    // Get the range, then values from a1
                    range = xlWorkSheet.get_Range("A2", downAddress);
                    object[,] values = (object[,])range.Value2;

                    string sql = "";
                    // View the values
                    for (int i = 1; i <= values.GetLength(0); i++)
                    {
                        //barcode//resi//date//reciever//status
                        string datestr = "";
                        string resi = "";
                        if (values[i, 2] != null)
                            resi = Regex.Replace((string)values[i, 2], "#", "");
                        if (values[i, 3] != null)
                            datestr = DateTime.FromOADate((double)values[i, 3]).ToString("yyyy-MM-dd HH:mm:ss");

                        if (values[i, 5].ToString().Equals("DELIVERED"))
                            sql += "UPDATE `f_order` SET `id_resi` = CASE WHEN `id_resi` = '0' THEN '" + S.GetUserid() + "' ELSE `id_resi` END, " +
                                "`resi` = '" + resi + "', `id_terima` = '" + S.GetUserid() + "', `sampai` = 'Y', `tglsampai` = '" + datestr + "', " +
                                "`penerimapaket`='" + values[i, 4] + "' WHERE `kode_barcode` = '" + values[i, 1] + "';";
                        else
                            sql += "UPDATE `f_order` SET `id_resi` = '" + S.GetUserid() + "', `resi` = '" + resi + "' WHERE `kode_barcode` = '" + values[i, 1] + "';";
                    }
                    if (sql.ManipulasiData())
                        MessageBox.Show("Data Pengiriman telah berhasil dirubah!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Gagal mengubah data pengiriman!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kesalahan dalam membaca file, Pastikan Format form sama!!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ex.LogError(GetCurrentMethod());
                }
                finally
                {
                    if (book != null)
                        book.Close(false, Missing.Value, Missing.Value);
                    if (app != null)
                        app.Quit();
                }
            }
        }
        public static void ExportExcel(this DataGridView Dg, string queri, string judul = "")
        {
            Cursor.Current = Cursors.WaitCursor;
            NetOffice.ExcelApi.Application xlApp = new NetOffice.ExcelApi.Application();
            Object misValue = System.Reflection.Missing.Value;
            _ = new NetOffice.ExcelApi.Range();
            NetOffice.ExcelApi.Workbook xlWorkbook = xlApp.Workbooks.Add(misValue);
            NetOffice.ExcelApi.Worksheet xlWorksheet = (NetOffice.ExcelApi.Worksheet)(xlWorkbook.Sheets["Sheet1"]);
            CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            xlWorksheet.PageSetup.Orientation = NetOffice.ExcelApi.Enums.XlPageOrientation.xlLandscape;
            xlWorksheet.PageSetup.PaperSize = NetOffice.ExcelApi.Enums.XlPaperSize.xlPaperA4;
            xlWorksheet.PageSetup.BottomMargin = 0.5;
            xlWorksheet.PageSetup.TopMargin = 0.5;
            xlWorksheet.PageSetup.LeftMargin = 0.5;
            xlWorksheet.PageSetup.RightMargin = 0.5;
            SaveFileDialog sf = new SaveFileDialog
            {
                Filter = "Excel Document (.xlsx)|*.xlsx",
                FilterIndex = 0,
                RestoreDirectory = true,
                FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx",
                Title = "Simpan File SpreadSheet"
            };
            if (sf.ShowDialog() == DialogResult.OK)
            {
                #region Memberi nama Header tabel
                int hasilbagi = Dg.ColumnCount / 26;
                int sisabagi = Dg.ColumnCount % 26;
                if (sisabagi > 0)
                    hasilbagi++;
                int colindex = 0;
                NetOffice.ExcelApi.Range range;
                for (int a = 0; a < hasilbagi; a++)
                {
                    string pre = ((char)(a + 64)).ToString();
                    if (a == 0)
                        pre = "";
                    int huruf = 26;
                    if (a == hasilbagi - 1)
                        if (sisabagi > 0)
                            huruf = sisabagi;
                    for (int b = 0; b < huruf; b++)
                    {
                        range = xlWorksheet.get_Range(pre + ((char)(b + 65)).ToString() + "3", pre + ((char)(b + 65)).ToString() + "3");
                        range.FormulaR1C1 = Dg.Columns[colindex].HeaderText;
                        range.Font.Bold = FontStyle.Bold;
                        range.HorizontalAlignment = NetOffice.ExcelApi.Enums.XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = NetOffice.ExcelApi.Enums.XlVAlign.xlVAlignCenter;
                        colindex++;
                    }
                }
                #endregion

                #region Mengisi Cell yang ada
                int baris = 0;
                foreach (DataRow br in queri.GetData().Rows)
                {
                    colindex = 0;
                    for (int a = 0; a < hasilbagi; a++)
                    {
                        string pre = ((char)(a + 64)).ToString();
                        if (a == 0)
                            pre = "";
                        int huruf = 26;
                        if (a == hasilbagi - 1)
                            if (sisabagi > 0)
                                huruf = sisabagi;
                        for (int b = 0; b < huruf; b++)
                        {
                            xlWorksheet.get_Range(pre + ((char)(b + 65)).ToString() + (baris + 4).ToString(), pre + ((char)(b + 65)).ToString() + (baris + 4).ToString()).FormulaR1C1 = br[colindex];
                            colindex++;
                        }
                    }
                    baris++;
                }
                #endregion
                Cursor.Current = Cursors.Default;

                try
                {
                    range = xlWorksheet.get_Range("A1", "A1");
                    range.FormulaR1C1 = judul.ToUpper();
                    range.Font.Size = 14;
                    range.Font.Bold = FontStyle.Bold;

                    xlWorksheet.get_Range("A2", "A2").RowHeight = 5;
                    xlWorksheet.UsedRange.WrapText = false;
                    xlApp.Visible = true;
                    xlWorksheet.SaveAs(sf.FileName, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
                    MessageBox.Show("Export Selesai!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ex.LogError(A.GetCurrentMethod());
                }
                finally
                {
                    xlApp.Dispose();
                    System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
                }
            }
        }
        public static void ExportPerWaktu(this DataGridView Dg, DataTable Size, List<string> Tanggal, string queri, string judul = "")
        {
            Cursor.Current = Cursors.WaitCursor;
            NetOffice.ExcelApi.Application xlApp = new NetOffice.ExcelApi.Application();
            Object misValue = Missing.Value;
            _ = new NetOffice.ExcelApi.Range();
            NetOffice.ExcelApi.Workbook xlWorkbook = xlApp.Workbooks.Add(misValue);
            NetOffice.ExcelApi.Worksheet xlWorksheet = (NetOffice.ExcelApi.Worksheet)(xlWorkbook.Sheets["Sheet1"]);
            CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            xlWorksheet.PageSetup.Orientation = NetOffice.ExcelApi.Enums.XlPageOrientation.xlLandscape;
            xlWorksheet.PageSetup.PaperSize = NetOffice.ExcelApi.Enums.XlPaperSize.xlPaperA4;
            xlWorksheet.PageSetup.BottomMargin = 0.5;
            xlWorksheet.PageSetup.TopMargin = 0.5;
            xlWorksheet.PageSetup.LeftMargin = 0.5;
            xlWorksheet.PageSetup.RightMargin = 0.5;
            SaveFileDialog sf = new SaveFileDialog
            {
                Filter = "Excel Document (.xlsx)|*.xlsx",
                FilterIndex = 0,
                RestoreDirectory = true,
                FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx",
                Title = "Simpan File SpreadSheet"
            };
            if (sf.ShowDialog() == DialogResult.OK)
            {
                //mengisi Header No
                NetOffice.ExcelApi.Range range = xlWorksheet.get_Range("A3", "A5");
                range.Merge(misValue);
                range.HorizontalAlignment = NetOffice.ExcelApi.Enums.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = NetOffice.ExcelApi.Enums.XlVAlign.xlVAlignCenter;
                range.FormulaR1C1 = "NO";
                range.Font.Bold = FontStyle.Bold;

                //mengisi WARNA
                range = xlWorksheet.get_Range("B3", "B5");
                range.Merge(misValue);
                range.HorizontalAlignment = NetOffice.ExcelApi.Enums.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = NetOffice.ExcelApi.Enums.XlVAlign.xlVAlignCenter;
                range.FormulaR1C1 = "WARNA";
                range.Font.Bold = FontStyle.Bold;

                #region Memberi nama Header tabel
                int hasilbagi = Dg.ColumnCount / 26;
                int sisabagi = Dg.ColumnCount % 26;
                if (sisabagi > 0)
                    hasilbagi++;
                int colindex = 1;
                int tanggalidx = 0;
                int size = 0;
                for (int a = 0; a < hasilbagi; a++)
                {
                    string pre = ((char)(a + 64)).ToString();
                    if (a == 0)
                        pre = "";
                    int huruf = 26;
                    if (a == hasilbagi - 1)
                        if (sisabagi > 0)
                            huruf = sisabagi;
                    for (int b = 1; b < huruf; b++)
                    {
                        //Isi Header baris ke tiga dari header tabel
                        range = xlWorksheet.get_Range(pre + ((char)(b + 1 + 65)).ToString() + "5", pre + ((char)(b + 1 + 65)).ToString() + "5");
                        range.FormulaR1C1 = Dg.Columns[colindex].HeaderText;
                        range.Font.Bold = FontStyle.Bold;
                        range.HorizontalAlignment = NetOffice.ExcelApi.Enums.XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = NetOffice.ExcelApi.Enums.XlVAlign.xlVAlignCenter;
                        //End Isi Header baris ke tiga dari header tabel
                        size++;
                        if (size == Size.Rows.Count)
                        {
                            //Isi Header Tanggal dan Jam
                            range = xlWorksheet.get_Range(pre + ((char)(b + 2 + 65 - Size.Rows.Count)).ToString() + "4", pre + ((char)(b + 1 + 65)).ToString() + "4");
                            range.Merge(misValue);
                            range.FormulaR1C1 = Tanggal[tanggalidx].ToString().Substring(0, 10);
                            range.Font.Bold = FontStyle.Bold;
                            range.HorizontalAlignment = NetOffice.ExcelApi.Enums.XlHAlign.xlHAlignCenter;
                            range.VerticalAlignment = NetOffice.ExcelApi.Enums.XlVAlign.xlVAlignCenter;

                            range = xlWorksheet.get_Range(pre + ((char)(b + 2 + 65 - Size.Rows.Count)).ToString() + "3", pre + ((char)(b + 1 + 65)).ToString() + "3");
                            range.Merge(misValue);
                            range.FormulaR1C1 = Tanggal[tanggalidx].ToString().Substring(11);
                            range.Font.Bold = FontStyle.Bold;
                            range.HorizontalAlignment = NetOffice.ExcelApi.Enums.XlHAlign.xlHAlignCenter;
                            range.VerticalAlignment = NetOffice.ExcelApi.Enums.XlVAlign.xlVAlignCenter;
                            //End Isi Header Tanggal dan jam
                            size = 0;
                            tanggalidx++;
                        }
                        colindex++;
                    }
                }
                #endregion

                #region Mengisi Cell yang ada
                int baris = 6;
                foreach (DataRow br in queri.GetData().Rows)
                {
                    colindex = 0;
                    for (int a = 0; a < hasilbagi; a++)
                    {
                        string pre = ((char)(a + 64)).ToString();
                        if (a == 0)
                            pre = "";
                        int huruf = 26;
                        if (a == hasilbagi - 1)
                            if (sisabagi > 0)
                                huruf = sisabagi;
                        xlWorksheet.get_Range(pre + ((char)(65)).ToString() + (baris).ToString(), pre + ((char)(65)).ToString() + (baris).ToString()).FormulaR1C1 = baris - 5;
                        for (int b = 0; b < huruf; b++)
                        {
                            xlWorksheet.get_Range(pre + ((char)(b + 1 + 65)).ToString() + (baris).ToString(), pre + ((char)(b + 1 + 65)).ToString() + (baris).ToString()).FormulaR1C1 = br[colindex];
                            colindex++;
                        }
                    }
                    baris++;
                }
                #endregion
                Cursor.Current = Cursors.Default;

                try
                {
                    range = xlWorksheet.get_Range("A1", "A1");
                    range.FormulaR1C1 = judul.ToUpper();
                    range.Font.Size = 14;
                    range.Font.Bold = FontStyle.Bold;

                    xlWorksheet.get_Range("A2", "A2").RowHeight = 5;
                    xlWorksheet.UsedRange.WrapText = false;
                    xlApp.Visible = true;
                    xlWorksheet.SaveAs(sf.FileName, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
                    MessageBox.Show("Export Selesai!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ex.LogError(A.GetCurrentMethod());
                }
                finally
                {
                    xlApp.Dispose();
                    System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
                }
            }

        }
        public static string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                //converimage to byte
                image.Save(ms, format);
                byte[] imageByte = ms.ToArray();

                //conver byte[] to base64 string
                string base64string = Convert.ToBase64String(imageByte);
                return base64string;
            }
        }
        public static bool SaveImage(this Image image, string ProId)
        {
            if (image is null)
            { return false; }
            else
            {
                string pathDestination = Path.Combine(Environment.CurrentDirectory, "images");
                if (!Directory.Exists(pathDestination))
                    Directory.CreateDirectory(pathDestination);
                Bitmap bmp = (Bitmap)image;
                bmp.SetResolution(100, 100);
                System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameter encoderParameter = new EncoderParameter(encoder, 25L);
                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = encoderParameter;
                ImageCodecInfo imageCodecInfo = GetEncodeInfo("image/jpeg");

                try
                {
                    bmp.Save(Path.Combine(pathDestination, ProId + ".jpg"), imageCodecInfo, encoderParameters);
                    return true;
                }
                catch (IOException)
                {
                    return false;
                }
            }
        }
        public static Image LoadImage(this Image image)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                RestoreDirectory = true,
                Filter = "Image Files (*.jpg)|*.jpg",
                FilterIndex = 2
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                return (Bitmap)Image.FromFile(filename: openFileDialog.FileName);
            else
                return image;
        }
        public static Image LoadImage(this string ProId)
        {
            try
            {
                Image image = null;
                using (var bmptemp = new Bitmap(filename: Path.Combine(Environment.CurrentDirectory, "images", ProId + ".jpg")))
                {
                    image = new Bitmap(original: bmptemp);
                }
                return image;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool DeleteImage(this string ProId)
        {
            string filename = Path.Combine(Environment.CurrentDirectory, "images", ProId + ".jpg");
            FileInfo fileInfo = new FileInfo(filename);
            FileStream stream = null;

            try
            {
                stream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.None);
                fileInfo.Delete();
                return true;
            }
            catch (IOException)
            {
                return false;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
        private static ImageCodecInfo GetEncodeInfo(string mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        #endregion End Export / Import

        #region Async
        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);
        public static void SetControlPropertyValue(Control oControl, string propName, object propValue)
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
        public static async Task<string> GetStringValues(this string queri)
        {
            return await GetValue(queri);
        }
        #endregion

        #region LoadData
        public static List<string> LoadAkses(this ComboBox cb)
        {
            id = new List<string>();
            cb.Items.Clear();
            foreach (DataRow b in GetData("SELECT `id_akses`, `nama_akses` FROM `m_akses` ORDER BY `id_akses`;").Rows)
            {
                id.Add(b[0].ToString());
                cb.Items.Add(b[1].ToString());
            }
            return id;
        }
        public static List<string> LoadJenisNilai(this ComboBox cb)
        {
            id = new List<string>();
            cb.Items.Clear();
            foreach (DataRow br in GetData("SELECT `kode_jenisnilai`, `namajenisnilai` FROM `r_jenisnilai` " +
                "WHERE `hapus`='N' ORDER BY `namajenisnilai` ASC;").Rows)
            {
                id.Add(br[0].ToString());
                cb.Items.Add(br[1].ToString());
            }
            return id;
        }
        public static void LoadTahunAjaran(ComboBox cb)
        {
            int nows = int.Parse(DateTime.Now.ToString("yyyy"));
            int next = nows + 1;
            cb.Items.Clear();
            while (nows >= 1990)
            {
                cb.Items.Add(nows + "/" + next);
                nows--;
                next--;
            }
        }
        public static List<string> LoadKelas(this ComboBox cb, string KodeGuru, string TahunAjaran)
        {
            id = new List<string>();
            cb.Items.Clear();
            foreach (DataRow br in GetData("SELECT `J`.`kode_kelas`, `namakelas` FROM `tb_jadwal` `J` " +
                "LEFT JOIN `r_kelas` `K` ON `K`.`kode_kelas`=`J`.`kode_kelas` " +
                "WHERE `tahunajaran`='"+TahunAjaran+"' AND `kode_guru`='"+KodeGuru+"' " +
                "GROUP BY `J`.`kode_kelas` ORDER BY `namakelas` ASC").Rows)
            {
                id.Add(br[0].ToString());
                cb.Items.Add(br[1].ToString());
            }
            return id;
        }
        public static List<string> LoadKelas(this ComboBox cb)
        {
            id = new List<string>();
            cb.Items.Clear();
            foreach (DataRow br in GetData("SELECT `kode_kelas`, `namakelas` FROM `r_kelas` WHERE `hapus`='N' ORDER BY `namakelas` ASC").Rows)
            {
                id.Add(br[0].ToString());
                cb.Items.Add(br[1].ToString());
            }
            return id;
        }
        public static List<string> LoadPelajaran(this ComboBox cb, string TahunAjaran, string KodeGuru, string KodeKelas)
        {
            id = new List<string>();
            cb.Items.Clear();
            foreach (DataRow br in GetData("SELECT `kodepelajaran`, `namapelajaran` FROM `tb_jadwal` `J` " +
                "LEFT JOIN `r_matapelajaran` `MP` ON `MP`.`kodepelajaran`=`J`.`kode_pelajaran` " +
                "WHERE `tahunajaran`='" + TahunAjaran + "' AND `kode_guru`='" + KodeGuru + "' " +
                "AND `kode_kelas`='" + KodeKelas + "' ORDER BY `namapelajaran` ASC").Rows)
            {
                id.Add(br[0].ToString());
                cb.Items.Add(br[1].ToString());
            }
            return id;
        }
        public static List<string> LoadPelajaran(this ComboBox cb)
        {
            id = new List<string>();
            cb.Items.Clear();
            foreach (DataRow br in GetData("SELECT `kodepelajaran`, `namapelajaran` FROM `r_matapelajaran` " +
                "WHERE `hapus`='N' ORDER BY `namapelajaran` ASC").Rows)
            {
                id.Add(br[0].ToString());
                cb.Items.Add(br[1].ToString());
            }
            return id;
        }
        #endregion
    }
    #region Setting
    public static class S
    {
        private static int divs = 1;
        private static Color colorpaneljudul = Color.White, statusstripmaincolor = Color.White, colorlabeljudul = Color.White, datagridviewaksencolor = Color.White,
            buttonmaincolor = Color.White, buttonaksencolor = Color.White, statusstripaksencolor = Color.White, forecolor = Color.White, backcolor = Color.White;
        private static string username = "", usernama = "", userid = "", useracces = "", endIpAddress = "000", statusstripmessage = "", notifsound = "",
            kodeguru="", kodesiswa="";
        public static string GetKodesiswa()
        {
            return kodesiswa;
        }
        public static void SetKodesiswa(string value)
        {
            kodesiswa = value;
        }
        public static string GetKodeGuru()
        {
            return kodeguru;
        }
        public static void SetKodeGuru(string value)
        {
            kodeguru = value;
        }
        public static int GetDivs()
        {
            return divs;
        }
        public static void SetDivs(int value)
        {
            divs = value;
        }
        public static Color GetColorpaneljudul()
        {
            return colorpaneljudul;
        }
        public static void SetColorpaneljudul(Color value)
        {
            colorpaneljudul = value;
        }
        public static string GetStatusstripmessage()
        {
            return statusstripmessage;
        }
        public static void SetStatusstripmessage(string value)
        {
            statusstripmessage = value;
        }
        public static Color GetStatusstripmaincolor()
        {
            return statusstripmaincolor;
        }
        public static void SetStatusstripmaincolor(Color value)
        {
            statusstripmaincolor = value;
        }
        public static Color GetStatusstripaksencolor()
        {
            return statusstripaksencolor;
        }
        public static void SetStatusstripaksencolor(Color value)
        {
            statusstripaksencolor = value;
        }
        public static Color GetColorlabeljudul()
        {
            return colorlabeljudul;
        }
        public static void SetColorlabeljudul(Color value)
        {
            colorlabeljudul = value;
        }
        public static Color GetDatagridviewaksencolor()
        {
            return datagridviewaksencolor;
        }
        public static void SetDatagridviewaksencolor(Color value)
        {
            datagridviewaksencolor = value;
        }
        public static Color GetButtonmaincolor()
        {
            return buttonmaincolor;
        }
        public static void SetButtonmaincolor(Color value)
        {
            buttonmaincolor = value;
        }
        public static Color GetButtonaksencolor()
        {
            return buttonaksencolor;
        }
        public static void SetButtonaksencolor(Color value)
        {
            buttonaksencolor = value;
        }
        public static Color GetForecolor()
        {
            return forecolor;
        }
        public static void SetForecolor(Color value)
        {
            forecolor = value;
        }
        public static Color GetBackcolor()
        {
            return backcolor;
        }
        public static void SetBackcolor(Color value)
        {
            backcolor = value;
        }
        public static string GetUsername()
        {
            return username;
        }
        public static void SetUsername(string value)
        {
            username = value;
        }
        public static string GetUsernama()
        {
            return usernama;
        }
        public static void SetUsernama(string value)
        {
            usernama = value;
        }
        public static string GetUserid()
        {
            return userid;
        }
        public static void SetUserid(string value)
        {
            userid = value;
        }
        public static string GetUseracces()
        {
            return useracces;
        }
        public static void SetUseracces(string value)
        {
            useracces = value;
        }
        public static void SetControlFrom(this Form f)
        {
            f.BackColor = GetBackcolor();
            f.ForeColor = GetForecolor();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "apps.ico");
            if (File.Exists(path))
                f.Icon = Icon.ExtractAssociatedIcon(path);
            else
                f.Icon = SINIS.Properties.Resources._default;
            f.SetControl(f.Text);
        }
        private static void SetControl(this Control control, string text)
        {
            Color forecolor = GetForecolor();
            Color backcolor = GetBackcolor();
            foreach (var a in control.Controls)
            {
                if (a is DateTimePicker dtp)
                {
                    dtp.CalendarForeColor = forecolor;
                    dtp.CalendarMonthBackground = backcolor;
                    dtp.CalendarTitleBackColor = backcolor;
                    dtp.CalendarTitleForeColor = forecolor;
                }
                else if (a is DataGridView)
                {
                    var aksen = S.GetDatagridviewaksencolor();
                    var dd = ((DataGridView)a);
                    dd.GridColor = aksen;
                    dd.BackgroundColor = backcolor;
                    dd.RowHeadersDefaultCellStyle.SelectionBackColor = aksen;
                    dd.RowHeadersDefaultCellStyle.BackColor = backcolor;
                    dd.RowHeadersDefaultCellStyle.ForeColor = forecolor;
                    dd.RowHeadersDefaultCellStyle.SelectionForeColor = backcolor;
                    dd.DefaultCellStyle.SelectionBackColor = aksen;
                    dd.DefaultCellStyle.SelectionForeColor = backcolor;
                }
                else if (a is LinkLabel ll)
                {
                    var warna = S.GetColorlabeljudul();
                    ll.ForeColor = warna;
                    ll.LinkColor = warna;
                    ll.ActiveLinkColor = warna;
                    ll.VisitedLinkColor = warna;
                    ll.Text = text;
                }
                else if (a is TextBox tb)
                {
                    tb.ForeColor = forecolor;
                    tb.BackColor = backcolor;
                }
                else if (a is RichTextBox rtb)
                {
                    rtb.ForeColor = forecolor;
                    rtb.BackColor = backcolor;
                }
                else if (a is ComboBox cb)
                {
                    cb.ForeColor = forecolor;
                    cb.BackColor = backcolor;
                }
                else if (a is Button bt)
                {
                    bt.BackColor = S.GetButtonmaincolor();
                    bt.ForeColor = S.GetButtonaksencolor();

                }
                else if (a is StatusStrip ss)
                {
                    ss.BackColor = GetStatusstripmaincolor();
                    ss.ForeColor = GetStatusstripaksencolor();
                    ss.Items.Clear();
                    ss.Items.Add("Halo, " + GetUsernama());
                    ToolStripStatusLabel status = new ToolStripStatusLabel(GetStatusstripmessage().DecodeUtf8()) { Spring = true };
                    ss.Items.Add(status);
                    ss.Items.Add("JAM");
                    Timer timer = new Timer();
                    timer.Tick += (sender, e) =>
                    {
                        if (ss.Items.Count >= 4)
                            ss.Items[4].Text = DateTime.Now.ToString("ddd, dd-MMM-yyyy HH mm ss");
                    };
                    timer.Enabled = true;
                }
                else if (a is Label lb)
                {
                    lb.Text = lb.Text.ToUpper();
                }
                else if (a is FlowLayoutPanel flp)
                {
                    flp.BackColor = S.GetColorpaneljudul();
                    SetControl(flp, text);
                }
                else if (a is Panel pn)
                {
                    pn.BackColor = Color.Transparent;
                    SetControl(pn, text);
                }
                else if (a is GroupBox gb)
                {
                    gb.Text = gb.Text.ToUpper();
                    gb.ForeColor = forecolor;
                    gb.BackColor = backcolor;
                    SetControl(gb, text);
                }
            }
        }
        public static void ClearControl(this Control control)
        {
            foreach (var a in control.Controls)
            {
                if (a is TextBox)
                    ((TextBox)a).Clear();
                else if (a is ComboBox)
                    ((ComboBox)a).SelectedIndex = -1;
                else if (a is DateTimePicker)
                    ((DateTimePicker)a).Value = DateTime.Now;
                else if (a is PictureBox)
                    ((PictureBox)a).Image = null;
                else if (a is Panel)
                    ClearControl((Panel)a);
                else if (a is GroupBox)
                    ClearControl((GroupBox)a);
            }
        }
        public static void SetSettings()
        {
            SetDivs(A.GetDataSettings("divs").ToInteger());
            SetColorpaneljudul(A.GetDataSettings("colorpaneljudul").StringToColor());
            SetStatusstripmessage(A.GetDataSettings("statusstripmessage"));
            SetStatusstripmaincolor(A.GetDataSettings("statusstripmaincolor").StringToColor());
            SetStatusstripaksencolor(A.GetDataSettings("statusstripaksencolor").StringToColor());
            SetColorlabeljudul(A.GetDataSettings("colorlabeljudul").StringToColor()); ;
            SetDatagridviewaksencolor(A.GetDataSettings("datagridviewaksencolor").StringToColor());
            SetButtonmaincolor(A.GetDataSettings("buttonmaincolor").StringToColor());
            SetButtonaksencolor(A.GetDataSettings("buttonaksencolor").StringToColor());
            SetForecolor(A.GetDataSettings("forecolor").StringToColor());
            SetBackcolor(A.GetDataSettings("backcolor").StringToColor());
            SetEndIpAddress(A.GetEndLocalIpAddress());
        }
        public static string GetNotifsound()
        {
            return notifsound;
        }
        public static void SetNotifsound(string value)
        {
            notifsound = value;
        }
        public static string GetEndIpAddress()
        {
            return endIpAddress;
        }
        public static void SetEndIpAddress(string value)
        {
            endIpAddress = value;
        }
        public static void SetRunningText(this Label lb, int Width, string text = "", int speed = 1)
        {
            if (!string.IsNullOrEmpty(text))
            {
                lb.Text = text;
                lb.Location = new Point(Width, 0);
                lb.AutoSize = true;

                Timer t = new Timer
                {
                    Interval = 15
                };
                t.Tick += (sender, e) =>
                {
                    lb.Location = new Point(lb.Location.X - speed, lb.Location.Y);
                    if (lb.Location.X + lb.Width < 0)
                    {
                        lb.Location = new Point(Width, lb.Location.Y);
                    }
                };
                t.Start();
            }
        }
    }
    #endregion
}
public static class MyPrinters
{
    [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool SetDefaultPrinter(string Name);
}