# MyContacts

A contact management application built with Blazor, MediatR, EF Core and SQLite.

## Features

- Create contacts
- View contacts
- Update contacts
- Delete contacts
- Validation using Data Annotations
- Delete confirmation
- CQRS pattern using MediatR
- SQLite persistence with Entity Framework Core

## Technologies

- .NET 8
- Blazor Server
- MediatR
- Entity Framework Core
- SQLite

## Architecture

```text
Blazor UI
    ↓
MediatR
    ↓
Commands / Queries
    ↓
Handlers
    ↓
EF Core
    ↓
SQLite
```

## Implemented Commands and Queries

### Commands

- CreateContactCommand
- UpdateContactCommand
- DeleteContactCommand

### Queries

- GetContactsQuery

## Getting Started

### Clone the repository

```bash
git clone <repository-url>
```

### Restore packages

```bash
dotnet restore
```

### Apply migrations

```bash
dotnet ef database update
```

### Run the application

```bash
dotnet run
```

## Roadmap

- Search
- Sorting
- FluentValidation
- Minimal API
- Swagger
- Serilog
- Global Exception Handling
- Pagination
- CSV Export
- Dark Mode

## License

MIT
