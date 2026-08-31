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
    public partial class AbrirNoLentePlanejamentoTransporteHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly IPedidoPlanejavelReadRepository _repReadPedidoPlanejavel;
        private readonly IPedidoPlanejavelWriteRepository _repWritePedidoPlanejavel;
        public AbrirNoLentePlanejamentoTransporteHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IPedidoPlanejavelReadRepository repReadPedidoPlanejavel, IPedidoPlanejavelWriteRepository repWritePedidoPlanejavel)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadPedidoPlanejavel = repReadPedidoPlanejavel;
            _repWritePedidoPlanejavel = repWritePedidoPlanejavel;
        }
protected partial async Task<State<AbrirNoLentePlanejamentoTransporteOutputCommand>> CustomActionHookAsync(State<AbrirNoLentePlanejamentoTransporteOutputCommand> state, AbrirNoLentePlanejamentoTransporteInputCommand comand, CancellationToken cancellationToken)
{
    return state;
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers