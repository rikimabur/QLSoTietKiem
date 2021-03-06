USE [QLSTK]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 5/6/2018 11:40:53 AM ******/
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GiaoDich]    Script Date: 5/6/2018 11:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoDich](
	[MaCTGD] [int] IDENTITY(1,1) NOT NULL,
	[MaSTK] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[MaKHang] [int] NOT NULL,
	[SoTienGui] [float] NOT NULL,
	[TongTienLai] [float] NULL,
	[TongTien] [float] NULL,
	[MaQuayGD] [int] NOT NULL,
	[LoaiGD] [tinyint] NOT NULL,
	[MaKyH] [int] NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
	[TinhTrang] [bit] NOT NULL,
	[NgayGiaoDich] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.GiaoDich] PRIMARY KEY CLUSTERED 
(
	[MaCTGD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 5/6/2018 11:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKh] [int] IDENTITY(1,1) NOT NULL,
	[Hoten] [nvarchar](max) NULL,
	[GioiTinh] [bit] NOT NULL,
	[Cmnd] [nvarchar](max) NULL,
	[Sdt] [nvarchar](max) NULL,
	[NgaySinh] [datetime] NOT NULL,
	[NgayCap] [datetime] NOT NULL,
	[DiaChi] [nvarchar](max) NULL,
	[TrangThai] [tinyint] NOT NULL,
 CONSTRAINT [PK_dbo.KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KyHanVay]    Script Date: 5/6/2018 11:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KyHanVay](
	[MaKyHan] [int] IDENTITY(1,1) NOT NULL,
	[SoThang] [int] NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
	[LaiSuat] [decimal](18, 2) NOT NULL,
	[MucTien] [decimal](18, 2) NOT NULL,
	[TinhTrang] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KyHanVay] PRIMARY KEY CLUSTERED 
(
	[MaKyHan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiTien]    Script Date: 5/6/2018 11:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTien](
	[MaLoaiTien] [int] IDENTITY(1,1) NOT NULL,
	[LoaiTien] [nvarchar](max) NULL,
	[TinhTrang] [bit] NOT NULL,
	[MenhGiaQuyDoi] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.LoaiTien] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/6/2018 11:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[MaQGD] [int] NOT NULL,
	[TenNhanVien] [nvarchar](max) NULL,
	[GioiTinh] [bit] NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[ChucVu] [nvarchar](max) NULL,
	[TrangThai] [bit] NOT NULL,
	[DoiMatKhau] [bit] NOT NULL,
	[DiaChi] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[SoDT] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhomTaiKhoan]    Script Date: 5/6/2018 11:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomTaiKhoan](
	[MaNhom] [int] IDENTITY(1,1) NOT NULL,
	[TenNhom] [nvarchar](max) NULL,
	[TrangThai] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.NhomTaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuayGiaoDich]    Script Date: 5/6/2018 11:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuayGiaoDich](
	[MaQGD] [int] IDENTITY(1,1) NOT NULL,
	[TenQuayGiaoDich] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[TinhTrang] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.QuayGiaoDich] PRIMARY KEY CLUSTERED 
(
	[MaQGD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SoTietKiem]    Script Date: 5/6/2018 11:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoTietKiem](
	[MaSTK] [int] IDENTITY(1,1) NOT NULL,
	[NgayMo] [datetime] NOT NULL,
	[NgayHieuLuc] [datetime] NOT NULL,
	[NgayDenHan] [datetime] NOT NULL,
	[SoTienGui] [float] NOT NULL,
	[MaKyHan] [int] NOT NULL,
	[MaLoaiTien] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[MaKhachHang] [int] NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SoTietKiem] PRIMARY KEY CLUSTERED 
(
	[MaSTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 5/6/2018 11:40:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](max) NULL,
	[MatKhau] [nvarchar](max) NULL,
	[MaNhanVien] [int] NOT NULL,
	[MaNhomTK] [int] NOT NULL,
	[TrangThai] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


--- foreign key 
GO
ALTER TABLE [dbo].[GiaoDich]  WITH CHECK ADD  CONSTRAINT [FK_dbo.GiaoDich_dbo.KhachHang_MaKHang] FOREIGN KEY([MaKHang])
REFERENCES [dbo].[KhachHang] ([MaKh])
GO
ALTER TABLE [dbo].[GiaoDich] CHECK CONSTRAINT [FK_dbo.GiaoDich_dbo.KhachHang_MaKHang]
GO
ALTER TABLE [dbo].[GiaoDich]  WITH CHECK ADD  CONSTRAINT [FK_dbo.GiaoDich_dbo.KyHanVay_MaKyH] FOREIGN KEY([MaKyH])
REFERENCES [dbo].[KyHanVay] ([MaKyHan])
GO
ALTER TABLE [dbo].[GiaoDich] CHECK CONSTRAINT [FK_dbo.GiaoDich_dbo.KyHanVay_MaKyH]
GO
ALTER TABLE [dbo].[GiaoDich]  WITH CHECK ADD  CONSTRAINT [FK_dbo.GiaoDich_dbo.NhanVien_MaNV] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[GiaoDich] CHECK CONSTRAINT [FK_dbo.GiaoDich_dbo.NhanVien_MaNV]
GO
ALTER TABLE [dbo].[GiaoDich]  WITH CHECK ADD  CONSTRAINT [FK_dbo.GiaoDich_dbo.QuayGiaoDich_MaQuayGD] FOREIGN KEY([MaQuayGD])
REFERENCES [dbo].[QuayGiaoDich] ([MaQGD])
GO
ALTER TABLE [dbo].[GiaoDich] CHECK CONSTRAINT [FK_dbo.GiaoDich_dbo.QuayGiaoDich_MaQuayGD]
GO
ALTER TABLE [dbo].[GiaoDich]  WITH CHECK ADD  CONSTRAINT [FK_dbo.GiaoDich_dbo.SoTietKiem_MaSTK] FOREIGN KEY([MaSTK])
REFERENCES [dbo].[SoTietKiem] ([MaSTK])
GO
ALTER TABLE [dbo].[GiaoDich] CHECK CONSTRAINT [FK_dbo.GiaoDich_dbo.SoTietKiem_MaSTK]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NhanVien_dbo.QuayGiaoDich_MaQGD] FOREIGN KEY([MaQGD])
REFERENCES [dbo].[QuayGiaoDich] ([MaQGD])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_dbo.NhanVien_dbo.QuayGiaoDich_MaQGD]
GO
ALTER TABLE [dbo].[SoTietKiem]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SoTietKiem_dbo.KhachHang_MaKhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKh])
GO
ALTER TABLE [dbo].[SoTietKiem] CHECK CONSTRAINT [FK_dbo.SoTietKiem_dbo.KhachHang_MaKhachHang]
GO
ALTER TABLE [dbo].[SoTietKiem]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SoTietKiem_dbo.KyHanVay_MaKyHan] FOREIGN KEY([MaKyHan])
REFERENCES [dbo].[KyHanVay] ([MaKyHan])
GO
ALTER TABLE [dbo].[SoTietKiem] CHECK CONSTRAINT [FK_dbo.SoTietKiem_dbo.KyHanVay_MaKyHan]
GO
ALTER TABLE [dbo].[SoTietKiem]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SoTietKiem_dbo.LoaiTien_MaLoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[SoTietKiem] CHECK CONSTRAINT [FK_dbo.SoTietKiem_dbo.LoaiTien_MaLoaiTien]
GO
ALTER TABLE [dbo].[SoTietKiem]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SoTietKiem_dbo.NhanVien_MaNV] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[SoTietKiem] CHECK CONSTRAINT [FK_dbo.SoTietKiem_dbo.NhanVien_MaNV]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TaiKhoan_dbo.NhanVien_MaNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_dbo.TaiKhoan_dbo.NhanVien_MaNhanVien]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TaiKhoan_dbo.NhomTaiKhoan_MaNhomTK] FOREIGN KEY([MaNhomTK])
REFERENCES [dbo].[NhomTaiKhoan] ([MaNhom])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_dbo.TaiKhoan_dbo.NhomTaiKhoan_MaNhomTK]
GO