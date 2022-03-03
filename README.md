# Movie Characters API

![GitHub repo size](https://img.shields.io/github/repo-size/Tooppa/MovieCharactersAPI)

[Database Diagram](Documentation/MovieCharacters_DB_Diagram.png)

## Table of Contents

- [General Information](#general-information)

- [Technologies](#technologies)

- [Installation and Usage](#installation-and-usage)

- [Contributors](#contributors)

## General Information

MovieCharactersAPI is a web API built with ASP.NET Core and it provides CRUD operations for characters, movies and franchises within a local SQL Express server database along with a few other operations that deal with related data of the aforementioned tables.

It uses Entity Framework to build the database and interact with it. The application is designed to implement a service pattern that separates the controllers from the actual database interactions via specific services that are then injected and could potentially be replaced with other implementations for testing purposes.

The endpoints deal with data transfer objects (DTOs) instead of the actual domain models to prevent users access to certain data attributes. AutoMapper is used to map data between the domain models and the DTOs.

The API uses Swagger to create a documented interface that be used to test the various endpoints.

These are the available endpoints:

### Character

- ```api/characters``` **\[GET, POST]**
- ```api/charaters/{id}``` **\[GET, PUT, DELETE]**

### Movie

- ```api/movies``` **\[GET, POST]**
- ```api/movies/{id}``` **\[GET, PUT, DELETE]**
- ```api/movies/{id}/characters``` **\[GET, PUT]** (Get or update the characters of a movie)

### Franchise

- ```api/franchises``` **\[GET, POST]**
- ```api/franchises/{id}``` **\[GET, PUT, DELETE]**
- ```api/franchises/{id}/movies``` **\[GET, PUT]** (Get or update the movies of a franchise)
- ```api/franchises/{id}/characters``` **\[GET]** (Get the characters from all the movies of a franchise)

## Technologies

- C#
- .NET 6
- EF Core
- ASP.NET Core
- Swagger
- SQL Express Server
- SQL Server Management Studio

## Installation and Usage

In order to use the application you need to follow these steps:

1.) Clone the project ```git clone git@github.com:Tooppa/MovieCharactersAPI.git```

2.) Open Visual Studio > Select 'Open a project or solution' > Find the project directory and select the **MovieCharactersAPI.sln** file

3.) You might need to clean/build the solution once to resolve the dependencies.

4.) Before running the application, make sure you have a SQL Express server running locally. The connection string uses ```".\\SQLEXPRESS"``` as the data source. You can change it in the *appsetting.json* file under DefaultConnection.

5.) On the Visual Studio toolbar navigate to Tools > NuGet Package Manager > Package Manager Console. Open the console and run the command ```update-database```. This will create a database called MovieCharacters on the server that was specified in the connection string.

6.) Now you can run the application. It should automatically start on ```localhost:7034``` and display the Swagger UI and API documentation. You can use Swagger to test the various endpoints or e.g. Postman while the application is up and running.

## Contributors

[Tomas Valkendorff (@Tooppa)](https://github.com/Tooppa)

[Timo Järvenpää (@TimoJarvenpaa)](https://github.com/TimoJarvenpaa)
