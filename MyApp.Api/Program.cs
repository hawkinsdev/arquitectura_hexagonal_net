using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MyApp.Api.Configuration;
using MyApp.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5114;https://localhost:7114");

// Configurar AutoMapper para mapear objetos
builder.Services.AddAutoMapper(typeof(Program));

// Cargar la configuración de JwtSettings desde appsettings.json
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// Registro de servicios
builder.Services.AddApplicationServices(); 

// Configurar conexión a la base de datos
builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21)))
);

// Agregar servicios de autenticación
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    // Usar la configuración de JwtSettings directamente
    var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>() ?? throw new Exception("JWT settings not configured");
    options.TokenValidationParameters = jwtSettings.ToTokenValidationsParameters();
});

// Aquí es donde agregas el servicio de autorización
builder.Services.AddAuthorization();

// Configura las CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Configurar Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

// Configurar el pipeline de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
