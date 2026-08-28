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
    public class DeleteItensCalendarioReceiver : ReciverBase<ICommand, IItensCalendarioEntity>
    {
        private readonly IItensCalendarioWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteItensCalendarioReceiver(
            IItensCalendarioWriteRepository repository,
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

        protected override async Task<State<IItensCalendarioEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ItensCalendarioCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteItensCalendario", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteItensCalendarioReceiver), commandName: "Command.Write.ItensCalendarioCrudCommand");
                 var itenscalendario = new ItensCalendarioFactory(_logger, _domainTrackingPolicy).Create(context, c.ICA_ID, c.ICA_DATA_DE, c.ICA_DATA_ATE, c.ICA_OBSERVACAO, c.ICA_TIPO, c.URM_ID, c.URN_ID, c.CAL_ID, c.MAQ_ID, c.PRO_ID, c.ICA_LIMPESA_MAQUINA);
                 var domainResult = ItensCalendarioDomainBehavior.Apply(itenscalendario, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(itenscalendario);
                     return Success("OK", itenscalendario);
                 }
                 catch (Exception e)
                 {
                    return Error(e, itenscalendario);
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