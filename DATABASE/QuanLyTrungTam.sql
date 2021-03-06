USE [master]
GO
/****** Object:  Database [QuanLyTrungTam]    Script Date: 10/7/2020 5:21:04 PM ******/
CREATE DATABASE [QuanLyTrungTam]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyTrungTam', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyTrungTam.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyTrungTam_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyTrungTam_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyTrungTam] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyTrungTam].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyTrungTam] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyTrungTam] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyTrungTam] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyTrungTam] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyTrungTam] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyTrungTam] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyTrungTam] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyTrungTam] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyTrungTam] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyTrungTam] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyTrungTam] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyTrungTam] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyTrungTam] SET QUERY_STORE = OFF
GO
USE [QuanLyTrungTam]
GO
/****** Object:  Table [dbo].[BangDiem]    Script Date: 10/7/2020 5:21:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangDiem](
	[MaBangDiem] [int] IDENTITY(1,1) NOT NULL,
	[DiemNghe] [int] NULL,
	[DiemNoi] [int] NULL,
	[DiemDoc] [int] NULL,
	[DiemViet] [int] NULL,
	[TenBangDiem] [nvarchar](100) NULL,
	[MaKhoaHoc] [int] NULL,
	[KetQua] [nvarchar](50) NULL,
 CONSTRAINT [PK_BangDiem] PRIMARY KEY CLUSTERED 
(
	[MaBangDiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTPhongHoc]    Script Date: 10/7/2020 5:21:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPhongHoc](
	[MaPhongHoc] [int] NULL,
	[MaTKB] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 10/7/2020 5:21:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[MaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaoVien]    Script Date: 10/7/2020 5:21:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[MaGiaoVien] [int] IDENTITY(1,1) NOT NULL,
	[TenGiaoVien] [nvarchar](100) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[NgayDangKy] [date] NULL,
	[Email] [nvarchar](100) NULL,
	[SDT] [int] NULL,
	[GhiChu] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[QuocTich] [nvarchar](50) NULL,
	[Visa] [nvarchar](50) NULL,
	[Toeic] [nvarchar](100) NULL,
	[Toefl] [nvarchar](100) NULL,
	[Ielts] [nvarchar](100) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_GiaoVien] PRIMARY KEY CLUSTERED 
(
	[MaGiaoVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocVien]    Script Date: 10/7/2020 5:21:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocVien](
	[MaHocVien] [int] IDENTITY(1,1) NOT NULL,
	[TenHocVien] [nvarchar](100) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[SDT] [int] NULL,
	[Email] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[NgayDangKy] [date] NULL,
	[NgaySinh] [date] NULL,
	[GhiChu] [nvarchar](max) NULL,
	[TrangThai] [bit] NULL,
	[Nguon] [nvarchar](100) NULL,
 CONSTRAINT [PK_HocVien] PRIMARY KEY CLUSTERED 
(
	[MaHocVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoaHoc]    Script Date: 10/7/2020 5:21:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoaHoc](
	[MaKhoaHoc] [int] IDENTITY(1,1) NOT NULL,
	[TenKhoaHoc] [nvarchar](100) NULL,
	[MoTa] [nvarchar](100) NULL,
	[MaTKB] [int] NULL,
	[MaHocVien] [int] NULL,
	[MaGiaoVien] [int] NULL,
	[HocPhi] [money] NULL,
 CONSTRAINT [PK_KhoaHoc] PRIMARY KEY CLUSTERED 
(
	[MaKhoaHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongHoc]    Script Date: 10/7/2020 5:21:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongHoc](
	[MaPhongHoc] [int] IDENTITY(1,1) NOT NULL,
	[TenPhongHoc] [nvarchar](100) NULL,
	[GhiChu] [nvarchar](100) NULL,
 CONSTRAINT [PK_PhongHoc] PRIMARY KEY CLUSTERED 
(
	[MaPhongHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhuHuynh]    Script Date: 10/7/2020 5:21:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhuHuynh](
	[MaPhuHuynh] [int] IDENTITY(1,1) NOT NULL,
	[TenPhuHuynh] [nvarchar](100) NULL,
	[SDT] [int] NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[Email] [nvarchar](200) NULL,
	[MaHocVien] [int] NULL,
 CONSTRAINT [PK_PhuHuynh] PRIMARY KEY CLUSTERED 
(
	[MaPhuHuynh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThoiKhoaBieu]    Script Date: 10/7/2020 5:21:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThoiKhoaBieu](
	[MaTKB] [int] IDENTITY(1,1) NOT NULL,
	[TongSoTuan] [int] NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
 CONSTRAINT [PK_ThoiKhoaBieu] PRIMARY KEY CLUSTERED 
(
	[MaTKB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DangNhap] ON 

INSERT [dbo].[DangNhap] ([MaTaiKhoan], [TaiKhoan], [MatKhau], [TrangThai]) VALUES (1, N'admin', N'123', 1)
INSERT [dbo].[DangNhap] ([MaTaiKhoan], [TaiKhoan], [MatKhau], [TrangThai]) VALUES (2, N'tamle', N'2412Vantam', 1)
SET IDENTITY_INSERT [dbo].[DangNhap] OFF
GO
ALTER TABLE [dbo].[BangDiem]  WITH CHECK ADD  CONSTRAINT [FK_BangDiem_KhoaHoc] FOREIGN KEY([MaKhoaHoc])
REFERENCES [dbo].[KhoaHoc] ([MaKhoaHoc])
GO
ALTER TABLE [dbo].[BangDiem] CHECK CONSTRAINT [FK_BangDiem_KhoaHoc]
GO
ALTER TABLE [dbo].[CTPhongHoc]  WITH CHECK ADD  CONSTRAINT [FK_CTPhongHoc_PhongHoc] FOREIGN KEY([MaPhongHoc])
REFERENCES [dbo].[PhongHoc] ([MaPhongHoc])
GO
ALTER TABLE [dbo].[CTPhongHoc] CHECK CONSTRAINT [FK_CTPhongHoc_PhongHoc]
GO
ALTER TABLE [dbo].[CTPhongHoc]  WITH CHECK ADD  CONSTRAINT [FK_CTPhongHoc_ThoiKhoaBieu] FOREIGN KEY([MaTKB])
REFERENCES [dbo].[ThoiKhoaBieu] ([MaTKB])
GO
ALTER TABLE [dbo].[CTPhongHoc] CHECK CONSTRAINT [FK_CTPhongHoc_ThoiKhoaBieu]
GO
ALTER TABLE [dbo].[KhoaHoc]  WITH CHECK ADD  CONSTRAINT [FK_KhoaHoc_GiaoVien] FOREIGN KEY([MaGiaoVien])
REFERENCES [dbo].[GiaoVien] ([MaGiaoVien])
GO
ALTER TABLE [dbo].[KhoaHoc] CHECK CONSTRAINT [FK_KhoaHoc_GiaoVien]
GO
ALTER TABLE [dbo].[KhoaHoc]  WITH CHECK ADD  CONSTRAINT [FK_KhoaHoc_HocVien] FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HocVien] ([MaHocVien])
GO
ALTER TABLE [dbo].[KhoaHoc] CHECK CONSTRAINT [FK_KhoaHoc_HocVien]
GO
ALTER TABLE [dbo].[KhoaHoc]  WITH CHECK ADD  CONSTRAINT [FK_KhoaHoc_ThoiKhoaBieu] FOREIGN KEY([MaTKB])
REFERENCES [dbo].[ThoiKhoaBieu] ([MaTKB])
GO
ALTER TABLE [dbo].[KhoaHoc] CHECK CONSTRAINT [FK_KhoaHoc_ThoiKhoaBieu]
GO
ALTER TABLE [dbo].[PhuHuynh]  WITH CHECK ADD  CONSTRAINT [FK_PhuHuynh_HocVien] FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HocVien] ([MaHocVien])
GO
ALTER TABLE [dbo].[PhuHuynh] CHECK CONSTRAINT [FK_PhuHuynh_HocVien]
GO
/****** Object:  StoredProcedure [dbo].[Sp_TaiKhoan_DangNhap]    Script Date: 10/7/2020 5:21:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_TaiKhoan_DangNhap]
	@TaiKhoan	nvarchar(50),
	@MatKhau	nvarchar(50)
AS
BEGIN 
	DECLARE	@count int -- Tạo biến đếm 
	DECLARE @res bit	-- Tạo biến kết quả
	SELECT @count = COUNT(*) FROM DangNhap WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau
	IF @count > 0 
		SET @res = 1
	ELSE 
		SET @res = 0

	SELECT @res
END
GO
USE [master]
GO
ALTER DATABASE [QuanLyTrungTam] SET  READ_WRITE 
GO
