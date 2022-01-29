using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using LTCSDL.DTO;


namespace LTCSDL.DAL
{
    public class BenhDAL
    {
        private SqlConnection cnn;
        private SqlCommand cmd;

        public BenhDAL()
        {
            string cnStr = @"Server=DESKTOP-NT03218\SQLEXPRESS; database=DBQuanLyBenhVien; Integrated Security=true;";
            cnn = new SqlConnection(cnStr);
        }
        public List<Benh> GetAll()
        {
            string sqlStr = "select MaBenh, TenBenh, TrieuChung, MaKhoa  from TenBenh$";
            List<Benh> lst = new List<Benh>();
            try
            {
                cnn.Open();
                cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = sqlStr;
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Benh cat = new Benh();
                    cat.MaBenh = int.Parse(reader["MaBenh"].ToString());
                    cat.TenBenh = reader["TenBenh"].ToString();
                    cat.TrieuChung = reader["TrieuChung"].ToString();
                    cat.MaKhoa = reader["MaKhoa"].ToString();

                    lst.Add(cat);
                }
                reader.Close();
                cnn.Close();
            }
            catch (Exception e)
            {
                lst = null;
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return lst;
        }
    }
}
