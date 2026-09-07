using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers
{
    internal sealed record SefazOpenSslHttpResponse(int StatusCode, string Body, string Headers);

    internal static class SefazOpenSslHttpFallback
    {
        public static bool CanHandle(Exception exception)
        {
            if (!OperatingSystem.IsWindows())
                return false;

            for (Exception? current = exception; current is not null; current = current.InnerException)
            {
                if (current is HttpRequestException or AuthenticationException)
                    continue;

                if (current.Message.Contains("Credenciais", StringComparison.OrdinalIgnoreCase) ||
                    current.Message.Contains("credentials", StringComparison.OrdinalIgnoreCase) ||
                    current.Message.Contains("SEC_E_NO_CREDENTIALS", StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        public static async Task<SefazOpenSslHttpResponse> PostAsync(
            string endpoint,
            string body,
            string contentType,
            string certificatePath,
            string certificatePassword,
            int timeoutSeconds)
        {
            var openSslPath = ResolveOpenSslPath();
            var tempDir = Path.Combine(Path.GetTempPath(), "yeshua-sefaz-openssl-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempDir);

            var certPem = Path.Combine(tempDir, "cert.pem");
            var keyPem = Path.Combine(tempDir, "key.pem");

            try
            {
                await RunOpenSslAsync(openSslPath, timeoutSeconds, null,
                    "pkcs12",
                    "-in", certificatePath,
                    "-clcerts",
                    "-nokeys",
                    "-out", certPem,
                    "-passin", "pass:" + certificatePassword).ConfigureAwait(false);

                await RunOpenSslAsync(openSslPath, timeoutSeconds, null,
                    "pkcs12",
                    "-in", certificatePath,
                    "-nocerts",
                    "-nodes",
                    "-out", keyPem,
                    "-passin", "pass:" + certificatePassword).ConfigureAwait(false);

                var uri = new Uri(endpoint);
                var payload = Encoding.UTF8.GetBytes(body);
                var request =
                    $"POST {uri.PathAndQuery} HTTP/1.1\r\n" +
                    $"Host: {uri.Host}\r\n" +
                    $"Content-Type: {contentType}\r\n" +
                    $"Content-Length: {payload.Length}\r\n" +
                    "Connection: close\r\n" +
                    "\r\n" +
                    body;

                var rawResponse = await RunOpenSslAsync(openSslPath, timeoutSeconds, request,
                    "s_client",
                    "-connect", uri.Host + ":" + uri.Port,
                    "-servername", uri.Host,
                    "-tls1_2",
                    "-cert", certPem,
                    "-key", keyPem,
                    "-quiet").ConfigureAwait(false);

                return ParseHttpResponse(rawResponse);
            }
            finally
            {
                try
                {
                    Directory.Delete(tempDir, recursive: true);
                }
                catch
                {
                }
            }
        }

        private static string ResolveOpenSslPath()
        {
            var configured = Environment.GetEnvironmentVariable("YESHUA_OPENSSL_PATH");
            if (!string.IsNullOrWhiteSpace(configured) && File.Exists(configured))
                return configured;

            const string gitOpenSsl = @"C:\Program Files\Git\mingw64\bin\openssl.exe";
            if (File.Exists(gitOpenSsl))
                return gitOpenSsl;

            return "openssl";
        }

        private static async Task<string> RunOpenSslAsync(
            string openSslPath,
            int timeoutSeconds,
            string? stdin,
            params string[] arguments)
        {
            using var process = new Process();
            process.StartInfo = new ProcessStartInfo(openSslPath)
            {
                RedirectStandardInput = stdin is not null,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            foreach (var argument in arguments)
                process.StartInfo.ArgumentList.Add(argument);

            process.Start();

            var outputTask = process.StandardOutput.ReadToEndAsync();
            var errorTask = process.StandardError.ReadToEndAsync();

            if (stdin is not null)
            {
                await process.StandardInput.WriteAsync(stdin).ConfigureAwait(false);
                process.StandardInput.Close();
            }

            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(timeoutSeconds));
            await process.WaitForExitAsync(cts.Token).ConfigureAwait(false);

            var output = await outputTask.ConfigureAwait(false);
            var error = await errorTask.ConfigureAwait(false);

            if (process.ExitCode != 0 && output.IndexOf("HTTP/", StringComparison.OrdinalIgnoreCase) < 0)
                throw new InvalidOperationException("OpenSSL falhou ao chamar SEFAZ. " + error);

            return output;
        }

        private static SefazOpenSslHttpResponse ParseHttpResponse(string raw)
        {
            var httpStart = raw.IndexOf("HTTP/", StringComparison.OrdinalIgnoreCase);
            if (httpStart < 0)
                throw new InvalidOperationException("OpenSSL nao retornou resposta HTTP da SEFAZ.");

            var http = raw[httpStart..];
            var separator = http.IndexOf("\r\n\r\n", StringComparison.Ordinal);
            var separatorLength = 4;
            if (separator < 0)
            {
                separator = http.IndexOf("\n\n", StringComparison.Ordinal);
                separatorLength = 2;
            }

            if (separator < 0)
                throw new InvalidOperationException("Resposta HTTP da SEFAZ sem separador de cabecalho.");

            var headers = http[..separator];
            var body = http[(separator + separatorLength)..];
            var firstLineEnd = headers.IndexOfAny(new[] { '\r', '\n' });
            var firstLine = firstLineEnd >= 0 ? headers[..firstLineEnd] : headers;
            var parts = firstLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2 || !int.TryParse(parts[1], out var statusCode))
                throw new InvalidOperationException("Nao foi possivel ler o status HTTP da SEFAZ.");

            return new SefazOpenSslHttpResponse(statusCode, body.Trim(), headers);
        }
    }
}
