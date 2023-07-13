Create Database ShopShoes

CREATE TABLE LoaiSanPham(
MaLoai	INT IDENTITY(1,1),
TenLoai	nvarchar(100)	,
GhiChu	nvarchar(3000)	
	PRIMARY KEY(MaLoai),
);
CREATE TABLE TinTuc(
ID	INT IDENTITY(1,1),
TieuDe	nvarchar(2000),
NgayThang	date,
GhiChu	nvarchar(3000)	
	PRIMARY KEY(ID),
);
CREATE TABLE NhaCungCap(
MaNCC	INT IDENTITY(1,1),
TenNCC	nvarchar(50),
DiaChi	nvarchar(500),
SoDT	nvarchar(50)
	PRIMARY KEY(MaNCC),
);
CREATE TABLE ADmin(
UserName	nvarchar(50),
PassWord	int
	PRIMARY KEY(UserName),
);


CREATE TABLE KhachHang(
	Username	nvarchar(80),
	AnhDaiDien varchar(500) NULL,
	DiaChi	nvarchar(500),
	Email	nvarchar(50),
	SoDT	int NOT NULL,
	MatKhau nvarchar(50),
	GioiTinh nvarchar(20) NULL,
	TrangThai	bit,
	GroupID	nvarchar(500),
	PostCode	int,
	PRIMARY KEY(Username),
	UNIQUE(PostCode)
);

CREATE TABLE SanPham(
	MaSP INT IDENTITY(1,1),
	HinhAnh	nvarchar(200),
	MaLoai INT,
	TenSP NVARCHAR(500) NOT NULL,
	MauSac	nvarchar(500),
	DonGia FLOAT NOT NULL,
	GiaSale FLOAT NOT NULL,
	GhiChu	nvarchar(4000),
	SoLuong	int NOT NULL,
	KichThuoc	nvarchar(500)
	PRIMARY KEY(MaSP),
	FOREIGN KEY (MaLoai) REFERENCES LoaiSanPham(MaLoai) ON DELETE CASCADE ON UPDATE CASCADE,
	CHECK(GiaSale >= 0)
);

CREATE TABLE DanhMuc(
	MaDanhMuc INT IDENTITY(1,1),
	STT int null,
	TenDanhMuc	nvarchar(250),
	TrangThai	bit
	PRIMARY KEY(MaDanhMuc)
);

CREATE TABLE NhanVien(
	MaNhanVien INT IDENTITY(1,1),
	TenDanhMuc	nvarchar(250),
	Email	nvarchar(250) null,
	SoDT	nvarchar(10) null,
	DiaChi	nvarchar(250) null
	PRIMARY KEY(MaNhanVien)
);

