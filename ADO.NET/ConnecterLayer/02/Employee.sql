IF DB_ID('Employee') IS NOT NULL
BEGIN
	USE master
    ALTER DATABASE Employee SET single_user with rollback immediate;
    DROP DATABASE Employee;
END
GO

CREATE DATABASE Employee
GO

USE Employee
GO

CREATE TABLE Positions
(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Title nvarchar(50) NOT NULL
);

CREATE TABLE Workers
(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	[Image] image,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	Surname nvarchar(50) NOT NULL,
	Birthday date NOT NULL,
	Position_fk bigint NOT NULL,
	Recruitment bigint NOT NULL,
	Dismissal bigint

		FOREIGN KEY (Position_fk) REFERENCES Positions(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

INSERT INTO Positions(Title) VALUES
(N'Посудомойщик'),
(N'Охранник')

INSERT INTO Workers(image, FirstName, LastName, Surname, Birthday, Position_fk, Recruitment, Dismissal) VALUES
(N'Костя', N'Цзю', N'Петров', N'1945-04-22', 1, 23434265, null),
(N'Анжелина', N'Джоли', N'Иванова', N'1945-04-22', 2, 23434265, 5357),
(N'Джонни', N'Депп', N'Васильевич', N'1945-04-22', 1, 098657, null),
(N'Бред', N'Питт', N'Сергеевич', N'1945-04-22', 1, 37652, null),
(N'Бритни', N'Спирс', N'Убнхабировна', N'1945-04-22', 2, 934597, null)