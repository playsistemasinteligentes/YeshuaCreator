using Command.UseCase;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
namespace Command.Receivers.UseCase;
public partial class RetrySagaStepHandler
{
    private readonly IUnitOfWork _work;
    private readonly IySagaStepWriteRepository _steps;
    public RetrySagaStepHandler(IUnitOfWork work, IySagaStepWriteRepository steps,
        Dominio.Interfaces.ILogger logger, Aplication.Interfaces.Services.IExecutionContext context) : base(logger, context)
        { _work = work; _steps = steps; _logger = logger; _executionContext = context; }
    protected partial Task<State<RetrySagaStepOutputCommand>> CustomActionHookAsync(
        State<RetrySagaStepOutputCommand> state, RetrySagaStepInputCommand command, CancellationToken cancellationToken)
    {
        _work.BeginTran();
        try
        {
            var key = _steps.RetryFailedStep(command.SagaId, command.SagaStepId,
                _executionContext.TenantID, _executionContext.UserId, _executionContext.ProcessingScope);
            if (key is null)
            {
                _work.Rollback();
                return Task.FromResult(ValidationError("Somente o step em falha do processamento atual pode ser reaberto.", new RetrySagaStepOutputCommand()));
            }
            _work.Commit();
            return Task.FromResult(Success("Retomada agendada para o Worker.", new RetrySagaStepOutputCommand
                { SagaId = command.SagaId, SagaStepId = command.SagaStepId, StepKey = key, Status = "Pending" }));
        }
        catch { _work.Rollback(); throw; }
    }
}
