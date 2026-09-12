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
    public class InsertNFeProdutoSnapshotReceiver : ReciverBase<ICommand, INFeProdutoSnapshotEntity>
    {
        private readonly INFeProdutoSnapshotWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertNFeProdutoSnapshotReceiver(
            INFeProdutoSnapshotWriteRepository repository,
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

        protected override Task<State<INFeProdutoSnapshotEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.NFeProdutoSnapshotCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertNFeProdutoSnapshot", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertNFeProdutoSnapshotReceiver), commandName: "Command.Write.NFeProdutoSnapshotCrudCommand");
                 var nfeprodutosnapshot = new NFeProdutoSnapshotFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.DocumentoFiscalOriginarioId, c.CorrelationId, c.CargaId, c.PedidoId, c.ChaveAcesso, c.EmitenteDocumento, c.DestinatarioDocumento, c.UFOrigem, c.UFDestino, c.MunicipioOrigemCodigoIbge, c.MunicipioDestinoCodigoIbge, c.ValorDocumento, c.PesoBruto, c.Volume, c.XmlStorageKey, c.SnapshotJson, c.Status);
                 var domainResult = NFeProdutoSnapshotDomainBehavior.Apply(nfeprodutosnapshot, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Insert(nfeprodutosnapshot);
                     return Task.FromResult(Success("OK", nfeprodutosnapshot));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, nfeprodutosnapshot));
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