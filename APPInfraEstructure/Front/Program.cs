using System.Net;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    // HTTP sempre ativo (interno)
    //    options.Listen(
    //        IPAddress.Parse(GS.I.MYC.HttpIPListen),
    //        GS.I.MYC.HttpPortListen
    //    );

    options.ListenAnyIP(8080);


    // HTTPS só se certificado existir
    if (
        !string.IsNullOrWhiteSpace(GS.I.MYC.HttpsPathCertificado) &&
        File.Exists(GS.I.MYC.HttpsPathCertificado)
    )
    {
        options.Listen(
            IPAddress.Parse(GS.I.MYC.HttpsIPListen),
            GS.I.MYC.HttpsPortListen,
            listenOptions =>
            {
                listenOptions.UseHttps(
                    GS.I.MYC.HttpsPathCertificado,
                    GS.I.MYC.HttpssenhaCertificado
                );
            }
        );
    }

    options.Limits.MaxConcurrentConnections = GS.I.MYC.MaxConcurrentConnections;
    options.Limits.MaxConcurrentUpgradedConnections = GS.I.MYC.MaxConcurrentUpgradedConnections;
    options.Limits.MaxRequestBodySize = GS.I.MYC.MaxRequestBodySize;
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
