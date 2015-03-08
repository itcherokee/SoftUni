-- Problem 1
SELECT PeakName
FROM Peaks p
ORDER BY p.PeakName

-- Problem 2
SELECT TOP 30 CountryName
	,Population
FROM Countries c
JOIN Continents con ON c.ContinentCode = con.ContinentCode
WHERE con.ContinentName = 'Europe'
ORDER BY Population DESC

-- Problem 3
SELECT CountryName
	,CountryCode
	,IIF(CUR.CurrencyCode = 'EUR', 'Euro', 'Not Euro') AS Currency
FROM Countries c
LEFT JOIN Currencies cur ON c.CurrencyCode = cur.CurrencyCode
ORDER BY C.CountryName

-- Problem 4
SELECT CountryName AS [Country Name]
	,c.IsoCode AS [ISO Code]
FROM Countries c
WHERE CountryName LIKE '%A%A%A%'
ORDER BY c.IsoCode

-- Problem 5
SELECT p.PeakName
	,m.MountainRange AS Mountain
	,p.Elevation
FROM Peaks p
JOIN Mountains m ON p.MountainId = m.Id
ORDER BY p.Elevation DESC

-- Problem 6
SELECT p.PeakName
	,m.MountainRange AS Mountain
	,c.CountryName
	,con.ContinentName
FROM Peaks p
JOIN Mountains m ON p.MountainId = m.Id
JOIN MountainsCountries mc ON m.Id = mc.MountainId
JOIN Countries c ON mc.CountryCode = c.CountryCode
JOIN Continents con ON c.ContinentCode = con.ContinentCode
ORDER BY p.PeakName
	,c.CountryName

-- Problem 7
SELECT r.RiverName AS River
	,count(c.CountryCode) AS [Countries Count]
FROM Rivers r
JOIN CountriesRivers cr ON r.Id = cr.RiverId
JOIN Countries c ON cr.CountryCode = c.CountryCode
GROUP BY r.RiverName
HAVING count(c.CountryCode) >= 3
ORDER BY r.RiverName

-- Problem 8
SELECT MAX(p.Elevation) AS MaxElevation
	,MIN(p.Elevation) AS MinElevation
	,AVG(p.Elevation) AS AverageElevation
FROM Peaks p

-- Problem 9
SELECT c.CountryName
	,con.ContinentName
	,IIF(count(r.Id) = 0, 0, count(r.Id)) AS RiversCount
	,IIF(SUM(r.Length) IS NULL, 0, SUM(r.Length)) AS TotalLength
FROM Countries c
LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r ON cr.RiverId = r.Id
JOIN Continents con ON c.ContinentCode = con.ContinentCode
GROUP BY c.CountryName
	,con.ContinentName
ORDER BY RiversCount DESC
	,TotalLength DESC
	,c.CountryName

-- Problem 10
SELECT cur.CurrencyCode
	,cur.Description AS Currency
	,count(c.CurrencyCode) AS NumberOfCountries
FROM Currencies cur
LEFT JOIN Countries c ON cur.CurrencyCode = c.CurrencyCode
GROUP BY cur.CurrencyCode
	,cur.Description
ORDER BY NumberOfCountries DESC
	,cur.Description

-- Problem 11
SELECT ContinentName
	,SUM(c.AreaInSqKm) AS CountriesArea
	,SUM(CAST(c.Population AS BIGINT)) AS CountriesPopulation
FROM Continents con
LEFT JOIN Countries c ON con.ContinentCode = c.ContinentCode
GROUP BY con.ContinentName
ORDER BY CountriesPopulation DESC

-- Problem 12
SELECT c.CountryName
	,MAX(p.Elevation) AS HighestPeakElevation
	,MAX(r.Length) AS LongestRiverLength
FROM Countries c
LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m ON mc.MountainId = m.Id
LEFT JOIN Peaks p ON m.Id = p.MountainId
LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC
	,LongestRiverLength DESC
	,c.CountryName

-- Problem 13
SELECT p.PeakName
	,r.RiverName
	,LOWER(p.PeakName + RIGHT(r.RiverName, LEN(r.RiverName) - 1)) AS Mix
FROM Peaks p
	,Rivers r
WHERE (SELECT RIGHT(p.PeakName, 1)) = (SELECT LEFT(r.RiverName, 1))
ORDER BY Mix

--Problem 15
CREATE TABLE Monasteries(
	Id int IDENTITY NOT NULL PRIMARY KEY,
	Name nvarchar(100) NOT NULL,
	CountryCode char(2) NOT NULL
	)

ALTER TABLE Monasteries ADD  CONSTRAINT FK_Monasteries_Countries 
FOREIGN KEY(CountryCode)
REFERENCES Countries (CountryCode)

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

ALTER TABLE Countries 
ADD IsDeleted bit 
DEFAULT 0

UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode in (
SELECT c.CountryCode FROM Countries c
JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
JOIN Rivers r ON cr.RiverId = r.Id
GROUP BY c.CountryCode
HAVING count(r.Id) > 3)

SELECT m.Name AS Monastery, c.CountryName AS Country
FROM Monasteries m
LEFT JOIN Countries c ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0 OR c.IsDeleted IS NULL
ORDER BY m.Name

-- Problem 16
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries
VALUES ('Hanga Abbey',  (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania') )

-- Next SQL command will not be executed because there is no more 'Myanmar' in table
INSERT INTO Monasteries
VALUES ('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Myanmar') )

SELECT con.ContinentName, c.CountryName, count(m.Id) AS MonasteriesCount
FROM Monasteries m
RIGHT JOIN Countries c ON m.CountryCode = c.CountryCode
JOIN Continents con ON c.ContinentCode = con.ContinentCode
GROUP BY con.ContinentName, c.CountryName, c.IsDeleted
HAVING c.IsDeleted = 0 OR c.IsDeleted IS NULL
ORDER BY MonasteriesCount DESC, c.CountryName 

-- Problem 18
CREATE DATABASE `trainings` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;

USE trainings;

CREATE TABLE courses(
	id int not null auto_increment primary key,
    name nvarchar(300) not null,
    description nvarchar(500)
);

CREATE TABLE training_centers(
	id int not null auto_increment primary key,
    name nvarchar(300) not null,
    description nvarchar(500),
    url nvarchar(200)
);


CREATE TABLE timetable(
	id int not null auto_increment primary key,
    course_id int not null,
    training_center_id int not null,
    start_date date
);

ALTER TABLE timetable ADD CONSTRAINT fk_timetable_courses
FOREIGN KEY (course_id) REFERENCES courses(id);

ALTER TABLE timetable ADD CONSTRAINT fk_timetable_training_centers
FOREIGN KEY (training_center_id) REFERENCES training_centers(id);

INSERT INTO `training_centers` VALUES (1, 'Sofia Learning', NULL, 'http://sofialearning.org'), (2, 'Varna Innovations & Learning', 'Innovative training center, located in Varna. Provides trainings in software development and foreign languages', 'http://vil.edu'), (3, 'Plovdiv Trainings & Inspiration', NULL, NULL),
(4, 'Sofia West Adult Trainings', 'The best training center in Lyulin', 'https://sofiawest.bg'), (5, 'Software Trainings Ltd.', NULL, 'http://softtrain.eu'),
(6, 'Polyglot Language School', 'English, French, Spanish and Russian language courses', NULL), (7, 'Modern Dances Academy', 'Learn how to dance!', 'http://danceacademy.bg');

INSERT INTO `courses` VALUES (101, 'Java Basics', 'Learn more at https://softuni.bg/courses/java-basics/'), (102, 'English for beginners', '3-month English course'), (103, 'Salsa: First Steps', NULL), (104, 'Avancée Français', 'French language: Level III'), (105, 'HTML & CSS', NULL), (106, 'Databases', 'Introductionary course in databases, SQL, MySQL, SQL Server and MongoDB'), (107, 'C# Programming', 'Intro C# corse for beginners'), (108, 'Tango dances', NULL), (109, 'Spanish, Level II', 'Aprender Español');

INSERT INTO `timetable`(course_id, training_center_id, start_date) VALUES (101, 1, '2015-01-31'), (101, 5, '2015-02-28'), (102, 6, '2015-01-21'), (102, 4, '2015-01-07'), (102, 2, '2015-02-14'), (102, 1, '2015-03-05'), (102, 3, '2015-03-01'), (103, 7, '2015-02-25'), (103, 3, '2015-02-19'), (104, 5, '2015-01-07'), (104, 1, '2015-03-30'), (104, 3, '2015-04-01'), (105, 5, '2015-01-25'), (105, 4, '2015-03-23'), (105, 3, '2015-04-17'), (105, 2, '2015-03-19'), (106, 5, '2015-02-26'), (107, 2, '2015-02-20'), (107, 1, '2015-01-20'), (107, 3, '2015-03-01'), (109, 6, '2015-01-13');

UPDATE `timetable` t JOIN `courses` c ON t.course_id = c.id
SET t.start_date = DATE_SUB(t.start_date, INTERVAL 7 DAY)
WHERE c.name REGEXP '^[a-j]{1,5}.*s$';

SELECT tc.name AS `traning center`, 
t.start_date AS `start date`,
c.name AS `course name`,
IFNULL(c.description, 'NULL') AS `more info`
FROM timetable t
JOIN training_centers tc ON t.training_center_id=tc.id
JOIN courses c ON t.course_id = c.id
ORDER BY t.start_date, t.id