IF DB_ID('Sales') IS NOT NULL
BEGIN
	USE master
    ALTER DATABASE Sales SET single_user with rollback immediate;
    DROP DATABASE Sales;
END
GO

CREATE DATABASE Sales
GO

USE Sales
GO

CREATE TABLE Seller
(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	FirstName nvarchar(50),
	LastName nvarchar(50)
);

CREATE TABLE Buyer
(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	FirstName nvarchar(50),
	LastName nvarchar(50)
);

CREATE TABLE Sales
(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Seller_fk bigint NOT NULL,
	Buyer_fk bigint NOT NULL,
	[Sum] bigint NOT NULL,
	[Date] Date NOT NULL,

	FOREIGN KEY (Seller_fk) REFERENCES Seller(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (Buyer_fk) REFERENCES Buyer(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

INSERT INTO Buyer(FirstName, LastName) VALUES
(N'Костя', N'Дзю'),
(N'Анжелина', N'Джоли'),
(N'Джонни', N'Депп'),
(N'Бред', N'Питт'),
(N'Бритни', N'Спирс')


INSERT INTO Seller(FirstName, LastName) VALUES
(N'Кто', N'Я'),
(N'Где', N'Мы')

INSERT INTO Sales(Seller_fk, Buyer_fk, [Sum], [Date]) VALUES
(1, 1, 100, '2020-03-21'),
(1, 2, 475, '2020-03-21'),
(2, 1, 300, '2020-03-22'),
(2, 3, 567, '2020-03-22'),
(2, 4, 243, '2020-03-22'),
(1, 5, 340, '2020-03-23')


SELECT 
Seller.FirstName + ' ' + Seller.LastName AS Seller, 
Buyer.FirstName + ' ' + Buyer.LastName AS Buyer,
Sales.Sum AS [Sum],
Sales.Date AS [Date]
FROM Sales join Seller on Seller_fk = Seller.ID join Buyer on Buyer_fk = Buyer.ID