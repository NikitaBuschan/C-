IF DB_ID('Akkk') IS NOT NULL
DROP DATABASE MyFirstBD
GO

CREATE DATABASE HomeLibrary
GO

USE HomeLibrary
GO

CREATE TABLE Authors
(
	Id bigint NOT NULL PRIMARY KEY,
	[Name] nvarchar(50) NOT NULL,
	BirthYear int DEFAULT 1900 CHECK(BirthYear > -5000)
)
GO

CREATE TABLE Presses
(
	Id bigint NOT NULL PRIMARY KEY,
	[Name] nvarchar(50) NOT NULL,
	Address nvarchar(100),
	Phone char(15)
)
GO

CREATE TABLE Books
(
	Id bigint NOT NULL,
	Name nvarchar(50) NOT NULL,
	AuthorFK bigint,
	PressFK bigint,
	Pages int CHECK(Pages > 0), -- �����������
	Price money,

	PRIMARY KEY (Id),

	FOREIGN KEY (AuthorFK) REFERENCES Authors(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (PressFK) REFERENCES Presses(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,

	CONSTRAINT PagesConstr CHECK (Pages > 0)  -- ����������� ������� ������������� �������� �� �������
)
GO

INSERT INTO Authors VALUES (1, '������ ����������', 1959)
INSERT INTO Authors VALUES (2, '������ ��������', 1900)
INSERT INTO Authors VALUES (3, '������� ���� �������', 1900)
GO

INSERT INTO Presses  (Id, [Name], Phone) VALUES (1, '����� ������', '+38012312322')
INSERT INTO Presses (Id, [Name], Phone) VALUES (2, '������', '+38012312342')
INSERT INTO Presses (Id, [Name], Phone) VALUES (3, '���������� �����', '+38012312327')
GO

INSERT INTO Books VALUES (1, '������ ���� �����', 1, 1, 300, 150)
INSERT INTO Books VALUES (2, '��� � �����������', 1, 1, 400, 170)
INSERT INTO Books VALUES (3, '����� ����� �����', 1, 1, 250, 250)
INSERT INTO Books VALUES (4, '������ � ���������', 2, 3, 500, 250)
INSERT INTO Books VALUES (5, '������. ���� � �������', 3, 2, 150, 150)
INSERT INTO Books VALUES (6, '��������� �����', 3, 2, 1500, 500)
GO

SELECT A.Name As Authos, B.Name, P.Name AS Press
FROM Authors A, Presses P, Books B
WHERE A.Id = B.AuthorFK AND P.Id = B.PressFK

SELECT *
FROM Books
GO