-- Create a table named friends with id, name, and birthday
CREATE TABLE friends (
  id INTEGER,
  name TEXT,
  birthday DATE
);

-- Add Ororo Munroe to friends
INSERT INTO friends (id, name, birthday)
VALUES (1, "Ororo Munroe", "1940-05-30");

-- Make sure that Ororo has been added to the database
SELECT *
FROM friends;

-- Add two of your friends to the table
INSERT INTO friends (id, name, birthday)
VALUES (2, "Ben", "1940-05-30");

INSERT INTO friends (id, name, birthday)
VALUES (3, "Bob", "1940-05-30");

-- Ororo Munroe decided to change her name to Storm
UPDATE friends
SET name = "Storm"
WHERE id = 1;

-- Add a new column named email
ALTER TABLE friends
ADD COLUMN email TEXT;

-- Update the email address for everyone in your table
UPDATE friends
SET email = "storm@codecademy.com"
WHERE id = 1;

-- Storm is fictional, remove her from friends
DELETE FROM friends
WHERE id = 1;

-- Take a look at the result one last time
SELECT *
FROM friends;
