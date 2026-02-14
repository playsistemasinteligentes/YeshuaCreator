using Shered.DB.Connection;
using Microsoft.Data.SqlClient;
using System.Data;
using Worker.Migration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
IndependenceInjection.MapIndependenceInjection(builder);
CustonIndependenceInjection.MapCustonIndependenceInjection(builder);
var app = builder.Build();


app.MapGet("/weatherforecast", () =>
{
    var process = System.Diagnostics.Process.GetCurrentProcess();

    return new
    {
        ManagedMemoryMB = GC.GetTotalMemory(false) / 1024d / 1024d,
        WorkingSetMB = process.WorkingSet64 / 1024d / 1024d,
        Gen0 = GC.CollectionCount(0),
        Gen1 = GC.CollectionCount(1),
        Gen2 = GC.CollectionCount(2)
    };

});





app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
