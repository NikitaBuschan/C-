USE Library
GO

-- 1
-- ���������� ����� � ����������� ����������� �������, 
-- �������-��� ��� ��� ���� �������������.

SELECT Presses.Name, MIN(Books.Pages)
FROM Presses JOIN Books ON Presses.Id = Books.PressFk
GROUP BY Presses.Name
ORDER BY MIN(Books.Pages)

-- 2
-- ���������� �������� �����������, 
-- ������� ��������� ����� �� ������� 
-- ����������� ������� ������� 100.

SELECT Presses.Name, AVG(Books.Pages)
FROM Presses JOIN Books ON Presses.Id = Books.PressFk
GROUP BY Presses.Name
HAVING AVG(Books.Pages) > 100;

-- 3
-- ������� ����� ����� ������� ���� ��������� � ���������� ����, 
-- ���������� �������������� BHV � �����.

SELECT Presses.Name, SUM(Books.Pages)
FROM Presses JOIN Books ON Presses.Id = Books.PressFk
WHERE Presses.Name = 'BHV' OR Presses.Name = '�����'
GROUP BY Presses.Name

-- 4
-- ������� ����� � ������� ���� ���������, 
-- ������� ����� ����� � ���������� ����� 1 ������ 2001 ���� � ������� �����.

-- 1 --
SELECT Students.FirstName, Students.LastName
FROM Students JOIN StudentCards ON Students.Id = StudentCards.StudentFk
WHERE StudentCards.DateOut > '2001-01-01' AND StudentCards.DateOut < GETDATE()

-- 2 --
SELECT  Students.FirstName, Students.LastName
FROM Students
WHERE Students.Id = 
	(SELECT StudentCards.StudentFk 
	 FROM StudentCards 
	 WHERE StudentCards.StudentFk = Students.Id AND
		   StudentCards.DateOut > '2001-01-01' AND StudentCards.DateOut < GETDATE())

-- 5
-- ����� ���� ���������, ��� �� ������ ������ ��������
-- � ������ "������ Windows 2000" ������ ����� ��������.

SELECT *
FROM Students
WHERE Students.Id = 
	(SELECT StudentCards.StudentFk
	 FROM StudentCards
	 WHERE StudentCards.StudentFk = Students.Id AND
		   StudentCards.BookFk = 
				(SELECT Books.Id
				 FROM Books
				 WHERE Books.Name = '������ Windows 2000' AND 
				       Books.AuthorFk = 
						(SELECT Authors.Id 
						 FROM Authors 
						 WHERE Authors.FirstName = '�����' AND 
							   Authors.LastName = '��������')))

-- 6
-- ���������� ���������� �� �������, 
-- ������� ����� ���� ������� (� ���������) ����� 600 �������.

SELECT *
FROM Authors
WHERE Authors.Id = 
	(SELECT a.Id
	 FROM Authors AS a JOIN Books ON a.Id = Books.AuthorFk
	 WHERE a.Id = Authors.Id
	 GROUP BY a.Id
	 HAVING SUM(Books.Pages) > 600)

-- 7
-- ���������� ���������� �� �������������, 
-- � ������� ����� ����-������ ������� ���������� ��� ���� ������ 700.

SELECT *
FROM Presses
WHERE Presses.Id = 
	(SELECT p.Id
	 FROM Presses AS p JOIN Books ON p.Id = Books.PressFk
	 WHERE p.Id = Presses.Id
	 GROUP BY p.Id
	 HAVING SUM(Books.Pages) > 700)

-- 8
-- ���������� ���� ����������� ���������� 
-- (� ��������� � �������-�������) � �����, ������� ��� �����.

SELECT Students.Id, Students.FirstName, Students.LastName, Books.Name, Books.Pages, StudentCards.DateIn, StudentCards.DateOut
FROM Students JOIN StudentCards ON Students.Id = StudentCards.StudentFk JOIN Books ON Books.Id = StudentCards.BookFk
WHERE StudentCards.BookFk = 
	(SELECT Books.Id
	 FROM Books
	 WHERE Books.Id = StudentCards.BookFk)

-- 9
-- ������� ������ ����������� ������(��) ����� ��������� 
-- � ������-���� ���� ����� ������, ������ � ����������.

SELECT TOP 1 Authors.FirstName, Authors.LastName, COUNT(AuthorS.FirstName)
FROM Authors JOIN Books ON Books.AuthorFk = Authors.Id JOIN StudentCards ON StudentCards.BookFk = Books.Id
GROUP BY Authors.FirstName, Authors.LastName

