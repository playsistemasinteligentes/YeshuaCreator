using Command.Interfaces;
using Command.Patterns;
using Command.Patterns.Command;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Saga;

namespace Command.Patterns.Saga
{
    public class SagaResumeCommandHandler : ReciverBase<InputSagaResumeCommand, OutputCommand>
    {
        private readonly ISagaResolverRegistry _registry;
        private readonly IySagaReadRepository _sagaReadRepository;
        private readonly IySagaWriteRepository _sagaWriteRepository;

        public SagaResumeCommandHandler(
            ISagaResolverRegistry registry,
            IySagaReadRepository sagaReadRepository,
            IySagaWriteRepository sagaWriteRepository)
        {
            _registry = registry;
            _sagaReadRepository = sagaReadRepository;
            _sagaWriteRepository = sagaWriteRepository;
        }

        protected override State<OutputCommand> Action(InputSagaResumeCommand command)
        {
            string sagaId = string.Empty;

            try
            {
                // 🔥 1. busca saga pelo correlationId
                var sagaDto = _sagaReadRepository.GetByCorrelationId(command.CorrelationId);

                if (sagaDto == null)
                    return Error("Saga não encontrada", null);

                var saga = _registry.Map(sagaDto);
                sagaId = saga.SagaId.ToString();

                // 🔥 2. resume
                saga.Resume(command.CorrelationId);

                // 🔥 3. executa próximo step (opcional mas recomendado)
                var resolver = _registry.Resolve(saga);
                _ = _registry; // só pra deixar claro uso consistente

                // você pode executar imediatamente ou deixar pro worker normal
                // aqui vou executar direto:
                // (se quiser deixar assíncrono, remove isso)
                // _executor.Execute(saga, resolver);

                // 🔥 4. salva
                _sagaWriteRepository.Save(saga);

                return Success("OK", null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao resumir saga {sagaId}: {ex.Message}");
                return Error(ex, null);
            }
        }
    }
    public partial record InputSagaResumeCommand : ICommand
    {
        public string CorrelationId { get; set; }
        public string Payload { get; set; }
    }
}


