-- Bang nhom user 1 : Admin, 2: Tac gia,3: Nguoi duyet(Phan Bien)
CREATE TABLE [Role]
(
	[RoleId] TINYINT PRIMARY KEY IDENTITY(1,1),
	[RoleName] NVARCHAR(200) NOT NULL DEFAULT '',
	[Description] NVARCHAR(3000) NOT NULL DEFAULT '',
	[IsActive] BIT NOT NULL DEFAULT 0
)
-- Nhom nguoi dung (Don vi)
CREATE TABLE GroupUser
(
	[GroupUserId] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(2000) NOT NULL DEFAULT '',
	[Description] NVARCHAR(3000) NOT NULL DEFAULT ''
)
-- Trang thai cua nhan vien
CREATE TABLE [UserStatus]
(
	[UserStatusId] TINYINT PRIMARY KEY IDENTITY(1,1),-- 1: cho duyet,2: da duoc duyet, 3: khoa- huy
	[Name] NVARCHAR(200) NOT NULL DEFAULT ''
)
-- Bang nguoi dung
CREATE TABLE [User]
(
	[UserId] BIGINT PRIMARY KEY IDENTITY(1,1),
	[UserName] VARCHAR(50) NOT NULL DEFAULT '',
	[PassWord] VARCHAR(50) NOT NULL DEFAULT '',
	[Email] VARCHAR(200) NOT NULL DEFAULT '',
	[CreateDate] DATETIME NOT NULL DEFAULT GETDATE(),
	[UserStatusId] TINYINT NOT NULL DEFAULT 1,
	[RoleId] TINYINT NOT NULL DEFAULT 1, -- Mac dinh la tac gia
	[FullName] NVARCHAR(500) DEFAULT '',
	[GroupUserId] INT NOT NULL DEFAULT 1 -- Nhom nguoi (Tuong ung voi don vi nao)
)

-- Nhom de tai (Cac so de tai)
CREATE TABLE GroupTopic
(
	[GroupTopicId] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(3000),
	[NumberTopic] INT NOT NULL DEFAULT 0,
	[ParentId] INT NOT NULL DEFAULT 0,
	[Level] TINYINT NOT NULL DEFAULT 0, -- Level cap 0 : nam, cap 1: so
	[CreateDate] DATETIME NOT NULL DEFAULT GETDATE(),
	[PublicDate] DATETIME NOT NULL DEFAULT GETDATE(),
	[GroupTopicStatus] BIT NOT NULL DEFAULT 0 -- 0 : Chua publich, 1: Da public
)
-- Trang thai xu ly cua de tai
CREATE TABLE ScientificTopicStatus
(
	[ScientificTopicStatusId] TINYINT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(200) NOT NULL DEFAULT ''
)
-- Thong tin chi tiet cua 1 de tai
CREATE TABLE ScientificTopics
(
	[ScientificTopicId] BIGINT PRIMARY KEY IDENTITY(1,1),
	[Title] NVARCHAR(3000) NOT NULL DEFAULT '',
	[Images] NVARCHAR(500) NOT NULL DEFAULT '', -- Ảnh đại diện nhỏ
	[ShortDesciption] NVARCHAR(3000) NOT NULL DEFAULT '',
	[Content] NTEXT NOT NULL DEFAULT '',
	[UserIdCreate] BIGINT NOT NULL DEFAULT 0, -- Ma nguoi tao
	[CreateDate] DATETIME NOT NULL DEFAULT GETDATE(), -- Ngay tao tin
	[UserIdUpdate] BIGINT NOT NULL DEFAULT 0, -- Nguoi duyet
	[UpdateDate] DATETIME NOT NULL DEFAULT GETDATE(),-- Ngay duyet
	[ScientificTopicStatusIdId] TINYINT NOT NULL DEFAULT 1, -- Trang thai duyet 1 : cho duyet,2: duoc duyet,3: tra lai,4: Hủy
	[GroupTopicId] INT NOT NULL DEFAULT 0, -- Ma nhom cha cua tin 
	[ToTalView] BIGINT NOT NULL DEFAULT 0, -- So luong view
	[Priority] INT NOT NULL DEFAULT 1, -- So thu tu hien thi cua tin nay trong nhom
	[NumberPage] INT NOT NULL DEFAULT 0 -- So trang trong tap chi
)

