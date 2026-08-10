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

        protected override State<OutputCommand> Action(InputCommand command)
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
                        _sagaReadRepository.ReleaseLock(sagaDto.id, lockedBy);
                    }
                }

                return Success("OK", null);
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

    public partial record OutputCommand : ICommand
    {
        public List<int> lst { get; set; }
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

namespace Command.Patterns
{
    public class SagaInboxWorkerCommandHandler : ReciverBase<InputCommand, OutputCommand>
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

        protected override State<OutputCommand> Action(InputCommand command)
        {
            try
            {
                _sagaStepReadRepository.SetPendingApply();
                return Success("OK", null);
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
}
""";
        }
    }
}
