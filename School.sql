Create database Winform

create table StudyProgram(
	IDPro int identity primary key,
	NamePro varchar(255),
	Type varchar(255)
)
go
create table Class(
	IDClass varchar(50) primary key,
	NameClass varchar(255),
	TimeSlotClass varchar(100),
	IDPro int references StudyProgram(IDPro)
)
go 
create table Subject(
	IDSub varchar(50) primary key,
	NameSub varchar(100),
	TimeSlotSub varchar(100),
	Sem varchar(50)
)
go 
create table Student(
	IDStudent varchar(50) primary key,
	NameStudent varchar(255),
	Email varchar(50),
	Phone int, 
	Address varchar(255),
	IDClass varchar(50) references Class(IDCLass) 
)
go
create table TyeOfTeacher(
	IDTypeTeacher int primary key,
	NameTypeTeahcher varchar(100)
)
go
create table Teacher(
	IDTeacher varchar(50) primary key,
	NameTeacher varchar(100),
	Phone int, 
	Email varchar(50),
	Address varchar(100),
	IDTypeTeacher int references TyeOfTeacher(IDTypeTeacher)
)
go 
create table DegreeType(
	IDDegreeType varchar(50) primary key,
	TypeName varchar(100),
	Description varchar(255)
)
go
create table Degree(
	IDDegree varchar(50) primary key,
	DegreeName varchar(100)
)
go
create table DegreeOfTeacher(
	IDDeOfTea int primary key,
	IDTeacher varchar(50) references Teacher(IDTeacher),
	IDDegree varchar(50),
	Description varchar(255)
)
go 
create table ClassSubject(
	IDClassSubject int primary key,
	StarDate datetime,
	EndDate datetime,
	TimeSlotClassSub varchar(50),
	Status varchar(50),
	IDClass varchar(50) references Class(IDClass),
	IDSub varchar(50) references Subject(IDSub)
)
go 
create table Login (
	IDUser int primary key,
	UserName varchar(50),
	PassWord varchar(50)
)
create table DegreeOfSubject(
	IDDeSub varchar(10) primary key,
	IDSub varchar(50) references Subject(IDSub),
	IDDegree varchar(50) references Degree(IDDegree)
)
create table Attendance
(
	AttID int identity(1,1) primary key,
	IDClassSubject int references ClassSubject(IDClassSubject),
	IDStudent varchar(50) references Student(IDStudent),
	[Status] int,
	[Note] nvarchar(100)
)
create table AttendanceDetails
(
	AttDetID int identity(1,1) primary key,
	AttID int references Attendance(AttID),
	[Date] date,
	LastUpdate date,
	[Status] int, 
	Others nvarchar(100)
)

--INSERT TABLE [dbo].[StudyProgram]
INSERT INTO [dbo].[StudyProgram] VALUES ('Aptech', 'Short-term')
INSERT INTO [dbo].[StudyProgram] VALUES ('Aptech', 'Long-term')
INSERT INTO [dbo].[StudyProgram] VALUES ('Arena', 'Short-term')
INSERT INTO [dbo].[StudyProgram] VALUES ('Arena', 'Long-term')
INSERT INTO [dbo].[StudyProgram] VALUES ('AI', 'Short-term')
INSERT INTO [dbo].[StudyProgram] VALUES ('AI', 'Long-term')
INSERT INTO [dbo].[StudyProgram] VALUES ('Adruino', 'Short-term')
INSERT INTO [dbo].[StudyProgram] VALUES ('Adruino', 'Long-term')

SELECT * FROM [dbo].[StudyProgram]

--INSERT TABLE [dbo].[Class]
INSERT INTO [dbo].[Class] VALUES ('CP2916G03', 'G03', '7h-9h', 1)
INSERT INTO [dbo].[Class] VALUES ('CP2916H04', 'H04', '9h-11h', 2)
INSERT INTO [dbo].[Class] VALUES ('CP2916J05', 'J05', '13h-15h', 3)
INSERT INTO [dbo].[Class] VALUES ('CP2916A06', 'A06', '15h-17h', 4)
INSERT INTO [dbo].[Class] VALUES ('CP2916B07', 'B07', '17h-19h', 5)
INSERT INTO [dbo].[Class] VALUES ('CP2916C08', 'C08', '19h-21h', 6)
INSERT INTO [dbo].[Class] VALUES ('CP2916K09', 'K09', '15h-17h', 7)
INSERT INTO [dbo].[Class] VALUES ('CP2916E02', 'E02', '17h-19h', 8)

SELECT * FROM [dbo].[Class]

--INSERT TABLE [dbo].[Subject]
INSERT INTO [dbo].[Subject] VALUES ('AP01', 'Aptech', '7h-9h', 'Sem 1')
INSERT INTO [dbo].[Subject] VALUES ('AP02', 'Aptech', '9h-11h', 'Sem 2')
INSERT INTO [dbo].[Subject] VALUES ('AP03', 'Aptech', '13h-15h', 'Sem 3')
INSERT INTO [dbo].[Subject] VALUES ('AR01', 'Arena', '7h-9h', 'Sem 1')
INSERT INTO [dbo].[Subject] VALUES ('AR02', 'Arena', '13h-15h', 'Sem 2')
INSERT INTO [dbo].[Subject] VALUES ('AR03', 'Arena', '17h-19h', 'Sem 3')
INSERT INTO [dbo].[Subject] VALUES ('AI01', 'AI', '13h-15h', 'Sem 1')
INSERT INTO [dbo].[Subject] VALUES ('AI02', 'AI', '7h-9h', 'Sem 2')
INSERT INTO [dbo].[Subject] VALUES ('AI03', 'AI', '19h-21h', 'Sem 3')
INSERT INTO [dbo].[Subject] VALUES ('AD01', 'Adruino', '9h-11h', 'Sem 1')
INSERT INTO [dbo].[Subject] VALUES ('AD02', 'Adruino', '17h-19h', 'Sem 2')
INSERT INTO [dbo].[Subject] VALUES ('AD03', 'Adruino', '7h-9h', 'Sem 3')

SELECT * FROM [dbo].[Subject]

--INSERT TABLE [dbo].[Student]
INSERT INTO [dbo].[Student] VALUES ('A19049', 'Huynh Cong Duy', 'hcduya19049@cusc.ctu.edu.vn', 0915000000, 'So 1 LTT', 'CP2916G03')
INSERT INTO [dbo].[Student] VALUES ('A19065', 'Tran Thi Dieu My', 'ttdmya19065@cusc.ctu.edu.vn', 0939000000, 'So 1 LTT', 'CP2916G03')
INSERT INTO [dbo].[Student] VALUES ('A19037', 'Nguyen Phuc Hau', 'nphaua19037@cusc.ctu.edu.vn', 0918000000, 'So 1 LTT', 'CP2916H04')
INSERT INTO [dbo].[Student] VALUES ('A19040', 'Bui Quoc Toan', 'bqtoana1940@cusc.ctu.edu.vn', 0918000000, 'So 1 LTT', 'CP2916E02')
INSERT INTO [dbo].[Student] VALUES ('A19071', 'Dang Thanh Phi', 'dtphia19071@cusc.ctu.edu.vn', 0918000000, 'So 1 LTT', 'CP2916G03')
INSERT INTO [dbo].[Student] VALUES ('A19059', 'Nguyen Duc Hiep Dinh', 'ndhdinha19059@cusc.ctu.edu.vn', 0918000000, 'So 1 LTT', 'CP2916G03')
INSERT INTO [dbo].[Student] VALUES ('A19047', 'Tran Thi Minh Thu', 'ttmthua19047@cusc.ctu.edu.vn', 0918000000, 'So 1 LTT', 'CP2916C08')
INSERT INTO [dbo].[Student] VALUES ('A19038', 'Le Duc Thinh', 'ldthinha19038@cusc.ctu.edu.vn', 0918000000, 'So 1 LTT', 'CP2916J05')
INSERT INTO [dbo].[Student] VALUES ('A19061', 'Le Dinh Qui', 'ldquia19061@cusc.ctu.edu.vn', 0918000000, 'So 1 LTT', 'CP2916G03')

SELECT * FROM [dbo].[Student]

--INSERT [dbo].[TyeOfTeacher]
INSERT INTO [dbo].[TyeOfTeacher] VALUES (001, 'Professional Teaching')
INSERT INTO [dbo].[TyeOfTeacher] VALUES (002, 'Teach secondary subjects')

SELECT * FROM [dbo].[TyeOfTeacher]

