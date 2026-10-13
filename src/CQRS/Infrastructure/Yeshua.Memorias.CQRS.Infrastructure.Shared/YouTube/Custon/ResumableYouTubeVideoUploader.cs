using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dominio.Patterns.Saga;

namespace Memorias.YouTube;

public sealed class ResumableYouTubeVideoUploader(
    IYouTubeAccountRepository repository, IYouTubeConnectionService connections,
    IHttpClientFactory httpClients) : IYouTubeVideoUploader
{
    public async Task<string> UploadAsync(YouTubeVideoUpload upload, Stream video, CancellationToken cancellationToken)
    {
        if (!video.CanSeek || video.Length <= 0)
            throw new SagaStepExecutionException("Video invalido para envio.", retryable: false);
        using var lease = await repository.AcquireUploadAsync(upload.Owner, upload.PublicationId, cancellationToken);
        var state = lease.ReadUpload(upload.PublicationId);
        video.Position = 0;
        var sha = Convert.ToHexString(await SHA256.HashDataAsync(video, cancellationToken));
        video.Position = 0;
        if (state != null && (state.ConnectionId != upload.ConnectionId || state.ChannelId != upload.ChannelId
            || state.StorageKey != upload.StorageKey || state.Length != video.Length || state.Sha256 != sha))
            throw new YouTubeUploadReviewException("Destino ou video diverge da sessao original. Revise a publicacao.");
        if (!string.IsNullOrEmpty(state?.VideoId)) return state.VideoId;

        var token = await connections.GetAccessTokenAsync(upload.Owner, upload.ConnectionId, upload.ChannelId, cancellationToken);
        if (string.IsNullOrWhiteSpace(token))
            throw new YouTubeConnectionException("Video pronto. Reconecte o canal de destino e retome o envio.");
        using var http = httpClients.CreateClient("Memorias.YouTube.Upload");
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        try
        {
            long offset = 0;
            if (state == null)
            {
                var metadata = JsonSerializer.Serialize(new YouTubeVideoMetadata(
                    new(upload.Title, upload.Description), new(upload.Privacy)), YouTubeUploadJson.Default.YouTubeVideoMetadata);
                using var request = new HttpRequestMessage(HttpMethod.Post,
                    "https://www.googleapis.com/upload/youtube/v3/videos?uploadType=resumable&part=snippet,status");
                request.Content = new StringContent(metadata, Encoding.UTF8, "application/json");
                request.Headers.Add("X-Upload-Content-Type", "video/mp4");
                request.Headers.Add("X-Upload-Content-Length", video.Length.ToString(CultureInfo.InvariantCulture));
                using var response = await http.SendAsync(request, cancellationToken);
                RequireSuccess(response);
                var uri = ValidateSessionUri(response.Headers.Location?.AbsoluteUri);
                state = new(upload.PublicationId, upload.ConnectionId, upload.ChannelId, upload.StorageKey,
                    video.Length, sha, uri.AbsoluteUri);
                // Nenhum byte do video sai antes da sessao estar duravelmente salva.
                lease.SaveUpload(state);
            }
            else
            {
                using var probe = new HttpRequestMessage(HttpMethod.Put, ValidateSessionUri(state.SessionUri));
                probe.Content = new ByteArrayContent([]);
                probe.Content.Headers.ContentRange = new ContentRangeHeaderValue(video.Length);
                using var response = await http.SendAsync(probe, cancellationToken);
                if (response.IsSuccessStatusCode) return await ConfirmAsync(lease, state, response, cancellationToken);
                offset = ReadOffset(response, video.Length);
            }

            if (offset >= video.Length)
                throw new SagaStepExecutionException("YouTube ainda nao confirmou a conclusao do video.", retryable: true);
            video.Position = offset;
            using var body = new StreamContent(video);
            body.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
            body.Headers.ContentLength = video.Length - offset;
            body.Headers.ContentRange = new ContentRangeHeaderValue(offset, video.Length - 1, video.Length);
            using var put = new HttpRequestMessage(HttpMethod.Put, ValidateSessionUri(state.SessionUri)) { Content = body };
            using var completed = await http.SendAsync(put, cancellationToken);
            if ((int)completed.StatusCode == 308)
            {
                ReadOffset(completed, video.Length);
                throw new SagaStepExecutionException("Envio parcial. A proxima tentativa consultara a mesma sessao.", retryable: true);
            }
            RequireSuccess(completed);
            return await ConfirmAsync(lease, state, completed, cancellationToken);
        }
        catch (Exception exception) when (exception is HttpRequestException or TaskCanceledException)
        {
            throw new SagaStepExecutionException("Comunicacao YouTube interrompida. Retomada pela mesma sessao.", retryable: true);
        }
    }

    private static async Task<string> ConfirmAsync(IYouTubeAccountLease lease, YouTubeUploadState state,
        HttpResponseMessage response, CancellationToken cancellationToken)
    {
        string? id;
        try
        {
            await response.Content.LoadIntoBufferAsync(65536);
            using var document = JsonDocument.Parse(await response.Content.ReadAsStringAsync(cancellationToken));
            id = document.RootElement.TryGetProperty("id", out var value) && value.ValueKind == JsonValueKind.String
                ? value.GetString() : null;
        }
        catch (JsonException) { id = null; }
        if (string.IsNullOrWhiteSpace(id) || id.Length > 64 || !id.All(c => char.IsAsciiLetterOrDigit(c) || c is '_' or '-'))
            throw new YouTubeUploadReviewException("YouTube nao devolveu uma confirmacao valida. Consulte a publicacao antes de reenviar.");
        // O recibo sobrevive a falhas posteriores ao atualizar o banco/saga.
        lease.SaveUpload(state with { VideoId = id });
        return id;
    }

    private static Uri ValidateSessionUri(string? value)
    {
        if (!Uri.TryCreate(value, UriKind.Absolute, out var uri) || uri.Scheme != Uri.UriSchemeHttps
            || uri.Host != "www.googleapis.com" || uri.Port != 443 || !string.IsNullOrEmpty(uri.UserInfo)
            || !string.IsNullOrEmpty(uri.Fragment) || uri.AbsolutePath != "/upload/youtube/v3/videos")
            throw new YouTubeUploadReviewException("Endereco da sessao YouTube invalido. Revise a publicacao.");
        return uri;
    }

    private static long ReadOffset(HttpResponseMessage response, long length)
    {
        if ((int)response.StatusCode != 308) { RequireSuccess(response); return 0; }
        if (!response.Headers.TryGetValues("Range", out var values)) return 0;
        var headers = values.ToArray();
        if (headers.Length != 1 || !RangeHeaderValue.TryParse(headers[0], out var range) || range.Unit != "bytes"
            || range.Ranges.Count != 1 || range.Ranges.Single().From != 0
            || range.Ranges.Single().To is not long end || end < 0 || end >= length)
            throw new YouTubeUploadReviewException("YouTube retornou uma posicao de envio invalida.");
        return end + 1;
    }

    private static void RequireSuccess(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode) return;
        if (response.StatusCode == HttpStatusCode.Unauthorized)
            throw new YouTubeConnectionException("Google recusou o acesso. Reconecte o mesmo canal e retome o envio.");
        if (response.StatusCode is HttpStatusCode.NotFound or HttpStatusCode.Gone)
            throw new YouTubeUploadReviewException("Sessao YouTube expirada. Confira o canal antes de criar outra publicacao.");
        var code = (int)response.StatusCode;
        throw new SagaStepExecutionException($"YouTube recusou o envio (HTTP {code}).",
            retryable: code is 408 or 429 or 500 or 502 or 503 or 504);
    }
}

internal sealed record YouTubeVideoMetadata(YouTubeVideoSnippet snippet, YouTubeVideoStatus status);
internal sealed record YouTubeVideoSnippet(string title, string description);
internal sealed record YouTubeVideoStatus(string privacyStatus);
[JsonSerializable(typeof(YouTubeVideoMetadata))]
internal partial class YouTubeUploadJson : JsonSerializerContext;
