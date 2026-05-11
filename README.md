# Mu Farm

A backend-focused Farm Simulator project built from scratch to demonstrate modern software development practices, including layered architecture, testing, and deployment.


## Purpose

This project demonstrates building software from scratch while applying modern software development practices. These practices are reflected from the initial setup through implementation and testing, and continue through to deployment.


## Features

- Manage crops and crop growth jobs  
- Simulate crop growth using background workers  
- RESTful API design following best practices  
- PostgreSQL integration with Docker-based setup  
- Scalable and maintainable layered architecture  


## Tech Stack

- **Backend:** ASP.NET Core Web API (.NET 10)  
- **Background Processing:** .NET Worker Service  
- **Database:** PostgreSQL with Docker  
- **ORM:** Entity Framework Core  
- **Architecture:** Layered architecture for separation of concerns (API, Application, Domain, Infrastructure)  
- **Testing:** xUnit (planned for unit and integration testing)  
- **Version Control:** Git with GitHub  


## Architecture

The project follows a layered architecture:

- **API** – Handles HTTP requests and responses  
- **Application** – Contains business logic and use cases  
- **Domain** – Core entities and domain rules  
- **Infrastructure** – Database access and external services  
- **Worker** – Monitors crop jobs and updates growth status in the background  

This structure ensures separation of concerns and maintainability.


## Key Dependencies

### Database
- Npgsql.EntityFrameworkCore.PostgreSQL – PostgreSQL provider for EF Core


## Getting Started

### Prerequisites
- .NET SDK
- Docker Desktop

### Running the Database

To start the PostgreSQL database using Docker, navigate to the `docker` folder and run:

docker-compose up -d

### Run Migrations

From the `src` folder, run the following command to apply database migrations:

dotnet ef database update --project MuFarm.Infrastructure --startup-project MuFarm.API

If dotnet-ef is not installed, install it globally using:

dotnet tool install --global dotnet-ef


## Project Status

This project is currently in active development. Features and structure may evolve as new concepts and practices are applied. 


## Technical Decisions

### Guid vs. int

I’m using GUIDs for primary keys since they’re globally unique and don’t rely on the database generating sequential IDs. It also helps when thinking about scaling or if multiple services end up creating data.

It’s also nice that they’re harder to predict when exposed through APIs.

### Switching to PostgreSQL with Docker

This project uses PostgreSQL to emphasize portability and modern development practices. PostgreSQL integrates well with Docker, making local setup and deployment more consistent across environments.

It also allows me to apply my SQL Server knowledge while adapting to a widely used, open-source relational database with minimal syntax differences. 
