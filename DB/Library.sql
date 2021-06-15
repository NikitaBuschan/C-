-- ������� ���� ������

IF DB_ID('Library') IS NOT NULL
BEGIN
	USE master
    ALTER DATABASE Library SET single_user with rollback immediate;
    DROP DATABASE Library;
END
GO

CREATE DATABASE Library;
GO


-- ������ ��������� ���� ������ �������

USE Library
GO


-- ������� �������

-- 
-- Book Staff
-- 

CREATE TABLE Authors
(
	Id int NOT NULL PRIMARY KEY,
	FirstName varchar(25),
	LastName varchar(50)
)
GO

CREATE TABLE Themes
(
	Id int NOT NULL PRIMARY KEY,
	Name varchar(30)
)
GO

CREATE TABLE Presses
(
	Id int NOT NULL PRIMARY KEY,
	Name varchar(30)
)
GO

CREATE TABLE Categories
(
	Id int NOT NULL PRIMARY KEY,
	Name varchar(30)
)
GO

CREATE TABLE Books
(
	Id int NOT NULL PRIMARY KEY,
	Name varchar(100),
	Pages int,
	YearPress int,
	ThemeFk int,
	CategoryFk int,
	AuthorFk int,
	PressFk int,
	Comment varchar(50),
	Quantity int,

	FOREIGN KEY (ThemeFk) REFERENCES Themes(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	FOREIGN KEY (CategoryFk) REFERENCES Categories(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	FOREIGN KEY (AuthorFk) REFERENCES Authors(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	FOREIGN KEY (PressFk) REFERENCES Presses(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)
GO


-- 
-- Teacher Stuff
-- 

CREATE TABLE Departments
(
	Id int NOT NULL PRIMARY KEY,
	Name varchar(40)
)
GO

CREATE TABLE Teachers
(
	Id int NOT NULL PRIMARY KEY,
	FirstName varchar(25),
	LastName varchar(35),
	DepartmentFk int,

	FOREIGN KEY (DepartmentFk) REFERENCES Departments(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)
GO



-- 
-- Student Staff
-- 

CREATE TABLE Faculties
(
	Id int NOT NULL PRIMARY KEY,
	Name varchar(20)
)
GO

CREATE TABLE Groups
(
	Id int NOT NULL PRIMARY KEY,
	Name varchar(10),
	FacultyFk int,

	FOREIGN KEY (FacultyFk) REFERENCES Faculties(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)
GO

CREATE TABLE Students
(
	Id int NOT NULL PRIMARY KEY,
	FirstName varchar(25),
	LastName varchar(35),
	GroupFk int,
	Term int,

	FOREIGN KEY (GroupFk) REFERENCES Groups(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)
GO


-- 
-- Library Stuff
-- 

CREATE TABLE Libs
(
	Id int NOT NULL PRIMARY KEY,
	FirstName varchar(25),
	LastName varchar(35)
)
GO

CREATE TABLE StudentCards
(
	Id int NOT NULL PRIMARY KEY,
	StudentFk int NOT NULL,
	BookFk int NOT NULL,
	DateOut date,
	DateIn date,
	LibFk int NOT NULL,

	FOREIGN KEY (StudentFk) REFERENCES Students(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	FOREIGN KEY (BookFk) REFERENCES Books(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	FOREIGN KEY (LibFk) REFERENCES Libs(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)
GO

CREATE TABLE TeacherCards
(
	Id int NOT NULL PRIMARY KEY,
	TeacherFk int NOT NULL,
	BookFk int NOT NULL,
	DateOut date,
	DateIn date,
	LibFk int NOT NULL,

	FOREIGN KEY (TeacherFk) REFERENCES Teachers(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	FOREIGN KEY (BookFk) REFERENCES Books(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	FOREIGN KEY (LibFk) REFERENCES Libs(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)
GO


-- ��������� �������

INSERT Authors (Id, FirstName, LastName) VALUES (1, N'������ �.', N'�����')
INSERT Authors (Id, FirstName, LastName) VALUES (2, N'������', N'����������')
INSERT Authors (Id, FirstName, LastName) VALUES (3, N'������', N'�����')
INSERT Authors (Id, FirstName, LastName) VALUES (4, N'�����', N'������')
INSERT Authors (Id, FirstName, LastName) VALUES (5, N'�������', N'�������������')
INSERT Authors (Id, FirstName, LastName) VALUES (6, N'��������', N'������')
INSERT Authors (Id, FirstName, LastName) VALUES (7, N'���������', N'��������')
INSERT Authors (Id, FirstName, LastName) VALUES (8, N'������', N'��������')
INSERT Authors (Id, FirstName, LastName) VALUES (9, N'�����', N'������')
INSERT Authors (Id, FirstName, LastName) VALUES (10, N'���������', N'��������')
INSERT Authors (Id, FirstName, LastName) VALUES (11, N'�������', N'����������')
INSERT Authors (Id, FirstName, LastName) VALUES (12, N'�����', N'�������')
INSERT Authors (Id, FirstName, LastName) VALUES (13, N'�����', N'��������')
INSERT Authors (Id, FirstName, LastName) VALUES (14, N'����', N'�����')
GO

INSERT Themes (Id, Name) VALUES (1, N'���� ������')
INSERT Themes (Id, Name) VALUES (2, N'����������������')
INSERT Themes (Id, Name) VALUES (3, N'����������� ������')
INSERT Themes (Id, Name) VALUES (4, N'������ ����������')
INSERT Themes (Id, Name) VALUES (5, N'�������������� ������')
INSERT Themes (Id, Name) VALUES (6, N'����')
INSERT Themes (Id, Name) VALUES (7, N'Web-������')
INSERT Themes (Id, Name) VALUES (8, N'Windows 2000')
INSERT Themes (Id, Name) VALUES (9, N'������������ �������')
GO

INSERT Presses (Id, Name) VALUES (1, N'DiaSoft')
INSERT Presses (Id, Name) VALUES (2, N'BHV')
INSERT Presses (Id, Name) VALUES (3, N'�����')
INSERT Presses (Id, Name) VALUES (4, N'�����')
INSERT Presses (Id, Name) VALUES (5, N'�����')
INSERT Presses (Id, Name) VALUES (6, N'�����-�����')
INSERT Presses (Id, Name) VALUES (7, N'����������')
GO

INSERT Categories (Id, Name) VALUES (1, N'���� SQL')
INSERT Categories (Id, Name) VALUES (2, N'�������������� ������')
INSERT Categories (Id, Name) VALUES (3, N'C++ Builder')
INSERT Categories (Id, Name) VALUES (4, N'Delphi')
INSERT Categories (Id, Name) VALUES (5, N'Visual Basic')
INSERT Categories (Id, Name) VALUES (6, N'3D Studio Max')
INSERT Categories (Id, Name) VALUES (7, N'Mathcad')
INSERT Categories (Id, Name) VALUES (8, N'Novell')
INSERT Categories (Id, Name) VALUES (9, N'Perl')
INSERT Categories (Id, Name) VALUES (10, N'FrontPage')
INSERT Categories (Id, Name) VALUES (11, N'Visual FoxPro')
INSERT Categories (Id, Name) VALUES (12, N'Windows 2000')
INSERT Categories (Id, Name) VALUES (13, N'Unix')
INSERT Categories (Id, Name) VALUES (14, N'HTML')
GO

INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (1, N'SQL', 816, 2001, 1, 1, 1, 2, N'2-� �������', 2)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (2, N'3D Studio Max 3', 640, 2000, 3, 6, 3, 3, N'������� ����', 3)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (3, N'100 ����������� ������ ���������� ���������� Delphi 5', 272, 1999, 2, 4, 5, 4, N'����������', 1)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (4, N'Visual Basic 6', 416, 2000, 2, 5, 4, 3, N'����������� ����������', 1)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (5, N'���� ��������������� �������', 328, 1990, 4, 2, 2, 5, N'1-� ���', 1)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (6, N'���������� C++ Builder 5: 70 ����������� �����/������ ����������', 288, 2000, 2, 3, 5, 4, N'����������', 1)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (7, N'��������������� ����� ����������', 272, 2000, 2, 3, 5, 4, N'����� ����������', 2)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (8, N'������� ������� (Help) �� Delphi 5 �  Object Pascal', 32, 2000, 2, 4, 5, 4, N'����������', 1)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (9, N'Visual Basic 6.0 for Application', 488, 2000, 2, 5, 6, 6, N'���������� � ���������', 3)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (10, N'Visual Basic 6', 576, 2000, 2, 5, 7, 2, N'����������� ������������ 1-� ���', 1)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (11, N'Mathcad 2000', 416, 2000, 5, 7, 8, 2, N'������ �����������', 1)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (12, N'Novell GroupWise 5.5 ������� ����������� ����� � ������������ ������', 480, 2000, 6, 8, 9, 2, N'������� ������', 2)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (13, N'������ Windows 2000', 352, 2000, 9, 12, 13, 2, N'����������� ��� ��������������', 4)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (14, N'Unix ����������', 384, 1999, 9, 13, 12, 3, N'���������� �����������', 1)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (15, N'����������� Visual FoxPro 6.0', 512, 1999, 1, 11, 11, 2, N'�����������', 1)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (16, N'����������� FrontPage 2000', 512, 1999, 7, 10, 11, 2, N'�����������', 1)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (17, N'����������� Perl', 432, 2000, 2, 9, 10, 2, N'�����������', 2)
INSERT Books (Id, Name, Pages, YearPress, ThemeFk, CategoryFk, AuthorFk, PressFk, Comment, Quantity) VALUES (18, N'HTML 3.2', 1040, 2000, 7, 14, 14, 2, N'�����������', 5)
GO

INSERT Departments (Id, Name) VALUES (1, N'��������������')
INSERT Departments (Id, Name) VALUES (2, N'������� � �������')
INSERT Departments (Id, Name) VALUES (3, N'������ � �����������������')
GO

INSERT Teachers (Id, FirstName, LastName, DepartmentFk) VALUES (1, N'��������', N'����', 1)
INSERT Teachers (Id, FirstName, LastName, DepartmentFk) VALUES (2, N'�����', N'�������', 1)
INSERT Teachers (Id, FirstName, LastName, DepartmentFk) VALUES (3, N'������', N'����������', 2)
INSERT Teachers (Id, FirstName, LastName, DepartmentFk) VALUES (4, N'�������', N'���������', 2)
INSERT Teachers (Id, FirstName, LastName, DepartmentFk) VALUES (5, N'������', N'������', 2)
INSERT Teachers (Id, FirstName, LastName, DepartmentFk) VALUES (6, N'�����', N'��������', 3)
INSERT Teachers (Id, FirstName, LastName, DepartmentFk) VALUES (7, N'��������', N'����������', 3)
INSERT Teachers (Id, FirstName, LastName, DepartmentFk) VALUES (8, N'������', N'���������', 1)
INSERT Teachers (Id, FirstName, LastName, DepartmentFk) VALUES (9, N'������', N'������', 1)
INSERT Teachers (Id, FirstName, LastName, DepartmentFk) VALUES (10, N'��������', N'������', 2)
INSERT Teachers (Id, FirstName, LastName, DepartmentFk) VALUES (11, N'����', N'����������', 3)
INSERT Teachers (Id, FirstName, LastName, DepartmentFk) VALUES (12, N'���������', N'�������', 1)
GO

INSERT Faculties (Id, Name) VALUES (1, N'����������������')
INSERT Faculties (Id, Name) VALUES (2, N'���-�������')
INSERT Faculties (Id, Name) VALUES (3, N'�����������������')
GO

INSERT Groups (Id, Name, FacultyFk) VALUES (2, N'9�1', 1)
INSERT Groups (Id, Name, FacultyFk) VALUES (3, N'9�2', 1)
INSERT Groups (Id, Name, FacultyFk) VALUES (4, N'9�', 3)
INSERT Groups (Id, Name, FacultyFk) VALUES (5, N'9�', 2)
INSERT Groups (Id, Name, FacultyFk) VALUES (6, N'14�', 3)
INSERT Groups (Id, Name, FacultyFk) VALUES (7, N'19�1', 1)
INSERT Groups (Id, Name, FacultyFk) VALUES (8, N'18�2', 1)
INSERT Groups (Id, Name, FacultyFk) VALUES (9, N'18�', 3)
INSERT Groups (Id, Name, FacultyFk) VALUES (10, N'19�', 2)
GO

INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (2, N'��������', N'�����', 8, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (3, N'�����', N'��������', 8, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (4, N'�����', N'�������', 8, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (5, N'�����', N'���������', 8, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (6, N'������', N'��������', 8, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (7, N'����', N'������', 8, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (8, N'����', N'���������', 8, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (9, N'������', N'���������', 8, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (10, N'�����', N'������', 8, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (11, N'����', N'�������', 8, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (12, N'�������', N'������', 3, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (13, N'�����', N'���������', 3, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (14, N'�������', N'�������', 3, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (15, N'�����', N'�������', 3, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (16, N'��������', N'��������', 9, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (17, N'���������', N'�������', 10, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (18, N'�������', N'��������', 10, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (19, N'�����', N'�����������', 5, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (20, N'���������', N'��������', 7, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (21, N'�����', N'�����', 4, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (22, N'�����', N'�����������', 6, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (23, N'������', N'��������', 6, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (24, N'����', N'��������', 3, 2)
INSERT Students (Id, FirstName, LastName, GroupFk, Term) VALUES (25, N'�����', N'���������', 5, 2)
GO

INSERT Libs (Id, FirstName, LastName) VALUES (1, N'������', N'����������')
INSERT Libs (Id, FirstName, LastName) VALUES (2, N'�������', N'���������')
GO

INSERT StudentCards (Id, StudentFk, BookFk, DateOut, DateIn, LibFk) VALUES (1, 2, 1, CAST(N'2001-05-17' AS date), CAST(N'2001-06-12' AS date), 1)
INSERT StudentCards (Id, StudentFk, BookFk, DateOut, DateIn, LibFk) VALUES (2, 17, 18, CAST(N'2000-05-18' AS date), NULL, 1)
INSERT StudentCards (Id, StudentFk, BookFk, DateOut, DateIn, LibFk) VALUES (3, 6, 3, CAST(N'2001-04-21' AS date), NULL, 2)
INSERT StudentCards (Id, StudentFk, BookFk, DateOut, DateIn, LibFk) VALUES (4, 21, 4, CAST(N'2001-03-26' AS date), NULL, 2)
INSERT StudentCards (Id, StudentFk, BookFk, DateOut, DateIn, LibFk) VALUES (5, 3, 1, CAST(N'2000-05-07' AS date), CAST(N'2001-04-12' AS date), 1)
INSERT StudentCards (Id, StudentFk, BookFk, DateOut, DateIn, LibFk) VALUES (6, 7, 11, CAST(N'2001-06-02' AS date), NULL, 2)
INSERT StudentCards (Id, StudentFk, BookFk, DateOut, DateIn, LibFk) VALUES (7, 16, 14, CAST(N'2001-04-05' AS date), NULL, 1)
INSERT StudentCards (Id, StudentFk, BookFk, DateOut, DateIn, LibFk) VALUES (8, 11, 6, CAST(N'2001-05-05' AS date), NULL, 2)
INSERT StudentCards (Id, StudentFk, BookFk, DateOut, DateIn, LibFk) VALUES (9, 17, 2, CAST(N'2001-10-01' AS date), NULL, 2)
INSERT StudentCards (Id, StudentFk, BookFk, DateOut, DateIn, LibFk) VALUES (10, 10, 13, CAST(N'2001-05-05' AS date), NULL, 1)
GO

INSERT TeacherCards (Id, TeacherFk, BookFk, DateOut, DateIn, LibFk) VALUES (1, 2, 13, CAST(N'2000-01-01' AS date), CAST(N'2001-07-04' AS date), 1)
INSERT TeacherCards (Id, TeacherFk, BookFk, DateOut, DateIn, LibFk) VALUES (2, 10, 2, CAST(N'2000-03-03' AS date), NULL, 1)
INSERT TeacherCards (Id, TeacherFk, BookFk, DateOut, DateIn, LibFk) VALUES (3, 6, 12, CAST(N'2000-06-04' AS date), NULL, 2)
INSERT TeacherCards (Id, TeacherFk, BookFk, DateOut, DateIn, LibFk) VALUES (4, 3, 1, CAST(N'2000-09-05' AS date), NULL, 1)
INSERT TeacherCards (Id, TeacherFk, BookFk, DateOut, DateIn, LibFk) VALUES (5, 8, 8, CAST(N'2000-05-05' AS date), NULL, 2)
INSERT TeacherCards (Id, TeacherFk, BookFk, DateOut, DateIn, LibFk) VALUES (6, 5, 18, CAST(N'2001-02-02' AS date), NULL, 2)
INSERT TeacherCards (Id, TeacherFk, BookFk, DateOut, DateIn, LibFk) VALUES (7, 12, 17, CAST(N'2001-03-04' AS date), NULL, 1)
INSERT TeacherCards (Id, TeacherFk, BookFk, DateOut, DateIn, LibFk) VALUES (8, 4, 18, CAST(N'2000-07-02' AS date), NULL, 1)
GO