--INSERT TABLE [dbo].[Teacher]
INSERT INTO [dbo].[Teacher] VALUES ('OTML01', 'Ong Thi My Linh', 0915000000, 'otmlinh@ctu.edu.vn', 'So 1 LTT', 001)
INSERT INTO [dbo].[Teacher] VALUES ('LTML02', 'Le Thi Minh Loan', 0915000000, 'ltmloan@ctu.edu.vn', 'So 1 LTT', 001)
INSERT INTO [dbo].[Teacher] VALUES ('LTD03', 'Luu Tien Dao', 0915000000, 'ltdao@ctu.edu.vn', 'So 1 LTT', 002)
INSERT INTO [dbo].[Teacher] VALUES ('TXV04', 'Truong Xuan Viet', 0915000000, 'txvieth@ctu.edu.vn', 'So 1 LTT', 001)

SELECT * FROM [dbo].[Teacher]

--INSER TABLE [dbo].[DegreeType]
INSERT INTO [dbo].[DegreeType] VALUES ('XS01', 'Xuat sac', '')
INSERT INTO [dbo].[DegreeType] VALUES ('GI02', 'Gioi', '')
INSERT INTO [dbo].[DegreeType] VALUES ('KH03', 'Kha', '')

SELECT * FROM [dbo].[DegreeType]

--INSERT TABLE [dbo].[Degree]
INSERT INTO [dbo].[Degree] VALUES ('THS01', 'Thac si')
INSERT INTO [dbo].[Degree] VALUES ('TS02', 'Tien si')
INSERT INTO [dbo].[Degree] VALUES ('CH03', 'Cao hoc')

SELECT * FROM [dbo].[Degree]

--INSERT TABLE [dbo].[DegreeOfTeacher]
INSERT INTO [dbo].[DegreeOfTeacher] VALUES (0101, 'OTML01', 'THS01', '')
INSERT INTO [dbo].[DegreeOfTeacher] VALUES (0202, 'LTML02', 'THS01', '')
INSERT INTO [dbo].[DegreeOfTeacher] VALUES (0303, 'LTD03', 'THS01', '')
INSERT INTO [dbo].[DegreeOfTeacher] VALUES (0404, 'TXV04', 'THS01', '')

SELECT * FROM [dbo].[DegreeOfTeacher]

--INSERT TABLE [dbo].[ClassSubject]
INSERT INTO [dbo].[ClassSubject] VALUES (1001, '2022/02/10', '2022/03/10', '1 thang', 'dang hoc', 'CP2916G03', 'AP01')
INSERT INTO [dbo].[ClassSubject] VALUES (2002, '2022/02/10', '2022/03/10', '1 thang', 'chua hoc', 'CP2916J05', 'AD03')
INSERT INTO [dbo].[ClassSubject] VALUES (3003, '2022/02/10', '2022/03/10', '1 thang', 'dang hoc', 'CP2916H04', 'AR01')
INSERT INTO [dbo].[ClassSubject] VALUES (4004, '2022/02/10', '2022/03/10', '1 thang', 'chua hoc', 'CP2916E02', 'AI02')
INSERT INTO [dbo].[ClassSubject] VALUES (5005, '2022/02/10', '2022/03/10', '1 thang', 'chua hoc', 'CP2916E02', 'AI02')
INSERT INTO [dbo].[ClassSubject] VALUES (6006, '2022/02/10', '2022/03/10', '1 thang', 'chua hoc', 'CP2916E02', 'AI02')

SELECT * FROM [dbo].[ClassSubject]

--INSERT TABLE [dbo].[Login]
INSERT INTO [dbo].[Login] VALUES (1201, 'admin', 'admin123')

SELECT * FROM [dbo].[Login]

--INSERT TABLE [dbo].[DegreeOfSubject]
INSERT INTO [dbo].[DegreeOfSubject] VALUES ('APHD01', 'AP01', 'THS01')
INSERT INTO [dbo].[DegreeOfSubject] VALUES ('ARAH01', 'AR01', 'THS01')

SELECT * FROM [dbo].[DegreeOfSubject]

--INSERT TABLE [dbo].[Attendance]
INSERT INTO [dbo].[Attendance] VALUES (1001, 'A19049', 1, '')
INSERT INTO [dbo].[Attendance] VALUES (1001, 'A19061', 0, '')

SELECT * FROM [dbo].[Attendance]

--INSERT TABLE [dbo].[AttendanceDetails]
INSERT INTO [dbo].[AttendanceDetails] VALUES (2, '2022/02/10', '2022/02/10', 1, '')

SELECT * FROM [dbo].[AttendanceDetails]