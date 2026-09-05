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
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class BuscarContextoPlanejamentoTransporteHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly IPedidoPlanejavelReadRepository _repReadPedidoPlanejavel;
        private readonly IPedidoPlanejavelWriteRepository _repWritePedidoPlanejavel;
        private readonly ICargaPlanejavelReadRepository _repReadCargaPlanejavel;
        private readonly ICargaPlanejavelWriteRepository _repWriteCargaPlanejavel;
        public BuscarContextoPlanejamentoTransporteHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IPedidoPlanejavelReadRepository repReadPedidoPlanejavel, IPedidoPlanejavelWriteRepository repWritePedidoPlanejavel,ICargaPlanejavelReadRepository repReadCargaPlanejavel, ICargaPlanejavelWriteRepository repWriteCargaPlanejavel)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadPedidoPlanejavel = repReadPedidoPlanejavel;
            _repWritePedidoPlanejavel = repWritePedidoPlanejavel;
            _repReadCargaPlanejavel = repReadCargaPlanejavel;
            _repWriteCargaPlanejavel = repWriteCargaPlanejavel;
        }
protected partial async Task<State<BuscarContextoPlanejamentoTransporteOutputCommand>> CustomActionHookAsync(State<BuscarContextoPlanejamentoTransporteOutputCommand> state, BuscarContextoPlanejamentoTransporteInputCommand comand, CancellationToken cancellationToken)
{
    await Task.CompletedTask;

    var embarqueDe = comand.EmbarqueDe.Date;
    var embarqueAte = comand.EmbarqueAte.Date;

    if (embarqueDe.Year < 2000)
        embarqueDe = DateTime.Today;

    if (embarqueAte.Year < 2000 || embarqueAte < embarqueDe)
        embarqueAte = embarqueDe.AddDays(1);

    var limite = PlanejamentoTransporteLensCatalog.NormalizeLimit(comand.LimitePedidos);
    var metrics = _repReadPedidoPlanejavel.GetPlanejamentoContext(embarqueDe, embarqueAte, limite);

    return Success("OK", new BuscarContextoPlanejamentoTransporteOutputCommand
    {
        ContextoId = PlanejamentoTransporteLensCatalog.CreateContextId(embarqueDe, embarqueAte, limite, comand.PlantaId),
        GeradoEm = DateTime.UtcNow,
        QuantidadePedidos = metrics.quantidadepedidos,
        QuantidadeCargas = metrics.quantidadecargas,
        Lentes = PlanejamentoTransporteLensCatalog.List()
    });
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
