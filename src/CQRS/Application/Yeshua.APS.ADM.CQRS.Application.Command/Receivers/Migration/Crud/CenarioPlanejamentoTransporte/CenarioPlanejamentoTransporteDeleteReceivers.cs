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
    public class DeleteCenarioPlanejamentoTransporteReceiver : ReciverBase<ICommand, ICenarioPlanejamentoTransporteEntity>
    {
        private readonly ICenarioPlanejamentoTransporteWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteCenarioPlanejamentoTransporteReceiver(
            ICenarioPlanejamentoTransporteWriteRepository repository,
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

        protected override async Task<State<ICenarioPlanejamentoTransporteEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CenarioPlanejamentoTransporteCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteCenarioPlanejamentoTransporte", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteCenarioPlanejamentoTransporteReceiver), commandName: "Command.Write.CenarioPlanejamentoTransporteCrudCommand");
                 var cenarioplanejamentotransporte = new CenarioPlanejamentoTransporteFactory(_logger, _domainTrackingPolicy).Create(context, c.CenarioId, c.Descricao, c.Objetivo, c.QuantidadeCargas, c.QuantidadePedidosNaoAtendidos, c.CustoTotal, c.AderenciaCubagem, c.AtrasoPrevisto, c.AlertasResumo);
                 var domainResult = CenarioPlanejamentoTransporteDomainBehavior.Apply(cenarioplanejamentotransporte, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(cenarioplanejamentotransporte);
                     return Success("OK", cenarioplanejamentotransporte);
                 }
                 catch (Exception e)
                 {
                    return Error(e, cenarioplanejamentotransporte);
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