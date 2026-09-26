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
    public class DeleteParametrosDeCustoReceiver : ReciverBase<ICommand, IParametrosDeCustoEntity>
    {
        private readonly IParametrosDeCustoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteParametrosDeCustoReceiver(
            IParametrosDeCustoWriteRepository repository,
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

        protected override Task<State<IParametrosDeCustoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ParametrosDeCustoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteParametrosDeCusto", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteParametrosDeCustoReceiver), commandName: "Command.Write.ParametrosDeCustoCrudCommand");
                 var parametrosdecusto = new ParametrosDeCustoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.PAR_ID, c.PRO_ID, c.CUS_ID, c.PAR_VALOR);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", parametrosdecusto.OperationalEntityId);
                 var domainResult = ParametrosDeCustoDomainBehavior.Apply(parametrosdecusto, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Delete(parametrosdecusto);
                     return Task.FromResult(Success("OK", parametrosdecusto));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, parametrosdecusto));
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