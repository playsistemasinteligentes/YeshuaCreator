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

        public RenderizarVideoAlbumHandler(
            IPublicacaoAlbumReadRepository publicacaoReadRepository,
            IPublicacaoAlbumWriteRepository publicacaoWriteRepository,
            OutboxService outboxService)
        {
            _publicacaoReadRepository = publicacaoReadRepository;
            _publicacaoWriteRepository = publicacaoWriteRepository;
            _outboxService = outboxService;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var publicacaoId = GetPublicacaoId(saga);
            var publicacao = _publicacaoReadRepository.FirstById(publicacaoId)
                ?? throw new SagaStepExecutionException("Publicacao do album nao encontrada.", retryable: false);

            if (string.IsNullOrWhiteSpace(publicacao.manifeststoragekey))
                throw new SagaStepExecutionException("Manifesto da publicacao ainda nao foi preparado.", retryable: true);

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

            _publicacaoWriteRepository.UpdateVideoStorageKey(publicacaoId, message.Result.OutputStorageKey.Replace('\\', '/'));
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
