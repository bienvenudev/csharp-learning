# Game Catalog API

Codecademy "Learn ASP.NET" — Controller-Based APIs module.

## What it does

REST API for managing a game catalog and its reviews: list all games, get by
ID, search by title/genre/release year, create/update/delete games, and
manage reviews for a given game. Data is in-memory (seeded on startup, reset
on restart) — no database.

## Endpoints

### Games

- `GET /api/Games` — all games
- `GET /api/Games/{id}` — single game or 404
- `GET /api/Games/search?title=&genre=&releaseYear=` — filtered search
- `POST /api/Games` — create (201, validated)
- `PUT /api/Games/{id}` — update or 404
- `DELETE /api/Games/{id}` — delete (also removes its reviews)

### Reviews

- `GET /api/Games/{gameId}/reviews` — reviews for a game, or 404 if the game doesn't exist
- `POST /api/Games/{gameId}/reviews` — create a review for a game (201, validated)
- `GET /api/Reviews/{id}` — single review by ID or 404
- `DELETE /api/Reviews/{id}` — delete a review

## Running it

```
dotnet run
```

Swagger UI is available at `/swagger` in development. Sample requests for
every endpoint are in `GameCatalogApi.http`.

## Concepts demonstrated

`[ApiController]`, attribute routing (including nested routes for a related
resource), HTTP verb attributes, `ActionResult<T>`, `[FromQuery]` binding,
model validation via data annotations, singleton dependency injection for
shared in-memory state, and Swagger/OpenAPI setup via Swashbuckle.
