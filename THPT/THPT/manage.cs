using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THPT
{
    public partial class manage : Form
    {
        Models.Dangnhap MaDN;
        public manage(string MaDN)
        {
            InitializeComponent();
        }
        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }
        private void AbrirFormEnPanel(object Formijo)
        {
            if (this.pnamain.Controls.Count > 0)
                this.pnamain.Controls.RemoveAt(0);
            Form fh = Formijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnamain.Controls.Add(fh);
            this.pnamain.Tag = fh;
            fh.Show();

        }  
        private void btnphieu_Click_1(object sender, EventArgs e)
        {
            Giao_Vien giao_vien = new Giao_Vien();
            giao_vien.ShowDialog();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Hoc_Sinh());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new TT_Giang_Day());
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new HuongDanForm());
        }
    }
}
