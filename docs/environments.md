# Environments en ASP.NET Core

Valores más comunes:

- `Development`
- `Staging`
- `Production`

Se leen desde:

- Variable de entorno `ASPNETCORE_ENVIRONMENT`
- `launchSettings.json`
- Docker / docker-compose

## Métodos de ayuda

- `env.IsDevelopment()`
- `env.IsStaging()`
- `env.IsProduction()`