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
    public class DeleteMovimentacaoFinanceiraReceiver : ReciverBase<ICommand, IMovimentacaoFinanceiraEntity>
    {
        private readonly IMovimentacaoFinanceiraWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteMovimentacaoFinanceiraReceiver(
            IMovimentacaoFinanceiraWriteRepository repository,
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

        protected override Task<State<IMovimentacaoFinanceiraEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.MovimentacaoFinanceiraCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteMovimentacaoFinanceira", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteMovimentacaoFinanceiraReceiver), commandName: "Command.Write.MovimentacaoFinanceiraCrudCommand");
                 var movimentacaofinanceira = new MovimentacaoFinanceiraFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.PacienteId, c.ServicoId, c.Valor, c.TipoMovimentacao, c.DataMovimentacao, c.SaldoAtual);
                 var domainResult = MovimentacaoFinanceiraDomainBehavior.Apply(movimentacaofinanceira, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Delete(movimentacaofinanceira);
                     return Task.FromResult(Success("OK", movimentacaofinanceira));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, movimentacaofinanceira));
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