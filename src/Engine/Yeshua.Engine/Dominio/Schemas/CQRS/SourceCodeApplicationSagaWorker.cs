using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public sealed class SourceCodeApplicationSagaWorker : SourceCodeBase
    {
        private readonly bool _inboxWorker;

        public SourceCodeApplicationSagaWorker(bool inboxWorker)
        {
            _inboxWorker = inboxWorker;
        }

        protected override StringBuilder GenerateCode()
        {
            return new StringBuilder(_inboxWorker ? GenerateInboxWorker() : GenerateSagaWorker());
        }

        protected override StringBuilder GenerateCustonCode()
        {
            return new StringBuilder();
        }

        private static string GenerateSagaWorker()
        {
            return """
using Command.Interfaces;
using Command.Patterns.Command;
using Command.Receivers.Migration.Saga;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using RepositoryInterfaces.Patterns.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Patterns
{
    public class SagaStepContinuation : ISagaStepContinuation
    {
        private const int MaxImmediateSteps = 25;
        private readonly SagaResolverRegistry _registry;
        private readonly ISagaExecutor _executor;
        private readonly IySagaReadRepository _sagaReadRepository;
        private readonly IySagaWriteRepository _sagaWriteRepository;
        private readonly IySagaStepReadRepository _sagaStepReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public SagaStepContinuation(
            Aplication.Interfaces.Services.IExecutionContext context,
            SagaResolverRegistry registry,
            ISagaExecutor executor,
            IySagaReadRepository sagaReadRepository,
            IySagaWriteRepository sagaWriteRepository,
            IySagaStepReadRepository sagaStepReadRepository,
            IUnitOfWork unitOfWork)
        {
            _executionContext = context;
            _registry = registry;
            _executor = executor;
            _sagaReadRepository = sagaReadRepository;
            _sagaWriteRepository = sagaWriteRepository;
            _sagaStepReadRepository = sagaStepReadRepository;
            _unitOfWork = unitOfWork;
        }

        public Task ContinueUntilWaitAsync(ISagaStepStimulusOutput stimulus, CancellationToken cancellationToken = default)
        {
            if (stimulus == null || !stimulus.Accepted || stimulus.SagaId <= 0 || stimulus.InboxId <= 0)
                return Task.CompletedTask;

            var lockedBy = $"Immediate_{Environment.MachineName}_{Guid.NewGuid():N}";
            var lockedAt = DateTime.UtcNow;
            var nextExecutionAt = DateTime.UtcNow.AddMinutes(5);

            if (!_sagaReadRepository.TryClaimSagaForExecution(stimulus.SagaId, lockedBy, lockedAt, nextExecutionAt))
                return Task.CompletedTask;

            try
            {
                if (!string.IsNullOrWhiteSpace(stimulus.CorrelationId))
                    _executionContext.SetTraceId(stimulus.CorrelationId);

                _unitOfWork.BeginTran();
                try
                {
                    var applied = _sagaStepReadRepository.SetPendingApplyByInboxId(stimulus.InboxId);
                    _unitOfWork.Commit();

                    if (applied <= 0)
                        return Task.CompletedTask;
                }
                catch
                {
                    _unitOfWork.Rollback();
                    throw;
                }

                RunClaimedSaga(stimulus.SagaId, lockedBy, lockedAt, cancellationToken);
                return Task.CompletedTask;
            }
            finally
            {
                _sagaReadRepository.ReleaseLock(stimulus.SagaId, lockedBy);
            }
        }

        private void RunClaimedSaga(int sagaId, string lockedBy, DateTime lockedAt, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var sagaDto = _sagaReadRepository.GetByIdWithSteps(sagaId);
            if (sagaDto == null)
                return;

            if (sagaDto.tenantid > 0)
                _executionContext.SetTenantId(sagaDto.tenantid);
            if (sagaDto.userid > 0)
                _executionContext.SetUserId(sagaDto.userid);
            if (!string.IsNullOrWhiteSpace(sagaDto.correlationid))
                _executionContext.SetTraceId(sagaDto.correlationid);

            var saga = _registry.Map(sagaDto);
            saga.LockedBy = lockedBy;
            saga.LockedAt = lockedAt;

            if (saga.Status != SagaStatus.InProgress)
                return;

            var current = saga.GetCurrent();
            if (current == null || current.Status == SagaStepStatus.WaitingResponse)
                return;

            var resolver = _registry.Resolve(saga);
            _executor.ExecuteUntilWait(saga, resolver, MaxImmediateSteps);

            if (!saga.IsDirty && saga.Steps.All(step => !step.IsDirty))
                return;

            _unitOfWork.BeginTran();
            try
            {
                _sagaWriteRepository.Save(saga);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }

    public class SagaWorkerCommandHandler : ReciverBase<InputCommand, OutputCommand>
    {
        private readonly SagaResolverRegistry _registry;
        private readonly ISagaExecutor _executor;
        private readonly IySagaReadRepository _sagaReadRepository;
        private readonly IySagaWriteRepository _sagaWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public SagaWorkerCommandHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context,
            SagaResolverRegistry registry,
            ISagaExecutor executor,
            IySagaReadRepository sagaReadRepository,
            IySagaWriteRepository sagaWriteRepository,
            IUnitOfWork unitOfWork)
            : base(logger, context)
        {
            _registry = registry;
            _executor = executor;
            _sagaReadRepository = sagaReadRepository;
            _sagaWriteRepository = sagaWriteRepository;
            _unitOfWork = unitOfWork;
            _executionContext = context;
        }

        protected override async Task<State<OutputCommand>> ActionAsync(InputCommand command, CancellationToken cancellationToken = default)
        {
            try
            {
                var processed = 0;
                var failed = 0;
                var lockedBy = $"Worker_{Environment.MachineName}";
                var lockedAt = DateTime.UtcNow;
                var nextExecutionAt = DateTime.UtcNow.AddMinutes(5);

                var sagas = _sagaReadRepository
                    .ClaimRunnableSagas(5, lockedBy, lockedAt, nextExecutionAt)
                    .ToList();

                foreach (var sagaDto in sagas)
                {
                    string sagaId = string.Empty;

                    try
                    {
                        if (sagaDto.tenantid > 0)
                            _executionContext.SetTenantId(sagaDto.tenantid);
                        if (sagaDto.userid > 0)
                            _executionContext.SetUserId(sagaDto.userid);
                        if (!string.IsNullOrWhiteSpace(sagaDto.correlationid))
                            _executionContext.SetTraceId(sagaDto.correlationid);

                        var saga = _registry.Map(sagaDto);
                        sagaId = saga.CorrelationId.ToString();
                        saga.LockedBy = lockedBy;
                        saga.LockedAt = lockedAt;

                        if (saga.Status != SagaStatus.InProgress)
                            continue;

                        var current = saga.GetCurrent();
                        if (current == null)
                            continue;

                        var resolver = _registry.Resolve(saga);
                        _executor.Execute(saga, resolver);

                        if (!saga.IsDirty && saga.Steps.All(step => !step.IsDirty))
                            continue;

                        _unitOfWork.BeginTran();
                        try
                        {
                            _sagaWriteRepository.Save(saga);
                            _unitOfWork.Commit();
                            processed++;
                        }
                        catch
                        {
                            _unitOfWork.Rollback();
                            throw;
                        }
                    }
                    catch (Exception ex)
                    {
                        failed++;
                        Console.WriteLine($"Erro na saga {sagaId}: {ex.Message}");
                    }
                    finally
                    {
                        _sagaReadRepository.ReleaseLock(sagaDto.id, lockedBy);
                    }
                }

                return Success("OK", new OutputCommand
                {
                    Claimed = sagas.Count,
                    Processed = processed,
                    Failed = failed
                });
            }
            catch (ReceiverException<OutputCommand> ex)
            {
                return ex.State;
            }
            catch (Exception ex)
            {
                return Error(ex, default);
            }
        }
    }

    public partial record InputCommand : ICommand
    {
        public List<int> lst { get; set; }
    }

    public partial record OutputCommand : ICommand, IWorkerCycleResult
    {
        public List<int> lst { get; set; }
        public int BatchLimit => 5;
        public int Claimed { get; init; }
        public int Processed { get; init; }
        public int Failed { get; init; }
    }
}
""";
        }

        private static string GenerateInboxWorker()
        {
            return """
using Command.Patterns.Command;
using IRepository.Read;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using RepositoryInterfaces.Patterns.Worker;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Patterns
{
    public class SagaInboxWorkerCommandHandler : ReciverBase<InputCommand, InboxOutputCommand>
    {
        private readonly IySagaStepReadRepository _sagaStepReadRepository;

        public SagaInboxWorkerCommandHandler(
            IySagaStepReadRepository sagaStepReadRepository,
            IUnitOfWork unitOfWork,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _sagaStepReadRepository = sagaStepReadRepository;
        }

        protected override async Task<State<InboxOutputCommand>> ActionAsync(InputCommand command, CancellationToken cancellationToken = default)
        {
            try
            {
                var processed = _sagaStepReadRepository.SetPendingApply();
                return Success("OK", new InboxOutputCommand
                {
                    Claimed = processed,
                    Processed = processed
                });
            }
            catch (ReceiverException<InboxOutputCommand> ex)
            {
                return ex.State;
            }
            catch (Exception ex)
            {
                return Error(ex, default);
            }
        }
    }

    public partial record InboxOutputCommand : ICommand, IWorkerCycleResult
    {
        public int BatchLimit => 0;
        public int Claimed { get; init; }
        public int Processed { get; init; }
        public int Failed { get; init; }
    }

}
""";
        }
    }
}
