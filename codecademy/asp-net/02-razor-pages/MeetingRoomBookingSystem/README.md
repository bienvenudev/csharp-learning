# Meeting Room Booking System

A single-page Razor Pages app built for CorporateTech Solutions that displays meeting room details, availability, amenities, and booking confirmations. This is an introductory Razor Pages exercise covering the `@page` directive, C# expressions, conditionals, and loops.

## Features

- Displays room name, capacity, and current date/time
- Shows room availability based on the current hour (business hours, after-hours, closed)
- Room type descriptions via `@switch`
- Lists amenities with `@foreach`
- Displays available hourly time slots (9 to 17) with `@for`
- Generates booking confirmation numbers with `@while`
- Conditionally lists AV equipment when a projector is available

## Tech Stack

- ASP.NET Core Razor Pages
- C#

## Running the project

```bash
dotnet run
```

Then open the URL shown in the console (e.g. `https://localhost:5001`).
