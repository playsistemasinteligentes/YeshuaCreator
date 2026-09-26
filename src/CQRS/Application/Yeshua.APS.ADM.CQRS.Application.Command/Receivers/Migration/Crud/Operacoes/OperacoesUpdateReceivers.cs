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
    public class UpdateOperacoesReceiver : ReciverBase<ICommand, IOperacoesEntity>
    {
        private readonly IOperacoesWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateOperacoesReceiver(
            IOperacoesWriteRepository repository,
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

        protected override Task<State<IOperacoesEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.OperacoesCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateOperacoes", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateOperacoesReceiver), commandName: "Command.Write.OperacoesCrudCommand");
                 var operacoes = new OperacoesFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.OPE_TIPO_REGISTRO, c.OPE_ID, c.GMA_ID, c.MAQ_ID, c.PRO_ID, c.OPE_EXCECAO, c.ROT_SEQ_TRANFORMACAO, c.ORD_ID, c.FPR_SEQ_REPETICAO);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", operacoes.OperationalEntityId);
                 var domainResult = OperacoesDomainBehavior.Apply(operacoes, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Update(operacoes);
                     return Task.FromResult(Success("OK", operacoes));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, operacoes));
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