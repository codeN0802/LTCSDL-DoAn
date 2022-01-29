using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LTCSDL.DTO;
using LTCSDL.BLL;
namespace Nhom10_QLBenhVien
{
    public partial class TraCuuThuoc : Form
    {
        ThuocBLL bus;
        BindingSource bs;
        public TraCuuThuoc()
        {
            InitializeComponent();
            bus = new ThuocBLL();
        }

        private void TraCuuThuoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            bs = new BindingSource();
            List<Thuocx> lst = bus.GetAll();
            bs.DataSource = typeof(Thuocx);
            foreach (Thuocx cat in lst)
            {
                bs.Add(cat);
            }
            dataGridView1.DataSource = bs;
            dataGridView1.AutoGenerateColumns = true;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            txtMaThuoc.Text = row.Cells["MaThuoc"].Value.ToString();
            txtTenThuoc.Text = row.Cells["TenThuoc"].Value.ToString();
            txtXuatXu.Text = row.Cells["XuatXu"].Value.ToString();
            txtGiaTien.Text = row.Cells["GiaTien"].Value.ToString();
            txtMaBenh.Text = row.Cells["MaBenh"].Value.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnTra_Click(object sender, EventArgs e)
        {

            Connection tim = new Connection();
            dataGridView1.DataSource = tim.LAYDULIEU("select * from Thuoc$ where MaBenh like'%' +N'" + txtMaCanTim.Text + "'+ '%'");
        }

       
    }
}
