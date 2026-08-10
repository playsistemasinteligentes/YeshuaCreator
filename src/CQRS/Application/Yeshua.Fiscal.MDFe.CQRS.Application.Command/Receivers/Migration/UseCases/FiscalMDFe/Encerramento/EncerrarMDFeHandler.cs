// Escopo: mdfe.encerrar
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
    public partial class EncerrarMDFeHandler : ReciverBase< EncerrarMDFeInputCommand, EncerrarMDFeOutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        public EncerrarMDFeHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
        }


        protected override State<EncerrarMDFeOutputCommand> Action(EncerrarMDFeInputCommand comand)
        {
            try
            {
                 State<EncerrarMDFeOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<EncerrarMDFeOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<EncerrarMDFeOutputCommand> state, EncerrarMDFeInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers