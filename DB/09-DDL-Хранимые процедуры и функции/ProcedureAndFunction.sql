USE Library
GO

-- �������� ��������� --

-- 1 
-- �������� �������� ���������, ��������� 
-- �� ����� ������ ���������, �� ������� �����.

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'GetStudentWithBooks' AND type = 'P')
	DROP PROCEDURE GetStudentWithBooks;
GO

create PROCEDURE GetStudentWithBooks
AS
select *
from StudentCards
where StudentCards.DateIn IS NULL

EXEC GetStudentWithBooks

-- 2
-- �������� �������� ���������, ������������ ��� � ������� ������������,
-- ��������� ���������� ���-�� ����.

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'RetunNameAndLastNameOfLib' AND type = 'P')
	DROP PROCEDURE RetunNameAndLastNameOfLib;
GO

CREATE PROCEDURE RetunNameAndLastNameOfLib
AS
SELECT TOP 1 Libs.FirstName, Libs.LastName
FROM Libs JOIN StudentCards on Libs.Id = StudentCards.LibFk
GROUP BY Libs.FirstName, Libs.LastName
ORDER BY COUNT(StudentCards.Id) DESC
GO

EXEC RetunNameAndLastNameOfLib

-- 3
-- �������� �������� ���������, �������������� ��������� �����.

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'GetFactorialOfNumber' AND type = 'P')
	DROP PROCEDURE GetFactorialOfNumber;
GO

CREATE PROCEDURE GetFactorialOfNumber @number int, @factorial int OUTPUT
AS
BEGIN
	DECLARE @i int = 1;
	SET @factorial = 1;

	WHILE @i <= @number
	BEGIN
		SET @factorial = @factorial * @i;
		SET @i = @i + 1;
	END;
END;
GO

DECLARE @Factorial int;
EXEC GetFactorialOfNumber 5, @factorial OUTPUT;
SELECT @Factorial AS Factorial
GO

-- ������� --

-- 1
-- �������, ������������ ���-�� ���������, ������� �� ����� �����.

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'StudentsWhoDontTakeBooks' AND type = 'FN')
	DROP FUNCTION StudentsWhoDontTakeBooks;
GO

CREATE FUNCTION StudentsWhoDontTakeBooks()
RETURNS int
AS
BEGIN
	DECLARE @result int;

	SELECT @result = COUNT(Students.Id)
	FROM Students FULL OUTER JOIN StudentCards ON StudentCards.StudentFk = Students.Id
	WHERE StudentFk IS NULL;

	RETURN @result;  
END;
GO

DECLARE @result int;
EXEC @result = StudentsWhoDontTakeBooks;
SELECT @result AS Result;

SELECT dbo.StudentsWhoDontTakeBooks() AS Result;


-- 2
-- �������, ������������ ����������� �� ���� ���������� ����������.

------  ��������������� ������� ------
IF EXISTS (SELECT * FROM sys.objects WHERE name = 'GetMinOfTwo' AND type = 'FN')
	DROP FUNCTION GetMinOfTwo;
GO

CREATE FUNCTION GetMinOfTwo(@one int, @two int)
RETURNS int
AS 
BEGIN
	IF @one > @two
		SET @one = @two;
	RETURN @one;
END;
GO

select dbo.GetMinOfTwo(1, 2);
------ ����� ��������������� ������� ------

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'GetMinOfThreeParam' AND type = 'FN')
	DROP FUNCTION GetMinOfThreeParam;
GO

CREATE FUNCTION GetMinOfThreeParam(@one int, @two int, @three int)
RETURNS int
AS
BEGIN
	DECLARE @result int = @one;
	SET @result = dbo.GetMinOfTwo(@one, @two);
	SET @result = dbo.GetMinOfTwo(@result, @three);

	RETURN @result;
END;
GO

SELECT dbo.GetMinOfThreeParam(10, 2, 5);
SELECT dbo.GetMinOfThreeParam(2, 10, 5);
SELECT dbo.GetMinOfThreeParam(10, 5, 2);


-- 3
-- �������, ������� ��������� � �������� ��������� ������������� �����
-- � ���������� ����� �� �������� ������, ���� ��� �����.
-- (����������� % - ������� � �������. ��������: 57 % 10 = 7.)

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'LargerDischarge' AND type = 'FN')
	DROP FUNCTION LargerDischarge;
GO

CREATE FUNCTION LargerDischarge(@number int)
RETURNS int
AS
BEGIN
	DECLARE @result int = @number / 10;
	DECLARE @temp int = @number % 10;
	SET @result = dbo.GetMinOfTwo(@result, @temp);

	IF @number > 99
		SET @result = NULL;

	RETURN @result;
END;
GO

SELECT dbo.LargerDischarge(324);
SELECT dbo.LargerDischarge(32);
SELECT dbo.LargerDischarge(23);


-- 4
-- �������, ������������ ���-�� ������ ���� �� ������ �� ����� �
-- �� ������ �� ������ (departments).

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'ReturnCountOfBooksEachGroupsAndDepartments' AND type = 'FN')
	DROP FUNCTION ReturnCountOfBooksEachGroupsAndDepartments;
GO

CREATE FUNCTION ReturnCountOfBooksEachGroupsAndDepartments()
RETURNS TABLE
AS
RETURN
	(SELECT Groups.Name AS [Group & Departments], COUNT(*) AS [Count]
	 FROM StudentCards join Students on StudentFk = students.Id join Groups on GroupFk = Groups.Id
	 GROUP BY Groups.Name
	 union
	 SELECT  Departments.Name, COUNT(*)
	 FROM TeacherCards join Teachers on TeacherFk = Teachers.Id join Departments on DepartmentFk = Departments.Id
	 GROUP BY Departments.Name)
GO

SELECT *
from ReturnCountOfBooksEachGroupsAndDepartments();


-- 5
--  �������, ������������ ������ ����, ���������� ������ ���������
--  (��������, ��� ������, ������� ������, ��������, ���������),
--  � ��������������� �� ������ ����, ���������� � 5-� ���������,
--  � �����������, ��������� � 6-� ���������.

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'GetListOfBooksWithSort')
	DROP FUNCTION GetListOfBooksWithSort;
GO

CREATE FUNCTION GetListOfBooksWithSort(@FirstName varchar(50), @LastName varchar(50), @Theme varchar(50), @Category varchar(50)) 
RETURNS @result TABLE 
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	AuthorFirstName nvarchar(50),
	AuthorLastName nvarchar(50),
	ThemeOfBook nvarchar(50),
	CategoryOfBook nvarchar(50)
)
AS 
BEGIN
	INSERT INTO @result 
		SELECT Authors.FirstName, Authors.LastName, Themes.Name AS Themes, Categories.Name AS Categories
		FROM Books 
		join Authors on AuthorFk = Authors.Id 
		join Themes on ThemeFk = Themes.Id 
		join Categories on CategoryFk = Categories.Id
		WHERE Authors.FirstName = @FirstName
		AND Authors.LastName = @LastName
		AND Themes.Name = @Theme
		AND Categories.Name = @Category
	RETURN;
END;
GO

DECLARE @AuthorFristName varchar(50) = '������';
DECLARE @AuthorLastName varchar(50) = '�����';
DECLARE @BooksTheme  varchar(50) = '����������� ������';
DECLARE @BookCategory varchar(50) = '3D Studio Max';

select *
from GetListOfBooksWithSort(@AuthorFristName, @AuthorLastName, @BooksTheme, @BookCategory);


-- 6
-- �������, ������� ���������� ������ ������������� � ���-�� ��������
-- ������ �� ��� ����.

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'GetListOfLibsAndCountOfBooks' AND type = 'IF')
	DROP FUNCTION GetListOfLibsAndCountOfBooks;
GO

CREATE FUNCTION GetListOfLibsAndCountOfBooks()
RETURNS TABLE
AS
RETURN
	(SELECT Libs.FirstName AS [First name], COUNT(*) AS [Count]
	 FROM Libs join StudentCards on Libs.Id = StudentCards.LibFk join TeacherCards on TeacherCards.LibFk = Libs.Id
	 GROUP BY Libs.FirstName);
GO

SELECT *
FROM dbo.GetListOfLibsAndCountOfBooks();