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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
    await Task.CompletedTask;

    var contexto = PlanejamentoTransporteLensCatalog.ParseContext(comand.ContextoId);
    var lente = PlanejamentoTransporteLensCatalog.Get(comand.LenteId);
    var filtros = PlanejamentoTransporteLensCatalog.ParseNodeId(comand.NoId);
    var nivel = Math.Max(0, comand.Nivel);

    if (nivel < lente.Niveis.Length)
    {
        var campo = lente.Niveis[nivel];
        var grupos = _repReadPedidoPlanejavel
            .GetPlanejamentoLensGroups(contexto.EmbarqueDe, contexto.EmbarqueAte, contexto.LimitePedidos, filtros, campo)
            .Select(grupo => new PlanejamentoNoLenteResumo
            {
                NoId = PlanejamentoTransporteLensCatalog.BuildNodeId(filtros, campo, grupo.valor),
                ParentNoId = comand.NoId ?? string.Empty,
                Descricao = string.IsNullOrWhiteSpace(grupo.valor) ? "Sem classificacao" : grupo.valor,
                Nivel = nivel,
                QuantidadePedidos = grupo.quantidadepedidos,
                Peso = grupo.peso,
                Volume = grupo.volume,
                TemFilhos = nivel + 1 < lente.Niveis.Length
            })
            .ToList();

        return Success("OK", new AbrirNoLentePlanejamentoTransporteOutputCommand
        {
            Nos = grupos,
            Pedidos = new List<PedidoPlanejamentoEnvelope>()
        });
    }

    var pedidos = _repReadPedidoPlanejavel
        .GetPlanejamentoPedidos(contexto.EmbarqueDe, contexto.EmbarqueAte, contexto.LimitePedidos, filtros)
        .Select(PlanejamentoTransporteLensCatalog.ToEnvelope)
        .ToList();

    return Success("OK", new AbrirNoLentePlanejamentoTransporteOutputCommand
    {
        Nos = new List<PlanejamentoNoLenteResumo>(),
        Pedidos = pedidos
    });
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
