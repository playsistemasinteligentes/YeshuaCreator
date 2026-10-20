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
                var videoPath = StoragePathBuilder.BuildFromFullPath(Command.Media.MemoriasStorage.Publications, publicacao.videostoragekey);
                if (!_fileStorage.ExistsAsync(videoPath, CancellationToken.None).GetAwaiter().GetResult())
                    throw new SagaStepExecutionException("Video volatil indisponivel. Solicite uma nova publicacao; reenvie fotos ausentes.", retryable: false);
                using var videoStream = _fileStorage.OpenRead(videoPath);
                videoId = _uploader.UploadAsync(new YouTubeVideoUpload(
                    new YouTubeOwner(publicacao.youtubecredentialtenantid, publicacao.userid),
                    publicacaoId, publicacao.conexaoyoutubeid, publicacao.canalyoutubeid, publicacao.videostoragekey,
                    string.IsNullOrWhiteSpace(album.titulo) ? $"Album {album.id}" : album.titulo,
                    BuildDescription(album.descricao, publicacao.musicaid), ResolvePrivacyStatus(publicacao.privacidadeyoutube, publicacao.canalstandardid > 0)),
                    videoStream, CancellationToken.None).GetAwaiter().GetResult();
            }
            catch (Exception exception) when (exception is YouTubeConnectionException or YouTubeUploadReviewException)
            {
                _publicacaoWriteRepository.UpdateStatus(publicacaoId, MemoriasPublicationStatus.YouTubePendenteConfiguracao);
                _publicacaoWriteRepository.UpdateMensagem(publicacaoId, publicacao.canalstandardid > 0
                    ? "O envio automatico precisa de revisao pela plataforma. O destino desta publicacao foi preservado."
                    : exception.Message);
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
            catch (Exception exception) when (exception is FileNotFoundException or DirectoryNotFoundException)
            {
                const string message = "Video volatil indisponivel. Solicite uma nova publicacao; reenvie fotos ausentes.";
                _publicacaoWriteRepository.UpdateStatus(publicacaoId, MemoriasPublicationStatus.Falhou);
                _publicacaoWriteRepository.UpdateMensagem(publicacaoId, message);
                throw new SagaStepExecutionException(message, retryable: false);
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

        private static string BuildDescription(string? description, int musicId)
        {
            var track = Dominio.Media.VideoPresentation.FindMusic(musicId);
            return track == null ? description ?? string.Empty : $"{description}\n\n{track.Credits}".Trim();
        }

        private static string ResolvePrivacyStatus(int privacidade, bool automatic)
        {
            if (privacidade is < 1 or > 3 || automatic && privacidade == 1)
                throw new SagaStepExecutionException("Visibilidade da publicacao incompativel com o canal de destino.", retryable: false);
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
