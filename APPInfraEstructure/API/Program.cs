using Shered.DB.Connection;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Migrations;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using System.Data;
using Microsoft.Data.SqlClient;
using RepositoryInterfaces.Services;
using Shered.Services;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
// Configuração do Kestrel para otimização de desempenho
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxConcurrentConnections = GS.I.MYC.MaxConcurrentConnections; // Ajuste conforme necessário
    options.Limits.MaxConcurrentUpgradedConnections = GS.I.MYC.MaxConcurrentUpgradedConnections; // Para WebSockets
    options.Limits.MaxRequestBodySize = GS.I.MYC.MaxRequestBodySize; // Limite do corpo da requisição
});

// Adiciona cache e compressão
builder.Services.AddMemoryCache();
builder.Services.AddResponseCompression();

// Adiciona a política CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhostAndNetwork", builder =>
    {
        builder.WithOrigins(GS.I.MYC.CorsOrigins) // Permite ambos os domínios
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

    // Configuração de segurança para o Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Por favor, insira o token JWT com o prefixo 'Bearer ' na frente."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


IndependenceInjection.MapIndependenceInjection(builder);
IndependenceInjectionCuston.MapIndependenceInjection(builder);


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

//app.UsePathBase("/api");

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
    try
    {
        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
        await next();
        Console.WriteLine($"Response: {context.Response.StatusCode} {context.Request.Method} {context.Request.Path}");

    }
    catch (Exception e)
    {


    }
});


Endpoints.MapEndpoints(app);
EndpointsCuston.MapEndpoints(app);
app.Run();
