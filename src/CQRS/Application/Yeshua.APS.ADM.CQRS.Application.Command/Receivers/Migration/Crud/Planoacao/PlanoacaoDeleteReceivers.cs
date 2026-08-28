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
    public class DeletePlanoacaoReceiver : ReciverBase<ICommand, IPlanoacaoEntity>
    {
        private readonly IPlanoacaoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeletePlanoacaoReceiver(
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

        protected override async Task<State<IPlanoacaoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.PlanoacaoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeletePlanoacao", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeletePlanoacaoReceiver), commandName: "Command.Write.PlanoacaoCrudCommand");
                 var planoacao = new PlanoacaoFactory(_logger, _domainTrackingPolicy).Create(context, c.PLA_ID, c.PLA_DESCRICAO, c.MET_ID, c.PLA_STATUS, c.PLA_DATA, c.PLA_METAPERIODO, c.PLA_VLRPERIODO, c.PLA_METACULADO, c.PLA_VLRACUMULADO, c.PLA_REFERENCIA, c.USE_ID);
                 var domainResult = PlanoacaoDomainBehavior.Apply(planoacao, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(planoacao);
                     return Success("OK", planoacao);
                 }
                 catch (Exception e)
                 {
                    return Error(e, planoacao);
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