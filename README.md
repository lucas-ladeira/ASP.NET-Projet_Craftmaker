# Projet Final

Project developed in ASP.NET MVC for a wood craftsman's online store.

## Description

Mr. Larmoire is a cabinetmaker in Normandy, northern France. He creates, renovates and manufactures furniture and decorative elements: tables, doors, cupboards, chairs, friezes and sculptures in solid wood, which he makes to measure.

He would like to promote his creations and is considering creating a website to showcase them. He doesn't have a website at all at the moment, and has no expertise in the field.

## Objective

Create an ASP.NET CORE (Model-View-Controller) application to create,
classify, modify or delete Members.

## Prerequisites

- Visual Studio 2022
- NuGet packages:
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Tools
  - Microsoft.VisualStudio.Web.CodeGeneration.Design
- SQL Server Management Studio 20

## How it works

To initialize the application, first create a SQL Server database and copy the Connection String from this database into the **DefaultConnection** variable in the **appsettings.json** document.

After this step, the application can be initialized by double-clicking on the **“ProjetFinal.sln”** file.

## Documentation

The project has been divided according to structure:

- Model: models of the classes used in the project;
- View: responsible for web page design;
- Controller: responsible for managing HTTP requests;
- Service: responsible for logic and managing CRUD operations.