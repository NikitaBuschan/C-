IF DB_ID('ITStep') IS NOT NULL
BEGIN
	USE master
    ALTER DATABASE ITStep SET single_user with rollback immediate;
    DROP DATABASE ITStep;
END
GO

CREATE DATABASE ITStep;
GO

USE ITStep
GO

CREATE TYPE id_type FROM bigint NOT NULL;

CREATE TABLE Specializations
(
	ID id_type IDENTITY PRIMARY KEY,
	[Name] nvarchar(50)
);

CREATE TABLE Subjects
(
	ID id_type IDENTITY PRIMARY KEY,
	[Name] nvarchar(50)
);

CREATE TABLE Groups
(
	ID id_type IDENTITY PRIMARY KEY,
	[Name] nvarchar(50),
	Specialization_Fk bigint,

	FOREIGN KEY (Specialization_Fk) REFERENCES Specializations(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

CREATE TABLE Students
(
	ID id_type IDENTITY PRIMARY KEY,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Group_Fk bigint,

	FOREIGN KEY (Group_Fk) REFERENCES Groups(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

CREATE TABLE Teachers
(
	ID id_type IDENTITY PRIMARY KEY,
	[Name] nvarchar(50),
	Subject_Fk bigint,
	
	FOREIGN KEY (Subject_Fk) REFERENCES Subjects(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

CREATE TABLE Classes
(
	ID id_type IDENTITY PRIMARY KEY,
	[Time] Date,
	Teacher_Fk bigint,
	Student_Fk bigint,

	FOREIGN KEY (Teacher_Fk) REFERENCES Teachers(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
		FOREIGN KEY (Student_Fk) REFERENCES Students(ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);

INSERT INTO Specializations VALUES
	('Программирование'),
	('Администрирование'),
	('Дизайн')

SELECT *
FROM Specializations

INSERT INTO Subjects VALUES
	('Растровая графика'),
	('Прикладное искусство'),
	('3D моделирование'),
	('C++'),
	('C# .NET'),
	('ASP .NET'),
	('Маршрутизация в IP-сетях'),
	('Кибер безопасность'),
	('Системы администрирования Linux')
	
SELECT *
FROM Subjects

BEGIN TRY
    BEGIN TRANSACTION;

	DECLARE @SpecializationPrimaryKey bigint;

	SELECT @SpecializationPrimaryKey = Id
	FROM Specializations
	WHERE Name = N'Программирование';

	INSERT INTO Groups VALUES
		('ПАБ-12', @SpecializationPrimaryKey),
		('ВИА-23', @SpecializationPrimaryKey),
		('НГА-45', @SpecializationPrimaryKey),
		('РОЛ-09', @SpecializationPrimaryKey),
		('ПЛЦ-3', @SpecializationPrimaryKey)
	
	SELECT @SpecializationPrimaryKey = Id
	FROM Specializations
	WHERE Name = N'Администрирование';

	INSERT INTO Groups VALUES
		('ОЛШ-34', @SpecializationPrimaryKey),
		('ЦЕО-743', @SpecializationPrimaryKey),
		('ПРЛ-2', @SpecializationPrimaryKey)

	SELECT @SpecializationPrimaryKey = Id
	FROM Specializations
	WHERE Name = N'Дизайн';

	INSERT INTO Groups VALUES
		('ГКЦ-72', @SpecializationPrimaryKey),
		('ГОЛ-19', @SpecializationPrimaryKey),
		('ТРВ-03', @SpecializationPrimaryKey),
		('ЦУК-43', @SpecializationPrimaryKey)

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
END CATCH
GO

SELECT Groups.Name AS [Group], (SELECT Specializations.Name FROM Specializations WHERE Specialization_Fk = Specializations.ID) AS Spec
FROM Groups
ORDER BY Spec

BEGIN TRY
	BEGIN TRANSACTION;

	DECLARE @GroupPrimaryKey bigint;

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = 'ПАБ-12'

	INSERT INTO Students VALUES 
		('Никита', 'Программист', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = 'ВИА-23'

	INSERT INTO Students VALUES 
		('Владимир', 'Лисин', @GroupPrimaryKey),
		('Алексей', 'Мордашов', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = 'НГА-45'

	INSERT INTO Students VALUES 
		('Леонид', 'Михельсон', @GroupPrimaryKey),
		('Виктор', 'Рашников', @GroupPrimaryKey),
		('Михаил', 'Прохоров', @GroupPrimaryKey)
	
	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = 'РОЛ-09'
		
	INSERT INTO Students VALUES 
		('Вагит', 'Алекперов', @GroupPrimaryKey),
		('Леонид', 'Федун', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = 'ПЛЦ-3'
		
	INSERT INTO Students VALUES 
		('Геннадий', 'Тимченко', @GroupPrimaryKey),
		('Дмитрий', 'Рыболовлев', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = 'ОЛШ-34'
		
	INSERT INTO Students VALUES 
		('Владимир', 'Потатин', @GroupPrimaryKey),
		('Олег', 'Дерипаска', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = 'ЦЕО-743'
		
	INSERT INTO Students VALUES 
		('Агдрей', 'Мельниченко', @GroupPrimaryKey),
		('Сулейман', 'Керимов', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = 'ПРЛ-2'
		
	INSERT INTO Students VALUES 
		('Михаил', 'Фридман', @GroupPrimaryKey),
		('Александр', 'Абрамов', @GroupPrimaryKey)
			
	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = 'ГКЦ-72'
		
	INSERT INTO Students VALUES 
		('Виктор', 'Вексельберг', @GroupPrimaryKey),
		('Петр', 'Авен', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = 'ГОЛ-19'
		
	INSERT INTO Students VALUES 
		('Алишер', 'Усманов', @GroupPrimaryKey),
		('Михаил', 'Гуцериев', @GroupPrimaryKey),
		('Андрей', 'Козьцын', @GroupPrimaryKey),
		('Андрей', 'Скоч', @GroupPrimaryKey),
		('Алексей', 'Кузьменко', @GroupPrimaryKey)
		
	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = 'ТРВ-03'
		
	INSERT INTO Students VALUES 
		('Роман', 'Абрамович', @GroupPrimaryKey),
		('Искандер', 'Махмудов', @GroupPrimaryKey),
		('Андрей', 'Гурьев', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = 'ЦУК-43'
		
	INSERT INTO Students VALUES 
		('Сергей', 'Попов', @GroupPrimaryKey),
		('Герман', 'Хан', @GroupPrimaryKey)

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
END CATCH
GO

SELECT Students.FirstName, Students.LastName
FROM Students

BEGIN TRY
	BEGIN TRANSACTION;

	DECLARE @SubjectPrimaryKey bigint;

	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = 'Растровая графика'

	INSERT INTO Teachers VALUES ('Артем  Филатов', @SubjectPrimaryKey)

	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = 'Прикладное искусство'
	
	INSERT INTO Teachers VALUES ('Акимов Игорь', @SubjectPrimaryKey)

	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = '3D моделирование'

	INSERT INTO Teachers VALUES ('Бухтер Николай', @SubjectPrimaryKey)
	
	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = 'C++'

	INSERT INTO Teachers VALUES ('Соколова Мария', @SubjectPrimaryKey)
	
	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = 'C# .NET'
	
	INSERT INTO Teachers VALUES ('Домчевская Алёна', @SubjectPrimaryKey)

	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = 'ASP .NET'
	
	INSERT INTO Teachers VALUES ('Ильяшенко Денис', @SubjectPrimaryKey)

	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = 'Маршрутизация в IP-сетях'
	
	INSERT INTO Teachers VALUES ('Кичук Вадим', @SubjectPrimaryKey)

	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = 'Кибер безопасность'

	INSERT INTO Teachers VALUES ('Колпакова Олеся', @SubjectPrimaryKey)

	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = 'Системы администрирования Linux'

	INSERT INTO Teachers VALUES ('Маевская Елена', @SubjectPrimaryKey)

	COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
END CATCH
GO


