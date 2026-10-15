namespace API.Migrations;

public static class EndpointsCuston
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGet("/yapi/Memorias/musicas/{musicaId:int}/arquivo", static (int musicaId, Memorias.Media.MusicFileReader reader, HttpContext context) =>
        {
            context.Response.Headers.CacheControl = "private, no-store";
            context.Response.Headers["X-Content-Type-Options"] = "nosniff";
            var stream = reader.Open(musicaId);
            return stream == null ? Results.NotFound() : Results.File(stream, "audio/mpeg", enableRangeProcessing: true);
        }).RequireAuthorization().WithTags("Memorias", "Musicas");
        app.MapGet("/yapi/Memorias/fotos/{fotoId:int}/arquivo", static (int fotoId, Memorias.Media.PhotoFileReader reader, HttpContext context) =>
        {
            context.Response.Headers.CacheControl = "private, no-store";
            context.Response.Headers["X-Content-Type-Options"] = "nosniff";
            var photo = reader.Open(fotoId);
            return photo == null ? Results.NotFound() : Results.File(photo.Stream, photo.ContentType);
        }).RequireAuthorization().WithTags("Memorias", "Fotos");
    }
}
