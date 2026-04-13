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
    public partial class RecoveryAccountHandler : ReciverBase< RecoveryAccountInputCommand, RecoveryAccountOutputCommand>
    {


        protected override State<RecoveryAccountOutputCommand> Action(RecoveryAccountInputCommand comand)
        {
            try
            {
                 State<RecoveryAccountOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<RecoveryAccountOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<RecoveryAccountOutputCommand> state, Command.UseCase.RecoveryAccountInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase