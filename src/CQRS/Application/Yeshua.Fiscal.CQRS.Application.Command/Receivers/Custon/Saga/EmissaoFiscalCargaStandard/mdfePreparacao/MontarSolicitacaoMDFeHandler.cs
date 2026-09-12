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
using System.Text.Json;

namespace Command.Receivers
{
    public partial class MontarSolicitacaoMDFeHandler
    {
        private readonly ICTeSaidaMDFeReadRepository _cteSaidaMDFeReadRepository = default!;
        private readonly ICTeRomaneioConsolidadoReadRepository _cteRomaneioConsolidadoReadRepository = default!;
        private readonly IMDFeSolicitacaoFiscalReadRepository _mdfeSolicitacaoFiscalReadRepository = default!;
        private readonly IMDFeSolicitacaoFiscalWriteRepository _mdfeSolicitacaoFiscalWriteRepository = default!;
        private readonly IMDFeDocumentoOriginarioReadRepository _mdfeDocumentoOriginarioReadRepository = default!;
        private readonly IMDFeDocumentoOriginarioWriteRepository _mdfeDocumentoOriginarioWriteRepository = default!;
        private readonly IyInboxWriteRepository _inboxWriteRepository = default!;
        private readonly ILogger _logger = default!;

        public MontarSolicitacaoMDFeHandler(
            ICTeSaidaMDFeReadRepository cteSaidaMDFeReadRepository,
            ICTeRomaneioConsolidadoReadRepository cteRomaneioConsolidadoReadRepository,
            IMDFeSolicitacaoFiscalReadRepository mdfeSolicitacaoFiscalReadRepository,
            IMDFeSolicitacaoFiscalWriteRepository mdfeSolicitacaoFiscalWriteRepository,
            IMDFeDocumentoOriginarioReadRepository mdfeDocumentoOriginarioReadRepository,
            IMDFeDocumentoOriginarioWriteRepository mdfeDocumentoOriginarioWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _cteSaidaMDFeReadRepository = cteSaidaMDFeReadRepository;
            _cteRomaneioConsolidadoReadRepository = cteRomaneioConsolidadoReadRepository;
            _mdfeSolicitacaoFiscalReadRepository = mdfeSolicitacaoFiscalReadRepository;
            _mdfeSolicitacaoFiscalWriteRepository = mdfeSolicitacaoFiscalWriteRepository;
            _mdfeDocumentoOriginarioReadRepository = mdfeDocumentoOriginarioReadRepository;
            _mdfeDocumentoOriginarioWriteRepository = mdfeDocumentoOriginarioWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var romaneio = _cteRomaneioConsolidadoReadRepository.FirstByCargaId(cargaId);
            if (romaneio == null || romaneio.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: romaneio CT-e nao encontrado para montar MDF-e.");

            var saidaCte = _cteSaidaMDFeReadRepository.FirstByCorrelationId(saga.CorrelationId.ToString());
            if (saidaCte == null || saidaCte.id <= 0 || saidaCte.status > 2)
                throw new InvalidOperationException($"Carga {cargaId}: CT-e autorizado nao encontrado para montar MDF-e.");

            var options = MdfeRecepcaoSincOptions.FromEnvironment();
            var solicitacaoId = GarantirSolicitacao(saga, romaneio, saidaCte, options);
            GarantirDocumentoOriginario(solicitacaoId, saidaCte);

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.mdfe.solicitacao-montada",
                new
                {
                    origem = "Fiscal",
                    modo = "solicitacao-mdfe-montada",
                    entityId = saga.EntityId,
                    mdfeSolicitacaoFiscalId = solicitacaoId,
                    chaveCTe = saidaCte.chaveacessocte
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: solicitacao de MDF-e montada.");
        }

        private int GarantirSolicitacao(
            SagaBase saga,
            Repositorio.Outputs.CTeRomaneioConsolidadoDTO romaneio,
            Repositorio.Outputs.CTeSaidaMDFeDTO saidaCte,
            MdfeRecepcaoSincOptions options)
        {
            var existente = _mdfeSolicitacaoFiscalReadRepository.FirstByCargaId(romaneio.cargaid);
            if (existente != null && existente.id > 0)
                return existente.id;

            var documentos = JsonSerializer.Serialize(new[]
            {
                new
                {
                    tipo = "CTe",
                    chave = saidaCte.chaveacessocte,
                    snapshotHash = saidaCte.snapshothash
                }
            });

            var transporte = JsonSerializer.Serialize(new
            {
                options.Placa,
                condutorDocumento = options.CondutorCpf,
                condutorNome = options.CondutorNome,
                options.Rntrc,
                options.Renavam,
                options.TaraKg,
                options.CapacidadeKg,
                options.CapacidadeM3,
                options.TipoRodado,
                options.TipoCarroceria
            });

            var solicitacao = new MDFeSolicitacaoFiscalFactory(_logger).Create(
                null,
                saga.CorrelationId.ToString(),
                romaneio.cargaid,
                2,
                romaneio.ufinicio,
                romaneio.uffim,
                options.Placa,
                options.CondutorCpf,
                documentos,
                transporte,
                1);

            _mdfeSolicitacaoFiscalWriteRepository.Insert(solicitacao);
            if (!solicitacao.Id.HasValue || solicitacao.Id.Value <= 0)
                throw new InvalidOperationException($"Carga {romaneio.cargaid}: solicitacao MDF-e nao recebeu Id apos insert.");

            return solicitacao.Id.Value;
        }

        private void GarantirDocumentoOriginario(int mdfeSolicitacaoFiscalId, Repositorio.Outputs.CTeSaidaMDFeDTO saidaCte)
        {
            var existente = _mdfeDocumentoOriginarioReadRepository.FirstByChaveAcesso(saidaCte.chaveacessocte);
            if (existente != null && existente.id > 0)
                return;

            var documento = new MDFeDocumentoOriginarioFactory(_logger).Create(
                null,
                mdfeSolicitacaoFiscalId,
                null,
                "CTe",
                saidaCte.chaveacessocte,
                JsonSerializer.Serialize(new
                {
                    saidaCte.id,
                    saidaCte.ctetentativaemissaoid,
                    saidaCte.correlationid,
                    saidaCte.chaveacessocte,
                    saidaCte.snapshothash
                }));

            _mdfeDocumentoOriginarioWriteRepository.Insert(documento);
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
