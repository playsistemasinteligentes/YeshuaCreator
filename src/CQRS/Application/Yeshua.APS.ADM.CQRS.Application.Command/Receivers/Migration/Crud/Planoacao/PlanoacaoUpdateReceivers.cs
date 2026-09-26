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
    public class UpdatePlanoacaoReceiver : ReciverBase<ICommand, IPlanoacaoEntity>
    {
        private readonly IPlanoacaoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdatePlanoacaoReceiver(
            IPlanoacaoWriteRepository repository,
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

        protected override Task<State<IPlanoacaoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.PlanoacaoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdatePlanoacao", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdatePlanoacaoReceiver), commandName: "Command.Write.PlanoacaoCrudCommand");
                 var planoacao = new PlanoacaoFactory(_logger, _domainTrackingPolicy).Create(context, c.PLA_ID, c.PLA_DESCRICAO, c.MET_ID, c.PLA_STATUS, c.PLA_DATA, c.PLA_METAPERIODO, c.PLA_VLRPERIODO, c.PLA_METACULADO, c.PLA_VLRACUMULADO, c.PLA_REFERENCIA, c.USE_ID);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", planoacao.OperationalEntityId);
                 var domainResult = PlanoacaoDomainBehavior.Apply(planoacao, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Update(planoacao);
                     return Task.FromResult(Success("OK", planoacao));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, planoacao));
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