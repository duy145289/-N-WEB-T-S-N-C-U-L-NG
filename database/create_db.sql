
-- BadmintonBooking: Schema & seed
IF DB_ID('BadmintonBooking') IS NULL
BEGIN
    CREATE DATABASE BadmintonBooking;
END
GO
USE BadmintonBooking;
GO

IF OBJECT_ID('dbo.CauLacBo','U') IS NULL
CREATE TABLE dbo.CauLacBo
(
    Id INT PRIMARY KEY,
    TenCLB NVARCHAR(200) NOT NULL,
    DiaChi NVARCHAR(300) NULL,
    GioMoCua NVARCHAR(10) NULL,
    GioDongCua NVARCHAR(10) NULL
);
GO

IF OBJECT_ID('dbo.San','U') IS NULL
CREATE TABLE dbo.San
(
    Id INT PRIMARY KEY,
    CLBId INT NOT NULL,
    TenSan NVARCHAR(100) NOT NULL,
    TrangThai NVARCHAR(50) NULL,
    CONSTRAINT FK_San_CLB FOREIGN KEY (CLBId) REFERENCES dbo.CauLacBo(Id)
);
GO

IF OBJECT_ID('dbo.NguoiDung','U') IS NULL
CREATE TABLE dbo.NguoiDung
(
    Id INT PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    Email NVARCHAR(200) NOT NULL,
    MatKhau NVARCHAR(100) NOT NULL,
    LaAdmin BIT NOT NULL DEFAULT 0
);
GO

IF OBJECT_ID('dbo.DatSan','U') IS NULL
CREATE TABLE dbo.DatSan
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NguoiDungId INT NOT NULL,
    SanId INT NOT NULL,
    Ngay DATE NOT NULL,
    GioBatDau NVARCHAR(5) NOT NULL,
    SoGio INT NOT NULL,
    GiaGio INT NOT NULL,
    CONSTRAINT FK_DatSan_NguoiDung FOREIGN KEY (NguoiDungId) REFERENCES dbo.NguoiDung(Id),
    CONSTRAINT FK_DatSan_San FOREIGN KEY (SanId) REFERENCES dbo.San(Id)
);
GO

IF OBJECT_ID('dbo.ThanhToan','U') IS NULL
CREATE TABLE dbo.ThanhToan
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DatSanId INT NOT NULL,
    TongTien INT NOT NULL,
    NgayThanhToan DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_ThanhToan_DatSan FOREIGN KEY (DatSanId) REFERENCES dbo.DatSan(Id)
);
GO

-- Seed
IF NOT EXISTS(SELECT 1 FROM dbo.CauLacBo WHERE Id=1)
INSERT INTO dbo.CauLacBo(Id,TenCLB,DiaChi,GioMoCua,GioDongCua) VALUES
(1,N'CLB Cầu Lông TPT Sport',N'Q1, TP.HCM',N'06:00',N'23:00'),
(2,N'NESTWORLD BADMINTON',N'TP Thủ Đức',N'05:00',N'24:00'),
(3,N'Sân Bóng Tân Hòa',N'Tân Phú',N'05:00',N'24:00'),
(4,N'CLB Nguyễn Du',N'Q1, TP.HCM',N'06:00',N'22:00'),
(5,N'Hutech Badminton',N'Bình Thạnh',N'06:00',N'23:00'),
(6,N'CLB Thống Nhất',N'Tân Bình',N'05:30',N'22:30'),
(7,N'CLB Vạn Phúc',N'Thủ Đức',N'06:00',N'23:00'),
(8,N'CLB Phú Thọ',N'Q11',N'06:00',N'22:00'),
(9,N'CLB Quân Khu 7',N'Tân Bình',N'05:00',N'23:00'),
(10,N'CLB Him Lam',N'Q7',N'06:00',N'23:00');

IF NOT EXISTS(SELECT 1 FROM dbo.San WHERE Id=1)
INSERT INTO dbo.San(Id,CLBId,TenSan,TrangThai) VALUES
(1,1,N'Sân 1',N'Hoạt động'),
(2,1,N'Sân 2',N'Hoạt động'),
(3,2,N'Sân 1',N'Hoạt động'),
(4,2,N'Sân 2',N'Hoạt động'),
(5,3,N'Sân 1',N'Hoạt động'),
(6,4,N'Sân 1',N'Hoạt động'),
(7,4,N'Sân 2',N'Hoạt động'),
(8,5,N'Sân 1',N'Hoạt động'),
(9,6,N'Sân 1',N'Hoạt động'),
(10,7,N'Sân 1',N'Hoạt động'),
(11,8,N'Sân 1',N'Hoạt động'),
(12,9,N'Sân 1',N'Hoạt động'),
(13,10,N'Sân 1',N'Hoạt động');

IF NOT EXISTS(SELECT 1 FROM dbo.NguoiDung WHERE Id=1)
INSERT INTO dbo.NguoiDung(Id,HoTen,Email,MatKhau,LaAdmin) VALUES
(1,N'Quản trị viên','admin@badminton.local','123456',1),
(2,N'Khách A','user@badminton.local','123456',0);
GO
