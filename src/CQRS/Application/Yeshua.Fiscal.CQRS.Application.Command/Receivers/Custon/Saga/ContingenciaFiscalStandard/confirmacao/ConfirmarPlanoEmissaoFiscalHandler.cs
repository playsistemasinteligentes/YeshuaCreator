// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using System;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class ConfirmarPlanoEmissaoFiscalHandler
    {
        private readonly IEntradaFiscalContingenciaReadRepository _entradaReadRepository = default!;
        private readonly IEntradaFiscalContingenciaWriteRepository _entradaWriteRepository = default!;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository = default!;
        private readonly ILogger _logger = default!;

        public ConfirmarPlanoEmissaoFiscalHandler(
            IEntradaFiscalContingenciaReadRepository entradaReadRepository,
            IEntradaFiscalContingenciaWriteRepository entradaWriteRepository,
            INFeProdutoSnapshotReadRepository nfeProdutoSnapshotReadRepository,
            ILogger logger)
        {
            _entradaReadRepository = entradaReadRepository;
            _entradaWriteRepository = entradaWriteRepository;
            _nfeProdutoSnapshotReadRepository = nfeProdutoSnapshotReadRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            _entradaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);
            _entradaWriteRepository.UpdateStatus(entrada.id, 3);

            step.SetPayload(JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.aguardando-confirmacao-plano-emissao",
                entradaFiscalContingenciaId = entrada.id,
                cargaId = entrada.cargaid,
                occurredAtUtc = DateTime.UtcNow
            }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            var entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            FiscalContingenciaState.ApplyComplemento(_entradaWriteRepository, entrada, payload, ContingenciaFiscalStandardSaga.STEP_9);

            entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            var documentos = FiscalContingenciaState.LoadDocumentos(_nfeProdutoSnapshotReadRepository, entrada.cargaid);
            var planoJson = FiscalContingenciaPayload.PlanoEmissaoJson(entrada, documentos);

            _entradaWriteRepository.UpdateSnapshotJson(entrada.id, planoJson);
            _entradaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);
            _entradaWriteRepository.UpdateStatus(entrada.id, 4);
            _logger.Info($"Contingencia fiscal {saga.EntityId}: plano de emissao confirmado pela tela.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
