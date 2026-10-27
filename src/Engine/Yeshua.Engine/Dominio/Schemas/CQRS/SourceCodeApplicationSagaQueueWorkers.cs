using System.Text;
using Dominio.Migration;
using Migration.Dominio;
namespace Dominio.Schemas.CQRS;

// Standard queue transport for applications that opt into the generated saga queue policy.
public sealed class SourceCodeApplicationSagaQueueWorkers : SourceCodeBase
{
    private readonly MigrationBase _migration;
    private readonly bool _inbox;
    public SourceCodeApplicationSagaQueueWorkers(MigrationBase migration, bool inbox)
        { _migration = migration; _inbox = inbox; }
    public void WriteGeneratedCode(string path) => WriteCode(null, path,
        Path.Combine(Path.GetDirectoryName(path)!, "Custon", Path.GetFileName(path)));
    protected override StringBuilder GenerateCode()
    {
        var routes = new StringBuilder();
        var contracts = new StringBuilder();
        var operations = new Dictionary<string, string>(StringComparer.Ordinal);
        foreach (var sub in _migration.UseCaseGroup.SelectMany(g => g.UseCaseSubGroup))
        foreach (var saga in sub.Saga)
        foreach (var step in saga.SagaStepGroup.SelectMany(g => g.Steps))
        {
            var inputs = step.InboxQueueTopology?.Exchanges.SelectMany(e => e.Bindings).ToList()
                ?? new List<Dominio.QueueBindingDefinition>();
            foreach (var binding in inputs)
            {
                routes.AppendLine($"        (\"{binding.QueueName}\", \"{saga.Name.SourceType()}Saga\", \"{step.Name.SourceType()}\") => true,");
                contracts.AppendLine($"        (\"{binding.RoutingKey}\", \"{saga.Name.SourceType()}Saga\", \"{step.Name.SourceType()}\") => true,");
            }
            foreach (var binding in step.OutboxQueueTopology?.Exchanges.SelectMany(e => e.Bindings)
                ?? Enumerable.Empty<Dominio.QueueBindingDefinition>())
            {
                if (inputs.Count != 1) continue;
                if (operations.TryGetValue(binding.RoutingKey, out var prior) && prior != inputs[0].RoutingKey)
                    throw new InvalidOperationException("Uma operacao de Outbox deve declarar um contrato de retorno unico.");
                operations[binding.RoutingKey] = inputs[0].RoutingKey;
            }
        }
        if (!_inbox)
            return new StringBuilder(OutboxCode.Replace("/*OPERATION_RESULTS*/",
                string.Join(Environment.NewLine, operations.Select(p => $"        \"{p.Key}\" => \"{p.Value}\","))));
        return new StringBuilder(InboxCode.Replace("/*RESULT_ROUTES*/", routes.ToString())
            .Replace("/*RESULT_CONTRACTS*/", contracts.ToString()));
    }
    protected override StringBuilder GenerateCustonCode() => new();

    private const string InboxCode = """
using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.Queue;
using Command.Patterns.Command;
using Dominio.Operational;
using IRepository.Read;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Command.Patterns.OutBox;

public class InboxListenerHandler : ReciverBase<InboxInputCommand, InboxOutputCommand>
{
    private readonly IySagaStepReadRepository _steps;
    private readonly IySagaReadRepository _sagas;
    private readonly OutboxService _inbox;
    private readonly IUnitOfWork _work;
    private readonly IExecutionContext _context;
    private readonly Dominio.Interfaces.ILogger _evidenceLogger;

    public InboxListenerHandler(IySagaStepReadRepository steps, IySagaReadRepository sagas, OutboxService inbox,
        IUnitOfWork work, Dominio.Interfaces.ILogger logger, IExecutionContext context) : base(logger, context)
        { _steps = steps; _sagas = sagas; _inbox = inbox; _work = work; _context = context; _evidenceLogger = logger; }

    protected override Task<State<InboxOutputCommand>> ActionAsync(InboxInputCommand command, CancellationToken cancellationToken = default)
    {
        _work.BeginTran();
        try
        {
            AcceptWithinTransaction(command);
            _work.Commit();
            return Task.FromResult(Success("Retorno recebido.", new InboxOutputCommand()));
        }
        catch { _work.Rollback(); throw; }
    }

    // Same validation/persistence for broker results and HTTP delivery receipts.
    // The Outbox caller owns the short transaction that also confirms delivery.
    public bool AcceptWithinTransaction(InboxInputCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.messageId) || string.IsNullOrWhiteSpace(command.correlationId)
            || command.messageId.Length > 100 || command.correlationId.Length > 100 || string.IsNullOrWhiteSpace(command.status)
            || command.status.Length > 100 || command.requestId?.Length > 100
            || command.result.ValueKind == JsonValueKind.Undefined || command.error.ValueKind == JsonValueKind.Undefined)
            return false;
        var step = _steps.FirstByCorrelationId(command.correlationId, TakeOffTenantID: true);
        var saga = step is null ? null : _sagas.FirstById(step.sagaid, TakeOffTenantID: true);
        if (step is null || saga is null || !(string.IsNullOrEmpty(command.QueueName)
            ? IsDeclaredContract(command.ResultContract, saga.type, step.stepkey)
            : IsDeclaredRoute(command.QueueName, saga.type, step.stepkey)))
            return false;
        if (saga.processingscope != _context.ProcessingScope)
            throw new InvalidOperationException("Resultado pertence a outro escopo de processamento.");
        if (saga.tenantid <= 0 || saga.userid <= 0)
            return false;
        _context.SetTenantId(saga.tenantid);
        _context.SetUserId(saga.userid);
        _context.SetTraceId(saga.correlationid);
        var decision = _evidenceLogger.Evaluate("Inbox", command.status, saga.entitytype, saga.entityid);
        var parent = _context.TryGetOperationalIdentity(out var incoming) ? incoming
            : new OperationalExecutionIdentity(step.rootoperationid, step.operationid, step.executionid, step.causationid);
        using var execution = decision.Enabled
            ? _context.BeginOperationalExecution(parent, "Saga.ExternalResult")
            : null;
        if (!_steps.CanReceiveResult(step.id, command.messageId, command.requestId)) return false;
        _inbox.AddInboxEvent(command.status, command, saga.entitytype, saga.entityid,
            command.messageId, command.correlationId, saga.id, step.id);
        return true;
    }

    private static bool IsDeclaredRoute(string queue, string saga, string step) => (queue, saga, step) switch
    {
        /*RESULT_ROUTES*/
        _ => false
    };
    private static bool IsDeclaredContract(string contract, string saga, string step) => (contract, saga, step) switch
    {
        /*RESULT_CONTRACTS*/
        _ => false
    };
}
public partial record InboxInputCommand : ICommand, IQueueReceivedCommand
{
    public string messageId { get; set; } = "";
    public string correlationId { get; set; } = "";
    public string? requestId { get; set; }
    public string status { get; set; } = "";
    public JsonElement result { get; set; }
    public JsonElement error { get; set; }
    [JsonIgnore] public string QueueName { get; set; } = "";
    [JsonIgnore] public string ResultContract { get; set; } = "";
}
public partial record InboxOutputCommand : ICommand { }

""";
    private const string OutboxCode = """
using Command.Interfaces.Patterns.Queue;
using Command.Patterns.Command;
using Command.Patterns.Queue;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using RepositoryInterfaces.Patterns.Worker;
using System.Text.Json;

namespace Command.Patterns.OutBox;

public class yOutBoxWorkerHandler : ReciverBase<yOutboxInputCommand, yOutboxOutputCommand>
{
    private readonly IyOutboxReadRepository _outbox;
    private readonly IUnitOfWork _work;
    private readonly InboxListenerHandler _inbox;
    private readonly IOutboxDeliveryFactory _factory;
    private readonly Aplication.Interfaces.Services.IExecutionContext _context;
    private readonly Dominio.Interfaces.ILogger _evidenceLogger;

    public yOutBoxWorkerHandler(IUnitOfWork work, IyOutboxReadRepository outbox,
        IyOutboxWriteRepository writes, IQueuePublisher publisher, Dominio.Interfaces.ILogger logger,
        Aplication.Interfaces.Services.IExecutionContext context, InboxListenerHandler inbox,
        IOutboxDeliveryFactory? factory = null) : base(logger, context)
        => (_work, _outbox, _inbox, _factory, _context, _evidenceLogger) =
            (work, outbox, inbox, factory ?? new QueueOutboxDeliveryFactory(publisher), context, logger);

    protected override async Task<State<yOutboxOutputCommand>> ActionAsync(yOutboxInputCommand command,
        CancellationToken cancellationToken = default)
    {
        var events = _outbox.ClaimBatch(1); // Reserve only the item whose I/O can start now.
        var processed = 0;
        var failed = 0;
        foreach (var evt in events)
        {
            var claimedAt = evt.processingat;
            if (claimedAt == default) throw new InvalidOperationException("Reserva de entrega ausente.");
            _context.SetTenantId(evt.tenantid);
            _context.SetUserId(evt.userid);
            var telemetry = _evidenceLogger.Evaluate("Outbox", evt.type, evt.entitytype, evt.entityid);
            using var execution = telemetry.Enabled
                ? _context.BeginOperationalExecution(new Dominio.Operational.OperationalExecutionIdentity(
                    evt.rootoperationid, evt.operationid, evt.executionid, evt.causationid), "Outbox.Delivery")
                : null;
            var identity = _context.TryGetOperationalIdentity(out var activeIdentity) ? activeIdentity
                : new Dominio.Operational.OperationalExecutionIdentity(
                    evt.rootoperationid, evt.operationid, evt.executionid, evt.causationid);
            var message = new QueueMessage(evt.type, evt.payload,
                identity)
            {
                MenssageId = evt.messageid, CorrelationId = evt.correlationid,
                Source = "outbox-worker", ProcessingScope = evt.processingscope
            };
            var request = new OutboxDeliveryRequest(message, evt.transportdata ?? "{}", evt.transporttype,
                evt.tenantid, ResultContract(evt.type));
            try
            {
                if (_outbox.HasAcceptedDeliveryResult(evt.id) || !_outbox.IsCurrentDelivery(evt.id))
                {
                    Finish(evt.id, claimedAt, request, null, null);
                    processed++;
                    continue;
                }
                var provider = ReadProvider(request.TransportData);
                if (provider is null)
                {
                    // Unbound recovered/retried legacy requests keep their declared queue destination.
                    provider = evt.claimpreviousstatus == 9 || evt.retrycount > 0
                        ? "Queue" : _factory.SelectProvider(request);
                    var transportType = _factory.GetType(provider).TransportType;
                    var bound = _outbox.BindDeliveryProvider(evt.id, claimedAt, provider, transportType);
                    if (bound is null) throw new ClaimLostException();
                    request = request with { TransportData = bound, TransportType = transportType };
                }
                using var deadline = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                // Claim recovery is five minutes: bounded I/O ends before that lease can expire.
                deadline.CancelAfter(TimeSpan.FromSeconds(240));
                var result = await _factory.GetType(provider).DeliverAsync(request, deadline.Token);
                Finish(evt.id, claimedAt, request, result, null);
                processed++;
            }
            catch (ClaimLostException) { failed++; }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested) { throw; }
            catch (Exception exception)
            {
                failed++;
                var failure = exception as OutboxDeliveryException
                    ?? new OutboxDeliveryException(exception is OperationCanceledException
                        ? "delivery_timeout" : "delivery_unavailable", "Entrega externa indisponivel.", true);
                var retry = evt.retrycount + 1;
                try
                {
                    if (!failure.Retryable || retry >= 5)
                    {
                        var result = string.IsNullOrEmpty(request.ResultContract) ? null
                            : ExternalExecutionResult.DeliveryFailed(request, failure.Code);
                        Finish(evt.id, claimedAt, request, result, (failure.Code, retry));
                    }
                    else
                    {
                        var delay = failure.RetryAfter ?? TimeSpan.FromSeconds(Math.Pow(2, retry));
                        _work.BeginTran();
                        try
                        {
                            if (!_outbox.MarkDeliveryRetry(evt.id, claimedAt, retry,
                                    DateTime.UtcNow.Add(delay), failure.Code))
                                throw new ClaimLostException();
                            _work.Commit();
                        }
                        catch { _work.Rollback(); throw; }
                    }
                }
                catch (ClaimLostException) { }
            }
        }
        return Success("OK", new yOutboxOutputCommand
            { Claimed = events.Count, Processed = processed, Failed = failed });
    }

    private void Finish(int id, DateTime claimedAt, OutboxDeliveryRequest request,
        ExternalExecutionResult? result, (string Code, int Retry)? deadLetter)
    {
        _work.BeginTran();
        try
        {
            if (result is not null)
            {
                if (result.requestId != request.Message.MenssageId
                    || result.correlationId != request.Message.CorrelationId)
                    throw new OutboxDeliveryException("result_identity_invalid", "Identidade do retorno invalida.", false);
                var accepted = _inbox.AcceptWithinTransaction(new InboxInputCommand
                {
                    messageId = result.messageId, requestId = result.requestId,
                    correlationId = result.correlationId, status = result.status,
                    result = result.result, error = result.error, ResultContract = request.ResultContract
                });
                if (!accepted && !_outbox.HasAcceptedDeliveryResult(id) && _outbox.IsCurrentDelivery(id))
                    throw new OutboxDeliveryException("result_not_accepted", "Retorno externo nao aceito.", false);
            }
            var marked = deadLetter is { } terminal
                ? _outbox.MarkDeliveryDeadLetter(id, claimedAt, terminal.Code, terminal.Retry)
                : _outbox.MarkDeliveryDone(id, claimedAt, DateTime.UtcNow);
            if (!marked) throw new ClaimLostException();
            _work.Commit();
        }
        catch { _work.Rollback(); throw; }
    }

    private static string? ReadProvider(string data)
    {
        using var document = JsonDocument.Parse(data);
        return document.RootElement.TryGetProperty("DeliveryProvider", out var provider) ? provider.GetString() : null;
    }
    private static string ResultContract(string operation) => operation switch
    {
        /*OPERATION_RESULTS*/
        _ => ""
    };
    private sealed class ClaimLostException : Exception { }
}

public partial record yOutboxInputCommand : ICommand
{
    public string CorrelationId { get; set; } = "";
    public string Payload { get; set; } = "";
}
public partial record yOutboxOutputCommand : ICommand, IWorkerCycleResult
{
    public int BatchLimit => 1;
    public int Claimed { get; init; }
    public int Processed { get; init; }
    public int Failed { get; init; }
}
""";
}
