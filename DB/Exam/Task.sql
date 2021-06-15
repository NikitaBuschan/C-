USE Football
GO

IF OBJECT_ID('ClearTables') IS NOT NULL
    DROP PROCEDURE ClearTables;
GO

CREATE PROCEDURE ClearTables
AS
BEGIN
	DECLARE @i int = (select COUNT(*) from Matches)
	WHILE (@i > 0)
	BEGIN
		DELETE TOP(1)
		FROM Matches
		WHERE ID = @i;
		SET @i = @i - 1;
	END;
	SET @i = (select COUNT(*) from Penaltes)
	WHILE (@i > 0)
	BEGIN
		DELETE TOP(1)
		FROM Penaltes
		WHERE ID = @i;
		SET @i = @i - 1;
	END;
	SET @i = (select COUNT(*) from Goals)
	WHILE (@i > 0)
	BEGIN
		DELETE TOP(1)
		FROM Goals
		WHERE ID = @i;
		SET @i = @i - 1;
	END;
	SET @i = (select COUNT(*) from Foals)
	WHILE (@i > 0)
	BEGIN
		DELETE TOP(1)
		FROM Foals
		WHERE ID = @i;
		SET @i = @i - 1;
	END;
	SET @i = (select COUNT(*) from Scores)
	WHILE (@i > 0)
	BEGIN
		DELETE TOP(1)
		FROM Scores
		WHERE ID = @i;
		SET @i = @i - 1;
	END;
END;
GO

IF OBJECT_ID('ReplayChampionship') IS NOT NULL
    DROP PROCEDURE ReplayChampionship;
GO

CREATE PROCEDURE ReplayChampionship
AS
BEGIN
	EXEC ClearTables
	EXEC PlayChampionship
END;
GO

-- EXEC ReplayChampionship
-- GO

-----------------------------------------
--------------- Inquiries ---------------
-----------------------------------------

-- 1. Общее количество голов, забитых на протяжении чемпионата

select COUNT(*) AS [Count of goals] from Goals

-- 2. Среднее количество голов в каждом матче

select CAST((select COUNT(*) AS [Count of goals] from Goals) / 
			(select COUNT(*) AS [Count of matches] from Matches) AS float) AS [Average count of goals in each match]

-- 3. Наибольшее и наименьшее количество мячей, забитых командами (2 команды)

select TOP(2) (select Name from Countries where ID = Team) AS [Team], COUNT(*) AS [Count of goals] 
from Goals join Teams ON Goals.Team = Teams.ID
Group by Team
ORDER BY [Count of goals] DESC

select TOP(2) (select Name from Countries where ID = Team) AS [Team], COUNT(*) AS [Count of goals] 
from Goals join Teams ON Goals.Team = Teams.ID
group by Team
ORDER BY [Count of goals] ASC

-- 4. Наибольшее и наименьшее количество мячей, пропущенных
-- командами (2 команды)

select TOP(2) (select Countries.Name from Teams join Countries ON Teams.Country_FK = Countries.ID where Teams.ID = A.ID) AS [Team], SUM(A.CountOfGoals) AS [Count of missed goals]
from (select Teams.ID, SUM(Scores.FirstTeam) AS CountOfGoals
from Teams join Matches ON Matches.SecondTeam_FK = Teams.ID join Scores ON Match_FK = Matches.ID
GROUP BY Teams.ID
UNION
select Teams.ID, SUM(Scores.FirstTeam) AS CountOfGoals
from Teams join Matches ON Matches.FirstTeam_FK = Teams.ID join Scores ON Match_FK = Matches.ID
GROUP BY Teams.ID) A
GROUP BY A.ID
ORDER BY [Count of missed goals] DESC

select TOP(2) (select Countries.Name from Teams join Countries ON Teams.Country_FK = Countries.ID where Teams.ID = A.ID) AS [Team], SUM(A.CountOfGoals) AS [Count of missed goals]
from (select Teams.ID, SUM(Scores.FirstTeam) AS CountOfGoals
from Teams join Matches ON Matches.SecondTeam_FK = Teams.ID join Scores ON Match_FK = Matches.ID
GROUP BY Teams.ID
UNION
select Teams.ID, SUM(Scores.FirstTeam) AS CountOfGoals
from Teams join Matches ON Matches.FirstTeam_FK = Teams.ID join Scores ON Match_FK = Matches.ID
GROUP BY Teams.ID) A
GROUP BY A.ID
ORDER BY [Count of missed goals] ASC

-- 5. Суммарная посещаемость всех матчей

select SUM(CountOfFans) AS [Count of fans in all matches] from Matches

-- 6. Средняя посещаемость одного матча

select ((select SUM(CountOfFans) AS [Count of fans in all matches] from Matches) / 
		(select COUNT(*) from Matches)) AS [Average of fans in one match]

-- 7. Наибольшее и наименьшее число побед (2 отличившиеся команды)

select TOP(2) (select Countries.Name from Teams join Countries ON Teams.Country_FK = Countries.ID where Teams.ID = A.ID) AS [Team], SUM(A.[Count of wins]) AS [Count of wins]
from (select Teams.ID, COUNT(*) AS [Count of wins]
from Matches join Scores ON Scores.Match_FK = Matches.ID join Teams ON Teams.ID = FirstTeam_FK 
where Scores.FirstTeam > Scores.SecondTeam
GROUP BY Teams.ID
UNION
select Teams.ID, COUNT(*) AS [Count of wins]
from Matches join Scores ON Scores.Match_FK = Matches.ID join Teams ON Teams.ID = SecondTeam_FK 
where Scores.FirstTeam < Scores.SecondTeam
GROUP BY Teams.ID) A
GROUP BY A.ID
ORDER BY [Count of wins] DESC

select TOP(2) (select Countries.Name from Teams join Countries ON Teams.Country_FK = Countries.ID where Teams.ID = A.ID) AS [Team], SUM(A.[Count of wins]) AS [Count of wins]
from (select Teams.ID, COUNT(*) AS [Count of wins]
from Matches join Scores ON Scores.Match_FK = Matches.ID join Teams ON Teams.ID = FirstTeam_FK 
where Scores.FirstTeam > Scores.SecondTeam
GROUP BY Teams.ID
UNION
select Teams.ID, COUNT(*) AS [Count of wins]
from Matches join Scores ON Scores.Match_FK = Matches.ID join Teams ON Teams.ID = SecondTeam_FK 
where Scores.FirstTeam < Scores.SecondTeam
GROUP BY Teams.ID) A
GROUP BY A.ID
ORDER BY [Count of wins] ASC

-- 8. Наибольшее и наименьшее количество поражений (2 команды)

select TOP(2) (select Countries.Name from Teams join Countries ON Teams.Country_FK = Countries.ID where Teams.ID = A.ID) AS [Team], SUM(A.[Count of loses]) AS [Count of loses]
from (select Teams.ID, COUNT(*) AS [Count of loses]
from Matches join Scores ON Scores.Match_FK = Matches.ID join Teams ON Teams.ID = FirstTeam_FK 
where Scores.FirstTeam < Scores.SecondTeam
GROUP BY Teams.ID
UNION
select Teams.ID, COUNT(*) AS [Count of loses]
from Matches join Scores ON Scores.Match_FK = Matches.ID join Teams ON Teams.ID = SecondTeam_FK 
where Scores.FirstTeam > Scores.SecondTeam
GROUP BY Teams.ID) A
GROUP BY A.ID
ORDER BY [Count of loses] DESC

select TOP(2) (select Countries.Name from Teams join Countries ON Teams.Country_FK = Countries.ID where Teams.ID = A.ID) AS [Team], SUM(A.[Count of loses]) AS [Count of loses]
from (select Teams.ID, COUNT(*) AS [Count of loses]
from Matches join Scores ON Scores.Match_FK = Matches.ID join Teams ON Teams.ID = FirstTeam_FK 
where Scores.FirstTeam < Scores.SecondTeam
GROUP BY Teams.ID
UNION
select Teams.ID, COUNT(*) AS [Count of loses]
from Matches join Scores ON Scores.Match_FK = Matches.ID join Teams ON Teams.ID = SecondTeam_FK 
where Scores.FirstTeam > Scores.SecondTeam
GROUP BY Teams.ID) A
GROUP BY A.ID
ORDER BY [Count of loses] ASC

-- 9. Лучшие бомбардиры (игроки, забившие наибольшее количество голов)

select TOP(5) (select [Name] from Players where ID = Goals.Player_FK) AS [Player name], COUNT(*) AS [Count of Goals]
from Goals
GROUP BY Player_FK
ORDER BY [Count of Goals] DESC

-- 10. Список команд, занявших призовые места

select *
from(
select *
from (
select (select Name from Countries join Teams ON Countries.ID = Teams.Country_FK where Teams.ID = FirstTeam_FK) AS [Top teams]
from Matches join Teams ON Matches.FirstTeam_FK = Teams.ID join Scores ON Scores.Match_FK = Matches.ID 
where Matches.ID = (select MAX(ID) from Matches) AND Scores.FirstTeam > Scores.SecondTeam
UNION
select (select Name from Countries join Teams ON Countries.ID = Teams.Country_FK where Teams.ID = SecondTeam_FK) AS [Top teams]
from Matches join Teams ON Matches.SecondTeam_FK = Teams.ID join Scores ON Scores.Match_FK = Matches.ID 
where Matches.ID = (select MAX(ID) from Matches) AND Scores.FirstTeam < Scores.SecondTeam) A
UNION
select *
from (
select (select Name from Countries join Teams ON Countries.ID = Teams.Country_FK where Teams.ID = FirstTeam_FK) AS [Top teams]
from Matches join Teams ON Matches.FirstTeam_FK = Teams.ID join Scores ON Scores.Match_FK = Matches.ID 
where Matches.ID = (select MAX(ID) from Matches) AND Scores.FirstTeam < Scores.SecondTeam
UNION
select (select Name from Countries join Teams ON Countries.ID = Teams.Country_FK where Teams.ID = SecondTeam_FK) AS [Top teams]
from Matches join Teams ON Matches.SecondTeam_FK = Teams.ID join Scores ON Scores.Match_FK = Matches.ID 
where Matches.ID = (select MAX(ID) from Matches) AND Scores.FirstTeam > Scores.SecondTeam) A
UNION
select *
from (
select (select Name from Countries join Teams ON Countries.ID = Teams.Country_FK where Teams.ID = FirstTeam_FK) AS [Top teams]
from Matches join Teams ON Matches.FirstTeam_FK = Teams.ID join Scores ON Scores.Match_FK = Matches.ID 
where Matches.ID = (select MAX(ID) - 1 from Matches) AND Scores.FirstTeam > Scores.SecondTeam
UNION
select (select Name from Countries join Teams ON Countries.ID = Teams.Country_FK where Teams.ID = SecondTeam_FK) AS [Top teams]
from Matches join Teams ON Matches.SecondTeam_FK = Teams.ID join Scores ON Scores.Match_FK = Matches.ID 
where Matches.ID = (select MAX(ID) - 1 from Matches) AND Scores.FirstTeam < Scores.SecondTeam) A) B