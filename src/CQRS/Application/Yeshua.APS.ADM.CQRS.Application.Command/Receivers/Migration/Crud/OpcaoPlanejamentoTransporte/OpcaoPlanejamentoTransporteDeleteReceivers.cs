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
    public class DeleteOpcaoPlanejamentoTransporteReceiver : ReciverBase<ICommand, IOpcaoPlanejamentoTransporteEntity>
    {
        private readonly IOpcaoPlanejamentoTransporteWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteOpcaoPlanejamentoTransporteReceiver(
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

        protected override async Task<State<IOpcaoPlanejamentoTransporteEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.OpcaoPlanejamentoTransporteCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteOpcaoPlanejamentoTransporte", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteOpcaoPlanejamentoTransporteReceiver), commandName: "Command.Write.OpcaoPlanejamentoTransporteCrudCommand");
                 var opcaoplanejamentotransporte = new OpcaoPlanejamentoTransporteFactory(_logger, _domainTrackingPolicy).Create(context, c.OpcaoId, c.GrupoDecisaoId, c.Peso, c.Volume, c.CustoEstimado, c.AderenciaCubagem, c.AderenciaJanelaEntrega, c.RiscoResumo, c.PedidosResumo, c.OpcoesConflitantesResumo);
                 var domainResult = OpcaoPlanejamentoTransporteDomainBehavior.Apply(opcaoplanejamentotransporte, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(opcaoplanejamentotransporte);
                     return Success("OK", opcaoplanejamentotransporte);
                 }
                 catch (Exception e)
                 {
                    return Error(e, opcaoplanejamentotransporte);
                 }
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration