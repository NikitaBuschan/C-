USE Books
GO

INSERT INTO Authors([Name]) VALUES
(N'������ ����������'),
(N'��������'),
(N'�����������'),
(N'��������')
GO

INSERT INTO Presses([Name]) VALUES
(N'BB'),
(N'AA'),
(N'PP')
GO

INSERT INTO Books([Name], Author_FK, Presses_FK) VALUES
(N'������', 1, 1),
(N'����', 1, 2),
(N'��� ����', 1, 3),
(N'���', 2, 1),
(N'���', 3, 1),
(N'�����', 4, 1)
GO

