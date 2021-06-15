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
	('����������������'),
	('�����������������'),
	('������')

SELECT *
FROM Specializations

INSERT INTO Subjects VALUES
	('��������� �������'),
	('���������� ���������'),
	('3D �������������'),
	('C++'),
	('C# .NET'),
	('ASP .NET'),
	('������������� � IP-�����'),
	('����� ������������'),
	('������� ����������������� Linux')
	
SELECT *
FROM Subjects

BEGIN TRY
    BEGIN TRANSACTION;

	DECLARE @SpecializationPrimaryKey bigint;

	SELECT @SpecializationPrimaryKey = Id
	FROM Specializations
	WHERE Name = N'����������������';

	INSERT INTO Groups VALUES
		('���-12', @SpecializationPrimaryKey),
		('���-23', @SpecializationPrimaryKey),
		('���-45', @SpecializationPrimaryKey),
		('���-09', @SpecializationPrimaryKey),
		('���-3', @SpecializationPrimaryKey)
	
	SELECT @SpecializationPrimaryKey = Id
	FROM Specializations
	WHERE Name = N'�����������������';

	INSERT INTO Groups VALUES
		('���-34', @SpecializationPrimaryKey),
		('���-743', @SpecializationPrimaryKey),
		('���-2', @SpecializationPrimaryKey)

	SELECT @SpecializationPrimaryKey = Id
	FROM Specializations
	WHERE Name = N'������';

	INSERT INTO Groups VALUES
		('���-72', @SpecializationPrimaryKey),
		('���-19', @SpecializationPrimaryKey),
		('���-03', @SpecializationPrimaryKey),
		('���-43', @SpecializationPrimaryKey)

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
	WHERE Groups.Name = '���-12'

	INSERT INTO Students VALUES 
		('������', '�����������', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = '���-23'

	INSERT INTO Students VALUES 
		('��������', '�����', @GroupPrimaryKey),
		('�������', '��������', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = '���-45'

	INSERT INTO Students VALUES 
		('������', '���������', @GroupPrimaryKey),
		('������', '��������', @GroupPrimaryKey),
		('������', '��������', @GroupPrimaryKey)
	
	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = '���-09'
		
	INSERT INTO Students VALUES 
		('�����', '���������', @GroupPrimaryKey),
		('������', '�����', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = '���-3'
		
	INSERT INTO Students VALUES 
		('��������', '��������', @GroupPrimaryKey),
		('�������', '����������', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = '���-34'
		
	INSERT INTO Students VALUES 
		('��������', '�������', @GroupPrimaryKey),
		('����', '���������', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = '���-743'
		
	INSERT INTO Students VALUES 
		('������', '�����������', @GroupPrimaryKey),
		('��������', '�������', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = '���-2'
		
	INSERT INTO Students VALUES 
		('������', '�������', @GroupPrimaryKey),
		('���������', '�������', @GroupPrimaryKey)
			
	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = '���-72'
		
	INSERT INTO Students VALUES 
		('������', '�����������', @GroupPrimaryKey),
		('����', '����', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = '���-19'
		
	INSERT INTO Students VALUES 
		('������', '�������', @GroupPrimaryKey),
		('������', '��������', @GroupPrimaryKey),
		('������', '�������', @GroupPrimaryKey),
		('������', '����', @GroupPrimaryKey),
		('�������', '���������', @GroupPrimaryKey)
		
	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = '���-03'
		
	INSERT INTO Students VALUES 
		('�����', '���������', @GroupPrimaryKey),
		('��������', '��������', @GroupPrimaryKey),
		('������', '������', @GroupPrimaryKey)

	SELECT @GroupPrimaryKey = ID
	FROM Groups
	WHERE Groups.Name = '���-43'
		
	INSERT INTO Students VALUES 
		('������', '�����', @GroupPrimaryKey),
		('������', '���', @GroupPrimaryKey)

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
	WHERE Subjects.Name = '��������� �������'

	INSERT INTO Teachers VALUES ('�����  �������', @SubjectPrimaryKey)

	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = '���������� ���������'
	
	INSERT INTO Teachers VALUES ('������ �����', @SubjectPrimaryKey)

	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = '3D �������������'

	INSERT INTO Teachers VALUES ('������ �������', @SubjectPrimaryKey)
	
	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = 'C++'

	INSERT INTO Teachers VALUES ('�������� �����', @SubjectPrimaryKey)
	
	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = 'C# .NET'
	
	INSERT INTO Teachers VALUES ('���������� ����', @SubjectPrimaryKey)

	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = 'ASP .NET'
	
	INSERT INTO Teachers VALUES ('��������� �����', @SubjectPrimaryKey)

	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = '������������� � IP-�����'
	
	INSERT INTO Teachers VALUES ('����� �����', @SubjectPrimaryKey)

	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = '����� ������������'

	INSERT INTO Teachers VALUES ('��������� �����', @SubjectPrimaryKey)

	SELECT @SubjectPrimaryKey = ID
	FROM Subjects
	WHERE Subjects.Name = '������� ����������������� Linux'

	INSERT INTO Teachers VALUES ('�������� �����', @SubjectPrimaryKey)

	COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
END CATCH
GO


