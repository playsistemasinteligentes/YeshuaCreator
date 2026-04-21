using Command.Interfaces;
using Command.Patterns.Command;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Saga;

namespace Command.Patterns
{
    public class SagaWorkerCommandHandler : ReciverBase<InputCommand, OutputCommand>
    {
        private readonly ISagaResolverRegistry _registry;
        private readonly ISagaExecutor _executor;
        private readonly IySagaReadRepository _sagaReadRepository;
        private readonly IySagaWriteRepository _sagaWriteRepository;

        public SagaWorkerCommandHandler(
            ISagaResolverRegistry registry,
            ISagaExecutor executor,
            IySagaReadRepository sagaReadRepository,
            IySagaWriteRepository sagaWriteRepository)
        {
            _registry = registry;
            _executor = executor;
            _sagaReadRepository = sagaReadRepository;
            _sagaWriteRepository = sagaWriteRepository;
        }

        protected override State<OutputCommand> Action(InputCommand comand)
        {
            try
            {
                var workerID = "Worker_0001";
                var sagas = _sagaReadRepository.ClaimRunnableSagas(5, workerID); 


                foreach (var sagaDto in sagas)
                {
                    string SagaId = string.Empty;
                    try
                    {
                        var saga = _registry.Map(sagaDto);
                         SagaId = saga.SagaId.ToString();

                        if (saga.Status != SagaStatus.InProgress)
                            continue;

                        var current = saga.GetCurrent();

                        if (current == null)
                            continue;

                        var resolver = _registry.Resolve(saga);

                        _executor.Execute(saga, resolver);

                        _sagaWriteRepository.Save(saga);

                        _sagaReadRepository.ReleaseLock(saga.Id, workerID);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro na saga {SagaId}: {ex.Message}");
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