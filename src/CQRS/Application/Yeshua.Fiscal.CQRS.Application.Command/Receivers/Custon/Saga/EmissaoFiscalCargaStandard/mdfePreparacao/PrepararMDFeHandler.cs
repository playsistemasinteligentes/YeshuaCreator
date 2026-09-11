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
using IRepository.Read;
using IRepository.Write;
using System;
using System.Linq;

namespace Command.Receivers
{
    public partial class PrepararMDFeHandler
    {
        private readonly IMDFeSolicitacaoFiscalReadRepository _mdfeSolicitacaoFiscalReadRepository;
        private readonly IMDFeSolicitacaoFiscalWriteRepository _mdfeSolicitacaoFiscalWriteRepository;
        private readonly IMDFeDocumentoOriginarioReadRepository _mdfeDocumentoOriginarioReadRepository;
        private readonly IMDFeTentativaEmissaoReadRepository _mdfeTentativaEmissaoReadRepository;
        private readonly IMDFeTentativaEmissaoWriteRepository _mdfeTentativaEmissaoWriteRepository;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public PrepararMDFeHandler(
            IMDFeSolicitacaoFiscalReadRepository mdfeSolicitacaoFiscalReadRepository,
            IMDFeSolicitacaoFiscalWriteRepository mdfeSolicitacaoFiscalWriteRepository,
            IMDFeDocumentoOriginarioReadRepository mdfeDocumentoOriginarioReadRepository,
            IMDFeTentativaEmissaoReadRepository mdfeTentativaEmissaoReadRepository,
            IMDFeTentativaEmissaoWriteRepository mdfeTentativaEmissaoWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _mdfeSolicitacaoFiscalReadRepository = mdfeSolicitacaoFiscalReadRepository;
            _mdfeSolicitacaoFiscalWriteRepository = mdfeSolicitacaoFiscalWriteRepository;
            _mdfeDocumentoOriginarioReadRepository = mdfeDocumentoOriginarioReadRepository;
            _mdfeTentativaEmissaoReadRepository = mdfeTentativaEmissaoReadRepository;
            _mdfeTentativaEmissaoWriteRepository = mdfeTentativaEmissaoWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var solicitacao = _mdfeSolicitacaoFiscalReadRepository.FirstByCargaId(cargaId);
            if (solicitacao == null || solicitacao.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: solicitacao fiscal MDF-e nao encontrada para preparar MDF-e.");

            var documento = _mdfeDocumentoOriginarioReadRepository
                .GetAllByMDFeSolicitacaoFiscalId(solicitacao.id)
                .FirstOrDefault(x => string.Equals(x.tipodocumento, "CTe", StringComparison.OrdinalIgnoreCase));

            if (documento == null || documento.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: documento CT-e originario nao encontrado para preparar MDF-e.");

            var chaveCTe = OnlyDigits(documento.chaveacesso ?? string.Empty);
            if (chaveCTe.Length != 44)
                throw new InvalidOperationException($"Carga {cargaId}: chave CT-e originaria invalida para MDF-e.");

            var tentativa = _mdfeTentativaEmissaoReadRepository.FirstByMDFeSolicitacaoFiscalId(solicitacao.id);
            var tentativaId = tentativa?.id ?? 0;
            var storageKey = tentativa?.xmlassinadostoragekey ?? string.Empty;
            var xmlHash = tentativa?.xmlhash ?? string.Empty;
            var chave = tentativa?.chaveacesso ?? string.Empty;
            var numero = tentativa?.numero ?? 0;
            var serie = tentativa?.serie ?? 0;

            if (tentativaId <= 0)
            {
                var prepared = MdfeRecepcaoSincHomologacaoClient.Preparar(chaveCTe);
                var storage = SefazFiscalDocumentStore.SalvarXmlResposta("mdfe", "preparacao", prepared.Chave, prepared.XmlMDFe);

                var entity = new MDFeTentativaEmissaoFactory(_logger).Create(
                    null,
                    solicitacao.id,
                    prepared.Chave,
                    prepared.Numero,
                    prepared.Serie,
                    1,
                    storage.Path,
                    string.Empty,
                    storage.Sha256,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    null,
                    null,
                    1);

                _mdfeTentativaEmissaoWriteRepository.Insert(entity);
                if (!entity.Id.HasValue || entity.Id.Value <= 0)
                    throw new InvalidOperationException($"Carga {cargaId}: tentativa MDF-e nao recebeu Id apos insert.");

                tentativaId = entity.Id.Value;
                storageKey = storage.Path;
                xmlHash = storage.Sha256;
                chave = prepared.Chave;
                numero = prepared.Numero ?? 0;
                serie = prepared.Serie ?? 0;
            }

            if (solicitacao.status < 2)
                _mdfeSolicitacaoFiscalWriteRepository.UpdateStatus(solicitacao.id, 2);

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.mdfe.preparado",
                new
                {
                    origem = "Fiscal",
                    modo = "xml-mdfe-assinado-preparado",
                    entityId = saga.EntityId,
                    mdfeSolicitacaoFiscalId = solicitacao.id,
                    mdfeTentativaEmissaoId = tentativaId,
                    chave,
                    numero,
                    serie,
                    chaveCTe,
                    xmlAssinadoStorageKey = storageKey,
                    xmlHash
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: MDF-e preparado.");
        }

        private static string OnlyDigits(string value)
        {
            var buffer = new char[value.Length];
            var count = 0;

            foreach (var character in value)
            {
                if (character is >= '0' and <= '9')
                    buffer[count++] = character;
            }

            return new string(buffer, 0, count);
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
