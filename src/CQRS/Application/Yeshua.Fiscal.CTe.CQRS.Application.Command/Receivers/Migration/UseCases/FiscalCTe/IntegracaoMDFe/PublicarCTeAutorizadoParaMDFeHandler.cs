// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

// Escopo: cte.mdfe.publicar
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
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class PublicarCTeAutorizadoParaMDFeHandler : ReciverBase< PublicarCTeAutorizadoParaMDFeInputCommand, PublicarCTeAutorizadoParaMDFeOutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        public PublicarCTeAutorizadoParaMDFeHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
        }


        protected override async Task<State<PublicarCTeAutorizadoParaMDFeOutputCommand>> ActionAsync(PublicarCTeAutorizadoParaMDFeInputCommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                 State<PublicarCTeAutorizadoParaMDFeOutputCommand> retorno = Success("OK", null);
                 return await CustomActionHookAsync(retorno, comand, cancellationToken);
            }
            catch (ReceiverException<PublicarCTeAutorizadoParaMDFeOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
protected partial Task<State<PublicarCTeAutorizadoParaMDFeOutputCommand>> CustomActionHookAsync(State<PublicarCTeAutorizadoParaMDFeOutputCommand> state, PublicarCTeAutorizadoParaMDFeInputCommand comand, CancellationToken cancellationToken);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers