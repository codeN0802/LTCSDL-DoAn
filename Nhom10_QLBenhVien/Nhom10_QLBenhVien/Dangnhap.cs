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
    public partial class Dangnhap : Form
    {
        Connection cn = new Connection();
        DataTable dtTaiKhoan;
        public Dangnhap()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            DataTable dtTaiKhoan = new DataTable();
            dtTaiKhoan = cn.LAYDULIEU("select * from TaiKhoan$ where TaiKhoan = '" + txtdangnhap.Text + "' and MatKhau = '" + txtpass.Text + "'");
            if (dtTaiKhoan.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dtTaiKhoan.Rows[0]["Quyen"].ToString().Contains("admin"))
                {
                    Form1 f = new Form1();
                    f.Show();

                }
                else
                {
                    Form2 t = new Form2();
                    t.Show();

                }

                this.Hide();

            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại ", "Xin nhập lại", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
            {
                txtpass.PasswordChar = (char)0;
            }
            else
            {
                txtpass.PasswordChar = '*';
            }
        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}

