IF DB_ID('Football') IS NOT NULL
BEGIN
	USE master
    ALTER DATABASE Football SET single_user with rollback immediate;
    DROP DATABASE Football;
END
GO

CREATE DATABASE Football;
GO

USE Football
GO

-- 1
CREATE TABLE Cities
(	
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50)
);
GO

-- 2
CREATE TABLE Stadiums
(	
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50),
	Capacity int,
	City_FK bigint,

	FOREIGN KEY (City_FK) REFERENCES Cities(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
GO

-- 3
CREATE TABLE Equipments
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50)
);
GO

-- 4
CREATE TABLE Countries
(	
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50)
);
GO

-- 5
CREATE TABLE Trainers
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50)
); 
GO

-- 6
CREATE TABLE Teams
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Equypment_FK bigint,
	Country_FK bigint,
	Trainer_FK bigint,

	FOREIGN KEY (Equypment_FK) REFERENCES Equipments(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (Country_FK) REFERENCES Countries(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (Trainer_FK) REFERENCES Trainers(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
GO

-- 7
CREATE TABLE Players
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50),
	Number int,
	Position nvarchar(2),
	Team_FK bigint,

	FOREIGN KEY (Team_FK) REFERENCES Teams(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
GO

-- 8
CREATE TABLE Cards
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Color nvarchar(10)
);
GO

-- 12
CREATE TABLE Associations
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50)
);
GO

-- 13
CREATE TABLE Referees
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50),
	Association_FK bigint,

	FOREIGN KEY (Association_FK) REFERENCES Associations(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
GO

-- 14
CREATE TABLE Groups
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50)
);
GO

-- 15
CREATE TABLE PlayOff
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50)
);
GO

