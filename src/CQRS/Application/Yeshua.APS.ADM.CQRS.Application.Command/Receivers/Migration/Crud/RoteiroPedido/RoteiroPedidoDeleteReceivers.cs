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
    public class DeleteRoteiroPedidoReceiver : ReciverBase<ICommand, IRoteiroPedidoEntity>
    {
        private readonly IRoteiroPedidoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteRoteiroPedidoReceiver(
            IRoteiroPedidoWriteRepository repository,
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

        protected override async Task<State<IRoteiroPedidoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.RoteiroPedidoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteRoteiroPedido", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteRoteiroPedidoReceiver), commandName: "Command.Write.RoteiroPedidoCrudCommand");
                 var roteiropedido = new RoteiroPedidoFactory(_logger, _domainTrackingPolicy).Create(context, c.PedidoId, c.MaquinaId, c.ProdutoId, c.SequenciaTransformacao, c.StatusCadastro, c.TipoPlanejamento, c.CalendarioId, c.HierarquiaSequenciaTransformacao, c.ProximaSequenciaTransformacao, c.Performance, c.TempoSetup, c.TempoSetupAjuste, c.PecasPorPulso, c.PrioridadeInformada, c.Status, c.Operacoes, c.ExcecaoOperacoes, c.LinhaDireta, c.AvaliaCusto, c.PercentualInicioPassoAnterior, c.MaquinaLarguraUtil, c.GrupoTipo, c.GrupoPerformanceMetroLinear);
                 var domainResult = RoteiroPedidoDomainBehavior.Apply(roteiropedido, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(roteiropedido);
                     return Success("OK", roteiropedido);
                 }
                 catch (Exception e)
                 {
                    return Error(e, roteiropedido);
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