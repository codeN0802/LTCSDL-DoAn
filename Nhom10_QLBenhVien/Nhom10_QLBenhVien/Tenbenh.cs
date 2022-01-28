using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace Nhom10_QLBenhVien
{
    public partial class Tenbenh : Form
    {
        Connection cn = new Connection();
        DataTable dtTenBenh,dtKhoa;
        DataColumn[] keytenbenh = new DataColumn[1];
        bool them = false;
        SqlConnection con;
        public Tenbenh()
        {
            InitializeComponent();
        }
      

        private void Tenbenh_Load(object sender, EventArgs e)
        {
            dtTenBenh = cn.LAYDULIEU("select *from TenBenh$");
            dtKhoa = cn.LAYDULIEU("select * from Khoa$");

            keytenbenh[0] = dtTenBenh.Columns[0];
            dtTenBenh.PrimaryKey = keytenbenh;
            
                      
          //  dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtTenBenh;
            dataGridView1.Columns[0].DataPropertyName = "MaBenh";
            dataGridView1.Columns[1].DataPropertyName = "TenBenh";
            dataGridView1.Columns[2].DataPropertyName = "TrieuChung";
         //   DataGridViewComboBoxColumn cbocol = (DataGridViewComboBoxColumn)dataGridView1.Columns[3];

            
          

            TenBenh_DataBiding();
        }
        void TenBenh_DataBiding()
        {
            txtMaBenh.DataBindings.Add("Text", dtTenBenh, "MaBenh");
            txtTenBenh.DataBindings.Add("Text", dtTenBenh, "TenBenh");
            txtTrieuChung.DataBindings.Add("Text", dtTenBenh, "TrieuChung");
            txtMaKhoa.DataBindings.Add("Text", dtTenBenh, "MaKhoa");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            them = true;
            txtMaBenh.DataBindings.Clear();
            txtTenBenh.DataBindings.Clear();
            txtTrieuChung.DataBindings.Clear();
            txtMaKhoa.DataBindings.Clear();

            txtMaBenh.Clear();
            txtTenBenh.Clear();
            txtTrieuChung.Clear();
            txtMaKhoa.Clear();


            txtMaBenh.Enabled = txtTenBenh.Enabled = txtTrieuChung.Enabled = txtMaKhoa.Enabled = true;

            btnThem.Enabled = btnTra.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            them = false;
            txtMaBenh.Enabled = false;
            txtTenBenh.Enabled = txtTrieuChung.Enabled = txtMaKhoa.Enabled = true;
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
                DataTable dtTenBenh = cn.LAYDULIEU("select distinct MaBenh from TenBenh$ where MaBenh='" + txtMaBenh.Text + "'");
                if (dtTenBenh.Rows.Count == 0)
                {
                    DataRow r = dtTenBenh.Rows.Find(txtMaBenh.Text);
                    if (r != null)
                        r.Delete();
                }
                else
                    MessageBox.Show("Bệnh đang tồn tại không xóa được");
            }
        }
        public void HienThi()
        {
            string sqlSELECT = "select *from Thuoc$";
            SqlCommand cmd = new SqlCommand(sqlSELECT, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnTra_Click(object sender, EventArgs e)
        {
         
            Connection tim = new Connection();
            dataGridView1.DataSource = tim.LAYDULIEU("select * from TenBenh$ where TenBenh like'%' +N'" + txtMaCanTim.Text +"'+ '%'");
        }
    }
}
