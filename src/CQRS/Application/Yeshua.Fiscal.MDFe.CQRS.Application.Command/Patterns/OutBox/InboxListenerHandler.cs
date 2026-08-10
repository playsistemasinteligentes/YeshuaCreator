using Command.Interfaces;
using Command.Patterns.Command;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Saga;
using System.Text.Json;

namespace Command.Patterns.OutBox
{
    public class InboxListenerHandler : ReciverBase<InboxInputCommand, InboxOutputCommand>
    {
        private readonly ISagaResolverRegistry _registry;
        private readonly IySagaReadRepository _sagaReadRepository;
        private readonly IySagaWriteRepository _sagaWriteRepository;
        private readonly OutboxService _inboxService;
        private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InboxListenerHandler(
            ISagaResolverRegistry registry,
            IySagaReadRepository sagaReadRepository,
            IySagaWriteRepository sagaWriteRepository,
            OutboxService inboxService,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _registry = registry;
            _sagaReadRepository = sagaReadRepository;
            _sagaWriteRepository = sagaWriteRepository;
            _inboxService = inboxService;
            _logger = logger;
            _executionContext = context;
        }
        protected override State<InboxOutputCommand> Action(InboxInputCommand command)
        {
            try
            {
                var hasResult = command.result.ValueKind != JsonValueKind.Null &&
                                command.result.ValueKind != JsonValueKind.Undefined;

                var payload = hasResult
                    ? command.result
                    : command.error;

                _inboxService.AddInboxEvent(
                    type: command.status,
                    payload: payload,
                    entityType: "SagaStep",
                    entityID: string.Empty,
                    messageId: command.messageId, // 🔥 vem do Python agora
                    correlationId: command.correlationId
                );

                return Success("Inbox registrado com sucesso", new InboxOutputCommand());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao incluir inbox: {ex.Message}");
                return Error(ex, null);
            }
        }
    }
    public partial record InboxInputCommand : ICommand
    {
        public string messageId { get; set; }   // 🔥 novo
        public string correlationId { get; set; }
        public string status { get; set; }

        public JsonElement result { get; set; }
        public JsonElement error { get; set; }
    }

    public partial record InboxOutputCommand : ICommand
    {
        public List<int> lst { get; set; }
    }
}


