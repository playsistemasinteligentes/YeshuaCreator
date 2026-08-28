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
    public class DeleteIndicadoresFatosDimencoesReceiver : ReciverBase<ICommand, IIndicadoresFatosDimencoesEntity>
    {
        private readonly IIndicadoresFatosDimencoesWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteIndicadoresFatosDimencoesReceiver(
            IIndicadoresFatosDimencoesWriteRepository repository,
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

        protected override async Task<State<IIndicadoresFatosDimencoesEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.IndicadoresFatosDimencoesCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteIndicadoresFatosDimencoes", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteIndicadoresFatosDimencoesReceiver), commandName: "Command.Write.IndicadoresFatosDimencoesCrudCommand");
                 var indicadoresfatosdimencoes = new IndicadoresFatosDimencoesFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.FAT_ID, c.IND_ID, c.DIM_ID, c.FAT_DESCRICAO);
                 var domainResult = IndicadoresFatosDimencoesDomainBehavior.Apply(indicadoresfatosdimencoes, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(indicadoresfatosdimencoes);
                     return Success("OK", indicadoresfatosdimencoes);
                 }
                 catch (Exception e)
                 {
                    return Error(e, indicadoresfatosdimencoes);
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