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
    public class InsertResultLoteReceiver : ReciverBase<ICommand, IResultLoteEntity>
    {
        private readonly IResultLoteWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertResultLoteReceiver(
            IResultLoteWriteRepository repository,
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

        protected override Task<State<IResultLoteEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ResultLoteCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertResultLote", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertResultLoteReceiver), commandName: "Command.Write.ResultLoteCrudCommand");
                 var resultlote = new ResultLoteFactory(_logger, _domainTrackingPolicy).Create(context, c.Id);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", resultlote.OperationalEntityId);
                 var domainResult = ResultLoteDomainBehavior.Apply(resultlote, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Insert(resultlote);
                     return Task.FromResult(Success("OK", resultlote));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, resultlote));
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