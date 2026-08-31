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

namespace Command.Receivers.UseCase
{
    public partial class GerarCenariosPlanejamentoTransporteHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly ICenarioPlanejamentoTransporteReadRepository _repReadCenarioPlanejamentoTransporte;
        private readonly ICenarioPlanejamentoTransporteWriteRepository _repWriteCenarioPlanejamentoTransporte;
        public GerarCenariosPlanejamentoTransporteHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,ICenarioPlanejamentoTransporteReadRepository repReadCenarioPlanejamentoTransporte, ICenarioPlanejamentoTransporteWriteRepository repWriteCenarioPlanejamentoTransporte)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadCenarioPlanejamentoTransporte = repReadCenarioPlanejamentoTransporte;
            _repWriteCenarioPlanejamentoTransporte = repWriteCenarioPlanejamentoTransporte;
        }
protected partial async Task<State<GerarCenariosPlanejamentoTransporteOutputCommand>> CustomActionHookAsync(State<GerarCenariosPlanejamentoTransporteOutputCommand> state, GerarCenariosPlanejamentoTransporteInputCommand comand, CancellationToken cancellationToken)
{
    return state;
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers