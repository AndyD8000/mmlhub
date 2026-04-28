# MML Hub – Architecture Overview

## Overview

The MML Hub is a web-based client portal built using Microsoft technologies, designed to provide secure, role-based access to operational data.

---

## Technology Stack

- Frontend: ASP.NET Razor Pages
- Backend: .NET (minimal API + services)
- Hosting: Azure App Service
- Data:
  - Current: In-memory (development)
  - Future: Existing SQL Server
- Source Control: GitHub
- CI/CD: GitHub Actions

---

## Application Structure

Pages → Services → Data Source


### Pages
- UI layer (Work Orders, Job Logging, Admin)

### Services
- Business logic layer
- Abstracts data access

### Data
- Mock / In-memory (current)
- SQL Server (planned)

---

## Key Concepts

### Multi-Tenant Design
- Data linked to `ClientId`
- UI filtered by current user context

### Role-Based Behaviour
- `MMLAdmin` → full access
- `ClientUser` → restricted access

### API Layer
- `/api/jobs` (POST)
- `/api/test` (GET – development)

---

## Hosting Architecture

User → Azure App Service → .NET App → SQL Server (future)


---

## Security Approach (Planned)

- Microsoft Entra ID authentication
- Role-based access control
- Secure API endpoints
- No direct database exposure

---

## Design Principles

- Keep MVP simple
- Reuse existing systems/data
- Separate UI, logic, and data layers
- Build for maintainability