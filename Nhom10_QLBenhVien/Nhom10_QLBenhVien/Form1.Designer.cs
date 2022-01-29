
namespace Nhom10_QLBenhVien
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.đăngNhâpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frm1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiêuKhamBênhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tênBênhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thuôcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngNhâpToolStripMenuItem,
            this.frm1,
            this.nhânViênToolStripMenuItem,
            this.phiêuKhamBênhToolStripMenuItem,
            this.tênBênhToolStripMenuItem,
            this.thuôcToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1466, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // đăngNhâpToolStripMenuItem
            // 
            this.đăngNhâpToolStripMenuItem.Name = "đăngNhâpToolStripMenuItem";
            this.đăngNhâpToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.đăngNhâpToolStripMenuItem.Text = "Đăng nhập";
            this.đăngNhâpToolStripMenuItem.Click += new System.EventHandler(this.đăngNhâpToolStripMenuItem_Click);
            // 
            // frm1
            // 
            this.frm1.Name = "frm1";
            this.frm1.Size = new System.Drawing.Size(95, 24);
            this.frm1.Text = "Bệnh Nhân";
            this.frm1.Click += new System.EventHandler(this.bênhNhânToolStripMenuItem_Click);
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.nhânViênToolStripMenuItem.Text = "Nhân Viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // phiêuKhamBênhToolStripMenuItem
            // 
            this.phiêuKhamBênhToolStripMenuItem.Name = "phiêuKhamBênhToolStripMenuItem";
            this.phiêuKhamBênhToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.phiêuKhamBênhToolStripMenuItem.Text = "Phiếu khám bệnh ";
            this.phiêuKhamBênhToolStripMenuItem.Click += new System.EventHandler(this.phiêuKhamBênhToolStripMenuItem_Click);
            // 
            // tênBênhToolStripMenuItem
            // 
            this.tênBênhToolStripMenuItem.Name = "tênBênhToolStripMenuItem";
            this.tênBênhToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.tênBênhToolStripMenuItem.Text = "Tên bệnh ";
            this.tênBênhToolStripMenuItem.Click += new System.EventHandler(this.tênBênhToolStripMenuItem_Click);
            // 
            // thuôcToolStripMenuItem
            // 
            this.thuôcToolStripMenuItem.Name = "thuôcToolStripMenuItem";
            this.thuôcToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.thuôcToolStripMenuItem.Text = "Thuốc";
            this.thuôcToolStripMenuItem.Click += new System.EventHandler(this.thuôcToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 776);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Quản lý bệnh viện";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem frm1;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiêuKhamBênhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tênBênhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thuôcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngNhâpToolStripMenuItem;
    }
}

