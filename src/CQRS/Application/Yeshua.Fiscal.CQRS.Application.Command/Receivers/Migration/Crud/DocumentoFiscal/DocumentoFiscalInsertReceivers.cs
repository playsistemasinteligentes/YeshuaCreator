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
    public class InsertDocumentoFiscalReceiver : ReciverBase<ICommand, IDocumentoFiscalEntity>
    {
        private readonly IDocumentoFiscalWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertDocumentoFiscalReceiver(
            IDocumentoFiscalWriteRepository repository,
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

        protected override Task<State<IDocumentoFiscalEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.DocumentoFiscalCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertDocumentoFiscal", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertDocumentoFiscalReceiver), commandName: "Command.Write.DocumentoFiscalCrudCommand");
                 var documentofiscal = new DocumentoFiscalFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CorrelationId, c.ProdutoFiscal, c.ChaveAcesso, c.Serie, c.Numero, c.Ambiente, c.UFEmitente, c.EmitenteDocumento, c.DestinatarioDocumento, c.XmlStorageKey, c.XmlHash, c.ProtocoloAutorizacao, c.CodigoRetorno, c.MensagemRetorno, c.Status);
                 var domainResult = DocumentoFiscalDomainBehavior.Apply(documentofiscal, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Insert(documentofiscal);
                     return Task.FromResult(Success("OK", documentofiscal));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, documentofiscal));
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