# xUnit Getting Started: PlayerCharacter/GameEngine

This directory contains the xUnit "Getting Started" course exercise for the
`GameEngine` class library. The production code models a small game domain with
player characters, enemies, enemy creation, and shared game state. The exercise
focuses on building and organizing tests around that existing domain model.

## Projects

- `GameEngine` contains the course-provided production classes, including
  `PlayerCharacter`, `NonPlayerCharacter`, enemy types, `EnemyFactory`, and
  `GameState`.
- `GameEngine.Tests` contains the xUnit test suite and references the production
  project.

## Testing coverage

The test suite demonstrates:

- `[Fact]` tests for individual, repeatable examples
- `[Theory]` tests for the same behavior across multiple inputs
- Assertions for Boolean values, equality, inequality, ranges, null values,
  strings, collections, types, assignability, exceptions, events, and property
  changes
- Inline, member, CSV-based, and custom `DataAttribute` test data
- Test fixtures and collection fixtures for shared `GameState` setup
- `ITestOutputHelper` for test output
- Test categorization and skipped tests
- `IDisposable`-based test lifecycle handling

## Exercise context

This is training material from the xUnit "Getting Started" course. The
`PlayerCharacter` and other `GameEngine` classes are provided exercise code;
the purpose of this directory is to demonstrate test construction, xUnit
features, and test organization rather than to present a new game implementation.

## Running the tests

The solution is intended to be opened as `Game.sln` and executed with the
standard .NET test runner. The test project copies `TestData.csv` to its output
directory because the custom data attribute reads that file when running the
data-driven health tests.