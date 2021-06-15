USE Library
GO

-- 8

USE Shop
GO

ALTER TABLE Cityes ADD Country nvarchar(50)

UPDATE Cityes SET Country = 'Россия'

CREATE VIEW OuthorsAndCityes
AS
select Authors.FirstName, Authors.LastName, Authors.Country 
from Shop 
join Sales on Shop.Sales_Fk = Sales.Id 
join Books on Sales.Book_Fk = Books.Id 
join Authors on Books.Author_Fk = Authors.Id 
join Cityes on Shop.City_Fk = Cityes.Id
where Cityes.Country = Authors.Country

select *
from OuthorsAndCityes

-- 9

ALTER TABLE Books ADD Price Money

declare @i int, @p int
set @i = 1;
set @p = 100;

while @i <= (select COUNT(Books.Id) from Books)
	BEGIN
		UPDATE Books SET Books.Price = @p WHERE Books.id = @i
		SET @p = @p + 25
		SET @i = @i + 1
	END;


CREATE VIEW BooksWithMaxPriceInEachThemes
AS
select Themes.Id, Themes.Name, (select Books.Name from books where books.Price in (select MAX(Books.Price) from books where books.ThemeFk = Themes.Id)) AS [Book name]
from Themes join Books on Books.ThemeFk = Themes.Id
group by Themes.Id, Themes.Name


-- 10

USE Shop
GO

CREATE VIEW WorkMagazine
AS
select Shop.Name as [Shop Name], Cityes.Name as City
from Shop join Cityes on City_Fk = Cityes.Id
Order by Shop.Name, Cityes.Name desc
OFFSET 0 rows


-- 11

USE MyLibrary
GO

CREATE VIEW MostPopularBook ([Name], Pages, Price)
AS
select [Name], Pages, Price
from Books

select *
from MostPopularBook



-- 12

CREATE VIEW AuthorsWhosNameStartOnAAndB
AS
SELECT *
FROM Authors
WHERE Authors.Name like 'А%' OR Authors.Name like 'Б%'

select *
from AuthorsWhosNameStartOnAAndB


-- 13

CREATE VIEW BooksWhosDontPrintInMyPresses
AS
SELECT *
FROM Books
WHERE PressFk = (SELECT Presses.Id FROM Presses WHERE Presses.Name <> 'ACT' AND Presses.Id = PressFk)


select *
from BooksWhosDontPrintInMyPresses

