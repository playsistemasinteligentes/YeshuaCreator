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
    public class DeleteLogsDatabaseReceiver : ReciverBase<ICommand, ILogsDatabaseEntity>
    {
        private readonly ILogsDatabaseWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteLogsDatabaseReceiver(
            ILogsDatabaseWriteRepository repository,
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

        protected override async Task<State<ILogsDatabaseEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.LogsDatabaseCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteLogsDatabase", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteLogsDatabaseReceiver), commandName: "Command.Write.LogsDatabaseCrudCommand");
                 var logsdatabase = new LogsDatabaseFactory(_logger, _domainTrackingPolicy).Create(context, c.LOGS_ID, c.LOGS_TABLE, c.LOGS_KEY, c.LOGS_KEY1, c.LOGS_KEY2, c.LOGS_KEY3, c.LOGS_KEY4, c.LOGS_COLUMN, c.LOGS_BEFORE, c.LOGS_AFTER, c.LOGS_ACTION, c.LOGS_DATE, c.USE_ID, c.LOGS_ORIGEM);
                 var domainResult = LogsDatabaseDomainBehavior.Apply(logsdatabase, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(logsdatabase);
                     return Success("OK", logsdatabase);
                 }
                 catch (Exception e)
                 {
                    return Error(e, logsdatabase);
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