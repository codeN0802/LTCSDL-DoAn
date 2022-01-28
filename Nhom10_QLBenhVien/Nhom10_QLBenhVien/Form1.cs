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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void bênhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BenhNhan benhNhan = new BenhNhan();
            benhNhan.MdiParent = this;
            benhNhan.StartPosition = FormStartPosition.CenterScreen;
            benhNhan.Show();
        }

      
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nhanvien nhanvien = new Nhanvien();
            nhanvien.MdiParent = this;
            nhanvien.StartPosition = FormStartPosition.CenterScreen;
            nhanvien.Show();
        }

        private void phiêuKhamBênhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Phieukhambenh phieukhambenh = new Phieukhambenh();
            phieukhambenh.MdiParent = this;
            phieukhambenh.StartPosition = FormStartPosition.CenterScreen;
            phieukhambenh.Show();
        }

        private void tênBênhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tenbenh tenbenh = new Tenbenh();
            tenbenh.MdiParent = this;
            tenbenh.StartPosition = FormStartPosition.CenterScreen;
            tenbenh.Show();
        }

        private void thuôcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thuoc thuoc = new Thuoc();
            thuoc.MdiParent = this;
            thuoc.StartPosition = FormStartPosition.CenterScreen;
            thuoc.Show();
        }

        private void đăngNhâpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dangnhap dangnhap = new Dangnhap();
            dangnhap.MdiParent = this;
            dangnhap.StartPosition = FormStartPosition.CenterScreen;
            dangnhap.Show();
        }

       
    }
}
