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
    public class DeleteProtocoloOnduladeiraReceiver : ReciverBase<ICommand, IProtocoloOnduladeiraEntity>
    {
        private readonly IProtocoloOnduladeiraWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteProtocoloOnduladeiraReceiver(
            IProtocoloOnduladeiraWriteRepository repository,
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

        protected override async Task<State<IProtocoloOnduladeiraEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ProtocoloOnduladeiraCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteProtocoloOnduladeira", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteProtocoloOnduladeiraReceiver), commandName: "Command.Write.ProtocoloOnduladeiraCrudCommand");
                 var protocoloonduladeira = new ProtocoloOnduladeiraFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.PTO_ID, c.PTO_CHAVE, c.MAQ_ID, c.PTO_COMANDO);
                 var domainResult = ProtocoloOnduladeiraDomainBehavior.Apply(protocoloonduladeira, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(protocoloonduladeira);
                     return Success("OK", protocoloonduladeira);
                 }
                 catch (Exception e)
                 {
                    return Error(e, protocoloonduladeira);
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