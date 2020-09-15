using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THPT.Models
{
    class Dangnhap
    {
        string taikhoan;
        string matkhau;
        string hoten;

        public string Taikhoan { get => taikhoan; set => taikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public Dangnhap(string _taikhoan, string _matkhau, string _hoten)
        {
            taikhoan = _taikhoan;
            matkhau = _matkhau;
            hoten = _hoten;
        }
        public Dangnhap(string[] data)
        {
            taikhoan = data[0];
            matkhau = data[1];
            hoten = data[2];
        }
        public static List<List<string>> getMaNV()
        {
            List<List<string>> re = new List<List<string>>();
            List<string> maNV = new List<string>();
            List<string> matKhau = new List<string>();
            DataTable dt = new DataTable();
            dt = Models.Connection.getData("Select taikhoan,matkhau from taikhoan", CommandType.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                maNV.Add(dt.Rows[i][0].ToString().Trim());
                matKhau.Add(dt.Rows[i][1].ToString().Trim());
            }
            re.Add(maNV);
            re.Add(matKhau);
            Console.Write(matKhau.Count);
            return re;
        }
    }
}
