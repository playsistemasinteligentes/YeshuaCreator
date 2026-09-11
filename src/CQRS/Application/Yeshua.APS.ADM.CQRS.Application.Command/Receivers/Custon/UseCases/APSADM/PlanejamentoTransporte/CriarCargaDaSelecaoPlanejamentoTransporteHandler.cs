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
using Dominio.Behaviors;
using Dominio.Entitys;
using Dominio.Patterns.Domain;
using Dominio.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class CriarCargaDaSelecaoPlanejamentoTransporteHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly IPedidoPlanejavelReadRepository _repReadPedidoPlanejavel;
        private readonly ICargaReadRepository _repReadCarga;
        private readonly ICargaWriteRepository _repWriteCarga;
        private readonly IItenCargaReadRepository _repReadItenCarga;
        private readonly IItenCargaWriteRepository _repWriteItenCarga;
        private readonly IySagaWriteRepository _repWriteSaga;
        public CriarCargaDaSelecaoPlanejamentoTransporteHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IPedidoPlanejavelReadRepository repReadPedidoPlanejavel, ICargaReadRepository repReadCarga, ICargaWriteRepository repWriteCarga,IItenCargaReadRepository repReadItenCarga, IItenCargaWriteRepository repWriteItenCarga,IySagaWriteRepository repWriteSaga)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadPedidoPlanejavel = repReadPedidoPlanejavel;
            _repReadCarga = repReadCarga;
            _repWriteCarga = repWriteCarga;
            _repReadItenCarga = repReadItenCarga;
            _repWriteItenCarga = repWriteItenCarga;
            _repWriteSaga = repWriteSaga;
        }
protected partial async Task<State<CriarCargaDaSelecaoPlanejamentoTransporteOutputCommand>> CustomActionHookAsync(State<CriarCargaDaSelecaoPlanejamentoTransporteOutputCommand> state, CriarCargaDaSelecaoPlanejamentoTransporteInputCommand comand, CancellationToken cancellationToken)
{
    await Task.CompletedTask;

    var refs = comand.Pedidos ?? new List<PedidoPlanejamentoRef>();
    var ids = refs
        .Where(pedido => !string.IsNullOrWhiteSpace(pedido.PedidoId))
        .Select(pedido => pedido.PedidoId)
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .ToArray();

    if (ids.Length == 0)
        return Success("OK", Failed("Selecione pelo menos um pedido para criar carga."));

    var contextoPlanejamento = PlanejamentoTransporteLensCatalog.ParseContext(comand.ContextoId);
    var pedidos = _repReadPedidoPlanejavel
        .GetPlanejamentoPedidosByIds(contextoPlanejamento.EmbarqueDe, contextoPlanejamento.EmbarqueAte, contextoPlanejamento.LimitePedidos, ids)
        .ToList();

    if (pedidos.Count != ids.Length)
        return Success("OK", Failed("Algum pedido saiu do contexto atual. Atualize a tela e selecione novamente."));

    if (pedidos.Any(pedido => !string.IsNullOrWhiteSpace(pedido.cargaatualid)
        || (pedido.alertasresumo ?? string.Empty).Contains("vinculado", StringComparison.OrdinalIgnoreCase)))
        return Success("OK", Failed("Existe pedido selecionado ja vinculado a carga. Atualize a selecao antes de criar."));

    var cargaId = CreateCargaId();
    var now = DateTime.Now;
    var peso = pedidos.Sum(pedido => pedido.peso);
    var volume = pedidos.Sum(pedido => pedido.volume);
    var inicioJanela = pedidos.Min(pedido => pedido.embarquealvo);
    var fimJanela = pedidos.Max(pedido => pedido.embarquealvo);
    var tipoVeiculoId = ParseTipoVeiculoId(comand.TipoVeiculoId);
    var transportadoraId = NormalizeText(comand.TransportadoraId);
    var veiculoPlaca = NormalizeText(comand.VeiculoPlaca);

    var contexto = DomainOperationContext.Create(
        DomainOperation.Registro,
        DomainEntryPoint.UseCase,
        "CriarCargaDaSelecaoPlanejamentoTransporte",
        _executionContext.TenantID,
        _executionContext.UserId,
        traceId: _executionContext.TraceId,
        receiverName: nameof(CriarCargaDaSelecaoPlanejamentoTransporteHandler),
        commandName: nameof(CriarCargaDaSelecaoPlanejamentoTransporteInputCommand),
        recordId: cargaId);

    var carga = new CargaFactory(_logger, _domainTrackingPolicy).Create(
        contexto,
        null,
        cargaId,
        null,
        null,
        null,
        null,
        null,
        inicioJanela,
        fimJanela,
        inicioJanela,
        1m,
        peso,
        volume,
        null,
        null,
        null,
        null,
        null,
        null,
        veiculoPlaca,
        tipoVeiculoId,
        transportadoraId,
        null,
        null,
        "Criada pela tela de planejamento de transporte.",
        comand.Observacao,
        null,
        null,
        "Selecao manual por lente.",
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null);

    var cargaResult = CargaDomainBehavior.Apply(carga, contexto);
    if (!cargaResult.IsValid)
        return Success("OK", Failed(string.Join(" ", cargaResult.Errors)));

    try
    {
        _unitOfWork.BeginTran();
        _repWriteCarga.Insert(carga);

        var ordem = 1;
        foreach (var pedido in pedidos)
        {
            var item = new ItenCargaFactory(_logger, _domainTrackingPolicy).Create(
                contexto,
                null,
                cargaId,
                pedido.pedidoid,
                pedido.embarquealvo == default ? now : pedido.embarquealvo,
                pedido.embarquealvo == default ? now : pedido.embarquealvo,
                ordem++,
                pedido.saldoaexpedir,
                0m,
                null,
                null,
                null);

            var itemResult = ItenCargaDomainBehavior.Apply(item, contexto);
            if (!itemResult.IsValid)
            {
                _unitOfWork.Rollback();
                return Success("OK", Failed(string.Join(" ", itemResult.Errors)));
            }

            _repWriteItenCarga.Insert(item);
        }

        StartCargaStandardSaga(cargaId, now);

        _unitOfWork.Commit();

        return Success("OK", new CriarCargaDaSelecaoPlanejamentoTransporteOutputCommand
        {
            CargaId = cargaId,
            Criada = true,
            Mensagem = $"Carga {cargaId} criada com {pedidos.Count} pedido(s)."
        });
    }
    catch
    {
        _unitOfWork.Rollback();
        throw;
    }
}

private void StartCargaStandardSaga(string cargaId, DateTime now)
{
    var saga = new CargaStandardSaga();
    saga.CreatedAt = now;
    saga.NextExecutionAt = DateTime.UtcNow;
    saga.LockedAt = DateTime.MinValue;
    saga.LockedBy = null;
    saga.Start(cargaId, "Carga");

    _repWriteSaga.Save(saga);
}

private static string CreateCargaId()
{
    return "PLN" + DateTime.UtcNow.ToString("MMddHHmmssfff");
}

private static int? ParseTipoVeiculoId(string? value)
{
    return int.TryParse(value, out var parsed) && parsed > 0 ? parsed : null;
}

private static string? NormalizeText(string? value)
{
    return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}

private static CriarCargaDaSelecaoPlanejamentoTransporteOutputCommand Failed(string message)
{
    return new CriarCargaDaSelecaoPlanejamentoTransporteOutputCommand
    {
        CargaId = string.Empty,
        Criada = false,
        Mensagem = message
    };
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
