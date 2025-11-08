--===================================TẠO DATABASE================================
go
	use master
	if exists(select * from sysdatabases where sysdatabases.name = 'CoupleTX_SQL')
		drop database CoupleTX_SQL
		create database CoupleTX_SQL
		on primary
		(
			size = 50MB,
			filegrowth = 10MB,
			maxsize = 200MB,
			filename = 'E:\SixForce_B\Data\CoupleTX_SQL.mdf',
			name = CoupleTX_SQL_data
		)
		log on
		(
			size = 10MB,
			filegrowth = 5MB,
			maxsize = unlimited,
			filename = 'E:\SixForce_B\Data\CoupleTX_SQL.ldf',
			name = CoupleTX_SQL_log
		)
go
use CoupleTX_SQL
--=====================================TẠO BẢNG==================================

-- BẢNG CHI NHÁNH
CREATE TABLE ChiNhanh(
	MaCN VARCHAR(100) PRIMARY KEY,
	TenCN NVARCHAR(300) NOT NULL,
	DiaChi NVARCHAR(500) NOT NULL
)

-- BẢNG NHÂN VIÊN
CREATE TABLE NhanVien(
	MaNV VARCHAR(20) PRIMARY KEY,
	HoTenNV NVARCHAR(200) NOT NULL,
	Phai NVARCHAR(5) CHECK (Phai = N'Nữ' OR Phai = N'Nam'),
	NgaySinh DATE,
	SDT VARCHAR(10),
	ChucVu NVARCHAR(100) NOT NULL,
	MaCN VARCHAR(100),
	CONSTRAINT FK_MACN_NHANVIEN FOREIGN KEY (MaCN) REFERENCES ChiNhanh (MaCN)
)

-- BẢNG TÀI KHOẢN
CREATE TABLE  TaiKhoan(
	TenDN VARCHAR(50) PRIMARY KEY,
	MatKhau NVARCHAR(100) NOT NULL,
	MaNV VARCHAR(20) UNIQUE,
	QuyenHan NVARCHAR(50),
	TrangThai BIT DEFAULT 1, -- 1 hoạt động, 0  là khoá
	NgayTao DATETIME DEFAULT GETDATE(),
	CONSTRAINT FK_TAIKHOAN_NHANVIEN FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
)

-- BẢNG KHÁCH HÀNG
CREATE TABLE KhachHang(
	MaKH VARCHAR(20) PRIMARY KEY,
	HoTen NVARCHAR(200) NOT NULL,
	Phai NVARCHAR(5) CHECK (Phai = N'Nữ' OR Phai = 'Nam'),
	SDT VARCHAR(10) NOT NULL,
	NgaySinh DATE check (Year(NgaySinh)<year(GetDate())),
	DiaChi NVARCHAR(300),
)

-- BẢNG SẢN PHẨM
CREATE TABLE SanPham(
	MaSP VARCHAR(20) PRIMARY KEY,
	TenSP NVARCHAR(500) NOT NULL,
	DonGia int CHECK (DonGia>0),
	DVT NVARCHAR(100)
)

-- KHO SẢN PHẨM
CREATE TABLE Kho(
	MaCN VARCHAR(100) REFERENCES ChiNhanh(MaCN),
	MaSP VARCHAR(20) REFERENCES SanPham (MaSP),
	SL int,
	CONSTRAINT PK_KHO PRIMARY KEY (MaCN,MaSP)
)

-- BẢNG HOÁ ĐƠN
CREATE TABLE HoaDon(
	SoHD VARCHAR(20) PRIMARY KEY,
	MaNV VARCHAR(20) REFERENCES NhanVien (MaNV),
	MAKH VARCHAR(20) REFERENCES KhachHang (MaKH),
	NgayLap DATETIME
)

-- BẢNG CHI TIẾT HOÁ ĐƠN
CREATE TABLE CTHD(
	SoHD VARCHAR(20) REFERENCES HoaDon (SoHD),
	MaSP VARCHAR(20) REFERENCES SanPham(MaSP),
	SL INT CHECK (SL > 0),
	ThanhTien int,
	CONSTRAINT PK_CTHD PRIMARY KEY (SoHD, MaSP)
)

-- BẢNG PHIẾU NHẬP
CREATE TABLE PhieuNhap(
	SoPN VARCHAR(20) PRIMARY KEY,
	TuCN VARCHAR(100) REFERENCES ChiNhanh(MaCN),
	DenCN VARCHAR(100) REFERENCES ChiNhanh(MaCN),
	NgayLap DATETIME
)

-- BẢNG CHI TIẾT PHIẾU NHẬP
CREATE TABLE CTPN(
	SoPN VARCHAR(20) REFERENCES PhieuNhap(SoPN),
	MaSP VARCHAR(20) REFERENCES SanPham(MaSP),
	SL INT CHECK(SL>0)
	CONSTRAINT PK_CTPN PRIMARY KEY (SoPN, MaSP)
)

-- BẢNG PHIẾU XUẤT
CREATE TABLE PhieuXuat(
	SoPX VARCHAR(20) PRIMARY KEY,
	TuCN VARCHAR(100) REFERENCES ChiNhanh(MaCN),
	DenCN VARCHAR(100) REFERENCES ChiNhanh(MaCN),
	NgayLap DATETIME
)

-- BẢNG CTPX
CREATE TABLE CTPX(
	SoPX VARCHAR(20) REFERENCES PhieuXuat(SoPX),
	MaSP VARCHAR(20) REFERENCES SanPham(MaSP),
	SL INT CHECK(SL>0),
	CONSTRAINT PK_CTPX PRIMARY KEY (SoPX, MaSP)
)

-- ======================================= FUNCTION ====================================
-- Lấy số chứng từ kế tiếp theo tiền tố + 6 số cuối
go
CREATE OR ALTER FUNCTION dbo.uf_NextNumber
(
    @Prefix NVARCHAR(20),   -- ví dụ 'PX-' hoặc MaCN như 'BH'
    @TableName SYSNAME,     -- 'HoaDon' | 'PhieuXuat' | 'PhieuNhap'
    @PKName SYSNAME         -- 'SoHD' | 'SoPX' | 'SoPN'
)
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @Next INT = 1;
    DECLARE @Result NVARCHAR(50);

    IF @TableName = 'HoaDon' AND @PKName = 'SoHD'
    BEGIN
        SELECT @Next = ISNULL(MAX(CAST(RIGHT(SoHD, 6) AS INT)), 0) + 1
        FROM dbo.HoaDon
        WHERE SoHD LIKE @Prefix + '%';
		SET @Result = @Prefix + RIGHT('000000' + CAST(@Next AS VARCHAR(6)), 6);
    END

    ELSE IF @TableName = 'PhieuXuat' AND @PKName = 'SoPX'
    BEGIN
        SELECT @Next = ISNULL(MAX(CAST(RIGHT(SoPX, 6) AS INT)), 0) + 1
        FROM dbo.PhieuXuat
        WHERE SoPX LIKE @Prefix + '%';
		SET @Result = @Prefix + RIGHT('000000' + CAST(@Next AS VARCHAR(6)), 6);
    END

    ELSE IF @TableName = 'PhieuNhap' AND @PKName = 'SoPN'
    BEGIN
        SELECT @Next = ISNULL(MAX(CAST(RIGHT(SoPN, 6) AS INT)), 0) + 1
        FROM dbo.PhieuNhap
        WHERE SoPN LIKE @Prefix + '%';
		SET @Result = @Prefix + RIGHT('000000' + CAST(@Next AS VARCHAR(6)), 6);
    END

	ELSE IF @TableName = 'KhachHang' AND @PKName = 'KH'
	Begin
		Select @Next = ISNULL(Max(Cast(Right(MaKH,3)as int)),0)+1
		from dbo.KhachHang
		where MaKH Like @Prefix +'%';
		SET @Result = @Prefix + RIGHT('00' + CAST(@Next AS VARCHAR(3)), 3);
	end

    -- Nếu không có dữ liệu thì mặc định @Next = 1
    RETURN @Result;
