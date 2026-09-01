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
    public class InsertPedidoPlanejavelReceiver : ReciverBase<ICommand, IPedidoPlanejavelEntity>
    {
        private readonly IPedidoPlanejavelWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertPedidoPlanejavelReceiver(
            IPedidoPlanejavelWriteRepository repository,
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

        protected override async Task<State<IPedidoPlanejavelEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.PedidoPlanejavelCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertPedidoPlanejavel", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertPedidoPlanejavelReceiver), commandName: "Command.Write.PedidoPlanejavelCrudCommand");
                 var pedidoplanejavel = new PedidoPlanejavelFactory(_logger, _domainTrackingPolicy).Create(context, c.PedidoId, c.ClienteId, c.ClienteNome, c.Estado, c.Municipio, c.Regiao, c.Bairro, c.RotaId, c.EmbarqueAlvo, c.DataEntregaDe, c.DataEntregaAte, c.Peso, c.Volume, c.SaldoAExpedir, c.Status, c.CargaAtualId, c.VersaoPlanejamento, c.AlertasResumo);
                 var domainResult = PedidoPlanejavelDomainBehavior.Apply(pedidoplanejavel, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(pedidoplanejavel);
                     return Success("OK", pedidoplanejavel);
                 }
                 catch (Exception e)
                 {
                    return Error(e, pedidoplanejavel);
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