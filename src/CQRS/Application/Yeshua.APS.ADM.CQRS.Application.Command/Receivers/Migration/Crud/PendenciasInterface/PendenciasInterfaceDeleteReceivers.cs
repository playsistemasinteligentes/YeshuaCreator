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
    public class DeletePendenciasInterfaceReceiver : ReciverBase<ICommand, IPendenciasInterfaceEntity>
    {
        private readonly IPendenciasInterfaceWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeletePendenciasInterfaceReceiver(
            IPendenciasInterfaceWriteRepository repository,
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

        protected override async Task<State<IPendenciasInterfaceEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.PendenciasInterfaceCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeletePendenciasInterface", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeletePendenciasInterfaceReceiver), commandName: "Command.Write.PendenciasInterfaceCrudCommand");
                 var pendenciasinterface = new PendenciasInterfaceFactory(_logger, _domainTrackingPolicy).Create(context, c.PEN_STATUS_OUT, c.PEN_PROTOCOLO_OUT, c.PEN_ID_PROTOCOLO_OUT, c.PEN_STATUS_IN, c.PEN_PROTOCOLO_IN, c.PEN_ID_PROTOCOLO_IN, c.DATA_ENTRADA, c.PEN_ID);
                 var domainResult = PendenciasInterfaceDomainBehavior.Apply(pendenciasinterface, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(pendenciasinterface);
                     return Success("OK", pendenciasinterface);
                 }
                 catch (Exception e)
                 {
                    return Error(e, pendenciasinterface);
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