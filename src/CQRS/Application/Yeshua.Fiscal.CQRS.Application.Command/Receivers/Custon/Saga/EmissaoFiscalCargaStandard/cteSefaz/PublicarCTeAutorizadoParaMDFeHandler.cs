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
    public partial class PublicarCTeAutorizadoParaMDFeHandler
    {
        private readonly ICTeRomaneioConsolidadoReadRepository _cteRomaneioConsolidadoReadRepository = default!;
        private readonly ICTeSolicitacaoFiscalReadRepository _cteSolicitacaoFiscalReadRepository = default!;
        private readonly ICTeTentativaEmissaoReadRepository _cteTentativaEmissaoReadRepository = default!;
        private readonly ICTeSaidaMDFeReadRepository _cteSaidaMDFeReadRepository = default!;
        private readonly ICTeSaidaMDFeWriteRepository _cteSaidaMDFeWriteRepository = default!;
        private readonly IyInboxWriteRepository _inboxWriteRepository = default!;
        private readonly ILogger _logger = default!;

        public PublicarCTeAutorizadoParaMDFeHandler(
            ICTeRomaneioConsolidadoReadRepository cteRomaneioConsolidadoReadRepository,
            ICTeSolicitacaoFiscalReadRepository cteSolicitacaoFiscalReadRepository,
            ICTeTentativaEmissaoReadRepository cteTentativaEmissaoReadRepository,
            ICTeSaidaMDFeReadRepository cteSaidaMDFeReadRepository,
            ICTeSaidaMDFeWriteRepository cteSaidaMDFeWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _cteRomaneioConsolidadoReadRepository = cteRomaneioConsolidadoReadRepository;
            _cteSolicitacaoFiscalReadRepository = cteSolicitacaoFiscalReadRepository;
            _cteTentativaEmissaoReadRepository = cteTentativaEmissaoReadRepository;
            _cteSaidaMDFeReadRepository = cteSaidaMDFeReadRepository;
            _cteSaidaMDFeWriteRepository = cteSaidaMDFeWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var romaneio = _cteRomaneioConsolidadoReadRepository.FirstByCargaId(cargaId);
            if (romaneio == null || romaneio.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: romaneio consolidado CT-e nao encontrado para publicar ao MDF-e.");

            var solicitacao = _cteSolicitacaoFiscalReadRepository.FirstByRomaneioConsolidadoId(romaneio.id);
            if (solicitacao == null || solicitacao.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: solicitacao fiscal CT-e nao encontrada para publicar ao MDF-e.");

            var tentativa = _cteTentativaEmissaoReadRepository.FirstByCTeSolicitacaoFiscalId(solicitacao.id);
            if (tentativa == null || tentativa.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: tentativa CT-e nao encontrada para publicar ao MDF-e.");

            if (tentativa.status != 3)
                throw new InvalidOperationException($"Carga {cargaId}: CT-e ainda nao autorizado para MDF-e. StatusTentativa={tentativa.status}; cStat={tentativa.codigoretorno}; xMotivo={tentativa.mensagemretorno}");

            var saida = _cteSaidaMDFeReadRepository.FirstByCTeTentativaEmissaoId(tentativa.id);
            var saidaId = saida?.id ?? 0;
            if (saidaId <= 0)
            {
                var entity = new CTeSaidaMDFeFactory(_logger).Create(
                    null,
                    tentativa.id,
                    saga.CorrelationId.ToString(),
                    tentativa.chaveacesso,
                    tentativa.xmlhash,
                    string.Empty,
                    DateTime.UtcNow,
                    string.Empty,
                    1);

                _cteSaidaMDFeWriteRepository.Insert(entity);
                if (!entity.Id.HasValue || entity.Id.Value <= 0)
                    throw new InvalidOperationException($"Carga {cargaId}: saida CT-e para MDF-e nao recebeu Id apos insert.");

                saidaId = entity.Id.Value;
            }

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.cte.publicado-para-mdfe",
                new
                {
                    origem = "Fiscal",
                    modo = "cte-autorizado-disponivel-para-mdfe",
                    entityId = saga.EntityId,
                    cteSolicitacaoFiscalId = solicitacao.id,
                    cteTentativaEmissaoId = tentativa.id,
                    cteSaidaMDFeId = saidaId,
                    chave = tentativa.chaveacesso,
                    protocolo = tentativa.protocoloautorizacao,
                    xmlHash = tentativa.xmlhash
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: CT-e autorizado disponibilizado para MDF-e.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
