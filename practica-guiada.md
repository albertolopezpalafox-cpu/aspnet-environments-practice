# Práctica de Environments en ASP.NET Core

## Objetivos logrados

1.  **Creación de API:** Generamos una Web API mínima con .NET 8.
2.  **Archivos de configuración:** Creamos los archivos `appsettings.Staging.json` y `appsettings.Production.json`.
3.  **Endpoint de prueba:** Modificamos `Program.cs` para crear el endpoint `/env` que lee la configuración y el entorno.
4.  **Perfiles de ejecución:** Definimos en `launchSettings.json` los perfiles para `Development`, `Staging` y `Production`, cada uno con su variable `ASPNETCORE_ENVIRONMENT` y puerto de ejecución.

## Conclusión

Se demostró que la aplicación:
* Carga la configuración de manera jerárquica (la específica del entorno sobrescribe la base).
* Permite definir un comportamiento diferente para cada entorno (ej: Swagger solo para Dev y Staging, no para Production).