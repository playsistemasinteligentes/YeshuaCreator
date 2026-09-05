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
    public partial class RevalidarSelecaoPlanejamentoTransporteHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly IPedidoPlanejavelReadRepository _repReadPedidoPlanejavel;
        private readonly IPedidoPlanejavelWriteRepository _repWritePedidoPlanejavel;
        public RevalidarSelecaoPlanejamentoTransporteHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IPedidoPlanejavelReadRepository repReadPedidoPlanejavel, IPedidoPlanejavelWriteRepository repWritePedidoPlanejavel)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadPedidoPlanejavel = repReadPedidoPlanejavel;
            _repWritePedidoPlanejavel = repWritePedidoPlanejavel;
        }
protected partial async Task<State<RevalidarSelecaoPlanejamentoTransporteOutputCommand>> CustomActionHookAsync(State<RevalidarSelecaoPlanejamentoTransporteOutputCommand> state, RevalidarSelecaoPlanejamentoTransporteInputCommand comand, CancellationToken cancellationToken)
{
    await Task.CompletedTask;

    var contexto = PlanejamentoTransporteLensCatalog.ParseContext(comand.ContextoId);
    var pedidosSolicitados = comand.Pedidos ?? new List<PedidoPlanejamentoRef>();
    var ids = pedidosSolicitados
        .Where(pedido => !string.IsNullOrWhiteSpace(pedido.PedidoId))
        .Select(pedido => pedido.PedidoId)
        .ToArray();

    var atuais = _repReadPedidoPlanejavel
        .GetPlanejamentoPedidosByIds(contexto.EmbarqueDe, contexto.EmbarqueAte, contexto.LimitePedidos, ids)
        .ToDictionary(pedido => pedido.pedidoid, StringComparer.OrdinalIgnoreCase);

    var invalidos = new List<PedidoPlanejamentoEnvelope>();

    foreach (var pedido in pedidosSolicitados)
    {
        if (string.IsNullOrWhiteSpace(pedido.PedidoId) || !atuais.TryGetValue(pedido.PedidoId, out var atual))
        {
            invalidos.Add(new PedidoPlanejamentoEnvelope
            {
                PedidoId = pedido.PedidoId,
                AlertasResumo = "Pedido fora do contexto atual."
            });
            continue;
        }

        if (!string.IsNullOrWhiteSpace(pedido.VersaoPlanejamento)
            && !string.Equals(pedido.VersaoPlanejamento, atual.versaoplanejamento, StringComparison.Ordinal))
        {
            var envelope = PlanejamentoTransporteLensCatalog.ToEnvelope(atual);
            envelope.AlertasResumo = "Pedido alterado depois da selecao.";
            invalidos.Add(envelope);
            continue;
        }

        if (!string.IsNullOrWhiteSpace(atual.cargaatualid)
            || (atual.alertasresumo ?? string.Empty).Contains("vinculado", StringComparison.OrdinalIgnoreCase))
        {
            var envelope = PlanejamentoTransporteLensCatalog.ToEnvelope(atual);
            envelope.AlertasResumo = "Pedido ja esta vinculado a uma carga.";
            invalidos.Add(envelope);
        }
    }

    return Success("OK", new RevalidarSelecaoPlanejamentoTransporteOutputCommand
    {
        Valida = invalidos.Count == 0,
        Mensagem = invalidos.Count == 0
            ? "Selecao valida."
            : $"{invalidos.Count} pedido(s) precisam ser revisados antes de criar a carga.",
        PedidosInvalidos = invalidos
    });
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
