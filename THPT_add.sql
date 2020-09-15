create table tblPhanCongGD(
MaGV nchar(10) references tblGiaoVien(MaGV),
MaLop nchar(10) references tblLop(MaLop),
primary key(MaGV,MaLop)
)
select * from tblHocSinh