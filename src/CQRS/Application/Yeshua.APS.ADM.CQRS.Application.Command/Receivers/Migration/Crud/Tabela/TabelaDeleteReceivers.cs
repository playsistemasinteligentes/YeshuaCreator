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
    public class DeleteTabelaReceiver : ReciverBase<ICommand, ITabelaEntity>
    {
        private readonly ITabelaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteTabelaReceiver(
            ITabelaWriteRepository repository,
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

        protected override Task<State<ITabelaEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.TabelaCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteTabela", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteTabelaReceiver), commandName: "Command.Write.TabelaCrudCommand");
                 var tabela = new TabelaFactory(_logger, _domainTrackingPolicy).Create(context, c.ID_TABELA, c.CODIGO, c.NOME);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", tabela.OperationalEntityId);
                 var domainResult = TabelaDomainBehavior.Apply(tabela, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Delete(tabela);
                     return Task.FromResult(Success("OK", tabela));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, tabela));
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