END;
GO

GO
--KIỂM TRA TÀI KHOẢN
CREATE OR ALTER FUNCTION dbo.uf_CheckAccount(@USERNAME VARCHAR(50), @MATKHAU NVARCHAR(100))
RETURNS Bit
AS
BEGIN
	DECLARE @KQ bit = 0
	IF EXISTS (SELECT * FROM TaiKhoan WHERE TenDN = @USERNAME AND CONVERT(NVARCHAR(100), DecryptByPassPhrase('MaHoaMatKhau', MatKhau)) = @MATKHAU and TrangThai = 1)
		SET @KQ = 1
	ELSE
		SET @KQ = 0
	RETURN @KQ
END

go
-- Tạo mã barcode sản phẩm
CREATE FUNCTION dbo.uf_TaoMaSP()
RETURNS VARCHAR(13)
AS
BEGIN
    DECLARE @SoCuoi BIGINT
    DECLARE @MaMoi VARCHAR(13)

    -- Lấy mã lớn nhất hiện có
    SELECT @SoCuoi = MAX(CAST(MaSP AS BIGINT)) FROM SanPham

    IF @SoCuoi IS NULL
        SET @SoCuoi = 893000000000  -- prefix 893 (VN) + 10 số

    -- Tăng lên 1
    SET @MaMoi = CAST(@SoCuoi + 1 AS VARCHAR(13))

    RETURN @MaMoi
END


-- LẤY THÔNG TIN ACCOUNT THEO TÀI KHOẢN
GO
CREATE OR ALTER FUNCTION dbo.ufTaiKhoan (@USERNAME VARCHAR(50), @MATKHAU NVARCHAR(100))
RETURNS Table
AS
	Return (Select QuyenHan,ChucVu,MaCN 
	from TaiKhoan tk join NhanVien nv on tk.MaNV = nv.MaNV
	where TenDN = @USERNAME AND CONVERT(NVARCHAR(100), DecryptByPassPhrase('MaHoaMatKhau', MatKhau)) = @MATKHAU)
-- SẢN PHẨM VÀ SỐ LƯỢNG SẢN PHẨM THEO CHI NHÁNH
go
CREATE OR ALTER FUNCTION dbo.uf_SanPham (@MACN VARCHAR(100))
RETURNS TABLE
AS
	RETURN (SELECT SanPham.MaSP, TenSP, DVT,SL,DonGia 
			FROM KHO LEFT JOIN SanPham 
			ON Kho.MaSP = SanPham.MaSP 
			WHERE MaCN = @MACN)

go
CREATE OR ALTER FUNCTION dbo.uf_SanPham_Kho (@MaCN varchar(20) = NULL)
RETURNs TABLE
AS
  RETURN select SUBSTRING(
    TenSP,
    PATINDEX('%[A-Z][A-Z][A-Z] [0-9][0-9][0-9][0-9]%', TenSP),
    8
  ) AS Model,TenSP,DonGia,Sum(SL) as TongSL
  from Kho k join SanPham sp on k.MaSP = sp.MaSP
  where  (@MaCN IS NULL OR @MaCN = '' OR k.MaCN LIKE @MaCN)
  Group by MaCN,k.MaSP,TenSP,DonGia
GO

--


-- MODEL - MÀU - SIZE
CREATE OR ALTER Function  dbo.v_uf_SanPham_MauKhoSize(@Model varchar(20))
RETURNS TABLE
AS
 RETURN SELECT
    k.MaCN,            -- Mã chi nhánh
    k.MaSP,            -- Mã sản phẩm
    k.SL,         -- Số lượng tồn kho
    -- Model (mã sản phẩm, nếu cần hiển thị chi tiết SP)
    SUBSTRING(s.TenSP, PATINDEX('%[A-Z][A-Z][A-Z] [0-9][0-9][0-9][0-9]%', s.TenSP), 8) AS Model,
    -- Tên sản phẩm
    LTRIM(RTRIM(LEFT(s.TenSP, PATINDEX('%[A-Z][A-Z][A-Z] [0-9][0-9][0-9][0-9]%', s.TenSP) - 2))) AS TenSP,
    -- Size (tách từ TenSP)
    SUBSTRING(
        s.TenSP,
        CHARINDEX('/', s.TenSP, PATINDEX('%[A-Z][A-Z][A-Z] [0-9][0-9][0-9][0-9]%', s.TenSP) + 8) + 1,
        CHARINDEX('/', s.TenSP, CHARINDEX('/', s.TenSP, PATINDEX('%[A-Z][A-Z][A-Z] [0-9][0-9][0-9][0-9]%', s.TenSP) + 8) + 1) -
        CHARINDEX('/', s.TenSP, PATINDEX('%[A-Z][A-Z][A-Z] [0-9][0-9][0-9][0-9]%', s.TenSP) + 8) - 1
    ) AS Size,
    -- Màu (tách từ TenSP)
    RIGHT(s.TenSP, CHARINDEX('/', REVERSE(s.TenSP)) - 1) AS Mau
FROM Kho k
LEFT JOIN SanPham s ON k.MaSP = s.MaSP
WHERE SUBSTRING(s.TenSP, PATINDEX('%[A-Z][A-Z][A-Z] [0-9][0-9][0-9][0-9]%', s.TenSP), 8) = @Model
-- ================================== TRIGGERS ================================

-- CHI TIẾT HOÁ ĐƠN
-- Tự tính ThanhTien và trừ kho chi nhánh của nhân viên lập hóa đơn
go
CREATE OR ALTER TRIGGER dbo.trg_CTHD_AIU_TinhTien_TruKho
ON dbo.CTHD
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật ThànhTiền
    UPDATE c
    SET c.ThanhTien = i.SL * sp.DonGia
    FROM dbo.CTHD c
    JOIN inserted i ON c.SoHD = i.SoHD AND c.MaSP = i.MaSP
    JOIN dbo.SanPham sp ON sp.MaSP = i.MaSP;

    -- Xác định chi nhánh của NV lập hóa đơn
    ;WITH X AS (
        SELECT i.MaSP, i.SL, hd.SoHD, nv.MaCN
        FROM inserted i
        JOIN dbo.HoaDon hd ON hd.SoHD = i.SoHD
        JOIN dbo.NhanVien nv ON nv.MaNV = hd.MaNV
    )
    -- Trừ kho (nếu chưa có dòng kho thì tạo = 0 rồi trừ)
    MERGE dbo.Kho AS k
    USING X AS x
      ON k.MaCN = x.MaCN AND k.MaSP = x.MaSP
    WHEN MATCHED THEN
        UPDATE SET k.SL = k.SL - x.SL
    WHEN NOT MATCHED THEN
        INSERT (MaCN, MaSP, SL) VALUES (x.MaCN, x.MaSP, 0 - x.SL);
END;
GO

-- XUẤT - NHẬP KHO
-- Khi thêm CTPX: giảm kho tại chi nhánh xuất; đồng thời
-- đảm bảo tồn tại Phiếu Nhập “đối ứng” (PN-xxxxxx) và copy chi tiết qua

CREATE OR ALTER TRIGGER dbo.trg_CTPX_AI_Xuat_GiamKho_TaoPN
ON dbo.CTPX
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Giảm kho tại chi nhánh xuất (TuCN)
    ;WITH X AS (
        SELECT px.TuCN AS MaCN, i.MaSP, i.SL, px.SoPX, px.DenCN
        FROM inserted i
        JOIN dbo.PhieuXuat px ON px.SoPX = i.SoPX
    )
    MERGE dbo.Kho AS k
    USING X AS x
      ON k.MaCN = x.MaCN AND k.MaSP = x.MaSP
    WHEN MATCHED THEN UPDATE SET k.SL = k.SL - x.SL
    WHEN NOT MATCHED THEN INSERT (MaCN, MaSP, SL) VALUES (x.MaCN, x.MaSP, 0 - x.SL);

    -- Tạo Phiếu Nhập đối ứng (nếu chưa có)
    INSERT INTO dbo.PhieuNhap(SoPN, TuCN, DenCN, NgayLap)
    SELECT DISTINCT
        REPLACE(px.SoPX,'PX-','PN-'), px.TuCN, px.DenCN, SYSDATETIME()
    FROM inserted i
    JOIN dbo.PhieuXuat px ON px.SoPX = i.SoPX
    LEFT JOIN dbo.PhieuNhap pn ON pn.SoPN = REPLACE(px.SoPX,'PX-','PN-')
    WHERE pn.SoPN IS NULL;

    -- Copy chi tiết sang CTPN (không trùng)
    INSERT INTO dbo.CTPN(SoPN, MaSP, SL)
    SELECT REPLACE(i.SoPX,'PX-','PN-'), i.MaSP, i.SL
    FROM inserted i
    LEFT JOIN dbo.CTPN t ON t.SoPN = REPLACE(i.SoPX,'PX-','PN-') AND t.MaSP = i.MaSP
    WHERE t.SoPN IS NULL;
END;
GO




--==================================== PROCEDURES =======================================

-- LỌC DỮ LIỆU CHO CHART THEO NGÀY
CREATE OR ALTER PROC dbo.sp_ChartDay
	@tuNgay DateTime,
	@denNgay DateTime,
	@maCN varchar(20)
AS
BEGIN
    SET NOCOUNT ON;
	SELECT 
		CAST(hd.NgayLap AS DATE) AS Ngay,
		SUM(ct.ThanhTien) AS TongTien
	FROM HoaDon hd
	LEFT JOIN CTHD ct ON hd.SoHD = ct.SoHD
	WHERE hd.NgayLap BETWEEN @tuNgay AND @denNgay
	  AND  LEFT(hd.SoHD, PATINDEX('%[0-9]%', hd.SoHD) - 1) like @maCN
	GROUP BY CAST(hd.NgayLap AS DATE)
	ORDER BY Ngay;
END;
GO

-- LỌC DỮ LIỆU CHO CHART THEO GIỜ
CREATE OR ALTER PROC dbo.sp_ChartHour
	@tuGio DateTime,
	@denGio DateTime,
	@maCN varchar(20)
AS
BEGIN
	SELECT 
    DATEPART(HOUR, hd.NgayLap) AS Gio,
    SUM(ct.ThanhTien) AS TongTien
		FROM HoaDon hd
		LEFT JOIN CTHD ct ON hd.SoHD = ct.SoHD
		WHERE hd.NgayLap BETWEEN @tuGio AND @denGio
		  	  AND  LEFT(hd.SoHD, PATINDEX('%[0-9]%', hd.SoHD) - 1) like @maCN
		GROUP BY DATEPART(HOUR, hd.NgayLap)
		ORDER BY Gio;
END;
GO

-- CHI TIẾT HOÁ ĐƠN
CREATE OR ALTER PROCEDURE dbo.sp_ThemCTHD
	@SoHD VARCHAR(20),
    @MaSP NVARCHAR(20),
    @MaKH NVARCHAR(20),
    @MaNV NVARCHAR(20),
    @SL   INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @MaCN NVARCHAR(20) = (SELECT MaCN FROM dbo.NhanVien WHERE MaNV = @MaNV);
    IF @MaCN IS NULL
        THROW 51000, 'MaNV khong hop le.', 1;
		

    -- Thêm chi tiết
    INSERT INTO dbo.CTHD(SoHD, MaSP, SL)
    VALUES (@SoHD, @MaSP, @SL);

END;
GO
go
-- PHIẾU XUẤT
CREATE OR ALTER PROCEDURE dbo.sp_ThemCTPX
	@SoPX NVARCHAR(20),
    @MaSP NVARCHAR(20),
    @SL   INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.CTPX(SoPX, MaSP, SL)
    VALUES (@SoPX, @MaSP, @SL);
END;
GO

go
-- ĐỔI PX THÀNH PN THEO SỐ PX
CREATE OR ALTER PROCEDURE dbo.usp_XacNhanNhapHang
    @SoPX VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SoPN VARCHAR(50) = REPLACE(@SoPX,'PX','PN');

    -- Tạo PN nếu chưa có
    INSERT INTO dbo.PhieuNhap(SoPN, TuCN, DenCN, NgayLap)
    SELECT @SoPN, px.TuCN, px.DenCN, GETDATE()
    FROM dbo.PhieuXuat px
    WHERE px.SoPX = @SoPX
      AND NOT EXISTS (SELECT 1 FROM dbo.PhieuNhap WHERE SoPN = @SoPN);

    -- Copy chi tiết
    INSERT INTO dbo.CTPN(SoPN, MaSP, SL)
    SELECT @SoPN, x.MaSP, x.SL
    FROM dbo.CTPX x
    WHERE x.SoPX = @SoPX
      AND NOT EXISTS (
            SELECT 1 FROM dbo.CTPN t WHERE t.SoPN = @SoPN AND t.MaSP = x.MaSP
      );

    -- Tăng kho đích
    ;WITH Y AS (
        SELECT px.DenCN AS MaCN, x.MaSP, x.SL
        FROM dbo.PhieuXuat px
        JOIN dbo.CTPX x ON x.SoPX = px.SoPX
        WHERE px.SoPX = @SoPX
    )
    MERGE dbo.Kho AS k
    USING Y AS y
      ON k.MaCN = y.MaCN AND k.MaSP = y.MaSP
    WHEN MATCHED THEN UPDATE SET k.SL = k.SL + y.SL
    WHEN NOT MATCHED THEN INSERT (MaCN, MaSP, SL) VALUES (y.MaCN, y.MaSP, y.SL);

    SELECT @SoPN AS SoPN;
END;
GO

--Stored Procedure Xác nhập hàng
CREATE OR ALTER PROCEDURE dbo.usp_XacNhanNhapHang
    @SoPX NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SoPN NVARCHAR(20);

    -- 1️⃣ Tạo số phiếu nhập mới (đổi PX → PN)
    SET @SoPN = REPLACE(@SoPX, 'PX', 'PN');

    -- 2️⃣ Đổi mã bảng PhieuNhap
    INSERT INTO dbo.PhieuNhap (SoPN, TuCN,DenCN,NgayLap)
    SELECT 
        @SoPN,
		px.TuCN,
        px.DenCN,
        GETDATE()
    FROM dbo.PhieuXuat px
    WHERE px.SoPX = @SoPX;

    -- 3️⃣ Thêm chi tiết phiếu nhập từ chi tiết phiếu xuất
    INSERT INTO dbo.CTPN (SoPN, MaSP, SL)
    SELECT 
        @SoPN,
        ctp.MaSP,
        ctp.SL
    FROM dbo.CTPX ctp
    WHERE ctp.SoPX = @SoPX;

    -- 4️⃣ Cập nhật tồn kho của chi nhánh nhận hàng
    ;WITH X AS (
        SELECT px.DenCN AS MaCN, ctp.MaSP, ctp.SL
        FROM dbo.PhieuXuat px
        JOIN dbo.CTPX ctp ON px.SoPX = ctp.SoPX
        WHERE px.SoPX = @SoPX
    )
    MERGE dbo.Kho AS k
    USING X AS x
      ON k.MaCN = x.MaCN AND k.MaSP = x.MaSP
    WHEN MATCHED THEN 
        UPDATE SET k.SL = k.SL + x.SL
    WHEN NOT MATCHED THEN 
        INSERT (MaCN, MaSP, SL) VALUES (x.MaCN, x.MaSP, x.SL);

	Delete From CTPN where SoPN = @SoPX
	Delete From PhieuNhap where SoPN = @SoPX
END;
GO


-- Report (báo cáo) doanh thu theo ngày
CREATE OR ALTER PROCEDURE dbo.sp_BaoCaoDoanhThuNgay_Report
    @Ngay DATE,
    @MaCN NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        cn.TenCN,
        hd.SoHD,
        hd.NgayLap,
        nv.MaNV,
        nv.HoTenNV,
        COUNT(ct.MaSP) AS SoLuong,
        SUM(ct.SL * ct.ThanhTien) AS TongTien
    FROM dbo.HoaDon hd
    JOIN dbo.CTHD ct ON hd.SoHD = ct.SoHD
    JOIN dbo.NhanVien nv ON nv.MaNV = hd.MaNV
    JOIN dbo.ChiNhanh cn ON cn.MaCN = nv.MaCN
    WHERE CAST(hd.NgayLap AS DATE) = @Ngay
      AND nv.MaCN = @MaCN
    GROUP BY cn.TenCN, hd.SoHD, hd.NgayLap, nv.MaNV, nv.HoTenNV;
END;
GO


--Report (báo cáo) xuất nhập kho theo ngày
CREATE OR ALTER PROCEDURE dbo.sp_BaoCaoXuatNhapKhoNgay
    @Ngay DATE,
    @MaCN NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        k.MaCN,
        cn.TenCN,
        k.MaSP,
        sp.TenSP,

        -- Tổng nhập trong ngày (phiếu nhập đến chi nhánh này)
        ISNULL(SUM(CASE 
            WHEN CAST(pn.NgayLap AS DATE) = @Ngay 
                 AND pn.DenCN = @MaCN 
            THEN ctpn.SL ELSE 0 END), 0) AS SoLuongNhap,

        -- Tổng xuất trong ngày: bán hàng + chuyển chi nhánh khác
        ISNULL(SUM(CASE 
            WHEN CAST(hd.NgayLap AS DATE) = @Ngay 
                 AND LEFT(hd.SoHD, LEN(@MaCN)) = @MaCN 
            THEN cthd.SL ELSE 0 END), 0)
        +
        ISNULL(SUM(CASE 
            WHEN CAST(px.NgayLap AS DATE) = @Ngay 
                 AND px.TuCN = @MaCN 
            THEN ctx.SL ELSE 0 END), 0) AS SoLuongXuat,

        -- Tồn cuối (lấy từ kho hiện tại)
        k.SL AS TonCuoiNgay

    FROM Kho k
    JOIN ChiNhanh cn ON cn.MaCN = k.MaCN
    LEFT JOIN SanPham sp ON sp.MaSP = k.MaSP

    -- Phiếu nhập
    LEFT JOIN PhieuNhap pn ON pn.DenCN = k.MaCN
    LEFT JOIN CTPN ctpn ON ctpn.SoPN = pn.SoPN AND ctpn.MaSP = k.MaSP

    -- Hóa đơn (suy ra chi nhánh từ tiền tố SoHD)
    LEFT JOIN HoaDon hd ON LEFT(hd.SoHD, LEN(@MaCN)) = @MaCN
    LEFT JOIN CTHD cthd ON cthd.SoHD = hd.SoHD AND cthd.MaSP = k.MaSP

    -- Phiếu xuất giữa chi nhánh
    LEFT JOIN PhieuXuat px ON px.TuCN = k.MaCN
    LEFT JOIN CTPX ctx ON ctx.SoPX = px.SoPX AND ctx.MaSP = k.MaSP

    WHERE k.MaCN = @MaCN
    GROUP BY k.MaCN, cn.TenCN, k.MaSP, sp.TenSP, k.SL;
END;
GO

-- XÓA KHÁCH HÀNG
CREATE OR ALTER PROCEDURE sp_XoaKhachHang
    @MaKH NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        -- Xóa chi tiết hóa đơn của khách hàng này
        DELETE FROM CTHD
        WHERE SoHD IN (SELECT SoHD FROM HoaDon WHERE MaKH = @MaKH);

        -- Xóa hóa đơn của khách hàng này
        DELETE FROM HoaDon
        WHERE MaKH = @MaKH;

        -- Cuối cùng xóa khách hàng
        DELETE FROM KhachHang
        WHERE MaKH = @MaKH;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END;
GO

