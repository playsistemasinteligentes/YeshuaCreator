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
    public class InsertTempoSetupOnduladeiraReceiver : ReciverBase<ICommand, ITempoSetupOnduladeiraEntity>
    {
        private readonly ITempoSetupOnduladeiraWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertTempoSetupOnduladeiraReceiver(
            ITempoSetupOnduladeiraWriteRepository repository,
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

        protected override async Task<State<ITempoSetupOnduladeiraEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.TempoSetupOnduladeiraCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertTempoSetupOnduladeira", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertTempoSetupOnduladeiraReceiver), commandName: "Command.Write.TempoSetupOnduladeiraCrudCommand");
                 var temposetuponduladeira = new TempoSetupOnduladeiraFactory(_logger, _domainTrackingPolicy).Create(context, c.TEM_ID, c.OND_ID_DE, c.OND_ID_PARA, c.TEM_RESINA_DE, c.TEM_RESINA_PARA, c.TEM_TEMPO);
                 var domainResult = TempoSetupOnduladeiraDomainBehavior.Apply(temposetuponduladeira, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(temposetuponduladeira);
                     return Success("OK", temposetuponduladeira);
                 }
                 catch (Exception e)
                 {
                    return Error(e, temposetuponduladeira);
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