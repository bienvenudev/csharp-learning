# Restaurant Menu — PostgreSQL Database Design

Database schema for **Bytes of China**, a Chinatown restaurant, designed to power its menu and reviews web pages.

## Schema

- **restaurant** — restaurant info (name, description, rating, telephone, hours)
- **address** — restaurant address (one-to-one with `restaurant`)
- **category** — menu categories (e.g. Chicken, Luncheon Specials), 2-char id
- **dish** — individual dishes (name, description, hot & spicy flag)
- **categories_dishes** — cross-reference table implementing the many-to-many relationship between `category` and `dish`, with a category-specific `price` and composite primary key
- **review** — customer reviews (one-to-many with `restaurant`)

## Relationships

- `restaurant` ↔ `address`: one-to-one
- `restaurant` → `review`: one-to-many
- `category` ↔ `dish`: many-to-many (via `categories_dishes`)

## Contents

`solution.sql` contains, in order:
1. Table creation with primary/foreign keys
2. Queries validating the foreign keys
3. Sample data inserts
4. Sample queries (restaurant info, best rating, dishes by price/category, spicy dishes, dishes appearing in multiple categories)
