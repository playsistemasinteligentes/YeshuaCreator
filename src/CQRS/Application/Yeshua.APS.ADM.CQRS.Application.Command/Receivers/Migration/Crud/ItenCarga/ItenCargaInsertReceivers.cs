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
    public class InsertItenCargaReceiver : ReciverBase<ICommand, IItenCargaEntity>
    {
        private readonly IItenCargaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertItenCargaReceiver(
            IItenCargaWriteRepository repository,
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

        protected override async Task<State<IItenCargaEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ItenCargaCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertItenCarga", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertItenCargaReceiver), commandName: "Command.Write.ItenCargaCrudCommand");
                 var itencarga = new ItenCargaFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CAR_ID, c.ORD_ID, c.ITC_ENTREGA_PLANEJADA, c.ITC_ENTREGA_REALIZADA, c.ITC_ORDEM_ENTREGA, c.ITC_QTD_PLANEJADA, c.ITC_QTD_REALIZADA, c.ORD_HASH_KEY, c.NOT_ID, c.NOT_EMISSAO);
                 var domainResult = ItenCargaDomainBehavior.Apply(itencarga, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(itencarga);
                     return Success("OK", itencarga);
                 }
                 catch (Exception e)
                 {
                    return Error(e, itencarga);
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