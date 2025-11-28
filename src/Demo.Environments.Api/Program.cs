var builder = WebApplication.CreateBuilder(args);

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

// Endpoint para ver entorno y configuración
app.MapGet("/env", () =>
{
    var currentEnv = app.Environment.EnvironmentName;
    var envNameFromConfig = configuration["EnvironmentName"];

    return Results.Ok(new
    {
        EnvironmentFromHost = currentEnv,
        EnvironmentFromConfig = envNameFromConfig,
        Message = $"Hola, estás en el entorno: {currentEnv}"
    });
});

app.Run();