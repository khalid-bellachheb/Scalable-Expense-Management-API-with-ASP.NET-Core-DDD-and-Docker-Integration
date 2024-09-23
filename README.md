**Expenses Management API**
===========================

**Project Overview**
--------------------

The Expenses Management API is a backend service built using ASP.NET Core (.NET 8) to manage user expenses. It supports CRUD (Create, Retrieve, Update, Delete) operations for expenses and offers a structure based on Domain-Driven Design (DDD). The project utilizes Entity Framework Core as the Object-Relational Mapper (ORM) with SQL Server for data storage and is fully containerized using Docker to facilitate development and deployment.

**Features**
------------

* **CRUD Operations**: Create, retrieve, update, and delete expenses.
* **User Management**: Manage user accounts and access.
* **Currency Conversion**: (Planned feature) Automatically convert expenses into different currencies.
* **Integration with Docker**: Simplified setup and deployment through Docker containers.
* **API Documentation**: Comprehensive API documentation with Swagger UI.

**Technology Stack**
--------------------

* **.NET 8**: Framework for building the API.
* **Entity Framework Core**: ORM used for database interactions.
* **SQL Server**: Database system for data storage.
* **Docker**: Containerization of the API and database to streamline development.
* **Swagger**: API documentation and interactive interface for testing endpoints.

**Getting Started**
-------------------

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### **Prerequisites**

* **.NET 8 SDK**: Required to build and run the project.
* **Docker Desktop**: For containerization and running the API in a Docker environment.
* **Visual Studio 2022 or later**: Recommended for full feature support and seamless development experience.
* **SQL Server Management Studio (SSMS)**: (Optional) For direct database interaction.

**Setup Instructions**
----------------------

1. **Clone the repository**:
    
    ```bash
    git clone <repository_url>
    ```
    
2. **Navigate to the project directory**:
    
    ```bash
    cd ExpensesAPI
    ```
    
3. **Build and run the Docker containers**:
    
    ```bash
    docker-compose up --build
    ```
    
4. **Access the Swagger documentation**: Open your browser and go to `http://localhost:<port>/swagger` to explore and test the API.

**Authors**
-----------

* **Khalid Bellachheb** - Initial development and implementation.

**License**
-----------

This project is licensed under the MIT License - see the LICENSE.md file for details.
