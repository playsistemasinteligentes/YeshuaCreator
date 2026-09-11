// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

// Escopo: fiscal.teste.saga-sync.acordar-passo3
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
    public partial class AcordarSagaTesteSyncPasso3Handler : ReciverBase< AcordarSagaTesteSyncPasso3InputCommand, AcordarSagaTesteSyncPasso3OutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        private readonly Command.Interfaces.ISagaStepInvoker _sagaStepInvoker;
        public AcordarSagaTesteSyncPasso3Handler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context,
            Command.Interfaces.ISagaStepInvoker sagaStepInvoker)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
            _sagaStepInvoker = sagaStepInvoker;
        }


        protected override async Task<State<AcordarSagaTesteSyncPasso3OutputCommand>> ActionAsync(AcordarSagaTesteSyncPasso3InputCommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                 State<AcordarSagaTesteSyncPasso3OutputCommand> retorno = Success("OK", null);
                 return await _sagaStepInvoker.Invoke(
                     "TesteSync",
                     "testeSyncPasso3",
                     "Deferred",
                     comand,
                     retorno,
                     CustomActionHookAsync,
                     cancellationToken);
            }
            catch (ReceiverException<AcordarSagaTesteSyncPasso3OutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
protected partial Task<State<AcordarSagaTesteSyncPasso3OutputCommand>> CustomActionHookAsync(State<AcordarSagaTesteSyncPasso3OutputCommand> state, AcordarSagaTesteSyncPasso3InputCommand comand, CancellationToken cancellationToken);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers