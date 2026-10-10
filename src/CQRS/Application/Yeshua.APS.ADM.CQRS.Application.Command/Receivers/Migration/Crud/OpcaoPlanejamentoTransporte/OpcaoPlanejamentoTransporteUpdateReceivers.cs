// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration
// </yeshua>

using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Behaviors;
using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Domain;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateOpcaoPlanejamentoTransporteReceiver : ReciverBase<ICommand, IOpcaoPlanejamentoTransporteEntity>
    {
        private readonly IOpcaoPlanejamentoTransporteWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateOpcaoPlanejamentoTransporteReceiver(
            IOpcaoPlanejamentoTransporteWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Dominio.Interfaces.IDomainTrackingPolicy domainTrackingPolicy,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _domainTrackingPolicy = domainTrackingPolicy;
            _executionContext = context;
        }

        protected override Task<State<IOpcaoPlanejamentoTransporteEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.OpcaoPlanejamentoTransporteCrudCommand c) 
             {    
                 var trackingMask = _domainTrackingPolicy.GetMask("OpcaoPlanejamentoTransporte", "UpdateOpcaoPlanejamentoTransporte", null);
                 var hasExecutionIdentity = _executionContext.TryGetOperationalIdentity(out var executionIdentity);
                 using var domainTrackingExecutionScope = !hasExecutionIdentity && trackingMask != 0UL ? _executionContext.BeginOperationalExecution("Command.Write.OpcaoPlanejamentoTransporteCrudCommand") : null;
                 if (!hasExecutionIdentity && trackingMask != 0UL)
                     executionIdentity = _executionContext.OperationalIdentity;
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateOpcaoPlanejamentoTransporte", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateOpcaoPlanejamentoTransporteReceiver), commandName: "Command.Write.OpcaoPlanejamentoTransporteCrudCommand", rootOperationId: executionIdentity.RootOperationId, operationId: executionIdentity.OperationId, executionId: executionIdentity.ExecutionId, causationId: executionIdentity.CausationId);
                 var opcaoplanejamentotransporte = new OpcaoPlanejamentoTransporteFactory(_logger, _domainTrackingPolicy).Create(context, c.OpcaoId, c.GrupoDecisaoId, c.Peso, c.Volume, c.CustoEstimado, c.AderenciaCubagem, c.AderenciaJanelaEntrega, c.RiscoResumo, c.PedidosResumo, c.OpcoesConflitantesResumo, trackingMask: trackingMask);
                 var domainResult = OpcaoPlanejamentoTransporteDomainBehavior.Apply(opcaoplanejamentotransporte, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Update(opcaoplanejamentotransporte);
                     return Task.FromResult(Success("OK", opcaoplanejamentotransporte));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, opcaoplanejamentotransporte));
                 }
            }
            else 
            {
                 return Task.FromResult(Error("ErroConversao"));
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration