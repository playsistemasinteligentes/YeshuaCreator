// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

// Escopo: fiscal.mdfe.utilitarios.xml.obter
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
    public partial class ObterXmlMDFeHandler : ReciverBase< ObterXmlMDFeInputCommand, ObterXmlMDFeOutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        public ObterXmlMDFeHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context
)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
        }


        protected override async Task<State<ObterXmlMDFeOutputCommand>> ActionAsync(ObterXmlMDFeInputCommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                 State<ObterXmlMDFeOutputCommand> retorno = Success("OK");
                 return await CustomActionHookAsync(retorno, comand, cancellationToken);
            }
            catch (ReceiverException<ObterXmlMDFeOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
protected partial Task<State<ObterXmlMDFeOutputCommand>> CustomActionHookAsync(State<ObterXmlMDFeOutputCommand> state, ObterXmlMDFeInputCommand comand, CancellationToken cancellationToken);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers