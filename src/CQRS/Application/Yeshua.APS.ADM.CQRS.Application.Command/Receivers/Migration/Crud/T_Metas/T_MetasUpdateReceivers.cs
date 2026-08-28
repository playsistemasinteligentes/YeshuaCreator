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
    public class UpdateT_MetasReceiver : ReciverBase<ICommand, IT_MetasEntity>
    {
        private readonly IT_MetasWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateT_MetasReceiver(
            IT_MetasWriteRepository repository,
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

        protected override async Task<State<IT_MetasEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.T_MetasCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateT_Metas", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateT_MetasReceiver), commandName: "Command.Write.T_MetasCrudCommand");
                 var t_metas = new T_MetasFactory(_logger, _domainTrackingPolicy).Create(context, c.MET_ID, c.MET_DTINICIO, c.MET_DTFIM, c.MET_ALVO, c.MET_TIPOALVO, c.IND_ID, c.MET_RANGE01, c.MET_RANGE02, c.MET_RANGE03, c.DIM_ID, c.FAT_ID, c.DIM_SUBDIMENSAO_ID, c.PER_ID, c.DOM_EMPRESA, c.DOM_FILIAL);
                 var domainResult = T_MetasDomainBehavior.Apply(t_metas, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(t_metas);
                     return Success("OK", t_metas);
                 }
                 catch (Exception e)
                 {
                    return Error(e, t_metas);
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