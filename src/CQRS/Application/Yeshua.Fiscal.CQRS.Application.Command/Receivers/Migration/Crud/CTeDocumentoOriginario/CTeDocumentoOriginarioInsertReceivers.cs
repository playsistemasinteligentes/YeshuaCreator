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
    public class InsertCTeDocumentoOriginarioReceiver : ReciverBase<ICommand, ICTeDocumentoOriginarioEntity>
    {
        private readonly ICTeDocumentoOriginarioWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertCTeDocumentoOriginarioReceiver(
            ICTeDocumentoOriginarioWriteRepository repository,
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

        protected override Task<State<ICTeDocumentoOriginarioEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CTeDocumentoOriginarioCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertCTeDocumentoOriginario", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertCTeDocumentoOriginarioReceiver), commandName: "Command.Write.CTeDocumentoOriginarioCrudCommand");
                 var ctedocumentooriginario = new CTeDocumentoOriginarioFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CTeSolicitacaoFiscalId, c.DocumentoFiscalOriginarioId, c.TipoDocumento, c.ChaveAcesso, c.Numero, c.Serie, c.EmitenteDocumento, c.DestinatarioDocumento, c.ValorDocumento, c.PesoBruto, c.SnapshotJson);
                 var domainResult = CTeDocumentoOriginarioDomainBehavior.Apply(ctedocumentooriginario, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Insert(ctedocumentooriginario);
                     return Task.FromResult(Success("OK", ctedocumentooriginario));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, ctedocumentooriginario));
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