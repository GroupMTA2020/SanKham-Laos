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
                pictureBox1.Image = global::THPT.Properties.Resources.main;
                richTextBox1.Text = "Click vào các button để sử dụng các chức năng\n1: Button 'Giáo Viên' hiển thị thông tin giáo viên và các thao tác sử lý\n2: button 'Hướng dẫn'" +
                    "để hiển thị các hướng dẫn"
                    + "\n3: Button 'TT_GiangDay' để hiển thị các thông tin liên quan"
                    + "\n4: Button 'Học Viên' để hiển thị các thông tin về học viên";
            }
            else if( e.Node.Name == "HocSinh")
            {
                pictureBox1.Image = global::THPT.Properties.Resources.hvien;
                richTextBox1.Text = "Thông tin học viên được hiển thị, click vào học viên muốn sửa hoặc xóa để thao tác, có thể thêm học viên với button thêm";
            }
            else if(e.Node.Name == "GiaoVien")
            {
                pictureBox1.Image = global::THPT.Properties.Resources.fmgv;
                richTextBox1.Text = "Thông tin giáo viên được hiển thị, click vào giáo viên để chỉnh sửa thông tin, có thể thêm mới giáo viên bằng button thêm";
            }
            else if(e.Node.Name == "ThongTinGiangDay")
            {
                pictureBox1.Image = global::THPT.Properties.Resources.ttgd;
                richTextBox1.Text = "Tìm kiếm các thông tin liên quan đến giáo viên, lớp học, học viên, có thể chỉnh sửa, thêm , xóa.";
            }
        }
    }
}