-- XÓA HÓA ĐƠN
CREATE OR ALTER PROCEDURE sp_XoaHoaDon
    @soHD NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        DECLARE @MaCN NVARCHAR(10);

        -- Lấy mã chi nhánh từ hóa đơn
        SELECT @MaCN = MaCN FROM HoaDon inner join NhanVien on HoaDon.MaNV = NhanVien.MaNV WHERE SoHD = @soHD;

        -- Cập nhật trả hàng: cộng lại số lượng sản phẩm trong chi tiết hóa đơn vào kho
        UPDATE sp
        SET sp.SL = sp.SL + cthd.SL
        FROM Kho sp
        INNER JOIN CTHD cthd ON sp.MaSP = cthd.MaSP
        WHERE cthd.SoHD= @soHD AND sp.MaCN = @MaCN;

        -- Xóa chi tiết hóa đơn
        DELETE FROM CTHD WHERE SoHD = @soHD;

        -- Xóa hóa đơn
        DELETE FROM HoaDon WHERE SoHD = @soHD;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END;
go

--XÓA PHIẾU XUẤT
CREATE OR ALTER PROCEDURE sp_XoaPhieuXuat
    @SoPX NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        DECLARE @MaCN NVARCHAR(10);
        SELECT @MaCN = TuCN FROM PhieuXuat WHERE SoPX = @SoPX;

        -- Hoàn hàng: cộng lại số lượng sản phẩm trong phiếu xuất
        UPDATE sp
        SET sp.SL = sp.SL + ctpx.SL
        FROM Kho sp
        INNER JOIN CTPX ctpx ON sp.MaSP = ctpx.MaSP
        WHERE ctpx.SoPX = @SoPX AND sp.MaCN = @MaCN;

        DELETE FROM CTPX WHERE SoPX = @SoPX;
        DELETE FROM PhieuXuat WHERE SoPX = @SoPX;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END;
go

-- THÔNG TIN HÓA ĐƠN
CREATE OR ALTER PROC dbo.sp_XemHoaDon @soHD varchar(20)
AS
SELECT hd.SoHD,NgayLap,HoTen,kh.SDT,HoTenNV,sum(ThanhTien)as TongTien
	FROM HoaDon hd left join KhachHang kh on hd.MAKH = kh.MaKH
					join NhanVien nv on hd.MaNV = nv.MaNV
					join CTHD cthd on hd.SoHD = cthd.SoHD
	where hd.SoHD like @soHD
	group by hd.SoHD,NgayLap,HoTen,kh.SDT,HoTenNV
GO


-- XÓA SẢN PHẨM
CREATE OR ALTER PROC sp_XoaSanPham @MaSP VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;
		DELETE FROM KHO WHERE MaSP = @MaSP
		DELETE FROM SanPham WHERE MaSP = @MaSP
END;
Go

-- XÓA PHIẾU NHẬP
CREATE OR ALTER PROCEDURE sp_XoaPhieuNhap
    @SoPN NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        DECLARE @MaCN NVARCHAR(10);
        SELECT @MaCN = TuCN FROM PhieuNhap WHERE SoPN = @SoPN;

        -- Khi xóa phiếu nhập: trừ số lượng khỏi kho
        UPDATE sp
        SET sp.SL = sp.SL - ctpn.SL
        FROM Kho sp
        INNER JOIN CTPN ctpn ON sp.MaSP = ctpn.MaSP
        WHERE ctpn.SoPN = @SoPN AND sp.MaCN = @MaCN;

        DELETE FROM CTPN WHERE SoPN = @SoPN;
        DELETE FROM PhieuNhap WHERE SoPN = @SoPN;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END;
go

-- XÓA NHÂN VIÊN
CREATE OR ALTER PROCEDURE sp_XoaNhanVien
    @MaNV NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        -- Xóa các hóa đơn nhân viên này tạo
        DELETE FROM CTHD
        WHERE SoHD IN (SELECT SoHD FROM HoaDon WHERE MaNV = @MaNV);

        DELETE FROM HoaDon WHERE MaNV = @MaNV;

        -- Cuối cùng xóa nhân viên
        DELETE FROM NhanVien WHERE MaNV = @MaNV;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END;
go

--================================ VIEWS =====================================
-- Khách hàng
CREATE OR ALTER VIEW dbo.vKhachHang
AS
SELECT MaKH, HoTen AS HoTenKhachHang, SDT
FROM dbo.KhachHang;
GO

-- Nhân viên
CREATE OR ALTER VIEW dbo.vNhanVien
AS
SELECT MaNV, HoTenNV
FROM dbo.NhanVien;
GO

-- Hóa đơn
CREATE OR ALTER VIEW dbo.vHoaDon
AS
SELECT NgayLap,hd.SoHD, sum(SL)as SL, sum(ThanhTien)as TongTien,kh.SDT,nv.HoTenNV
  FROM HoaDon hd join CTHD cthd on hd.SoHD = cthd.SoHD
				left join KhachHang kh on hd.MAKH = kh.MaKH
				join NhanVien nv on hd.MaNV = nv.MaNV
  group by NgayLap,hd.sohd,kh.SDT,nv.HoTenNV
GO



-- Chi tiết hóa đơn (tên sp, đơn giá, số lượng, thành tiền)
CREATE OR ALTER VIEW dbo.vCTHD
AS
SELECT  c.SoHD, sp.TenSP, sp.DonGia, c.SL, c.ThanhTien
FROM dbo.CTHD c
JOIN dbo.SanPham sp ON sp.MaSP = c.MaSP;
GO

-- Báo cáo bán hàng (lọc theo mã chi nhánh)
CREATE OR ALTER VIEW dbo.vBaoCaoBanHang_Ngay_ChiNhanh
AS
SELECT  
    CAST(hd.NgayLap AS DATE) AS Ngay,
    nv.MaCN,

    COUNT(DISTINCT hd.SoHD) AS SoHD_DaBan,

    -- Tổng khách hàng (gồm cả khách lẻ)
    COUNT(DISTINCT ISNULL(hd.MaKH, 'KLE_' + CAST(hd.SoHD AS NVARCHAR(20)))) AS SoKhachHang,

    -- Riêng khách lẻ (MaKH bị NULL)
    COUNT(DISTINCT CASE WHEN hd.MaKH IS NULL THEN hd.SoHD END) AS SoKhachLe,

    SUM(ct.ThanhTien) AS TongThanhTien,
    SUM(ct.SL) AS TongSLBan
FROM dbo.HoaDon hd
JOIN dbo.NhanVien nv ON nv.MaNV = hd.MaNV
LEFT JOIN dbo.CTHD ct ON ct.SoHD = hd.SoHD
GROUP BY CAST(hd.NgayLap AS DATE), nv.MaCN;
GO


-- Báo cáo xuất - nhập - tồn kho theo chi nhánh - theo ngày
CREATE OR ALTER VIEW dbo.vBaoCaoQuanLy_Ngay_ChiNhanh
AS
WITH Ban AS (
    SELECT CAST(hd.NgayLap AS DATE) AS Ngay, nv.MaCN, SUM(ct.SL) AS SLBan
    FROM dbo.HoaDon hd
    JOIN dbo.NhanVien nv ON nv.MaNV = hd.MaNV
    JOIN dbo.CTHD ct ON ct.SoHD = hd.SoHD
    GROUP BY CAST(hd.NgayLap AS DATE), nv.MaCN
),
Xuat AS (
    SELECT CAST(px.NgayLap AS DATE) AS Ngay, px.TuCN AS MaCN, SUM(x.SL) AS SLXuat
    FROM dbo.PhieuXuat px
    JOIN dbo.CTPX x ON x.SoPX = px.SoPX
    GROUP BY CAST(px.NgayLap AS DATE), px.TuCN
),
Nhap AS (
    SELECT CAST(pn.NgayLap AS DATE) AS Ngay, pn.DenCN AS MaCN, SUM(n.SL) AS SLNhap
    FROM dbo.PhieuNhap pn
    JOIN dbo.CTPN n ON n.SoPN = pn.SoPN
	WHERE LEFT(pn.SoPN,2) LIKE 'PN'
    GROUP BY CAST(pn.NgayLap AS DATE), pn.DenCN
)
SELECT 
    COALESCE(b.Ngay, x.Ngay, n.Ngay) AS Ngay,
    COALESCE(b.MaCN, x.MaCN, n.MaCN) AS MaCN,
    ISNULL(b.SLBan,0)  + ISNULL(x.SLXuat,0) AS SL_Ban_Xuat,
    ISNULL(n.SLNhap,0) AS SL_Nhap
FROM Ban b
FULL JOIN Xuat x ON x.Ngay = b.Ngay AND x.MaCN = b.MaCN
FULL JOIN Nhap n ON n.Ngay = COALESCE(b.Ngay,x.Ngay) AND n.MaCN = COALESCE(b.MaCN,x.MaCN);
GO

-- Tồn đầu ngày - cuối ngày hiện tại theo chi nhánh
CREATE OR ALTER VIEW dbo.vTonKho_TheoChiNhanh
AS
SELECT k.MaCN,Ngay,SL as [TonCuoiNgay], SL+SLXuat as [TonDauNgay]
FROM (select MaCN,sum(SL)as SL from Kho group by MaCN) AS k
	JOIN (select Ngay,MaCN,sum(SL_Ban_Xuat)as SLXuat, sum(SL_Nhap)as SLNhap from dbo.vBaoCaoQuanLy_Ngay_ChiNhanh Group by Ngay,MaCN) AS cn ON k.MaCN = cn.MaCN
GO

--Phiếu nhập
CREATE OR ALTER VIEW v_XemPhieuNhap AS
SELECT
	pn.NgayLap,
	pn.SoPN,
	cnTu.TenCN as TuCN,
	cnDen.TenCN as DenCN,
	SUM(ct.SL)as[TongSL]
FROM PhieuNhap pn
JOIN CTPN ct on pn.SoPN = ct.SoPN
JOIN ChiNhanh cnTu on pn.TuCN = cnTu.MaCN
JOIN ChiNhanh cnDen on pn.DenCN=cnDen.MaCN
GROUP BY 	pn.NgayLap,
	pn.SoPN,
	cnTu.TenCN,
	cnDen.TenCN;
GO

--Xem chi tiết phiếu nhập
CREATE OR ALTER VIEW dbo.v_XemCTPN
AS
SELECT  c.SoPN, sp.MaSP,sp.TenSP, c.SL
FROM dbo.CTPN c
JOIN dbo.SanPham sp ON sp.MaSP = c.MaSP;
GO

-- Xem phiếu xuất
CREATE OR ALTER VIEW v_XemCTPX AS
select NgayLap,px.SoPX,tuCN.TenCN as [TuCN],denCN.TenCN as [DenCN],SUM(ct.SL)as [TongSL]
from PhieuXuat px join CTPX ct on px.SoPX = ct.SoPX
				  join ChiNhanh tuCN on px.TuCN = tuCN.MaCN
				  join ChiNhanh denCN on px.DenCN = denCN.MaCN
group by NgayLap,px.SoPX,tuCN.TenCN,denCN.TenCN
GO

-- Xem chi tiết phiếu xuất
CREATE OR ALTER VIEW dbo.v_XemSanPhamPhieuXuat AS
SELECT  c.SoPX, sp.MaSP,sp.TenSP, c.SL
FROM dbo.CTPX c
JOIN dbo.SanPham sp ON sp.MaSP = c.MaSP;
GO

-- SẢN PHẨM ADMIN
CREATE OR ALTER VIEW dbo.v_SanPham_Kho
AS
  select SUBSTRING(
    TenSP,
    PATINDEX('%[A-Z][A-Z][A-Z] [0-9][0-9][0-9][0-9]%', TenSP),
    8
  ) AS Model,TenSP,DonGia,Sum(SL) as TongSL
  from Kho k join SanPham sp on k.MaSP = sp.MaSP
  Group by k.MaSP,TenSP,DonGia
GO

--================================================ DỮ LIỆU MẪU

-- chi nhánh
insert into ChiNhanh values ('BH',N'Couple TX Biên Hoà',N'phường Thống Nhất, Tp. Biên Hòa, Đồng Nai, Việt Nam'),
							('AEBD',N'Couple TX Aeon Bình Dương',N'Đại lộ Bình Dương, Thuận Giao, Thuận An, Bình Dương, Việt Nam'),
							('DA',N'Couple TX Dĩ An',N'12C Nguyễn An Ninh, Dĩ An, Thủ Đức, Hồ Chí Minh, Việt Nam'),
							('VVN',N'Couple TX Võ Văn Ngân',N'134 Đ. Võ Văn Ngân, Bình Thọ, Thủ Đức, Hồ Chí Minh, Việt Nam'),
							('HBT',N'Couple TX Hai Bà Trưng',N'289 Hai Bà Trưng, Phường Võ Thị Sáu, Quận 3, Hồ Chí Minh 700000, Việt Nam'),
							('BD',N'Couple TX Bình Dương',N'65a Yersin, Phú Cường, Thủ Dầu Một, Bình Dương, Việt Nam'),
							('Tong',N'Couple TX Chính','65a Yersin, Phú Cường, Thủ Dầu Một, Bình Dương, Việt Nam')

-- Nhân viên
-- quản lý
INSERT INTO NhanVien (MaNV, HoTenNV, Phai, NgaySinh, SDT, ChucVu, MaCN) VALUES
('QLBH',   N'Nguyễn Văn A', N'Nam', '1985-05-12', '0912345678', N'Quản lý', 'BH'),
('QLAEBD', N'Trần Thị B',   N'Nữ',  '1987-08-21', '0934567890', N'Quản lý', 'AEBD'),
('QLDA',   N'Lê Văn C',     N'Nam', '1983-02-14', '0978123456', N'Quản lý', 'DA'),
('QLVVN',  N'Phạm Thị D',   N'Nữ',  '1990-11-01', '0903456123', N'Quản lý', 'VVN'),
('QLHBT',  N'Hoàng Văn E',  N'Nam', '1984-07-09', '0987654321', N'Quản lý', 'HBT'),
('QLBD',   N'Võ Thị F',     N'Nữ',  '1986-09-17', '0912233445', N'Quản lý', 'BD'),
('QLTong', N'Đặng Văn G',   N'Nam', '1982-03-05', '0961122334', N'Quản lý', 'Tong'),
('GDCPTX',N'Đặng Thanh X', N'Nữ','1982-05-15','0865791254',N'Giám đốc','Tong');

-- nhân viên
INSERT INTO NhanVien (MaNV, HoTenNV, Phai, NgaySinh, SDT, ChucVu, MaCN) VALUES
('NVBH01',   N'Nguyễn Thị H', N'Nữ',  '1995-06-20', '0911111111', N'Nhân viên bán hàng', 'BH'),
('NVBH02',   N'Lê Văn I',     N'Nam', '1996-04-15', '0922222222', N'Nhân viên bán hàng', 'BH'),

('NVAEBD01', N'Trần Văn K',   N'Nam', '1994-03-11', '0933333333', N'Nhân viên bán hàng', 'AEBD'),
('NVAEBD02', N'Phạm Thị L',   N'Nữ',  '1992-12-25', '0944444444', N'Nhân viên bán hàng', 'AEBD'),

('NVDA01',   N'Huỳnh Văn M',  N'Nam', '1993-01-18', '0955555555', N'Nhân viên bán hàng', 'DA'),
('NVDA02',   N'Đỗ Thị N',     N'Nữ',  '1997-09-30', '0966666666', N'Nhân viên bán hàng', 'DA'),

('NVVVN01',  N'Nguyễn Văn O', N'Nam', '1991-07-14', '0977777777', N'Nhân viên bán hàng', 'VVN'),
('NVVVN02',  N'Lê Thị P',     N'Nữ',  '1998-02-10', '0988888888', N'Nhân viên bán hàng', 'VVN'),

('NVHBT01',  N'Hoàng Văn Q',  N'Nam', '1990-10-09', '0999999999', N'Nhân viên bán hàng', 'HBT'),
('NVHBT02',  N'Nguyễn Thị R', N'Nữ',  '1999-11-22', '0912121212', N'Nhân viên bán hàng', 'HBT'),

('NVBD01',   N'Phan Văn S',   N'Nam', '1993-05-05', '0923232323', N'Nhân viên bán hàng', 'BD'),
('NVBD02',   N'Vũ Thị T',     N'Nữ',  '1996-08-18', '0934343434', N'Nhân viên bán hàng', 'BD'),

('NVTong01', N'Đặng Văn U',   N'Nam', '1992-04-02', '0945454545', N'Nhân viên bán hàng', 'Tong'),
('NVTong02', N'Lý Thị V',     N'Nữ',  '1994-09-12', '0956565656', N'Nhân viên bán hàng', 'Tong');


-- Khách hàng
INSERT INTO KhachHang (MaKH, HoTen, Phai, SDT, NgaySinh, DiaChi)
VALUES
('KH001', N'Nguyễn Văn An', N'Nam', '0912345678', '1990-05-21', N'123 Lê Lợi, Q.1, TP.HCM'),
('KH002', N'Trần Thị Bình', N'Nữ', '0987654321', '1992-08-15', N'45 Nguyễn Huệ, Q.1, TP.HCM'),
('KH003', N'Lê Văn Cường', N'Nam', '0934567890', '1988-02-10', N'78 Điện Biên Phủ, Q.Bình Thạnh, TP.HCM'),
('KH004', N'Phạm Thị Dung', N'Nữ', '0978123456', '1995-11-30', N'12 Hai Bà Trưng, Q.3, TP.HCM'),
('KH005', N'Hoàng Minh Đức', N'Nam', '0909988776', '1985-07-19', N'56 Trần Hưng Đạo, Q.5, TP.HCM'),
('KH006', N'Võ Thị Hạnh', N'Nữ', '0911223344', '1993-03-25', N'22 Lý Thường Kiệt, TP. Biên Hòa, Đồng Nai'),
('KH007', N'Đỗ Văn Hùng', N'Nam', '0966778899', '1987-09-09', N'99 Phan Chu Trinh, TP. Vũng Tàu, Bà Rịa-Vũng Tàu'),
('KH008', N'Nguyễn Thị Lan', N'Nữ', '0944332211', '1996-12-12', N'88 Cách Mạng Tháng 8, Q.10, TP.HCM');

-- Sản phẩm
INSERT INTO SanPham VALUES 
('8934567890130',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/M/Be Nâu',649000,N'Cái'),
('8934567890147',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/L/Be Nâu',649000,N'Cái'),
('8934567890154',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/S/Xanh Nhạt',649000,N'Cái'),
('8934567890161',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/M/Xanh Nhạt',649000,N'Cái'),
('8934567890178',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/L/Xanh Nhạt',649000,N'Cái'),
('8934567890185',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/S/Xám Đậm',649000,N'Cái'),
('8934567890192',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/M/Xám Đậm',649000,N'Cái'),
('8934567890208',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/L/Xám Đậm',649000,N'Cái'),
('8934567890215',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/S/Tím',649000,N'Cái'),
('8934567890222',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/M/Tím',649000,N'Cái'),
('8934567890239',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/L/Tím',649000,N'Cái'),
('8934567890246',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/S/Đen',649000,N'Cái'),
('8934567890253',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/M/Đen',649000,N'Cái'),
('8934567890260',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/L/Đen',649000,N'Cái'),
('8934567890277',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/S/Be',649000,N'Cái'),
('8934567890284',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/M/Be',649000,N'Cái'),
('8934567890291',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/L/Be',649000,N'Cái'),
('8934567890307',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/S/Xanh Lá',649000,N'Cái'),
('8934567890314',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/M/Xanh Lá',649000,N'Cái'),
('8934567890321',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/L/Xanh Lá',649000,N'Cái'),
('8934567890338',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/S/Xám',649000,N'Cái'),
('8934567890345',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/M/Xám',649000,N'Cái'),
('8934567890352',N'Áo Khoác Nữ Double Face Original Slogan WOK 2063/L/Xám',649000,N'Cái'),
('8936020300001',N'Áo Thun Proud To Be Vietnamese Version 02.09 MTS 1454/S/Đỏ',399000,N'Cái'),
('8936020300002',N'Áo Thun Proud To Be Vietnamese Version 02.09 MTS 1454/M/Đỏ',399000,N'Cái'),
('8936020300003',N'Áo Thun Proud To Be Vietnamese Version 02.09 MTS 1454/L/Đỏ',399000,N'Cái'),
('8936020300004',N'Áo Thun Proud To Be Vietnamese Version 02.09 MTS 1454/XL/Đỏ',399000,N'Cái'),
('893000000001',N'Áo Polo Nam By Color CTX MPO 1072/M/Trắng',449000,N'Cái'),
('893000000002',N'Áo Polo Nam By Color CTX MPO 1072/L/Trắng',449000,N'Cái'),
('893000000003',N'Áo Polo Nam By Color CTX MPO 1072/XL/Trắng',449000,N'Cái'),
('893000000004',N'Áo Polo Nam By Color CTX MPO 1072/XXL/Trắng',449000,N'Cái'),
('893000000005',N'Áo Khoác Nam Anti UV Original MOK 1064/M/Nâu Cafe',679000,N'Cái'),
('893000000006',N'Áo Khoác Nam Anti UV Original MOK 1064/L/Nâu Cafe',679000,N'Cái'),
('893000000007',N'Áo Khoác Nam Anti UV Original MOK 1064/XL/Nâu Cafe',679000,N'Cái'),
('893000000008',N'Áo Khoác Nam Anti UV Original MOK 1064/XXL/Nâu Cafe',679000,N'Cái'),
('893000000009',N'Áo Khoác Nam Anti UV Original MOK 1064/M/Xám Metal',679000,N'Cái'),
('893000000010',N'Áo Khoác Nam Anti UV Original MOK 1064/L/Xám Metal',679000,N'Cái'),
('893000000011',N'Áo Khoác Nam Anti UV Original MOK 1064/XL/Xám Metal',679000,N'Cái'),
('893000000012',N'Áo Khoác Nam Anti UV Original MOK 1064/XXL/Xám Metal',679000,N'Cái'),
('893000000013',N'Áo Khoác Nam Anti UV Original MOK 1064/M/Xanh Blue Surf',679000,N'Cái'),
('893000000014',N'Áo Khoác Nam Anti UV Original MOK 1064/L/Xanh Blue Surf',679000,N'Cái'),
('893000000015',N'Áo Khoác Nam Anti UV Original MOK 1064/XL/Xanh Blue Surf',679000,N'Cái'),
('893000000016',N'Áo Khoác Nam Anti UV Original MOK 1064/XXL/Xanh Blue Surf',679000,N'Cái'),
('893000000017',N'Áo Khoác Nam Anti UV Original MOK 1064/M/Xanh Lá Đậm',679000,N'Cái'),
('893000000018',N'Áo Khoác Nam Anti UV Original MOK 1064/L/Xanh Lá Đậm',679000,N'Cái'),
('893000000019',N'Áo Khoác Nam Anti UV Original MOK 1064/XL/Xanh Lá Đậm',679000,N'Cái'),
('893000000020',N'Áo Khoác Nam Anti UV Original MOK 1064/XXL/Xanh Lá Đậm',679000,N'Cái'),
('893000000021',N'Áo Khoác Nam Anti UV Original MOK 1064/M/Xám Xanh',679000,N'Cái'),
('893000000022',N'Áo Khoác Nam Anti UV Original MOK 1064/L/Xám Xanh',679000,N'Cái'),
('893000000023',N'Áo Khoác Nam Anti UV Original MOK 1064/XL/Xám Xanh',679000,N'Cái'),
('893000000024',N'Áo Khoác Nam Anti UV Original MOK 1064/XXL/Xám Xanh',679000,N'Cái'),
('893000000025',N'Áo Khoác Nam Anti UV Original MOK 1064/M/Xám Đậm',679000,N'Cái'),
('893000000026',N'Áo Khoác Nam Anti UV Original MOK 1064/L/Xám Đậm',679000,N'Cái'),
('893000000027',N'Áo Khoác Nam Anti UV Original MOK 1064/XL/Xám Đậm',679000,N'Cái'),
('893000000028',N'Áo Khoác Nam Anti UV Original MOK 1064/XXL/Xám Đậm',679000,N'Cái'),
('893000000029',N'Áo Thun Nữ Relax ‘Nurture Your Soul’ WTS 2434/S/Hồng Chalk',299000,N'Cái'),
('893000000030',N'Áo Thun Nữ Relax ‘Nurture Your Soul’ WTS 2434/M/Hồng Chalk',299000,N'Cái'),
('893000000031',N'Áo Thun Nữ Relax ‘Nurture Your Soul’ WTS 2434/L/Hồng Chalk',299000,N'Cái');
-- Kho
INSERT INTO Kho (MaCN, MaSP, SL) VALUES 
('Tong', '893000000001', 120),
('Tong', '893000000002', 85),
('Tong', '893000000003', 100),
('Tong', '893000000004', 65),
('Tong', '893000000005', 140),
('Tong', '893000000006', 90),
('Tong', '893000000007', 110),
('Tong', '893000000008', 75),
('Tong', '893000000009', 130),
('Tong', '893000000010', 150),
('Tong', '893000000011', 115),
('Tong', '893000000012', 60),
('Tong', '893000000013', 98),
('Tong', '893000000014', 170),
('Tong', '893000000015', 150),
('Tong', '893000000016', 105),
('Tong', '893000000017', 88),
('Tong', '893000000018', 112),
('Tong', '893000000019', 70),
('Tong', '893000000020', 125),
('Tong', '893000000021', 150),
('Tong', '893000000022', 95),
('Tong', '893000000023', 135),
('Tong', '893000000024', 100),
('Tong', '893000000025', 145),
('Tong', '893000000026', 60),
('Tong', '893000000027', 90),
('Tong', '893000000028', 155),
('Tong', '893000000029', 85),
('Tong', '893000000030', 105),
('Tong', '893000000031', 130),
('Tong', '8934567890123', 75),
('Tong', '8934567890130', 90),
('Tong', '8934567890147', 110),
('Tong', '8934567890154', 65),
('Tong', '8934567890161', 98),
('Tong', '8934567890178', 105),
('Tong', '8934567890185', 120),
('Tong', '8934567890192', 150),
('Tong', '8934567890208', 115),
('Tong', '8934567890215', 140),
('Tong', '8934567890222', 75),
('Tong', '8934567890239', 100),
('Tong', '8934567890246', 130),
('Tong', '8934567890253', 95),
('Tong', '8934567890260', 145),
('Tong', '8934567890277', 110),
('Tong', '8934567890284', 125),
('Tong', '8934567890291', 80),
('Tong', '8934567890307', 105),
('Tong', '8934567890314', 150),
('Tong', '8934567890321', 115),
('Tong', '8934567890338', 135),
('Tong', '8934567890345', 100),
('Tong', '8934567890352', 70),
('Tong', '8936020300001', 95),
('Tong', '8936020300002', 120),
('Tong', '8936020300003', 85),
('Tong', '8936020300004', 110);

-- Tài khoản
INSERT INTO TaiKhoan (TenDN, MatKhau, MaNV, QuyenHan, TrangThai)
VALUES
('QLBH',    EncryptByPassPhrase('MaHoaMatKhau',N'123456'), 'QLBH',   N'Manager', 1),
('QLAEBD', EncryptByPassPhrase('MaHoaMatKhau',N'123456'), 'QLAEBD', N'Manager', 1),
('QLDA',   EncryptByPassPhrase('MaHoaMatKhau',N'123456'), 'QLDA',   N'Manager', 1),
('QLVVN',  EncryptByPassPhrase('MaHoaMatKhau',N'123456'), 'QLVVN',  N'Manager', 1),
('QLHBT',  EncryptByPassPhrase('MaHoaMatKhau',N'123456'), 'QLHBT',  N'Manager', 1),
('QLBD',   EncryptByPassPhrase('MaHoaMatKhau',N'123456'), 'QLBD',   N'Manager', 1),
('QLTong', EncryptByPassPhrase('MaHoaMatKhau',N'123456'), 'QLTong', N'Manager', 1),
('GDCPTX', EncryptByPassPhrase('MaHoaMatKhau',N'123456'), 'GDCPTX', N'Admin',   1);
