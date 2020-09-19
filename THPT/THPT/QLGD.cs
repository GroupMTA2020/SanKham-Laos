using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace THPT
{
    public partial class QLGD : Form
    {
        public QLGD()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void QLGD_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=LAPTOP-KBK3516B\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True");
            con.Open();
            HienThi();

        }
        private void HienThi()
        {
            string sqlSelect = "SELECT * FROM tblGIAOVIEN";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void QLGD_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
