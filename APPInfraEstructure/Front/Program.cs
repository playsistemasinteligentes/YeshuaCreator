using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    // Limites continuam sendo responsabilidade da aplicação
    options.Limits.MaxConcurrentConnections =
        GS.I.MYC.MaxConcurrentConnections;

    options.Limits.MaxConcurrentUpgradedConnections =
        GS.I.MYC.MaxConcurrentUpgradedConnections;

    options.Limits.MaxRequestBodySize =
        GS.I.MYC.MaxRequestBodySize;
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
