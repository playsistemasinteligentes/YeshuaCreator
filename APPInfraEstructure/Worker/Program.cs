var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

//var host = app.Services.GetRequiredService<WorkerHost>();

//var inboxWorker = app.Services.GetRequiredService<Worker<InboxCommand, object>>();
//var outboxWorker = app.Services.GetRequiredService<Worker<OutboxCommand, object>>();

//host.Register(inboxWorker.RunAsync);
//host.Register(outboxWorker.RunAsync);

//var cts = new CancellationTokenSource();

//app.Lifetime.ApplicationStopping.Register(() =>
//{
//    cts.Cancel();
//});

//_ = host.RunAsync(cts.Token);













// Configure the HTTP request pipeline.

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
