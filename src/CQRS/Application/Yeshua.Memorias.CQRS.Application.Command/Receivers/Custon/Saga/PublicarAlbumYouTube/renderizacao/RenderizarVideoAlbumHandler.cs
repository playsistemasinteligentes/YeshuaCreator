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
using Command.Patterns.OutBox;
using Command.Interfaces.Patterns.FileStore;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;

namespace Command.Receivers
{
    public partial class RenderizarVideoAlbumHandler
    {
        private const string RenderRequestedType = "media.album.render.requested";
        private const string RenderCompletedStatus = "media.album.render.completed";
        private const string RenderFailedStatus = "media.album.render.failed";

        private readonly IPublicacaoAlbumReadRepository _publicacaoReadRepository;
        private readonly IPublicacaoAlbumWriteRepository _publicacaoWriteRepository;
        private readonly OutboxService _outboxService;
        private readonly IFileStorage _fileStorage;

        public RenderizarVideoAlbumHandler(
            IPublicacaoAlbumReadRepository publicacaoReadRepository,
            IPublicacaoAlbumWriteRepository publicacaoWriteRepository,
            OutboxService outboxService,
            IFileStorage fileStorage)
        {
            _publicacaoReadRepository = publicacaoReadRepository;
            _publicacaoWriteRepository = publicacaoWriteRepository;
            _outboxService = outboxService;
            _fileStorage = fileStorage;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var publicacaoId = GetPublicacaoId(saga);
            var publicacao = _publicacaoReadRepository.FirstById(publicacaoId)
                ?? throw new SagaStepExecutionException("Publicacao do album nao encontrada.", retryable: false);

            if (string.IsNullOrWhiteSpace(publicacao.manifeststoragekey))
                throw new SagaStepExecutionException("Manifesto da publicacao ainda nao foi preparado.", retryable: true);

            var manifestPath = StoragePathBuilder.BuildFromFullPath(Command.Media.MemoriasStorage.Publications, publicacao.manifeststoragekey);
            if (!_fileStorage.ExistsAsync(manifestPath, CancellationToken.None).GetAwaiter().GetResult())
                throw new SagaStepExecutionException("Manifesto volatil indisponivel. Solicite uma nova publicacao; reenvie fotos ausentes.", retryable: false);

            var payload = new
            {
                ManifestPath = publicacao.manifeststoragekey.Replace('\\', '/'),
                PublicacaoAlbumId = publicacaoId
            };

            _outboxService.AddOutBoxEvent(
                RenderRequestedType,
                payload,
                "PublicacaoAlbum",
                publicacaoId.ToString(),
                Guid.NewGuid().ToString("D"),
                step.CorrelationId,
                1,
                new
                {
                    exchange = "media.tasks",
                    routingKey = "media.album.render",
                    taskName = "app.tasks.render_album"
                },
                saga.Id,
                step.Id);

            _publicacaoWriteRepository.UpdateStatus(publicacaoId, MemoriasPublicationStatus.RenderizacaoSolicitada);
            _publicacaoWriteRepository.UpdateMensagem(publicacaoId, "Renderizacao enviada para o worker de midia.");
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            var publicacaoId = GetPublicacaoId(saga);
            var message = JsonSerializer.Deserialize<RenderAlbumResultMessage>(payload)
                ?? throw new SagaStepExecutionException("Retorno da renderizacao invalido.", retryable: false);

            if (string.Equals(message.Status, RenderFailedStatus, StringComparison.OrdinalIgnoreCase))
            {
                var error = message.Error?.Message ?? "Renderizacao falhou.";
                _publicacaoWriteRepository.UpdateStatus(publicacaoId, MemoriasPublicationStatus.Falhou);
                _publicacaoWriteRepository.UpdateMensagem(publicacaoId, error);
                throw new SagaStepExecutionException(error, retryable: false);
            }

            if (!string.Equals(message.Status, RenderCompletedStatus, StringComparison.OrdinalIgnoreCase)
                || message.Result == null
                || string.IsNullOrWhiteSpace(message.Result.OutputStorageKey))
            {
                throw new SagaStepExecutionException("Retorno da renderizacao nao confirmou video gerado.", retryable: false);
            }

            var expectedOutput = Command.Media.MemoriasStorage.PublicationPath(publicacaoId, "video.mp4").Value.Replace('\\', '/');
            if (!string.Equals(expectedOutput, message.Result.OutputStorageKey.Replace('\\', '/'), StringComparison.Ordinal))
                throw new SagaStepExecutionException("O video retornado nao pertence a esta publicacao.", retryable: false);
            _publicacaoWriteRepository.UpdateVideoStorageKey(publicacaoId, expectedOutput);
            _publicacaoWriteRepository.UpdateStatus(publicacaoId, MemoriasPublicationStatus.VideoRenderizado);
            _publicacaoWriteRepository.UpdateMensagem(publicacaoId, "Video renderizado pelo worker de midia.");
            step.SetPayload(payload);
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
