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
using IRepository.Read;
using IRepository.Write;
using System;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class AguardarResultadoEmissaoFiscalHandler
    {
        private readonly IEntradaFiscalContingenciaReadRepository _entradaReadRepository = default!;
        private readonly IEntradaFiscalContingenciaWriteRepository _entradaWriteRepository = default!;
        private readonly ILogger _logger = default!;

        public AguardarResultadoEmissaoFiscalHandler(
            IEntradaFiscalContingenciaReadRepository entradaReadRepository,
            IEntradaFiscalContingenciaWriteRepository entradaWriteRepository,
            ILogger logger)
        {
            _entradaReadRepository = entradaReadRepository;
            _entradaWriteRepository = entradaWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            _entradaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);
            _entradaWriteRepository.UpdateStatus(entrada.id, 5);
            _logger.Info($"Contingencia fiscal {entrada.cargaid}: aguardando resultado da emissao fiscal.");
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            // pendencia: publicar aqui um fato de negocio versionado para automacoes externas do tenant.
            // A entrega deve usar Outbox/HTTP e nao bloquear a saga. Uma regra externa que decida
            // encerrar MDF-e deve chamar o Command publico de encerramento com autenticacao,
            // autorizacao e idempotencia; codigo do cliente nunca deve rodar neste processo.
            var entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            _entradaWriteRepository.UpdateSnapshotJson(entrada.id, JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.resultado-emissao-fiscal",
                entradaFiscalContingenciaId = entrada.id,
                cargaId = entrada.cargaid,
                resultadoPayload = payload,
                occurredAtUtc = DateTime.UtcNow
            }));
            _entradaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);
            _entradaWriteRepository.UpdateStatus(entrada.id, 6);

            _logger.Info($"Contingencia fiscal {entrada.cargaid}: resultado da emissao fiscal recebido.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
