// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

// Escopo: fiscal.contingencia.transporte.informar
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
    public partial class InformarDadosTransporteContingenciaHandler : ReciverBase< InformarDadosTransporteContingenciaInputCommand, InformarDadosTransporteContingenciaOutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        private readonly Command.Interfaces.ISagaStepInvoker _sagaStepInvoker;
        public InformarDadosTransporteContingenciaHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context,
            Command.Interfaces.ISagaStepInvoker sagaStepInvoker)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
            _sagaStepInvoker = sagaStepInvoker;
        }


        protected override async Task<State<InformarDadosTransporteContingenciaOutputCommand>> ActionAsync(InformarDadosTransporteContingenciaInputCommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                 State<InformarDadosTransporteContingenciaOutputCommand> retorno = Success("OK", null);
                 return await _sagaStepInvoker.Invoke(
                     "ContingenciaFiscalStandard",
                     "informarDadosTransporte",
                     "Immediate",
                     comand,
                     retorno,
                     CustomActionHookAsync,
                     cancellationToken);
            }
            catch (ReceiverException<InformarDadosTransporteContingenciaOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
protected partial Task<State<InformarDadosTransporteContingenciaOutputCommand>> CustomActionHookAsync(State<InformarDadosTransporteContingenciaOutputCommand> state, InformarDadosTransporteContingenciaInputCommand comand, CancellationToken cancellationToken);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers