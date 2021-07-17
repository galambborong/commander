# Commander

## Intro/aims

This project initially took shape while following this [tutorial](https://www.youtube.com/watch?v=fmvcAzHpsk8) by way of re-familiarising myself with C#, having been working more or less only in JavaScript since October 2020, and having had limited C# exposure beforehand.

I've extended it far beyond the scope of the tutorial, using it as a chance to learn about Entity and LINQ, as well as turning it into an application that actually suits my needs.

This is a project in development, so there's no hosted version at present - but I'll likely deploy it soon. 

## What is Commander?

**Commander** is a REST API which stores summary information about CLI commands. This is an example response from the `/api/commands/` endpoint.

| Id | HowTo | Line | Platform | AdminPrivilegesRequired |
|---|---|---|---|---|
| 1 | Update AUR packages | paru -Sua | AUR | true |
| 2 | Add DB migrations | dotnet ef migrations add \<NAME> | Entity | false |

See `/api` for a detailed description of the various available endpoints.
### Current endpoints and methods

Currently, the API supports the following endpoints and request methods: 

```http
GET /api

GET /api/commands
POST /api/commands

GET /api/commands/{id}
DELETE /api/commands/{id}

GET /api/commands/{id}/alias
POST /api/commands/{id}/alias

GET /api/platforms
POST /api/platforms

GET /api/platforms/{id}
PATCH /api/platforms/{id}
DELETE /api/platforms/{id}
```

### Tech stack and libraries

Commander makes use the following technologies, each with the principle aim of learning them 

- **.NET 5**
- **C#** 
- **PostgreSQL**
- **Entity Framework**
- **LINQ**







