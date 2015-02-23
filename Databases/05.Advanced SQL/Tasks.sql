-- Problem 1.	Write a SQL query to find the names and salaries of 
--				the employees that take the minimal salary in the company.
SELECT FirstName + ' ' + LastName AS [Full Name]
	,Salary
FROM [SoftUni].[dbo].[Employees]
WHERE Salary = (
		SELECT MIN(Salary)
		FROM [SoftUni].[dbo].[Employees]
		)

-- Problem 2.	Write a SQL query to find the names and salaries of the employees 
--				that have a salary that is up to 10% higher than the minimal 
--				salary for the company.
SELECT FirstName + ' ' + LastName AS [Full Name]
	,Salary
FROM [SoftUni].[dbo].[Employees]
WHERE (
		Salary BETWEEN (
					SELECT MIN(Salary)
					FROM [SoftUni].[dbo].[Employees]
					)
			AND (
					SELECT MIN(Salary)
					FROM [SoftUni].[dbo].[Employees]
					) * 1.1
		)

-- Problem 3.	Write a SQL query to find the full name, salary and department 
--				of the employees that take the minimal salary in their department.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name]
	,e.Salary AS [Lowest Salary]
	,d.NAME
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (
		SELECT MIN(Salary)
		FROM [SoftUni].[dbo].[Employees]
		WHERE DepartmentId = e.DepartmentId
		)

-- Problem 4.	Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) AS [Average Salary]
FROM [SoftUni].[dbo].[Employees]
WHERE DepartmentId = 1

-- Problem 5.	Write a SQL query to find the average salary in the "Sales" department.
SELECT AVG(Salary) AS [Average Salary]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID
WHERE d.NAME = 'Sales'

-- Problem 6.	Write a SQL query to find the number of employees 
--				in the "Sales" department.
SELECT COUNT(*) AS [Employee Count in Sales]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID
WHERE d.NAME = 'Sales'

-- Problem 7.	Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*) AS [Employee Count with Manager]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Employees] m ON e.ManagerID = m.EmployeeID

-- OR
SELECT COUNT(ManagerId) AS [Employee Count with Manager]
FROM [SoftUni].[dbo].[Employees]

-- Problem 8.	Write a SQL query to find the number of all employees 
--				that have no manager.
SELECT COUNT(*)
FROM [SoftUni].[dbo].[Employees]
WHERE ManagerID IS NULL

-- Problem 9.	Write a SQL query to find all departments and the average 
--				salary for each of them.
SELECT d.NAME
	,AVG(Salary)
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID
GROUP BY d.NAME

-- Problem 10.	Write a SQL query to find the count of all employees 
--				in each department and for each town.
SELECT d.NAME
	,t.NAME
	,COUNT(*) AS [Employee Count]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID
JOIN [SoftUni].[dbo].[Addresses] a ON e.AddressID = a.AddressID
JOIN [SoftUni].[dbo].[Towns] t ON a.TownID = t.TownID
GROUP BY d.NAME
	,t.NAME

-- Problem 11.	Write a SQL query to find all managers that have exactly 5 employees.
SELECT m.FirstName + ' ' + m.LastName AS [Managers with 5 Employees]
	,COUNT(e.ManagerID) AS [Nb of Employees]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Employees] m ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName
	,m.LastName
HAVING COUNT(e.ManagerId) = 5
ORDER BY m.LastName

-- Problem 12.	Write a SQL query to find all employees along with their managers.
SELECT e.FirstName + ' ' + e.LastName AS [Employee]
	,ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS [Managed By]
FROM [SoftUni].[dbo].[Employees] e
LEFT JOIN [SoftUni].[dbo].[Employees] m ON e.ManagerID = m.EmployeeID

-- Problem 13.	Write a SQL query to find the names of all employees whose 
--				last name is exactly 5 characters long. 
SELECT FirstName
	,LastName
FROM [SoftUni].[dbo].[Employees]
WHERE LEN(LastName) = 5

-- Problem 14.	Write a SQL query to display the current date and time in the 
--				following format "day.month.year hour:minutes:seconds:milliseconds". 
SELECT CONVERT(NVARCHAR(10), GETDATE(), 104) + ' ' + CONVERT(NVARCHAR(12), GETDATE(), 114)

-- Problem 15.	Write a SQL statement to create a table Users.
CREATE TABLE [SoftUni].[dbo].[Users] (
	UserId INT IDENTITY(1, 1) NOT NULL
	,UserName NVARCHAR(100) NOT NULL UNIQUE
	,[Password] NVARCHAR(100)
	,FullName NVARCHAR(100) NOT NULL
	,LastLoginTime DATETIME
	,CONSTRAINT PK_Users PRIMARY KEY (UserId)
	,CONSTRAINT chk_Paswword CHECK (LEN([Password]) >= 5)
	)

INSERT [SoftUni].[dbo].[Users] (
	UserName
	,[Password]
	,FullName
	,LastLoginTime
	)
VALUES (
	N'nakov'
	,N'123456'
	,N'asdasd'
	,CAST(N'2015-02-18 00:00:00.000' AS DATETIME)
	)
	,(
	N'joro'
	,N'1234567788'
	,N'234524224'
	,CAST(N'2015-02-10 00:00:00.000' AS DATETIME)
	)

-- Problem 16.	Write a SQL statement to create a view that displays the users 
--				from the Users table that have been in the system today.
CREATE VIEW [dbo].[TodayUsers]
AS
SELECT *
FROM [SoftUni].[dbo].[Users]
WHERE CONVERT(DATE, getdate()) = CONVERT(DATE, LastLoginTime)

-- Problem 17.	Write a SQL statement to create a table Groups. 
CREATE TABLE [SoftUni].[dbo].Groups (
	GroupId INT IDENTITY(1, 1) NOT NULL
	,NAME NVARCHAR(50) NOT NULL UNIQUE
	,CONSTRAINT PK_Groups PRIMARY KEY (GroupId)
	)

-- Problem 18.	Write a SQL statement to add a column GroupID to the table Users.
ALTER TABLE [SoftUni].[dbo].Users ADD GroupId INT FOREIGN KEY REFERENCES Groups (GroupId)

INSERT INTO [SoftUni].[dbo].[Groups] (NAME)
VALUES ('Facebook')
	,('Google+')
	,('Twitter')

-- Problem 19.	Write SQL statements to insert several records in the Users and Groups tables.
-- done above
-- Problem 20.	Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE [SoftUni].[dbo].[Users]
SET FullName = 'Nakov'
WHERE UserName = 'nakov'

UPDATE [SoftUni].[dbo].Groups
SET NAME = 'Dir.bg'
WHERE NAME = 'Twitter'

-- Problem 21.	Write SQL statements to delete some of the records from the Users
--				and Groups tables.
DELETE
FROM [SoftUni].[dbo].[Groups]
WHERE NAME = 'Dir.bg'

DELETE
FROM [SoftUni].[dbo].[Users]
WHERE UserName = 'joro'

-- Problem 22.	Write SQL statements to insert in the Users table the names 
--				of all employees from the Employees table.
INSERT INTO [SoftUni].[dbo].[Users]
SELECT LOWER(SUBSTRING(FirstName, 1, 1) + LastName + CAST(EmployeeID AS NVARCHAR))
	,LOWER(SUBSTRING(FirstName, 1, 1) + LastName) + '0000'
	,FirstName + ' ' + LastName
	,'2009-02-02'
	,NULL
FROM [SoftUni].[dbo].[Employees]

-- Problem 23.	Write a SQL statement that changes the password to NULL for 
--				all users that have not been in the system since 10.03.2010.
UPDATE [SoftUni].[dbo].[Users]
SET [Password] = NULL
WHERE LastLoginTime < CONVERT(DATE, '2010-03-10')

-- Problem 24.	Write a SQL statement that deletes all users without passwords (NULL password).
DELETE
FROM [SoftUni].[dbo].[Users]
WHERE [Password] IS NULL

-- Problem 25.	Write a SQL query to display the average employee salary 
--				by department and job title.
SELECT d.NAME
	,JobTitle
	,AVG(Salary) AS [Salary (Average)]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d ON d.DepartmentID = e.DepartmentID
GROUP BY d.NAME
	,JobTitle

-- Problem 26.	Write a SQL query to display the minimal employee salary 
--				by department and job title along with the name of some 
--				of the employees that take it.
SELECT d.NAME AS [Department]
	,FirstName
	,LastName
	,Salary AS [Minimal Salary]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d ON d.DepartmentID = e.DepartmentID
WHERE Salary = (
		SELECT MIN(Salary)
		FROM [SoftUni].[dbo].[Employees]
		WHERE DepartmentID = e.DepartmentID
		)
GROUP BY d.NAME
	,FirstName
	,LastName
	,Salary

--  Problem 27.	Write a SQL query to display the town where maximal number of employees work.
SELECT t.NAME AS Town
	,COUNT(t.TownID) AS [Employees by Town]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Addresses] a ON a.AddressID = e.AddressID
JOIN [SoftUni].[dbo].[Towns] t ON a.TownID = t.TownID
GROUP BY t.NAME
	,t.TownID

-- Problem 28.	Write a SQL query to display the number of managers from each town.
SELECT t.NAME AS Town
	,COUNT(DISTINCT e.ManagerID) AS [Number of Managers]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Addresses] a ON a.AddressID = e.AddressID
JOIN [SoftUni].[dbo].[Towns] t ON a.TownID = t.TownID
GROUP BY t.NAME

-- Problem 29.	Write a SQL to create table WorkHours to store work reports for each employee.
CREATE TABLE [SoftUni].[dbo].[WorkHours] (
	WorkHourId INT IDENTITY(1, 1) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES [SoftUni].[dbo].[Employees](EmployeeId) NOT NULL,
	[Date] DATETIME NULL
	,Task NVARCHAR(max) NOT NULL
	,[Hours] INT NOT NULL
	,Comments NTEXT NULL
	,CONSTRAINT PK_WorkHours PRIMARY KEY (WorkHourId)
	)



