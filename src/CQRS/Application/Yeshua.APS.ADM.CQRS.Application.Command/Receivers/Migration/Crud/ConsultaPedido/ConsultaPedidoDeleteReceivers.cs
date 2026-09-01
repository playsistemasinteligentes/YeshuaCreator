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
    public class DeleteConsultaPedidoReceiver : ReciverBase<ICommand, IConsultaPedidoEntity>
    {
        private readonly IConsultaPedidoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteConsultaPedidoReceiver(
            IConsultaPedidoWriteRepository repository,
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

        protected override async Task<State<IConsultaPedidoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ConsultaPedidoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteConsultaPedido", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteConsultaPedidoReceiver), commandName: "Command.Write.ConsultaPedidoCrudCommand");
                 var consultapedido = new ConsultaPedidoFactory(_logger, _domainTrackingPolicy).Create(context, c.PedidoId, c.ClienteId, c.ClienteNome, c.RazaoSocial, c.ProdutoId, c.ProdutoDescricao, c.Status, c.Estagio, c.DataEntregaDe, c.DataEntregaAte, c.EmbarqueAlvo, c.Quantidade, c.SaldoAProduzir, c.SaldoAExpedir, c.CorFila, c.PedidoCliente);
                 var domainResult = ConsultaPedidoDomainBehavior.Apply(consultapedido, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(consultapedido);
                     return Success("OK", consultapedido);
                 }
                 catch (Exception e)
                 {
                    return Error(e, consultapedido);
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