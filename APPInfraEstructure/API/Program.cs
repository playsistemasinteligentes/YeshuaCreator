using Shered.DB.Connection;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using API.Migrations;
using RepositoryInterfaces.Read.Repository.Clinica;
using Comandos.Commands;
using System.Net;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Configuração do Kestrel para otimização de desempenho
builder.WebHost.ConfigureKestrel(options =>
{
    // HTTP (opcional)
    options.Listen(IPAddress.Parse("192.168.18.19"), 5162);

    // HTTPS com certificado
    options.Listen(IPAddress.Parse("192.168.18.19"), 7214, listenOptions =>
    {
        listenOptions.UseHttps("C:\\Users\\angel\\source\\repos\\playsistemasinteligentes\\YeshuaCreator\\APPInfraEstructure\\API\\bin\\Debug\\net8.0\\certi\\ck.pfx", "123456");
    });



    options.Limits.MaxConcurrentConnections = 1000; // Ajuste conforme necessário
    options.Limits.MaxConcurrentUpgradedConnections = 1000; // Para WebSockets
    options.Limits.MaxRequestBodySize = 10 * 1024 * 1024; // Limite do corpo da requisição
});

// Adiciona cache e compressão
builder.Services.AddMemoryCache();
builder.Services.AddResponseCompression();

// Adiciona a política CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhostAndNetwork", builder =>
    {
        builder.WithOrigins("http://localhost:3000", "http://192.168.18.19:3000", "https://192.168.18.19:3000") // Permite ambos os domínios
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

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                var result = System.Text.Json.JsonSerializer.Serialize(new { message = "Autenticação falhou. Token inválido ou expirado." });
                return context.Response.WriteAsync(result);
            }
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Aplica a política CORS
app.UseCors("AllowLocalhostAndNetwork");

// Adiciona middleware de redirecionamento HTTPS
app.UseHttpsRedirection();

// Configura o Swagger e Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Example v1");
});

// Middleware de autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Adiciona um middleware personalizado para logging de requisições
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next();
    Console.WriteLine($"Response: {context.Response.StatusCode} {context.Request.Method} {context.Request.Path}");
});


// Endpoints


Endpoints.MapEndpoints(app, "http://localhost:5162/");

app.MapPost("/login", (UserLogin user, JwtSettings jwtSettings) =>
{
    if (true) // Substitua pelo seu critério de validação
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



app.MapPost("/upload", async (HttpContext context) =>
{
    try
    {
        var request = context.Request;
        if (!request.HasFormContentType)
            return Results.BadRequest("Requisição inválida. Esperado form-data.");

        var form = await request.ReadFormAsync();
        var file = form.Files["audio"];

        if (file == null || file.Length == 0)
            return Results.BadRequest("Nenhum arquivo foi enviado.");

        // Define o caminho onde os áudios serão salvos
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        Directory.CreateDirectory(uploadsFolder); // Garante que a pasta existe

        var filePath = Path.Combine(uploadsFolder, file.FileName);

        // Salva o arquivo no servidor
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        Console.WriteLine($"Arquivo salvo em: {filePath}");
        return Results.Ok(new { message = "Arquivo recebido com sucesso!", filePath });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao receber arquivo: {ex.Message}");
        return Results.Problem("Erro ao processar o arquivo.");
    }
});


app.Run();

public record UserLogin(string Username, string Password);
