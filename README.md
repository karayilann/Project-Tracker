# ProjectTracker

ProjectTracker is a web API application built with modern .NET 8 technologies and JWT-based authentication, designed for teams to easily manage their projects, tasks, and user roles.

## Features

* **JWT Authentication:** Secure user login and token-based authentication.
* **User Management:** Create, update, delete, and list users.
* **Role Management:** Create and assign user roles.
* **Project Management:** Add, update, delete projects and assign users to projects.
* **WorkItem Management:** Create, update, delete, and list tasks based on projects.
* **FluentValidation:** Advanced model validation.
* **Swagger/OpenAPI:** Automatic API documentation and testing interface.
* **AutoMapper:** Automatic mapping for DTO and Entity conversions.
* **Dependency Injection:** Modular and testable service architecture using Autofac.
* **Entity Framework Core:** Powerful data access with SQL Server.
* **Layered Architecture:** Clean code structure with API, Service, Repository, and Core layers.

## Layers and Architecture

* **API:** The layer that handles HTTP requests and exposes endpoints to the outside world. Controllers are located here.
* **Service:** The layer containing business rules and application logic.
* **Repository:** The layer abstracting database operations.
* **Core:** The layer containing Entity, DTO, Interface, and fundamental models.

## Getting Started

### Requirements

* [.NET 8 SDK](https://dotnet.microsoft.com/download)
* SQL Server (or a compatible connection string)
* (Optional) Visual Studio 2022+ or VS Code

### Setup

1. **Clone the project:**

```bash
  git clone https://github.com/karayilann/Project-Tracker.git
```

2. **Restore dependencies:**

```bash
  dotnet restore
```

3. **Configure the database connection:**

   * Update the `DefaultConnection` string in `appsettings.json` or via User Secrets.

4. **Apply database migrations:**

```bash
  dotnet ef database update --project ProjectTracker.Repository
```

5. **Run the project:**

6. **Access the Swagger interface:**

   * [https://localhost:7097/swagger](https://localhost:7097/swagger)

## Usage

### Authentication

* Obtain a JWT token via the `/api/auth/login` endpoint.
* Include `Authorization: Bearer {token}` header when making requests to other endpoints.

### Main API Endpoints

* **Users:** `/api/user`
* **Projects:** `/api/project`
* **Roles:** `/api/role`
* **Work Items:** `/api/workitem`

CRUD operations and details for each endpoint can be viewed in the Swagger interface.

## Technologies

* ASP.NET Core 8
* Entity Framework Core
* Autofac
* AutoMapper
* FluentValidation
* Swagger (Swashbuckle)
* JWT Authentication

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/feature-name`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature/feature-name`).
5. Open a pull request.

## License

MIT

---

> For more information about the project or specific use cases, please review the code and Swagger documentation.
