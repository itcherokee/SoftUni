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