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
    public class DeleteEstruturaProdutoReceiver : ReciverBase<ICommand, IEstruturaProdutoEntity>
    {
        private readonly IEstruturaProdutoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteEstruturaProdutoReceiver(
            IEstruturaProdutoWriteRepository repository,
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

        protected override Task<State<IEstruturaProdutoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.EstruturaProdutoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteEstruturaProduto", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteEstruturaProdutoReceiver), commandName: "Command.Write.EstruturaProdutoCrudCommand");
                 var estruturaproduto = new EstruturaProdutoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.EST_DATA_VALIDADE, c.PRO_ID_PRODUTO, c.PRO_ID_COMPONENTE, c.EST_QUANT, c.EST_DATA_INCLUSAO, c.EST_BASE_PRODUCAO, c.EST_TIPO_REQUISICAO, c.EST_CODIGO_DE_EXCECAO);
                 var domainResult = EstruturaProdutoDomainBehavior.Apply(estruturaproduto, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Delete(estruturaproduto);
                     return Task.FromResult(Success("OK", estruturaproduto));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, estruturaproduto));
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