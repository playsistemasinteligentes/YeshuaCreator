using Command.Interfaces;
using Command.Patterns.Command;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Saga;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Patterns
{
    public class SagaWorkerCommandHandler : ReciverBase<InputCommand, OutputCommand>
    {
        private readonly ISagaResolverRegistry _registry;
        private readonly ISagaExecutor _executor;
        private readonly IySagaReadRepository _sagaReadRepository;
        private readonly IySagaWriteRepository _sagaWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public SagaWorkerCommandHandler(
                Dominio.Interfaces.ILogger logger,
    Aplication.Interfaces.Services.IExecutionContext context,
            ISagaResolverRegistry registry,
            ISagaExecutor executor,
            IySagaReadRepository sagaReadRepository,
            IySagaWriteRepository sagaWriteRepository,
            IUnitOfWork unitOfWork):base(logger, context)
        {
            _registry = registry;
            _executor = executor;
            _sagaReadRepository = sagaReadRepository;
            _sagaWriteRepository = sagaWriteRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _executionContext = context;
        }

        


        protected override State<OutputCommand> Action(InputCommand comand)
        {
            try
            {
                var lockedBy = $"Worker_{Environment.MachineName}";
                var lockedAt = DateTime.UtcNow;
                var nextExecutionAt = DateTime.UtcNow.AddMinutes(5);

                var sagas = _sagaReadRepository
                    .ClaimRunnableSagas(5, lockedBy, lockedAt, nextExecutionAt);

                foreach (var sagaDto in sagas)
                {
                    string sagaId = string.Empty;

                    try
                    {
                        var saga = _registry.Map(sagaDto);
                        sagaId = saga.CorrelationId.ToString();

                        // 🔒 lock metadata
                        saga.LockedBy = lockedBy;
                        saga.LockedAt = lockedAt;

                        if (saga.Status != SagaStatus.InProgress)
                            continue;

                        var current = saga.GetCurrent();

                        if (current == null)
                            continue;

                        var resolver = _registry.Resolve(saga);

                        // 🔥 EXECUÇÃO CENTRALIZADA
                        _executor.Execute(saga, resolver);

                        // 🔥 só persiste se mudou
                        if (!saga.IsDirty)
                            continue;

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
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro na saga {sagaId}: {ex.Message}");
                    }
                    finally
                    {
                        // 🔓 libera lock SEMPRE
                        _sagaReadRepository.ReleaseLock(sagaDto.id, lockedBy);
                    }
                }

                return Success("OK", null);
            }
            catch (ReceiverException<OutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
    }

    public partial record InputCommand : ICommand
    {
        public List<int> lst { get; set; }
    }

    public partial record OutputCommand : ICommand
    {
        public List<int> lst { get; set; }
    }
}