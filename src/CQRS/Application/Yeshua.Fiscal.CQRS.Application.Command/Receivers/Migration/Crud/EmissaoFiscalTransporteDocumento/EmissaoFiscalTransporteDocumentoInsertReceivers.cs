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
    public class InsertEmissaoFiscalTransporteDocumentoReceiver : ReciverBase<ICommand, IEmissaoFiscalTransporteDocumentoEntity>
    {
        private readonly IEmissaoFiscalTransporteDocumentoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertEmissaoFiscalTransporteDocumentoReceiver(
            IEmissaoFiscalTransporteDocumentoWriteRepository repository,
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

        protected override Task<State<IEmissaoFiscalTransporteDocumentoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.EmissaoFiscalTransporteDocumentoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertEmissaoFiscalTransporteDocumento", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertEmissaoFiscalTransporteDocumentoReceiver), commandName: "Command.Write.EmissaoFiscalTransporteDocumentoCrudCommand");
                 var emissaofiscaltransportedocumento = new EmissaoFiscalTransporteDocumentoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.EmissaoFiscalTransporteId, c.DocumentoFiscalId, c.DocumentoFiscalOriginarioId, c.NFeProdutoSnapshotId, c.ProdutoFiscal, c.Papel, c.TipoEvento, c.ChaveAcesso, c.XmlStorageKey, c.PdfStorageKey, c.Protocolo, c.CodigoRetorno, c.MensagemRetorno, c.CriadoEmUtc, c.Status);
                 var domainResult = EmissaoFiscalTransporteDocumentoDomainBehavior.Apply(emissaofiscaltransportedocumento, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Insert(emissaofiscaltransportedocumento);
                     return Task.FromResult(Success("OK", emissaofiscaltransportedocumento));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, emissaofiscaltransportedocumento));
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