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
    public partial class Phieukhambenh : Form
    {
        Connection cn = new Connection();
        DataTable dtNhanVien, dtBenhNhan, dtTenBenh, dtThuoc, dtPhieuKham;
        DataColumn[] keyphieukham = new DataColumn[1];
        bool themmoi = false;

        private void button4_Click(object sender, EventArgs e)
        {

        }

        public Phieukhambenh()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Phieukhambenh_Load(object sender, EventArgs e)
        {
            dtPhieuKham = cn.LAYDULIEU("select * from PhieuKhamBenh$");
            dtNhanVien = cn.LAYDULIEU("select * from NhanVien$");
            dtBenhNhan = cn.LAYDULIEU("select * from BenhNhan$");
            dtTenBenh = cn.LAYDULIEU("select * from TenBenh$");
            dtThuoc = cn.LAYDULIEU("select * from Thuoc$");



            keyphieukham[0] = dtPhieuKham.Columns[0];
            dtPhieuKham.PrimaryKey = keyphieukham;

            cboThuoc.DataSource = dtThuoc;
            cboThuoc.DisplayMember = "TenThuoc";
            cboThuoc.ValueMember = "MaThuoc";

            cboBenh.DataSource = dtTenBenh;
            cboBenh.DisplayMember = "TenBenh";
            cboBenh.ValueMember = "MaBenh";

            cboBN.DataSource = dtBenhNhan;
            cboBN.DisplayMember = "TenBenhNhan";
            cboBN.ValueMember = "MaBenhNhan";

            cboNV.DataSource = dtNhanVien;
            cboNV.DisplayMember = "TenNhanVien";
            cboNV.ValueMember = "MaNhanVien";

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtPhieuKham;
            dataGridView1.Columns[0].DataPropertyName = "MaPKB";
            dataGridView1.Columns[1].DataPropertyName = "STT";
            dataGridView1.Columns[2].DataPropertyName = "NgayKham";
            dataGridView1.Columns[3].DataPropertyName = "NgayxuatVien";
            dataGridView1.Columns[4].DataPropertyName = "HuongDieuTri";

            DataGridViewComboBoxColumn thuoc = (DataGridViewComboBoxColumn)dataGridView1.Columns[5];
            thuoc.DataSource = dtThuoc;
            thuoc.DisplayMember = "TenThuoc";
            thuoc.ValueMember = "MaThuoc";
            thuoc.DataPropertyName = "MaThuoc";

            DataGridViewComboBoxColumn benh = (DataGridViewComboBoxColumn)dataGridView1.Columns[6];
            benh.DataSource = dtTenBenh;
            benh.DisplayMember = "TenBenh";
            benh.ValueMember = "MaBenh";
            benh.DataPropertyName = "MaBenh";

            DataGridViewComboBoxColumn bn = (DataGridViewComboBoxColumn)dataGridView1.Columns[7];
            bn.DataSource = dtBenhNhan;
            bn.DisplayMember = "TenBenhNhan";
            bn.ValueMember = "MaBenhNhan";
            bn.DataPropertyName = "MaBenhNhan";

            DataGridViewComboBoxColumn nv = (DataGridViewComboBoxColumn)dataGridView1.Columns[8];
            nv.DataSource = dtNhanVien;
            nv.DisplayMember = "TenNhanVien";
            nv.ValueMember = "MaNhanVien";
            nv.DataPropertyName = "MaNhanVien";

            PhieuKhamBenh_DataBiding();






        }

        private void PhieuKhamBenh_DataBiding()
        {
            txtMaPKB.DataBindings.Add("Text", dtPhieuKham, "MaPKB");
            txtSTT.DataBindings.Add("Text", dtPhieuKham, "STT");
            datetimeNgayKham.DataBindings.Add("Text", dtPhieuKham, "NgayKham");
            datetimeNgayXuatVien.DataBindings.Add("Text", dtPhieuKham, "NgayxuatVien");
            txtHDT.DataBindings.Add("Text", dtPhieuKham, "HuongDieuTri");
            cboThuoc.DataBindings.Add("SelectedValue", dtPhieuKham, "MaThuoc");
            cboBenh.DataBindings.Add("SelectedValue", dtPhieuKham, "MaBenh");
            cboBN.DataBindings.Add("SelectedValue", dtPhieuKham, "MaBenhNhan");
            cboNV.DataBindings.Add("SelectedValue", dtPhieuKham, "MaNhanVien");


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            txtMaPKB.DataBindings.Clear();
            txtSTT.DataBindings.Clear();
            txtHDT.DataBindings.Clear();
            datetimeNgayKham.DataBindings.Clear();
            datetimeNgayXuatVien.DataBindings.Clear();
            cboThuoc.DataBindings.Clear();
            cboBenh.DataBindings.Clear();
            cboBN.DataBindings.Clear();
            cboNV.DataBindings.Clear();


            txtMaPKB.Clear();
            txtSTT.Clear();
            txtHDT.Clear();
            datetimeNgayKham.Enabled = true;
            datetimeNgayXuatVien.Enabled = true;
            txtMaPKB.Enabled = txtSTT.Enabled = txtHDT.Enabled = cboThuoc.Enabled = cboBenh.Enabled = cboBN.Enabled = cboNV.Enabled = true;

            btnThem.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (themmoi)
            {
                if (txtMaPKB.Text != "" || txtSTT.Text != "" || txtHDT.Text != "")
                {
                    DataRow newrow = dtPhieuKham.NewRow();
                    newrow["MaPKB"] = txtMaPKB.Text;
                    newrow["STT"] = txtSTT.Text;
                    newrow["NgayKham"] = datetimeNgayKham.Text;
                    newrow["NgayxuatVien"] = datetimeNgayXuatVien.Text;
                    newrow["HuongDieuTri"] = txtHDT.Text;
                    newrow["MaThuoc"] = cboThuoc.SelectedValue.ToString();
                    newrow["MaBenh"] = cboBenh.SelectedValue.ToString();
                    newrow["MaBenhNhan"] = cboBN.SelectedValue.ToString();
                    newrow["MaNhanVien"] = cboNV.SelectedValue.ToString();

                    dtPhieuKham.Rows.Add(newrow);
                }
                PhieuKhamBenh_DataBiding();

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
            themmoi = false;
            txtMaPKB.Enabled = false;
            txtSTT.Enabled = txtHDT.Enabled = cboThuoc.Enabled = cboBenh.Enabled = cboBN.Enabled = cboNV.Enabled = true;

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
                DataTable dtPhieukhambenh = cn.LAYDULIEU("select distinct MaNhanVien from PhieuKhamBenh$ where MaNhanVien='" + txtMaPKB.Text + "'");
                if (dtPhieukhambenh.Rows.Count == 0)//ko tồn tại trong bảng sinh viên
                {
                    DataRow r = dtPhieuKham.Rows.Find(txtMaPKB.Text);
                    if (r != null)
                        r.Delete();
                }
                else
                    MessageBox.Show("Nhân viên đang tồn tại không xóa được");
            }
        }
    }

}