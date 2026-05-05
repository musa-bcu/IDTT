# Gilded Rose starting position in C# xUnit

## Build the project

Use your normal build tools to build the projects in Debug mode.
For example, you can use the `dotnet` command line tool:

``` cmd
dotnet build GildedRose.sln -c Debug
```

## Run the Gilded Rose Command-Line program

For e.g. 10 days:

``` cmd
GildedRose/bin/Debug/net8.0/GildedRose 10
```

## Run all the unit tests

``` cmd
dotnet test
```

# Overview of Gilded Rose Refactoring Exercise (C#)

## Overview
This project is a refactored implementation of the classic Gilded Rose kata. The original codebase was difficult to maintain and extend due to tightly coupled logic inside a single update method.

The goal of this exercise was to:

- Preserve existing behaviour
- Fix failing/incorrect logic
- Add support for a new item type (Conjured items)
- Improve code structure, readability, and maintainability
- Add comprehensive unit test coverage

## Tech Stack

The solution was implemented in C# (.NET X) using the pre-configured xUnit test framework. 

## Key Improvements

1. Refactoring of existing logic

The original implementation contained a large, conditional-heavy UpdateQuality() method.

This has been improved by:

Separated logic by item type using a factory-based dispatcher to select the appropriate update handler per item.
Reduced nested conditionals by delegating behaviour to dedicated handlers per item type.
Improved readability, separation of concerns, and extensibility.
Removed magic numbers by introducing named constants in respective item type.

This makes it significantly easier to introduce new item types without modifying existing logic heavily.

2. New Feature: Conjured Items

Implemented support for Conjured items, as required.

Behaviour:
Degrade in Quality twice as fast as normal items
Before sell date: -2 Quality per day
After sell date: -4 Quality per day


3. Bug Fixes

Identified and fixed 4 logic defects during test coverage expansion.
These included edge-case errors in SellIn transition handling and incorrect Quality updates for specific item types.

4. Unit Testing Improvements

A total of ~15 unit tests were added to improve coverage and prevent regressions.
Coverage includes:
- Normal item degradation (before/after SellIn)
- Quality boundaries (0–40 constraints)
- Aged Brie increasing quality behaviour
- Sulfuras immutability
- Backstage Passes tiered increases and expiry behaviour
- Conjured item accelerated degradation

Result:
~4 previously failing tests were identified during development
All failing cases were fixed and validated through automated testing

5. Design Decisions

To improve maintainability, the following decisions were made:

Encapsulated item-specific behaviour into dedicated handlers to improve separation of concerns.
Avoided modifying the Item class (as per constraints)
Focused on extensibility for future item types
Prioritised readability over over-engineered abstractions

Trade-off:
A simple, explicit design was chosen over heavy design patterns to maintain clarity while still improving structure.