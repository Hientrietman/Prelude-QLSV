

CREATE TABLE TAIKHOAN(
	ID INT PRIMARY KEY IDENTITY(1,1),
	Tentaikhoan NVARCHAR(100) NOT NULL,
	Matkhau NVARCHAR(100) NOT NULL DEFAULT 123,
	Tennguoidung NVARCHAR(100) NOT NULL,
	Loaitaikhoan INT NOT NULL,	--0: STAFF; 1: ADMIN; 2: ....
)
GO

CREATE TABLE LOAITIETKIEM(
	Maloaitietkiem int primary key IDENTITY(1,1),
	Tenloaitietkiem nvarchar (50),
	Laisuat float,
	Kyhan int,
	Songayduocrut int,
	Duocguithem bit,
	Sotienguitoithieu int DEFAULT 100000,
	Tienguithemtoithieu int,
)
GO

CREATE TABLE SOTIETKIEM(
	
	Masotietkiem int PRIMARY KEY IDENTITY(1,1),

	Maloaitietkiem int,

	Tenkhachhang nvarchar (50),
	CCCD nvarchar (12),
	Diachi nvarchar (250),
	Ngaymoso datetime,
	Ngaydongso datetime,
	Sotienguibandau int,
	Sodu int,
	
)
GO

ALTER TABLE SOTIETKIEM ADD
	FOREIGN KEY (Maloaitietkiem) REFERENCES LOAITIETKIEM(Maloaitietkiem)

GO

CREATE TABLE PHIEURUTTIEN(
	Maphieuruttien INT PRIMARY KEY IDENTITY(1,1), 
	Masotietkiem INT,
	Sotienrut INT,
	Ngayrut datetime,
)
GO

ALTER TABLE PHIEURUTTIEN ADD
	FOREIGN KEY (Masotietkiem)	REFERENCES SOTIETKIEM(Masotietkiem)
GO

CREATE TABLE PHIEUGUITIEN(
	Maphieuguitien INT PRIMARY KEY IDENTITY(1,1), 
	Masotietkiem INT,
	Sotiengui INT,
	Ngaygui datetime,
)
GO

ALTER TABLE PHIEUGUITIEN ADD
	FOREIGN KEY (Masotietkiem)	REFERENCES SOTIETKIEM(Masotietkiem)
go

---------------------------------INSERT--------------------------------------------
INSERT INTO TAIKHOAN(Tentaikhoan, Matkhau, Tennguoidung, Loaitaikhoan) VALUES
(N'admin1','123', N'HoangNM', 1),
(N'admin2','123', N'NguyenHM', 1),
(N'staff1','123', N'MinhNH', 0),
(N'staff2','123', N'staff2', 0),
(N'staff3','123', N'staff3', 0),
(N'staff4','123', N'staff4', 0),
(N'User Name','Password', N'staff4', 0)
GO

INSERT INTO LOAITIETKIEM(Tenloaitietkiem, Laisuat, Kyhan, Songayduocrut, Duocguithem, Sotienguitoithieu, Tienguithemtoithieu) VALUES
(N'Không kỳ hạn', 0.15, null, 0, 15, 100000, 100000),
(N'3 tháng', 0.5, 90, 91, 0, 100000, null),
(N'6 tháng', 0.55, 180, 181, 0, 100000, null)
GO

INSERT INTO SOTIETKIEM(Maloaitietkiem, Tenkhachhang, CCCD, Diachi, Ngaymoso,Ngaydongso, Sotienguibandau, Sodu) VALUES
(1, N'Nguyễn Minh Hoàng', '111111111111', N'Phường Núi Sam', '2023-03-30',NULL, 10000000,10000000),
(2, N'Hoàng Nguyễn Minh', '222222222222', N'TP.Châu Đốc', '2023-03-1', NULL,10000000,10000000),
(3, N'Nguyễn Hoàng Minh', '333333333333', N'Tỉnh An Giang', '2023-03-2',NULL, 10000000,10000000)
GO
select * from SOTIETKIEM




  

INSERT INTO PHIEURUTTIEN(Masotietkiem, Sotienrut, Ngayrut) VALUES
(1, 2000000, '2023-04-5'),
(1, 3000000, '2023-04-8')
GO

INSERT INTO PHIEUGUITIEN(Masotietkiem, Sotiengui, Ngaygui) VALUES
(1, 2000000, '2023-04-20'),
(1, 3000000, '2023-04-25')
GO

----------------------------------Store Procedure, trigger, function-----------------------------------
CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS
BEGIN
	SELECT * 
	FROM TAIKHOAN
	WHERE Tentaikhoan = @userName
END
GO

