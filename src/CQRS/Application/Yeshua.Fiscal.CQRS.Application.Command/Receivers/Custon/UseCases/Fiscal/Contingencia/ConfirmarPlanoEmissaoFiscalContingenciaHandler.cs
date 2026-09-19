// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

//scope;
using Dominio.Interfaces;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Dominio.Saga;

namespace Command.Receivers.UseCase
{
    public partial class ConfirmarPlanoEmissaoFiscalContingenciaHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IEntradaFiscalContingenciaReadRepository _repReadEntradaFiscalContingencia = default!;
        private readonly IEntradaFiscalContingenciaWriteRepository _repWriteEntradaFiscalContingencia = default!;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository = default!;
        private readonly ICertificadoDigitalReadRepository _certificadoDigitalReadRepository = default!;
        private readonly ContingenciaFiscalStepStimulusService _stepStimulusService = default!;
        public ConfirmarPlanoEmissaoFiscalContingenciaHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,Command.Interfaces.ISagaStepInvoker sagaStepInvoker,IEntradaFiscalContingenciaReadRepository repReadEntradaFiscalContingencia, IEntradaFiscalContingenciaWriteRepository repWriteEntradaFiscalContingencia, INFeProdutoSnapshotReadRepository nfeProdutoSnapshotReadRepository, ICertificadoDigitalReadRepository certificadoDigitalReadRepository, ContingenciaFiscalStepStimulusService stepStimulusService)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
           _sagaStepInvoker = sagaStepInvoker;
            _repReadEntradaFiscalContingencia = repReadEntradaFiscalContingencia;
            _repWriteEntradaFiscalContingencia = repWriteEntradaFiscalContingencia;
            _nfeProdutoSnapshotReadRepository = nfeProdutoSnapshotReadRepository;
            _certificadoDigitalReadRepository = certificadoDigitalReadRepository;
            _stepStimulusService = stepStimulusService;
        }
protected partial async Task<State<ConfirmarPlanoEmissaoFiscalContingenciaOutputCommand>> CustomActionHookAsync(State<ConfirmarPlanoEmissaoFiscalContingenciaOutputCommand> state, ConfirmarPlanoEmissaoFiscalContingenciaInputCommand comand, CancellationToken cancellationToken)
{
    var entrada = _repReadEntradaFiscalContingencia.FirstByCargaId(comand.CargaId);
    if (entrada is null || entrada.id <= 0)
        return ValidationError("Contingencia fiscal nao encontrada.");

    try
    {
        var certificado = Command.Receivers.FiscalCertificateResolver.TryResolve(
            comand.CargaId,
            _repReadEntradaFiscalContingencia,
            _certificadoDigitalReadRepository);

        if (certificado is null)
            return ValidationError("Nenhum certificado digital valido esta vinculado a contingencia.");

        var documentos = Command.Receivers.FiscalContingenciaState.LoadDocumentos(
            _nfeProdutoSnapshotReadRepository,
            comand.CargaId);
        Command.Receivers.FiscalContingenciaState.RefreshPlan(
            _repWriteEntradaFiscalContingencia,
            entrada,
            documentos,
            certificado.DocumentoTitular,
            certificadoFoiVerificado: true);
        entrada = _repReadEntradaFiscalContingencia.FirstByCargaId(comand.CargaId) ?? entrada;

        if (!Command.Receivers.FiscalContingenciaState.HasValidPlanSnapshot(entrada))
            return ValidationError("A previa fiscal possui pendencias. Corrija os dados e gere a previa novamente.");

        Command.Receivers.FiscalCertificateResolver.ValidateIssuer(
            certificado,
            entrada.emitentefiscaldocumento,
            $"Contingencia fiscal {comand.CargaId}");
    }
    catch (Exception exception) when (exception is InvalidOperationException or FileNotFoundException)
    {
        return ValidationError(exception.Message);
    }

    var result = await _stepStimulusService.SubmitAsync(
        ContingenciaFiscalStandardSaga.STEP_1,
        comand.CorrelationId,
        comand.TenantId,
        comand.CargaId,
        comand.EntradaFiscalContingenciaId,
        "ConfirmarPlanoEmissaoFiscalContingencia",
        comand.DocumentosOriginariosJson,
        comand.DadosComplementaresJson,
        comand.PayloadHash,
        comand.PayloadStorageKey,
        cancellationToken);

    var output = new ConfirmarPlanoEmissaoFiscalContingenciaOutputCommand
    {
        CorrelationId = result.CorrelationId,
        CargaId = result.CargaId,
        StepKey = result.StepKey,
        SagaId = result.SagaId,
        SagaStepId = result.SagaStepId,
        InboxId = result.InboxId,
        Accepted = result.Accepted,
        Mensagem = result.Mensagem
    };

    return result.Accepted ? Success("OK", output) : ValidationError(result.Mensagem, output);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
