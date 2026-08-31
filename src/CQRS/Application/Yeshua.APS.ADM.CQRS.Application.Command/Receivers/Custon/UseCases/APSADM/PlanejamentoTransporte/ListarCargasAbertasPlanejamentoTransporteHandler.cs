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
    public partial class ListarCargasAbertasPlanejamentoTransporteHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly ICargaPlanejavelReadRepository _repReadCargaPlanejavel;
        private readonly ICargaPlanejavelWriteRepository _repWriteCargaPlanejavel;
        public ListarCargasAbertasPlanejamentoTransporteHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,ICargaPlanejavelReadRepository repReadCargaPlanejavel, ICargaPlanejavelWriteRepository repWriteCargaPlanejavel)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadCargaPlanejavel = repReadCargaPlanejavel;
            _repWriteCargaPlanejavel = repWriteCargaPlanejavel;
        }
protected partial async Task<State<ListarCargasAbertasPlanejamentoTransporteOutputCommand>> CustomActionHookAsync(State<ListarCargasAbertasPlanejamentoTransporteOutputCommand> state, ListarCargasAbertasPlanejamentoTransporteInputCommand comand, CancellationToken cancellationToken)
{
    return state;
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers