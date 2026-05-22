# Docker setup

## Prerequisites
- Docker Desktop (or Docker Engine + Compose)

## Run
From the repository root:

1. Build and start the containers:
   ```bash
   docker compose up --build
   ```
2. Open the API:
   - Swagger UI: http://localhost:8080/swagger

## Stop
```bash
docker compose down -v
```

## Configuration notes
- SQL Server runs on `localhost:1433` with `sa` / `Your_password123!`.
- The API uses `ConnectionStrings__DefaultConnection` in `docker-compose.yml`.
- Update `Jwt__Secret`, `SEED_ADMIN_EMAIL`, and `SEED_ADMIN_PASSWORD` as needed.
