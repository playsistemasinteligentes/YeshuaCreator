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
    public class DeleteTipoInspecaoVisualReceiver : ReciverBase<ICommand, ITipoInspecaoVisualEntity>
    {
        private readonly ITipoInspecaoVisualWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteTipoInspecaoVisualReceiver(
            ITipoInspecaoVisualWriteRepository repository,
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

        protected override async Task<State<ITipoInspecaoVisualEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.TipoInspecaoVisualCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteTipoInspecaoVisual", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteTipoInspecaoVisualReceiver), commandName: "Command.Write.TipoInspecaoVisualCrudCommand");
                 var tipoinspecaovisual = new TipoInspecaoVisualFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.TIV_ID, c.TIV_NOME, c.TIV_DESCRICAO, c.TIV_FECHAMENTO, c.TIV_AMOSTRA_ALEATORIA, c.TIV_N_AMOSTRAS, c.TIV_MEDIDA, c.TIV_ESPECIFICACAO, c.TIV_TOL_MAIS, c.TIV_TOL_MENOS);
                 var domainResult = TipoInspecaoVisualDomainBehavior.Apply(tipoinspecaovisual, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(tipoinspecaovisual);
                     return Success("OK", tipoinspecaovisual);
                 }
                 catch (Exception e)
                 {
                    return Error(e, tipoinspecaovisual);
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