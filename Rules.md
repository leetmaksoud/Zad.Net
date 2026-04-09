# ZAD PROJECT — RULES

## ARCHITECTURE RULES

- Domain layer MUST be pure (no EF, no external libs)
- Application layer depends ONLY on Domain
- Infrastructure depends on Domain + Application
- API depends on all layers

---

## RESPONSIBILITY RULES

- Controllers MUST be thin (no business logic)
- Services contain ALL business logic
- Repositories handle ONLY data access
- DTOs are used for data transfer ONLY

---

## FORBIDDEN PRACTICES

- ? No business logic in Controllers
- ? No EF Core in Application or Domain
- ? No direct DbContext usage outside Infrastructure
- ? No calling external services from Controllers
- ? No circular dependencies

---

## DESIGN RULES

- Use Repository Pattern
- Use Unit of Work
- Use Dependency Injection everywhere
- Use async/await for all IO operations
- Use interfaces for abstraction

---

## NAMING & STRUCTURE

- Entities ? singular (User, Message)
- DTOs ? suffix with Dto (UserDto)
- Interfaces ? prefix with I (IUserService)
- Services ? clear business naming

---

## VALIDATION

- Use FluentValidation
- Do NOT validate inside controllers
- Keep validation in Application layer

---

## GENERAL PRINCIPLES

- Keep code clean and modular
- Follow SOLID principles
- Write readable and maintainable code
- Prefer clarity over cleverness