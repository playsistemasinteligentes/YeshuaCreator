// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

// Escopo: fiscal.documentos-originarios-carga.informar
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
    public partial class InformarDocumentosOriginariosDaCargaHandler : ReciverBase< InformarDocumentosOriginariosDaCargaInputCommand, InformarDocumentosOriginariosDaCargaOutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        public InformarDocumentosOriginariosDaCargaHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context
)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
        }


        protected override async Task<State<InformarDocumentosOriginariosDaCargaOutputCommand>> ActionAsync(InformarDocumentosOriginariosDaCargaInputCommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                 State<InformarDocumentosOriginariosDaCargaOutputCommand> retorno = Success("OK");
                 return await CustomActionHookAsync(retorno, comand, cancellationToken);
            }
            catch (ReceiverException<InformarDocumentosOriginariosDaCargaOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
protected partial Task<State<InformarDocumentosOriginariosDaCargaOutputCommand>> CustomActionHookAsync(State<InformarDocumentosOriginariosDaCargaOutputCommand> state, InformarDocumentosOriginariosDaCargaInputCommand comand, CancellationToken cancellationToken);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers