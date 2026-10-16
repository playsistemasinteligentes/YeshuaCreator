var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/memorias", () => Results.Redirect("/spa/?app=Memorias"));
app.MapGet("/memorias/login", () => Results.Redirect("/spa/?app=Memorias#login"));

app.Run();
