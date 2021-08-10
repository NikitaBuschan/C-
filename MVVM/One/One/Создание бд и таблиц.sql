/* create database my; */

IF DB_ID('AutoPro') IS NOT NULL
BEGIN
	USE master
    ALTER DATABASE AutoPro SET single_user with rollback immediate;
    DROP DATABASE AutoPro;
END
GO

CREATE DATABASE AutoPro
GO

USE AutoPro
GO


-- Выбор модели автомобиля
-- 1 Модели автомобилей
CREATE TABLE Models 
(
	Id int NOT NULL IDENTITY PRIMARY KEY,
	[Name] varchar(100),
	Code varchar(15),
	[Date] varchar(30)
)
GO

-- (Выбор комплектации автомобиля)
-- 2 Информация о модификациях автомобиля 
CREATE TABLE Modifications
(
	Id int NOT NULL IDENTITY PRIMARY KEY,
	Engine1 varchar(18),
	Body varchar(18),
	Grade varchar(18),
	AtmMtm varchar(18),
	GearShiftType varchar(18),
	DriversPosition varchar(18),
	NoOfDoors varchar(18),
	Destination1 varchar(18),
	Dectination2 varchar(18),
	ModelFk int,

	FOREIGN KEY (ModelFk) REFERENCES Models(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)

-- Выбор группы запчастей
-- 3 Комплектации
CREATE TABLE Complectation
(
	Id int NOT NULL IDENTITY PRIMARY KEY,
	[Name] varchar(100),
	ModificationsFk int,
	
	FOREIGN KEY (ModificationsFk) REFERENCES Modifications(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)

-- Выбор подгруппы запчастей
-- 4 Группы комплектаций
CREATE TABLE [Group]
(
	Id int NOT NULL IDENTITY PRIMARY KEY,
	[Name] varchar(100),
	ComplectationFk int,

	FOREIGN KEY (ComplectationFk) REFERENCES Complectation(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)

-- Выбор запчасти
-- 5 Запчасти
CREATE TABLE Spares
(
	Id int NOT NULL IDENTITY PRIMARY KEY,
	Code varchar(30),
	[Count] int,
	Info varchar(50),
	TreeCode varchar(15),
	Tree varchar(50),
	[Date] varchar(30),
	GroupFk int,

	FOREIGN KEY (GroupFk) REFERENCES [Group](Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)
