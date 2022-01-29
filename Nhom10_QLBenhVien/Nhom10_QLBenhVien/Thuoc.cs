using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Nhom10_QLBenhVien
{
    public partial class Thuoc : Form
    {
        Connection cn = new Connection();
        DataTable dtThuoc;
        DataColumn[] keythuoc = new DataColumn[1];
        bool them = false;
        public Thuoc()
        {
            InitializeComponent();
        }
        SqlConnection con;

        private void Thuoc_Load(object sender, EventArgs e)
        {
            //string conString = ConfigurationManager.ConnectionStrings["QLThuoc"].ConnectionString.ToString();
            //con = new SqlConnection();
            //con.Open();          
            dtThuoc = cn.LAYDULIEU("select * from Thuoc$");
            keythuoc[0] = dtThuoc.Columns[0];
            dtThuoc.PrimaryKey = keythuoc;
            //cboTenbenh.DataSource = dtTenBenh;
            //cboTenbenh.DisplayMember = "TenBenh";
            //cboTenbenh.ValueMember = "MaBenh";

            //dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtThuoc;
            dataGridView1.Columns[0].DataPropertyName = "MaThuoc";
            dataGridView1.Columns[1].DataPropertyName = "TenThuoc";
            dataGridView1.Columns[2].DataPropertyName = "XuatXu";
            dataGridView1.Columns[3].DataPropertyName = "GiaTien";
            dataGridView1.Columns[4].DataPropertyName = "MaBenh";
            //thuoc.DataSource = dtThuoc;
            //thuoc.DisplayMember = "TenThuoc";
            //thuoc.ValueMember = "MaThuoc";
            //thuoc.DataPropertyName = "MaThuoc";

            Thuoc_DataBiding();
        }
        void Thuoc_DataBiding()
        {
            txtMaThuoc.DataBindings.Add("Text", dtThuoc, "MaThuoc");
            txtTenThuoc.DataBindings.Add("Text", dtThuoc, "TenThuoc");
            txtXuatXu.DataBindings.Add("Text", dtThuoc, "XuatXu");
            txtGiaTien.DataBindings.Add("Text", dtThuoc, "GiaTien");
            txtMaBenh.DataBindings.Add("Text", dtThuoc, "MaBenh");

        }

        private void btnThem_Click(object sender, EventArgs e)
        {


            them = true;
            txtMaThuoc.DataBindings.Clear();
            txtTenThuoc.DataBindings.Clear();
            txtXuatXu.DataBindings.Clear();
            txtGiaTien.DataBindings.Clear();
            txtMaBenh.DataBindings.Clear();
            //txtGT.DataBindings.Clear();
            //txtNgheN.DataBindings.Clear();
            //dTNS.DataBindings.Clear();
            //cboTenbenh.DataBindings.Clear();

            txtMaThuoc.Clear();
            txtTenThuoc.Clear();
            txtXuatXu.Clear();
            txtGiaTien.Clear();
            txtMaBenh.Clear();
            //txtGT.Clear();
            //txtNgheN.Clear();


            //dTNS.Enabled = true;
            txtMaThuoc.Enabled = txtTenThuoc.Enabled = txtXuatXu.Enabled = txtGiaTien.Enabled = txtMaBenh.Enabled = true;

            btnThem.Enabled = btnTra.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;
        }

        private void Thuoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            //con.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            txtMaThuoc.Enabled = false;
            txtTenThuoc.Enabled = txtXuatXu.Enabled = txtGiaTien.Enabled = txtMaBenh.Enabled = true;

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnTra.Enabled = true;
            dataGridView1.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc không?", "Cảnh báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
              == DialogResult.Yes)
            {
                //kiểm tra khóa ngoại
                DataTable dtThuoc = cn.LAYDULIEU("select distinct MaThuoc from Thuoc$ where MaThuoc='" + txtMaThuoc.Text + "'");
                if (dtThuoc.Rows.Count == 0)
                {
                    DataRow r = dtThuoc.Rows.Find(txtMaThuoc.Text);
                    if (r != null)
                        r.Delete();
                }
                else
                    MessageBox.Show("Thuốc đang tồn tại không xóa được");
            }
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            //DataTable dt = Red("select *from Thuoc$ where MaThuoc = '" + txtMaThuoc.Text + "'");
            //if(dt !=null)
            //{
            //    dataGridView1.DataSource = dt;
            //}

            string sqlTimKiem = "select *from Thuoc$ where MaThuoc =@MaThuoc";
            SqlCommand cmd = new SqlCommand(sqlTimKiem, con);
            cmd.Parameters.AddWithValue("MaThuoc", txtMaCanTim.Text);
            cmd.Parameters.AddWithValue("TenThuoc", txtTenThuoc.Text);
            cmd.Parameters.AddWithValue("XuatXu", txtXuatXu.Text);
            cmd.Parameters.AddWithValue("GiaTien", txtGiaTien.Text);
            cmd.Parameters.AddWithValue("MaBenh", txtMaBenh.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void btnTra_Click_1(object sender, EventArgs e)
        {
            Connection tim = new Connection();
            dataGridView1.DataSource = tim.LAYDULIEU("select * from Thuoc$ where MaBenh like'%' +N'" + txtMaCanTim.Text + "'+ '%'");
        }
        //public void HienThi()
        //{
        //    string sqlSELECT = "select *from Thuoc$";
        //    SqlCommand cmd = new SqlCommand(sqlSELECT, con);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    DataTable dt = new DataTable();
        //    dt.Load(dr);
        //    dataGridView1.DataSource = dt;
        //}
    }
}
