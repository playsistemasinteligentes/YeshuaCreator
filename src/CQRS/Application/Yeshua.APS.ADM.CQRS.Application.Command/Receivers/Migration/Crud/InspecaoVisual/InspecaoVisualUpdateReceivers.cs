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
    public class UpdateInspecaoVisualReceiver : ReciverBase<ICommand, IInspecaoVisualEntity>
    {
        private readonly IInspecaoVisualWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateInspecaoVisualReceiver(
            IInspecaoVisualWriteRepository repository,
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

        protected override async Task<State<IInspecaoVisualEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.InspecaoVisualCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateInspecaoVisual", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateInspecaoVisualReceiver), commandName: "Command.Write.InspecaoVisualCrudCommand");
                 var inspecaovisual = new InspecaoVisualFactory(_logger, _domainTrackingPolicy).Create(context, c.IPV_ID, c.IPV_VALOR, c.IPV_ID_OPERADOR, c.IPV_ID_LIBERACAO, c.IPV_OBS, c.IPV_DATA_COLETA, c.IPV_DATA_AVAL, c.TIV_ID, c.TURN_ID, c.TURM_ID, c.ORD_ID, c.ROT_PRO_ID, c.ROT_MAQ_ID, c.ROT_SEQ_TRANSFORMACAO, c.FPR_SEQ_REPETICAO, c.IPV_STATUS_LIBERACAO, c.IPV_VALOR_MEDIDA);
                 var domainResult = InspecaoVisualDomainBehavior.Apply(inspecaovisual, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(inspecaovisual);
                     return Success("OK", inspecaovisual);
                 }
                 catch (Exception e)
                 {
                    return Error(e, inspecaovisual);
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