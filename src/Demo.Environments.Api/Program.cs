using Serilog;

var builder = WebApplication.CreateBuilder(args);

// --- 1. Configurar Serilog ---
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
// -----------------------------

var env = builder.Environment;
var configuration = builder.Configuration;

// Servicios
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger según entorno (Dev/Staging)
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoint 1: Entorno y Configuración (previo)
app.MapGet("/env", () =>
{
    // Usando el logger de Serilog
    Log.Information("Request received for /env endpoint in {Environment}", app.Environment.EnvironmentName);

    var currentEnv = app.Environment.EnvironmentName;
    var envNameFromConfig = configuration["EnvironmentName"];

    return Results.Ok(new
    {
        EnvironmentFromHost = currentEnv,
        EnvironmentFromConfig = envNameFromConfig,
        Message = $"Hola, estás en el entorno: {currentEnv}"
    });
});

// Endpoint 2: Mostrar Connection String (Nuevo)
app.MapGet("/connection-info", () =>
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    Log.Warning("Accessing Connection Info: {ConnectionString}", connectionString);

    return Results.Ok(new
    {
        Environment = app.Environment.EnvironmentName,
        ConnectionString = connectionString
    });
});

app.Run();