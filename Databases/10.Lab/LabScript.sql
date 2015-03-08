-- Lab 1:
-- Lab 2:
-- Lab 3:
-- Lab 4:
-- Lab 5:
SELECT a.Content AS [Answer Content]
	,a.CreatedOn
	,u.Username AS [Answer Author]
	,q.Title AS [Question Title]
	,cat.NAME AS [Category Name]
FROM Answers a
JOIN Questions q ON a.QuestionId = q.Id
JOIN Categories cat ON q.CategoryId = cat.Id
JOIN Users u ON a.UserId = u.Id
ORDER BY [Category Name]
	,[Answer Author]
	,CreatedOn
GO

-- Lab 6:
SELECT cat.NAME
	,q.Title
	,q.CreatedOn
FROM Categories cat
LEFT JOIN Questions q ON q.CategoryId = cat.Id
ORDER BY cat.NAME
GO

-- Lab 7:
SELECT u.Id
	,u.Username
	,u.FirstName
	,u.PhoneNumber
	,u.RegistrationDate
	,u.Email
FROM Users u
WHERE u.PhoneNumber IS NULL
	AND u.Id NOT IN (
		SELECT DISTINCT UserId
		FROM Questions
		)
ORDER BY u.RegistrationDate
GO

-- Lab 8:
SELECT MIN(CreatedOn) AS MinDate, MAX(CreatedOn) AS MaxDate
FROM Answers
WHERE Year(CreatedOn) = '2012' OR YEAR(CreatedOn) = '2014'
GO

-- Lab 9:
SELECT TOP 10 Content
	,CreatedOn
	,u.Username
FROM Answers a
JOIN Users u ON a.UserId = u.Id
ORDER BY CreatedOn
GO

-- Lab 10:
DECLARE @last_year datetime = (SELECT MAX(CreatedOn) FROM Answers)
DECLARE @last_month datetime = (SELECT Month(MAX(CreatedOn)) FROM Answers WHERE YEAR(CreatedOn) = YEAR(@last_year))
DECLARE @first_month datetime =(SELECT Month(MIN(CreatedOn)) FROM Answers WHERE YEAR(CreatedOn) = YEAR(@last_year))
SELECT a.Content AS [Answer Content], q.Title AS Question, c.Name AS Category
FROM Answers a
JOIN Questions q ON a.QuestionId=q.Id
JOIN Categories c ON q.CategoryId= c.Id
WHERE a.IsHidden = 1 AND (YEAR(a.CreatedOn) = YEAR(@last_year) AND (MONTH(a.CreatedOn) = MONTH(@first_month) OR MONTH(a.CreatedOn) = MONTH(@last_month)))
ORDER BY c.Name
GO

-- Lab 11:
SELECT c.Name as Category, count(a.Id) AS [Answers Count]
FROM Categories c
LEFT JOIN Questions q ON c.Id = q.CategoryId
LEFT JOIN Answers a ON a.QuestionId = q.Id
GROUP BY c.Name
ORDER BY [Answers Count] DESC
GO

-- Lab 12:
SELECT c.Name AS Category, u.Username, u.PhoneNumber, count(a.Id) AS [Answers Count]
FROM Categories c
	JOIN Questions q ON c.Id=q.CategoryId
	JOIN Answers a ON q.Id=a.QuestionId
	JOIN Users u ON a.UserId = u.Id
	GROUP BY c.Name, u.Username, u.PhoneNumber
		HAVING (u.PhoneNumber IS NOT NULL)
	ORDER BY [Answers Count] DESC
GO

-- Lab 13:
SELECT *
FROM 

GO
-- Lab 14:
