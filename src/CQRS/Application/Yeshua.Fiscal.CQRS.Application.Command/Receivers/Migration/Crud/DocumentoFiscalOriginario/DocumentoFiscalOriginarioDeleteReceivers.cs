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
    public class DeleteDocumentoFiscalOriginarioReceiver : ReciverBase<ICommand, IDocumentoFiscalOriginarioEntity>
    {
        private readonly IDocumentoFiscalOriginarioWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteDocumentoFiscalOriginarioReceiver(
            IDocumentoFiscalOriginarioWriteRepository repository,
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

        protected override Task<State<IDocumentoFiscalOriginarioEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.DocumentoFiscalOriginarioCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteDocumentoFiscalOriginario", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteDocumentoFiscalOriginarioReceiver), commandName: "Command.Write.DocumentoFiscalOriginarioCrudCommand");
                 var documentofiscaloriginario = new DocumentoFiscalOriginarioFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.DocumentoFiscalId, c.CorrelationId, c.SourceApplication, c.SourceModule, c.SourceMessageId, c.TipoDocumento, c.ChaveAcesso, c.Numero, c.Serie, c.EmitenteDocumento, c.DestinatarioDocumento, c.ValorDocumento, c.PesoBruto, c.Volume, c.SnapshotJson, c.Status);
                 var domainResult = DocumentoFiscalOriginarioDomainBehavior.Apply(documentofiscaloriginario, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Delete(documentofiscaloriginario);
                     return Task.FromResult(Success("OK", documentofiscaloriginario));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, documentofiscaloriginario));
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