-- 10
-- ������� ������ ����������� ������(��) ����� �����������-���
-- � ���������� ���� ����� ������, ������ � ����������.

SELECT TOP 1 Authors.FirstName, Authors.LastName, COUNT(AuthorS.FirstName)
FROM Authors JOIN Books ON Books.AuthorFk = Authors.Id JOIN TeacherCards ON TeacherCards.BookFk = Books.Id
GROUP BY Authors.FirstName, Authors.LastName

-- 11
-- ������� ����� ����������(��) ��������(�)
-- ����� ��������� � ��������������.

SELECT TOP 1 Themes.Name, COUNT(Themes.Name) AS [Count]
FROM StudentCards JOIN Books ON StudentCards.BookFk = Books.Id 
				  JOIN TeacherCards ON TeacherCards.BookFk = Books.Id 
				  JOIN Themes ON Books.ThemeFk = Themes.Id
GROUP BY Themes.Name

-- 12
-- ���������� ���������� �������������� � ���������,
-- ����-������ ����������.

SELECT 
(SELECT COUNT(StudentCards.Id) FROM StudentCards) AS Students,
(SELECT COUNT(TeacherCards.Id) FROM TeacherCards) AS Teachers

-- 13
-- ���� ������� ����� ���������� ���� � ���������� �� 100%, 
-- �� ���������� ����������, ������� ���� (� ���������� ���������) ���� ������ ���������.

SELECT Faculties.Name AS [Faculties], COUNT(StudentCards.BookFk) * 100 / (SELECT COUNT(Books.Name) FROM Books) AS [Percents]
FROM StudentCards JOIN Students ON StudentFk = Students.Id JOIN Groups ON Groups.Id = GroupFk JOIN Faculties ON Faculties.Id = FacultyFk
GROUP BY Faculties.Name

-- 14
-- ���������� ����� �������� ��������� � ����� �������� �������.

SELECT 
	(SELECT TOP 1 Faculties.Name
	 FROM Books JOIN StudentCards ON Books.Id = StudentCards.BookFk 
		   	    JOIN Students ON StudentCards.StudentFk = Students.Id 
		 	    JOIN Groups ON Students.GroupFk = Groups.Id 
				JOIN Faculties ON Groups.FacultyFk = Faculties.Id
	 GROUP BY Faculties.Name
	 ORDER BY COUNT(Books.Id) DESC)  AS Faculties,
	(SELECT TOP 1 Departments.Name 
	 FROM Books JOIN TeacherCards ON Books.Id = TeacherCards.BookFk 
				JOIN Teachers ON TeacherCards.TeacherFk = Teachers.Id 
				JOIN Departments ON Teachers.DepartmentFk = Departments.Id
	 GROUP BY Departments.Name
	 ORDER BY COUNT(Books.Id) DESC) AS Department

-- 15
-- �������� ������ (��) ����� ���������� ���� ����� �������-������� � ���������.

SELECT TOP 1 Authors.FirstName, Authors.LastName
FROM StudentCards JOIN Books ON StudentCards.BookFk = Books.Id 
				  JOIN TeacherCards ON TeacherCards.BookFk = Books.Id 
				  JOIN Authors ON Books.AuthorFk = Authors.Id
GROUP BY Authors.FirstName, Authors.LastName
ORDER BY COUNT(Books.Id)

-- 16
-- ���������� �������� ����� ���������� ���� ����� �������-������� � ���������.

SELECT TOP 3 Books.Name
FROM StudentCards JOIN Books ON StudentCards.BookFk = Books.Id 
				  JOIN TeacherCards ON TeacherCards.BookFk = Books.Id 
				  JOIN Authors ON Books.AuthorFk = Authors.Id
GROUP BY Books.Name
ORDER BY COUNT(Books.Id) DESC

-- 17
-- �������� ���� ��������� � �������������� ����������.


SELECT * 
FROM Students JOIN Groups ON GroupFk = Groups.Id
					  JOIN Faculties ON Groups.FacultyFk = Faculties.Id
WHERE Faculties.Name = '���-�������'

SELECT * 
FROM Teachers JOIN Departments ON Teachers.DepartmentFk = Departments.Id
WHERE Departments.Name = '������� � �������'


SELECT *
FROM 
Students JOIN Groups ON GroupFk = Groups.Id
		 JOIN Faculties ON Groups.FacultyFk = Faculties.Id, 
Teachers JOIN Departments ON Teachers.DepartmentFk = Departments.Id
WHERE Faculties.Name = '���-�������' OR  Departments.Name = '������� � �������'

SELECT *
FROM 


