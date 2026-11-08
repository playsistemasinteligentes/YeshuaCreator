// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using System;
using System.Linq;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class FinalizarCTeComplementarHandler
    {
        private readonly ICTeRomaneioConsolidadoReadRepository _romaneioReadRepository;
        private readonly ICTeSolicitacaoFiscalReadRepository _solicitacaoReadRepository;
        private readonly ICTeTentativaEmissaoReadRepository _tentativaReadRepository;
        private readonly IEntradaFiscalContingenciaReadRepository _entradaContingenciaReadRepository;
        private readonly IEntradaFiscalContingenciaWriteRepository _entradaContingenciaWriteRepository;
        private readonly IySagaReadRepository _sagaReadRepository;
        private readonly IySagaStepReadRepository _sagaStepReadRepository;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public FinalizarCTeComplementarHandler(
            ICTeRomaneioConsolidadoReadRepository romaneioReadRepository,
            ICTeSolicitacaoFiscalReadRepository solicitacaoReadRepository,
            ICTeTentativaEmissaoReadRepository tentativaReadRepository,
            IEntradaFiscalContingenciaReadRepository entradaContingenciaReadRepository,
            IEntradaFiscalContingenciaWriteRepository entradaContingenciaWriteRepository,
            IySagaReadRepository sagaReadRepository,
            IySagaStepReadRepository sagaStepReadRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _romaneioReadRepository = romaneioReadRepository;
            _solicitacaoReadRepository = solicitacaoReadRepository;
            _tentativaReadRepository = tentativaReadRepository;
            _entradaContingenciaReadRepository = entradaContingenciaReadRepository;
            _entradaContingenciaWriteRepository = entradaContingenciaWriteRepository;
            _sagaReadRepository = sagaReadRepository;
            _sagaStepReadRepository = sagaStepReadRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var romaneio = _romaneioReadRepository.FirstByCargaId(cargaId);
            if (romaneio == null || romaneio.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: romaneio do CT-e complementar nao encontrado na finalizacao.");

            var solicitacao = _solicitacaoReadRepository.FirstByRomaneioConsolidadoId(romaneio.id);
            if (solicitacao == null || solicitacao.id <= 0 || solicitacao.tipocte != 1)
                throw new InvalidOperationException($"Carga {cargaId}: solicitacao de CT-e complementar nao encontrada na finalizacao.");

            var tentativa = (_tentativaReadRepository.GetAllByCTeSolicitacaoFiscalId(solicitacao.id)
                    ?? Array.Empty<Repositorio.Outputs.CTeTentativaEmissaoDTO>())
                .OrderByDescending(x => x.id)
                .FirstOrDefault();
            if (tentativa == null || tentativa.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: tentativa do CT-e complementar nao encontrada.");
            if (tentativa.status != 3)
            {
                throw new InvalidOperationException(
                    $"Carga {cargaId}: CT-e complementar nao autorizado. Status={tentativa.status}; " +
                    $"cStat={tentativa.codigoretorno}; motivo={tentativa.mensagemretorno}.");
            }

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.cte-complementar.concluido",
                new
                {
                    origem = "Fiscal",
                    cargaId,
                    tentativa.chaveacesso,
                    tentativa.protocoloautorizacao,
                    tentativa.codigoretorno,
                    tentativa.mensagemretorno,
                    tentativa.xmlassinadostoragekey,
                    tentativa.xmlhash
                }));

            AcordarContingencia(saga, tentativa);
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: CT-e complementar concluido.");
        }

        private void AcordarContingencia(SagaBase saga, Repositorio.Outputs.CTeTentativaEmissaoDTO tentativa)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var contingencia = _sagaReadRepository.GetLatestByTypeEntityAndStatus(
                nameof(ContingenciaFiscalStandardSaga),
                "Carga",
                cargaId,
                1);
            if (contingencia == null || contingencia.id <= 0)
                return;

            var waitStep = _sagaStepReadRepository.GetFirstBySagaStepKeyAndStatuses(
                contingencia.id,
                ContingenciaFiscalStandardSaga.STEP_4,
                new[] { 0, 1, 2, 3, 4 });
            if (waitStep == null || waitStep.id <= 0)
                return;

            var entrada = _entradaContingenciaReadRepository.FirstByCargaId(cargaId);
            if (entrada != null && entrada.id > 0)
            {
                if (saga.Id > 0)
                    _entradaContingenciaWriteRepository.UpdateEmissaoFiscalSagaId(entrada.id, saga.Id);
                _entradaContingenciaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);
            }

            var payload = JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.resultado-emissao-fiscal.informado",
                origem = "Fiscal",
                modo = "cte-complementar-concluido",
                cargaId,
                emissaoFiscalSagaId = saga.Id,
                emissaoFiscalCorrelationId = saga.CorrelationId.ToString(),
                contingenciaSagaId = contingencia.id,
                contingenciaSagaCorrelationId = contingencia.correlationid,
                stepId = waitStep.id,
                stepKey = waitStep.stepkey,
                cte = new
                {
                    tentativa.chaveacesso,
                    tentativa.protocoloautorizacao,
                    tentativa.codigoretorno,
                    tentativa.mensagemretorno,
                    tentativa.xmlassinadostoragekey,
                    tentativa.xmlhash
                },
                mdfe = (object?)null,
                occurredAtUtc = DateTime.UtcNow
            });

            _inboxWriteRepository.Insert(new yInboxFactory(_logger).Create(
                null,
                Guid.NewGuid().ToString(),
                "fiscal.contingencia.resultado-emissao-fiscal.informado",
                "Carga",
                cargaId,
                waitStep.correlationid,
                payload,
                0,
                DateTime.UtcNow,
                0,
                null,
                null,
                null,
                contingencia.id,
                waitStep.id));
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
