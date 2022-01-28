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
    public partial class BenhNhan : Form
    {
        Connection cn = new Connection();
        DataTable dtBenhNhan, dtTenBenh;
        DataColumn[] keybn = new DataColumn[1];
        bool them = false;
        public BenhNhan()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            

            them = true;
            txtMaBN.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtQuequan.DataBindings.Clear();
            txtBHYT.DataBindings.Clear();
            txtGT.DataBindings.Clear();
            txtNgheN.DataBindings.Clear();
            dTNS.DataBindings.Clear();
            cboTenbenh.DataBindings.Clear();

            txtMaBN.Clear();
            txtTen.Clear();
            txtSDT.Clear();
            txtQuequan.Clear();
            txtBHYT.Clear();
            txtGT.Clear();
            txtNgheN.Clear();
            

            dTNS.Enabled = true;
            txtMaBN.Enabled = txtTen.Enabled = txtSDT.Enabled = txtGT.Enabled = txtBHYT.Enabled = txtQuequan.Enabled = txtNgheN.Enabled =cboTenbenh.Enabled = true;

            btnThem.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                if (txtMaBN.Text != "" || txtTen.Text != "" || txtSDT.Text != "" || txtGT.Text != "" || txtBHYT.Text != "" || txtQuequan.Text != "" || txtNgheN.Text != "")
                {
                    DataRow newrow = dtBenhNhan.NewRow();
                    newrow["MaBenhNhan"] = txtMaBN.Text;
                    newrow["TenBenhNhan"] = txtTen.Text;
                    newrow["SoDienThoai"] = txtSDT.Text;
                    newrow["GioiTinh"] = txtGT.Text;
                    newrow["TheBHYT"] = txtBHYT.Text;
                    newrow["QueQuan"] = txtQuequan.Text;
                    newrow["NgheNghiep"] = txtNgheN.Text;
                    newrow["NgaySinh"] = dTNS.Text;
                    newrow["MaKhoa"] = cboTenbenh.SelectedValue.ToString();
                    dtBenhNhan.Rows.Add(newrow);
                }
                Benhnhan_DataBiding();

            }
            else
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
            them = false;
            txtMaBN.Enabled = false;
            txtTen.Enabled = txtSDT.Enabled = txtGT.Enabled = txtBHYT.Enabled = txtQuequan.Enabled = cboTenbenh.Enabled = txtNgheN.Enabled= true;

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
                DataTable dtPhieukhambenh = cn.LAYDULIEU("select distinct MaBenhNhan from PhieuKhamBenh$ where MaBenhNhan='" + txtMaBN.Text + "'");
                if (dtPhieukhambenh.Rows.Count == 0)//ko tồn tại trong bảng sinh viên
                {
                    DataRow r = dtBenhNhan.Rows.Find(txtMaBN.Text);
                    if (r != null)
                        r.Delete();
                }
                else
                    MessageBox.Show("Nhân viên đang tồn tại không xóa được");
            }
        }

        private void BenhNhan_Load(object sender, EventArgs e)
        {
            dtBenhNhan = cn.LAYDULIEU("select * from BenhNhan$");
            dtTenBenh = cn.LAYDULIEU("select * from TenBenh$");

            keybn[0] = dtBenhNhan.Columns[0];
            dtBenhNhan.PrimaryKey = keybn;

            cboTenbenh.DataSource = dtTenBenh;
            cboTenbenh.DisplayMember = "TenBenh";
            cboTenbenh.ValueMember = "MaBenh";

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtBenhNhan;
            dataGridView1.Columns[0].DataPropertyName = "MaBenhNhan";
            dataGridView1.Columns[1].DataPropertyName = "TenBenhNhan";
            dataGridView1.Columns[2].DataPropertyName = "SoDienThoai";
            dataGridView1.Columns[3].DataPropertyName = "QueQuan";
            dataGridView1.Columns[4].DataPropertyName = "TheBHYT";
            dataGridView1.Columns[5].DataPropertyName = "GioiTinh";
            dataGridView1.Columns[6].DataPropertyName = "NgaySinh";
            dataGridView1.Columns[7].DataPropertyName = "NgheNghiep";
            DataGridViewComboBoxColumn tenbenh = (DataGridViewComboBoxColumn)dataGridView1.Columns[8];
            tenbenh.DataSource = dtTenBenh;
            tenbenh.DisplayMember = "TenBenh";
            tenbenh.ValueMember = "MaBenh";
            tenbenh.DataPropertyName = "MaBenh";

            Benhnhan_DataBiding();
        }
        void Benhnhan_DataBiding()
        {
            txtMaBN.DataBindings.Add("Text", dtBenhNhan, "MaBenhNhan");
            txtTen.DataBindings.Add("Text", dtBenhNhan, "TenBenhNhan");
            txtSDT.DataBindings.Add("Text", dtBenhNhan, "SoDienThoai");
            txtQuequan.DataBindings.Add("Text", dtBenhNhan, "QueQuan");
            txtBHYT.DataBindings.Add("Text", dtBenhNhan, "TheBHYT");
            txtGT.DataBindings.Add("Text", dtBenhNhan, "GioiTinh");
            dTNS.DataBindings.Add("Text", dtBenhNhan, "NgaySinh");
            txtNgheN.DataBindings.Add("Text", dtBenhNhan, "NgheNghiep");
            cboTenbenh.DataBindings.Add("SelectedValue", dtBenhNhan, "MaBenh");
        }

       
       
    }
}
