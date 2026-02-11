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
    public partial class ContasLoginUseCaseReceiver : ReciverBase< ContasLoginUseCaseInputCommand, ContasLoginUseCaseOutputCommand>
    {


        protected override State<ContasLoginUseCaseOutputCommand> Action(ContasLoginUseCaseInputCommand comand)
        {
            try
            {
                 State<ContasLoginUseCaseOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
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