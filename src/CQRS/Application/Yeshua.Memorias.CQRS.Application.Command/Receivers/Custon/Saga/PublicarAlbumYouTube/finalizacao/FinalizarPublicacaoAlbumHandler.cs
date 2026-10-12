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
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;

namespace Command.Receivers
{
    public partial class FinalizarPublicacaoAlbumHandler
    {
        private readonly IPublicacaoAlbumReadRepository _publicacaoReadRepository;
        private readonly IPublicacaoAlbumWriteRepository _publicacaoWriteRepository;

        public FinalizarPublicacaoAlbumHandler(
            IPublicacaoAlbumReadRepository publicacaoReadRepository,
            IPublicacaoAlbumWriteRepository publicacaoWriteRepository)
        {
            _publicacaoReadRepository = publicacaoReadRepository;
            _publicacaoWriteRepository = publicacaoWriteRepository;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var publicacaoId = GetPublicacaoId(saga);
            var publicacao = _publicacaoReadRepository.FirstById(publicacaoId)
                ?? throw new SagaStepExecutionException("Publicacao do album nao encontrada.", retryable: false);

            if (!string.IsNullOrWhiteSpace(publicacao.youtubevideoid))
            {
                _publicacaoWriteRepository.UpdateStatus(publicacaoId, MemoriasPublicationStatus.Finalizada);
                _publicacaoWriteRepository.UpdateMensagem(publicacaoId, "Publicacao finalizada.");
                step.SetPayload(JsonSerializer.Serialize(new { status = "finalizada", publicacaoId }));
                return;
            }

            _publicacaoWriteRepository.UpdateStatus(publicacaoId, MemoriasPublicationStatus.YouTubePendenteConfiguracao);
            _publicacaoWriteRepository.UpdateMensagem(publicacaoId, "Video pronto. Aguardando configuracao OAuth do YouTube no .NET.");
            step.SetPayload(JsonSerializer.Serialize(new { status = "aguardando-youtube-oauth", publicacaoId }));
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
