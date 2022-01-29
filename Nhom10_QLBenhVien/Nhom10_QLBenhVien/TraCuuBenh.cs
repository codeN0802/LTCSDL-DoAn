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
    public partial class TraCuuBenh : Form
    {
        BenhBLL bus;
        BindingSource bs;
        public TraCuuBenh()
        {
            InitializeComponent();
            bus = new BenhBLL();
        }

        private void TraCuuBenh_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            bs = new BindingSource();
            List<Benh> lst = bus.GetAll();
            bs.DataSource = typeof(Benh);
            foreach (Benh cat in lst)
            {
                bs.Add(cat);
            }
            dataGridView1.DataSource = bs;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            txtMaBenh.Text = row.Cells["MaBenh"].Value.ToString();
            txtTenBenh.Text = row.Cells["TenBenh"].Value.ToString();
            txtTrieuChung.Text = row.Cells["TrieuChung"].Value.ToString();
            txtMaKhoa.Text = row.Cells["MaKhoa"].Value.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnTra_Click(object sender, EventArgs e)
        {

            Connection tim = new Connection();
           // dataGridView1.DataSource = tim.LAYDULIEU("select * from TenBenh$ where TenBenh  like'%' +N'" + txtMaCanTim.Text + "'+ '%'");
           dataGridView1.DataSource = tim.LAYDULIEU("select * from TenBenh$ where TrieuChung like'%' +N'" + txtMaCanTim.Text + "'+ '%'");
        }
    }
}