-- 17
CREATE TABLE Matches
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Stadium_FK bigint NOT NULL,
	Referee_FK bigint NOT NULL,
	FirstTeam_FK bigint NOT NULL,
	SecondTeam_FK bigint NOT NULL,
	[DateTime] smalldatetime NOT NULL,
	ExtraTime bit DEFAULT NULL,
	Penalty bit DEFAULT NULL,
	CountOfFans int DEFAULT NULL,
	Group_FK bigint DEFAULT NULL,
	PalyOff_FK bigint DEFAULT NULL,

	FOREIGN KEY (Stadium_FK) REFERENCES Stadiums(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (Referee_FK) REFERENCES Referees(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (FirstTeam_FK) REFERENCES Teams(ID),
	FOREIGN KEY (SecondTeam_FK) REFERENCES Teams(ID),
	FOREIGN KEY (Group_FK) REFERENCES Groups(ID),
	FOREIGN KEY (PalyOff_FK) REFERENCES PlayOff(ID)
);

-- 16
CREATE TABLE Scores
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FirstTeam int DEFAULT NULL,
	SecondTeam int DEFAULT NULL,
	Match_FK bigint DEFAULT NULL,

	FOREIGN KEY (Match_FK) REFERENCES Matches(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
GO

-- 9
CREATE TABLE Foals
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Player_FK bigint,
	Team bigint,
	[Time] float,
	Card_FK bigint,
	Match_FK bigint,

	FOREIGN KEY (Player_FK) REFERENCES Players(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (Card_FK) REFERENCES Cards(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (Match_FK) REFERENCES Matches(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
GO

-- 10
CREATE TABLE Penaltes
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Player_FK bigint,
	Team bigint,
	Hit bit,
	Match_FK bigint,

	FOREIGN KEY (Player_FK) REFERENCES Players(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (Match_FK) REFERENCES Matches(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
GO

-- 11
CREATE TABLE Goals
(
	ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Player_FK bigint,
	Team bigint,
	[Time] float,
	Match_FK bigint,

	FOREIGN KEY (Player_FK) REFERENCES Players(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (Match_FK) REFERENCES Matches(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
GO

-- 1
--- Cities --------------  //
INSERT INTO Cities([Name]) VALUES
(N'Соккер Сити'),
(N'Кейптаун'),
(N'Мозес Мабида'),
(N'Кока-Кола Парк'),
(N'Лофтус Версфельд'),
(N'Нельсон Мандела Бэй'),
(N'Питер Мокаба'),
(N'Мбомбела'),
(N'Фри-Стейт'),
(N'Роял Бафокенг'),
(N'Bloemfontein'),
(N'Cape Town'),
(N'Durban'),
(N'Johannesburg'),
(N'Kimberley'),
(N'Klerksdorp'),
(N'Nelspruit'),
(N'Orkney'),
(N'Polokwane'),
(N'Port Elizabeth'),
(N'Pretoria'),
(N'Rustenburg')
GO

-- 2
--- Stadiums --------------  //
INSERT INTO Stadiums([Name], Capacity, City_FK) VALUES
(N'Йоханнесбург', 84490, 1),
(N'Кейптаун', 64100, 2),
(N'Дурбан', 62760, 3),
(N'Йоханнесбург', 55686, 4),
(N'Претория', 42858, 5),
(N'Порт-Элизабет', 42486, 6),
(N'Полокване', 41733, 7),
(N'Нелспрейт', 40929, 8),
(N'Блумфонтейн', 40911, 9),
(N'Рустенбург', 38646, 10)
GO

-- 3
--- Equipments --------------  //
IF OBJECT_ID('ImportData') IS NOT NULL
    DROP TABLE ImportData;
GO
CREATE TABLE ImportData (Field VARCHAR(max)) 
GO
BULK INSERT ImportData
FROM 'D:\Users\Nikita\Desktop\DB\Exam\Чемпионат мира по футболу\Форма.txt'
WITH (ROWTERMINATOR = '\n')
GO
INSERT INTO Equipments
SELECT *
FROM ImportData;
GO

-- 4
--- Countries --------------  //
IF OBJECT_ID('ImportData') IS NOT NULL
    DROP TABLE ImportData;
GO
CREATE TABLE ImportData (Field VARCHAR(max)) 
GO
BULK INSERT ImportData
FROM 'D:\Users\Nikita\Desktop\DB\Exam\Чемпионат мира по футболу\Страны.txt'
WITH ( ROWTERMINATOR = '\n')
GO
INSERT INTO Countries
SELECT *
FROM ImportData;
GO

-- 5
--- Trainers --------------  //
INSERT INTO Trainers([Name]) VALUES
(N'Пим Вербеек'),
(N'Рабах Саадан'),
(N'Фабио Капелло'),
(N'Диего Марадона'),
(N'Дунга'),
(N'Милован Раевац'),
(N'Йоахим Лёв'),
(N'Отто Рехагель'),
(N'Рейнальдо Руэда'),
(N'Мортен Ольсен'),
(N'Висенте дель Боске'),
(N'Марчелло Липпи'),
(N'Поль Ле Гуэн'),
(N'ПКим Чон Хон'),
(N'Кот-д’Ивуар	Свен-Ёран Эрикссон'),
(N'Хавьер Агирре'),
(N'Ларс Лагербек'),
(N'Берт ван Марвейк'),
(N'Рики Херберт'),
(N'Херардо Мартино'),
(N'Карлуш Кейрош'),
(N'Хо Чжон Му'),
(N'Радомир Антич'),
(N'Владимир Вайсс'),
(N'Матьяж Кек'),
(N'Боб Брэдли'),
(N'Оскар Табарес'),
(N'Раймон Доменек'),
(N'Марсело Бьельса'),
(N'Оттмар Хитцфельд'),
(N'Карлос Алберто Паррейра'),
(N'Такэси Окада')
GO

-- 6
--- Teams --------------  //
DECLARE @count int = 32
while(@count > 0)
BEGIN
	INSERT INTO Teams(Equypment_FK, Country_FK, Trainer_FK) VALUES
	((select RAND() * (select MAX(ID) from Equipments) + 1), 
	(select RAND() * (select MAX(ID) from Countries) + 1), 
	(select RAND() * (select COUNT(ID) from Trainers) + 1));
	SET @count = @count - 1;
END;
GO

-- 7
--- Players --------------  //
IF OBJECT_ID('ImportData') IS NOT NULL
    DROP TABLE ImportData;
GO
CREATE TABLE ImportData(Position VARCHAR(max), [Name] VARCHAR(max))
GO
BULK INSERT ImportData
FROM 'D:\Users\Nikita\Desktop\DB\Exam\Чемпионат мира по футболу\Игроки.txt'
WITH ( FIELDTERMINATOR = '\t', ROWTERMINATOR = '\n');
GO

INSERT INTO Players(Position, Number, [Name])
SELECT Position, null, [Name]
FROM ImportData;
GO

DECLARE @count int;
DECLARE @iter int;
SET @count = (select MAX(ID) from Players)
SET @iter = 1;

while(@count > 0)
BEGIN
	DECLARE @temp int;
	SET @temp = (select RAND() * 100);
	UPDATE Players SET Number = @temp where ID = @iter
	SET @iter = @iter + 1;
	SET @count = @count - 1;
END;
GO

DECLARE @iterator int = 1;
WHILE (@iterator < (select COUNT(*) from Teams) + 1)
BEGIN
	DECLARE @CountOfPlayers int = 11;
	WHILE (@CountOfPlayers > 0)
	BEGIN
		DECLARE @Player int = RAND() * (select COUNT(*) from Players);
		WHILE ((select Team_FK from Players where ID = @Player) > 0)
			SET @Player = RAND() * (select COUNT(*) from Players);

		UPDATE Players SET Team_FK = @iterator WHERE ID = @Player;
		SET @CountOfPlayers = @CountOfPlayers - 1;
	END;
	SET @iterator = @iterator + 1;
END;

-- 8
--- Cards --------------  //
INSERT INTO Cards(Color) VALUES
(N'Желтая'),
(N'Красная')
GO

-- 12
--- Associations --------------  //
INSERT INTO Associations([Name]) VALUES
(N'АФК'),
(N'КАФ'),
(N'КОНМЕБОЛ'),
(N'КОНКАКАФ'),
(N'ОФК'),
(N'УЕФА')
GO

-- 13
--- Referees --------------  //
INSERT INTO Referees([Name]) VALUES
(N'Коман Кулибали'),
(N'Джером Деймон'),
(N'Эдди Майе'),
(N'Хоэль Агилар'),
(N'Бенито Арчундиа'),
(N'Карлос Батрес'),
(N'Марко Родригес'),
(N'Эктор Бальдасси'),
(N'Хорхе Ларрионда'),
(N'Пабло Посо'),
(N'Оскар Руис'),
(N'Карлуш Симон'),
(N'Мартин Васкес'),
(N'Майкл Хестер'),
(N'Питер Лири'),
(N'Олегарио Бенкеренса'),
(N'Массимо Бузакка'),
(N'Франк Де Блекере'),
(N'Мартин Ханссон'),
(N'Виктор Кашшаи'),
(N'Стефан Ланнуа'),
(N'Роберто Розетти'),
(N'Вольфганг Штарк'),
(N'Альберто Ундиано'),
(N'Ховард Уэбб'),
(N'Халил аль-Гамди'),
(N'Равшан Ирматов'),
(N'Субхиддин Мохд Саллех'),
(N'Юити Нисимура')
GO

DECLARE @count int;
DECLARE @iter int;
SET @count = (select MAX(ID) from Referees)
SET @iter = 1;

while(@count > 0)
BEGIN
	DECLARE @temp int;
	SET @temp = (select RAND() * (select MAX(ID) from Associations) + 1);
	UPDATE Referees SET Association_FK = @temp where ID = @iter
	SET @iter = @iter + 1;
	SET @count = @count - 1;
END;
GO


-- 14
--- Groups --------------  //
INSERT INTO Groups([Name]) VALUES
('A'),
('B'),
('C'),
('D'),
('E'),
('F'),
('G'),
('H')
GO

-- 15
--- PlayOff --------------  //
INSERT INTO PlayOff([Name]) VALUES
('1/8'),
('1/4'),
('1/2'),
('Third place'),
('Final')
GO






























