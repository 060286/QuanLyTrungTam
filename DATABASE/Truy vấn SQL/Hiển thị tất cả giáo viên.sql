select * from dbo.GiaoVien
GO

create proc Sp_GiaoVien_ListALl
AS 
select * from dbo.GiaoVien 
where TrangThai = 1
order by MaGiaoVien

GO

exec Sp_GiaoVien_ListALl