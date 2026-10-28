// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

// Escopo: clinica.atendimentos.configurar
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
    public partial class ConfirmarServicoClinicaHandler : ReciverBase< ConfirmarServicoClinicaInputCommand, ConfirmarServicoClinicaOutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        private readonly Command.Interfaces.ISagaStepInvoker _sagaStepInvoker;
        public ConfirmarServicoClinicaHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context,
            Command.Interfaces.ISagaStepInvoker sagaStepInvoker)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
            _sagaStepInvoker = sagaStepInvoker;
        }


        protected override async Task<State<ConfirmarServicoClinicaOutputCommand>> ActionAsync(ConfirmarServicoClinicaInputCommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                 State<ConfirmarServicoClinicaOutputCommand> retorno = Success("OK");
                 return await _sagaStepInvoker.Invoke(
                     "ConfiguracaoInicialClinica",
                     "definirServicoInicial",
                     "Immediate",
                     comand,
                     retorno,
                     CustomActionHookAsync,
                     cancellationToken);
            }
            catch (ReceiverException<ConfirmarServicoClinicaOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
protected partial Task<State<ConfirmarServicoClinicaOutputCommand>> CustomActionHookAsync(State<ConfirmarServicoClinicaOutputCommand> state, ConfirmarServicoClinicaInputCommand comand, CancellationToken cancellationToken);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers