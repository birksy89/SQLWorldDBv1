SELECT *

--SELECT country.Name, city.Name, country.Continent

FROM country

INNER JOIN city

ON city.ID= country.Capital