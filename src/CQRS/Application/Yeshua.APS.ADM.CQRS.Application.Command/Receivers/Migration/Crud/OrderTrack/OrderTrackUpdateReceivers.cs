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
    public class UpdateOrderTrackReceiver : ReciverBase<ICommand, IOrderTrackEntity>
    {
        private readonly IOrderTrackWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateOrderTrackReceiver(
            IOrderTrackWriteRepository repository,
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

        protected override async Task<State<IOrderTrackEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.OrderTrackCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateOrderTrack", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateOrderTrackReceiver), commandName: "Command.Write.OrderTrackCrudCommand");
                 var ordertrack = new OrderTrackFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.OTK_ID, c.OTK_SEQUENCIA, c.OTK_VERSSAO, c.ORD_ID, c.OTK_EVENTO, c.OTK_DATA_NECESSIDADE_DE, c.OTK_DATA_NECESSIDADE_ATE, c.OTK_DATA_PREVISTA, c.OTK_DATA_REALIZADA, c.FPR_ID);
                 var domainResult = OrderTrackDomainBehavior.Apply(ordertrack, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(ordertrack);
                     return Success("OK", ordertrack);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ordertrack);
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