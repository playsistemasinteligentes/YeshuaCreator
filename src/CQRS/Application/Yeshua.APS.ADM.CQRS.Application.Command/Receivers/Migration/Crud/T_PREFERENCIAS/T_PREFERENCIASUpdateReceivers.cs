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
    public class UpdateT_PREFERENCIASReceiver : ReciverBase<ICommand, IT_PREFERENCIASEntity>
    {
        private readonly IT_PREFERENCIASWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateT_PREFERENCIASReceiver(
            IT_PREFERENCIASWriteRepository repository,
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

        protected override async Task<State<IT_PREFERENCIASEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.T_PREFERENCIASCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateT_PREFERENCIAS", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateT_PREFERENCIASReceiver), commandName: "Command.Write.T_PREFERENCIASCrudCommand");
                 var t_preferencias = new T_PREFERENCIASFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.PRE_ID, c.PRE_DESCRICAO, c.PRE_NAMESPACE, c.PRE_TIPO, c.PRE_VALOR, c.USE_ID, c.PER_ID);
                 var domainResult = T_PREFERENCIASDomainBehavior.Apply(t_preferencias, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(t_preferencias);
                     return Success("OK", t_preferencias);
                 }
                 catch (Exception e)
                 {
                    return Error(e, t_preferencias);
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