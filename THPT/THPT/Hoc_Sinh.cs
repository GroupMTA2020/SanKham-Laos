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
    public partial class Hoc_Sinh : Form
    {
        Models.HocVien myHV;
        int flag = 0;
        public Hoc_Sinh()
        {
            InitializeComponent();
            HienThiDanhSachSV();
        }
        public void HienThiDanhSachSV()
        {
            var dataTable = Models.HocVien.getTableSinhVien();
            dgvHocSinh.ReadOnly = true;
            dgvHocSinh.DataSource = dataTable;
        }
        private void clearData()
        {
            txtMa_HS.Text = "";
            txtHoTen_HS.Text = "";
            dtpNgaySinh_HS.Refresh();
            cbGT_HS.Text = "-Chọn giới tính-";
            txtDiaChi.Text = "";
            txtPhuHuynh.Text = "";
            cbLop.Text = "-Chọn Lớp-";
        }
        void btnReload()
        {
            btnSua_HS.Visible = btnXoa_HS.Visible =
                btnThem_HS.Visible = !btnSua_HS.Visible;
            btnHuy.Visible = btnLuu_HS.Visible = !btnLuu_HS.Visible;
        }
        private void btnThem_HS_Click(object sender, EventArgs e)
        {         
            flag = 0;
            clearData();
            txtMa_HS.Text = "HV" + dgvHocSinh.Rows.Count.ToString("00000000");
            btnLuu_HS.Tag = "Them";
            btnHuy.Tag = "Them";
            btnReload();
        }

        private void btnSua_HS_Click(object sender, EventArgs e)
        {
            btnReload();
            flag = 1;
            btnLuu_HS.Tag = "Sua";
            btnHuy.Tag = "Sua";
        }
        string convertToDateSQL(string dateC)
        {
            string result;
            string date = dateC.Split(' ')[0];
            var X = date.Split('/');
            result = X[2] + "-" + X[1] + "-" + X[0];
            return result;
        }
        private void btnLuu_HS_Click(object sender, EventArgs e)
        {
            if (btnLuu_HS.Tag.ToString() == "Them")
            {
                string ngaySinh = convertToDateSQL(dtpNgaySinh_HS.Value.ToString("dd/MM/yyy"));
                myHV = new Models.HocVien(txtMa_HS.Text, txtHoTen_HS.Text, cbGT_HS.Text, ngaySinh, txtDiaChi.Text
                    , txtPhuHuynh.Text, cbLop.Text);
                //HienThiDanhSachSV();
                var i = myHV.InsertSinhVien();
                if (i == 0)
                {
                    MessageBox.Show("Thêm mới thất bại !");
                }
                else
                {
                    MessageBox.Show("Thêm mới thành công !");
                    HienThiDanhSachSV();
                }
            }
            if (btnLuu_HS.Tag.ToString() == "Sua")
            {
                string ngaySinh = convertToDateSQL(dtpNgaySinh_HS.Value.ToString("dd/MM/yyy"));
                myHV = new Models.HocVien(txtMa_HS.Text, txtHoTen_HS.Text, cbGT_HS.Text, ngaySinh, txtDiaChi.Text
                    , txtPhuHuynh.Text, cbLop.Text);
                var i = myHV.UpdateSinhVien();
                if (i == 0)
                {
                    MessageBox.Show("Sửa thất bại !");
                }
                else
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDanhSachSV();
                }
            }
        }

        private void dgvHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMa_HS.Text = dgvHocSinh.Rows[index].Cells["MaHS"].Value.ToString();
                txtHoTen_HS.Text = dgvHocSinh.Rows[index].Cells["HovaTen"].Value.ToString();
                cbGT_HS.Text = dgvHocSinh.Rows[index].Cells["GT"].Value.ToString();
                dtpNgaySinh_HS.Text = dgvHocSinh.Rows[index].Cells["NgaySinh"].Value.ToString();
                txtDiaChi.Text = dgvHocSinh.Rows[index].Cells["DiaChi"].Value.ToString();
                txtPhuHuynh.Text = dgvHocSinh.Rows[index].Cells["PhuHuynh"].Value.ToString();
                cbLop.Text = dgvHocSinh.Rows[index].Cells["MaLop"].Value.ToString();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (btnHuy.Tag.ToString() == "Them")
            {
                txtMa_HS.Text = "";
                txtHoTen_HS.Text ="";
                cbGT_HS.Text = "-Chọn Giới Tính-";
                dtpNgaySinh_HS.Refresh();
                txtDiaChi.Text = "";
                txtPhuHuynh.Text = "";
                cbLop.Text = "-Chọn Lớp-";
            }
            if (btnHuy.Tag.ToString() == "Sua")
            {
                txtMa_HS.Text = "";
                txtHoTen_HS.Text = "";
                cbGT_HS.Text = "-Chọn Giới Tính-";
                dtpNgaySinh_HS.Refresh();
                txtDiaChi.Text = "";
                txtPhuHuynh.Text = "";
                cbLop.Text = "-Chọn Lớp-";
            }
            btnReload();
        }

        private void btnXoa_HS_Click(object sender, EventArgs e)
        {
            string _MaSV = "";
            try
            {
                _MaSV = txtMa_HS.Text;
                MessageBox.Show("bạn muốn xóa ID : "+_MaSV);
            }
            catch { }
            DialogResult dr = MessageBox.Show(" Bạn có chắc chắn xóa ?", "Xác nhận ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string ngaySinh = convertToDateSQL(dtpNgaySinh_HS.Value.ToString("dd/MM/yyy"));
                myHV = new Models.HocVien(txtMa_HS.Text, txtHoTen_HS.Text, cbGT_HS.Text, ngaySinh, txtDiaChi.Text
                    , txtPhuHuynh.Text, cbLop.Text);
                var i = myHV.DeleteSinhVien();
                if (i > 0)
                {
                    MessageBox.Show("Xóa Thành Công !");

                }
                else
                    MessageBox.Show("Xóa Không thành công");
            }
            HienThiDanhSachSV();
        }
        public void SearchByKey(string query, string value)
        {

            query = query + "N'%" + value + "%'";
            DataTable data = Models.Connection.SeachInDataBase(query);
            if (data.Rows.Count == 0) MessageBox.Show("Không Tìm Thấy");
            else dgvHocSinh.DataSource = data;
        }
        private void btntimkiem_Click(object sender, EventArgs e)
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
                if (GiaTri == "MaHS") query = "Select * from tblHocSinh where MaHS like ";
                if (GiaTri == "HovaTen") query = "Select * from tblHocSinh where HovaTen like ";
                if (GiaTri == "GT") query = "Select * from tblHocSinh where GT like ";
                if (GiaTri == "DiaChi") query = "Select * from tblHocSinh where DiaChi like ";
                if (GiaTri == "PhuHuynh") query = "Select * from tblHocSinh where PhuHuynh like ";
                if (GiaTri == "MaLop") query = "Select * from tblHocSinh where MaLop like ";
                SearchByKey(query, keyRow);
            }
        }
    }
}
