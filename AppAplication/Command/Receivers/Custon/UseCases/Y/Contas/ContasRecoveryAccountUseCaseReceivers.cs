using Command.Commands;
using Command.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces.Strategy;
using Read.RepositoryInterfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Receivers.UseCase
{
    public partial class ContasRecoveryAccountUseCaseReceiver
    {

        private readonly IINotificationFactory _factory;
        private readonly IMessage _messege;
        private readonly IY_UserReadRepository _userRep;
        // Injete a fábrica no construtor
        public ContasRecoveryAccountUseCaseReceiver(IINotificationFactory factory, IMessage messege, IY_UserReadRepository userRep)
        {
            _factory = factory;
            _messege = messege;
            _userRep = userRep;
        }

        partial void CustomActionHook(ref State<object> state, Command.Commands.ContasRecoveryAccountUseCaseCommand command)
        {
            var notification = _factory.GetType(command.typeNotification);
            var us = new Command.Commands.Read.Y_UserReadCommand();
            us.Email = command.email;
            var user = _userRep.getY_User(us);
            _messege.Destination = "teste";

            notification.SendNotification(_messege);

        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase