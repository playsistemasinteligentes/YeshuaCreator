using System.Net;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Parse(GS.I.MYC.HttpIPListen), GS.I.MYC.HttpPortListen);
    options.Listen(IPAddress.Parse(GS.I.MYC.HttpsIPListen), GS.I.MYC.HttpsPortListen, listenOptions =>
    {
        listenOptions.UseHttps(GS.I.MYC.HttpsPathCertificado, GS.I.MYC.HttpssenhaCertificado);
    });
    options.Limits.MaxConcurrentConnections = GS.I.MYC.MaxConcurrentConnections; // Ajuste conforme necessário
    options.Limits.MaxConcurrentUpgradedConnections = GS.I.MYC.MaxConcurrentUpgradedConnections; // Para WebSockets
    options.Limits.MaxRequestBodySize = GS.I.MYC.MaxRequestBodySize; // Limite do corpo da requisição
});




var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();

