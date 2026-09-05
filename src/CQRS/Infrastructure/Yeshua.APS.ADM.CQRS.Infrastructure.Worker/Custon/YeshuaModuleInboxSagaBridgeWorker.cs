using Aplication.Interfaces.Services;
using Command.Patterns.Command;
using Dominio.Saga;
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
    private const string ApsSagaType = nameof(CargaStandardSaga);
    private const string ApsWaitingFiscalStep = CargaStandardSaga.STEP_5;

    private static readonly string[] FiscalReturnEvents =
    [
        "DocumentosFiscaisDaCargaConcluidos.v1",
        "MDFeEncerrado.v1"
    ];

    private readonly IUnitOfWork _unitOfWork;

    public YeshuaModuleInboxSagaBridgeWorker(
        IUnitOfWork unitOfWork,
        Dominio.Interfaces.ILogger logger,
        IExecutionContext context)
        : base(logger, context)
    {
        _unitOfWork = unitOfWork;
    }

    protected override Task<State<YeshuaModuleInboxSagaBridgeOutputCommand>> ActionAsync(
        YeshuaModuleInboxSagaBridgeInputCommand command,
        CancellationToken cancellationToken = default)
    {
        var claimed = ClaimFiscalReturnEvents(command.Limit <= 0 ? 10 : command.Limit).ToList();
        var processed = 0;
        var failed = 0;

        foreach (var inbox in claimed)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                ApplyFiscalReturn(inbox);
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

    private IEnumerable<yInboxDTO> ClaimFiscalReturnEvents(int limit)
    {
        const string sql = @"
            WITH NextInbox AS
            (
                SELECT TOP (@Limit) i.*
                  FROM [yInbox] i WITH (UPDLOCK, READPAST, ROWLOCK)
                 WHERE i.[Status] = @Pending
                   AND i.[Type] IN @Types
                   AND EXISTS
                   (
                       SELECT 1
                         FROM [ySaga] s
                        INNER JOIN [ySagaStep] st ON st.[SagaId] = s.[Id]
                        WHERE s.[CorrelationId] = JSON_VALUE(i.[Payload], '$.sagaCorrelationId')
                          AND s.[Type] = @SagaType
                          AND st.[StepKey] = @StepKey
                          AND st.[Status] = 3
                   )
                 ORDER BY i.[CreatedAt]
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
            Types = FiscalReturnEvents,
            SagaType = ApsSagaType,
            StepKey = ApsWaitingFiscalStep,
            Now = DateTime.UtcNow
        });
    }

    private void ApplyFiscalReturn(yInboxDTO inbox)
    {
        var sagaCorrelationId = ExtractSagaCorrelationId(inbox.payload);

        _unitOfWork.BeginTran();
        try
        {
            const string sql = @"
                UPDATE st
                   SET st.[Status] = 4,
                       st.[Payload] = @Payload
                  FROM [ySagaStep] st
                 INNER JOIN [ySaga] s ON s.[Id] = st.[SagaId]
                 WHERE s.[CorrelationId] = @SagaCorrelationId
                   AND s.[Type] = @SagaType
                   AND st.[StepKey] = @StepKey
                   AND st.[Status] = 3;";

            var appliedSteps = _unitOfWork.Execute(sql, new
            {
                Payload = inbox.payload,
                SagaCorrelationId = sagaCorrelationId,
                SagaType = ApsSagaType,
                StepKey = ApsWaitingFiscalStep
            });

            if (appliedSteps == 0)
                throw new InvalidOperationException("Nao foi encontrado step APS aguardando retorno fiscal para a correlacao " + sagaCorrelationId + ".");

            const string wakeSagaSql = @"
                UPDATE [ySaga]
                   SET [NextExecutionAt] = SYSUTCDATETIME()
                 WHERE [CorrelationId] = @SagaCorrelationId
                   AND [Type] = @SagaType;";

            _unitOfWork.Execute(wakeSagaSql, new
            {
                SagaCorrelationId = sagaCorrelationId,
                SagaType = ApsSagaType
            });

            MarkApplied(inbox.id);
            _unitOfWork.Commit();
        }
        catch
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    private void MarkApplied(int inboxId)
    {
        const string sql = @"
            UPDATE [yInbox]
               SET [Status] = @Applied
             WHERE [Id] = @InboxId;";

        _unitOfWork.Execute(sql, new
        {
            Applied,
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
        using var document = JsonDocument.Parse(payload);
        if (document.RootElement.TryGetProperty("sagaCorrelationId", out var property))
        {
            var value = property.GetString();
            if (Guid.TryParse(value, out var guid))
                return guid.ToString();
        }

        throw new InvalidOperationException("Payload fiscal sem sagaCorrelationId valido.");
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
