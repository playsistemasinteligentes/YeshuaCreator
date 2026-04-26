using Command.Interfaces;
using Command.Patterns.Command;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Saga;

namespace Command.Patterns.OutBox
{
    public class InboxListenerHandler : ReciverBase<InboxInputCommand, InboxOutputCommand>
    {
        private readonly ISagaResolverRegistry _registry;
        private readonly IySagaReadRepository _sagaReadRepository;
        private readonly IySagaWriteRepository _sagaWriteRepository;

        public InboxListenerHandler(
            ISagaResolverRegistry registry,
            IySagaReadRepository sagaReadRepository,
            IySagaWriteRepository sagaWriteRepository)
        {
            _registry = registry;
            _sagaReadRepository = sagaReadRepository;
            _sagaWriteRepository = sagaWriteRepository;
        }

        protected override State<InboxOutputCommand> Action(InboxInputCommand command)
        {

            try
            {
               
                return Success("OK", null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao incluir inbox");
                return Error(ex, null);
            }
        }
    }
    public partial record InboxInputCommand : ICommand
    {
        public string CorrelationId { get; set; }
        public string Payload { get; set; }
    }
    public partial record InboxOutputCommand : ICommand
    {
        public List<int> lst { get; set; }
    }
}


