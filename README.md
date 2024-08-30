# E-commerce Platform

## Overview

This project is an e-commerce backend project, which manages user accounts, orders, products, and reviews. It is built with a layered architecture that separates concerns between the domain, service, Presentation, and infrastructure layers. The platform is designed to be scalable, secure, and maintainable.

## Features

- **User Management**: Registration, login, password management, and profile updates.
- **Order Management**: Creating, updating, and tracking orders.
- **Product Management**: CRUD operations for products.
- **Review System**: Users can review products they have purchased.
- **Security**: Secure password hashing and authentication.

## Technology Stack

- **Backend**: ASP.NET Core
- **Database**: Entity Framework Core with SQL Server
- **Authentication**: Custom authentication with password hashing
- **Testing**: xUnit for unit testing
- **Dependency Injection**: Built-in DI provided by ASP.NET Core

## Project Structure

## Project Structure

```plaintext
├── Ecommerce.Domain
│   ├── src
│   │   ├── Auth
│   │   ├── Entities
│   │   ├── Exceptions
│   │   ├── Interfaces
│   │   ├── Model
│   │   └── Shared
├── Ecommerce.Infrastructure
│   ├── Migrations
│   ├── Properties
│   ├── src
│   │   ├── Repository
│   │   └── Database
├── Ecommerce.Presentation
│   ├── src
│   │   ├── Controllers
│   │   └── Middleware
├── Ecommerce.Service
│   ├── src
│   │   ├── UserService
│   │   ├── OrderService
│   │   ├── ...
│   │   ├── ...
│   │   └── Shared
├── Ecommerce.Tests
│   ├── src
│   │   ├── Domain
│   │   └── Service
└── README.md
```

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

### Installation

1. **Clone the repository**:

   ```sh
   git clone https://github.com/MohamadNach/fs18_CSharp_Teamwork
   cd fs18_CSharp_Teamwork
   ```

2. **Set up the database**:

   - Update the connection string in `appsettings.json` located in the `Ecommerce.Infrastructure` project.
   - Run database migrations to set up the initial schema:
     ```sh
     dotnet ef database update
     ```

3. **Run the application**:

   ```sh
   dotnet run
   ```

4. **Run the tests**:
   ```sh
   dotnet test
   ```

## Usage

- **User Registration and Authentication**: API endpoints are available for registering users, logging in, and managing user sessions.
- **Order Processing**: Users can place orders, view order history, and manage active orders.
- **Product Management**: Admin users can create, update, and delete products.
- **Review System**: Users can leave reviews for products they have purchased.

## Testing

- **Unit Tests**: The project includes a suite of unit tests using xUnit. You can run the tests using the following command:
  ```sh
  dotnet test
  ```
