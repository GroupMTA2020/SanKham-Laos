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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Button login = sender as Button;
            List<List<string>> NV = Models.Dangnhap.getMaNV();
            string maDN = txttaikhoan.Text;
            string matKhau = txtmatkhau.Text;
            if (NV[0].Contains(maDN.ToUpper()) && NV[1][NV[0].IndexOf(maDN.ToUpper())] == matKhau)
            {
                dangnhap(maDN);
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void dangnhap(string MaHS)
        {
            manage ma = new manage(MaHS);
            this.Hide();
            ma.Show();
        }
    }
}
