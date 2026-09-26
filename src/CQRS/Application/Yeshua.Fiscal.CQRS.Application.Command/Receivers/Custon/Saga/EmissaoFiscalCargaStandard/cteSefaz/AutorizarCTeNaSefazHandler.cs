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
using Repositorio.Outputs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Command.Receivers
{
    public partial class AutorizarCTeNaSefazHandler
    {
        private readonly ICTeRomaneioConsolidadoReadRepository _cteRomaneioConsolidadoReadRepository = default!;
        private readonly ICTeSolicitacaoFiscalReadRepository _cteSolicitacaoFiscalReadRepository = default!;
        private readonly ICTeSolicitacaoFiscalWriteRepository _cteSolicitacaoFiscalWriteRepository = default!;
        private readonly ICTeTentativaEmissaoReadRepository _cteTentativaEmissaoReadRepository = default!;
        private readonly ICTeTentativaEmissaoWriteRepository _cteTentativaEmissaoWriteRepository = default!;
        private readonly IyInboxWriteRepository _inboxWriteRepository = default!;
        private readonly IDocumentoFiscalWriteRepository _documentoFiscalWriteRepository = default!;
        private readonly IEntradaFiscalContingenciaReadRepository _entradaFiscalContingenciaReadRepository = default!;
        private readonly ICertificadoDigitalReadRepository _certificadoDigitalReadRepository = default!;
        private readonly ILogger _logger = default!;

        public AutorizarCTeNaSefazHandler(
            ICTeRomaneioConsolidadoReadRepository cteRomaneioConsolidadoReadRepository,
            ICTeSolicitacaoFiscalReadRepository cteSolicitacaoFiscalReadRepository,
            ICTeSolicitacaoFiscalWriteRepository cteSolicitacaoFiscalWriteRepository,
            ICTeTentativaEmissaoReadRepository cteTentativaEmissaoReadRepository,
            ICTeTentativaEmissaoWriteRepository cteTentativaEmissaoWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            IDocumentoFiscalWriteRepository documentoFiscalWriteRepository,
            IEntradaFiscalContingenciaReadRepository entradaFiscalContingenciaReadRepository,
            ICertificadoDigitalReadRepository certificadoDigitalReadRepository,
            ILogger logger)
        {
            _cteRomaneioConsolidadoReadRepository = cteRomaneioConsolidadoReadRepository;
            _cteSolicitacaoFiscalReadRepository = cteSolicitacaoFiscalReadRepository;
            _cteSolicitacaoFiscalWriteRepository = cteSolicitacaoFiscalWriteRepository;
            _cteTentativaEmissaoReadRepository = cteTentativaEmissaoReadRepository;
            _cteTentativaEmissaoWriteRepository = cteTentativaEmissaoWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _documentoFiscalWriteRepository = documentoFiscalWriteRepository;
            _entradaFiscalContingenciaReadRepository = entradaFiscalContingenciaReadRepository;
            _certificadoDigitalReadRepository = certificadoDigitalReadRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var romaneio = _cteRomaneioConsolidadoReadRepository.FirstByCargaId(cargaId);
            if (romaneio == null || romaneio.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: romaneio consolidado CT-e nao encontrado para autorizar CT-e.");

            var solicitacoes = (_cteSolicitacaoFiscalReadRepository.GetAllByRomaneioConsolidadoId(romaneio.id)
                    ?? Array.Empty<CTeSolicitacaoFiscalDTO>())
                .OrderBy(x => x.id)
                .ToList();

            if (solicitacoes.Count == 0)
                throw new InvalidOperationException($"Carga {cargaId}: solicitacoes fiscais CT-e nao encontradas para autorizar CT-e.");

            var autorizados = 0;
            var falhas = new List<string>();
            var possuiFalhaTecnica = false;
            var certificado = FiscalCertificateResolver.TryResolve(
                cargaId,
                _entradaFiscalContingenciaReadRepository,
                _certificadoDigitalReadRepository);
            foreach (var solicitacao in solicitacoes)
            {
                var tentativa = CarregarTentativaPreparada(cargaId, solicitacao);
                if (tentativa.status == 3)
                {
                    autorizados++;
                    continue;
                }

                try
                {
                    var prepared = CarregarXmlPreparado(tentativa);
                    if (certificado is not null)
                    {
                        var emitenteDocumento = tentativa.chaveacesso?.Length >= 20
                            ? tentativa.chaveacesso.Substring(6, 14)
                            : solicitacao.emitentedocumento;
                        FiscalCertificateResolver.ValidateIssuer(
                            certificado,
                            emitenteDocumento ?? string.Empty,
                            $"Solicitacao CT-e {solicitacao.id}");
                    }
                    var result = certificado is null
                        ? CteRecepcaoSincV4HomologacaoClient.Autorizar(prepared)
                        : CteRecepcaoSincV4HomologacaoClient.Autorizar(
                            prepared,
                            certificado.CertificatePath,
                            certificado.Password);
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

                    RegistrarResultadoTentativa(solicitacao, tentativa, result, respostaEstruturada);

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
                            cteSolicitacaoFiscalId = solicitacao.id,
                            entityId = saga.EntityId
                        }));

                    if (result.Autorizado)
                        autorizados++;
                    else
                        falhas.Add($"solicitacao={solicitacao.id}; cStat={result.CodigoRetorno}; xMotivo={result.Motivo}");
                }
                catch (Exception ex)
                {
                    possuiFalhaTecnica = true;
                    RegistrarFalhaTecnica(solicitacao, tentativa, ex);

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
                            chave = tentativa.chaveacesso,
                            protocolo = string.Empty,
                            httpStatusCode = 0,
                            cteSolicitacaoFiscalId = solicitacao.id,
                            exceptionType = ex.GetType().FullName,
                            entityId = saga.EntityId
                        }));

                    falhas.Add($"solicitacao={solicitacao.id}; erro={ex.Message}");
                }
            }

            if (falhas.Count > 0)
            {
                throw new SagaStepExecutionException(
                    $"Carga {cargaId}: {autorizados} de {solicitacoes.Count} CT-e autorizados. Falhas: {string.Join(" | ", falhas)}",
                    retryable: possuiFalhaTecnica);
            }

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.cte.lote-autorizado",
                new
                {
                    origem = "Fiscal",
                    quantidadeSolicitacoes = solicitacoes.Count,
                    quantidadeAutorizados = autorizados,
                    entityId = saga.EntityId
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: resposta CT-e SEFAZ homologacao registrada.");
        }

        private CTeTentativaEmissaoDTO CarregarTentativaPreparada(
            string cargaId,
            CTeSolicitacaoFiscalDTO solicitacao)
        {
            var tentativa = (_cteTentativaEmissaoReadRepository.GetAllByCTeSolicitacaoFiscalId(solicitacao.id)
                    ?? Array.Empty<CTeTentativaEmissaoDTO>())
                .OrderByDescending(x => x.id)
                .FirstOrDefault();

            if (tentativa == null || tentativa.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: tentativa CT-e preparada da solicitacao {solicitacao.id} nao encontrada.");

            return tentativa;
        }

        private static CteRecepcaoSincV4Prepared CarregarXmlPreparado(CTeTentativaEmissaoDTO tentativa)
        {
            if (string.IsNullOrWhiteSpace(tentativa.xmlassinadostoragekey))
                throw new InvalidOperationException($"Tentativa CT-e {tentativa.id}: XML assinado nao informado.");

            if (!File.Exists(tentativa.xmlassinadostoragekey))
                throw new FileNotFoundException("XML assinado do CT-e nao encontrado.", tentativa.xmlassinadostoragekey);

            var xml = File.ReadAllText(tentativa.xmlassinadostoragekey);
            return new CteRecepcaoSincV4Prepared(
                tentativa.chaveacesso,
                tentativa.numero,
                tentativa.serie,
                xml,
                tentativa.xmlhash);
        }

        private void RegistrarResultadoTentativa(
            CTeSolicitacaoFiscalDTO solicitacao,
            CTeTentativaEmissaoDTO tentativa,
            CteRecepcaoSincV4Result result,
            bool respostaEstruturada)
        {
            var statusTentativa = result.Autorizado ? 3 : respostaEstruturada ? 4 : 5;
            var statusSolicitacao = result.Autorizado ? 4 : respostaEstruturada ? 5 : 6;

            _cteTentativaEmissaoWriteRepository.UpdateEnviadoEmUtc(tentativa.id, DateTime.UtcNow);
            _cteTentativaEmissaoWriteRepository.UpdateCodigoRetorno(tentativa.id, result.CodigoRetorno.ToString());
            _cteTentativaEmissaoWriteRepository.UpdateMensagemRetorno(tentativa.id, Limitar(result.Motivo, 1000));
            _cteTentativaEmissaoWriteRepository.UpdateProtocoloAutorizacao(tentativa.id, result.Protocolo ?? string.Empty);
            _cteTentativaEmissaoWriteRepository.UpdateStatus(tentativa.id, statusTentativa);

            if (result.Autorizado)
                _cteTentativaEmissaoWriteRepository.UpdateAutorizadoEmUtc(tentativa.id, DateTime.UtcNow);

            _cteSolicitacaoFiscalWriteRepository.UpdateStatus(solicitacao.id, statusSolicitacao);
        }

        private void RegistrarFalhaTecnica(
            CTeSolicitacaoFiscalDTO? solicitacao,
            CTeTentativaEmissaoDTO? tentativa,
            Exception exception)
        {
            if (tentativa != null && tentativa.id > 0)
            {
                _cteTentativaEmissaoWriteRepository.UpdateMensagemRetorno(tentativa.id, Limitar(exception.Message, 1000));
                _cteTentativaEmissaoWriteRepository.UpdateStatus(tentativa.id, 5);
            }

            if (solicitacao != null && solicitacao.id > 0)
                _cteSolicitacaoFiscalWriteRepository.UpdateStatus(solicitacao.id, 6);
        }

        private static string Limitar(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= maxLength)
                return value ?? string.Empty;

            return value.Substring(0, maxLength);
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
