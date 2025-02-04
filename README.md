# Handyman Project

## Overview
This project is built using ASP.NET Core 8 MVC. It includes user authentication with roles such as Admin, Customer, and Provider.

## Prerequisites
- .NET 8 SDK
- SQL Server

## Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/PropertyGuys1/Handyman.git
cd handyman
```
## Set Up the Database
Ensure your database connection string is correctly configured in appsettings.json.

## Update the Database
To create the necessary database tables, run the following command in the Package Manager Console:
```bash
Update-Database
```
## Start the application using Visual Studio or the .NET CLI:
```bash
dotnet run
```
## Features
User registration and login
Role-based authorization (Admin, Customer, Provider)
Password recovery and reset
Contributing
Feel free to submit issues and pull requests. For major changes, please open an issue first to discuss what you would like to change.

