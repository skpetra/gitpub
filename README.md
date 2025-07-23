# GitPub API

A modern .NET 9 Web API application for managing quizzes and questions. The application provides RESTful endpoints for creating, retrieving, exporting, and deleting quizzes with full support for question reuse and pagination.

## Features
The API supports the following operations:

- Fetch all quizzes
- Fetch all questions
- Create a new quiz
- Edit an existing quiz
- Delete a quiz
- Export a quiz

## Getting Started
### Prerequisites
Before running the application, make sure you have the following installed:
- .NET 9 SDK
- SQL Server

### 1. Clone the Repository
### 2. Database Configuration
If needed, update the connection string in `appsettings.Development.json` to match your SQL Server configuration. The application automatically applies migrations on startup.
### 3. Run the Application
To start the API, navigate to the folder containing the `WebAPI.csproj` file and run:
```
dotnet run
```
By default, the application will be available at:
- https://localhost:7049
- http://localhost:5131

### 4. Access Swagger API Documentation
You can explore and test all available API endpoints through the Swagger UI.
Once the application is running, Swagger can be accessed at:
```
<your-base-url>/swagger
```

## Technology Stack
- **.NET 9**
- **Entity Framework Core**
- **SQL Server**
- **FastEndpoints** 
- **Serilog**
- **Mapster**
