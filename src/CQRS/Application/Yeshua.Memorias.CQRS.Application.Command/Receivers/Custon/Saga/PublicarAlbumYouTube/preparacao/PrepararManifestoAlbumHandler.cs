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

namespace Command.Receivers
{
    public partial class PrepararManifestoAlbumHandler
    {
        private readonly IPublicacaoAlbumReadRepository _publicacaoReadRepository;
        private readonly IPublicacaoAlbumWriteRepository _publicacaoWriteRepository;
        private readonly IAlbumReadRepository _albumReadRepository;
        private readonly IAlbumFotoReadRepository _albumFotoReadRepository;
        private readonly IFotoReadRepository _fotoReadRepository;
        private readonly IFileStorage _fileStorage;

        public PrepararManifestoAlbumHandler(
            IPublicacaoAlbumReadRepository publicacaoReadRepository,
            IPublicacaoAlbumWriteRepository publicacaoWriteRepository,
            IAlbumReadRepository albumReadRepository,
            IAlbumFotoReadRepository albumFotoReadRepository,
            IFotoReadRepository fotoReadRepository,
            IFileStorage fileStorage)
        {
            _publicacaoReadRepository = publicacaoReadRepository;
            _publicacaoWriteRepository = publicacaoWriteRepository;
            _albumReadRepository = albumReadRepository;
            _albumFotoReadRepository = albumFotoReadRepository;
            _fotoReadRepository = fotoReadRepository;
            _fileStorage = fileStorage;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var publicacaoId = GetPublicacaoId(saga);
            var publicacao = _publicacaoReadRepository.FirstById(publicacaoId)
                ?? throw new SagaStepExecutionException("Publicacao do album nao encontrada.", retryable: false);

            var album = _albumReadRepository.FirstById(publicacao.albumid)
                ?? throw new SagaStepExecutionException("Album da publicacao nao encontrado.", retryable: false);

            var fotos = _albumFotoReadRepository
                .GetAllByAlbumId(album.id)
                .Where(albumFoto => !albumFoto.deleted)
                .OrderBy(albumFoto => albumFoto.ordem)
                .Select(albumFoto =>
                {
                    var foto = _fotoReadRepository.FirstById(albumFoto.fotoid)
                        ?? throw new SagaStepExecutionException($"Foto {albumFoto.fotoid} nao encontrada.", retryable: false);
                    if (foto.deleted || string.IsNullOrWhiteSpace(foto.storagekey))
                        throw new SagaStepExecutionException($"Foto {albumFoto.fotoid} invalida para renderizacao.", retryable: false);

                    return new AlbumRenderPhoto(
                        foto.storagekey.Replace('\\', '/'),
                        Math.Max(1, album.segundosporfoto),
                        albumFoto.legenda ?? string.Empty);
                })
                .ToArray();

            if (fotos.Length == 0)
                throw new SagaStepExecutionException("O album nao possui fotos para publicacao.", retryable: false);

            var baseKey = $"persistent/memorias/publicacoes/{publicacaoId}";
            var manifestStorageKey = $"{baseKey}/manifest.json";
            var outputStorageKey = $"{baseKey}/video.mp4";
            var manifest = new AlbumRenderManifest(
                1,
                outputStorageKey,
                1920,
                1080,
                30,
                Math.Max(1, album.segundosporfoto),
                fotos);

            using (var stream = _fileStorage.OpenWrite(new StoragePath(manifestStorageKey)))
            {
                JsonSerializer.Serialize(stream, manifest, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });
            }

            _publicacaoWriteRepository.UpdateManifestStorageKey(publicacaoId, manifestStorageKey);
            _publicacaoWriteRepository.UpdateVideoStorageKey(publicacaoId, outputStorageKey);
            _publicacaoWriteRepository.UpdateStatus(publicacaoId, MemoriasPublicationStatus.ManifestoPreparado);
            _publicacaoWriteRepository.UpdateMensagem(publicacaoId, "Manifesto preparado para renderizacao.");
            step.SetPayload(JsonSerializer.Serialize(new { manifestStorageKey, outputStorageKey }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
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
