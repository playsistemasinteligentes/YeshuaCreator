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
using Repositorio.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class ReceberCTeComplementarProntoParaEmissaoHandler
    {
        private readonly ICTeEntradaOficialReadRepository _entradaReadRepository;
        private readonly ICTeEntradaOficialWriteRepository _entradaWriteRepository;
        private readonly ICTeRomaneioConsolidadoReadRepository _romaneioReadRepository;
        private readonly ICTeRomaneioConsolidadoWriteRepository _romaneioWriteRepository;
        private readonly ICTeSolicitacaoFiscalReadRepository _solicitacaoReadRepository;
        private readonly ICTeSolicitacaoFiscalWriteRepository _solicitacaoWriteRepository;
        private readonly ICTeDocumentoOriginarioReadRepository _documentoReadRepository;
        private readonly ICTeDocumentoOriginarioWriteRepository _documentoWriteRepository;
        private readonly ICTeParticipanteSnapshotReadRepository _participanteReadRepository;
        private readonly ICTeParticipanteSnapshotWriteRepository _participanteWriteRepository;
        private readonly ICTeComplementoIcmsFiscalReadRepository _complementoReadRepository;
        private readonly ICTeComplementoIcmsFiscalWriteRepository _complementoWriteRepository;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public ReceberCTeComplementarProntoParaEmissaoHandler(
            ICTeEntradaOficialReadRepository entradaReadRepository,
            ICTeEntradaOficialWriteRepository entradaWriteRepository,
            ICTeRomaneioConsolidadoReadRepository romaneioReadRepository,
            ICTeRomaneioConsolidadoWriteRepository romaneioWriteRepository,
            ICTeSolicitacaoFiscalReadRepository solicitacaoReadRepository,
            ICTeSolicitacaoFiscalWriteRepository solicitacaoWriteRepository,
            ICTeDocumentoOriginarioReadRepository documentoReadRepository,
            ICTeDocumentoOriginarioWriteRepository documentoWriteRepository,
            ICTeParticipanteSnapshotReadRepository participanteReadRepository,
            ICTeParticipanteSnapshotWriteRepository participanteWriteRepository,
            ICTeComplementoIcmsFiscalReadRepository complementoReadRepository,
            ICTeComplementoIcmsFiscalWriteRepository complementoWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _entradaReadRepository = entradaReadRepository;
            _entradaWriteRepository = entradaWriteRepository;
            _romaneioReadRepository = romaneioReadRepository;
            _romaneioWriteRepository = romaneioWriteRepository;
            _solicitacaoReadRepository = solicitacaoReadRepository;
            _solicitacaoWriteRepository = solicitacaoWriteRepository;
            _documentoReadRepository = documentoReadRepository;
            _documentoWriteRepository = documentoWriteRepository;
            _participanteReadRepository = participanteReadRepository;
            _participanteWriteRepository = participanteWriteRepository;
            _complementoReadRepository = complementoReadRepository;
            _complementoWriteRepository = complementoWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var plan = CTeComplementarPlan.From(saga, step);
            var entradaId = EnsureEntrada(saga, plan);
            var romaneioId = EnsureRomaneio(saga, plan, entradaId);
            var solicitacaoId = EnsureSolicitacao(saga, plan, entradaId, romaneioId);

            EnsureDocumentos(plan, solicitacaoId);
            EnsureParticipantes(plan, solicitacaoId);
            EnsureComplemento(plan, solicitacaoId);

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.cte-complementar.entrada-recebida",
                new
                {
                    origem = "Fiscal",
                    cargaId = plan.CargaId,
                    cteSolicitacaoFiscalId = solicitacaoId,
                    quantidadeCTeOriginais = plan.ChavesCTeOriginais.Count,
                    plan.ValorPrestacaoComplementar,
                    plan.ValorIcms
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: entrada do CT-e complementar recebida.");
        }

        private int EnsureEntrada(SagaBase saga, CTeComplementarPlan plan)
        {
            var correlationId = saga.CorrelationId.ToString();
            var current = _entradaReadRepository.FirstByCorrelationId(correlationId);
            if (current is not null && current.id > 0)
                return current.id;

            var entity = new CTeEntradaOficialFactory(_logger).Create(
                null,
                correlationId,
                plan.SourceApplication,
                plan.SourceModule,
                plan.SourceMessageId,
                "CTeComplementarProntoParaEmissaoFiscal.v1",
                "1",
                DateTime.UtcNow,
                plan.PayloadHash,
                plan.PayloadStorageKey,
                2);

            _entradaWriteRepository.Insert(entity);
            return entity.Id ?? throw new InvalidOperationException($"Carga {plan.CargaId}: entrada oficial do CT-e complementar nao recebeu Id.");
        }

        private int EnsureRomaneio(SagaBase saga, CTeComplementarPlan plan, int entradaId)
        {
            var current = _romaneioReadRepository.FirstByCorrelationId(saga.CorrelationId.ToString());
            if (current is not null && current.id > 0)
                return current.id;

            var route = JsonSerializer.Serialize(new
            {
                ufInicio = plan.UfInicio,
                ufFim = plan.UfFim,
                municipioInicioCodigoIbge = plan.MunicipioInicioCodigoIbge,
                municipioFimCodigoIbge = plan.MunicipioFimCodigoIbge
            });
            var entity = new CTeRomaneioConsolidadoFactory(_logger).Create(
                null,
                entradaId,
                saga.CorrelationId.ToString(),
                plan.CargaId,
                plan.CargaId,
                DateTime.UtcNow,
                plan.UfInicio,
                plan.UfFim,
                plan.MunicipioInicioCodigoIbge,
                plan.MunicipioFimCodigoIbge,
                plan.EmitenteDocumento,
                plan.TomadorDocumento,
                route,
                plan.PlanoJson,
                plan.PlanoJson,
                1);

            _romaneioWriteRepository.Insert(entity);
            return entity.Id ?? throw new InvalidOperationException($"Carga {plan.CargaId}: romaneio do CT-e complementar nao recebeu Id.");
        }

        private int EnsureSolicitacao(SagaBase saga, CTeComplementarPlan plan, int entradaId, int romaneioId)
        {
            var current = _solicitacaoReadRepository.FirstByCorrelationId(saga.CorrelationId.ToString());
            if (current is not null && current.id > 0)
                return current.id;

            var entity = new CTeSolicitacaoFiscalFactory(_logger).Create(
                null,
                entradaId,
                romaneioId,
                saga.CorrelationId.ToString(),
                plan.Ambiente,
                plan.UfEmitente,
                plan.EmitenteDocumento,
                57,
                1,
                plan.TipoServico,
                plan.Modal,
                plan.Globalizado,
                plan.UfInicio,
                plan.UfFim,
                plan.MunicipioInicioCodigoIbge,
                plan.MunicipioFimCodigoIbge,
                plan.ValorPrestacaoComplementar,
                0m,
                plan.PlanoJson,
                1);

            _solicitacaoWriteRepository.Insert(entity);
            return entity.Id ?? throw new InvalidOperationException($"Carga {plan.CargaId}: solicitacao do CT-e complementar nao recebeu Id.");
        }

        private void EnsureDocumentos(CTeComplementarPlan plan, int solicitacaoId)
        {
            var current = (_documentoReadRepository.GetAllByCTeSolicitacaoFiscalId(solicitacaoId)
                    ?? Array.Empty<CTeDocumentoOriginarioDTO>())
                .Where(x => string.Equals(x.tipodocumento, "CTe", StringComparison.OrdinalIgnoreCase))
                .Select(x => CTeComplementarPlan.Digits(x.chaveacesso ?? string.Empty))
                .ToHashSet(StringComparer.Ordinal);

            foreach (var key in plan.ChavesCTeOriginais.Where(x => !current.Contains(x)))
            {
                var number = key.Length == 44 ? key.Substring(25, 9).TrimStart('0') : string.Empty;
                var series = key.Length == 44 ? key.Substring(22, 3).TrimStart('0') : string.Empty;
                _documentoWriteRepository.Insert(new CTeDocumentoOriginarioFactory(_logger).Create(
                    null,
                    solicitacaoId,
                    null,
                    "CTe",
                    key,
                    string.IsNullOrWhiteSpace(number) ? "0" : number,
                    string.IsNullOrWhiteSpace(series) ? "0" : series,
                    plan.RemetenteDocumento,
                    plan.DestinatarioDocumento,
                    null,
                    null,
                    JsonSerializer.Serialize(new { chaveCTeOriginal = key })));
            }
        }

        private void EnsureParticipantes(CTeComplementarPlan plan, int solicitacaoId)
        {
            var current = (_participanteReadRepository.GetAllByCTeSolicitacaoFiscalId(solicitacaoId)
                    ?? Array.Empty<CTeParticipanteSnapshotDTO>())
                .Select(x => x.papel ?? string.Empty)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            InsertParticipant("Remetente", plan.RemetenteDocumento);
            InsertParticipant("Destinatario", plan.DestinatarioDocumento);
            InsertParticipant("Tomador", plan.TomadorDocumento);

            void InsertParticipant(string role, string document)
            {
                if (current.Contains(role) || string.IsNullOrWhiteSpace(document))
                    return;

                _participanteWriteRepository.Insert(new CTeParticipanteSnapshotFactory(_logger).Create(
                    null,
                    solicitacaoId,
                    role,
                    document,
                    plan.ParticipantName(role),
                    plan.ParticipantStateRegistration(role),
                    plan.ParticipantUf(role),
                    plan.ParticipantMunicipality(role),
                    plan.ParticipantAddressJson(role)));
            }
        }

        private void EnsureComplemento(CTeComplementarPlan plan, int solicitacaoId)
        {
            var current = _complementoReadRepository.FirstByCTeSolicitacaoFiscalId(solicitacaoId);
            if (current is not null && current.id > 0)
            {
                _complementoWriteRepository.UpdateValorPrestacaoComplementar(current.id, plan.ValorPrestacaoComplementar);
                _complementoWriteRepository.UpdateCST(current.id, plan.CstIcms);
                _complementoWriteRepository.UpdateValorBaseCalculo(current.id, plan.ValorBaseCalculoIcms);
                _complementoWriteRepository.UpdateAliquotaICMS(current.id, plan.AliquotaIcms);
                _complementoWriteRepository.UpdateValorICMS(current.id, plan.ValorIcms);
                return;
            }

            _complementoWriteRepository.Insert(new CTeComplementoIcmsFiscalFactory(_logger).Create(
                null,
                solicitacaoId,
                plan.ValorPrestacaoComplementar,
                plan.CstIcms,
                plan.ValorBaseCalculoIcms,
                plan.AliquotaIcms,
                plan.ValorIcms));
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
