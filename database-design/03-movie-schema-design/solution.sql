CREATE TABLE movie (
id int PRIMARY KEY,
title text,
overview text,
status varchar(80),
score int CHECK (score >= 0 AND score <= 100),
release_year int,
rating text,
original_language text,
website text
);

CREATE TABLE category (
id int PRIMARY KEY,
name text
);

CREATE TABLE movie_category (
movie_id int REFERENCES movie(id),
category_id int REFERENCES category(id),
PRIMARY KEY(movie_id, category_id)
);

CREATE TABLE person (
id int PRIMARY KEY,
name text
);

CREATE TABLE movie_person (
movie_id int REFERENCES movie(id),
person_id int REFERENCES person(id),
movie_role varchar(30),
PRIMARY KEY (movie_id, person_id, movie_role)
);

CREATE TABLE review (
id int PRIMARY KEY,
movie_id int REFERENCES movie(id),
stars int CHECK (stars >= 1 AND stars <= 5),
description text
);

CREATE TABLE award (
id int PRIMARY KEY,
name text
);

CREATE TABLE nomination (
id int PRIMARY KEY,
movie_id int REFERENCES movie(id),
award_id int REFERENCES award(id),
year int,
won boolean default false
);

-- Movies
INSERT INTO movie (id, title, overview, status, score, release_year, rating, original_language, website) VALUES
(1, 'The Great Adventure', 'A hero embarks on a quest.', 'Released', 85, 2019, 'PG-13', 'en', 'https://greatadventure.example.com'),
(2, 'City of Shadows', 'A detective uncovers a conspiracy.', 'Released', 78, 2021, 'R', 'en', 'https://cityofshadows.example.com'),
(3, 'Laughing Matters', 'A comedy about family reunions.', 'Released', 65, 2020, 'PG', 'en', NULL),
(4, 'Silent Echoes', 'A drama exploring loss and memory.', 'Post Production', NULL, 2024, 'PG-13', 'fr', NULL);

-- Categories
INSERT INTO category (id, name) VALUES
(1, 'Action'),
(2, 'Mystery'),
(3, 'Comedy'),
(4, 'Drama');

-- Movie <-> Category (many-to-many: a movie can have several categories,
-- and a category applies to several movies)
INSERT INTO movie_category (movie_id, category_id) VALUES
(1, 1),
(1, 2),
(2, 2),
(2, 4),
(3, 3),
(4, 4);

-- People
INSERT INTO person (id, name) VALUES
(1, 'Alex Rivera'),
(2, 'Jordan Lee'),
(3, 'Morgan Blake'),
(4, 'Casey Nguyen');

-- Movie <-> Person (many-to-many with role: a person can work on several
-- movies in different roles, and a movie has several people attached)
INSERT INTO movie_person (movie_id, person_id, movie_role) VALUES
(1, 1, 'Director'),
(1, 2, 'Actor'),
(1, 3, 'Actor'),
(2, 1, 'Actor'),
(2, 3, 'Director'),
(3, 4, 'Director'),
(3, 2, 'Actor'),
(4, 4, 'Actor');

-- Reviews (one-to-many: a movie can have several reviews)
INSERT INTO review (id, movie_id, stars, description) VALUES
(1, 1, 5, 'Thrilling from start to finish.'),
(2, 1, 4, 'Great action, weak ending.'),
(3, 2, 3, 'Solid mystery but predictable.'),
(4, 3, 4, 'Funny and heartwarming.');

-- Awards
INSERT INTO award (id, name) VALUES
(1, 'Best Picture'),
(2, 'Best Director'),
(3, 'Audience Choice');

-- Nominations (one-to-many: a movie can have several nominations,
-- and an award is given out across several nominations/years)
INSERT INTO nomination (id, movie_id, award_id, year, won) VALUES
(1, 1, 1, 2019, true),
(2, 1, 2, 2019, false),
(3, 2, 1, 2021, false),
(4, 2, 3, 2021, true),
(5, 3, 3, 2020, false);