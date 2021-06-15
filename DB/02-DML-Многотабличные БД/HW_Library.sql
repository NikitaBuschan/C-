USE Library
GO

SELECT *
FROM Themes
GO

select *
from Books

-- 1
SELECT *
FROM Books
WHERE Pages = 
	(SELECT MAX(Pages)
	FROM Books
	WHERE Pages = Books.Pages);
GO

-- 2
SELECT *
FROM Books 
WHERE Books.Pages = 
	(SELECT MAX(Pages)
	 FROM Books
	 WHERE Books.ThemeFk =
		(SELECT Id
		 FROM Themes
		 WHERE Themes.Name = 'Программирование'));
GO

-- 3
SELECT 
g.Name AS GroupName, 
s.FirstName AS FirstName, 
s.LastName AS LastName,
sc.DateIn AS DateIn, 
sc.DateOut AS DateOut
FROM 
Groups g, 
Students s, 
StudentCards sc
WHERE 
s.GroupFk = g.Id 
AND 
s.Id = sc.StudentFk
GO

-- 4
SELECT COUNT(Books.Quantity) AS CountOfBooks, SUM(Books.Pages) AS SumOfPages
FROM Students, Books, StudentCards
WHERE Students.Id = StudentCards.StudentFk AND StudentCards.BookFk = Books.Id AND Students.GroupFk = 
	(SELECT Groups.Id
	 FROM Groups JOIN Faculties ON Groups.FacultyFk = Faculties.Id
	 WHERE Faculties.Name = 'Программирования' AND Groups.Id = Students.GroupFk) AND Books.ThemeFk = 
		(SELECT Themes.Id
		 FROM Themes
		 WHERE Books.ThemeFk = Themes.Id AND (Themes.Name = 'Программирование' OR Themes.Name = 'Базы данных'))
GO

-- 4.1
SELECT  COUNT(Books.Quantity) AS CountOfBooks, SUM(Books.Pages) AS SumOfPages
FROM (((((Students 
	JOIN StudentCards ON Students.Id = StudentCards.StudentFk)
	JOIN Books ON StudentCards.BookFk = Books.Id) 
	JOIN Themes ON Themes.Id = Books.ThemeFk 
		AND (Themes.Name = 'Программирование' OR Themes.Name = 'Базы данных')
	JOIN Groups ON Students.GroupFk = Groups.Id)
	JOIN Faculties ON Groups.FacultyFk = Faculties.Id 
		AND Faculties.Name = 'Программирования'))
GO

-- 5
SELECT Students.FirstName AS Name, CAST(DATEDIFF(WEEK, StudentCards.DateOut, StudentCards.DateIn) * 0.5 AS int) AS Liters
FROM Students JOIN StudentCards ON Students.Id = StudentCards.StudentFk
WHERE StudentCards.DateIn IS NOT NULL
GO

-- 6
-- Если считать общее количество книг в библиотеке за 100%, то необходимо подсчитать
-- сколько книг (в процентном отношении) брал каждый факультет.

SELECT Faculties.Name AS [Faculties], COUNT(Books.ID) * 100 / (SELECT COUNT(Books.ID) FROM books) AS [Percent]
FROM Faculties, Groups, Students, StudentCards, Books
where Faculties.ID = Groups.FacultyFk AND
Students.GroupFk = Groups.ID AND
Students.ID = StudentCards.StudentFk AND
StudentCards.BookFk = Books.ID
GROUP BY Faculties.Name
GO

-- 7
-- Вывести самого популярного автора(ов) среди студентов.

SELECT TOP (1) Authors.FirstName, Authors.LastName 
FROM Students, StudentCards, Books, Authors
WHERE Students.ID = StudentCards.StudentFk AND
StudentCards.BookFk = Books.ID AND
Books.AuthorFk = Authors.ID
GROUP BY Authors.FirstName, Authors.LastName 
ORDER BY COUNT(Authors.ID) DESC

-- 8
-- Вывести самого популярного автора(ов) 
-- среди преподавателей и количество книг
-- этого автора, взятых в библиотеке.

SELECT TOP(1) Authors.FirstName, Authors.LastName, count(Books.ID) AS CountOfBooks
FROM TeacherCards, Books, Authors
WHERE TeacherCards.BookFk = Books.Id AND
Books.AuthorFk = Authors.Id
GROUP BY Authors.FirstName, Authors.LastName
ORDER BY COUNT(Authors.ID) DESC

-- 9
-- Вывести самого популярную(ые) тематику(и) 
-- среди студентов и преподавателей.

SELECT TOP (1) Themes.Name, COUNT(Themes.ID) 
FROM Books, StudentCards, TeacherCards, Themes
WHERE Books.Id = StudentCards.BookFk AND
	  Books.Id = TeacherCards.BookFk AND
	  Books.ThemeFk = Themes.Id
GROUP BY Themes.Name
ORDER BY COUNT(Themes.ID) DESC

