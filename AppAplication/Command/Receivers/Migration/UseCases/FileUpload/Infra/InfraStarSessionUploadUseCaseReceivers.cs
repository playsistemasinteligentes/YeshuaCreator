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
    public partial class InfraStarSessionUploadUseCaseReceiver : ReciverBase< InfraStarSessionUploadUseCaseInputCommand, InfraStarSessionUploadUseCaseOutputCommand>
    {


        protected override State<InfraStarSessionUploadUseCaseOutputCommand> Action(InfraStarSessionUploadUseCaseInputCommand comand)
        {
            try
            {
                 State<InfraStarSessionUploadUseCaseOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<InfraStarSessionUploadUseCaseOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<InfraStarSessionUploadUseCaseOutputCommand> state, Command.UseCase.InfraStarSessionUploadUseCaseInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase