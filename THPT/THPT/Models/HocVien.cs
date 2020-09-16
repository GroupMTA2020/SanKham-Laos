using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THPT.Models
{
    class HocVien
    {
         string Mahs;
         string HovaTen;
         string GT;
         string NgaySinh;
         string DiaChi;
         string PhuHuynh;
         string MaLop;

         public string Mahs1 { get => Mahs; set => Mahs = value; }
         public string HovaTen1 { get => HovaTen; set => HovaTen = value; }
         public string GT1 { get => GT; set => GT = value; }
         public string NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
         public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
         public string PhuHuynh1 { get => PhuHuynh; set => PhuHuynh = value; }
         public string MaLop1 { get => MaLop; set => MaLop = value; }

        public HocVien(string _Mahs, string _HovaTen, string _GT,
            string _NgaySinh, string _DiaChi, string _PhuHuynh, string _MaLop)
        {
             Mahs = _Mahs;
             HovaTen = _HovaTen;
             GT = _GT;
             NgaySinh = _NgaySinh;
             DiaChi = _DiaChi;
             PhuHuynh = _PhuHuynh;
             MaLop = _MaLop;
        }
        public HocVien(string[] data)
        {
            Mahs = data[0];
            HovaTen = data[1];
            GT = data[2];
            NgaySinh = data[3];
            DiaChi = data[4];
            PhuHuynh = data[5];
            MaLop = data[6];
        }

        public HocVien()
        {
        }

        public static DataTable getTableSinhVien()
        {
            return Models.Connection.getData("splisthocvien", CommandType.StoredProcedure);
        }
        public int InsertSinhVien()
        {
                string[] paras = new string[7] { "@MaHS", "@HovaTen", "@GT",
                    "@NgaySinh", "@DiaChi", "@PhuHuynh", "@MaLop"};
                object[] values = new object[7] { Mahs, HovaTen, GT, NgaySinh,
                    DiaChi, PhuHuynh, MaLop};
                var i = Models.Connection.ExcuteQuery("insert_sinhvien",
                    CommandType.StoredProcedure, paras, values);
                return i;
        }
        public int UpdateSinhVien()
        {
            string[] paras = new string[7] { "@MaHS", "@HovaTen", "@GT",
                 "@NgaySinh", "@DiaChi", "@PhuHuynh", "@MaLop"};
             object[] values = new object[7] { Mahs, HovaTen, GT, NgaySinh,
                 DiaChi, PhuHuynh, MaLop};
             var i = Models.Connection.ExcuteQuery("Sua_HS",
                 CommandType.StoredProcedure, paras, values);
             return i;
        }
         public int DeleteSinhVien()
        {
             var i = Models.Connection.ExcuteQuery("Xoa_HS",
                 CommandType.StoredProcedure, new string[1] { "@MaHS" }, new object[1] { Mahs });
             return i;
         }
    }
}
