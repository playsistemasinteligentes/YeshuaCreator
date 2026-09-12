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

namespace Command.Receivers
{
    public partial class PrepararCTeHandler
    {
        private readonly ICTeRomaneioConsolidadoReadRepository _cteRomaneioConsolidadoReadRepository = default!;
        private readonly ICTeSolicitacaoFiscalReadRepository _cteSolicitacaoFiscalReadRepository = default!;
        private readonly ICTeSolicitacaoFiscalWriteRepository _cteSolicitacaoFiscalWriteRepository = default!;
        private readonly ICTeTentativaEmissaoReadRepository _cteTentativaEmissaoReadRepository = default!;
        private readonly ICTeTentativaEmissaoWriteRepository _cteTentativaEmissaoWriteRepository = default!;
        private readonly IyInboxWriteRepository _inboxWriteRepository = default!;
        private readonly ILogger _logger = default!;

        public PrepararCTeHandler(
            ICTeRomaneioConsolidadoReadRepository cteRomaneioConsolidadoReadRepository,
            ICTeSolicitacaoFiscalReadRepository cteSolicitacaoFiscalReadRepository,
            ICTeSolicitacaoFiscalWriteRepository cteSolicitacaoFiscalWriteRepository,
            ICTeTentativaEmissaoReadRepository cteTentativaEmissaoReadRepository,
            ICTeTentativaEmissaoWriteRepository cteTentativaEmissaoWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _cteRomaneioConsolidadoReadRepository = cteRomaneioConsolidadoReadRepository;
            _cteSolicitacaoFiscalReadRepository = cteSolicitacaoFiscalReadRepository;
            _cteSolicitacaoFiscalWriteRepository = cteSolicitacaoFiscalWriteRepository;
            _cteTentativaEmissaoReadRepository = cteTentativaEmissaoReadRepository;
            _cteTentativaEmissaoWriteRepository = cteTentativaEmissaoWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var romaneio = _cteRomaneioConsolidadoReadRepository.FirstByCargaId(cargaId);
            if (romaneio == null || romaneio.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: romaneio consolidado CT-e nao encontrado para preparar CT-e.");

            var solicitacao = _cteSolicitacaoFiscalReadRepository.FirstByRomaneioConsolidadoId(romaneio.id);
            if (solicitacao == null || solicitacao.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: solicitacao fiscal CT-e nao encontrada para preparar CT-e.");

            var tentativa = _cteTentativaEmissaoReadRepository.FirstByCTeSolicitacaoFiscalId(solicitacao.id);
            var tentativaId = tentativa?.id ?? 0;
            var storageKey = tentativa?.xmlassinadostoragekey ?? string.Empty;
            var xmlHash = tentativa?.xmlhash ?? string.Empty;
            var chave = tentativa?.chaveacesso ?? string.Empty;
            var numero = tentativa?.numero ?? 0;
            var serie = tentativa?.serie ?? 0;

            if (tentativaId <= 0)
            {
                var prepared = CteRecepcaoSincV4HomologacaoClient.Preparar();
                var storage = SefazFiscalDocumentStore.SalvarXmlResposta("cte", "preparacao", prepared.Chave, prepared.XmlCte);

                var entity = new CTeTentativaEmissaoFactory(_logger).Create(
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

                _cteTentativaEmissaoWriteRepository.Insert(entity);
                if (!entity.Id.HasValue || entity.Id.Value <= 0)
                    throw new InvalidOperationException($"Carga {cargaId}: tentativa CT-e nao recebeu Id apos insert.");

                tentativaId = entity.Id.Value;
                storageKey = storage.Path;
                xmlHash = storage.Sha256;
                chave = prepared.Chave;
                numero = prepared.Numero ?? 0;
                serie = prepared.Serie ?? 0;
            }

            if (solicitacao.status < 3)
                _cteSolicitacaoFiscalWriteRepository.UpdateStatus(solicitacao.id, 3);

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.cte.preparado",
                new
                {
                    origem = "Fiscal",
                    modo = "xml-cte-assinado-preparado",
                    entityId = saga.EntityId,
                    cteSolicitacaoFiscalId = solicitacao.id,
                    cteTentativaEmissaoId = tentativaId,
                    chave,
                    numero,
                    serie,
                    xmlAssinadoStorageKey = storageKey,
                    xmlHash
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: CT-e preparado.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
