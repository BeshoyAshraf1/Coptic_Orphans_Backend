# Coptic_Orphans_Backend
# Job Portal API 🚀

A robust backend API for a job portal application built with .NET Core, following Clean Architecture and best practices.

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)
![SQL Server](https://img.shields.io/badge/SQL_Server-2019-%23CC2927)


## Features ✨
- 📋 Job Listings with Pagination
- 🔍 Job Details by ID
- 📮 Job Application Submission
- ✅ Robust Validations
- ⚙️ Clean Architecture (3-Tier)
- 🛡️ Error Handling & API Security

## Technologies Used 💻

| Component               | Technology/Pattern                          |
|-------------------------|---------------------------------------------|
| **Database**            | SQL Server
| **Backend Framework**   | ![.NET](https://img.icons8.com/color/24/net-framework.png) .NET Core 8 |
| **ORM**                 | Entity Framework Core |
| **Architecture**        | 3-Tier (BAL/DAL/Web API) + Unit of Work Pattern |
| **Mapping**             | AutoMapper |
| **API Documentation**   | Swagger |


## API Endpoints 📡

| Endpoint                | Method   | Description                      | Example Request                  |
|-------------------------|----------|----------------------------------|-----------------------------------|
| `/api/Jobs`             | `GET`    | 📃 Get paginated job listings    | `GET /api/Jobs?pageNumber=1&pageSize=10` |
| `/api/Jobs/{id}`        | `GET`    | 🔍 Get job details by ID         | `GET /api/Jobs/5`                |
| `/api/Jobs/apply`     | `POST`   | 📮 Submit job application        | `POST /api/apply`         |

## 🚀 Setup & Run  

### 1️⃣ Clone the Repository  

git clone https://github.com/your-repo/job-portal-backend.git

### 2️⃣ Configure the Database

- Update connection string in appsettings.json
- Run migrations to set up the database
- update-database
### 3️⃣ Run the Backend Project

