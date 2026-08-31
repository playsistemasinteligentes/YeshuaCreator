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
    public partial class AceitarOpcaoPlanejamentoTransporteHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly IOpcaoPlanejamentoTransporteReadRepository _repReadOpcaoPlanejamentoTransporte;
        private readonly IOpcaoPlanejamentoTransporteWriteRepository _repWriteOpcaoPlanejamentoTransporte;
        private readonly ICargaReadRepository _repReadCarga;
        private readonly ICargaWriteRepository _repWriteCarga;
        private readonly IItenCargaReadRepository _repReadItenCarga;
        private readonly IItenCargaWriteRepository _repWriteItenCarga;
        public AceitarOpcaoPlanejamentoTransporteHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IOpcaoPlanejamentoTransporteReadRepository repReadOpcaoPlanejamentoTransporte, IOpcaoPlanejamentoTransporteWriteRepository repWriteOpcaoPlanejamentoTransporte,ICargaReadRepository repReadCarga, ICargaWriteRepository repWriteCarga,IItenCargaReadRepository repReadItenCarga, IItenCargaWriteRepository repWriteItenCarga)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadOpcaoPlanejamentoTransporte = repReadOpcaoPlanejamentoTransporte;
            _repWriteOpcaoPlanejamentoTransporte = repWriteOpcaoPlanejamentoTransporte;
            _repReadCarga = repReadCarga;
            _repWriteCarga = repWriteCarga;
            _repReadItenCarga = repReadItenCarga;
            _repWriteItenCarga = repWriteItenCarga;
        }
protected partial async Task<State<AceitarOpcaoPlanejamentoTransporteOutputCommand>> CustomActionHookAsync(State<AceitarOpcaoPlanejamentoTransporteOutputCommand> state, AceitarOpcaoPlanejamentoTransporteInputCommand comand, CancellationToken cancellationToken)
{
    return state;
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers