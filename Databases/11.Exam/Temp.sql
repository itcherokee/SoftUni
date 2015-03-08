-- Problem 13
SELECT  DISTINCT c.CountryName
	,IIF(p.PeakName IS NULL, '(no highest peak)', p.PeakName) AS [Highest Peak Name]
	,IIF(p.Elevation IS NULL, 0, MAX(p.Elevation)) AS [Highest Peak Elevation]
	,ISNULL(m.MountainRange, '(no mountain)') AS Mountain
FROM Countries c
LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
 JOIN Mountains m ON mc.MountainId = m.Id
 JOIN Peaks p ON m.Id = p.MountainId
GROUP BY c.CountryName, p.PeakName, p.Elevation, m.MountainRange
ORDER BY c.CountryName, [Highest Peak Name]

-- Problem 13
SELECT  c.CountryName, p.PeakName, MAX(p.Elevation), m.
	
FROM Countries c
JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
JOIN Mountains m ON mc.MountainId = m.Id
JOIN Peaks p ON m.Id = p.MountainId
GROUP BY c.CountryName, p.PeakName, p.Elevation, m.MountainRange
HAVING p.Elevation = MAX(p.Elevation)
ORDER BY c.CountryName
