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
using Repositorio.Outputs;
using System;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class PublicarDocumentosFiscaisDaCargaConcluidosHandler
    {
        private readonly ICTeRomaneioConsolidadoReadRepository _cteRomaneioConsolidadoReadRepository;
        private readonly ICTeSolicitacaoFiscalReadRepository _cteSolicitacaoFiscalReadRepository;
        private readonly ICTeTentativaEmissaoReadRepository _cteTentativaEmissaoReadRepository;
        private readonly IMDFeSolicitacaoFiscalReadRepository _mdfeSolicitacaoFiscalReadRepository;
        private readonly IMDFeTentativaEmissaoReadRepository _mdfeTentativaEmissaoReadRepository;
        private readonly IEntradaFiscalContingenciaReadRepository _entradaFiscalContingenciaReadRepository;
        private readonly IEntradaFiscalContingenciaWriteRepository _entradaFiscalContingenciaWriteRepository;
        private readonly IySagaReadRepository _sagaReadRepository;
        private readonly IySagaStepReadRepository _sagaStepReadRepository;
        private readonly IyOutboxWriteRepository _outboxWriteRepository;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public PublicarDocumentosFiscaisDaCargaConcluidosHandler(
            ICTeRomaneioConsolidadoReadRepository cteRomaneioConsolidadoReadRepository,
            ICTeSolicitacaoFiscalReadRepository cteSolicitacaoFiscalReadRepository,
            ICTeTentativaEmissaoReadRepository cteTentativaEmissaoReadRepository,
            IMDFeSolicitacaoFiscalReadRepository mdfeSolicitacaoFiscalReadRepository,
            IMDFeTentativaEmissaoReadRepository mdfeTentativaEmissaoReadRepository,
            IEntradaFiscalContingenciaReadRepository entradaFiscalContingenciaReadRepository,
            IEntradaFiscalContingenciaWriteRepository entradaFiscalContingenciaWriteRepository,
            IySagaReadRepository sagaReadRepository,
            IySagaStepReadRepository sagaStepReadRepository,
            IyOutboxWriteRepository outboxWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _cteRomaneioConsolidadoReadRepository = cteRomaneioConsolidadoReadRepository;
            _cteSolicitacaoFiscalReadRepository = cteSolicitacaoFiscalReadRepository;
            _cteTentativaEmissaoReadRepository = cteTentativaEmissaoReadRepository;
            _mdfeSolicitacaoFiscalReadRepository = mdfeSolicitacaoFiscalReadRepository;
            _mdfeTentativaEmissaoReadRepository = mdfeTentativaEmissaoReadRepository;
            _entradaFiscalContingenciaReadRepository = entradaFiscalContingenciaReadRepository;
            _entradaFiscalContingenciaWriteRepository = entradaFiscalContingenciaWriteRepository;
            _sagaReadRepository = sagaReadRepository;
            _sagaStepReadRepository = sagaStepReadRepository;
            _outboxWriteRepository = outboxWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var fiscal = CarregarDocumentosAutorizados(saga);

            var outbox = FiscalSagaPayloads.CreateOutbox(
                _logger,
                saga,
                step,
                "DocumentosFiscaisDaCargaConcluidos.v1",
                new
                {
                    origem = "Fiscal",
                    moduloOrigem = "Fiscal",
                    sagaOrigem = "EmissaoFiscalCargaStandard",
                    stepOrigem = "publicarDocumentosFiscaisDaCargaConcluidos",
                    moduloDestino = "APSADM",
                    sagaDestino = "CargaStandard",
                    cargaId = saga.EntityId,
                    cte = new
                    {
                        fiscal.CTe.chaveacesso,
                        fiscal.CTe.protocoloautorizacao,
                        fiscal.CTe.codigoretorno,
                        fiscal.CTe.mensagemretorno,
                        fiscal.CTe.xmlassinadostoragekey,
                        fiscal.CTe.xmlhash
                    },
                    mdfe = new
                    {
                        fiscal.MDFe.chaveacesso,
                        fiscal.MDFe.protocoloautorizacao,
                        fiscal.MDFe.codigoretorno,
                        fiscal.MDFe.mensagemretorno,
                        fiscal.MDFe.xmlassinadostoragekey,
                        fiscal.MDFe.xmlhash
                    }
                },
                "APSADM",
                "/yapi/APSADM/Inbox/YeshuaModuleEvent",
                "YeshuaModules:APSADM:BaseUrl");

            _outboxWriteRepository.Insert(outbox);

            var inbox = FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.documentos-concluidos.publicacao-enfileirada",
                new
                {
                    origem = "Fiscal",
                    modo = "documentos-autorizados",
                    entityId = saga.EntityId,
                    cteChave = fiscal.CTe.chaveacesso,
                    mdfeChave = fiscal.MDFe.chaveacesso
                });

            _inboxWriteRepository.Insert(inbox);

            AcordarContingenciaSeExistir(saga, fiscal);
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: documentos fiscais concluidos publicados para APS.");
        }

        private (CTeTentativaEmissaoDTO CTe, MDFeTentativaEmissaoDTO MDFe) CarregarDocumentosAutorizados(SagaBase saga)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var romaneio = _cteRomaneioConsolidadoReadRepository.FirstByCargaId(cargaId);
            if (romaneio == null || romaneio.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: romaneio consolidado CT-e nao encontrado para publicar conclusao fiscal.");

            var cteSolicitacao = _cteSolicitacaoFiscalReadRepository.FirstByRomaneioConsolidadoId(romaneio.id);
            if (cteSolicitacao == null || cteSolicitacao.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: solicitacao CT-e nao encontrada para publicar conclusao fiscal.");

            var cteTentativa = _cteTentativaEmissaoReadRepository.FirstByCTeSolicitacaoFiscalId(cteSolicitacao.id);
            if (cteTentativa == null || cteTentativa.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: tentativa CT-e nao encontrada para publicar conclusao fiscal.");

            if (cteTentativa.status != 3)
                throw new InvalidOperationException($"Carga {cargaId}: CT-e ainda nao esta autorizado. Status tentativa={cteTentativa.status}; cStat={cteTentativa.codigoretorno}; motivo={cteTentativa.mensagemretorno}");

            var mdfeSolicitacao = _mdfeSolicitacaoFiscalReadRepository.FirstByCargaId(cargaId);
            if (mdfeSolicitacao == null || mdfeSolicitacao.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: solicitacao MDF-e nao encontrada para publicar conclusao fiscal.");

            var mdfeTentativa = _mdfeTentativaEmissaoReadRepository.FirstByMDFeSolicitacaoFiscalId(mdfeSolicitacao.id);
            if (mdfeTentativa == null || mdfeTentativa.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: tentativa MDF-e nao encontrada para publicar conclusao fiscal.");

            if (mdfeTentativa.status != 3)
                throw new InvalidOperationException($"Carga {cargaId}: MDF-e ainda nao esta autorizado. Status tentativa={mdfeTentativa.status}; cStat={mdfeTentativa.codigoretorno}; motivo={mdfeTentativa.mensagemretorno}");

            return (cteTentativa, mdfeTentativa);
        }

        private void AcordarContingenciaSeExistir(SagaBase saga, (CTeTentativaEmissaoDTO CTe, MDFeTentativaEmissaoDTO MDFe) fiscal)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            if (string.IsNullOrWhiteSpace(cargaId))
                return;

            var contingencia = _sagaReadRepository.GetLatestByTypeEntityAndStatus(
                nameof(ContingenciaFiscalStandardSaga),
                "Carga",
                cargaId,
                1);

            if (contingencia == null || contingencia.id <= 0)
                return;

            var waitStep = _sagaStepReadRepository.GetFirstBySagaStepKeyAndStatuses(
                contingencia.id,
                ContingenciaFiscalStandardSaga.STEP_11,
                new[] { 0, 1, 2, 3, 4 });

            if (waitStep == null || waitStep.id <= 0)
                return;

            var entrada = _entradaFiscalContingenciaReadRepository.FirstByCargaId(cargaId);
            if (entrada != null && entrada.id > 0)
            {
                if (saga.Id > 0)
                    _entradaFiscalContingenciaWriteRepository.UpdateEmissaoFiscalSagaId(entrada.id, saga.Id);
                _entradaFiscalContingenciaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);
            }

            var payload = JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.resultado-emissao-fiscal.informado",
                origem = "Fiscal",
                modo = "documentos-fiscais-concluidos",
                cargaId,
                emissaoFiscalSagaId = saga.Id,
                emissaoFiscalCorrelationId = saga.CorrelationId.ToString(),
                contingenciaSagaId = contingencia.id,
                contingenciaSagaCorrelationId = contingencia.correlationid,
                stepId = waitStep.id,
                stepKey = waitStep.stepkey,
                cte = new
                {
                    fiscal.CTe.chaveacesso,
                    fiscal.CTe.protocoloautorizacao,
                    fiscal.CTe.codigoretorno,
                    fiscal.CTe.mensagemretorno,
                    fiscal.CTe.xmlassinadostoragekey,
                    fiscal.CTe.xmlhash
                },
                mdfe = new
                {
                    fiscal.MDFe.chaveacesso,
                    fiscal.MDFe.protocoloautorizacao,
                    fiscal.MDFe.codigoretorno,
                    fiscal.MDFe.mensagemretorno,
                    fiscal.MDFe.xmlassinadostoragekey,
                    fiscal.MDFe.xmlhash
                },
                occurredAtUtc = DateTime.UtcNow
            });

            var inbox = new yInboxFactory(_logger).Create(
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
                waitStep.id);

            _inboxWriteRepository.Insert(inbox);
            _logger.Info($"Fiscal {cargaId}: resultado da emissao fiscal publicado para contingencia.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
