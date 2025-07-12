using Command.Commands;
using Command.Patterns.Command;
using Dominio.Interfaces.Strategy;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Receivers.UseCase
{
    public partial class ContasRecoveryAccountUseCaseReceiver
    {

        private readonly IINotificationFactory _factory;
        // Injete a fábrica no construtor
        public ContasRecoveryAccountUseCaseReceiver(IINotificationFactory factory)
        {
            _factory = factory;
        }

        partial void CustomActionHook(ref State<object> state, Command.Commands.ContasRecoveryAccountUseCaseCommand command)
        {
            var notification = _factory.GetType(command.typeNotification);

            
            notification.SendNotification(new Message());

        }
    }
    public class Message : IMessage
    {
        public string Destination { get; set; }
        public string Body { get; set; }
        public string? Subject { get; set; } = null;
        public byte[]? Attachment { get; set; } = null;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase