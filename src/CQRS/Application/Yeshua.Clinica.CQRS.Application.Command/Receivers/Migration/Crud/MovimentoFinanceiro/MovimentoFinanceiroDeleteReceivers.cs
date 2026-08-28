using System.Threading;
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
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteMovimentoFinanceiroReceiver : ReciverBase<ICommand, IMovimentoFinanceiroEntity>
    {
        private readonly IMovimentoFinanceiroWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteMovimentoFinanceiroReceiver(
            IMovimentoFinanceiroWriteRepository repository,
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

        protected override async Task<State<IMovimentoFinanceiroEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.MovimentoFinanceiroCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteMovimentoFinanceiro", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteMovimentoFinanceiroReceiver), commandName: "Command.Write.MovimentoFinanceiroCrudCommand");
                 var movimentofinanceiro = new MovimentoFinanceiroFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.IdOrigem, c.ContaDebitoId, c.Valor, c.DataMovimento, c.DataVencimento, c.Status);
                 var domainResult = MovimentoFinanceiroDomainBehavior.Apply(movimentofinanceiro, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(movimentofinanceiro);
                     return Success("OK", movimentofinanceiro);
                 }
                 catch (Exception e)
                 {
                    return Error(e, movimentofinanceiro);
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