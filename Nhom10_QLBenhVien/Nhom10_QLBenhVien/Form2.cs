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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void traCứuBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
                TraCuuBenh traCuuBenh = new TraCuuBenh();
            //  traCuuBenh.MdiParent = this;
                traCuuBenh.StartPosition = FormStartPosition.CenterScreen;
                traCuuBenh.Show();
            }

        private void traCứuThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TraCuuThuoc traCuuThuoc = new TraCuuThuoc();
           // traCuuThuoc.MdiParent = this;
            traCuuThuoc.StartPosition = FormStartPosition.CenterScreen;
            traCuuThuoc.Show();
        }
    }
    
}
