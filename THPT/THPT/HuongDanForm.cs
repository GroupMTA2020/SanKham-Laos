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
    public partial class HuongDanForm : Form
    {
        public HuongDanForm()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Name == "Login")
            {
                pictureBox1.Image = global::THPT.Properties.Resources.Hd_DangNhap;
                richTextBox1.Text = "1: Nhập Tài Khoản để đăng nhập vào hệ thống.\n2: Nhập Password của tài khoản trên.\n3: Click Đăng nhập để vào và sử dụng phần mềm.\n4: Click Thoát để tắt phần mềm.";
            }
            else if(e.Node.Name == "Main")
            {
                //do something
                //pictureBox1.Image = global::THPT.Properties.Resources.
            }
            else if( e.Node.Name == "HocSinh")
            {
                //do something
            }
            else if(e.Node.Name == "GiaoVien")
            {

            }
            else if(e.Node.Name == "ThongTinGiangDay")
            {
                //do something
            }
        }
    }
}
