USE Books
GO

INSERT INTO Authors([Name]) VALUES
(N'Братья Стругацкие'),
(N'Тургенев'),
(N'Достаевский'),
(N'Булгаков')
GO

INSERT INTO Presses([Name]) VALUES
(N'BB'),
(N'AA'),
(N'PP')
GO

INSERT INTO Books([Name], Author_FK, Presses_FK) VALUES
(N'Привет', 1, 1),
(N'Пока', 1, 2),
(N'Как дела', 1, 3),
(N'Что', 2, 1),
(N'Где', 3, 1),
(N'Когда', 4, 1)
GO

