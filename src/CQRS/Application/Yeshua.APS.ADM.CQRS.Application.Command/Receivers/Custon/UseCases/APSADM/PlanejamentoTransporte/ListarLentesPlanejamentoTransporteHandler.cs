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
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class ListarLentesPlanejamentoTransporteHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly IPedidoPlanejavelReadRepository _repReadPedidoPlanejavel;
        private readonly IPedidoPlanejavelWriteRepository _repWritePedidoPlanejavel;
        public ListarLentesPlanejamentoTransporteHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IPedidoPlanejavelReadRepository repReadPedidoPlanejavel, IPedidoPlanejavelWriteRepository repWritePedidoPlanejavel)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadPedidoPlanejavel = repReadPedidoPlanejavel;
            _repWritePedidoPlanejavel = repWritePedidoPlanejavel;
        }
protected partial async Task<State<ListarLentesPlanejamentoTransporteOutputCommand>> CustomActionHookAsync(State<ListarLentesPlanejamentoTransporteOutputCommand> state, ListarLentesPlanejamentoTransporteInputCommand comand, CancellationToken cancellationToken)
{
    await Task.CompletedTask;

    return Success("OK", new ListarLentesPlanejamentoTransporteOutputCommand
    {
        Lentes = PlanejamentoTransporteLensCatalog.List()
    });
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
