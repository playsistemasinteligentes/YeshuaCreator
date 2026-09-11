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
    public partial class EscolherModeloAgrupamentoCTeContingenciaHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly IEntradaFiscalContingenciaReadRepository _repReadEntradaFiscalContingencia;
        private readonly IEntradaFiscalContingenciaWriteRepository _repWriteEntradaFiscalContingencia;
        private readonly ContingenciaFiscalStepStimulusService _stepStimulusService;
        public EscolherModeloAgrupamentoCTeContingenciaHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,Command.Interfaces.ISagaStepInvoker sagaStepInvoker,IEntradaFiscalContingenciaReadRepository repReadEntradaFiscalContingencia, IEntradaFiscalContingenciaWriteRepository repWriteEntradaFiscalContingencia, ContingenciaFiscalStepStimulusService stepStimulusService)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
           _sagaStepInvoker = sagaStepInvoker;
            _repReadEntradaFiscalContingencia = repReadEntradaFiscalContingencia;
            _repWriteEntradaFiscalContingencia = repWriteEntradaFiscalContingencia;
            _stepStimulusService = stepStimulusService;
        }
protected partial async Task<State<EscolherModeloAgrupamentoCTeContingenciaOutputCommand>> CustomActionHookAsync(State<EscolherModeloAgrupamentoCTeContingenciaOutputCommand> state, EscolherModeloAgrupamentoCTeContingenciaInputCommand comand, CancellationToken cancellationToken)
{
    var result = await _stepStimulusService.SubmitAsync(
        ContingenciaFiscalStandardSaga.STEP_3,
        comand.CorrelationId,
        comand.TenantId,
        comand.CargaId,
        comand.EntradaFiscalContingenciaId,
        comand.UserAction,
        comand.DocumentosOriginariosJson,
        comand.DadosComplementaresJson,
        comand.PayloadHash,
        comand.PayloadStorageKey,
        cancellationToken);

    var output = new EscolherModeloAgrupamentoCTeContingenciaOutputCommand
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
