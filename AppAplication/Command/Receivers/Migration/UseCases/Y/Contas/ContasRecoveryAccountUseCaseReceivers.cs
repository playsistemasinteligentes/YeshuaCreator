// Escopo: Implemente use case para recuperação de contas, use strategy para implementar os diferentes tipos de mensagens de recuperação, use CustomActionHook
using Command.Write;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Dominio.Interfaces;
using Command.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class ContasRecoveryAccountUseCaseReceiver : ReciverBase<ContasRecoveryAccountUseCaseOutputCommand>
    {


        protected override State<ContasRecoveryAccountUseCaseOutputCommand> Action(ICommand comand)
        {
            try
            {
                 State<ContasRecoveryAccountUseCaseOutputCommand> retorno = Success("OK", null);
                 if (comand is Command.UseCase.ContasRecoveryAccountUseCaseInputCommand specificCommand)
                 CustomActionHook(ref retorno, specificCommand);
                 return retorno;
            }
            catch (ReceiverException<ContasRecoveryAccountUseCaseOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<ContasRecoveryAccountUseCaseOutputCommand> state, Command.UseCase.ContasRecoveryAccountUseCaseInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase