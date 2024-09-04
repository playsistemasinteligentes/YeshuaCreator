using Comandos.Commands.Clinica;
using Comandos.Receivers.Clinica;
using Input.Repository.Clinica;
using Repositorio.Inputs.Repositorio.Clinica;
using Shered.DB.Connection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Read.ConcreteRepository.Clinica;
using RepositoryInterfaces.Read.Repository.Clinica;


var builder = WebApplication.CreateBuilder(args);
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


string conectionString = "Data Source=DESKTOP-JT9N4SD;Initial Catalog=YESHUA;User ID=sa;Password=sa;TrustServerCertificate=True;";


builder.Services.AddScoped<SqlFactory>(provader => { 
    return new SqlFactory(EnumSqlConections.SqlServer,conectionString);
});
builder.Services.AddTransient<IClinicaWriteRepository, ClinicaWriteRepository>();
builder.Services.AddTransient<IClinicaReadRepositorys, ClinicaReadRepository>();
builder.Services.AddTransient<InsertClinicaReceiver>();









var app = builder.Build();




app.UseResponseCompression();

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

object value1 = app.MapGet("/clinica/", ([FromServices] IClinicaReadRepositorys rep) => {

    try
    {
        var teste  = Environment.GetEnvironmentVariable("DOTNET_SYSTEM_GLOBALIZATION_INVARIANT");


        return rep.getAllClinicas();

    }
    catch (Exception E)
    {

        throw;
    }

});


object value = app.MapPost("/clinica/PostClinica", ([FromServices] InsertClinicaReceiver receiver, [FromBody] ClinicaCommand comand) => {
    return receiver.Execute(comand);
});

app.Run();

