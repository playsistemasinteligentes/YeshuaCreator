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
    public partial class ValidarCTeOriginalEComplementoHandler
    {
        private readonly ICTeRomaneioConsolidadoReadRepository _romaneioReadRepository;
        private readonly ICTeSolicitacaoFiscalReadRepository _solicitacaoReadRepository;
        private readonly ICTeDocumentoOriginarioReadRepository _documentoReadRepository;
        private readonly ICTeParticipanteSnapshotReadRepository _participanteReadRepository;
        private readonly ICTeComplementoIcmsFiscalReadRepository _complementoReadRepository;
        private readonly IEntradaFiscalContingenciaReadRepository _entradaContingenciaReadRepository;
        private readonly ICertificadoDigitalReadRepository _certificadoReadRepository;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public ValidarCTeOriginalEComplementoHandler(
            ICTeRomaneioConsolidadoReadRepository romaneioReadRepository,
            ICTeSolicitacaoFiscalReadRepository solicitacaoReadRepository,
            ICTeDocumentoOriginarioReadRepository documentoReadRepository,
            ICTeParticipanteSnapshotReadRepository participanteReadRepository,
            ICTeComplementoIcmsFiscalReadRepository complementoReadRepository,
            IEntradaFiscalContingenciaReadRepository entradaContingenciaReadRepository,
            ICertificadoDigitalReadRepository certificadoReadRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _romaneioReadRepository = romaneioReadRepository;
            _solicitacaoReadRepository = solicitacaoReadRepository;
            _documentoReadRepository = documentoReadRepository;
            _participanteReadRepository = participanteReadRepository;
            _complementoReadRepository = complementoReadRepository;
            _entradaContingenciaReadRepository = entradaContingenciaReadRepository;
            _certificadoReadRepository = certificadoReadRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var plan = CTeComplementarPlan.From(saga, step);
            var romaneio = _romaneioReadRepository.FirstByCargaId(plan.CargaId);
            if (romaneio == null || romaneio.id <= 0)
                throw new InvalidOperationException($"Carga {plan.CargaId}: romaneio do CT-e complementar nao encontrado.");

            var solicitacao = _solicitacaoReadRepository.FirstByRomaneioConsolidadoId(romaneio.id);
            if (solicitacao == null || solicitacao.id <= 0 || solicitacao.tipocte != 1)
                throw new InvalidOperationException($"Carga {plan.CargaId}: solicitacao de CT-e complementar nao encontrada.");

            var documentos = (_documentoReadRepository.GetAllByCTeSolicitacaoFiscalId(solicitacao.id)
                    ?? Array.Empty<Repositorio.Outputs.CTeDocumentoOriginarioDTO>())
                .Where(x => string.Equals(x.tipodocumento, "CTe", StringComparison.OrdinalIgnoreCase))
                .ToArray();
            if (documentos.Length is < 1 or > 10 || documentos.Any(x => CTeComplementarPlan.Digits(x.chaveacesso ?? string.Empty).Length != 44))
                throw new InvalidOperationException($"Carga {plan.CargaId}: informe de uma a dez chaves validas de CT-e original.");

            var participantes = (_participanteReadRepository.GetAllByCTeSolicitacaoFiscalId(solicitacao.id)
                    ?? Array.Empty<Repositorio.Outputs.CTeParticipanteSnapshotDTO>())
                .ToArray();
            foreach (var papel in new[] { "Remetente", "Destinatario", "Tomador" })
            {
                if (!participantes.Any(x => string.Equals(x.papel, papel, StringComparison.OrdinalIgnoreCase)))
                    throw new InvalidOperationException($"Carga {plan.CargaId}: participante {papel} nao encontrado no CT-e complementar.");
            }

            var complemento = _complementoReadRepository.FirstByCTeSolicitacaoFiscalId(solicitacao.id);
            if (complemento == null || complemento.id <= 0 ||
                complemento.valorprestacaocomplementar <= 0m ||
                complemento.valorbasecalculo <= 0m ||
                complemento.aliquotaicms <= 0m ||
                complemento.valoricms <= 0m ||
                !string.Equals(complemento.cst, "00", StringComparison.Ordinal))
            {
                throw new InvalidOperationException($"Carga {plan.CargaId}: valores do complemento de ICMS invalidos ou incompletos.");
            }

            var certificado = FiscalCertificateResolver.TryResolve(
                plan.CargaId,
                _entradaContingenciaReadRepository,
                _certificadoReadRepository)
                ?? throw new InvalidOperationException($"Carga {plan.CargaId}: certificado digital nao informado.");
            FiscalCertificateResolver.ValidateIssuer(certificado, solicitacao.emitentedocumento, $"Carga {plan.CargaId}");

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.cte-complementar.validado",
                new
                {
                    origem = "Fiscal",
                    cargaId = plan.CargaId,
                    cteSolicitacaoFiscalId = solicitacao.id,
                    quantidadeCTeOriginais = documentos.Length
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: CT-e original e complemento de ICMS validados.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
