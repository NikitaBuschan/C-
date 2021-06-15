IF DB_ID('Fridges') IS NOT NULL
BEGIN
	USE master
    ALTER DATABASE Fridges SET single_user with rollback immediate;
    DROP DATABASE Fridges;
END
GO

CREATE DATABASE Fridges;
GO

USE Fridges
GO

CREATE TABLE Companies
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(30)
);

CREATE TABLE Colors
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(30)
);

CREATE TABLE Sellers
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(30),
	Age int
);

CREATE TABLE Fridges
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Model nvarchar(20),
	Company_FK bigint,
	Color_FK bigint,
	Cost bigint,

	FOREIGN KEY (Company_FK) REFERENCES Companies(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (Color_FK) REFERENCES Colors(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);

CREATE TABLE Receipts
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Order] bigint,
	[Date] datetime,
	Seller_FK bigint,
	Fridge_FK bigint,

	FOREIGN KEY (Seller_FK) REFERENCES Sellers(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (Fridge_FK) REFERENCES Fridges(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);