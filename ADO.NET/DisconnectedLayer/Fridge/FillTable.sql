USE Fridges
GO

INSERT INTO Companies([Name]) VALUES
(N'Samsung'),
(N'Apple'),
(N'Tesla')
GO

INSERT INTO Colors([Name]) VALUES
(N'Red'),
(N'Black'),
(N'White'),
(N'Metallic')
GO

INSERT INTO Sellers([Name], Age) VALUES
(N'Иван', 20),
(N'Юлия', 22),
(N'Фёдр', 30),
(N'Елена', 18)
GO

INSERT INTO Fridges(Model, Company_FK, Color_FK, Cost) VALUES
(N'X', 1, 1, 2000),
(N'X1', 1, 2, 5300),
(N'X2', 1, 3, 2700),
(N'X3', 1, 4, 7290),
(N'Y4', 2, 1, 9000),
(N'X5', 2, 2, 9200),
(N'X6', 2, 3, 9500),
(N'X7', 2, 4, 9700),
(N'X8', 3, 1, 28000),
(N'X9', 3, 1, 22000),
(N'XX', 3, 2, 21000),
(N'XX1', 3, 3, 25000),
(N'XX2', 3, 3, 276000),
(N'XX3', 3, 4, 21000),
(N'XX4', 1, 1, 223000),
(N'XXV', 2, 1, 2000)
GO