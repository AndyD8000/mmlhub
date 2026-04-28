# MML Hub – Setup Guide

## Prerequisites

- Azure account
- GitHub account
- VS Code
- .NET SDK (LTS)

---

## Local Development


-dotnet run

-https://localhost:xxxx

Azure Setup
Create Resource Group
Create App Service Plan (Basic)
Create Web App (.NET)
Connect GitHub (Deployment Center)

Deployment
Push to main branch
GitHub Actions builds and deploys automatically

Environment Config
Connection strings stored securely
No secrets in source control

Notes
Free tier not suitable for production
Basic tier used for DEV
Standard tier planned for UAT/PROD


---

# 📄 `docs/decisions.md`

---

# MML Hub – Key Technical Decisions

## Why .NET / Microsoft Stack

- Aligns with existing MML systems
- Internal familiarity
- Strong Azure integration

---

## Why Azure App Service

- Managed hosting (no server management)
- Scalable
- Integrated deployment

---

## Why Service Layer

- Separates UI from data access
- Enables easy switch from mock → SQL
- Improves maintainability

---

## Why Start with Mock Data

- Faster development
- No dependency on SQL setup
- Enables UI and flow validation early

---

## Why Lean MVP Approach

- Reduce initial cost
- Prove value quickly
- Lower risk for board approval

---

## Why In-Memory Storage (Temporary)

- Demonstrates full workflow
- Avoids early database complexity
- Easy to replace later

---

## Future Decisions

- Entra ID for authentication
- Hybrid connection or migration for SQL access
- Role and client management model
