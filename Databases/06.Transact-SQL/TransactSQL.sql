-- ##############################################################################
-- Problem 1.	Create a database with two tables
-- Persons (id (PK), first name, last name, SSN) and Accounts (id (PK), person id (FK), balance).
-- Insert few records for testing. 
-- Write a stored procedure that selects the full names of all persons.
-- ##############################################################################
CREATE DATABASE TransactSQL
GO

USE [TransactSQL]
GO

CREATE TABLE Persons (
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,FirstName NVARCHAR(50)
	,LastName NVARCHAR(100) NOT NULL
	,SSN NVARCHAR(max)
	)

CREATE TABLE Accounts (
	Id INT PRIMARY KEY NOT NULL IDENTITY
	,PersonId INT NOT NULL
	,Balance MONEY NOT NULL DEFAULT(0)
	,CONSTRAINT chk_Balance CHECK (Balance >= 0)
	,CONSTRAINT FK_Persons_Accounts FOREIGN KEY (PersonId) REFERENCES Persons(Id)
	)
GO

INSERT INTO Persons
VALUES (
	'Pencho'
	,'Penchov'
	,'123456'
	)
	,(
	'Goshko'
	,'Goshkov'
	,'1234567'
	)
	,(
	'Toshko'
	,'Toshkov'
	,'1234568'
	)
	,(
	'Sencho'
	,'Senchov'
	,'1234569'
	)
	,(
	'Minka'
	,'Minkova'
	,'1234561'
	)
	,(
	'Penka'
	,'Penkova'
	,'1234562'
	)
	,(
	'Zvyncho'
	,'Drankavachev'
	,'1234563'
	)
	,(
	'BIll'
	,'Gates'
	,'1234564'
	)

INSERT INTO Accounts
VALUES (
	1
	,100000
	)
	,(
	2
	,4200
	)
	,(
	3
	,20450
	)
	,(
	4
	,25400
	)
	,(
	5
	,20
	)
	,(
	6
	,11200
	)
	,(
	7
	,200
	)
	,(
	8
	,0
	)
GO

CREATE PROCEDURE usp_PersonsFullName
AS
SELECT FirstName + ' ' + LastName
FROM Persons
GO

-- Test Problem 1
EXEC usp_PersonsFullName
GO

-- ##############################################################################
-- Problem 2.	Create a stored procedure
-- Your task is to create a stored procedure that accepts a number as a parameter
-- and returns all persons who have more money in their accounts than the supplied number.
-- ##############################################################################
CREATE PROCEDURE usp_PersonsWithMoreMoneyThan (@amount MONEY)
AS
SELECT p.FirstName
	,p.LastName
	,a.Balance
FROM Accounts a
JOIN Persons p ON p.Id = a.PersonId
WHERE a.Balance >= @amount
GO

-- Test Problem 2
EXEC usp_PersonsWithMoreMoneyThan 11000
GO

-- ##############################################################################
-- Problem 3.	Create a function with parameters
-- Your task is to create a function that accepts as parameters – sum,
-- yearly interest rate and number of months. It should calculate and return
-- the new sum. Write a SELECT to test whether the function works as expected.
-- ##############################################################################
CREATE FUNCTION ufn_CalculatInterest (
	@sum MONEY
	,@interest FLOAT
	,@months INT
	)
RETURNS MONEY
AS
BEGIN
	DECLARE @monthlyInterest FLOAT = @interest / 12 / 100

	RETURN @sum * (@monthlyInterest * @months)
END
GO

-- Test Problem 3
DECLARE @months INT = 5
	,@yearlyInteres FLOAT = 3.5
	,@interestIncome MONEY

SELECT p.FirstName + ' ' + p.LastName AS [Full Name]
	,a.Balance AS [Current Balance]
	,CAST([dbo].ufn_CalculatInterest(a.Balance, @yearlyInteres, @months) AS NVARCHAR) + ' [for ' + CAST(@months AS NVARCHAR) + ' months]' AS [Income per Period]
FROM Persons p
JOIN Accounts a ON p.Id = a.PersonId
GO

-- ##############################################################################
-- Problem 4.	Create a stored procedure that uses the function from the previous example.
-- Your task is to create a stored procedure that uses the function from the previous
-- example to give an interest to a person's account for one month.
-- It should take the AccountId and the interest rate as parameters.
-- ##############################################################################
CREATE PROCEDURE usp_UpdateBalanceWithMonthInterest (
	@accountId INT
	,@interest FLOAT
	)
AS
UPDATE Accounts
SET Balance = Balance + [dbo].ufn_CalculatInterest(Balance, @interest, 1)
WHERE Id = @accountId
GO

-- Test Problem 4
EXEC usp_UpdateBalanceWithMonthInterest 1
	,3.5
GO

-- ##############################################################################
-- Problem 5.	Add two more stored procedures WithdrawMoney and DepositMoney.
-- Add two more stored procedures WithdrawMoney (AccountId, money) and
-- DepositMoney (AccountId, money) that operate in transactions.
-- ##############################################################################
CREATE PROCEDURE usp_WithdrawMoney (
	@accountId INT
	,@money MONEY
	)
AS
BEGIN TRAN

UPDATE Accounts
SET Balance = Balance - @money
WHERE Id = @accountId

COMMIT TRAN
GO

CREATE PROCEDURE usp_DepositMoney (
	@accountId INT
	,@money MONEY
	)
AS
BEGIN TRAN

UPDATE Accounts
SET Balance = Balance + @money
WHERE Id = @accountId

COMMIT TRAN
GO

-- Test Problem 5
SELECT Balance
FROM Accounts
WHERE Id = 1

EXEC usp_DepositMoney 1
	,100

EXEC usp_WithdrawMoney 1
	,100100

SELECT Balance
FROM Accounts
WHERE Id = 1
GO

-- ##############################################################################
-- Problem 6.	Create table Logs.
-- Create another table – Logs (LogID, AccountID, OldSum, NewSum).
-- Add a trigger to the Accounts table that enters a new entry into the Logs table 
-- every time the sum on an account changes.
-- ##############################################################################
CREATE TABLE Logs (
	LogId INT NOT NULL IDENTITY PRIMARY KEY
	,AccountId INT NOT NULL
	,OldSum MONEY NOT NULL
	,NewSum MONEY NOT NULL
	)
GO

CREATE TRIGGER tr_LogBalanceChange ON Accounts
INSTEAD OF UPDATE
AS
DECLARE @accountId INT = (
		SELECT Id
		FROM inserted
		)
DECLARE @oldBalance MONEY = (
		SELECT a.Balance
		FROM Accounts a
		WHERE a.Id = @accountId
		)
	,@newBalance MONEY = (
		SELECT Balance
		FROM inserted
		)

UPDATE Accounts
SET Balance = @newBalance
WHERE Id = @accountId

INSERT INTO Logs
VALUES (
	@accountId
	,@oldBalance
	,@newBalance
	)
GO

-- Test Problem 6
UPDATE Accounts
SET Balance = 100
WHERE Id = 1
GO

-- ##############################################################################
-- Problem 7.	Define function in the SoftUni database.
-- Define a function in the database SoftUni that returns all Employee's names (first or middle or last name)
-- and all town's names that are comprised of given set of letters. 
-- Example: 'oistmiahf' will return 'Sofia', 'Smith', but not 'Rob' and 'Guy'.
-- ##############################################################################
USE [SoftUni]
GO

CREATE FUNCTION ufn_IsValid (
	@string NVARCHAR(MaX)
	,@symbols NVARCHAR(MAX)
	)
RETURNS BIT
AS
BEGIN
	DECLARE @length INT = (LEN(@string))
	DECLARE @currentIndex INT = 1
	DECLARE @currentSymbol NVARCHAR(1) = ''

	IF (@string IS NULL)
		OR (@length = 0)
	BEGIN
		RETURN 0
	END

	WHILE (@currentIndex <= @length)
	BEGIN
		SET @currentSymbol = SUBSTRING(@string, @currentIndex, 1)

		IF (@symbols NOT LIKE '%' + @currentSymbol + '%')
		BEGIN
			RETURN 0
		END

		SET @currentIndex = @currentIndex + 1
	END

	RETURN 1
END
GO

CREATE FUNCTION ufn_AllUsersNamesAndTownsInSymbolsScope (@symbols NVARCHAR)
RETURNS @tbl_result TABLE (
	Id INT IDENTITY PRIMARY KEY NOT NULL
	,Name NVARCHAR(max) NOT NULL
	)
AS
BEGIN
	INSERT INTO @tbl_result (Name) (
		SELECT FirstName FROM Employees WHERE [dbo].ufn_IsValid(FirstName, @symbols) = 1
	
	UNION
		
		--INSERT INTO @tbl_result ([Values in scope])
		SELECT LastName FROM Employees WHERE [dbo].ufn_IsValid(LastName, @symbols) = 1
	
	UNION
		
		--INSERT INTO @tbl_result ([Values in scope])
		SELECT MiddleName  FROM Employees WHERE [dbo].ufn_IsValid(MiddleName, @symbols) = 1
	
	UNION
		
		--INSERT INTO @tbl_result ([Values in scope])
		SELECT NAME FROM Towns WHERE [dbo].ufn_IsValid(NAME, @symbols) = 1
		)

	RETURN
END
GO

-- Test Problem 7
SELECT *
FROM [dbo].ufn_AllUsersNamesAndTownsInSymbolsScope('oistmiahf')

SELECT FirstName
FROM Employees
WHERE [dbo].ufn_IsValid(FirstName, 'oistmiahf') = 1

SELECT MiddleName AS [Values in scope]
FROM Employees
WHERE [dbo].ufn_IsValid(MiddleName, 'oistmiahf') = 1

SELECT NAME
FROM Towns
WHERE [dbo].ufn_IsValid(NAME, 'oistmiahf') = 1

SELECT NAME
FROM Towns
WHERE [dbo].fn_StringFuzzyComparator(NAME, 'oistmiahf') = 1

SELECT NAME
FROM Towns
WHERE 'oistmiahf' NOT LIKE '%' + SUBSTRING(NAME, 1, 1) + '%'

CREATE FUNCTION fn_StringFuzzyComparator (
	@name NVARCHAR(MAX)
	,@str NVARCHAR(MAX)
	)
RETURNS BIT
AS
BEGIN
	DECLARE @strLen INT = LEN(@str)
	DECLARE @nameLen INT = LEN(@name)
	DECLARE @index INT = 1
	DECLARE @currentChar NVARCHAR(1) = ''
	DECLARE @matchCounter INT = 0

	IF @nameLen > @strLen
	BEGIN
		RETURN 0
	END

	WHILE (@index <= @nameLen)
	BEGIN
		SET @currentChar = SUBSTRING(@name, @index, 1)

		IF @str NOT LIKE '%' + @currentChar + '%'
		BEGIN
			RETURN 0
		END

		SET @index += 1
	END

	RETURN 1
END
GO

SELECT NAME
FROM Towns
WHERE ()
GO

-- ##############################################################################
-- Problem 8.	Using database cursor write a T-SQL
-- Using database cursor write a T-SQL script that scans all employees and
-- their addresses and prints all pairs of employees that live in the same town.
-- ##############################################################################
GO

-- ##############################################################################
-- Problem 9.	Define a .NET aggregate function
-- Define a .NET aggregate function StrConcat that takes as input a sequence
-- of strings and return a single string that consists of the input strings
-- separated by ','. For example the following SQL statement should return a single string:
-- ##############################################################################
GO

-- ##############################################################################
-- Problem 10.	*Write a T-SQL script
-- Write a T-SQL script that shows for each town a list of all employees that live in it.
-- ##############################################################################
GO

USE SoftUni
GO

CREATE FUNCTION fn_StringFuzzyComparator (
	@name NVARCHAR(MAX)
	,@str NVARCHAR(MAX)
	)
RETURNS BIT
AS
BEGIN
	DECLARE @strLen INT = LEN(@str)
	DECLARE @nameLen INT = LEN(@name)
	DECLARE @index INT = 1
	DECLARE @currentChar NVARCHAR(1) = ''
	DECLARE @matchCounter INT = 0

	IF @nameLen > @strLen
	BEGIN
		RETURN 0
	END

	WHILE (@index <= @nameLen)
	BEGIN
		SET @currentChar = SUBSTRING(@name, @index, 1)

		IF @str NOT LIKE '%' + @currentChar + '%'
		BEGIN
			RETURN 0
		END

		SET @index += 1
	END

	RETURN 1
END
GO

CREATE FUNCTION fn_NameResearcher (@letters NVARCHAR(MAX))
RETURNS @tbl_AllNamesFromLetters TABLE (
	NameID INT PRIMARY KEY IDENTITY NOT NULL
	,NAME NVARCHAR(MAX) NOT NULL
	)
AS
BEGIN
	DECLARE @a TABLE (
		Id INT PRIMARY KEY identity NOT NULL
		,NAME NVARCHAR(max)
		)

	INSERT INTO @a (NAME)
	SELECT FirstName
	FROM Employees

	INSERT INTO @a (NAME)
	SELECT LastName AS NAME
	FROM Employees

	INSERT INTO @a (NAME)
	SELECT MiddleName AS NAME
	FROM Employees
	WHERE MiddleName IS NOT NULL

	INSERT INTO @a (NAME)
	SELECT NAME AS NAME
	FROM Towns

	INSERT @tbl_AllNamesFromLetters
	SELECT DISTINCT NAME
	FROM @a currentName
	WHERE 1 = dbo.fn_StringFuzzyComparator(currentName.NAME, @letters)

	RETURN
END
GO

SELECT *
FROM fn_NameResearcher('oistmiahf')
GO

