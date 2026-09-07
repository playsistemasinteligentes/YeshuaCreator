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
using IRepository.Write;
using System;

namespace Command.Receivers
{
    public partial class AutorizarCTeNaSefazHandler
    {
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly IDocumentoFiscalWriteRepository _documentoFiscalWriteRepository;
        private readonly ILogger _logger;

        public AutorizarCTeNaSefazHandler(
            IyInboxWriteRepository inboxWriteRepository,
            IDocumentoFiscalWriteRepository documentoFiscalWriteRepository,
            ILogger logger)
        {
            _inboxWriteRepository = inboxWriteRepository;
            _documentoFiscalWriteRepository = documentoFiscalWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            try
            {
                var result = CteRecepcaoSincV4HomologacaoClient.Autorizar();
                var respostaEstruturada = result.CodigoRetorno > 0 && !string.IsNullOrWhiteSpace(result.Motivo);

                if (!respostaEstruturada)
                {
                    var exception = new InvalidOperationException(
                        $"SEFAZ CT-e nao retornou resposta fiscal estruturada. HTTP={result.HttpStatusCode}; chave={result.Chave}");

                    _logger.CommandFailed(
                        "Fiscal.CTe.AutorizarCTeNaSefaz.SemRespostaFiscalEstruturada",
                        step.CorrelationId,
                        exception,
                        0);
                }

                if (respostaEstruturada && !result.Autorizado)
                {
                    var rejection = new InvalidOperationException(
                        $"SEFAZ CT-e rejeitou em homologacao. cStat={result.CodigoRetorno}; xMotivo={result.Motivo}; chave={result.Chave}");

                    _logger.CommandFailed(
                        "Fiscal.CTe.AutorizarCTeNaSefaz.RejeicaoFiscal",
                        step.CorrelationId,
                        rejection,
                        0);
                }

                SefazFiscalDocumentStore.PersistirCTe(
                    _documentoFiscalWriteRepository,
                    _logger,
                    saga,
                    step,
                    result);

                _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                    _logger,
                    saga,
                    step,
                    "fiscal.cte.resposta-sefaz-homologacao",
                    new
                    {
                        origem = "Fiscal",
                        modo = "sefaz-homologacao",
                        autorizado = result.Autorizado,
                        erroTecnico = false,
                        respostaFiscalEstruturada = respostaEstruturada,
                        cStat = result.CodigoRetorno,
                        xMotivo = result.Motivo,
                        chave = result.Chave,
                        protocolo = result.Protocolo,
                        httpStatusCode = result.HttpStatusCode,
                        entityId = saga.EntityId
                    }));
            }
            catch (Exception ex)
            {
                _logger.CommandFailed(
                    "Fiscal.CTe.AutorizarCTeNaSefaz.ErroTecnico",
                    step.CorrelationId,
                    ex,
                    0);

                _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                    _logger,
                    saga,
                    step,
                    "fiscal.cte.resposta-sefaz-homologacao",
                    new
                    {
                        origem = "Fiscal",
                        modo = "sefaz-homologacao",
                        autorizado = false,
                        erroTecnico = true,
                        respostaFiscalEstruturada = false,
                        cStat = 0,
                        xMotivo = ex.InnerException == null
                            ? ex.Message
                            : ex.Message + " | inner: " + ex.InnerException.Message,
                        chave = string.Empty,
                        protocolo = string.Empty,
                        httpStatusCode = 0,
                        exceptionType = ex.GetType().FullName,
                        entityId = saga.EntityId
                    }));
            }
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: resposta CT-e SEFAZ homologacao registrada.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
