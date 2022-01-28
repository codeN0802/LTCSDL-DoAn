
namespace Nhom10_QLBenhVien
{
    partial class Form2
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
            this.traCứuBệnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traCứuThuốcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.traCứuBệnhToolStripMenuItem,
            this.traCứuThuốcToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // traCứuBệnhToolStripMenuItem
            // 
            this.traCứuBệnhToolStripMenuItem.Name = "traCứuBệnhToolStripMenuItem";
            this.traCứuBệnhToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.traCứuBệnhToolStripMenuItem.Text = "Tra cứu bệnh";
            this.traCứuBệnhToolStripMenuItem.Click += new System.EventHandler(this.traCứuBệnhToolStripMenuItem_Click);
            // 
            // traCứuThuốcToolStripMenuItem
            // 
            this.traCứuThuốcToolStripMenuItem.Name = "traCứuThuốcToolStripMenuItem";
            this.traCứuThuốcToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.traCứuThuốcToolStripMenuItem.Text = "Tra cứu thuốc";
            this.traCứuThuốcToolStripMenuItem.Click += new System.EventHandler(this.traCứuThuốcToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem traCứuBệnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traCứuThuốcToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}