CREATE TABLE FileManager
(
	[FileManagerId] INT PRIMARY KEY IDENTITY(1,1),
	[FielPath] NVARCHAR(500) NOT NULL DEFAULT 0,-- Duong dan file
	[ScientificTopicId] BIGINT NOT NULL DEFAULT 0, -- File cua de tai nao
	[FileDate] DATETIME NOT NULL DEFAULT GETDATE(),
	[LastUpdate] DATETIME NOT NULL DEFAULT GETDATE()
)

-- Nhat ky xu ly cua mot de tai
CREATE TABLE ScientificTopicProcess
(
	[ScientificTopicProcessId] BIGINT PRIMARY KEY IDENTITY(1,1),
	[ScientificTopicId] BIGINT NOT NULL DEFAULT 0,
	[UserId] BIGINT NOT NULL DEFAULT 0, -- Ma User xu ly lien quan den ban tin nay
	[ProcessContent] NTEXT , -- Noi dung xu ly la gi
	[ProcessDate] DATETIME NOT NULL DEFAULT GETDATE()
)
-- Nhom tin (Se chia theo nhom) 1 : Introduction,2: danh cho tac gia,3: danh cho phan bien
CREATE TABLE GroupNew
(
	[GroupNewId] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(200)
)
-- Chi tiet tin
CREATE TABLE New
(
	[NewId] INT PRIMARY KEY IDENTITY(1,1),
	[GroupNewId] INT NOT NULL DEFAULT 0,
	[Title] NVARCHAR(200) NOT NULL DEFAULT '',
	[Images] NVARCHAR(500) NOT NULL DEFAULT '',
	[ShortDescription] NVARCHAR(3000) NOT NULL DEFAULT '',
	[Contetn] NTEXT NOT NULL DEFAULT '',
	[Publish] BIT NOT NULL DEFAULT 0,
	[CreateDate] DATETIME NOT NULL DEFAULT GETDATE()
)

-- Cau hinh chung cua he thong
CREATE TABLE SystemConfig
(
	[Id] TINYINT PRIMARY KEY NOT NULL DEFAULT 1,
	[Logo] NVARCHAR(3000) NOT NULL DEFAULT '',-- Duong dan logo
	[Banner] NVARCHAR(3000) NOT NULL DEFAULT '',-- Anh banner
	[Sologan] NVARCHAR(3000) NOT NULL DEFAULT '',-- Sologan cua website
	[SmtpEmailAccount] VARCHAR(200) NOT NULL DEFAULT'',-- Dia chi email lam server
	[SmtpEmailPassword] VARCHAR(200) NOT NULL DEFAULT '',-- Dia chi 
	[Introduction] NTEXT NOT NULL DEFAULT '',-- Loi noi dau
	[CompanyName] NVARCHAR(3000) NOT NULL DEFAULT '',-- Ten cong ty chu quan
	[WebsiteName] NVARCHAR(3000) NOT NULL DEFAULT '',-- Ten website Tạp chí Khoa học và Công nghệ - Đại học Đà Nẵng
	[CopyRight] NVARCHAR(3000) NOT NULL DEFAULT '', -- Thong tin ban quyen © Đại học Đà Nẵng
	[Address] NVARCHAR(3000) NOT NULL DEFAULT '', -- Dia chi lien he Địa chỉ: 41 Lê Duẩn Thành phố Đà Nẵng
	[Phone] NVARCHAR(200) NOT NULL DEFAULT '', -- SDT lien he: Điện	thoại: (0511) 3 817 788
	[Email] VARCHAR(200) NOT NULL DEFAULT '',--Email:	tapchikhcn@ud.edu.vn
	[Deverloper] NVARCHAR(200) NOT NULL DEFAULT '' -- Xây dựng và phát triển bởi Đại học Đà Nẵng; email: udn.it@ud.edu.vn
)

CREATE TABLE Sys_Function
(
	SysFunctionId INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(500) NOT NULL DEFAULT '',
	[Link] NVARCHAR(500) NOT NULL DEFAULT ''
)

CREATE TABLE RoleMapSysfunction
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	RoleId INT NOT NULL DEFAULT 0,
	SysFunctionId INT NOT NULL DEFAULT 0
)