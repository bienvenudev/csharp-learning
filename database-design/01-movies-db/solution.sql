-- Part 1: create the films table
CREATE TABLE films (
  name TEXT,
  release_year INTEGER
);

-- Part 2: insert favorite movies
INSERT INTO films (name, release_year)
VALUES ('The Matrix', 1999);

INSERT INTO films (name, release_year)
VALUES ('Monsters, Inc.', 2001);

INSERT INTO films (name, release_year)
VALUES ('Call Me By Your Name', 2017);

INSERT INTO films (name, release_year)
VALUES ('Inception', 2010);

-- Part 3: browse movies released in a given year
SELECT * FROM films WHERE release_year = 1999;

-- Part 4: add supplementary columns (existing rows get NULL until backfilled)
ALTER TABLE films ADD COLUMN runtime INTEGER;
ALTER TABLE films ADD COLUMN category TEXT;
ALTER TABLE films ADD COLUMN rating REAL;
ALTER TABLE films ADD COLUMN box_office BIGINT;

-- Part 5: backfill data for existing rows
UPDATE films
SET runtime = 148,
    category = 'Sci-Fi',
    rating = 8.8,
    box_office = 836848102
WHERE name = 'Inception';

UPDATE films
SET runtime = 136,
    category = 'Sci-Fi',
    rating = 8.7,
    box_office = 465343787
WHERE name = 'The Matrix';

UPDATE films
SET runtime = 92,
    category = 'Animation',
    rating = 8.1,
    box_office = 577425734
WHERE name = 'Monsters, Inc.';

UPDATE films
SET runtime = 132,
    category = 'Romance',
    rating = 7.9,
    box_office = 41879802
WHERE name = 'Call Me By Your Name';

-- Part 6: add a UNIQUE constraint on name
ALTER TABLE films
ADD CONSTRAINT unique_name UNIQUE (name);

-- inserting/updating a name that already exists: rejected, violates unique_name
-- adding a UNIQUE constraint already violated by existing data (e.g. category,
-- since Inception and The Matrix are both 'Sci-Fi'): fails immediately, no rows added/changed