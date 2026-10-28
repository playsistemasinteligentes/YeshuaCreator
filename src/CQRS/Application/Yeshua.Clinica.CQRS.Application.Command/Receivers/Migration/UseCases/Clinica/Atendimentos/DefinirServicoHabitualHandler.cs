// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

// Escopo: clinica.atendimentos
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
    public partial class DefinirServicoHabitualHandler : ReciverBase< DefinirServicoHabitualInputCommand, DefinirServicoHabitualOutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        public DefinirServicoHabitualHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context
)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
        }


        protected override async Task<State<DefinirServicoHabitualOutputCommand>> ActionAsync(DefinirServicoHabitualInputCommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                 State<DefinirServicoHabitualOutputCommand> retorno = Success("OK");
                 return await CustomActionHookAsync(retorno, comand, cancellationToken);
            }
            catch (ReceiverException<DefinirServicoHabitualOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
protected partial Task<State<DefinirServicoHabitualOutputCommand>> CustomActionHookAsync(State<DefinirServicoHabitualOutputCommand> state, DefinirServicoHabitualInputCommand comand, CancellationToken cancellationToken);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers