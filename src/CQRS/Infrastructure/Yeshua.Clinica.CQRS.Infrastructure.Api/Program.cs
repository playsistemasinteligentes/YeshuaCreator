using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddMemoryCache();
builder.Services.AddResponseCompression();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        var origins = builder.Configuration.GetSection("Cors:Origins").Get<string[]>() ?? [];
        if (origins.Length > 0)
            policy.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = builder.Environment.ApplicationName, Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
});

Migrations.DependencInjection.MapDependencInjection(builder);
Migrations.DependenceInjectionCuston.MapDependenceInjection(builder);

var jwtSettings = new JwtSettings();
builder.Configuration.Bind("JwtSettings", jwtSettings);
builder.Services.AddSingleton(jwtSettings);
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

const string applicationName = "Clinica";
builder.Services.AddAuthorization(options =>
{
    static string? Claim(AuthorizationHandlerContext context, string type) =>
        context.User.FindFirst(type)?.Value;

    static bool IsLegacy(AuthorizationHandlerContext context) =>
        string.IsNullOrWhiteSpace(Claim(context, "tokenOrigin"));

    static bool IsApplicationToken(AuthorizationHandlerContext context, string expectedApplication) =>
        string.Equals(Claim(context, "tokenOrigin"), "Application", StringComparison.OrdinalIgnoreCase)
        && string.Equals(Claim(context, "application"), expectedApplication, StringComparison.OrdinalIgnoreCase);

    static bool IsCentralToken(AuthorizationHandlerContext context) =>
        string.Equals(Claim(context, "tokenOrigin"), "Central", StringComparison.OrdinalIgnoreCase);

    static bool IsPlatformToken(AuthorizationHandlerContext context) =>
        IsCentralToken(context)
        || string.Equals(Claim(context, "tokenOrigin"), "Application", StringComparison.OrdinalIgnoreCase);

    static bool HasCatalog(AuthorizationHandlerContext context, string expectedApplication) =>
        (Claim(context, "userCatalogs") ?? string.Empty)
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Contains(expectedApplication, StringComparer.OrdinalIgnoreCase);

    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .RequireAssertion(context =>
            IsLegacy(context)
            || (string.Equals(applicationName, "Central", StringComparison.OrdinalIgnoreCase)
                ? IsCentralToken(context)
                : IsApplicationToken(context, applicationName)))
        .Build();

    options.AddPolicy("ApplicationEntry", policy =>
        policy.RequireAuthenticatedUser().RequireAssertion(context =>
            IsLegacy(context)
            || (IsPlatformToken(context) && HasCatalog(context, applicationName))));
});

var app = builder.Build();

app.UseResponseCompression();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();

API.Migrations.Endpoints.MapEndpoints(app);
API.Migrations.EndpointsCuston.MapEndpoints(app);

app.Run();
