# Quizini

A simple desktop quiz app for Windows, built with WPF (.NET 6). Load a quiz from a SQLite database file, answer multiple-choice questions against a countdown timer, and see your score at the end.

## Features

- Load quiz data from any `.db` (SQLite) file via a file picker
- Multiple-choice questions with four answer options each
- Per-quiz countdown timer (30 seconds per question)
- Live score tracking, shown as `points / total questions`
- Question and answer text stored Base64-encoded in the database and decoded at load time

## Tech stack

- **.NET 6** / **C#**
- **WPF** with the MVVM pattern (`Model` / `View` / `ViewModel`)
- **Microsoft.Data.Sqlite** for reading quiz data

## Project structure

```text
Model/       Quiz, Question, Answer entities + DataAccess (SQLite reads)
View/        MainWindow (XAML UI)
ViewModel/   MainViewModel (state, timer, scoring) + RelayCommand
```

## Database schema

The app expects a SQLite database with the following tables:

- `quiz(id, title)`
- `question(id, quiz_id, title)`
- `answer(id, question_id, text, is_correct)`

`title`/`text` fields for questions and answers are expected to be Base64-encoded strings.

## Getting started

### Prerequisites

- Windows
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

### Run

```sh
dotnet restore
dotnet run
```

Then click **Wczytaj** to select a quiz `.db` file, and **Rozpocznij** to start the quiz.

## Status

Small personal/learning project — not production hardened.
