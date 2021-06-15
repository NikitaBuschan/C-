USE Football
GO

---------------------------
    --- Play groups ---
---------------------------
IF OBJECT_ID('GroupDistribution') IS NOT NULL
    DROP FUNCTION GroupDistribution;
GO

CREATE FUNCTION GroupDistribution(@one int, @two int, @three int, @four int)
RETURNS @result TABLE (firstTeam bigint, secondTeam bigint)
AS
BEGIN
	INSERT INTO @result(firstTeam, secondTeam) VALUES
	(@one, @two),
	(@three, @four),
	(@one, @three),
	(@two, @four),
	(@one, @four),
	(@two, @three)
	RETURN;
END;
GO

IF OBJECT_ID('PlayGroups') IS NOT NULL
    DROP PROCEDURE PlayGroups;
GO

CREATE PROCEDURE PlayGroups
AS
BEGIN
	DECLARE @count int = 8 * 6;
	DECLARE @iter int = 1;
	WHILE (@count > 0)
	BEGIN
		DECLARE @begin datetime = '2020-06-01T12:00:00', @end datetime = '2020-06-30T21:00:00';
		INSERT INTO Matches(
		Stadium_FK,
		Referee_FK,
		FirstTeam_FK,
		SecondTeam_FK,
		[DateTime]) VALUES
		((select RAND() * (select MAX(ID) from Stadiums) + 1),
		(select RAND() * (select MAX(ID) from Referees) + 1),
		1,
		1,
		(select CAST(CAST(@Begin AS float) + (CAST(@End AS float) - CAST(@Begin AS float)) * RAND() AS datetime)));
		SET @count = @count - 1;
	END;
	
	IF OBJECT_ID('TempTable') IS NOT NULL
		DROP TABLE TempTable;
	CREATE TABLE TempTable(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, firstTeam bigint, secondTeam bigint)
	
	SET @count = 8;
	DECLARE @a int = 1;
	DECLARE @b int = 2;
	DECLARE @c int = 3;
	DECLARE @d int = 4;
	WHILE (@count > 0)
	BEGIN
		INSERT INTO TempTable(firstTeam, secondTeam)
		SELECT * 
		FROM GroupDistribution(@a, @b, @c, @d)
	
		SET @a = @a + 4;
		SET @b = @b + 4;
		SET @c = @c + 4;
		SET @d = @d + 4;
		SET @count = @count - 1;
	END;

	SET @count = 8 * 6;
	SET @iter = 1;
	WHILE (@count > 0)
	BEGIN
		INSERT INTO Scores(firstTeam, secondTeam, Match_Fk) VALUES
		(RAND() * 5, RAND() * 5, @iter)

		UPDATE Matches SET CountOfFans = (select RAND() * (select Stadiums.Capacity from Stadiums where ID = (select Stadium_FK from Matches where ID = (select MAX(ID) from Matches)))) where ID = @iter;
		UPDATE Matches SET FirstTeam_FK = (select firstTeam from TempTable where ID = @iter), SecondTeam_FK = (select secondTeam from TempTable where ID = @iter) where ID = @iter
	
		DECLARE @from int = 0;
		DECLARE @to int = 7;
		DECLARE @temp int = 1;
		DECLARE @ident int = 1;
		WHILE (@temp < 9)
		BEGIN
			IF (@from < @ident AND @ident < @to)
				BEGIN
					UPDATE Matches SET Group_FK = @temp WHERE ID = @ident
					SET @ident = @ident + 1;
				END;
			ELSE
				BEGIN
					SET @temp = @temp + 1;
					SET @from = @from + 6;
					SET @to = @to + 6;
				END;
		END;
		SET @count = @count - 1;
		SET @iter = @iter + 1;
	END;
	
	SET @count = 1;
	WHILE (@count <> 48)
	BEGIN
		IF ((select FirstTeam from Scores where ID = @count) = (select SecondTeam from Scores where ID = @count))
		BEGIN
			UPDATE Matches SET ExtraTime = 1 WHERE ID = @count
			DECLARE @first int = 0;
			DECLARE @second int = 0;
			WHILE (@first = @second)
			BEGIN
				SET @first = RAND() * 5;
				SET @second = RAND() * 5;
			END;
			UPDATE Scores SET FirstTeam = @first, SecondTeam = @second WHERE ID = @count
		END;
		SET @count = @count + 1;
	END;

	SET @count = 1;
	WHILE (@count <> 48)
	BEGIN
		---- Первая команда --
		IF OBJECT_ID('FirstTeamPlayers') IS NOT NULL
			DROP TABLE FirstTeamPlayers;
		CREATE TABLE FirstTeamPlayers(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Player bigint);
	
		INSERT INTO FirstTeamPlayers (Player)
		SELECT ID FROM Players WHERE Team_FK = (select FirstTeam_FK from Matches where ID = @count)
	
		-- Вторая команда --
		IF OBJECT_ID('SecondTeamPlayers') IS NOT NULL
			DROP TABLE SecondTeamPlayers;
		CREATE TABLE SecondTeamPlayers(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Player bigint);
	
		INSERT INTO SecondTeamPlayers (Player)
		SELECT ID FROM Players WHERE Team_FK = (select FirstTeam_FK from Matches where ID = @count)
	
		---- Goals
		DECLARE @Player int;
		DECLARE @CountOfGoals int;
		---- 1
		SET @CountOfGoals= (select FirstTeam from Scores where ID = @count);
		WHILE (@CountOfGoals > 0)
		BEGIN
			SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
			INSERT INTO Goals VALUES 
			(@Player, 
			(select FirstTeam_FK from Matches where ID = @count), 
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			@count);
			SET @CountOfGoals = @CountOfGoals - 1;
		END;
		---- 2
		SET @CountOfGoals = (select SecondTeam from Scores where ID = @count);
		WHILE (@CountOfGoals > 0)
		BEGIN
			SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
			INSERT INTO Goals VALUES 
			(@Player, 
			(select SecondTeam_FK from Matches where ID = @count),
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			@count);
			SET @CountOfGoals = @CountOfGoals - 1;
		END;
	
		---- Foals
		IF OBJECT_ID('CardRand') IS NOT NULL
			DROP TABLE CardRand;
		CREATE TABLE CardRand(ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, [Card] int);
		INSERT INTO CardRand VALUES (1), (1), (1), (1), (2)
	
		DECLARE @CountOfFoalse int = (select RAND() * 5);
		-- 1
		WHILE (@CountOfFoalse > 0)
		BEGIN
			SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
			INSERT INTO Foals VALUES
			(@Player,
			(select FirstTeam_FK from Matches where ID = @count),
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select ID from Cards where ID = (select [Card] from CardRand where ID = (select CAST(RAND() * (select COUNT(*) from CardRand) + 1 AS int)))),
			@count);
			SET @CountOfFoalse = @CountOfFoalse - 1;
		END;
		-- 2
		SET  @CountOfFoalse = (select RAND() * 5);
		WHILE (@CountOfFoalse > 0)
		BEGIN
			SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
			INSERT INTO Foals VALUES
			(@Player,
			(select SecondTeam_FK from Matches where ID = @count),
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select ID from Cards where ID = (select [Card] from CardRand where ID = (select CAST(RAND() * (select COUNT(*) from CardRand) + 1 AS int)))),
			@count);
			SET @CountOfFoalse = @CountOfFoalse - 1;
		END;
		SET @count = @count + 1;
	END;
END;
GO

---------------------------
    --- Play 1/8 ---
---------------------------

IF OBJECT_ID('PlayOneEight') IS NOT NULL
    DROP PROCEDURE PlayOneEight;
GO

CREATE PROCEDURE PlayOneEight
AS
BEGIN
	IF OBJECT_ID('TT') IS NOT NULL
	    DROP TABLE TT;

	CREATE TABLE TT(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Team bigint, Goals bigint, [Group] bigint)
	
	DECLARE @win int;
	DECLARE @iter int = 1;
	WHILE (@iter < (select COUNT(*) from Teams) + 1)
	BEGIN
		DECLARE @score int;
		IF ((select SUM(Scores.FirstTeam) from Scores join Matches ON Scores.Match_FK = Matches.ID where Matches.FirstTeam_FK = @iter) IS NOT NULL)
			SET @score = (select SUM(Scores.FirstTeam) from Scores join Matches ON Scores.Match_FK = Matches.ID where Matches.FirstTeam_FK = @iter);
		IF ((select SUM(Scores.SecondTeam) from Scores join Matches ON Scores.Match_FK = Matches.ID where Matches.SecondTeam_FK =  @iter) IS NOT NULL)
			SET @score = @score + (select SUM(Scores.SecondTeam) from Scores join Matches ON Scores.Match_FK = Matches.ID where Matches.SecondTeam_FK =  @iter);
	
		INSERT INTO TT(Team, Goals, [Group]) VALUES
		(@iter, @score, (select TOP(1) Group_FK from Matches where FirstTeam_FK = @iter OR SecondTeam_FK = @iter))
		SET @iter = @iter + 1;
	END;
	
	IF OBJECT_ID('OneEight') IS NOT NULL
		DROP TABLE OneEight;
	CREATE TABLE OneEight(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Team bigint)

	SET @iter = 1;
	WHILE (@iter < (select COUNT(*) from Groups) + 1)
	BEGIN
		INSERT INTO OneEight(Team)
		select TOP(2) Team
		from TT
		where [Group] = @iter
		order by Goals DESC
	
		SET @iter = @iter + 1;
	END;

	DECLARE @begin datetime = '2020-06-01T12:00:00', @end datetime = '2020-06-30T21:00:00';	
	DECLARE @MatchOneEight int = 8;
	DECLARE @First int = 1;
	DECLARE @Second int = 2;
	WHILE (@MatchOneEight > 0)
	BEGIN

		INSERT INTO Matches(
		Stadium_FK,
		Referee_FK,
		FirstTeam_FK,
		SecondTeam_FK,
		[DateTime]) VALUES
		((select RAND() * (select MAX(ID) from Stadiums) + 1),
		(select RAND() * (select MAX(ID) from Referees) + 1),
		(select Team from OneEight where ID = @First),
		(select Team from OneEight where ID = @Second),
		(select CAST(CAST(@Begin AS float) + (CAST(@End AS float) - CAST(@Begin AS float)) * RAND() AS datetime)));
	
		UPDATE Matches SET PalyOff_FK = 1 WHERE ID = (select MAX(ID) from Matches)
		UPDATE Matches SET CountOfFans = (select RAND() * (select Stadiums.Capacity from Stadiums where ID = (select Stadium_FK from Matches where ID = (select MAX(ID) from Matches)))) where ID = (select MAX(ID) from Matches);

		INSERT INTO Scores(FirstTeam, SecondTeam, Match_FK) VALUES
		(RAND() * 5, RAND() * 5, (select MAX(ID) from Matches))
	
		---- Первая команда --
		IF OBJECT_ID('FirstTeamPlayers') IS NOT NULL
			DROP TABLE FirstTeamPlayers;
		CREATE TABLE FirstTeamPlayers(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Player bigint);
	
		INSERT INTO FirstTeamPlayers (Player)
		SELECT ID FROM Players WHERE Team_FK = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches))
	
		-- Вторая команда --
		IF OBJECT_ID('SecondTeamPlayers') IS NOT NULL
			DROP TABLE SecondTeamPlayers;
		CREATE TABLE SecondTeamPlayers(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Player bigint);
	
		INSERT INTO SecondTeamPlayers (Player)
		SELECT ID FROM Players WHERE Team_FK = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches))
	
		---- Goals
		DECLARE @Player int;
		DECLARE @CountOfGoals int;
		---- 1
		SET @CountOfGoals= (select FirstTeam from Scores where ID = (select MAX(ID) from Matches));
		WHILE (@CountOfGoals > 0)
		BEGIN
			SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
			INSERT INTO Goals VALUES 
			(@Player, 
			(select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), 
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select MAX(ID) from Matches));
			SET @CountOfGoals = @CountOfGoals - 1;
		END;
		---- 2
		SET @CountOfGoals = (select SecondTeam from Scores where ID = (select MAX(ID) from Matches));
		WHILE (@CountOfGoals > 0)
		BEGIN
			SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
			INSERT INTO Goals VALUES 
			(@Player, 
			(select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select MAX(ID) from Matches));
			SET @CountOfGoals = @CountOfGoals - 1;
		END;
		--------
	
		IF ((select FirstTeam from Scores where ID = (select MAX(ID) from Scores)) = (select SecondTeam from Scores where ID = (select MAX(ID) from Scores)))
		BEGIN
			UPDATE Matches SET ExtraTime = 1 WHERE ID = (select MAX(ID) from Matches)
			UPDATE Scores SET FirstTeam = RAND() * 5, SecondTeam = RAND() * 5 WHERE ID = (select MAX(ID) from Scores)
	
			SET @CountOfGoals = (select FirstTeam from Scores where ID = (select MAX(ID) from Matches));
			WHILE (@CountOfGoals > 0)
			BEGIN
				UPDATE Goals SET [Time] = (select LEFT(CAST(RAND() * 120 AS varchar), 5)) where Match_FK = (select MAX(ID) from Matches) AND Team = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches))
				SET @CountOfGoals = @CountOfGoals - 1;
			END;
			SET @CountOfGoals = (select SecondTeam from Scores where ID = (select MAX(ID) from Matches));
			WHILE (@CountOfGoals > 0)
			BEGIN
				UPDATE Goals SET [Time] = (select LEFT(CAST(RAND() * 120 AS varchar), 5)) where Match_FK = (select MAX(ID) from Matches) AND Team = (select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches));
				SET @CountOfGoals = @CountOfGoals - 1;
			END;
		END;
	
		----- Penalty
		IF ((select FirstTeam from Scores where ID = (select MAX(ID) from Scores)) = (select SecondTeam from Scores where ID = (select MAX(ID) from Scores)))
		BEGIN
			UPDATE Matches SET Penalty = 1 WHERE ID = (select MAX(ID) from Matches)
			DECLARE @hits int = 10;
			
			DECLARE @num int = 0;
			WHILE (@hits > 0)
			BEGIN
				SET @num = (select RAND() * 2);
				IF (@hits > 5)
				BEGIN
					SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
					IF ((select COUNT(*) from Penaltes) = 0)
						INSERT INTO Penaltes VALUES (@Player, (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
					ELSE
					BEGIN
						WHILE (@Player = (select Player_FK from Penaltes where Match_FK = (select MAX(ID) from Matches) AND Player_FK = @Player))
						BEGIN
							SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
						END;
						INSERT INTO Penaltes VALUES (@Player, (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
					END;
				END;
				ELSE
				BEGIN
				    SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
					WHILE (@Player = (select Player_FK from Penaltes where Match_FK = (select MAX(ID) from Matches) AND Player_FK = @Player))
					BEGIN
						SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
					END;
					INSERT INTO Penaltes VALUES (@Player, (select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
				END;
				SET @hits = @hits - 1;
			END;
		END;
		---- Foals
		IF OBJECT_ID('CardRand') IS NOT NULL
			DROP TABLE CardRand;
		CREATE TABLE CardRand(ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, [Card] int);
		INSERT INTO CardRand VALUES (1), (1), (1), (1), (2)
	
		DECLARE @CountOfFoalse int = (select RAND() * 5);
		-- 1
		WHILE (@CountOfFoalse > 0)
		BEGIN
			SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
			INSERT INTO Foals VALUES
			(@Player,
			(select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select ID from Cards where ID = (select [Card] from CardRand where ID = (select CAST(RAND() * (select COUNT(*) from CardRand) + 1 AS int)))),
			(select MAX(ID) from Matches));
			SET @CountOfFoalse = @CountOfFoalse - 1;
		END;
		-- 2
		SET  @CountOfFoalse = (select RAND() * 5);
		WHILE (@CountOfFoalse > 0)
		BEGIN
			SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
			INSERT INTO Foals VALUES
			(@Player,
			(select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select ID from Cards where ID = (select [Card] from CardRand where ID = (select CAST(RAND() * (select COUNT(*) from CardRand) + 1 AS int)))),
			(select MAX(ID) from Matches));
			SET @CountOfFoalse = @CountOfFoalse - 1;
		END;
	
		SET @First = @First + 2;
		SET @Second = @Second + 2;
		SET @MatchOneEight = @MatchOneEight - 1;
	END;
END;
GO

---------------------------
    --- Play 1/4 ---
---------------------------

IF OBJECT_ID('PlayOneFour') IS NOT NULL
    DROP PROCEDURE PlayOneFour;
GO

CREATE PROCEDURE PlayOneFour
AS
BEGIN
	IF OBJECT_ID('OneFour') IS NOT NULL
		DROP TABLE OneFour;
	CREATE TABLE OneFour(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Team bigint)
	
	DECLARE @Match int = (select MIN(ID) from Matches where Matches.PalyOff_FK = 1);
	WHILE (@Match < (select MAX(ID) from Matches) + 1)
	BEGIN
		IF ((select FirstTeam from Scores where ID = @Match) > (select SecondTeam from Scores where ID = @Match))
			INSERT INTO OneFour (Team) 
			VALUES 
			((select Matches.FirstTeam_FK from Matches join Scores ON Matches.ID = Match_FK where Scores.ID = @Match))
		ELSE
			INSERT INTO OneFour (Team) 
			VALUES 
			((select Matches.SecondTeam_FK from Matches join Scores ON Matches.ID = Match_FK where Scores.ID = @Match))
		SET @Match = @Match + 1;
	END;

	DECLARE @MatchOneFour int = 4;
	DECLARE @First int = 1;
	DECLARE @Second int = 2;
	WHILE (@MatchOneFour > 0)
	BEGIN
		DECLARE @begin datetime = '2020-06-01T12:00:00', @end datetime = '2020-06-30T21:00:00';
		INSERT INTO Matches(
		Stadium_FK,
		Referee_FK,
		FirstTeam_FK,
		SecondTeam_FK,
		[DateTime]) VALUES
		((select RAND() * (select MAX(ID) from Stadiums) + 1),
		(select RAND() * (select MAX(ID) from Referees) + 1),
		(select Team from OneFour where ID = @First),
		(select Team from OneFour where ID = @Second),
		(select CAST(CAST(@Begin AS float) + (CAST(@End AS float) - CAST(@Begin AS float)) * RAND() AS datetime)));
	
		UPDATE Matches SET PalyOff_FK = 2 WHERE ID = (select MAX(ID) from Matches)
		UPDATE Matches SET CountOfFans = (select RAND() * (select Stadiums.Capacity from Stadiums where ID = (select Stadium_FK from Matches where ID = (select MAX(ID) from Matches)))) where ID = (select MAX(ID) from Matches)
	
		INSERT INTO Scores(FirstTeam, SecondTeam, Match_FK) VALUES
		(RAND() * 5, RAND() * 5, (select MAX(ID) from Matches))
	
		---- Первая команда --
		IF OBJECT_ID('FirstTeamPlayers') IS NOT NULL
			DROP TABLE FirstTeamPlayers;
		CREATE TABLE FirstTeamPlayers(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Player bigint);
	
		INSERT INTO FirstTeamPlayers (Player)
		SELECT ID FROM Players WHERE Team_FK = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches))
	
		-- Вторая команда --
		IF OBJECT_ID('SecondTeamPlayers') IS NOT NULL
			DROP TABLE SecondTeamPlayers;
		CREATE TABLE SecondTeamPlayers(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Player bigint);
	
		INSERT INTO SecondTeamPlayers (Player)
		SELECT ID FROM Players WHERE Team_FK = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches))
	
		---- Goals
		DECLARE @Player int;
		DECLARE @CountOfGoals int;
		---- 1
		SET @CountOfGoals= (select FirstTeam from Scores where ID = (select MAX(ID) from Matches));
		WHILE (@CountOfGoals > 0)
		BEGIN
			SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
			
			INSERT INTO Goals VALUES 
			(@Player, 
			(select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), 
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select MAX(ID) from Matches));
			SET @CountOfGoals = @CountOfGoals - 1;
		END;
		---- 2
		SET @CountOfGoals = (select SecondTeam from Scores where ID = (select MAX(ID) from Matches));
		WHILE (@CountOfGoals > 0)
		BEGIN
			SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
			INSERT INTO Goals VALUES 
			(@Player, 
			(select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select MAX(ID) from Matches));
			SET @CountOfGoals = @CountOfGoals - 1;
		END;
		--------
	
		IF ((select FirstTeam from Scores where ID = (select MAX(ID) from Scores)) = (select SecondTeam from Scores where ID = (select MAX(ID) from Scores)))
		BEGIN
			UPDATE Matches SET ExtraTime = 1 WHERE ID = (select MAX(ID) from Matches)
			UPDATE Scores SET FirstTeam = RAND() * 5, SecondTeam = RAND() * 5 WHERE ID = (select MAX(ID) from Scores)
	
			SET @CountOfGoals = (select FirstTeam from Scores where ID = (select MAX(ID) from Matches));
			WHILE (@CountOfGoals > 0)
			BEGIN
				UPDATE Goals SET Time = (select LEFT(CAST(RAND() * 120 AS varchar), 5)) where Match_FK = (select MAX(ID) from Matches) AND Team = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches));
				SET @CountOfGoals = @CountOfGoals - 1;
			END;
			SET @CountOfGoals = (select SecondTeam from Scores where ID = (select MAX(ID) from Matches));
			WHILE (@CountOfGoals > 0)
			BEGIN
				UPDATE Goals SET Time = (select LEFT(CAST(RAND() * 120 AS varchar), 5)) where Match_FK = (select MAX(ID) from Matches) AND Team = (select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches));
				SET @CountOfGoals = @CountOfGoals - 1;
			END;
		END;
	
		----- Penalty
		IF ((select FirstTeam from Scores where ID = (select MAX(ID) from Scores)) = (select SecondTeam from Scores where ID = (select MAX(ID) from Scores)))
		BEGIN
			UPDATE Matches SET Penalty = 1 WHERE ID = (select MAX(ID) from Matches)
			DECLARE @hits int = 10;
			
			DECLARE @num int = 0;
			WHILE (@hits > 0)
			BEGIN
				SET @num = (select RAND() * 2);
				IF (@hits > 5)
				BEGIN
					SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
					IF ((select COUNT(*) from Penaltes) = 0)
						INSERT INTO Penaltes VALUES (@Player, (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
					ELSE
					BEGIN
						WHILE (@Player = (select Player_FK from Penaltes where Match_FK = (select MAX(ID) from Matches) AND Player_FK = @Player))
						BEGIN
							SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
						END;
						INSERT INTO Penaltes VALUES (@Player, (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
					END;
				END;
				ELSE
				BEGIN
				    SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
					WHILE (@Player = (select Player_FK from Penaltes where Match_FK = (select MAX(ID) from Matches) AND Player_FK = @Player))
					BEGIN
						SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
					END;
					INSERT INTO Penaltes VALUES (@Player, (select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
				END;
				SET @hits = @hits - 1;
			END;
		END;
		---- Foals
		IF OBJECT_ID('CardRand') IS NOT NULL
			DROP TABLE CardRand;
		CREATE TABLE CardRand(ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, [Card] int);
		INSERT INTO CardRand VALUES (1), (1), (1), (1), (2)
	
		DECLARE @CountOfFoalse int = (select RAND() * 5);
		-- 1
		WHILE (@CountOfFoalse > 0)
		BEGIN
			SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
			INSERT INTO Foals VALUES
			(@Player,
			(select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select ID from Cards where ID = (select [Card] from CardRand where ID = (select CAST(RAND() * (select COUNT(*) from CardRand) + 1 AS int)))),
			(select MAX(ID) from Matches));
			SET @CountOfFoalse = @CountOfFoalse - 1;
		END;
		-- 2
		SET  @CountOfFoalse = (select RAND() * 5);
		WHILE (@CountOfFoalse > 0)
		BEGIN
			SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
			INSERT INTO Foals VALUES
			(@Player,
			(select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select ID from Cards where ID = (select [Card] from CardRand where ID = (select CAST(RAND() * (select COUNT(*) from CardRand) + 1 AS int)))),
			(select MAX(ID) from Matches));
			SET @CountOfFoalse = @CountOfFoalse - 1;
		END;
	
		SET @First = @First + 2;
		SET @Second = @Second + 2;
		SET @MatchOneFour = @MatchOneFour - 1;
	END;
END;
GO

---------------------------
    --- Play 1/2 ---
---------------------------

IF OBJECT_ID('PlayOneTwo') IS NOT NULL
    DROP PROCEDURE PlayOneTwo;
GO

CREATE PROCEDURE PlayOneTwo
AS
BEGIN
	IF OBJECT_ID('OneTwo') IS NOT NULL
		DROP TABLE OneTwo;
	CREATE TABLE OneTwo(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Team bigint)

	DECLARE @Match int = (select MIN(ID) from Matches where Matches.PalyOff_FK = 2);
	WHILE (@Match < (select MAX(ID) from Matches) + 1)
	BEGIN
		IF ((select FirstTeam from Scores where ID = @Match) > (select SecondTeam from Scores where ID = @Match))
			INSERT INTO OneTwo (Team) 
			VALUES 
			((select Matches.FirstTeam_FK from Matches join Scores ON Matches.ID = Match_FK where Scores.ID = @Match))
		ELSE
			INSERT INTO OneTwo (Team) 
			VALUES 
			((select Matches.SecondTeam_FK from Matches join Scores ON Matches.ID = Match_FK where Scores.ID = @Match))
		SET @Match = @Match + 1;
	END;

	DECLARE @MatchOneTwo int = 2;
	DECLARE @First int = 1;
	DECLARE @Second int = 2;
	WHILE (@MatchOneTwo > 0)
	BEGIN
		DECLARE @begin datetime = '2020-06-01T12:00:00', @end datetime = '2020-06-30T21:00:00';
		INSERT INTO Matches(
		Stadium_FK,
		Referee_FK,
		FirstTeam_FK,
		SecondTeam_FK,
		[DateTime]) VALUES
		((select RAND() * (select MAX(ID) from Stadiums) + 1),
		(select RAND() * (select MAX(ID) from Referees) + 1),
		(select Team from OneTwo where ID = @First),
		(select Team from OneTwo where ID = @Second),
		(select CAST(CAST(@Begin AS float) + (CAST(@End AS float) - CAST(@Begin AS float)) * RAND() AS datetime)));
	
		UPDATE Matches SET PalyOff_FK = 3 WHERE ID = (select MAX(ID) from Matches)
		UPDATE Matches SET CountOfFans = (select RAND() * (select Stadiums.Capacity from Stadiums where ID = (select Stadium_FK from Matches where ID = (select MAX(ID) from Matches)))) where ID = (select MAX(ID) from Matches)
	
		INSERT INTO Scores(FirstTeam, SecondTeam, Match_FK) VALUES
		(RAND() * 5, RAND() * 5, (select MAX(ID) from Matches))
	
	
		---- Первая команда --
		IF OBJECT_ID('FirstTeamPlayers') IS NOT NULL
			DROP TABLE FirstTeamPlayers;
		CREATE TABLE FirstTeamPlayers(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Player bigint);
	
		INSERT INTO FirstTeamPlayers (Player)
		SELECT ID FROM Players WHERE Team_FK = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches))
	
		-- Вторая команда --
		IF OBJECT_ID('SecondTeamPlayers') IS NOT NULL
			DROP TABLE SecondTeamPlayers;
		CREATE TABLE SecondTeamPlayers(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Player bigint);
	
		INSERT INTO SecondTeamPlayers (Player)
		SELECT ID FROM Players WHERE Team_FK = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches))
	
		---- Goals
		DECLARE @Player int;
		DECLARE @CountOfGoals int;
		---- 1
		SET @CountOfGoals= (select FirstTeam from Scores where ID = (select MAX(ID) from Matches));
		WHILE (@CountOfGoals > 0)
		BEGIN
			SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
			
			INSERT INTO Goals VALUES 
			(@Player, 
			(select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), 
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select MAX(ID) from Matches));
			SET @CountOfGoals = @CountOfGoals - 1;
		END;
		---- 2
		SET @CountOfGoals = (select SecondTeam from Scores where ID = (select MAX(ID) from Matches));
		WHILE (@CountOfGoals > 0)
		BEGIN
			SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
			INSERT INTO Goals VALUES 
			(@Player, 
			(select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select MAX(ID) from Matches));
			SET @CountOfGoals = @CountOfGoals - 1;
		END;
		--------
	
		IF ((select FirstTeam from Scores where ID = (select MAX(ID) from Scores)) = (select SecondTeam from Scores where ID = (select MAX(ID) from Scores)))
		BEGIN
			UPDATE Matches SET ExtraTime = 1 WHERE ID = (select MAX(ID) from Matches)
			UPDATE Scores SET FirstTeam = RAND() * 5, SecondTeam = RAND() * 5 WHERE ID = (select MAX(ID) from Scores)
	
			SET @CountOfGoals = (select FirstTeam from Scores where ID = (select MAX(ID) from Matches));
			WHILE (@CountOfGoals > 0)
			BEGIN
				UPDATE Goals SET [Time] = (select LEFT(CAST(RAND() * 120 AS varchar), 5)) where Match_FK = (select MAX(ID) from Matches) AND Team = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches));
				SET @CountOfGoals = @CountOfGoals - 1;
			END;
			SET @CountOfGoals = (select SecondTeam from Scores where ID = (select MAX(ID) from Matches));
			WHILE (@CountOfGoals > 0)
			BEGIN
				UPDATE Goals SET [Time] = (select LEFT(CAST(RAND() * 120 AS varchar), 5)) where Match_FK = (select MAX(ID) from Matches) AND Team = (select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches));
				SET @CountOfGoals = @CountOfGoals - 1;
			END;
		END;
	
		----- Penalty
		IF ((select FirstTeam from Scores where ID = (select MAX(ID) from Scores)) = (select SecondTeam from Scores where ID = (select MAX(ID) from Scores)))
		BEGIN
			UPDATE Matches SET Penalty = 1 WHERE ID = (select MAX(ID) from Matches)
			DECLARE @hits int = 10;
			
			DECLARE @num int = 0;
			WHILE (@hits > 0)
			BEGIN
				SET @num = (select RAND() * 2);
				IF (@hits > 5)
				BEGIN
					SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
					IF ((select COUNT(*) from Penaltes) = 0)
						INSERT INTO Penaltes VALUES (@Player, (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
					ELSE
					BEGIN
						WHILE (@Player = (select Player_FK from Penaltes where Match_FK = (select MAX(ID) from Matches) AND Player_FK = @Player))
						BEGIN
							SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
						END;
						INSERT INTO Penaltes VALUES (@Player, (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
					END;
				END;
				ELSE
				BEGIN
				    SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
					WHILE (@Player = (select Player_FK from Penaltes where Match_FK = (select MAX(ID) from Matches) AND Player_FK = @Player))
					BEGIN
						SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
					END;
					INSERT INTO Penaltes VALUES (@Player, (select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
				END;
				SET @hits = @hits - 1;
			END;
		END;
		---- Foals
		IF OBJECT_ID('CardRand') IS NOT NULL
			DROP TABLE CardRand;
		CREATE TABLE CardRand(ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, [Card] int);
		INSERT INTO CardRand VALUES (1), (1), (1), (1), (2)
	
		DECLARE @CountOfFoalse int = (select RAND() * 5);
		-- 1
		WHILE (@CountOfFoalse > 0)
		BEGIN
			SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
			INSERT INTO Foals VALUES
			(@Player,
			(select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select ID from Cards where ID = (select [Card] from CardRand where ID = (select CAST(RAND() * (select COUNT(*) from CardRand) + 1 AS int)))),
			(select MAX(ID) from Matches));
			SET @CountOfFoalse = @CountOfFoalse - 1;
		END;
		-- 2
		SET  @CountOfFoalse = (select RAND() * 5);
		WHILE (@CountOfFoalse > 0)
		BEGIN
			SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
			INSERT INTO Foals VALUES
			(@Player,
			(select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
			(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
			(select ID from Cards where ID = (select [Card] from CardRand where ID = (select CAST(RAND() * (select COUNT(*) from CardRand) + 1 AS int)))),
			(select MAX(ID) from Matches));
			SET @CountOfFoalse = @CountOfFoalse - 1;
		END;
	
		SET @First = @First + 2;
		SET @Second = @Second + 2;
		SET @MatchOneTwo = @MatchOneTwo - 1;
	END;
END;
GO

---------------------------
     --- 3rd place ---
---------------------------

IF OBJECT_ID('PlayThirdPlace') IS NOT NULL
    DROP PROCEDURE PlayThirdPlace;
GO

CREATE PROCEDURE PlayThirdPlace
AS
BEGIN
	IF OBJECT_ID('ThirdPlace') IS NOT NULL
	    DROP TABLE ThirdPlace;
	CREATE TABLE ThirdPlace(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Team bigint)
	
	DECLARE @Match int = (select MIN(ID) from Matches where Matches.PalyOff_FK = 3);
	WHILE (@Match < (select MAX(ID) from Matches) + 1)
	BEGIN
		IF ((select FirstTeam from Scores where ID = @Match) < (select SecondTeam from Scores where ID = @Match))
			INSERT INTO ThirdPlace (Team) 
			VALUES 
			((select Matches.FirstTeam_FK from Matches join Scores ON Matches.ID = Match_FK where Scores.ID = @Match))
		ELSE
			INSERT INTO ThirdPlace (Team) 
			VALUES 
			((select Matches.SecondTeam_FK from Matches join Scores ON Matches.ID = Match_FK where Scores.ID = @Match))
		SET @Match = @Match + 1;
	END;
	
	DECLARE @begin datetime = '2020-06-01T12:00:00', @end datetime = '2020-06-30T21:00:00';
	INSERT INTO Matches(
	Stadium_FK,
	Referee_FK,
	FirstTeam_FK,
	SecondTeam_FK,
	[DateTime]) VALUES
	((select RAND() * (select MAX(ID) from Stadiums) + 1),
	(select RAND() * (select MAX(ID) from Referees) + 1),
	(select Team from ThirdPlace where ID = 1),
	(select Team from ThirdPlace where ID = 2),
	(select CAST(CAST(@Begin AS float) + (CAST(@End AS float) - CAST(@Begin AS float)) * RAND() AS datetime)));
	
	UPDATE Matches SET PalyOff_FK = 4 WHERE ID = (select MAX(ID) from Matches)
	UPDATE Matches SET CountOfFans = (select RAND() * (select Stadiums.Capacity from Stadiums where ID = (select Stadium_FK from Matches where ID = (select MAX(ID) from Matches)))) where ID = (select MAX(ID) from Matches)
	
	INSERT INTO Scores(FirstTeam, SecondTeam, Match_FK) VALUES
	(RAND() * 5, RAND() * 5, (select MAX(ID) from Matches))
	
	
	---- Первая команда --
	IF OBJECT_ID('FirstTeamPlayers') IS NOT NULL
		DROP TABLE FirstTeamPlayers;
	CREATE TABLE FirstTeamPlayers(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Player bigint);
	
	INSERT INTO FirstTeamPlayers (Player)
	SELECT ID FROM Players WHERE Team_FK = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches))
	
	-- Вторая команда --
	IF OBJECT_ID('SecondTeamPlayers') IS NOT NULL
		DROP TABLE SecondTeamPlayers;
	CREATE TABLE SecondTeamPlayers(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Player bigint);
	
	INSERT INTO SecondTeamPlayers (Player)
	SELECT ID FROM Players WHERE Team_FK = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches))
	
	---- Goals
	DECLARE @Player int;
	DECLARE @CountOfGoals int;
	---- 1
	SET @CountOfGoals= (select FirstTeam from Scores where ID = (select MAX(ID) from Matches));
	WHILE (@CountOfGoals > 0)
	BEGIN
		SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
		
		INSERT INTO Goals VALUES 
		(@Player, 
		(select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), 
		(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
		(select MAX(ID) from Matches));
		SET @CountOfGoals = @CountOfGoals - 1;
	END;
	---- 2
	SET @CountOfGoals = (select SecondTeam from Scores where ID = (select MAX(ID) from Matches));
	WHILE (@CountOfGoals > 0)
	BEGIN
		SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
		INSERT INTO Goals VALUES 
		(@Player, 
		(select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
		(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
		(select MAX(ID) from Matches));
		SET @CountOfGoals = @CountOfGoals - 1;
	END;
	--------
	
		IF ((select FirstTeam from Scores where ID = (select MAX(ID) from Scores)) = (select SecondTeam from Scores where ID = (select MAX(ID) from Scores)))
		BEGIN
			UPDATE Matches SET ExtraTime = 1 WHERE ID = (select MAX(ID) from Matches)
			UPDATE Scores SET FirstTeam = RAND() * 5, SecondTeam = RAND() * 5 WHERE ID = (select MAX(ID) from Scores)
	
			SET @CountOfGoals = (select FirstTeam from Scores where ID = (select MAX(ID) from Matches));
			WHILE (@CountOfGoals > 0)
			BEGIN
				UPDATE Goals SET [Time] = (select LEFT(CAST(RAND() * 120 AS varchar), 5)) where Match_FK = (select MAX(ID) from Matches) AND Team = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches));
				SET @CountOfGoals = @CountOfGoals - 1;
			END;
			SET @CountOfGoals = (select SecondTeam from Scores where ID = (select MAX(ID) from Matches));
			WHILE (@CountOfGoals > 0)
			BEGIN
				UPDATE Goals SET [Time] = (select LEFT(CAST(RAND() * 120 AS varchar), 5)) where Match_FK = (select MAX(ID) from Matches) AND Team = (select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches));
				SET @CountOfGoals = @CountOfGoals - 1;
			END;
		END;
	
	----- Penalty
	IF ((select FirstTeam from Scores where ID = (select MAX(ID) from Scores)) = (select SecondTeam from Scores where ID = (select MAX(ID) from Scores)))
	BEGIN
		UPDATE Matches SET Penalty = 1 WHERE ID = (select MAX(ID) from Matches)
		DECLARE @hits int = 10;
		
		DECLARE @num int = 0;
		WHILE (@hits > 0)
		BEGIN
			SET @num = (select RAND() * 2);
			IF (@hits > 5)
			BEGIN
				SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
				IF ((select COUNT(*) from Penaltes) = 0)
					INSERT INTO Penaltes VALUES (@Player, (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
				ELSE
				BEGIN
					WHILE (@Player = (select Player_FK from Penaltes where Match_FK = (select MAX(ID) from Matches) AND Player_FK = @Player))
					BEGIN
						SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
					END;
					INSERT INTO Penaltes VALUES (@Player, (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
				END;
			END;
			ELSE
			BEGIN
			    SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
				WHILE (@Player = (select Player_FK from Penaltes where Match_FK = (select MAX(ID) from Matches) AND Player_FK = @Player))
				BEGIN
					SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
				END;
				INSERT INTO Penaltes VALUES (@Player, (select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
			END;
			SET @hits = @hits - 1;
		END;
	END;
	---- Foals
	IF OBJECT_ID('CardRand') IS NOT NULL
		DROP TABLE CardRand;
	CREATE TABLE CardRand(ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, [Card] int);
	INSERT INTO CardRand VALUES (1), (1), (1), (1), (2)
	
	DECLARE @CountOfFoalse int = (select RAND() * 5);
	-- 1
	WHILE (@CountOfFoalse > 0)
	BEGIN
		SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
		INSERT INTO Foals VALUES
		(@Player,
		(select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
		(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
		(select ID from Cards where ID = (select [Card] from CardRand where ID = (select CAST(RAND() * (select COUNT(*) from CardRand) + 1 AS int)))),
		(select MAX(ID) from Matches));
		SET @CountOfFoalse = @CountOfFoalse - 1;
	END;
	-- 2
	SET  @CountOfFoalse = (select RAND() * 5);
	WHILE (@CountOfFoalse > 0)
	BEGIN
		SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
		INSERT INTO Foals VALUES
		(@Player,
		(select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
		(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
		(select ID from Cards where ID = (select [Card] from CardRand where ID = (select CAST(RAND() * (select COUNT(*) from CardRand) + 1 AS int)))),
		(select MAX(ID) from Matches));
		SET @CountOfFoalse = @CountOfFoalse - 1;
	END;
END;
GO

---------------------------
      --- FINAL ---
---------------------------

IF OBJECT_ID('PlayFinal') IS NOT NULL
    DROP PROCEDURE PlayFinal;
GO

CREATE PROCEDURE PlayFinal
AS
BEGIN
	IF OBJECT_ID('Final') IS NOT NULL
	    DROP TABLE Final;
	CREATE TABLE Final(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Team bigint)

	DECLARE @Match int = (select MIN(ID) from Matches where Matches.PalyOff_FK = 3);
	WHILE (@Match < (select MAX(ID) from Matches))
	BEGIN
		IF ((select FirstTeam from Scores where ID = @Match) > (select SecondTeam from Scores where ID = @Match))
			INSERT INTO Final (Team) 
			VALUES 
			((select Matches.FirstTeam_FK from Matches join Scores ON Matches.ID = Match_FK where Scores.ID = @Match))
		ELSE
			INSERT INTO Final (Team) 
			VALUES 
			((select Matches.SecondTeam_FK from Matches join Scores ON Matches.ID = Match_FK where Scores.ID = @Match))
		SET @Match = @Match + 1;
	END;
	
	DECLARE @begin datetime = '2020-06-01T12:00:00', @end datetime = '2020-06-30T21:00:00';
	INSERT INTO Matches(
	Stadium_FK,
	Referee_FK,
	FirstTeam_FK,
	SecondTeam_FK,
	[DateTime]) VALUES
	((select RAND() * (select MAX(ID) from Stadiums) + 1),
	(select RAND() * (select MAX(ID) from Referees) + 1),
	(select Team from Final where ID = 1),
	(select Team from Final where ID = 2),
	(select CAST(CAST(@Begin AS float) + (CAST(@End AS float) - CAST(@Begin AS float)) * RAND() AS datetime)));
	
	UPDATE Matches SET PalyOff_FK = 5 WHERE ID = (select MAX(ID) from Matches)
	UPDATE Matches SET CountOfFans = (select RAND() * (select Stadiums.Capacity from Stadiums where ID = (select Stadium_FK from Matches where ID = (select MAX(ID) from Matches)))) where ID = (select MAX(ID) from Matches)
	
	INSERT INTO Scores(FirstTeam, SecondTeam, Match_FK) VALUES
	(RAND() * 5, RAND() * 5, (select MAX(ID) from Matches))
	
	---- Первая команда --
	IF OBJECT_ID('FirstTeamPlayers') IS NOT NULL
		DROP TABLE FirstTeamPlayers;
	CREATE TABLE FirstTeamPlayers(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Player bigint);
	
	INSERT INTO FirstTeamPlayers (Player)
	SELECT ID FROM Players WHERE Team_FK = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches))
	
	-- Вторая команда --
	IF OBJECT_ID('SecondTeamPlayers') IS NOT NULL
		DROP TABLE SecondTeamPlayers;
	CREATE TABLE SecondTeamPlayers(Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, Player bigint);
	
	INSERT INTO SecondTeamPlayers (Player)
	SELECT ID FROM Players WHERE Team_FK = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches))
	
	---- Goals
	DECLARE @Player int;
	DECLARE @CountOfGoals int;
	---- 1
	SET @CountOfGoals= (select FirstTeam from Scores where ID = (select MAX(ID) from Matches));
	WHILE (@CountOfGoals > 0)
	BEGIN
		SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
		
		INSERT INTO Goals VALUES 
		(@Player, 
		(select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), 
		(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
		(select MAX(ID) from Matches));
		SET @CountOfGoals = @CountOfGoals - 1;
	END;
	---- 2
	SET @CountOfGoals = (select SecondTeam from Scores where ID = (select MAX(ID) from Matches));
	WHILE (@CountOfGoals > 0)
	BEGIN
		SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
		INSERT INTO Goals VALUES 
		(@Player, 
		(select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
		(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
		(select MAX(ID) from Matches));
		SET @CountOfGoals = @CountOfGoals - 1;
	END;
	--------
	
		IF ((select FirstTeam from Scores where ID = (select MAX(ID) from Scores)) = (select SecondTeam from Scores where ID = (select MAX(ID) from Scores)))
		BEGIN
			UPDATE Matches SET ExtraTime = 1 WHERE ID = (select MAX(ID) from Matches)
			UPDATE Scores SET FirstTeam = RAND() * 5, SecondTeam = RAND() * 5 WHERE ID = (select MAX(ID) from Scores)
	
			SET @CountOfGoals = (select FirstTeam from Scores where ID = (select MAX(ID) from Matches));
			WHILE (@CountOfGoals > 0)
			BEGIN
				UPDATE Goals SET [Time] = (select LEFT(CAST(RAND() * 120 AS varchar), 5)) where Match_FK = (select MAX(ID) from Matches) AND Team = (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches));
				SET @CountOfGoals = @CountOfGoals - 1;
			END;
			SET @CountOfGoals = (select SecondTeam from Scores where ID = (select MAX(ID) from Matches));
			WHILE (@CountOfGoals > 0)
			BEGIN
				UPDATE Goals SET [Time] = (select LEFT(CAST(RAND() * 120 AS varchar), 5)) where Match_FK = (select MAX(ID) from Matches) AND Team = (select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches));
				SET @CountOfGoals = @CountOfGoals - 1;
			END;
		END;
	
	----- Penalty
	IF ((select FirstTeam from Scores where ID = (select MAX(ID) from Scores)) = (select SecondTeam from Scores where ID = (select MAX(ID) from Scores)))
	BEGIN
		UPDATE Matches SET Penalty = 1 WHERE ID = (select MAX(ID) from Matches)
		DECLARE @hits int = 10;
		
		DECLARE @num int = 0;
		WHILE (@hits > 0)
		BEGIN
			SET @num = (select RAND() * 2);
			IF (@hits > 5)
			BEGIN
				SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
				IF ((select COUNT(*) from Penaltes) = 0)
					INSERT INTO Penaltes VALUES (@Player, (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
				ELSE
				BEGIN
					WHILE (@Player = (select Player_FK from Penaltes where Match_FK = (select MAX(ID) from Matches) AND Player_FK = @Player))
					BEGIN
						SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
					END;
					INSERT INTO Penaltes VALUES (@Player, (select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
				END;
			END;
			ELSE
			BEGIN
			    SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
				WHILE (@Player = (select Player_FK from Penaltes where Match_FK = (select MAX(ID) from Matches) AND Player_FK = @Player))
				BEGIN
					SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
				END;
				INSERT INTO Penaltes VALUES (@Player, (select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)), @num, (select MAX(ID) from Matches));
			END;
			SET @hits = @hits - 1;
		END;
	END;
	---- Foals
	IF OBJECT_ID('CardRand') IS NOT NULL
		DROP TABLE CardRand;
	CREATE TABLE CardRand(ID bigint IDENTITY(1,1) NOT NULL PRIMARY KEY, [Card] int);
	INSERT INTO CardRand VALUES (1), (1), (1), (1), (2)
	
	DECLARE @CountOfFoalse int = (select RAND() * 5);
	-- 1
	WHILE (@CountOfFoalse > 0)
	BEGIN
		SET @Player = (select Player from FirstTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from FirstTeamPlayers) + 1 AS int)));
	
		INSERT INTO Foals VALUES
		(@Player,
		(select FirstTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
		(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
		(select ID from Cards where ID = (select [Card] from CardRand where ID = (select CAST(RAND() * (select COUNT(*) from CardRand) + 1 AS int)))),
		(select MAX(ID) from Matches));
		SET @CountOfFoalse = @CountOfFoalse - 1;
	END;
	-- 2
	SET  @CountOfFoalse = (select RAND() * 5);
	WHILE (@CountOfFoalse > 0)
	BEGIN
		SET @Player = (select Player from SecondTeamPlayers where Id = (select CAST(RAND() * (select COUNT(*) from SecondTeamPlayers) + 1 AS int)));
	
		INSERT INTO Foals VALUES
		(@Player,
		(select SecondTeam_FK from Matches where ID = (select MAX(ID) from Matches)),
		(select LEFT(CAST(RAND() * 90 AS varchar), 5)),
		(select ID from Cards where ID = (select [Card] from CardRand where ID = (select CAST(RAND() * (select COUNT(*) from CardRand) + 1 AS int)))),
		(select MAX(ID) from Matches));
		SET @CountOfFoalse = @CountOfFoalse - 1;
	END;
END;
GO

IF OBJECT_ID('PlayChampionship') IS NOT NULL
    DROP PROCEDURE PlayChampionship;
GO

CREATE PROCEDURE PlayChampionship
AS
BEGIN
	EXEC PlayGroups
	EXEC PlayOneEight
	EXEC PlayOneFour
	EXEC PlayOneTwo
	EXEC PlayThirdPlace
	EXEC PlayFinal
END;
GO

 EXEC PlayChampionship
 GO
 --select * from Matches