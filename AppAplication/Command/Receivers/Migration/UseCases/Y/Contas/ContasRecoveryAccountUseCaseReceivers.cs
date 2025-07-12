// Escopo: Implemente use case para recuperação de contas, use strategy para implementar os diferentes tipos de mensagens de recuperação, use CustomActionHook
using Command.Commands;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Y_User;
using RepositoryInterfaces.Read.Repository.Y_User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class ContasRecoveryAccountUseCaseReceiver : ReciverBase<object>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IY_UserReadRepository _repReadY_User;
        private readonly IY_UserWriteRepository _repWriteY_User;
        public ContasRecoveryAccountUseCaseReceiver(IUnitOfWork unitOfWork,ILogger logger,IY_UserReadRepository repReadY_User, IY_UserWriteRepository repWriteY_User)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
            _repReadY_User = repReadY_User;
            _repWriteY_User = repWriteY_User;
        }

        protected override State<object> Action(ICommand comand)
        {
            try
            {
                 State<object> retorno = Success("OK", (ContasRecoveryAccountUseCaseCommand)comand);
                 if (comand is Command.Commands.ContasRecoveryAccountUseCaseCommand specificCommand)
                 CustomActionHook(ref retorno, specificCommand);
                 return retorno;
            }
            catch (ReceiverException<object> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<object> state, Command.Commands.ContasRecoveryAccountUseCaseCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase