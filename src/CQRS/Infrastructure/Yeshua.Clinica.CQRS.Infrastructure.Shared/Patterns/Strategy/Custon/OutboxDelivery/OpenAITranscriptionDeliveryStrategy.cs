using Command.Interfaces.Patterns.FileStore;
using Command.Patterns.OutBox;
using Shared.Operational;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Clinica.Infrastructure.OutboxDelivery;

public sealed class OpenAITranscriptionDeliveryStrategy(
    HttpClient client, IFileStorage storage, ClinicaTranscriptionOptions options) : IOutboxDeliveryStrategy
{
    private const long MaximumUploadBytes = 24_000_000;
    private const long MaximumInputBytes = 250_000_000;
    private const int MaximumTextLength = 300_000;
    public int TransportType => 2; // Existing Http value in the standard Outbox schema.

    public async Task<ExternalExecutionResult?> DeliverAsync(OutboxDeliveryRequest request, CancellationToken cancellationToken)
    {
        if (request.Message.Type != "audio.transcribe" || request.ResultContract != "audio.transcribed")
            throw Failure("operation_invalid", "Operacao de transcricao invalida.");
        if (string.IsNullOrWhiteSpace(options.ApiKey))
            throw Failure("transcription_credentials_missing", "Credencial de transcricao nao configurada.");
        if (!Uri.TryCreate(options.BaseUrl.TrimEnd('/') + "/audio/transcriptions", UriKind.Absolute, out var endpoint)
            || endpoint.Scheme != Uri.UriSchemeHttps || !string.IsNullOrEmpty(endpoint.UserInfo)
            || !string.IsNullOrEmpty(endpoint.Query) || !string.IsNullOrEmpty(endpoint.Fragment))
            throw Failure("transcription_endpoint_invalid", "Endereco de transcricao invalido.");

        var source = AudioReference(request);
        if (!await storage.ExistsAsync(source, cancellationToken))
            throw Failure("audio_missing", "Audio indisponivel. Reenvie o arquivo.");
        await using var input = storage.OpenRead(source);
        if (!input.CanSeek || input.Length <= 0 || input.Length > MaximumInputBytes)
            throw Failure("audio_size_invalid", "Arquivo de audio vazio, extenso ou indisponivel para leitura.");

        var header = new byte[12];
        var count = await input.ReadAtLeastAsync(header, (int)Math.Min(input.Length, header.Length),
            throwOnEndOfStream: false, cancellationToken);
        input.Position = 0;
        var format = DetectFormat(header.AsSpan(0, count));
        string text;
        if (input.Length <= MaximumUploadBytes && format is { } recognized)
            text = await SendAsync(request, endpoint, input, recognized.Extension, recognized.Mime, cancellationToken);
        else
            text = await PrepareAndSendAsync(request, endpoint, input, cancellationToken);

        return ExternalExecutionResult.Create(request, "audio.transcription.completed",
            JsonSerializer.SerializeToElement(new TranscriptionText(text), TranscriptionJson.Default.TranscriptionText));
    }

    private static StoragePath AudioReference(OutboxDeliveryRequest request)
    {
        try
        {
            using var document = JsonDocument.Parse(request.Message.Payload as string ?? "");
            var root = document.RootElement;
            var key = root.GetProperty("StorageKey").GetString() ?? "";
            var uploadId = root.GetProperty("uploadId").GetInt32();
            var expected = $"volatile/ia/transcriptions/input/{request.TenantId}/{uploadId}/audio.webm";
            if (request.TenantId <= 0 || uploadId <= 0 || key.Replace('\\', '/') != expected)
                throw new JsonException();
            return StoragePathBuilder.BuildFromFullPath(StorageLocation.Volatile.TranscriptionsInput, expected);
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or KeyNotFoundException or FormatException)
        {
            throw Failure("audio_reference_invalid", "Referencia de audio invalida.");
        }
    }

    private async Task<string> SendAsync(OutboxDeliveryRequest request, Uri endpoint, Stream audio,
        string extension, string mime, CancellationToken cancellationToken)
    {
        using var form = new MultipartFormDataContent();
        var file = new StreamContent(audio);
        file.Headers.ContentType = new MediaTypeHeaderValue(mime);
        form.Add(file, "file", "audio." + extension);
        form.Add(new StringContent(options.Model), "model");
        form.Add(new StringContent("pt"), options.Model == "gpt-transcribe" ? "languages[]" : "language");
        using var http = new HttpRequestMessage(HttpMethod.Post, endpoint) { Content = form };
        http.Headers.Authorization = new AuthenticationHeaderValue("Bearer", options.ApiKey);
        http.Options.Set(OperationalHttpRequestOptions.Operation, "Audio.Transcription");
        http.Options.Set(OperationalHttpRequestOptions.CorrelationId, request.Message.CorrelationId ?? "");
        http.Options.Set(OperationalHttpRequestOptions.MessageId, request.Message.MenssageId ?? "");
        using var response = await client.SendAsync(http, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        using var body = await ReadBodyAsync(response, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var code = ReadErrorCode(body.RootElement);
            var quota = code is "insufficient_quota" or "credit_balance_exhausted"
                or "organization_spend_limit_exceeded" or "project_spend_limit_exceeded";
            var retryable = !quota && (response.StatusCode is HttpStatusCode.RequestTimeout
                or HttpStatusCode.TooManyRequests || (int)response.StatusCode >= 500);
            TimeSpan? retryAfter = response.Headers.RetryAfter?.Delta;
            if (retryAfter is null && response.Headers.RetryAfter?.Date is { } date)
                retryAfter = date - DateTimeOffset.UtcNow;
            if (retryAfter is { } delay)
                retryAfter = TimeSpan.FromSeconds(Math.Clamp(delay.TotalSeconds, 1, 300));
            throw new OutboxDeliveryException(quota ? "transcription_quota" : "transcription_http_" + (int)response.StatusCode,
                "O provedor de transcricao recusou a solicitacao.", retryable, retryAfter);
        }
        if (body.RootElement.ValueKind != JsonValueKind.Object
            || !body.RootElement.TryGetProperty("text", out var value) || value.ValueKind != JsonValueKind.String
            || string.IsNullOrWhiteSpace(value.GetString()) || value.GetString()!.Length > MaximumTextLength)
            throw Failure("transcription_invalid", "O provedor nao retornou uma transcricao valida.");
        return value.GetString()!;
    }

    private static async Task<JsonDocument> ReadBodyAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var buffer = new MemoryStream();
        var chunk = new byte[8192];
        while (true)
        {
            var read = await stream.ReadAsync(chunk, cancellationToken);
            if (read == 0) break;
            if (buffer.Length + read > 5_000_000)
                throw Failure("transcription_response_large", "Resposta de transcricao extensa.");
            buffer.Write(chunk, 0, read);
        }
        try { return JsonDocument.Parse(buffer.ToArray(), new JsonDocumentOptions { MaxDepth = 16 }); }
        catch (JsonException)
        {
            if (!response.IsSuccessStatusCode)
                return JsonDocument.Parse("{}"); // Do not retain or expose provider error bodies.
            throw Failure("transcription_response_invalid", "Resposta de transcricao invalida.");
        }
    }

    private async Task<string> PrepareAndSendAsync(OutboxDeliveryRequest request, Uri endpoint, Stream input,
        CancellationToken cancellationToken)
    {
        var root = Path.GetFullPath(Path.Combine(options.StorageRoot, "volatile", "ia", "transcriptions", "output"));
        Directory.CreateDirectory(root);
        if (File.GetAttributes(root).HasFlag(FileAttributes.ReparsePoint))
            throw Failure("audio_storage_invalid", "Area temporaria de audio invalida.");
        var job = Path.Combine(root, "openai-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(job);
        try
        {
            await PrepareAsync(input, job, cancellationToken);
            var parts = Directory.GetFiles(job, "part-*.mp3").OrderBy(p => p, StringComparer.Ordinal).ToArray();
            if (parts.Length is 0 or > 64)
                throw Failure("audio_parts_invalid", "Audio sem partes validas ou extenso.");
            var text = new StringBuilder();
            foreach (var part in parts)
            {
                var info = new FileInfo(part);
                if (info.Length <= 0 || info.Length > MaximumUploadBytes)
                    throw Failure("audio_part_large", "Parte de audio fora do limite.");
                await using var audio = File.OpenRead(part);
                var value = await SendAsync(request, endpoint, audio, "mp3", "audio/mpeg", cancellationToken);
                if (text.Length + value.Length + 1 > MaximumTextLength)
                    throw Failure("transcription_large", "Transcricao fora do limite de armazenamento.");
                if (text.Length > 0) text.Append('\n');
                text.Append(value);
            }
            return text.ToString();
        }
        finally
        {
            if (Path.GetDirectoryName(job) == root && Directory.Exists(job))
                Directory.Delete(job, recursive: true);
        }
    }

    private async Task PrepareAsync(Stream input, string job, CancellationToken cancellationToken)
    {
        var source = Path.Combine(job, "source.audio");
        await using (var copy = File.Create(source))
            await input.CopyToAsync(copy, cancellationToken);
        using var process = new Process
        {
            StartInfo = new ProcessStartInfo(options.FFmpegExecutable)
            {
                UseShellExecute = false, CreateNoWindow = true,
                RedirectStandardOutput = true, RedirectStandardError = true
            }
        };
        foreach (var argument in new[] { "-nostdin", "-v", "error", "-i", source, "-vn", "-ac", "1",
            "-ar", "16000", "-c:a", "libmp3lame", "-b:a", "64k", "-f", "segment", "-segment_time", "600",
            Path.Combine(job, "part-%04d.mp3") })
            process.StartInfo.ArgumentList.Add(argument);
        try
        {
            if (!process.Start()) throw Failure("audio_preparation_failed", "Nao foi possivel preparar o audio.");
        }
        catch (System.ComponentModel.Win32Exception)
        {
            throw Failure("ffmpeg_missing", "FFmpeg indisponivel para preparar este audio.");
        }
        using var stop = cancellationToken.Register(static state =>
        {
            try { ((Process)state!).Kill(entireProcessTree: true); }
            catch (InvalidOperationException) { }
            catch (System.ComponentModel.Win32Exception) { }
        }, process);
        try
        {
            var stdout = process.StandardOutput.BaseStream.CopyToAsync(Stream.Null, cancellationToken);
            var stderr = process.StandardError.BaseStream.CopyToAsync(Stream.Null, cancellationToken);
            await Task.WhenAll(process.WaitForExitAsync(cancellationToken), stdout, stderr);
            if (process.ExitCode != 0)
                throw Failure("audio_preparation_failed", "Nao foi possivel preparar o audio.");
        }
        catch
        {
            try { if (!process.HasExited) process.Kill(entireProcessTree: true); }
            catch (InvalidOperationException) { }
            catch (System.ComponentModel.Win32Exception) { }
            await process.WaitForExitAsync(CancellationToken.None);
            throw;
        }
    }

    private static (string Extension, string Mime)? DetectFormat(ReadOnlySpan<byte> header)
    {
        if (header.Length < 4) return null;
        if (header[0] == 0x1a && header[1] == 0x45 && header[2] == 0xdf && header[3] == 0xa3)
            return ("webm", "audio/webm");
        if (header[..4].SequenceEqual("OggS"u8)) return ("ogg", "audio/ogg");
        if (header.Length >= 8 && header.Slice(4, 4).SequenceEqual("ftyp"u8)) return ("mp4", "audio/mp4");
        if (header.Length >= 12 && header[..4].SequenceEqual("RIFF"u8)
            && header.Slice(8, 4).SequenceEqual("WAVE"u8)) return ("wav", "audio/wav");
        if (header[..3].SequenceEqual("ID3"u8) || (header[0] == 0xff && (header[1] & 0xe0) == 0xe0))
            return ("mp3", "audio/mpeg");
        if (header[..4].SequenceEqual("fLaC"u8)) return ("flac", "audio/flac");
        return null;
    }
    private static string? ReadErrorCode(JsonElement root)
        => root.ValueKind == JsonValueKind.Object && root.TryGetProperty("error", out var error) && error.ValueKind == JsonValueKind.Object
            && error.TryGetProperty("code", out var code) && code.ValueKind == JsonValueKind.String ? code.GetString() : null;
    private static OutboxDeliveryException Failure(string code, string message) => new(code, message, false);
}

internal sealed record TranscriptionText(string text);
[JsonSerializable(typeof(TranscriptionText))]
internal partial class TranscriptionJson : JsonSerializerContext;
