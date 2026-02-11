// Escopo: Criar um tenant, e um user baseado command(string idcompany, string email, string phone, string password, string confirmpassword), controlar transação.
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
    public partial class ContasCreateContaUseCaseReceiver : ReciverBase< ContasCreateContaUseCaseInputCommand, ContasCreateContaUseCaseOutputCommand>
    {


        protected override State<ContasCreateContaUseCaseOutputCommand> Action(ContasCreateContaUseCaseInputCommand comand)
        {
            try
            {
                 State<ContasCreateContaUseCaseOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<ContasCreateContaUseCaseOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<ContasCreateContaUseCaseOutputCommand> state, Command.UseCase.ContasCreateContaUseCaseInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase