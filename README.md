# 🎮 Game Catalogue (ASP.NET Core + Angular)

A simple two-page catalogue app for video games:
- **Page 1:** Browse the list of games  
- **Page 2:** Edit a game entry  

Backend is built with **ASP.NET Core 9.0** + **EF Core (Code-First)**.  
Frontend is built with **Angular** + **Bootstrap / ng-bootstrap**.

---

## 🚀 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or Docker is fine)
- [Node.js + npm](https://nodejs.org/) (LTS recommended)
- [Angular CLI](https://angular.dev/tools/cli)  

```
npm install -g @angular/cli


Running the Backend (API)

Navigate to the API folder:

cd GameCatalog.Api


Restore dependencies:

dotnet restore


Apply EF Core migrations & create database:

dotnet ef database update


Run the API:

dotnet run


By default, the API will listen on:

http://localhost:5177


🌐 Running the Frontend (Angular)

Navigate to the UI folder:

cd game-catalog-ui


Install dependencies:

npm install


Start the dev server:

ng serve --open


The app will open in your browser at:

http://localhost:4200
```
