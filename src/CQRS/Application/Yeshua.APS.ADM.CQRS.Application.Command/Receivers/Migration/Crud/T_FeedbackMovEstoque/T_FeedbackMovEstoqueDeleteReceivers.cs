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
    public class DeleteT_FeedbackMovEstoqueReceiver : ReciverBase<ICommand, IT_FeedbackMovEstoqueEntity>
    {
        private readonly IT_FeedbackMovEstoqueWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteT_FeedbackMovEstoqueReceiver(
            IT_FeedbackMovEstoqueWriteRepository repository,
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

        protected override async Task<State<IT_FeedbackMovEstoqueEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.T_FeedbackMovEstoqueCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteT_FeedbackMovEstoque", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteT_FeedbackMovEstoqueReceiver), commandName: "Command.Write.T_FeedbackMovEstoqueCrudCommand");
                 var t_feedbackmovestoque = new T_FeedbackMovEstoqueFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.FeedbackId, c.MovimentoEstoqueId);
                 var domainResult = T_FeedbackMovEstoqueDomainBehavior.Apply(t_feedbackmovestoque, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(t_feedbackmovestoque);
                     return Success("OK", t_feedbackmovestoque);
                 }
                 catch (Exception e)
                 {
                    return Error(e, t_feedbackmovestoque);
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