USE SoftUni
GO

CREATE PROCEDURE usp_AllProjectsByEmployee
@employeeFirstName nvarchar(max), @employeeLastName nvarchar(max)
AS
SELECT p.*
FROM Employees e
JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE e.LastName = @employeeLastName AND e.FirstName = @employeeFirstName
GO