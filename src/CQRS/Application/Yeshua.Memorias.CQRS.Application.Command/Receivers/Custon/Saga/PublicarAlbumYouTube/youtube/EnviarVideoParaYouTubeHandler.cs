// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Command.Interfaces.Patterns.FileStore;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;

namespace Command.Receivers
{
    public partial class EnviarVideoParaYouTubeHandler
    {
        private readonly IPublicacaoAlbumReadRepository _publicacaoReadRepository;
        private readonly IPublicacaoAlbumWriteRepository _publicacaoWriteRepository;
        private readonly IAlbumReadRepository _albumReadRepository;
        private readonly IFileStorage _fileStorage;

        public EnviarVideoParaYouTubeHandler(
            IPublicacaoAlbumReadRepository publicacaoReadRepository,
            IPublicacaoAlbumWriteRepository publicacaoWriteRepository,
            IAlbumReadRepository albumReadRepository,
            IFileStorage fileStorage)
        {
            _publicacaoReadRepository = publicacaoReadRepository;
            _publicacaoWriteRepository = publicacaoWriteRepository;
            _albumReadRepository = albumReadRepository;
            _fileStorage = fileStorage;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var publicacaoId = GetPublicacaoId(saga);
            var publicacao = _publicacaoReadRepository.FirstById(publicacaoId)
                ?? throw new SagaStepExecutionException("Publicacao do album nao encontrada.", retryable: false);

            if (string.IsNullOrWhiteSpace(publicacao.videostoragekey))
                throw new SagaStepExecutionException("Video da publicacao ainda nao foi renderizado.", retryable: true);

            var accessToken = Environment.GetEnvironmentVariable("YESHUA_MEMORIAS_YOUTUBE_ACCESS_TOKEN");
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                _publicacaoWriteRepository.UpdateStatus(publicacaoId, MemoriasPublicationStatus.YouTubePendenteConfiguracao);
                _publicacaoWriteRepository.UpdateMensagem(publicacaoId, "Video renderizado. Publicacao no YouTube pendente de OAuth/token no .NET.");
                step.SetPayload(JsonSerializer.Serialize(new { youtube = "pending-oauth", publicacaoId }));
                return;
            }

            var album = _albumReadRepository.FirstById(publicacao.albumid)
                ?? throw new SagaStepExecutionException("Album da publicacao nao encontrado.", retryable: false);

            using var videoStream = _fileStorage.OpenRead(new StoragePath(publicacao.videostoragekey));
            using var http = new HttpClient();
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var metadata = new
            {
                snippet = new
                {
                    title = string.IsNullOrWhiteSpace(album.titulo) ? $"Album {album.id}" : album.titulo,
                    description = album.descricao ?? string.Empty
                },
                status = new
                {
                    privacyStatus = ResolvePrivacyStatus(album.privacidade)
                }
            };

            using var startContent = new StringContent(
                JsonSerializer.Serialize(metadata),
                Encoding.UTF8,
                "application/json");
            startContent.Headers.Add("X-Upload-Content-Type", "video/mp4");
            startContent.Headers.Add("X-Upload-Content-Length", videoStream.Length.ToString());

            using var startResponse = http.PostAsync(
                "https://www.googleapis.com/upload/youtube/v3/videos?uploadType=resumable&part=snippet,status",
                startContent).GetAwaiter().GetResult();

            if (!startResponse.IsSuccessStatusCode || startResponse.Headers.Location == null)
            {
                var body = startResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                throw new SagaStepExecutionException($"YouTube nao aceitou o inicio do upload: {(int)startResponse.StatusCode} {body}", retryable: false);
            }

            using var uploadContent = new StreamContent(videoStream);
            uploadContent.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
            using var uploadResponse = http.PutAsync(startResponse.Headers.Location, uploadContent).GetAwaiter().GetResult();
            var uploadBody = uploadResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (!uploadResponse.IsSuccessStatusCode)
                throw new SagaStepExecutionException($"Upload para YouTube falhou: {(int)uploadResponse.StatusCode} {uploadBody}", retryable: true);

            using var document = JsonDocument.Parse(uploadBody);
            var videoId = document.RootElement.TryGetProperty("id", out var idElement)
                ? idElement.GetString()
                : null;

            if (string.IsNullOrWhiteSpace(videoId))
                throw new SagaStepExecutionException("YouTube concluiu upload sem retornar id do video.", retryable: false);

            var url = $"https://www.youtube.com/watch?v={videoId}";
            _publicacaoWriteRepository.UpdateYouTubeVideoId(publicacaoId, videoId);
            _publicacaoWriteRepository.UpdateYouTubeUrl(publicacaoId, url);
            _publicacaoWriteRepository.UpdatePublicadaEmUtc(publicacaoId, DateTime.UtcNow);
            _publicacaoWriteRepository.UpdateStatus(publicacaoId, MemoriasPublicationStatus.PublicadaNoYouTube);
            _publicacaoWriteRepository.UpdateMensagem(publicacaoId, "Video publicado no YouTube.");
            step.SetPayload(JsonSerializer.Serialize(new { youtubeVideoId = videoId, youtubeUrl = url }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
        }

        private static string ResolvePrivacyStatus(int privacidade)
        {
            return privacidade switch
            {
                2 => "public",
                1 => "unlisted",
                _ => "private"
            };
        }

        private static int GetPublicacaoId(SagaBase saga)
        {
            return int.TryParse(saga.EntityId, out var id) && id > 0
                ? id
                : throw new SagaStepExecutionException("Saga sem PublicacaoAlbum associada.", retryable: false);
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