CREATE PROC AccountLogin
	@userName nvarchar(100),
	@passWord nvarchar(100)
AS
BEGIN
	SELECT * 
	FROM TAIKHOAN
	WHERE Tentaikhoan = @userName and Matkhau = @passWord
END
GO
CREATE PROCEDURE them_thongtin_sotietkiem
(
    @Maloaitietkiem int,
    @Tenkhachhang varchar(50),
    @CCCD varchar(12),
    @Diachi varchar(250),
    @Ngaymoso date,
    @Sotienguibandau int,
    @Sodu int
    
)
AS
BEGIN
    INSERT INTO SOTIETKIEM (Maloaitietkiem, Tenkhachhang, CCCD, Diachi, Ngaymoso, Sotienguibandau, Sodu)
    VALUES (@Maloaitietkiem, @Tenkhachhang, @CCCD, @Diachi, @Ngaymoso, @Sotienguibandau, @Sodu)
END
GO
CREATE PROCEDURE them_thongtin_sotietkiem2
(
    @Maloaitietkiem int,
    @Tenkhachhang varchar(50),
    @CCCD varchar(12),
    @Diachi varchar(250),
    @Ngaymoso date,

    @Sotienguibandau int,
    @Sodu int,
    @Ngaydongso date
)
AS
BEGIN
    INSERT INTO SOTIETKIEM (Maloaitietkiem, Tenkhachhang, CCCD, Diachi, Ngaymoso, Sotienguibandau, Sodu, Ngaydongso)
    VALUES (@Maloaitietkiem, @Tenkhachhang, @CCCD, @Diachi, @Ngaymoso, @Sotienguibandau, @Sodu, @Ngaydongso)
END

GO
CREATE PROCEDURE GetSOTIETKIEMByMonthYearAndMaloaitietkiem
    @Month INT,
    @Year INT,
    @Maloaitietkiem INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CONVERT(nvarchar(10), Ngaymoso, 103) AS Ngay,
        COUNT(*) AS SoSoMo,
        SUM(CASE WHEN MONTH(Ngaydongso) = @Month THEN 1 ELSE 0 END) AS SoSoDong,
        COUNT(*) - SUM(CASE WHEN MONTH(Ngaydongso) = @Month THEN 1 ELSE 0 END) AS ChenhLechSoLuong
    FROM 
        SOTIETKIEM
    WHERE 
        MONTH(Ngaymoso) = @Month
        AND YEAR(Ngaymoso) = @Year
        AND Maloaitietkiem = @Maloaitietkiem
    GROUP BY 
        CONVERT(nvarchar(10), Ngaymoso, 103)
    ORDER BY 
        CONVERT(nvarchar(10), Ngaymoso, 103)

END

CREATE PROCEDURE XoaLoaiTietKiem
    @MaLoaiTietKiem int
AS
BEGIN
    DELETE FROM LOAITIETKIEM WHERE MaLoaiTietKiem = @MaLoaiTietKiem
END
//
CREATE PROCEDURE UpdateSoDu
    @Masotietkiem int,
    @SoDuMoi int
AS
BEGIN
    UPDATE SOTIETKIEM
    SET Sodu = Sodu + @SoDuMoi
    WHERE Masotietkiem = @Masotietkiem
END

CREATE PROCEDURE UpdateLoaiTietKiemWithoutSoTietKiem
    @Maloaitietkiem INT,
    @Songayduocrut INT,
    @Laisuat FLOAT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM SOTIETKIEM
        WHERE Maloaitietkiem = @Maloaitietkiem
            AND Ngaydongso IS NULL
    )
    BEGIN
        UPDATE LOAITIETKIEM
        SET Songayduocrut = @Songayduocrut,
            Laisuat = @Laisuat,
			Kyhan = @Songayduocrut-1
        WHERE Maloaitietkiem = @Maloaitietkiem;
    END
END;

----------------------------------TEST-----------------------------------
Select * from TAIKHOAN 
select * from LOAITIETKIEM
select * from SOTIETKIEM
select * from PHIEUGUITIEN
select * from PHIEURUTTIEN
insert into PHIEUGUITIEN(Masotietkiem,Sotiengui) values (9,11111)
SELECT name, type_desc
FROM sys.procedures;
EXEC them_thongtin_sotietkiem2
    @Maloaitietkiem = 1,
    @Tenkhachhang = 'Nguyen Van A',
    @CCCD = '123456789012',
    @Diachi = '123 Đường ABC',
    @Ngaymoso = '2023-05-05',
    @Sotienguibandau = 1000000,
    @Sodu = 1000000,
    @Ngaydongso = '2023-05-06'
EXEC XoaLoaiTietKiem 5

select * from LOAITIETKIEM
