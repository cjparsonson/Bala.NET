# Bala.NET - Digital Bullet Journal

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A simple yet powerful digital bullet journal app to track your daily thoughts, moods, and reflections.

## Table of Contents

- [Features](#features)
- [Demo](#demo)
- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Add Daily Entries:** Capture your thoughts, mood, and reflections for each day.
- **Mood Tracking:** Select from a range of moods to reflect how you're feeling.
- **Filtering and Sorting:** Easily find entries by date or mood.
- **Editing and Deleting:** Update or remove entries as needed.

(More features on the way...)

## Demo

(Will be added once a MVP is ready)

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [SQLite](https://www.sqlite.org/index.html)

### Installation

1. Clone the repository:

   ```bash
   git clone [project-url]
   ```

2. Navigate to the project directory:

   ```bash
   cd DigitalBulletJournal
   ```

3. Install dependencies: (adjust the file name if different)

   ```bash
   dotnet restore Bala.BulletJournal/Bala.BulletJournal.csproj
   ```

4. Update Database:

   ```bash
   dotnet ef database update --project Bala.BulletJournal/Bala.BulletJournal.csproj
   ```

5. Run the app:

   ```bash
   dotnet run --project Bala.BulletJournal/Bala.BulletJournal.csproj
   ```

## Usage

(Instructions will be added once a MVP is ready)

## Contributing

Contributions are welcome! Please read the [CONTRIBUTING.md](CONTRIBUTING.md) file for details on our code of conduct, and the process for submitting pull requests.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Progress

✅ = Completed, 🚧 = In Progress, ❌ = Not Started

- ✅ Create Models, DbContext and Seed Data
