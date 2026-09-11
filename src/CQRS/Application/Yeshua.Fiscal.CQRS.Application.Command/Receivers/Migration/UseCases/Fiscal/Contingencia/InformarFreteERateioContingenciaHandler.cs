// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

// Escopo: fiscal.contingencia.frete.informar
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
    public partial class InformarFreteERateioContingenciaHandler : ReciverBase< InformarFreteERateioContingenciaInputCommand, InformarFreteERateioContingenciaOutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        private readonly Command.Interfaces.ISagaStepInvoker _sagaStepInvoker;
        public InformarFreteERateioContingenciaHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context,
            Command.Interfaces.ISagaStepInvoker sagaStepInvoker)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
            _sagaStepInvoker = sagaStepInvoker;
        }


        protected override async Task<State<InformarFreteERateioContingenciaOutputCommand>> ActionAsync(InformarFreteERateioContingenciaInputCommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                 State<InformarFreteERateioContingenciaOutputCommand> retorno = Success("OK", null);
                 return await _sagaStepInvoker.Invoke(
                     "ContingenciaFiscalStandard",
                     "informarFreteERateio",
                     "Sync",
                     comand,
                     retorno,
                     CustomActionHookAsync,
                     cancellationToken);
            }
            catch (ReceiverException<InformarFreteERateioContingenciaOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
protected partial Task<State<InformarFreteERateioContingenciaOutputCommand>> CustomActionHookAsync(State<InformarFreteERateioContingenciaOutputCommand> state, InformarFreteERateioContingenciaInputCommand comand, CancellationToken cancellationToken);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers