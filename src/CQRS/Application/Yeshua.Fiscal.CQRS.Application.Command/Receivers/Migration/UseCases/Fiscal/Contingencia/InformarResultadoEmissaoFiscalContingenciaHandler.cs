// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

// Escopo: fiscal.contingencia.resultado-emissao.informar
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
    public partial class InformarResultadoEmissaoFiscalContingenciaHandler : ReciverBase< InformarResultadoEmissaoFiscalContingenciaInputCommand, InformarResultadoEmissaoFiscalContingenciaOutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        private readonly Command.Interfaces.ISagaStepInvoker _sagaStepInvoker;
        public InformarResultadoEmissaoFiscalContingenciaHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context,
            Command.Interfaces.ISagaStepInvoker sagaStepInvoker)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
            _sagaStepInvoker = sagaStepInvoker;
        }


        protected override async Task<State<InformarResultadoEmissaoFiscalContingenciaOutputCommand>> ActionAsync(InformarResultadoEmissaoFiscalContingenciaInputCommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                 State<InformarResultadoEmissaoFiscalContingenciaOutputCommand> retorno = Success("OK", null);
                 return await _sagaStepInvoker.Invoke(
                     "ContingenciaFiscalStandard",
                     "aguardarResultadoEmissaoFiscal",
                     "Async",
                     comand,
                     retorno,
                     CustomActionHookAsync,
                     cancellationToken);
            }
            catch (ReceiverException<InformarResultadoEmissaoFiscalContingenciaOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
protected partial Task<State<InformarResultadoEmissaoFiscalContingenciaOutputCommand>> CustomActionHookAsync(State<InformarResultadoEmissaoFiscalContingenciaOutputCommand> state, InformarResultadoEmissaoFiscalContingenciaInputCommand comand, CancellationToken cancellationToken);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers