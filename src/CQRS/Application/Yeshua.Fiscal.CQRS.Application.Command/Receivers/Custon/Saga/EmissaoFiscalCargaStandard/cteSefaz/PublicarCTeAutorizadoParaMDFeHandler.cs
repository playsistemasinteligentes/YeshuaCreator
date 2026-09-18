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
using System.Collections.Generic;
using System.Linq;

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

            var solicitacoes = (_cteSolicitacaoFiscalReadRepository.GetAllByRomaneioConsolidadoId(romaneio.id)
                    ?? Array.Empty<Repositorio.Outputs.CTeSolicitacaoFiscalDTO>())
                .OrderBy(x => x.id)
                .ToList();

            if (solicitacoes.Count == 0)
                throw new InvalidOperationException($"Carga {cargaId}: solicitacoes fiscais CT-e nao encontradas para publicar ao MDF-e.");

            var saidas = new List<int>(solicitacoes.Count);
            foreach (var solicitacao in solicitacoes)
            {
                var tentativa = (_cteTentativaEmissaoReadRepository.GetAllByCTeSolicitacaoFiscalId(solicitacao.id)
                        ?? Array.Empty<Repositorio.Outputs.CTeTentativaEmissaoDTO>())
                    .OrderByDescending(x => x.id)
                    .FirstOrDefault();

                if (tentativa == null || tentativa.id <= 0)
                    throw new InvalidOperationException($"Carga {cargaId}: tentativa CT-e da solicitacao {solicitacao.id} nao encontrada para publicar ao MDF-e.");

                if (tentativa.status != 3)
                    throw new InvalidOperationException($"Carga {cargaId}: CT-e da solicitacao {solicitacao.id} ainda nao autorizado para MDF-e. StatusTentativa={tentativa.status}; cStat={tentativa.codigoretorno}; xMotivo={tentativa.mensagemretorno}");

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

                saidas.Add(saidaId);
            }

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.cte.publicado-para-mdfe",
                new
                {
                    origem = "Fiscal",
                    modo = "ctes-autorizados-disponiveis-para-mdfe",
                    entityId = saga.EntityId,
                    quantidadeCTes = solicitacoes.Count,
                    quantidadeSaidasMDFe = saidas.Count
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: CT-e autorizado disponibilizado para MDF-e.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
