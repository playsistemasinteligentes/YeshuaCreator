namespace Worker.Custon;

public static class CustonDependenceInjection
{
    public static void MapCustonDependenceInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<MediaOutboxTransportWorker>();
        builder.Services.AddHostedService(sp =>
            new PollingWorker<MediaOutboxTransportWorker, MediaOutboxTransportInputCommand, MediaOutboxTransportOutputCommand>(
                sp,
                sp.GetRequiredService<ILogger<PollingWorker<MediaOutboxTransportWorker, MediaOutboxTransportInputCommand, MediaOutboxTransportOutputCommand>>>(),
                TimeSpan.FromMilliseconds(500)));

        builder.Services.AddTransient<MediaRenderResultInboxWorker>();
        builder.Services.AddHostedService(sp =>
            new QueueListenerWorker<MediaRenderResultInboxWorker, Command.Receivers.RenderAlbumResultMessage, MediaRenderResultOutputCommand>(
                sp,
                sp.GetRequiredService<Command.Interfaces.Patterns.Queue.IQueueListener>(),
                sp.GetRequiredService<ILogger<QueueListenerWorker<MediaRenderResultInboxWorker, Command.Receivers.RenderAlbumResultMessage, MediaRenderResultOutputCommand>>>(),
                "media.album.rendered.inbox"));
    }
}
