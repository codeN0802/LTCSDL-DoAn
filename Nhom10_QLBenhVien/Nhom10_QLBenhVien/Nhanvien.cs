using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom10_QLBenhVien
{
    public partial class Nhanvien : Form
    {
        Connection cn = new Connection();
        DataTable dtNhanvien, dtKhoa;
        DataColumn[] keynv = new DataColumn[1];
        bool themmoi = false;
        public Nhanvien()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Nhanvien_Load(object sender, EventArgs e)
        {
            dtNhanvien = cn.LAYDULIEU("select * from NhanVien$");
            dtKhoa = cn.LAYDULIEU("select * from Khoa$");

            keynv[0] = dtNhanvien.Columns[0];
            dtNhanvien.PrimaryKey = keynv;

            cboKhoa.DataSource = dtKhoa;
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtNhanvien;
            dataGridView1.Columns[0].DataPropertyName = "MaNhanVien";
            dataGridView1.Columns[1].DataPropertyName = "TenNhanVien";
            dataGridView1.Columns[2].DataPropertyName = "ChucVu";
            dataGridView1.Columns[3].DataPropertyName = "GioiTinh";
            dataGridView1.Columns[4].DataPropertyName = "SDT";
            dataGridView1.Columns[5].DataPropertyName = "CMND";
            dataGridView1.Columns[6].DataPropertyName = "NgaySinh";
            DataGridViewComboBoxColumn khoa = (DataGridViewComboBoxColumn)dataGridView1.Columns[7];
            khoa.DataSource = dtKhoa;
            khoa.DisplayMember = "TenKhoa";
            khoa.ValueMember = "MaKhoa";
            khoa.DataPropertyName = "MaKhoa";

            Nhanvien_DataBiding();
        }
        
        void Nhanvien_DataBiding()
        {
            txtManv.DataBindings.Add("Text", dtNhanvien, "MaNhanVien");
            txtTennv.DataBindings.Add("Text", dtNhanvien, "TenNhanVien");
            txtChucvu.DataBindings.Add("Text", dtNhanvien, "ChucVu");
            txtCMND.DataBindings.Add("Text", dtNhanvien, "CMND");
            txtGioitinh.DataBindings.Add("Text", dtNhanvien, "GioiTinh");
            txtSDT.DataBindings.Add("Text", dtNhanvien, "SDT");
            datetimeNS.DataBindings.Add("Text", dtNhanvien, "NgaySinh");
            cboKhoa.DataBindings.Add("SelectedValue", dtNhanvien, "MaKhoa");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            txtManv.DataBindings.Clear();
            txtTennv.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtGioitinh.DataBindings.Clear();
            txtCMND.DataBindings.Clear();
            txtChucvu.DataBindings.Clear();
            datetimeNS.DataBindings.Clear();
            cboKhoa.DataBindings.Clear();

            txtManv.Clear();
            txtTennv.Clear();
            txtSDT.Clear();
            txtGioitinh.Clear();
            txtCMND.Clear();
            txtChucvu.Clear();

            datetimeNS.Enabled = true;
            txtManv.Enabled = txtTennv.Enabled = txtSDT.Enabled = txtGioitinh.Enabled = txtChucvu.Enabled = txtCMND.Enabled = cboKhoa.Enabled = true;

            btnThem.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(themmoi)
            {
                if(txtManv.Text !=""||txtTennv.Text !=""||txtSDT.Text !=""||txtGioitinh.Text !=""||txtCMND.Text !=""||txtChucvu.Text !="")
                {
                    DataRow newrow = dtNhanvien.NewRow();
                    newrow["MaNhanVien"] = txtManv.Text;
                    newrow["TenNhanVien"] = txtTennv.Text;
                    newrow["SDT"] = txtSDT.Text;
                    newrow["GioiTinh"] = txtGioitinh.Text;
                    newrow["CMND"] = txtCMND.Text;
                    newrow["NgaySinh"] = datetimeNS.Text;
                    newrow["ChucVu"] = txtChucvu.Text;
                    newrow["MaKhoa"] = cboKhoa.SelectedValue.ToString();
                    dtNhanvien.Rows.Add(newrow);
                }
                Nhanvien_DataBiding();

            }else
            {
                dataGridView1.Refresh();
            }
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            txtManv.Enabled = false;
            txtTennv.Enabled = txtSDT.Enabled = txtGioitinh.Enabled = txtChucvu.Enabled = txtCMND.Enabled = cboKhoa.Enabled = true;

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            dataGridView1.ReadOnly = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc không?", "Cảnh báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                //ktr khóa ngoại 
                DataTable dtPhieukhambenh = cn.LAYDULIEU("select distinct MaNhanVien from PhieuKhamBenh$ where MaNhanVien='" + txtManv.Text + "'");
                if (dtPhieukhambenh.Rows.Count == 0)//ko tồn tại trong bảng sinh viên
                {
                    DataRow r = dtNhanvien.Rows.Find(txtManv.Text);
                    if (r != null)
                        r.Delete();
                }
                else
                    MessageBox.Show("Nhân viên đang tồn tại không xóa được");
            }
        }

        
       
       
     
    }
}
