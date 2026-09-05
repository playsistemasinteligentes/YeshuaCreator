using Aplication.Interfaces.Services;
using Command.Patterns.Command;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using IRepository.Write;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using RepositoryInterfaces.Patterns.Worker;
using System.Text.Json;

namespace Worker.Custon;

public sealed class YeshuaModuleInboxSagaBridgeWorker
    : ReciverBase<YeshuaModuleInboxSagaBridgeInputCommand, YeshuaModuleInboxSagaBridgeOutputCommand>
{
    private const int Pending = 0;
    private const int Processing = 3;
    private const int Applied = 1;
    private const int DeadLetter = 9;
    private const string StartFiscalSagaEvent = "CargaProntaParaEmissaoFiscal.v1";
    private const string FiscalSagaType = nameof(EmissaoFiscalCargaStandardSaga);

    private readonly IUnitOfWork _unitOfWork;
    private readonly IySagaWriteRepository _sagaWriteRepository;

    public YeshuaModuleInboxSagaBridgeWorker(
        IUnitOfWork unitOfWork,
        IySagaWriteRepository sagaWriteRepository,
        Dominio.Interfaces.ILogger logger,
        IExecutionContext context)
        : base(logger, context)
    {
        _unitOfWork = unitOfWork;
        _sagaWriteRepository = sagaWriteRepository;
    }

    protected override Task<State<YeshuaModuleInboxSagaBridgeOutputCommand>> ActionAsync(
        YeshuaModuleInboxSagaBridgeInputCommand command,
        CancellationToken cancellationToken = default)
    {
        var claimed = ClaimStartEvents(command.Limit <= 0 ? 10 : command.Limit).ToList();
        var processed = 0;
        var failed = 0;

        foreach (var inbox in claimed)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                StartSagaFromInbox(inbox);
                processed++;
            }
            catch (Exception ex)
            {
                failed++;
                MarkDeadLetter(inbox.id, ex.Message);
            }
        }

        return Task.FromResult(Success("OK", new YeshuaModuleInboxSagaBridgeOutputCommand
        {
            Claimed = claimed.Count,
            Processed = processed,
            Failed = failed
        }));
    }

    private IEnumerable<yInboxDTO> ClaimStartEvents(int limit)
    {
        const string sql = @"
            WITH NextInbox AS
            (
                SELECT TOP (@Limit) *
                  FROM [yInbox] WITH (UPDLOCK, READPAST, ROWLOCK)
                 WHERE [Status] = @Pending
                   AND [Type] = @Type
                 ORDER BY [CreatedAt]
            )
            UPDATE NextInbox
               SET [Status] = @Processing,
                   [ProcessingAt] = @Now,
                   [RetryCount] = ISNULL([RetryCount], 0) + 1
            OUTPUT inserted.*;";

        return _unitOfWork.Query<yInboxDTO>(sql, new
        {
            Limit = limit,
            Pending,
            Processing,
            Type = StartFiscalSagaEvent,
            Now = DateTime.UtcNow
        });
    }

    private void StartSagaFromInbox(yInboxDTO inbox)
    {
        var correlationId = ExtractSagaCorrelationId(inbox.payload);

        _unitOfWork.BeginTran();
        try
        {
            if (FiscalSagaAlreadyStarted(correlationId))
            {
                MarkApplied(inbox.id, null, null);
                _unitOfWork.Commit();
                return;
            }

            var saga = new EmissaoFiscalCargaStandardSaga
            {
                CreatedAt = DateTime.UtcNow,
                NextExecutionAt = DateTime.UtcNow,
                LockedAt = DateTime.MinValue,
                LockedBy = null
            };

            saga.SetCorrelationId(correlationId);
            saga.Start(inbox.entityid, "Carga");

            var step = saga.GetCurrent();
            if (step == null)
                throw new InvalidOperationException("Saga fiscal nao possui step inicial.");

            step.SetPayload(inbox.payload);
            step.SetPendingApply();

            _sagaWriteRepository.Save(saga);
            MarkApplied(inbox.id, saga.Id, step.Id);
            _unitOfWork.Commit();
        }
        catch
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    private bool FiscalSagaAlreadyStarted(string correlationId)
    {
        const string sql = @"
            SELECT COUNT(1)
              FROM [ySaga]
             WHERE [CorrelationId] = @CorrelationId
               AND [Type] = @Type;";

        return _unitOfWork.ExecuteScalar<int>(sql, new
        {
            CorrelationId = correlationId,
            Type = FiscalSagaType
        }) > 0;
    }

    private void MarkApplied(int inboxId, int? sagaId, int? sagaStepId)
    {
        const string sql = @"
            UPDATE [yInbox]
               SET [Status] = @Applied,
                   [SagaId] = COALESCE(@SagaId, [SagaId]),
                   [SagaStepId] = COALESCE(@SagaStepId, [SagaStepId])
             WHERE [Id] = @InboxId;";

        _unitOfWork.Execute(sql, new
        {
            Applied,
            SagaId = sagaId,
            SagaStepId = sagaStepId,
            InboxId = inboxId
        });
    }

    private void MarkDeadLetter(int inboxId, string error)
    {
        const string sql = @"
            UPDATE [yInbox]
               SET [Status] = @DeadLetter,
                   [LastError] = @Error
             WHERE [Id] = @InboxId;";

        _unitOfWork.Execute(sql, new
        {
            DeadLetter,
            Error = error,
            InboxId = inboxId
        });
    }

    private static string ExtractSagaCorrelationId(string payload)
    {
        if (!string.IsNullOrWhiteSpace(payload))
        {
            using var document = JsonDocument.Parse(payload);
            if (document.RootElement.TryGetProperty("sagaCorrelationId", out var property))
            {
                var value = property.GetString();
                if (Guid.TryParse(value, out var guid))
                    return guid.ToString();
            }
        }

        return Guid.NewGuid().ToString();
    }
}

public sealed record YeshuaModuleInboxSagaBridgeInputCommand : ICommand
{
    public int Limit { get; init; } = 10;
}

public sealed record YeshuaModuleInboxSagaBridgeOutputCommand : ICommand, IWorkerCycleResult
{
    public int BatchLimit => 10;
    public int Claimed { get; init; }
    public int Processed { get; init; }
    public int Failed { get; init; }
}
