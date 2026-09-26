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
    public class UpdateMemoriaDeCalculoReceiver : ReciverBase<ICommand, IMemoriaDeCalculoEntity>
    {
        private readonly IMemoriaDeCalculoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateMemoriaDeCalculoReceiver(
            IMemoriaDeCalculoWriteRepository repository,
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

        protected override Task<State<IMemoriaDeCalculoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.MemoriaDeCalculoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateMemoriaDeCalculo", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateMemoriaDeCalculoReceiver), commandName: "Command.Write.MemoriaDeCalculoCrudCommand");
                 var memoriadecalculo = new MemoriaDeCalculoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.MEM_ID, c.ORC_ID, c.MEM_VALOR, c.MEM_DESCRICAO);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", memoriadecalculo.OperationalEntityId);
                 var domainResult = MemoriaDeCalculoDomainBehavior.Apply(memoriadecalculo, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Update(memoriadecalculo);
                     return Task.FromResult(Success("OK", memoriadecalculo));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, memoriadecalculo));
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