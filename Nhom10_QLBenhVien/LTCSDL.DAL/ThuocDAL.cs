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
    public class ThuocDAL
    {
        private SqlConnection cnn;
        private SqlCommand cmd;

        public ThuocDAL()
        {
            string cnStr = @"Server=DESKTOP-NT03218\SQLEXPRESS; database=DBQuanLyBenhVien; Integrated Security=true;";
            cnn = new SqlConnection(cnStr);
        }
        public List<Thuocx> GetAll()
        {
            string sqlStr = "select MaThuoc, TenThuoc, XuatXu, GiaTien, MaBenh  from Thuoc$";
            List<Thuocx> lst = new List<Thuocx>();
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
                    Thuocx cat = new Thuocx();
                    cat.MaThuoc = int.Parse(reader["MaThuoc"].ToString());
                    cat.TenThuoc = reader["TenThuoc"].ToString();
                    cat.XuatXu = reader["XuatXu"].ToString();
                    cat.GiaTien = int.Parse(reader["GiaTien"].ToString());
                    cat.MaBenh = int.Parse(reader["MaBenh"].ToString());

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
