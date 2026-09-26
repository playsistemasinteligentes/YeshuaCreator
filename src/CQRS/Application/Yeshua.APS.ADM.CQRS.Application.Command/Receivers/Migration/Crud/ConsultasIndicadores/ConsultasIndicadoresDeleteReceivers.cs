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
    public class DeleteConsultasIndicadoresReceiver : ReciverBase<ICommand, IConsultasIndicadoresEntity>
    {
        private readonly IConsultasIndicadoresWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteConsultasIndicadoresReceiver(
            IConsultasIndicadoresWriteRepository repository,
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

        protected override Task<State<IConsultasIndicadoresEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ConsultasIndicadoresCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteConsultasIndicadores", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteConsultasIndicadoresReceiver), commandName: "Command.Write.ConsultasIndicadoresCrudCommand");
                 var consultasindicadores = new ConsultasIndicadoresFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CON_ID, c.IND_ID);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", consultasindicadores.OperationalEntityId);
                 var domainResult = ConsultasIndicadoresDomainBehavior.Apply(consultasindicadores, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Delete(consultasindicadores);
                     return Task.FromResult(Success("OK", consultasindicadores));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, consultasindicadores));
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