using System.Threading.Tasks;
using System.Threading;
// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeApplicationSagaWorker
// </yeshua>

using Command.Interfaces;
using Command.Patterns.Command;
using Command.Receivers.Migration.Saga;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using RepositoryInterfaces.Patterns.Worker;

namespace Command.Patterns
{
    public class SagaWorkerCommandHandler : ReciverBase<InputCommand, OutputCommand>
    {
        private readonly SagaResolverRegistry _registry;
        private readonly ISagaExecutor _executor;
        private readonly IySagaReadRepository _sagaReadRepository;
        private readonly IySagaWriteRepository _sagaWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

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

                        if (!saga.IsDirty)
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
}//Dominio.Schemas.CQRS.SourceCodeApplicationSagaWorker