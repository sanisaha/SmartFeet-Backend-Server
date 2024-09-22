# Fullstack Project: E-commerce system

![.NET Core](https://img.shields.io/badge/.NET%20Core-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-cyan)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-drakblue)
![C#](https://img.shields.io/badge/C%23-8.0-239120?logo=csharp)
![Clean Architecture](https://img.shields.io/badge/Clean_Architecture-orange?logo=cleanarchitecture)
![JWT](https://img.shields.io/badge/JWT-JSON_Web_Token-00B5AD?logo=jsonwebtokens)
![Xunit Testing](https://img.shields.io/badge/Xunit-Testing-FF4136?logo=xunit)
![Microsoft Azure](https://img.shields.io/badge/Microsoft-Azure-skyblue)
![Swaggar](https://img.shields.io/badge/Swaggar-greenyellow)

# 🥿 SmartFeet - Backend API

The SmartFeet backend is a robust and scalable REST API built with C# and .NET Core. This project follows a clean architecture approach with distinct layers, ensuring easy maintenance and scalability. It supports JWT token authentication and utilizes PostgreSQL as its database, hosted on Azure.

---

## 🌟 Features

- **JWT Authentication**: Secure user authentication with JSON Web Tokens.
- **CRUD Operations**: Base service for common CRUD operations across various entities.
- **Well-Structured Architecture**: Follows Domain-Driven Design (DDD) principles with separate layers for Domain, Service, Presentation, and Infrastructure.
- **PostgreSQL Database**: Efficient database management with Entity Framework Core and PostgreSQL.
- **Custom Error Handling Middleware**: Centralized error management for cleaner code and easier debugging.
- **Swagger Integration**: Customized Swagger documentation for API endpoints.
- **Unit Testing**: xUnit tests implemented for Domain and Service layers to ensure robustness.

---

## 🛠️ Tech Stack

- **Backend:**
  - C# & .NET Core
  - Entity Framework Core
  - PostgreSQL
- **Authentication:**
  - JWT Token Authentication
- **Testing:**
  - xUnit for unit testing
- **Deployment:**
  - Azure (Deployed via Azure CLI)

---

## 🏗️ Clean Architecture

The project is organized into the following layers:

1. **Domain**: Contains the core business logic, entities, and domain services.
2. **Service**: Contains service classes that handle business rules, logic, and validation.
3. **Presentation**: Contains the API controllers to handle HTTP requests and responses.
4. **Infrastructure**: Contains data access logic using Entity Framework Core and manages PostgreSQL interactions.

## Test with Admin User

To test the application as an Admin, use the following credentials:

- **Email**: `admin@email.com`
- **Password**: `password`

### New Product Creation

When creating a new product, the `subcategoryId` is required.

To fetch subcategories for a specific category (e.g., Men), you can send an API request to the following endpoint:

```bash
GET /api/v1/Category/categoryName/Men


---
```
