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
    public partial class InfraSendFileUseCaseReceiver : ReciverBase< InfraSendFileUseCaseInputCommand, InfraSendFileUseCaseOutputCommand>
    {


        protected override State<InfraSendFileUseCaseOutputCommand> Action(InfraSendFileUseCaseInputCommand comand)
        {
            try
            {
                 State<InfraSendFileUseCaseOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<InfraSendFileUseCaseOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<InfraSendFileUseCaseOutputCommand> state, Command.UseCase.InfraSendFileUseCaseInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase