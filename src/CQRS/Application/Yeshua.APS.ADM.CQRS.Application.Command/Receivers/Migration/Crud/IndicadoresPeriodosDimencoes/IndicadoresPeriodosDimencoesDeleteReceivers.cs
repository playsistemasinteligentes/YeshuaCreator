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
    public class DeleteIndicadoresPeriodosDimencoesReceiver : ReciverBase<ICommand, IIndicadoresPeriodosDimencoesEntity>
    {
        private readonly IIndicadoresPeriodosDimencoesWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteIndicadoresPeriodosDimencoesReceiver(
            IIndicadoresPeriodosDimencoesWriteRepository repository,
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

        protected override Task<State<IIndicadoresPeriodosDimencoesEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.IndicadoresPeriodosDimencoesCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteIndicadoresPeriodosDimencoes", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteIndicadoresPeriodosDimencoesReceiver), commandName: "Command.Write.IndicadoresPeriodosDimencoesCrudCommand");
                 var indicadoresperiodosdimencoes = new IndicadoresPeriodosDimencoesFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.PER_ID, c.IND_ID, c.DIM_ID, c.PER_DESCRICAO);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", indicadoresperiodosdimencoes.OperationalEntityId);
                 var domainResult = IndicadoresPeriodosDimencoesDomainBehavior.Apply(indicadoresperiodosdimencoes, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Delete(indicadoresperiodosdimencoes);
                     return Task.FromResult(Success("OK", indicadoresperiodosdimencoes));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, indicadoresperiodosdimencoes));
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