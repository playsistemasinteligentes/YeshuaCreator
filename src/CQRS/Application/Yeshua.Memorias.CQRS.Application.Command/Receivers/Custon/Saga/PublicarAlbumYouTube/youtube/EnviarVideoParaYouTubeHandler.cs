// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using System.Text.Json;
using Command.Interfaces.Patterns.FileStore;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using Memorias.YouTube;

namespace Command.Receivers
{
    public partial class EnviarVideoParaYouTubeHandler
    {
        private readonly IPublicacaoAlbumReadRepository _publicacaoReadRepository;
        private readonly IPublicacaoAlbumWriteRepository _publicacaoWriteRepository;
        private readonly IAlbumReadRepository _albumReadRepository;
        private readonly IFileStorage _fileStorage;
        private readonly IYouTubeVideoUploader _uploader;

        public EnviarVideoParaYouTubeHandler(
            IPublicacaoAlbumReadRepository publicacaoReadRepository,
            IPublicacaoAlbumWriteRepository publicacaoWriteRepository,
            IAlbumReadRepository albumReadRepository,
            IFileStorage fileStorage,
            IYouTubeVideoUploader uploader)
        {
            _publicacaoReadRepository = publicacaoReadRepository;
            _publicacaoWriteRepository = publicacaoWriteRepository;
            _albumReadRepository = albumReadRepository;
            _fileStorage = fileStorage;
            _uploader = uploader;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var publicacaoId = GetPublicacaoId(saga);
            var publicacao = _publicacaoReadRepository.FirstById(publicacaoId)
                ?? throw new SagaStepExecutionException("Publicacao do album nao encontrada.", retryable: false);

            if (string.IsNullOrWhiteSpace(publicacao.videostoragekey))
                throw new SagaStepExecutionException("Video da publicacao ainda nao foi renderizado.", retryable: true);

            // Uma tentativa ja confirmada nunca reenvia o arquivo.
            if (!string.IsNullOrWhiteSpace(publicacao.youtubevideoid)) return;
            var album = _albumReadRepository.FirstById(publicacao.albumid)
                ?? throw new SagaStepExecutionException("Album da publicacao nao encontrado.", retryable: false);
            string videoId;
            try
            {
                using var videoStream = _fileStorage.OpenRead(new StoragePath(publicacao.videostoragekey));
                videoId = _uploader.UploadAsync(new YouTubeVideoUpload(
                    new YouTubeOwner(publicacao.tenantid, publicacao.youtubecredentialuserid),
                    publicacaoId, publicacao.conexaoyoutubeid, publicacao.canalyoutubeid, publicacao.videostoragekey,
                    string.IsNullOrWhiteSpace(album.titulo) ? $"Album {album.id}" : album.titulo,
                    album.descricao ?? string.Empty, ResolvePrivacyStatus(album.privacidade)),
                    videoStream, CancellationToken.None).GetAwaiter().GetResult();
            }
            catch (Exception exception) when (exception is YouTubeConnectionException or YouTubeUploadReviewException)
            {
                _publicacaoWriteRepository.UpdateStatus(publicacaoId, MemoriasPublicationStatus.YouTubePendenteConfiguracao);
                _publicacaoWriteRepository.UpdateMensagem(publicacaoId, exception.Message);
                step.SetPayload(JsonSerializer.Serialize(new { youtube = "pending-oauth", publicacaoId }));
                step.SetWaiting();
                return;
            }
            catch (SagaStepExecutionException exception)
            {
                _publicacaoWriteRepository.UpdateStatus(publicacaoId, MemoriasPublicationStatus.Falhou);
                _publicacaoWriteRepository.UpdateMensagem(publicacaoId, exception.Retryable
                    ? "Falha temporaria no envio. A saga controla a retomada da mesma sessao."
                    : exception.Message);
                throw;
            }

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
                3 => "public",
                2 => "unlisted",
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
