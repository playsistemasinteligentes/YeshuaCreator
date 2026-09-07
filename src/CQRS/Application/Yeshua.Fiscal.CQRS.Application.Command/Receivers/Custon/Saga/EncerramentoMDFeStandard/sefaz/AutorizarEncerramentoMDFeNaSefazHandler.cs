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
    public partial class AutorizarEncerramentoMDFeNaSefazHandler
    {
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public AutorizarEncerramentoMDFeNaSefazHandler(
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            try
            {
                var result = MdfeRecepcaoEventoClient
                    .EncerrarAsync(MdfeEncerramentoSefazOptions.FromEnvironment())
                    .GetAwaiter()
                    .GetResult();

                var respostaEstruturada = result.CodigoRetorno > 0 &&
                                          !string.IsNullOrWhiteSpace(result.Motivo);

                if (!respostaEstruturada)
                {
                    var exception = new InvalidOperationException(
                        $"SEFAZ MDF-e nao retornou resposta fiscal estruturada. HTTP={result.HttpStatusCode}; chave={result.ChaveAcesso}");

                    _logger.CommandFailed(
                        "Fiscal.MDFe.Encerramento.Sefaz.SemRespostaFiscalEstruturada",
                        step.CorrelationId,
                        exception,
                        0);
                }

                if (respostaEstruturada && !result.Encerrado)
                {
                    var rejection = new InvalidOperationException(
                        $"SEFAZ MDF-e retornou rejeicao. cStat={result.CodigoRetorno}; xMotivo={result.Motivo}; chave={result.ChaveAcesso}");

                    _logger.CommandFailed(
                        "Fiscal.MDFe.Encerramento.Sefaz.RejeicaoFiscal",
                        step.CorrelationId,
                        rejection,
                        0);
                }

                _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                    _logger,
                    saga,
                    step,
                    "fiscal.mdfe.encerramento.resposta-sefaz",
                    new
                    {
                        origem = "Fiscal",
                        modo = "sefaz-mdfe-recepcao-evento",
                        encerrado = result.Encerrado,
                        erroTecnico = false,
                        respostaFiscalEstruturada = respostaEstruturada,
                        cStat = result.CodigoRetorno,
                        xMotivo = result.Motivo,
                        chave = result.ChaveAcesso,
                        protocolo = result.Protocolo,
                        httpStatusCode = result.HttpStatusCode,
                        entityId = saga.EntityId
                    }));
            }
            catch (Exception ex)
            {
                _logger.CommandFailed(
                    "Fiscal.MDFe.Encerramento.Sefaz.ErroTecnico",
                    step.CorrelationId,
                    ex,
                    0);

                _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                    _logger,
                    saga,
                    step,
                    "fiscal.mdfe.encerramento.resposta-sefaz",
                    new
                    {
                        origem = "Fiscal",
                        modo = "sefaz-mdfe-recepcao-evento",
                        encerrado = false,
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
            _logger.Info($"MDF-e {saga.EntityId}: resposta de encerramento SEFAZ registrada.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
