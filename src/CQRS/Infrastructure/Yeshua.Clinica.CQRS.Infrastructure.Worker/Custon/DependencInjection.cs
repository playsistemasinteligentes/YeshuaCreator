namespace Worker.Custon;

public static class CustonDependenceInjection
{
    public static void MapCustonDependenceInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<Command.Receivers.Custon.UseCases.FileUpload.Infra.UploadTokenHelper>(_ =>
            new(builder.Configuration["UploadTokens:SigningKey"] ?? string.Empty));
    }
}
