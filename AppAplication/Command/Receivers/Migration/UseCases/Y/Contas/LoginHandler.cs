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
    public partial class LoginHandler : ReciverBase< LoginInputCommand, LoginOutputCommand>
    {


        protected override State<LoginOutputCommand> Action(LoginInputCommand comand)
        {
            try
            {
                 State<LoginOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<LoginOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<LoginOutputCommand> state, Command.UseCase.LoginInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase