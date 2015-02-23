-- Problem 4.	Write a SQL query to find all information about all departments
SELECT *
FROM [SoftUni].[dbo].[Departments]

-- Problem 5.	Write a SQL query to find all department names.
SELECT DISTINCT [Name]
FROM [SoftUni].[dbo].[Departments]

-- Problem 6.	Write a SQL query to find the salary of each employee.
SELECT FirstName, LastName, Salary
FROM [SoftUni].[dbo].[Employees]

-- Problem 7.	Write a SQL to find the full name of each employee.
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM [SoftUni].[dbo].[Employees]

-- Problem 8.	Write a SQL query to find the email addresses of each employee.
SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Addresses]
FROM [SoftUni].[dbo].[Employees]

-- Problem 9.	Write a SQL query to find all different employee salaries.
SELECT DISTINCT Salary AS [Distinct Salaries]
FROM [SoftUni].[dbo].[Employees]

-- Problem 10.	Write a SQL query to find all information about the employees
--				whose job title is “Sales Representative“.
SELECT *
FROM [SoftUni].[dbo].[Employees]
WHERE JobTitle = 'Sales Representative'

-- Problem 11.	Write a SQL query to find the names of all employees whose
--				first name starts with "SA".
SELECT FirstName, LastName
FROM [SoftUni].[dbo].[Employees]
WHERE FirstName LIKE 'SA%'

-- Problem 12.	Write a SQL query to find the names of all employees
--				whose last name contains "ei".
SELECT FirstName, LastName
FROM [SoftUni].[dbo].[Employees]
WHERE LastName LIKE '%ei%'

-- Problem 13.	Write a SQL query to find the salary of all employees
--				whose salary is in the range [20000…30000].
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM [SoftUni].[dbo].[Employees]
WHERE Salary BETWEEN 20000 AND 30000

-- Problem 14.	Write a SQL query to find the names of all employees
--				whose salary is 25000, 14000, 12500 or 23600.
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM [SoftUni].[dbo].[Employees]
WHERE Salary IN (12500, 14000, 23600, 25000)
ORDER BY Salary

-- Problem 15.	Write a SQL query to find all employees that do not have manager.
SELECT FirstName + ' ' + LastName AS [Full Name], ManagerID
FROM [SoftUni].[dbo].[Employees]
WHERE ManagerID IS NULL

-- Problem 16.	Write a SQL query to find all employees that have salary more than 50000.
--				Order them in decreasing order by salary.
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM [SoftUni].[dbo].[Employees]
WHERE Salary > 50000
ORDER BY Salary

-- Problem 17.	Write a SQL query to find the top 5 best paid employees.
SELECT TOP (5) FirstName,
	 LastName,
	 Salary
FROM [SoftUni].[dbo].[Employees]
ORDER BY Salary DESC

-- Problem 18.	Write a SQL query to find all employees along with their address.
SELECT FirstName,
	 LastName,
	 AddressText
FROM [SoftUni].[dbo].[Employees] e
	JOIN [SoftUni].[dbo].[Addresses] a
		ON e.AddressID = a.AddressID

-- Problem 19.	Write a SQL query to find all employees and their address.
SELECT FirstName, LastName,	 AddressText
FROM [SoftUni].[dbo].[Employees] e, [SoftUni].[dbo].[Addresses] a
WHERE e.AddressID = a.AddressID

-- Problem 20.	Write a SQL query to find all employees along with their manager.
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],
	 m.FirstName + ' ' + m.LastName AS [Mananager Name]
FROM [SoftUni].[dbo].[Employees] e
	JOIN [SoftUni].[dbo].[Employees] m
		ON e.ManagerID = m.EmployeeID

-- Problem 21.	Write a SQL query to find all employees, along with their 
--				manager and their address.
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],
	 a.AddressText AS [Living on],
	 m.FirstName + ' ' + m.LastName AS [with Mananager]
FROM [SoftUni].[dbo].[Employees] e
	JOIN [SoftUni].[dbo].[Employees] m 
		ON e.ManagerID = m.EmployeeID
	JOIN [SoftUni].[dbo].[Addresses] a
		ON e.AddressID = a.AddressID

-- Problem 22.	Write a SQL query to find all departments and all town names
--				as a single list.
SELECT [Name]
FROM [SoftUni].[dbo].[Departments]
UNION
SELECT [Name]
FROM [SoftUni].[dbo].[Towns]

-- Problem 23.	Write a SQL query to find all the employees and the manager
--				for each of them along with the employees that do not have manager. 
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name],
	 e.ManagerID,
	 CASE 
		WHEN (m.ManagerID IS NOT NULL)
			THEN (m.FirstName + ' ' + m.LastName)
		ELSE 'self'
		END AS [Managed by]
FROM [SoftUni].[dbo].[Employees] e
	LEFT OUTER JOIN [SoftUni].[dbo].[Employees] m 
		ON e.EmployeeID = m.EmployeeID
ORDER BY e.ManagerID

SELECT m.FirstName, m.LastName, m.ManagerID
FROM [SoftUni].[dbo].[Employees] e
	RIGHT OUTER JOIN [SoftUni].[dbo].[Employees] m 
		ON e.EmployeeID = m.EmployeeID
ORDER BY e.ManagerID

-- Problem 24.	Write a SQL query to find the names of all employees from
--				the departments "Sales" and "Finance" whose hire year is
--				between 1995 and 2005.
SELECT e.FirstName, e.LastName, d.NAME AS Department, e.HireDate
FROM [SoftUni].[dbo].[Employees] e
	JOIN [SoftUni].[dbo].[Departments] d 
		ON e.DepartmentID = d.DepartmentID
WHERE (YEAR(e.HireDate) BETWEEN 1995 AND 2005)
	AND (d.NAME = 'Sales' OR d.NAME = 'Finance')
ORDER BY e.HireDate