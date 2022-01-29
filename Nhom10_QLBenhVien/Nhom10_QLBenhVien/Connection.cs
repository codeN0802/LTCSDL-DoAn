using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Nhom10_QLBenhVien
{
    class Connection
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        
        public Connection()
        {
            string chuoiketnoi = @"Server=DESKTOP-NT03218\SQLEXPRESS; database=DBQuanLyBenhVien; Integrated Security=true;"; //them \ hoac @
            con = new SqlConnection(chuoiketnoi);
            try
            {
                con.Open();
            }
            catch
            {
                MessageBox.Show("Error", "Error when connecting your database");
                return;
            }
        }

        public Connection(string serverName, string dbName, bool auth, string uid, string pwd)
        {
            string chuoiketnoi;
            if (auth) // window authentication
                chuoiketnoi = string.Format(@"Data Source={0}; Initial Catalog={1}; Integrated Security=true;", serverName, dbName);
            else // sqlserver authentication
                chuoiketnoi = string.Format(@"Data Source={0}; Initial Catalog={1}; Integrated Security=false;uid={2},pwd={3}", serverName, dbName, uid, pwd);
            con = new SqlConnection(chuoiketnoi);
        }
        public DataTable LAYDULIEU(string lenhsql)
        {
            da = new SqlDataAdapter(lenhsql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public void CAPNHAP(string lenhsql, DataTable table)
        {
            da = new SqlDataAdapter(lenhsql, con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.Update(table);
        }
        public void THEMXOASUA(string lenhsql)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand com = new SqlCommand(lenhsql, con);
            com.ExecuteNonQuery();
            con.Close();

        }
    }
        
    
}
