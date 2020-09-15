using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THPT.model
{
    class GiaoVien
    {
        
        string MaGV;
        string HoTen;
        string GT;
        string NgaySinh;
        string DiaChi;
        int SDT;
        float Luong;
        string MaMon;

        public string MaGV1 { get => MaGV; set => MaGV = value; }
        public string HoTen1 { get => HoTen; set => HoTen = value; }
        public string GT1 { get => GT; set => GT = value; }
        public string NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public int SDT1 { get => SDT; set => SDT = value; }
        public float Luong1 { get => Luong; set => Luong = value; }
        public string MaMon1 { get => MaMon; set => MaMon = value; }
        public GiaoVien(string _MaGV, string _HoTen, string _GT,
            string _NgaySinh, string _DiaChi, int _SDT, float _Luong, string _MaMon)
        {
            MaGV = _MaGV;
            HoTen = _HoTen;
            GT = _GT;
            NgaySinh = _NgaySinh;
            DiaChi = _DiaChi;
            SDT = _SDT;
            Luong = _Luong;
            MaMon = _MaMon;
        }
        public GiaoVien(string[] data)
        {
            MaGV = data[0];
            HoTen = data[1];
            GT = data[2];
            NgaySinh = data[3];
            DiaChi = data[4];
            SDT = Convert.ToInt32(data[5]);
            Luong = Convert.ToInt32(data[6]);
            MaMon = data[7];
        }
        public static DataTable getTableGiaovien()
        {
            return model.Connection.getData("splistgiaovien", CommandType.StoredProcedure);
        }
        public int InsertGiaovien()
        {
            string[] paras = new string[8] { "@MaGV", "@HoTen", "@GT",
                "@NgaySinh", "@DiaChi", "@SDT", "@Luong","@MaMon"};
            object[] values = new object[8] { MaGV, HoTen, GT, NgaySinh,
                DiaChi, SDT, Luong,MaMon};
            var i = model.Connection.ExcuteQuery("insert_giaovien",
                CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int UpdateGiaovien()
        {
            string[] paras = new string[8] { "@MaGV", "@HoTen", "@GT",
                "@NgaySinh", "@DiaChi", "@SDT", "@Luong","@MaMon"};
            object[] values = new object[8] { MaGV, HoTen, GT, NgaySinh,
                DiaChi, SDT, Luong,MaMon};
            var i = model.Connection.ExcuteQuery("Sua_GV",
                CommandType.StoredProcedure, paras, values);
            return i;
        }
        public int DeleteGiaovien()
        {
            var i = model.Connection.ExcuteQuery("Xoa_GV",
                CommandType.StoredProcedure, new string[1] { "@MaGV" }, new object[1] { MaGV });
            return i;
        }
    }
}

