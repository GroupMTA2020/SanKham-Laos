using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace THPT
{
    public partial class Giao_Vien : Form
    {
       
        public Giao_Vien()
        {
            InitializeComponent();
            HienThiDanhSachGV();
        }
        Models.GiaoVien myGV;
        int flag = 0;
        public void HienThiDanhSachGV()
        {
            var dataTable = Models.GiaoVien.getTableGiaovien();
            dgvGiaoVien.ReadOnly = true;
            dgvGiaoVien.DataSource = dataTable;
        }
        void btnReload()
        {
            btnSua.Visible = btnXoa.Visible =
                btnThem.Visible = !btnSua.Visible;
            btnHuy.Visible = btnLuu.Visible = !btnLuu.Visible;
        }
        private void clearData()
        {
            txtMaGV.Text = "";
            txtHoTenGV.Text = "";
            dtpNgaySinhGV.Refresh();
            cbGTGV.Text = "-Chọn giới tính-";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtLuong.Text = "";
            cbMonHoc.Text = "-Chọn Môn Học-";
        }
   
    
        string convertToDateSQL(string dateC)
        {
            string result;
            string date = dateC.Split(' ')[0];
            var X = date.Split('/');
            result = X[2] + "-" + X[1] + "-" + X[0];
            return result;
        }
     

        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaGV.Text = dgvGiaoVien.Rows[index].Cells["MaGV"].Value.ToString();
                txtHoTenGV.Text = dgvGiaoVien.Rows[index].Cells["HoTen"].Value.ToString();
                cbGTGV.Text = dgvGiaoVien.Rows[index].Cells["GT"].Value.ToString();
                dtpNgaySinhGV.Text = dgvGiaoVien.Rows[index].Cells["NgaySinh"].Value.ToString();
                txtSDT.Text = dgvGiaoVien.Rows[index].Cells["SDT"].Value.ToString();
                txtDiaChi.Text = dgvGiaoVien.Rows[index].Cells["DiaChi"].Value.ToString();
                txtLuong.Text = dgvGiaoVien.Rows[index].Cells["Luong"].Value.ToString();
                cbMonHoc.Text = dgvGiaoVien.Rows[index].Cells["MaMon"].Value.ToString();
            }
        }
        public void SearchByKey(string query, string value)
        {

            query = query + "N'%" + value + "%'";
            DataTable data = Models.Connection.SeachInDataBase(query);
            if (data.Rows.Count == 0) MessageBox.Show("Không Tìm Thấy");
            else dgvGiaoVien.DataSource = data;
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
      
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            flag = 0;
            clearData();
            txtMaGV.Text = "GV" + dgvGiaoVien.Rows.Count.ToString("00000000");
            btnLuu.Tag = "Them";
            btnHuy.Tag = "Them";
            btnReload();
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (btnLuu.Tag.ToString() == "Them")
            {
                string ngaySinh = convertToDateSQL(dtpNgaySinhGV.Value.ToString("dd/MM/yyy"));
                myGV = new Models.GiaoVien(txtMaGV.Text, txtHoTenGV.Text, cbGTGV.Text, ngaySinh, txtDiaChi.Text
                    , Convert.ToInt32(txtSDT.Text), Convert.ToInt32(txtLuong.Text), cbMonHoc.Text);
                var i = myGV.InsertGiaovien();
                if (i == 0)
                {
                    MessageBox.Show("Thêm mới thất bại !");
                }
                else
                {
                    MessageBox.Show("Thêm mới thành công !");
                    HienThiDanhSachGV();
                }
            }
            if (btnLuu.Tag.ToString() == "Sua")
            {
                string ngaySinh = convertToDateSQL(dtpNgaySinhGV.Value.ToString("dd/MM/yyy"));
                myGV = new Models.GiaoVien(txtMaGV.Text, txtHoTenGV.Text, cbGTGV.Text, ngaySinh, txtDiaChi.Text
                    , Convert.ToInt32(txtSDT.Text), Convert.ToInt32(txtLuong.Text), cbMonHoc.Text);
                var i = myGV.UpdateGiaovien();
                if (i == 0)
                {
                    MessageBox.Show("Sửa thất bại !");
                }
                else
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDanhSachGV();
                }
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            btnReload();
            flag = 1;
            btnLuu.Tag = "Sua";
            btnHuy.Tag = "Sua";
        }

        private void btntimkiem_Click_1(object sender, EventArgs e)
        {
            string GiaTri = cbTK_HS.GetItemText(this.cbTK_HS.SelectedItem).Trim();

            string keyRow = txtTK_HS.Text;
            if (GiaTri == "" || keyRow == "")
            {
                MessageBox.Show("Chưa Có Thông Tin Cần Tìm");
            }
            else
            {

                string query = "";
                //set value of query if valuaCol change 
                if (GiaTri == "MaGV") query = "Select * from tblGiaoVien where MaGV like ";
                if (GiaTri == "HoTen") query = "Select * from tblGiaoVien where HoTen like ";
                if (GiaTri == "GT") query = "Select * from tblGiaoVien where GT like ";
                if (GiaTri == "MaMon") query = "Select * from tblGiaoVien where MaMon like ";
                SearchByKey(query, keyRow);
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            if (btnHuy.Tag.ToString() == "Them")
            {
                txtMaGV.Text = "";
                txtHoTenGV.Text = "";
                dtpNgaySinhGV.Refresh();
                cbGTGV.Text = "-Chọn giới tính-";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtLuong.Text = "";
                cbMonHoc.Text = "-Chọn Môn Học-";
            }
            if (btnHuy.Tag.ToString() == "Sua")
            {
                txtMaGV.Text = "";
                txtHoTenGV.Text = "";
                dtpNgaySinhGV.Refresh();
                cbGTGV.Text = "-Chọn giới tính-";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtLuong.Text = "";
                cbMonHoc.Text = "-Chọn Môn Học-";
            }
            btnReload();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string _MaGV = "";
            try
            {
                _MaGV = txtMaGV.Text;
                MessageBox.Show("bạn muốn xóa ID : " + _MaGV);
            }
            catch { }
            DialogResult dr = MessageBox.Show(" Bạn có chắc chắn xóa ?", "Xác nhận ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string ngaySinh = convertToDateSQL(dtpNgaySinhGV.Value.ToString("dd/MM/yyy"));
                myGV = new Models.GiaoVien(txtMaGV.Text, txtHoTenGV.Text, cbGTGV.Text, ngaySinh, txtDiaChi.Text
                    , Convert.ToInt32(txtSDT.Text), Convert.ToInt32(txtLuong.Text), cbMonHoc.Text);
                var i = myGV.DeleteGiaovien();
                if (i > 0)
                {
                    MessageBox.Show("Xóa Thành Công !");

                }
                else
                    MessageBox.Show("Xóa Không thành công");
            }
            HienThiDanhSachGV();
        }

        private void dgvGiaoVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvGiaoVien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaGV.Text = dgvGiaoVien.Rows[index].Cells["MaGV"].Value.ToString();
                txtHoTenGV.Text = dgvGiaoVien.Rows[index].Cells["HoTen"].Value.ToString();
                cbGTGV.Text = dgvGiaoVien.Rows[index].Cells["GT"].Value.ToString();
                dtpNgaySinhGV.Text = dgvGiaoVien.Rows[index].Cells["NgaySinh"].Value.ToString();
                txtSDT.Text = dgvGiaoVien.Rows[index].Cells["SDT"].Value.ToString();
                txtDiaChi.Text = dgvGiaoVien.Rows[index].Cells["DiaChi"].Value.ToString();
                txtLuong.Text = dgvGiaoVien.Rows[index].Cells["Luong"].Value.ToString();
                cbMonHoc.Text = dgvGiaoVien.Rows[index].Cells["MaMon"].Value.ToString();
            }
        }
    }
    
}
