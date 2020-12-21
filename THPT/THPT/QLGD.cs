using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THPT.Models;

namespace THPT
{
    public partial class QLGD : Form
    {
        Models._QLGD myGD;
        int flag = 0;
        public QLGD()
        {
            InitializeComponent();
            HienThiDSQLGD();
        }
        private void QLGD_Load(object sender, EventArgs e)
        {
        }
        public void HienThiDSQLGD()
        {
            var dataTable = Models._QLGD.getTable_QLGD();
            dgvGD.ReadOnly = true;
            dgvGD.DataSource = dataTable;
        }
        private void clearData()
        {
            txtMaGD.Text = "";
            cbMaLop.Text = "";
            cbMaMon.Refresh();
            cbMaGV.Text = "";
            dtngayday.Text = "";
            txtTiet.Text = "";
        }
        void btnReload()
        {
            btnSua.Visible = btnXoa.Visible =
                btnThem.Visible = !btnSua.Visible;
            btnThoat.Visible = btnLuu.Visible = btnLuu.Visible;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            clearData();
            txtMaGD.Text = "GD" + dgvGD.Rows.Count.ToString("0000000");
            btnLuu.Tag = "Them";
            btnThoat.Tag = "Them";
            btnReload();

        }



        private void QLGD_FormClosing(object sender, FormClosingEventArgs e)
        {
            Connection.close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnReload();
            flag = 1;
            btnLuu.Tag = "Sua";
            btnThoat.Tag = "Sua";
        }
        string convertToDateSQL(string dateC)
        {
            string result;
            string date = dateC.Split(' ')[0];
            var X = date.Split('/');
            result = X[2] + "-" + X[1] + "-" + X[0];
            return result;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnLuu.Tag.ToString() == "Them")
            {
                string Ngayday = convertToDateSQL(dtngayday.Value.ToString("dd/MM/yyy"));
                myGD = new Models._QLGD(txtMaGD.Text, cbMaLop.Text, cbMaMon.Text, cbMaGV.Text, Ngayday, Convert.ToInt32(txtTiet.Text));
                var i = myGD.Insert_QLGD();
                if (i == 0)
                {
                    MessageBox.Show("Thêm mới thất bại !");
                }
                else
                {
                    MessageBox.Show("Thêm mới thành công !");
                    HienThiDSQLGD();
                }
            }
            if (btnLuu.Tag.ToString() == "Sua")
            {
                string NgayDay = convertToDateSQL(dtngayday.Value.ToString("dd/MM/yyy"));
                myGD = new Models._QLGD(txtMaGD.Text, cbMaLop.Text, cbMaMon.Text, cbMaGV.Text , NgayDay, Convert.ToInt32(txtTiet.Text));
                var i = myGD.Update_QLGD();
                if (i == 0)
                {
                    MessageBox.Show("Sửa thất bại !");
                }
                else
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDSQLGD();
                }
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (btnThoat.Tag.ToString() == "Them")
            {
                txtMaGD.Text = "";
                cbMaLop.Text = "";
                cbMaMon.Text = " " ;
                cbMaGV.Text = "";
                dtngayday.Refresh();
                txtTiet.Text = "";

            }
            if (btnThoat.Tag.ToString() == "Sua")
            {
                txtMaGD.Text = "";
                cbMaLop.Text = "";
                cbMaMon.Text = " ";
                cbMaGV.Text = "";
                dtngayday.Refresh();
                txtTiet.Text = "";
            }
            btnReload();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string _MaGD = "";
            try
            {
                _MaGD = txtMaGD.Text;
                MessageBox.Show("bạn muốn xóa ID : " + _MaGD);
            }
            catch { }
            DialogResult dr = MessageBox.Show(" Bạn có chắc chắn xóa ?", "Xác nhận ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string NgayDay = convertToDateSQL(dtngayday.Value.ToString("dd/MM/yyy"));
                myGD = new Models._QLGD(txtMaGD.Text, cbMaLop.Text, cbMaMon.Text, cbMaGV.Text, NgayDay, Convert.ToInt32(txtTiet.Text));
                var i = myGD.Delete_QLGD();
                if (i > 0)
                {
                    MessageBox.Show("Xóa Thành Công !");

                }
                else
                    MessageBox.Show("Xóa Không thành công");
            }
            HienThiDSQLGD();
        }
        public void SearchByKey(string query, string value)
        {

            query = query + "N'%" + value + "%'";
            DataTable data = Models.Connection.SeachInDataBase(query);
            if (data.Rows.Count == 0) MessageBox.Show("Không Tìm Thấy");
            else dgvGD.DataSource = data;
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
            string GiaTri = cbTimKiem.GetItemText(this.cbTimKiem.SelectedItem).Trim();

            string keyRow = txtTK.Text;
            if (GiaTri == "" || keyRow == "")
            {
                MessageBox.Show("Chưa Có Thông Tin Cần Tìm");
            }
            else
            {

                string query = "";
                //set value of query if valuaCol change 
                if (GiaTri == "MaGD") query = "Select * from QLGD where MaGD like ";
                if (GiaTri == "MaLop") query = "Select * from QLGD where MaLop like ";
                if (GiaTri == "MaMon") query = "Select * from QLGD where MaMon like ";
                if (GiaTri == "MaGV") query = "Select * from QLGD where MaGV like ";
                SearchByKey(query, keyRow);
            }
        }

        private void dgvGD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaGD.Text = dgvGD.Rows[index].Cells["MaGD"].Value.ToString();
                cbMaLop.Text = dgvGD.Rows[index].Cells["MaLop"].Value.ToString();           
                cbMaMon.Text = dgvGD.Rows[index].Cells["MaMon"].Value.ToString();
                cbMaGV.Text = dgvGD.Rows[index].Cells["MaGV"].Value.ToString();
                dtngayday.Text = dgvGD.Rows[index].Cells["Ngayday"].Value.ToString();
                txtTiet.Text = dgvGD.Rows[index].Cells["Tiet"].Value.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
