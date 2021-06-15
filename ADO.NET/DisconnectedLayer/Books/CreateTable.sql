IF DB_ID('Books') IS NOT NULL
BEGIN
	USE master
    ALTER DATABASE Books SET single_user with rollback immediate;
    DROP DATABASE Books;
END
GO

CREATE DATABASE Books;
GO

USE Books
GO

CREATE TABLE Authors
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(20)
);

CREATE TABLE Presses
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(20)
);

CREATE TABLE Books
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(20),
	Author_FK bigint,
	Presses_FK bigint,

	FOREIGN KEY (Author_FK) REFERENCES Authors(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (Presses_FK) REFERENCES Presses(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);