-- 10
-- «Заставить» сдать книги тех студентов, 
-- которые не сдавали книги более года,
-- т.е. в таблице «Карточка студентов» (StudentCards) 
-- заполнить поле «Дата возврата»
-- (DateIn) текущей датой.

UPDATE StudentCards
SET	DateIn = GETDATE();

SELECT Students.FirstName + ' ' + Students.LastName
FROM Students JOIN StudentCards ON StudentCards.StudentFk = Students.Id
WHERE DATEDIFF(year, StudentCards.DateOut, StudentCards.DateIn ) < 1

-- 11
-- Удалить из таблицы «Карточка студентов» студентов,
-- которые уже вернули книги.

DELETE StudentCards
WHERE StudentCards.DateOut < GETDATE()














 -- 1. 
 -- Вывести информацию о книге с наибольшим количеством страниц.

 SELECT *
 FROM Books
 WHERE Books.Pages IN (SELECT MAX(Books.Pages) FROM Books)

 -- 2. 
 -- Вывести информацию о книге по программированию с наибольшим количеством страниц.

SELECT *
FROM Books
WHERE Books.Pages 
IN (SELECT MAX(Books.Pages) FROM Books WHERE Books.ThemeFk 
	IN (SELECT Themes.Id FROM Themes WHERE Themes.Name = 'Программирование'))

 -- 3. 
 -- Вывести статистику посещений библиотеки по каждой группе студентов.

 SELECT Groups.Name, COUNT(Students.Id) AS Visits
 FROM  StudentCards 
 JOIN Students ON StudentFk = Students.Id 
 JOIN Groups ON GroupFk = Groups.Id
 GROUP BY Groups.Name

 -- 4. 
 -- Вывести количество книг, взятых в библиотеке программистами по тематикам
 -- «Программирование» и «Базы данных», и сумму страниц в этих книгах.

 SELECT COUNT(Books.Id) AS [Count of books], SUM(Books.Pages) AS [Sum of pages]
 FROM Books
 WHERE 
	Books.Id IN
	(SELECT StudentCards.StudentFk FROM StudentCards WHERE StudentFk IN 
		(SELECT Students.Id FROM Students WHERE GroupFk IN 
			(SELECT GroupFk FROM Faculties WHERE Faculties.Name = 'Программирования')))
AND
	Books.ThemeFk IN 
		(SELECT Themes.Id FROM Themes WHERE Themes.Name = 'Программирование' OR Themes.Name = 'Базы данных')

 --5. Допустим, что студент имеет право держать книгу у себя дома только 1 месяц,
  --  а за каждую неделю сверх того он обязан «выставить» уважаемому библиотекарю Сергею Максименко
  --  полбутылки (емкость бутылки 0.5 л) светлого пива. Необходимо вывести сколько литров
 --   должен каждый студент, а также суммарное количество литров пива. Итоговая сумма должна
 --   округляться в большую сторону, то есть суммарное число литров должно быть целым.
  --  Используйте функции DATEDIFF и CAST.

SELECT 
Students.FirstName , 
(SELECT DATEDIFF(WEEK, StudentCards.DateOut, StudentCards.DateIn) FROM StudentCards WHERE LibFk IN (SELECT Libs.Id FROM Libs WHERE FirstName = 'Сергей' AND LastName = 'Максименко'))
FROM Students 
WHERE Students.Id IN
	(SELECT StudentFk FROM StudentCards WHERE LibFk IN
		(SELECT Libs.Id FROM Libs  WHERE FirstName = 'Сергей' AND LastName = 'Максименко'))



SELECT 

SELECT Students.FirstName
FROM Students 
WHERE Students.Id IN
	(SELECT StudentFk FROM StudentCards WHERE LibFk IN
		(SELECT Libs.Id FROM Libs  WHERE FirstName = 'Сергей' AND LastName = 'Максименко'))

SELECT DATEDIFF(WEEK, StudentCards.DateOut, StudentCards.DateIn) 
FROM StudentCards 
WHERE LibFk IN 
	(SELECT Libs.Id FROM Libs WHERE FirstName = 'Сергей' AND LastName = 'Максименко')


 --6. Если считать общее количество книг в библиотеке за 100%, то необходимо подсчитать
 --   сколько книг (в процентном отношении) брал каждый факультет.
 --7. Вывести самого популярного автора(ов) среди студентов.
 --8. Вывести самого популярного автора(ов) среди преподавателей и количество книг
--    этого автора, взятых в библиотеке.
-- 9. Вывести самого популярную(ые) тематику(и) среди студентов и преподавателей.
--10. «Заставить» сдать книги тех студентов, которые не сдавали книги более года,
--    т.е. в таблице «Карточка студентов» (StudentCards) заполнить поле «Дата возврата»
--    (DateIn) текущей датой.
--11.	Удалить из таблицы «Карточка студентов» студентов, которые уже вернули книги.