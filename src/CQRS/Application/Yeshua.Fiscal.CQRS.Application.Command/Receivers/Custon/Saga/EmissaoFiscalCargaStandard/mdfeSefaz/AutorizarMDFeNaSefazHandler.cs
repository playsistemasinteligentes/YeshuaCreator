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
using System.IO;
using System.Linq;

namespace Command.Receivers
{
    public partial class AutorizarMDFeNaSefazHandler
    {
        private readonly IMDFeSolicitacaoFiscalReadRepository _mdfeSolicitacaoFiscalReadRepository;
        private readonly IMDFeSolicitacaoFiscalWriteRepository _mdfeSolicitacaoFiscalWriteRepository;
        private readonly IMDFeDocumentoOriginarioReadRepository _mdfeDocumentoOriginarioReadRepository;
        private readonly IMDFeTentativaEmissaoReadRepository _mdfeTentativaEmissaoReadRepository;
        private readonly IMDFeTentativaEmissaoWriteRepository _mdfeTentativaEmissaoWriteRepository;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly IDocumentoFiscalWriteRepository _documentoFiscalWriteRepository;
        private readonly ILogger _logger;

        public AutorizarMDFeNaSefazHandler(
            IMDFeSolicitacaoFiscalReadRepository mdfeSolicitacaoFiscalReadRepository,
            IMDFeSolicitacaoFiscalWriteRepository mdfeSolicitacaoFiscalWriteRepository,
            IMDFeDocumentoOriginarioReadRepository mdfeDocumentoOriginarioReadRepository,
            IMDFeTentativaEmissaoReadRepository mdfeTentativaEmissaoReadRepository,
            IMDFeTentativaEmissaoWriteRepository mdfeTentativaEmissaoWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            IDocumentoFiscalWriteRepository documentoFiscalWriteRepository,
            ILogger logger)
        {
            _mdfeSolicitacaoFiscalReadRepository = mdfeSolicitacaoFiscalReadRepository;
            _mdfeSolicitacaoFiscalWriteRepository = mdfeSolicitacaoFiscalWriteRepository;
            _mdfeDocumentoOriginarioReadRepository = mdfeDocumentoOriginarioReadRepository;
            _mdfeTentativaEmissaoReadRepository = mdfeTentativaEmissaoReadRepository;
            _mdfeTentativaEmissaoWriteRepository = mdfeTentativaEmissaoWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _documentoFiscalWriteRepository = documentoFiscalWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            MDFeSolicitacaoFiscalDTO? solicitacao = null;
            MDFeTentativaEmissaoDTO? tentativa = null;
            MDFeDocumentoOriginarioDTO? documentoOriginario = null;

            try
            {
                (solicitacao, tentativa, documentoOriginario) = CarregarTentativaPreparada(saga);
                var prepared = CarregarXmlPreparado(tentativa, documentoOriginario);
                var result = MdfeRecepcaoSincHomologacaoClient.Autorizar(prepared);
                var respostaEstruturada = result.CodigoRetorno > 0 && !string.IsNullOrWhiteSpace(result.Motivo);

                if (!respostaEstruturada)
                {
                    var exception = new InvalidOperationException(
                        $"SEFAZ MDF-e nao retornou resposta fiscal estruturada. HTTP={result.HttpStatusCode}; chave={result.Chave}");

                    _logger.CommandFailed(
                        "Fiscal.MDFe.AutorizarMDFeNaSefaz.SemRespostaFiscalEstruturada",
                        step.CorrelationId,
                        exception,
                        0);
                }

                if (respostaEstruturada && !result.Autorizado)
                {
                    var rejection = new InvalidOperationException(
                        $"SEFAZ MDF-e rejeitou em homologacao. cStat={result.CodigoRetorno}; xMotivo={result.Motivo}; chave={result.Chave}");

                    _logger.CommandFailed(
                        "Fiscal.MDFe.AutorizarMDFeNaSefaz.RejeicaoFiscal",
                        step.CorrelationId,
                        rejection,
                        0);
                }

                RegistrarResultadoTentativa(solicitacao, tentativa, result, respostaEstruturada);

                SefazFiscalDocumentStore.PersistirMDFe(
                    _documentoFiscalWriteRepository,
                    _logger,
                    saga,
                    step,
                    result);

                _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                    _logger,
                    saga,
                    step,
                    "fiscal.mdfe.resposta-sefaz-homologacao",
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
                        chaveCTe = documentoOriginario.chaveacesso,
                        protocolo = result.Protocolo,
                        httpStatusCode = result.HttpStatusCode,
                        entityId = saga.EntityId
                    }));
            }
            catch (Exception ex)
            {
                RegistrarFalhaTecnica(solicitacao, tentativa, ex);

                _logger.CommandFailed(
                    "Fiscal.MDFe.AutorizarMDFeNaSefaz.ErroTecnico",
                    step.CorrelationId,
                    ex,
                    0);

                _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                    _logger,
                    saga,
                    step,
                    "fiscal.mdfe.resposta-sefaz-homologacao",
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
                        chave = tentativa?.chaveacesso ?? string.Empty,
                        chaveCTe = documentoOriginario?.chaveacesso ?? string.Empty,
                        protocolo = string.Empty,
                        httpStatusCode = 0,
                        exceptionType = ex.GetType().FullName,
                        entityId = saga.EntityId
                    }));
            }
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: resposta MDF-e SEFAZ homologacao registrada.");
        }

        private (MDFeSolicitacaoFiscalDTO Solicitacao, MDFeTentativaEmissaoDTO Tentativa, MDFeDocumentoOriginarioDTO DocumentoOriginario)
            CarregarTentativaPreparada(SagaBase saga)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var solicitacao = _mdfeSolicitacaoFiscalReadRepository.FirstByCargaId(cargaId);
            if (solicitacao == null || solicitacao.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: solicitacao fiscal MDF-e nao encontrada para autorizar MDF-e.");

            var documentoOriginario = _mdfeDocumentoOriginarioReadRepository
                .GetAllByMDFeSolicitacaoFiscalId(solicitacao.id)
                .FirstOrDefault(x => string.Equals(x.tipodocumento, "CTe", StringComparison.OrdinalIgnoreCase));

            if (documentoOriginario == null || documentoOriginario.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: CT-e originario nao encontrado para autorizar MDF-e.");

            var tentativa = _mdfeTentativaEmissaoReadRepository.FirstByMDFeSolicitacaoFiscalId(solicitacao.id);
            if (tentativa == null || tentativa.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: tentativa MDF-e preparada nao encontrada para autorizar MDF-e.");

            return (solicitacao, tentativa, documentoOriginario);
        }

        private static MdfeRecepcaoSincPrepared CarregarXmlPreparado(
            MDFeTentativaEmissaoDTO tentativa,
            MDFeDocumentoOriginarioDTO documentoOriginario)
        {
            if (string.IsNullOrWhiteSpace(tentativa.xmlassinadostoragekey))
                throw new InvalidOperationException($"Tentativa MDF-e {tentativa.id}: XML assinado nao informado.");

            if (!File.Exists(tentativa.xmlassinadostoragekey))
                throw new FileNotFoundException("XML assinado do MDF-e nao encontrado.", tentativa.xmlassinadostoragekey);

            var xml = File.ReadAllText(tentativa.xmlassinadostoragekey);
            return new MdfeRecepcaoSincPrepared(
                tentativa.chaveacesso,
                tentativa.numero,
                tentativa.serie,
                documentoOriginario.chaveacesso,
                xml,
                tentativa.xmlhash);
        }

        private void RegistrarResultadoTentativa(
            MDFeSolicitacaoFiscalDTO solicitacao,
            MDFeTentativaEmissaoDTO tentativa,
            MdfeRecepcaoSincResult result,
            bool respostaEstruturada)
        {
            var statusTentativa = result.Autorizado ? 3 : respostaEstruturada ? 4 : 5;
            var statusSolicitacao = result.Autorizado ? 3 : respostaEstruturada ? 4 : 5;

            _mdfeTentativaEmissaoWriteRepository.UpdateEnviadoEmUtc(tentativa.id, DateTime.UtcNow);
            _mdfeTentativaEmissaoWriteRepository.UpdateCodigoRetorno(tentativa.id, result.CodigoRetorno.ToString());
            _mdfeTentativaEmissaoWriteRepository.UpdateMensagemRetorno(tentativa.id, Limitar(result.Motivo, 1000));
            _mdfeTentativaEmissaoWriteRepository.UpdateProtocoloAutorizacao(tentativa.id, result.Protocolo ?? string.Empty);
            _mdfeTentativaEmissaoWriteRepository.UpdateStatus(tentativa.id, statusTentativa);

            if (result.Autorizado)
                _mdfeTentativaEmissaoWriteRepository.UpdateAutorizadoEmUtc(tentativa.id, DateTime.UtcNow);

            _mdfeSolicitacaoFiscalWriteRepository.UpdateStatus(solicitacao.id, statusSolicitacao);
        }

        private void RegistrarFalhaTecnica(
            MDFeSolicitacaoFiscalDTO? solicitacao,
            MDFeTentativaEmissaoDTO? tentativa,
            Exception exception)
        {
            if (tentativa != null && tentativa.id > 0)
            {
                _mdfeTentativaEmissaoWriteRepository.UpdateMensagemRetorno(tentativa.id, Limitar(exception.Message, 1000));
                _mdfeTentativaEmissaoWriteRepository.UpdateStatus(tentativa.id, 5);
            }

            if (solicitacao != null && solicitacao.id > 0)
                _mdfeSolicitacaoFiscalWriteRepository.UpdateStatus(solicitacao.id, 5);
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
