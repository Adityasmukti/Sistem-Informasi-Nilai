//using Finisar.SQLite;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using ExtensionMethods;
using System.Threading.Tasks;

public class ModulData
{
    public MySqlConnection koneksi;
    public MySqlConnection koneksi2;
    private MySqlCommand perintah;
    private MySqlDataAdapter adapter;
    private MySqlDataReader reader;
    private string queri;
    /*
    ====================================================================================================================================================
        DI SINI TEMPAT UNTUK MENEMPATKAN PUBLIC FUNCTION
    ====================================================================================================================================================        
     */
    private string server = "";
    private string database = "";
    private string uid = "";
    private string pwd = "";
    private string port = "";

    public ModulData()
    {
        string strcon = "server = " + server + ";" +
            "database=" + database + ";" +
            "uid=" + uid + ";" +
            "pwd=" + pwd + ";" +
            "port=" + port + ";" +
            "SslMode=none;" +
            "Pooling=true;" +
            "Min Pool Size=0;" +
            "Max Pool Size=150;" +
            "Persist Security Info=True;" +
            "respect binary flags=false;" +
            "Allow User Variables=True;";
        koneksi = new MySqlConnection(strcon);
        koneksi2 = new MySqlConnection(strcon);
    }
    public string GetDataSettings(string KeySetting)
    {
        string value = "";
        queri = "SELECT `nilai` FROM `r_settings` WHERE `pengaturan`='"+KeySetting+"' LIMIT 1";
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
    public DataSet GetData(string queri)
    {

        DataSet ds1 = new DataSet();
        ds1.Clear();
        try
        {
            if (koneksi.State == ConnectionState.Closed)
                koneksi.Open();
            perintah = new MySqlCommand(queri, koneksi);
            adapter = new MySqlDataAdapter(perintah);
            perintah.ExecuteNonQuery();
            adapter.Fill(ds1);
        }
        catch (Exception ex)
        {
            ex.LogError(A.GetCurrentMethod(),"", queri);
            ds1 = null; 
        }
        finally
        {
            koneksi.Close();
        }
        return ds1;
    }
    public string Singeldata(string queri)
    {
        string output = "";
        try
        {
            foreach (DataRow baris in GetData(queri).Tables[0].Rows)
            {
                output = baris[0].ToString();
                break;
            }
        }
        catch (Exception ex)
        {
            ex.LogError(A.GetCurrentMethod(),"", queri);
        }
        return output;
    }
    public bool Cekstatus()
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
    public bool ManipulasiData(string queri)
    {
        //sint res = 0;
        try
        {
            koneksi.Open();
            perintah = new MySqlCommand(queri, koneksi);
            perintah.ExecuteNonQuery();
            koneksi.Close();
            return true;
        }
        catch (Exception ex)
        {
            ex.LogError(A.GetCurrentMethod(), "", queri);
        }
        if (koneksi.State == ConnectionState.Open)
            koneksi.Close();
        return false;
    }
    public bool ManipulasiData(string queri, out int rows)
    {
        int res = 0;
        try
        {
            koneksi.Open();
            perintah = new MySqlCommand(queri, koneksi);
            res = perintah.ExecuteNonQuery();
            koneksi.Close();
            rows = res;
            return true;
        }
        catch (Exception ex)
        {
            koneksi.Close();
            ex.LogError(A.GetCurrentMethod(), "", queri);
        }
        rows = res;
        return false;
    }
    public int Jumlahdata(string queri)
    {
        int count = 0;
        foreach(DataRow baris in GetData(queri).Tables[0].Rows)
            count ++;
        return count;
    }
    public bool Search(string queri)
    {
        bool ada = false;
        foreach (DataRow baris in GetData(queri).Tables[0].Rows)
        {
            ada = true;
            break;
        }
        if (koneksi.State == ConnectionState.Open)
            koneksi.Close();
        return ada;
    }
    public async Task<string> GetValue(string queri)
    {
        string result = "";
        koneksi2.Open();
        var com = new  MySqlCommand(queri, koneksi2);
        var reader = await com.ExecuteReaderAsync();
        while(reader.Read())
        {
            result = reader[0].ToString();
        }
        reader.Close();
        koneksi2.Close();
        return result;
    }
}
