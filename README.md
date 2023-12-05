# Hotlier Booking System (ASP.NET Core 6)

## Project Description
The "Hotlier_Booking_AspNetCore6" project is an ASP.NET Core 6 web application designed to manage hotel booking processes. This application facilitates functions such as hotel room reservation, customer communication, and room management. It offers these functionalities through various controllers found in the `Controllers` directory, such as `BookingController`, `ContactController`, `HomeController`, and `RoomController`. The `Views` directory contains Razor pages that enable user interaction, offering essential functionalities and user experience required for modern web applications.

## Project Structure
- **Business**: This directory contains classes related to business logic. Example files: `AuthManager.cs`, `BookingManager.cs`, `RoomManager.cs`, etc.
- **DataAccess**: Represents the data access layer. Example files: `BookingRepository.cs`, `RoomRepository.cs`, `RepositoryContext.cs`, etc.
- **Entities**: Includes data structures such as models and DTOs. Subdirectories: `Dtos`, `Models`.
- **Hotlier_Booking_AspNetCore6**: The main folder of the application. Contains fundamental components of an ASP.NET Core application like `Controllers`, `Views`, `Migrations`, `wwwroot`, etc.

## Installation Instructions
1. **.NET Core Installation**: To run the project, the [.NET Core SDK](https://dotnet.microsoft.com/download) must be installed.
2. **Database Settings**: Update the "sqlconnection" value in the "ConnectionStrings" section of the `appsettings.json` file with your own SQL Server database information.
3. **Installing Dependencies**: Open a terminal or command prompt in the project root directory and execute the `dotnet restore` command to install dependencies.
4. **Running the Application**: Start the application by executing the `dotnet run` command in the same directory.

## Usage
- **Home Page**: The main page of the application provides links to other sections.
- **Room Management**: Manage room information via the `RoomController`.
- **Booking Management**: Make and manage hotel room reservations with the `BookingController`.
- **Contact**: Allows users to communicate with hotel management through the `ContactController`.

## Contribution
Those who wish to contribute to the project can send pull requests on GitHub. Before contributing, adherence to the project's coding standards and development guidelines is important.
