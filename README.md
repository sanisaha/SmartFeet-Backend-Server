# Fullstack Project: E-commerce system

![.NET Core](https://img.shields.io/badge/.NET%20Core-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-cyan)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-drakblue)

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

---

## 📜 API Documentation

The backend API offers a wide range of endpoints to interact with the database and handle the application’s business logic. The API is documented using **Swagger**, allowing for easy testing and exploration.

### To view Swagger documentation:

After starting the backend server, navigate to:
