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
    public class UpdateMDFeCondutorReceiver : ReciverBase<ICommand, IMDFeCondutorEntity>
    {
        private readonly IMDFeCondutorWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateMDFeCondutorReceiver(
            IMDFeCondutorWriteRepository repository,
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

        protected override async Task<State<IMDFeCondutorEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.MDFeCondutorCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateMDFeCondutor", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateMDFeCondutorReceiver), commandName: "Command.Write.MDFeCondutorCrudCommand");
                 var mdfecondutor = new MDFeCondutorFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.MDFeSolicitacaoFiscalId, c.Nome, c.Documento);
                 var domainResult = MDFeCondutorDomainBehavior.Apply(mdfecondutor, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(mdfecondutor);
                     return Success("OK", mdfecondutor);
                 }
                 catch (Exception e)
                 {
                    return Error(e, mdfecondutor);
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