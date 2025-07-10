using Command.Commands;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using RepositoryInterfaces.Strategy;
//using using Repositorio.Inputs.Repositorio.Implemente use case para recuperação de contas, use strategy para implementar os diferentes tipos de mensagens de recuperação, use CustomActionHook;

namespace Command.Receivers.UseCase
{
    public partial class ContasRecoveryAccountUseCaseReceiver
    {
        private readonly INotificationFactory _NotificationFactory;

        public ContasRecoveryAccountUseCaseReceiver(INotificationFactory notificationFactory)
        {
            _NotificationFactory = notificationFactory;
        }

        partial void CustomActionHook(ref State<object> state, Command.Commands.ContasRecoveryAccountUseCaseCommand comand)
        {
            var teste = _NotificationFactory.GetType(comand.typeNotification);
            teste.SendNotification(null);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase