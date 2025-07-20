using Command.Commands;
using Command.Patterns.Command;
using Command.Read;
using Dominio.Entitys;
using Dominio.Interfaces.Strategy;
using IRepository.Read;
using Read.RepositoryInterfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Receivers.UseCase
{
    public partial class ContasRecoveryAccountUseCaseReceiver
    {

        private readonly IINotificationFactory _factory;
        private readonly IMessage _messege;
        private readonly IYuserReadRepository _userRep;
        // Injete a fábrica no construtor
        public ContasRecoveryAccountUseCaseReceiver(IINotificationFactory factory, IMessage messege, IYuserReadRepository userRep)
        {
            _factory = factory;
            _messege = messege;
            _userRep = userRep;
        }

        partial void CustomActionHook(ref State<object> state, Command.UseCase.ContasRecoveryAccountUseCaseCommand command)
        {
            var notification = _factory.GetType(command.typeNotification);
            var us = new YuserReadCommand();
            us.Email = command.email;
            var user = _userRep.getYuser(us);
            _messege.Destination = "teste";

            notification.SendNotification(_messege);

        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase