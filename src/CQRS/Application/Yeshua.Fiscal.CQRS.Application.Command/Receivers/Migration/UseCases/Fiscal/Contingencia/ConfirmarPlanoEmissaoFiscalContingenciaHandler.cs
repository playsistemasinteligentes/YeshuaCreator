// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

// Escopo: fiscal.contingencia.plano.confirmar
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
    public partial class ConfirmarPlanoEmissaoFiscalContingenciaHandler : ReciverBase< ConfirmarPlanoEmissaoFiscalContingenciaInputCommand, ConfirmarPlanoEmissaoFiscalContingenciaOutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        private readonly Command.Interfaces.ISagaStepInvoker _sagaStepInvoker;
        public ConfirmarPlanoEmissaoFiscalContingenciaHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context,
            Command.Interfaces.ISagaStepInvoker sagaStepInvoker)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
            _sagaStepInvoker = sagaStepInvoker;
        }


        protected override async Task<State<ConfirmarPlanoEmissaoFiscalContingenciaOutputCommand>> ActionAsync(ConfirmarPlanoEmissaoFiscalContingenciaInputCommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                 State<ConfirmarPlanoEmissaoFiscalContingenciaOutputCommand> retorno = Success("OK", null);
                 return await _sagaStepInvoker.Invoke(
                     "ContingenciaFiscalStandard",
                     "confirmarPlanoEmissaoFiscal",
                     "Sync",
                     comand,
                     retorno,
                     CustomActionHookAsync,
                     cancellationToken);
            }
            catch (ReceiverException<ConfirmarPlanoEmissaoFiscalContingenciaOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
protected partial Task<State<ConfirmarPlanoEmissaoFiscalContingenciaOutputCommand>> CustomActionHookAsync(State<ConfirmarPlanoEmissaoFiscalContingenciaOutputCommand> state, ConfirmarPlanoEmissaoFiscalContingenciaInputCommand comand, CancellationToken cancellationToken);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers