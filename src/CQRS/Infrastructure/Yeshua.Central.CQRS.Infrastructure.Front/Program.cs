var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        // Keep conditional caching, but always validate application assets after a deploy.
        var extension = Path.GetExtension(context.File.Name);
        if (extension is ".html" or ".js" or ".css" or ".json")
            context.Context.Response.Headers.CacheControl = "no-cache";
    }
});

app.MapGet("/memorias", () => Results.Redirect("/spa/?app=Memorias"));
app.MapGet("/memorias/login", () => Results.Redirect("/spa/?app=Memorias#login"));

app.Run();
