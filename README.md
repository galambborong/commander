# Commander

## Intro/aims

This project initially took shape when following this [tutorial](https://www.youtube.com/watch?v=fmvcAzHpsk8), by way of re-familiarising myself with C#, having been more or less only working in JavaScript since October 2020, and having had limited C# exposure beforehand.

I've been extending it beyond the scope of the tutorial, and using it as a project to learn and turn it into an actual application that suits my needs.

This is a project in development, so there's no hosted version at present - but I'll likely deploy it soon. 

## What is Commander?

**Commander** is a REST API which stores summary information about CLI commands. Example:

| Id | HowTo | Line | Platform | AdminPrivilegesRequired |
|---|---|---|---|---|
| 1 | Update AUR packages | paru -Sua | AUR | true |
| 2 | Add DB migrations | dotnet ef migrations add <NAME> | Entity | false |

### Current endpoints and methods

Currently, the API supports the following methods/endpoints: 

```http
GET /api/commands
POST /api/commands
GET /api/commands/{id}

GET /api/platforms
GET /api/platforms/{id}
POST /api/platforms
```
Formerly, full CRUD operations were available for `/api/commands`, but as I've developed this beyond the tutorial I am redesigning the API to meet my own needs. 
A full range of CRUD operations will be supported in due course. 

### Tech stack

Commander makes use the following technologies, each with the principle aim of learning them 

- **.NET 5**
- **C#** 
- **PostgreSQL** database
- **Entity Framework** as the ORM
- **LINQ** as preferred querying language








