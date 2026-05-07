// Escopo: Criar um tenant, e um user baseado command(string idcompany, string email, string phone, string password, string confirmpassword), controlar transação.
using Command.Write;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Dominio.Interfaces;
using Command.UseCase;
using Command.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class CreateContaHandler : ReciverBase< CreateContaInputCommand, CreateContaOutputCommand>
    {

        public CreateContaHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
        }


        protected override State<CreateContaOutputCommand> Action(CreateContaInputCommand comand)
        {
            try
            {
                 State<CreateContaOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<CreateContaOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<CreateContaOutputCommand> state, CreateContaInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers