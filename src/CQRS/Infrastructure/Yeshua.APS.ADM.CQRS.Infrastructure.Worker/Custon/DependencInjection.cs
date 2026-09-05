namespace Worker.Custon;

public static class CustonDependenceInjection
{
    public static void MapCustonDependenceInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient("YeshuaModuleApiTransport", client =>
        {
            client.Timeout = TimeSpan.FromSeconds(10);
        });

        builder.Services.AddTransient<YeshuaModuleHttpOutboxTransportWorker>();
        builder.Services.AddHostedService(sp =>
            new PollingWorker<YeshuaModuleHttpOutboxTransportWorker, YeshuaModuleHttpOutboxTransportInputCommand, YeshuaModuleHttpOutboxTransportOutputCommand>(
                sp,
                sp.GetRequiredService<ILogger<PollingWorker<YeshuaModuleHttpOutboxTransportWorker, YeshuaModuleHttpOutboxTransportInputCommand, YeshuaModuleHttpOutboxTransportOutputCommand>>>(),
                TimeSpan.FromSeconds(2)));
    }
}
