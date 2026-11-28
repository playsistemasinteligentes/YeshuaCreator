using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Yeshua.Central.BusinessMcp.Tests;

// Opt-in test infrastructure only. No system configuration, certificate store,
// production listener, container, private profile or real upstream is accessed.
internal sealed class IsolatedNginxGateway(string directory, Process process, int port, int httpPort, byte[] certificate) : IAsyncDisposable
{
    internal static string RepositoryRoot()
    {
        var root = new DirectoryInfo(AppContext.BaseDirectory);
        while (root is not null && !File.Exists(Path.Combine(root.FullName, "AGENTS.md"))) root = root.Parent;
        return root?.FullName ?? throw new InvalidOperationException("Repository root not found.");
    }

    internal HttpClient Client(bool tls = true)
    {
        var handler = new SocketsHttpHandler
        {
            AllowAutoRedirect = false, UseCookies = false, UseProxy = false,
            ConnectCallback = async (_, ct) =>
            {
                var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                try { await socket.ConnectAsync(IPAddress.Loopback, tls ? port : httpPort, ct); return new NetworkStream(socket, ownsSocket: true); }
                catch { socket.Dispose(); throw; }
            },
            SslOptions = new SslClientAuthenticationOptions
            {
                // Pin this ephemeral certificate only; retain hostname validation.
                RemoteCertificateValidationCallback = (_, presented, _, errors) => presented is not null
                    && (errors & SslPolicyErrors.RemoteCertificateNameMismatch) == 0
                    && presented.GetRawCertData().AsSpan().SequenceEqual(certificate)
            }
        };
        return new HttpClient(handler) { BaseAddress = new Uri(tls ? "https://central.test/" : "http://central.test/"), Timeout = TimeSpan.FromSeconds(30) };
    }

    internal static async Task<IsolatedNginxGateway> Start(string binary, string upstream, string? operationalUpstream = null)
    {
        if (!Path.IsPathFullyQualified(binary) || !File.Exists(binary)) throw new InvalidOperationException("YESHUA_TEST_NGINX must name an existing absolute binary path.");
        var directory = Directory.CreateTempSubdirectory("yeshua-agent-gateway-").FullName;
        using var rsa = RSA.Create(2048);
        var request = new CertificateRequest("CN=central.test", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        var names = new SubjectAlternativeNameBuilder(); names.AddDnsName("central.test"); names.AddDnsName("destination.test");
        request.CertificateExtensions.Add(names.Build());
        using var cert = request.CreateSelfSigned(DateTimeOffset.UtcNow.AddMinutes(-1), DateTimeOffset.UtcNow.AddMinutes(30));
        await File.WriteAllTextAsync(Path.Combine(directory, "cert.pem"), cert.ExportCertificatePem());
        await File.WriteAllTextAsync(Path.Combine(directory, "key.pem"), rsa.ExportPkcs8PrivateKeyPem());
        if (!OperatingSystem.IsWindows()) File.SetUnixFileMode(Path.Combine(directory, "key.pem"), UnixFileMode.UserRead | UnixFileMode.UserWrite);
        var listener = new TcpListener(IPAddress.Loopback, 0); listener.Start();
        var port = ((IPEndPoint)listener.LocalEndpoint).Port; listener.Stop();
        listener = new TcpListener(IPAddress.Loopback, 0); listener.Start();
        var httpPort = ((IPEndPoint)listener.LocalEndpoint).Port; listener.Stop();
        var root = Path.Combine(RepositoryRoot(), "infra/Shared/DockerCompose/nginx");
        var routes = await File.ReadAllTextAsync(Path.Combine(root, "routes/15-agent-oauth.conf.disabled"));
        routes += await File.ReadAllTextAsync(Path.Combine(root, "routes/10-applications.conf"));
        routes += await File.ReadAllTextAsync(Path.Combine(root, "routes/30-operational-intelligence.conf"));
        // Preserve actual upstream names and routing; all sockets are loopback fixtures.
        var pools = Regex.Matches(routes, @"proxy_pass http://([a-z_]+)").Select(m => m.Groups[1].Value).Distinct();
        var upstreams = string.Join('\n', pools.Select(pool => $"upstream {pool} {{ server {new Uri(pool == "operational_intelligence_api_pool" ? operationalUpstream ?? upstream : upstream).Authority}; }}"));
        var server = await File.ReadAllTextAsync(Path.Combine(root, "conf.d/20-https.conf.disabled"));
        server = server[..server.IndexOf("# Loaded together", StringComparison.Ordinal)]
            .Replace("listen 443 ssl;", $"listen 127.0.0.1:{port} ssl;")
            .Replace("server_name playsis.com.br;", "server_name central.test;")
            .Replace("/etc/letsencrypt/live/playsis.com.br/fullchain.pem", directory + "/cert.pem")
            .Replace("/etc/letsencrypt/live/playsis.com.br/privkey.pem", directory + "/key.pem")
            .Replace("include /etc/nginx/routes/*.conf;", routes);
        var httpServer = (await File.ReadAllTextAsync(Path.Combine(root, "conf.d/10-http.conf")))
            .Replace("listen 80;", $"listen 127.0.0.1:{httpPort};")
            .Replace("server_name _;", "server_name central.test;")
            .Replace("include /etc/nginx/routes/*.conf;", routes);
        var config = $"daemon off; master_process off; pid {directory}/nginx.pid; error_log {directory}/error.log crit;\nevents {{}}\nhttp {{ access_log off; client_body_temp_path {directory}/body; proxy_temp_path {directory}/proxy; fastcgi_temp_path {directory}/fastcgi; scgi_temp_path {directory}/scgi; uwsgi_temp_path {directory}/uwsgi;\n{upstreams}\n{server}\n{httpServer}\n}}";
        var path = Path.Combine(directory, "nginx.conf"); await File.WriteAllTextAsync(path, config);
        ProcessStartInfo Command(bool validate)
        {
            var info = new ProcessStartInfo(binary) { RedirectStandardError = true, RedirectStandardOutput = true };
            info.ArgumentList.Add("-p"); info.ArgumentList.Add(directory); info.ArgumentList.Add("-c"); info.ArgumentList.Add(path);
            if (validate) info.ArgumentList.Add("-t");
            return info;
        }
        using (var check = Process.Start(Command(true))!)
        {
            var error = check.StandardError.ReadToEndAsync(); await check.WaitForExitAsync();
            if (check.ExitCode != 0)
            {
                var message = await error; Directory.Delete(directory, recursive: true);
                throw new InvalidOperationException("Isolated nginx -t failed: " + message);
            }
        }
        var process = Process.Start(Command(false))!;
        var gateway = new IsolatedNginxGateway(directory, process, port, httpPort, cert.RawData);
        try
        {
            for (var attempt = 0; attempt < 100; attempt++)
            {
                if (process.HasExited) throw new InvalidOperationException("Isolated nginx exited: " + await process.StandardError.ReadToEndAsync());
                try { using var client = new TcpClient(); await client.ConnectAsync(IPAddress.Loopback, port); return gateway; }
                catch (SocketException) { await Task.Delay(25); }
            }
            throw new TimeoutException("Isolated nginx did not listen on loopback.");
        }
        catch { await gateway.DisposeAsync(); throw; }
    }

    public async ValueTask DisposeAsync()
    {
        if (!process.HasExited) process.Kill(entireProcessTree: true);
        await process.WaitForExitAsync(); process.Dispose();
        Directory.Delete(directory, recursive: true);
    }
}
