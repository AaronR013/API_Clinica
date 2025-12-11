using API_Clinica.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
//Inicialización de la base de datos
try
{
    Console.WriteLine("Iniciando API Clínica...");
    new DatabaseInitializer(builder.Configuration);
}
catch (Exception ex)
{
    Console.WriteLine($"Advertencia: {ex.Message}");
    Console.WriteLine("La aplicación continuará sin base de datos");
}

//Configuración del swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Ingresa tu usuario y contraseña en formato Basic Auth"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basic" }
            },
            new string[] {}
        }
    });
});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
