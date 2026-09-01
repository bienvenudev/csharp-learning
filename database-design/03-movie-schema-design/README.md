# Movie Schema Design

A relational schema for a movie database, modeling movies, people, categories,
reviews, and awards.

## Tables

- **movie** — core movie data (title, overview, status, score, release year, rating, language, website)
- **category** — genres/categories (e.g. Action, Comedy)
- **movie_category** — many-to-many join between movies and categories
- **person** — people involved in movies (directors, actors, etc.)
- **movie_person** — many-to-many join between movies and people, tagged with a `movie_role` (e.g. Director, Actor)
- **review** — one-to-many: a movie can have several star ratings and descriptions
- **award** — award names (e.g. Best Picture)
- **nomination** — one-to-many: links a movie to an award for a given year, with a `won` flag

## Files

- `movie-schema.dbml` — schema definition in [dbdiagram.io](https://dbdiagram.io) DBML format
- `movie-schema.png` — rendered ER diagram
- `solution.sql` — `CREATE TABLE` statements plus sample data (`INSERT`s) for testing
