// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

// Escopo: fiscal.contingencia.processamento.consultar
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
    public partial class ConsultarProcessamentoContingenciaFiscalHandler : ReciverBase< ConsultarProcessamentoContingenciaFiscalInputCommand, ConsultarProcessamentoContingenciaFiscalOutputCommand>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        public ConsultarProcessamentoContingenciaFiscalHandler(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context
)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
        }


        protected override async Task<State<ConsultarProcessamentoContingenciaFiscalOutputCommand>> ActionAsync(ConsultarProcessamentoContingenciaFiscalInputCommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                 State<ConsultarProcessamentoContingenciaFiscalOutputCommand> retorno = Success("OK");
                 return await CustomActionHookAsync(retorno, comand, cancellationToken);
            }
            catch (ReceiverException<ConsultarProcessamentoContingenciaFiscalOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
protected partial Task<State<ConsultarProcessamentoContingenciaFiscalOutputCommand>> CustomActionHookAsync(State<ConsultarProcessamentoContingenciaFiscalOutputCommand> state, ConsultarProcessamentoContingenciaFiscalInputCommand comand, CancellationToken cancellationToken);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers