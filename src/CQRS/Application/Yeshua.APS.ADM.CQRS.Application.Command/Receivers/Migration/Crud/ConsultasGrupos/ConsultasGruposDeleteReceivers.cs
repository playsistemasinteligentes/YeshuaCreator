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
    public class DeleteConsultasGruposReceiver : ReciverBase<ICommand, IConsultasGruposEntity>
    {
        private readonly IConsultasGruposWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteConsultasGruposReceiver(
            IConsultasGruposWriteRepository repository,
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

        protected override Task<State<IConsultasGruposEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ConsultasGruposCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteConsultasGrupos", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteConsultasGruposReceiver), commandName: "Command.Write.ConsultasGruposCrudCommand");
                 var consultasgrupos = new ConsultasGruposFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CON_ID, c.GRU_ID);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", consultasgrupos.OperationalEntityId);
                 var domainResult = ConsultasGruposDomainBehavior.Apply(consultasgrupos, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Delete(consultasgrupos);
                     return Task.FromResult(Success("OK", consultasgrupos));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, consultasgrupos));
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