CREATE TABLE HoaDonNhap(
	MaHDN INT IDENTITY(1,1),
	MaNCC INT,
	NgayDat	date NOT NULL,
	SDT	nvarchar(50),
	DiaChi	nvarchar(500),
	TrangThai	bit,
	GhiChu	nvarchar(50),
	PRIMARY KEY(MaHDN),
	FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE CT_HoaDonNhap(
	MaCTHDN INT IDENTITY(1,1),
	MaHDN	int NOT NULL,
	MaSP	int NOT NULL,
	SoLuong	int,
	DonGia FLOAT NOT NULL,
	TongTien FLOAT NOT NULL,
	PRIMARY KEY(MaCTHDN),
	FOREIGN KEY (MaHDN) REFERENCES HoaDonNhap(MaHDN) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE HoaDonBan(
	MaHDB INT IDENTITY(1,1),
	Username	nvarchar(80),
	NgayDat	date NOT NULL,
	SDT	nvarchar(50),
	DiaChi	nvarchar(500),
	TrangThai	bit,
	GhiChu	nvarchar(500),
	PRIMARY KEY(MaHDB),
	FOREIGN KEY (Username) REFERENCES KhachHang(Username) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE CT_HoaDonBan(
	MaCTHDB INT IDENTITY(1,1),
	MaHDB	int,
	MaSP	int,
	SoLuong	int,
	DonGia FLOAT NOT NULL,
	PRIMARY KEY(MaCTHDB),
	FOREIGN KEY (MaHDB) REFERENCES HoaDonBan(MaHDB) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP) ON DELETE CASCADE ON UPDATE CASCADE,
	CHECK(DonGia >= 0)
);

CREATE TABLE Menu(
	MaMenu INT IDENTITY(1,1),
	TenMenu	nvarchar(500),
	TrangThai	bit,
	PRIMARY KEY(MaMenu)
);
CREATE TABLE Silde(
	MaSilde INT IDENTITY(1,1),
	AnhSilde	nvarchar(200),
	LinkSilde	nvarchar(500),
	TrangThai	bit
	PRIMARY KEY(MaSilde)
);

CREATE TABLE LienHe(
	MaLH INT IDENTITY(1,1),
	TenLH	nvarchar(200),
	Mota	nvarchar(500),
	TrangThai	bit
	PRIMARY KEY(MaLH)
);

-- Insert LoaiSanPham
INSERT INTO LoaiSanPham(TenLoai, GhiChu)
VALUES ( 'Giày đi bộ', N'Cách chọn giày thể thao đối với người thích đi bộ là nên tìm một đôi giày nhẹ. Đôi giày đó cũng cần có thêm khả năng giảm sốc ở gót chân và bàn chân để giảm đau và căng cơ. Những đôi giày có phần đế hơi tròn sẽ giúp chuyển trọng lượng nhẹ nhàng hơn từ gót chân đến ngón chân. Giày đi bộ cũng có phần cứng hơn ở phía trước để người tập có thể cuộn các ngón chân thay vì uốn cong như như đi giày chạy bộ.'),
	('Giày tennis', N'Khi chơi quần vợt, người chơi thực hiện rất nhiều chuyển động nhanh từ bên này sang bên kia của sân thể thao. Muốn vậy, người chơi cần những đôi giày vừa hỗ trợ bên trong vừa hỗ trợ bên ngoài bàn chân. Đồng thời, đôi giày cần linh hoạt ở phần đế để có thể chuyển động nhanh về phía trước. Khi chơi tennis trên sân mềm, người chơi nên chọn đôi giày có đế mềm. Còn khi chơi trên sân cứng, người chơi nên chọn đôi giày có đế nhiều gai.'),
	( 'Giày tập luyện đa năng', N'Đôi giày này là một lựa chọn tốt nếu người chơi thích nhiều loại hình thể thao khác nhau. Vì vậy, người chơi có thể chọn đôi giày thiết kế linh hoạt ở bàn chân trước nếu muốn chạy bộ và có hỗ trợ cả 2 bên chân nếu muốn chơi tennis hoặc tập aerobic.'),
	( 'Giày chạy địa hình', N'Với những người thích chạy bộ địa hình thì những đôi giày có thể chống chọi với bùn, đất, nước và đá chính là lựa chọn không thể thiếu. Loại giày này có gai đế to hơn so với giày chạy bộ truyền thống. Chúng cũng có thêm phần hỗ trợ ở gót chân và 2 bên để giữ an toàn cho người tập khi chạy trên các bề mặt không bằng phẳng.'),
	( 'Giày bóng rổ', N'Loại giày này có đế dày và cứng, giúp người tập vững chắc hơn khi chạy lên và xuống sân. Giày có phần trên cao, hỗ trợ mắt cá chân khi thay đổi hướng nhanh chóng hoặc khi nhảy lên và tiếp đất, tránh chấn thương.')

	
-- Insert SanPham
INSERT INTO SanPham(HinhAnh, MaLoai, TenSP, MauSac, DonGia, GiaSale, GhiChu, SoLuong, KichThuoc)
VALUES ('/UploadedFiles/files/nb2.jpg', 1002, 'NB Fresh Foam X 1080v12', 'White with black', 19990, 2555000, N'Nếu chúng tôi chỉ sản xuất một chiếc giày chạy bộ, thì chiếc giày đó sẽ là chiếc 1080. Điều khiến chiếc 1080 trở nên độc đáo không chỉ là nó là chiếc giày chạy bộ tốt nhất mà chúng tôi tạo ra, mà còn là chiếc giày linh hoạt nhất. 1080 mang lại hiệu suất hàng đầu cho mọi loại vận động viên, cho dù bạn đang tập luyện cho cuộc thi đẳng cấp thế giới hay bắt một chuyến tàu vào giờ cao điểm. Fresh Foam X 1080v12 đại diện cho sự phát triển nhất quán về chất lượng đặc trưng của mô hình. Sự chuyển đổi mượt mà của trải nghiệm đệm dưới chân đỉnh cao được tinh chỉnh với cách sắp xếp đế giữa được cập nhật, áp dụng nhiều bọt hơn cho các khu vực rộng hơn của đế giữa và tăng tính linh hoạt ở các điểm hẹp hơn. Viễn cảnh cực kỳ hiện đại cũng được phản ánh trong phần trên của 1080. v12 cung cấp một phong cách da thứ hai hỗ trợ phù hợp với mặt trên Hypoknit được thiết kế kỹ thuật, cho một thiết kế tổng thể hợp lý hơn.', 43, '8UK'),
('/UploadedFiles/files/nb3.jpg', 1003, 'NB Fresh Foam X More v4', 'White with electric teal', 29990, 1965000, N'Loại Fresh Foam được sử dụng nhiều nhất trong bất kỳ loại giày nào cho đến nay, dòng sản phẩm mới nhất sử dụng nhiều Fresh Foam X hơn, xếp nó cao hơn bao giờ hết và phân bổ nó dọc theo chiều dài của giày, mang lại trải nghiệm êm ái nhưng ổn định dưới chân. Đế ngoài điều khiển bằng dữ liệu áp dụng vị trí chiến lược của các vùng đệm ấn tượng và các vùng uốn cong quyết liệt thúc đẩy sải chân tự nhiên trong khi cấu hình bập bênh của hình bóng thúc đẩy quá trình chuyển đổi và di chuyển suôn sẻ. Tất cả những thứ này nằm bên dưới lớp lưới được thiết kế phía trên giúp bạn luôn cố định với sự thoải mái và hỗ trợ thoáng khí. ', 63, '4.5UK'),
('/UploadedFiles/files/nb4.jpg', 1004, 'NB 574 Core', 'Grey with white', 49990, 2999000, N'Nếu chúng tôi chỉ sản xuất một chiếc giày chạy bộ, thì chiếc giày đó sẽ là chiếc 1080. Điều khiến chiếc 1080 trở nên độc đáo không chỉ là nó là chiếc giày chạy bộ tốt nhất mà chúng tôi tạo ra, mà còn là chiếc giày linh hoạt nhất. 1080 mang lại hiệu suất hàng đầu cho mọi loại vận động viên, cho dù bạn đang tập luyện cho cuộc thi đẳng cấp thế giới hay bắt một chuyến tàu vào giờ cao điểm. Fresh Foam X 1080v12 đại diện cho sự phát triển nhất quán về chất lượng đặc trưng của mô hình. Sự chuyển đổi mượt mà của trải nghiệm đệm dưới chân đỉnh cao được tinh chỉnh với cách sắp xếp đế giữa được cập nhật, áp dụng nhiều bọt hơn cho các khu vực rộng hơn của đế giữa và tăng tính linh hoạt ở các điểm hẹp hơn. Viễn cảnh cực kỳ hiện đại cũng được phản ánh trong phần trên của 1080. v12 cung cấp một phong cách da thứ hai hỗ trợ phù hợp với mặt trên Hypoknit được thiết kế kỹ thuật, cho một thiết kế tổng thể hợp lý hơn.', 193, '8.5UK')

-- Insert SanPham
INSERT INTO KhachHang(Username, DiaChi, Email, SoDT, MatKhau, TrangThai, GroupID, PostCode)
VALUES ('vancong14', N'Hưng Yên', 'cọnkoi090@gmail.com', 0334624356, '123Cong', '', 'MEMBER',2002)

