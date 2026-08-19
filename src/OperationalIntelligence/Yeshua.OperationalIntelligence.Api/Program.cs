using Microsoft.OpenApi.Models;
using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Collectors;
using Yeshua.OperationalIntelligence.Api.Configuration;
using Yeshua.OperationalIntelligence.Api.Database;
using Yeshua.OperationalIntelligence.Api.Endpoints;
using Yeshua.OperationalIntelligence.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOptions<OperationalIntelligenceOptions>()
    .Bind(builder.Configuration.GetSection(OperationalIntelligenceOptions.SectionName))
    .Validate(options => options.CommandTimeoutSeconds > 0, "Command timeout must be positive.")
    .Validate(options => options.MaximumMaxDepth > 0, "Maximum graph depth must be positive.")
    .Validate(options => options.MaximumMaxResults > 0, "Maximum result count must be positive.")
    .ValidateOnStart();

builder.Services.AddSingleton<OperationalIntelligenceDatabase>();
builder.Services.AddScoped<ISourceContextRepository, SourceContextRepository>();
builder.Services.AddScoped<IContextCollector, SourceCodeContextCollector>();
builder.Services.AddScoped<OperationalContextOrchestrator>();
builder.Services.AddScoped<QuestionContextBuilder>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Yeshua Operational Intelligence API",
        Version = "v1"
    }));

var app = builder.Build();

await app.Services.GetRequiredService<OperationalIntelligenceDatabase>()
    .InitializeAsync(app.Lifetime.ApplicationStopping);

app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapOperationalIntelligenceEndpoints();

app.Run();

public partial class Program;
