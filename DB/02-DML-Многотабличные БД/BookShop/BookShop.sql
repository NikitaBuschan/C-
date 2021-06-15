IF DB_ID('Shop') IS NOT NULL
BEGIN
	USE master
    ALTER DATABASE Shop SET single_user with rollback immediate;
    DROP DATABASE Shop;
END
GO

CREATE DATABASE Shop
GO

USE Shop
GO

CREATE TABLE Formats
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Format] nvarchar(50)
);

CREATE TABLE Authors
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Born date,
	Died date,
	Country nvarchar(50)
);

CREATE TABLE Themes
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50)
);

CREATE TABLE Categories
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50)
);

CREATE TABLE Books
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Code int NOT NULL,
	[Name] nvarchar(50),
	Price bigint,
	Pages int NOT NULL,
	New bit,
	Pressrun int,
	[Date] date,
	Format_Fk bigint NOT NULL,
	Category_Fk bigint NOT NULL,
	Author_Fk bigint NOT NULL,
	Themes_Fk bigint NOT NULL,

	FOREIGN KEY (Format_Fk) REFERENCES Formats(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (Category_Fk) REFERENCES Categories(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (Author_Fk) REFERENCES Authors(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (Themes_Fk) REFERENCES Themes(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

CREATE TABLE [Owners]
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Phone nvarchar(15)
);

CREATE TABLE Discounts
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Percent] smallint
);

CREATE TABLE [Cards]
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Number bigint,
	Owner_Fk bigint,
	Discount_Fk bigint,

	FOREIGN KEY (Owner_Fk) REFERENCES [Owners](Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (Discount_Fk) REFERENCES Discounts(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

CREATE TABLE PhoneQRCode
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Image] bigint,
	Card_Fk bigint,

	FOREIGN KEY (Card_Fk) REFERENCES Cards(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

CREATE TABLE Taxes
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Number bigint,
	[Percent] smallint
);

CREATE TABLE Sellers
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FirstName nvarchar(50),
    LastName nvarchar(50)
);

CREATE TABLE Stocks
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	DiscountPercent smallint,
	DaysLeft date
);

CREATE TABLE Buyers
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50),
	Phone nvarchar(15),
	Sex bit
);

CREATE TABLE [Types]
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50)
);

CREATE TABLE Sales
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ReceiptNumber bigint,
	SalesNumberOfDay bigint,
	CashReceived bigint,
	[Count] bigint,
	[Date] date,
	Seller_Fk bigint,
	Book_Fk bigint,
	TypeOfPayment_Fk bigint,
	Tax_Fk bigint,
	Discount_Fk bigint,
	Buyer_Fk bigint,
	Stock_Fk bigint,

	FOREIGN KEY (Seller_Fk) REFERENCES Sellers(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (Book_Fk) REFERENCES Books(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (TypeOfPayment_Fk) REFERENCES [Types](Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (Tax_Fk) REFERENCES Taxes(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (Discount_Fk) REFERENCES Discounts(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (Buyer_Fk) REFERENCES Buyers(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (Stock_Fk) REFERENCES Stocks(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

CREATE TABLE Cityes
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50),
	Adress nvarchar(50)
);

CREATE TABLE Shop
(
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(50),
	City_Fk bigint,
	Sales_Fk bigint,

	FOREIGN KEY (City_Fk) REFERENCES Cityes(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (Sales_Fk) REFERENCES Sales(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);


INSERT INTO Formats VALUES
('(100-130)×(140-177)'),
('(130-145)×(200-215)')

INSERT INTO Authors VALUES
('Иван','Тургенев','1818-11-09', '1883-09-03', 'Россия'),
('Александр', 'Беляев', '1884-03-16', '1942-01-06', 'Россия')

INSERT INTO Themes VALUES
('Фантастика'),
('Роман')

INSERT INTO Categories VALUES
('Учебник'),
('Литература')

INSERT INTO Books
(
Code,
[Name],
Price,
Pages,
New,
Pressrun,
[Date],
Format_Fk,
Category_Fk,
Author_Fk,
Themes_Fk
) VALUES
(2341, 'Отцы и дети', 350, 240, 1, 15000, '1862-02-01', 1, 2, 1, 2),
(4654, 'Хождение по мукам', 413, 480, 1, 20000, '1852-01-01', 2, 2, 1, 2)

INSERT INTO [Owners] (FirstName, LastName, Phone) VALUES
('Никита', 'Бущан', '+023913723483'),
('Костя', 'Дзю', '+02455980245'),
('Петя', 'Полухин', '+38023423498612')

INSERT INTO Discounts (	[Percent]) VALUES
(3),
(5),
(10),
(20)

INSERT INTO [Cards](
Number,
Owner_Fk,
Discount_Fk
) VALUES
(2435735543576, 1, 2),
(3563522343448, 2, 3),
(029345872309, 3, 1)

INSERT INTO PhoneQRCode(
[Image],
Card_Fk
) VALUES
(1, 1),
(2, 2),
(3,3)

INSERT INTO Taxes(Number, [Percent]) VALUES
(52345345, 20)

INSERT INTO  Sellers(FirstName, LastName) VALUES
('Костя', 'Тисовский'),
('Коля', 'Куришин'),
('Алина', 'Крикунова'),
('Катя', 'Остапчук')

INSERT INTO Stocks(DiscountPercent, DaysLeft) VALUES
(5, '2020-04-14'),
(15, '2020-03-20'),
(10, '2020-05-02')

INSERT INTO  Buyers(Name, Phone, Sex) VALUES
('Николай', '0932234643', 1),
('Константин', '0936598565', 1),
('Гоша', '0943747855', 1),
('Георгий', '0956786787', 1),
('Василий', '0932474356', 1),
('Пётр', '0935768356', 1),
('Евгений', '0938965643', 1),
('Илья', '0934567983', 1),
('Мария', '0932234643', 2),
('Александра', '0935345793', 2)

INSERT INTO [Types]([Name]) VALUES
('Наличный'),
('Безналичный')

INSERT INTO Sales(
ReceiptNumber, 
SalesNumberOfDay,
CashReceived,
[Count],
[Date],
Seller_Fk,
Book_Fk,
TypeOfPayment_Fk,
Tax_Fk,
Discount_Fk,
Buyer_Fk,
Stock_Fk) VALUES
(2378234509, 01, 780, 2, '2020-03-12', 1, 2, 1, 1, 2, NULL, NULL),
(2378234342, 02, 521, 1, '2020-03-12', 2, 1, 2, 1, 1, 1, 1)

INSERT INTO Cityes([Name], Adress) VALUES
('Одесса', 'Гоголя 2а'),
('Киев', 'площадь Морселя 75'),
('Николаев', 'Атамана Головатого 5')

INSERT INTO Shop([Name], City_Fk, Sales_Fk) VALUES
('Азбука', 1, 1),
('Азбука', 2, 2)

SELECT *
FROM Sales