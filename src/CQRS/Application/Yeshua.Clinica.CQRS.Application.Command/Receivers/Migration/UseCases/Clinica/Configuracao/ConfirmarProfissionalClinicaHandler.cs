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
    public partial class ConfirmarProfissionalClinicaHandler : ReciverBase< ConfirmarProfissionalClinicaInputCommand, ConfirmarProfissionalClinicaOutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        private readonly Command.Interfaces.ISagaStepInvoker _sagaStepInvoker;
        public ConfirmarProfissionalClinicaHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context,
            Command.Interfaces.ISagaStepInvoker sagaStepInvoker)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
            _sagaStepInvoker = sagaStepInvoker;
        }


        protected override async Task<State<ConfirmarProfissionalClinicaOutputCommand>> ActionAsync(ConfirmarProfissionalClinicaInputCommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                 State<ConfirmarProfissionalClinicaOutputCommand> retorno = Success("OK");
                 return await _sagaStepInvoker.Invoke(
                     "ConfiguracaoInicialClinica",
                     "vincularProfissionalInicial",
                     "Immediate",
                     comand,
                     retorno,
                     CustomActionHookAsync,
                     cancellationToken);
            }
            catch (ReceiverException<ConfirmarProfissionalClinicaOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
protected partial Task<State<ConfirmarProfissionalClinicaOutputCommand>> CustomActionHookAsync(State<ConfirmarProfissionalClinicaOutputCommand> state, ConfirmarProfissionalClinicaInputCommand comand, CancellationToken cancellationToken);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers