-- Get a feel for the nomnom table
SELECT *
FROM nomnom;

-- What are the distinct neighborhoods?
SELECT DISTINCT neighborhood
FROM nomnom;

-- What are the distinct cuisine types?
SELECT DISTINCT cuisine
FROM nomnom;

-- Suppose we would like some Chinese takeout.
-- What are our options?
SELECT name
FROM nomnom
WHERE cuisine = 'Chinese';

-- Return all the restaurants with reviews of 4 and above.
SELECT name, review
FROM nomnom
WHERE review >= 4;

-- Return all the restaurants that are Italian and $$$.
SELECT name, cuisine, price
FROM nomnom
WHERE cuisine = 'Italian'
  AND price = '$$$';

-- A restaurant that contains the word meatball in it
SELECT name
FROM nomnom
WHERE name LIKE '%meatball%';

-- Find all the close by spots in Midtown, Downtown or Chinatown.
SELECT name, neighborhood
FROM nomnom
WHERE neighborhood = 'Midtown' OR neighborhood = 'Downtown' OR neighborhood = 'Chinatown';

-- Find all the health grade pending restaurants (empty values).
SELECT name, health
FROM nomnom
WHERE health IS NULL;

-- Create a Top 10 Restaurants Ranking based on reviews.
SELECT name, review
FROM nomnom
ORDER BY review DESC
LIMIT 10;

-- Use a CASE statement to change the rating system to:
SELECT name, review,
  CASE
    WHEN review > 4.5 THEN 'Extraordinary'
    WHEN review > 4 THEN 'Excellent'
    WHEN review > 3 THEN 'Good'
    WHEN review > 2 THEN 'Fair'
    ELSE 'Poor'
  END AS 'rating'
FROM nomnom;
