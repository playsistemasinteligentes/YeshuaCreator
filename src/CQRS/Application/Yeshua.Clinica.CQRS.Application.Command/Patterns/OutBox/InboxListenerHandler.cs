// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeApplicationSagaQueueWorkers
// </yeshua>

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
                ("audio.transcribed.inbox", "PsychologySessionInsightSaga", "AudioTranscriptRequested") => true,
        ("text.summarized.inbox", "PsychologySessionInsightSaga", "ReportEndProntuaryRequested") => true,

        _ => false
    };
    private static bool IsDeclaredContract(string contract, string saga, string step) => (contract, saga, step) switch
    {
                ("audio.transcribed", "PsychologySessionInsightSaga", "AudioTranscriptRequested") => true,
        ("text.summarized", "PsychologySessionInsightSaga", "ReportEndProntuaryRequested") => true,

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
//Dominio.Schemas.CQRS.SourceCodeApplicationSagaQueueWorkers