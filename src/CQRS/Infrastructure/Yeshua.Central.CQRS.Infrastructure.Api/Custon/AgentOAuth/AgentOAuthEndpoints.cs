using System.Security.Claims;
using Microsoft.AspNetCore;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Central.AgentOAuth;

public static class AgentOAuthEndpoints
{
    private const string ServerScheme = OpenIddictServerAspNetCoreDefaults.AuthenticationScheme;
    public static void MapCentralAgentOAuth(this WebApplication app)
    {
        var options = app.Services.GetRequiredService<AgentOAuthOptions>();
        app.MapMethods("/oauth/authorize", ["GET", "POST"], async (HttpContext http, IAntiforgery csrf,
            AgentOAuthReceiver receiver) =>
        {
            Secure(http);
            var request = http.GetOpenIddictServerRequest()!;
            if (http.Request.Method == "GET")
            {
                if (request.HasPromptValue("none")) return ProtocolError(Errors.LoginRequired);
                var client = options.Clients.SingleOrDefault(c => c.ClientId == request.ClientId);
                if (client is null) return ProtocolError(Errors.InvalidClient);
                var tokens = csrf.GetAndStoreTokens(http);
                string Encode(string? value) => HtmlEncoder.Default.Encode(value ?? "");
                var body = new StringBuilder("<!doctype html><html lang=\"pt-BR\"><meta charset=\"utf-8\"><title>Autorizar agente</title><main><h1>Autorizar agente externo</h1>");
                body.Append("<p>Cliente: ").Append(Encode(client.DisplayName)).Append("</p><p>Retorno: ")
                    .Append(Encode(request.RedirectUri)).Append("</p><p>Permissões solicitadas: ")
                    .Append(Encode(string.Join("; ", request.GetScopes().Select(scope => scope switch
                    {
                        "business:discover" => "Descobrir aplicativos e operações permitidos",
                        "offline_access" => "Renovar o acesso do agente por até sete dias",
                        _ when scope.StartsWith("application:", StringComparison.Ordinal) => "Usar " + scope["application:".Length..] + " com seus acessos atuais",
                        _ => scope
                    })))).Append("</p>")
                    .Append("<p>O agente executará como você no seu tenant, sujeito aos acessos atuais. A renovação pode ser revogada na Central.</p>")
                    .Append("<form method=\"post\" action=\"/oauth/authorize\">");
                foreach (var key in new[] { "client_id", "redirect_uri", "response_type", "response_mode", "scope", "state", "code_challenge", "code_challenge_method", "resource" })
                {
                    var value = (string?)request.GetParameter(key);
                    if (value is not null) body.Append("<input type=\"hidden\" name=\"").Append(key).Append("\" value=\"").Append(Encode(value)).Append("\">");
                }
                body.Append("<input type=\"hidden\" name=\"").Append(Encode(tokens.FormFieldName)).Append("\" value=\"").Append(Encode(tokens.RequestToken)).Append("\">")
                    .Append("<label>Login da Central <input name=\"username\" type=\"email\" autocomplete=\"username\" required></label>")
                    .Append("<label>Senha <input name=\"password\" type=\"password\" autocomplete=\"current-password\" required></label>")
                    .Append("<p>Ao autorizar você confirma o cliente, os aplicativos e o acesso solicitado acima.</p>")
                    .Append("<button name=\"decision\" value=\"allow\">Autorizar este agente</button> <button name=\"decision\" value=\"deny\" formnovalidate>Negar</button></form></main></html>");
                return Results.Content(body.ToString(), "text/html; charset=utf-8");
            }
            try { await csrf.ValidateRequestAsync(http); }
            catch (AntiforgeryValidationException) { return Results.BadRequest(new { error = "invalid_request" }); }
            var form = await http.Request.ReadFormAsync(http.RequestAborted);
            if (form["decision"] != "allow") return ProtocolError(Errors.AccessDenied);
            var principal = await receiver.AuthorizeAsync(request.ClientId!, request.GetScopes(), form["username"]!, form["password"]!, http.RequestAborted);
            return principal is null ? ProtocolError(Errors.AccessDenied) : Results.SignIn(principal, authenticationScheme: ServerScheme);
        }).AllowAnonymous();
        app.MapPost("/oauth/token", async (HttpContext http, AgentOAuthReceiver receiver) =>
        {
            Secure(http);
            var request = http.GetOpenIddictServerRequest()!;
            if (!request.IsAuthorizationCodeGrantType() && !request.IsRefreshTokenGrantType()) return ProtocolError(Errors.UnsupportedGrantType);
            var authentication = await http.AuthenticateAsync(ServerScheme);
            if (authentication.Principal is null) return ProtocolError(Errors.InvalidGrant);
            var principal = await receiver.RenewAsync(authentication.Principal, request.ClientId!, http.RequestAborted);
            return principal is null ? ProtocolError(Errors.InvalidGrant) : Results.SignIn(principal, authenticationScheme: ServerScheme);
        }).AllowAnonymous();
        app.MapGet(new Uri(AgentOAuthRegistration.MetadataUri(options)).AbsolutePath, (HttpContext http) =>
        {
            Secure(http);
            return Results.Json(new { resource = options.Resource, authorization_servers = new[] { options.Issuer },
                bearer_methods_supported = new[] { "header" }, scopes_supported = new[] { "business:discover" } });
        }).AllowAnonymous();
        // A regular Central session owns grant management. No OAuth delegate, Admin
        // inference, tenant/user form field, or guessed grant ID can revoke another owner.
        var management = app.MapGroup("/yapi/agents").RequireAuthorization(policy => policy.RequireAuthenticatedUser()
            .RequireClaim("tokenOrigin", "Central").RequireClaim("application", "Central"));
        management.MapGet("/grants", async (HttpContext http, AgentOAuthReceiver receiver) =>
        {
            Secure(http); var (owner, tenant) = Owner(http.User);
            return Results.Json(await receiver.ListAsync(owner, tenant, http.RequestAborted));
        });
        management.MapPost("/revoke", async (HttpContext http, RevokeAgentGrant command, AgentOAuthReceiver receiver) =>
        {
            Secure(http); var (owner, tenant) = Owner(http.User);
            return await receiver.RevokeAsync(command, owner, tenant, http.RequestAborted) ? Results.NoContent() : Results.NotFound();
        });
    }
    private static (int, int) Owner(ClaimsPrincipal user) =>
        (int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var owner) ? owner : 0,
         int.TryParse(user.FindFirst("tenantId")?.Value, out var tenant) ? tenant : 0);
    private static IResult ProtocolError(string error) => Results.Forbid(new AuthenticationProperties(new Dictionary<string, string?>
        { [OpenIddictServerAspNetCoreConstants.Properties.Error] = error }), [ServerScheme]);
    private static void Secure(HttpContext http)
    {
        http.Response.Headers.CacheControl = "no-store";
        http.Response.Headers.Pragma = "no-cache";
        http.Response.Headers["Content-Security-Policy"] = "default-src 'none'; form-action 'self'; frame-ancestors 'none'; base-uri 'none'";
        http.Response.Headers["X-Frame-Options"] = "DENY";
        http.Response.Headers["Referrer-Policy"] = "no-referrer";
        http.Response.Headers["X-Content-Type-Options"] = "nosniff";
    }
}
