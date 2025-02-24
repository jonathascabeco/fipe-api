# Car Fipe Project

This project utilizes the [Fipe API](https://deividfortuna.github.io/fipe/) to retrieve information about cars and car brands in Brazil. The API provides base prices for used cars in the country, offering valuable insights for users.

---

## 🛠️ Tech Stack and Patterns

### Backend
- **C#**
- **.NET 9**
- **Entity Framework (EF Core)**
- **Hangfire** (for background tasks)
- **MSSQL** (database)

### Frontend
- **Vue.js**
- **TypeScript**
- **Bootstrap** (for styling)

### Architecture and Design Patterns
- **Domain-Driven Design (DDD)**
- **SOLID Principles**
- **Clean Architecture**

---

## 🚀 How to Build and Run the Project

### Backend
1. **CarFipe.WebAPI**:
   ```bash
   dotnet run

2. **CarFipe.WorkerService**:
   ```bash
   dotnet run

### Frontend
1.Navigate to the frontend directory.

2.Install dependencies (if not already installed):
```bash
   npm install
```
3.Run the development server:
```bash
   npm run dev
```
---

## 🗄️ Database Setup

The project uses SQL Server Express with a local database named car_fipe_database. The database contains a single table:
```bash
CREATE TABLE Cars
(
    Id INT PRIMARY KEY,    
    Name NVARCHAR(500)
);
```
To set up the database:

1.Ensure SQL Server Express is installed and running locally.

2.Create the car_fipe_database database.

3.Run the above SQL script to create the Cars table.

---

## 📂 Project Structure

The project follows Clean Architecture principles, organized into the following layers:

Domain: Core business logic and entities.

Application: Application-specific logic and use cases.

Infrastructure: Database, external API integrations, and background tasks.

WebAPI: REST API endpoints.

WorkerService: Background services (e.g., Hangfire jobs).

Frontend: Vue.js application for the user interface.

---

## 🔧 Dependencies

### Backend

.NET 9 SDK

Entity Framework Core

Hangfire

SQL Server Express

### Frontend

Node.js

Vue.js

TypeScript

Bootstrap

---

## 🙏 Acknowledgments

Thanks to Deivid Fortuna for providing the Fipe API.

Inspired by Clean Architecture and Domain-Driven Design principles.

---

## 📧 Contact

For questions or feedback, feel free to reach out to Cabêço at [cabeco@protonmail.com].

---
