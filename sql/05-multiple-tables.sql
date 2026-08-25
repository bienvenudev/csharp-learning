-- Examine the three tables.
SELECT * FROM trips;

SELECT * FROM riders;

SELECT * FROM cars;

-- Try out a simple cross join between riders and cars.
SELECT *
FROM riders
CROSS JOIN cars;

-- Create a Trip Log with the trips and its users. Find the columns to join between trips and riders and combine the two tables using a LEFT JOIN.
SELECT trips.id, trips.cost,
  riders.username
FROM trips
LEFT JOIN riders
ON trips.rider_id = riders.id;

-- We want to create a link between the trips and the cars used during those trips. Find the columns to join on and combine the trips and cars table using an INNER JOIN.
SELECT trips.id, trips.cost,
  cars.model
FROM trips
JOIN cars
ON trips.car_id = cars.id;

-- The new riders data are in! There are three new users this month. Stack the riders table on top of the new table named riders2.
SELECT *
FROM riders
UNION
SELECT *
FROM riders2;

-- What is the average cost for a trip?
SELECT AVG(cost)
FROM trips;

-- Find all the riders who have used Lyft less than 500 times!
SELECT username
FROM riders
WHERE total_trips < 500
UNION
SELECT username
FROM riders2
WHERE total_trips < 500;

-- Calculate the number of cars that are active.
SELECT COUNT(*)
FROM cars
WHERE status = 'active';

-- Write a query that finds the two cars that have the highest trips_completed.
SELECT model, trips_completed
FROM cars
ORDER BY trips_completed DESC
LIMIT 2;
