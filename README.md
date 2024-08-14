# Fullstack Project: E-commerce system

![TypeScript](https://img.shields.io/badge/TypeScript-green)
![SASS](https://img.shields.io/badge/SASS-hotpink)
![React](https://img.shields.io/badge/React-blue)
![Redux toolkit](https://img.shields.io/badge/Redux-brown)
![.NET Core](https://img.shields.io/badge/.NET%20Core-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-cyan)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-drakblue)

This project involves creating a Fullstack project with React and Redux in the frontend and ASP.NET Core in the backend. The goal is to provide a seamless experience for users, along with robust management system for administrators.

- Frontend: SASS, TypeScript, React, Redux Toolkit
- Backend: ASP.NET Core, Entity Framework Core, PostgreSQL

For backend, you should improve the teamwork backend project to have better performance and functionalities (do not start backend from scratch). For fronend, you can reuse the previous frontend ecommerce assignment with necessary modification to fit your backend server or build new frontend.

## Table of Contents

1. [Instruction](#instruction)
2. [Features](#features)
   - [Mandatory features](#mandatory-features)
   - [Extra features](#extra-features)
3. [Requirements](#requirements)
4. [Getting Started](#getting-started)
5. [Testing](#testing)

## Instruction

This repository should be used only for backend server. The frontend server should be done in a separate repository [here](https://github.com/Integrify-Finland/fs18_CSharp_FullStack_Frontend). You can modify your previous frontend project and instructors will check the submissions (pull requests) in the frontend project repository. The modified frontend server need to be connected with this backend server to make a whole fullstack project.

### Frontend
Check the Frontend repository

### Backend

Generate a solution file in this repository. All the project layers of backend server should be added into this solution.

## Features
These features are not specifically assigned to backend or frontend. You must decide where they should go.

### Mandatory features

#### User Functionalities

1. User Management: Users should be able to register for an account and manage their profile.
2. Browse Products: Users should be able to view all available products and single product, search and sort products.
3. Add to Cart: Users should be able to add products to a shopping cart, and manage cart.
4. Oders: Users should be able to place orders and see the history of their orders.

#### Admin Functionalities

1. User Management: Admins should be able to manage all users.
2. Product Management: Admins should be able to manage all products.
3. Order Management: Admins should be able to manage all orders.

### Bonus-point 

1. Third party integrations, for example: Google Authentication, Sending Email, Payment gateway, etc.
2. Extra features, for examples: dynamic pricing algorithms, chatbots, subscription, admin dashboard with analytics, etc.

## Requirements

1. Project should use CLEAN architecture, proper naming convention, security, and comply with Rest API. In README file, explain the structure of your project as well.
2. Error handler: This will ensure any exceptions thrown in your application are handled appropriately and helpful error messages are returned.
3. In backend server, unit testing (xunit) should be done, at least for Service(Use case) layer. We recommend to test entities, repositories and controllers as well.
4. Document with Swagger: Make sure to annotate your API endpoints and generate a Swagger UI for easier testing and documentation.
5. `README` files should sufficiently describe the project, as well as the deployment, link to frontend github.
6. Frontend, backend, and database servers need to be available in the live servers.  

## Getting Started

1. Start with backend first before moving to frontend.

2. You should focus on the mandatory features first. Make sure you have minimal working project before opting for advanced functionalities.

3. Testing should be done along the development circle, early and regularly.

## Testing

Unit testing, and optionally integration testing, must be included for both frontend and backend code. Aim for high test coverage and ensure all major functionalities are covered.
