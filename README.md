# InventorySystem

Multilayered ASP.NET Core Web API for a simple store inventory.
Products have: **Name, Description, Price, Quantity**.  
Persistence: **EF Core** + **MySQL**.

## Architecture
- **InventorySystem.Api** – Web API (controllers, Swagger, DI composition)
- **InventorySystem.Application** – DTOs, business services, FluentValidation
- **InventorySystem.Domain** – Entities and repository contracts
- **InventorySystem.Infrastructure** – EF Core DbContext, repository implementations, migrations
- **InventorySystem.Tests** – xUnit, FluentAssertions, Moq, EFCore.InMemory

## Prerequisites
- .NET 8 SDK
- MySQL Server 8 (Workbench optional)

## Setup (MySQL Workbench)
1. Start MySQL Server (Windows service **MySQL80**).
2. In Workbench:
   ```sql
   CREATE DATABASE IF NOT EXISTS inventorydb
     DEFAULT CHARACTER SET utf8mb4
     DEFAULT COLLATE utf8mb4_0900_ai_ci;

   CREATE USER IF NOT EXISTS 'inventory'@'localhost' IDENTIFIED BY 'inventorypw';
   GRANT ALL PRIVILEGES ON inventorydb.* TO 'inventory'@'localhost';
   FLUSH PRIVILEGES;


Was it easy to complete the task using AI?
- It was quite easy
  How long did task take you to complete?
-  About 2 hours
   Was the code ready to run after generation?
- Yes, it was ready to run after generation, but some dependencies needed to be updated.
  What did you have to change to make it usable?
- Updated some dependencies to their latest versions.
  Which challenges did you face during completion of the task?
- Some minor issues with dependency versions.
  Which specific prompts you learned as a good practice to complete the task?
- Asking for a multilayered architecture and specifying the technologies to be used.