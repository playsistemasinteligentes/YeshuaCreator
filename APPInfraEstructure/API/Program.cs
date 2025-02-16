using Shered.DB.Connection;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using API.Migrations;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
// Configuração do Kestrel para otimização de desempenho
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxConcurrentConnections = 1000; // Ajuste conforme necessário
    options.Limits.MaxConcurrentUpgradedConnections = 1000; // Para WebSockets
    options.Limits.MaxRequestBodySize = 10 * 1024 * 1024; // Limite do corpo da requisição
});

// Adiciona cache e compressão
builder.Services.AddMemoryCache();
builder.Services.AddResponseCompression();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // Define o domínio permitido
               .AllowAnyMethod()                    // Permite qualquer método HTTP (GET, POST, etc)
               .AllowAnyHeader()                    // Permite qualquer cabeçalho
               .AllowCredentials();                 // Permite enviar cookies e credenciais
    });
});

// Adiciona suporte para endpoints e Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Example",
        Version = "v1"
    });
});

string conectionString = "Data Source=DESKTOP-JT9N4SD;Initial Catalog=CLINICA;User ID=sa;Password=sa;TrustServerCertificate=True;";

builder.Services.AddScoped<SqlFactory>(provader =>
{
    return new SqlFactory(EnumSqlConections.SqlServer, conectionString);
});

IndependenceInjection.MapIndependenceInjection(builder);

// Configurações do JWT
var jwtSettings = new JwtSettings();
builder.Configuration.Bind("JwtSettings", jwtSettings);
builder.Services.AddSingleton(jwtSettings);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization();


var app = builder.Build();

//app.UseResponseCompression();

//Adiciona middleware de redirecionamento HTTPS
app.UseHttpsRedirection();

// Configura o Swagger e Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Example v1");
});

// Adiciona um middleware personalizado para logging de requisições
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next();
});

Endpoints.MapEndpoints(app, "http://localhost:5162/");

app.MapPost("/login", (UserLogin user, JwtSettings jwtSettings) =>
{
    //if (user.Username == "admin" && user.Password == "123456")
    if (true)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Username) }),
            Expires = DateTime.UtcNow.AddSeconds(jwtSettings.ExpirationMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Results.Ok(new { token = tokenHandler.WriteToken(token) });
    }

    return Results.Unauthorized();
});

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowLocalhost3000");
app.Run();

public record UserLogin(string Username, string Password);

