// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeApplicationSagaQueueWorkers
// </yeshua>

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
                "audio.transcribe" => "audio.transcribed",
        "text.summarize" => "text.summarized",
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
}//Dominio.Schemas.CQRS.SourceCodeApplicationSagaQueueWorkers