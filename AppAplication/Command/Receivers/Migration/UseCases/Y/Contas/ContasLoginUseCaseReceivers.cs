// Escopo: 
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
    public partial class ContasLoginUseCaseReceiver : ReciverBase<ContasLoginUseCaseOutputCommand>
    {


        protected override State<ContasLoginUseCaseOutputCommand> Action(ICommand comand)
        {
            try
            {
                 State<ContasLoginUseCaseOutputCommand> retorno = Success("OK", null);
                 if (comand is Command.UseCase.ContasLoginUseCaseInputCommand specificCommand)
                 CustomActionHook(ref retorno, specificCommand);
                 return retorno;
            }
            catch (ReceiverException<ContasLoginUseCaseOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<ContasLoginUseCaseOutputCommand> state, Command.UseCase.ContasLoginUseCaseInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase