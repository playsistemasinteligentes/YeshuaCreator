// Escopo: 
using Command.Commands;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class ContasLoginUseCaseReceiver : ReciverBase<object>
    {


        protected override State<object> Action(ICommand comand)
        {
            try
            {
                 State<object> retorno = Success("OK", (ContasLoginUseCaseCommand)comand);
                 if (comand is Command.Commands.ContasLoginUseCaseCommand specificCommand)
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
partial void CustomActionHook(ref State<object> state, Command.Commands.ContasLoginUseCaseCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase