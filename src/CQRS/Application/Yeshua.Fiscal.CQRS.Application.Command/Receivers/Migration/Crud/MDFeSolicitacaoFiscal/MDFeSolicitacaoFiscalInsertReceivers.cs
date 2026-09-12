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
    public class InsertMDFeSolicitacaoFiscalReceiver : ReciverBase<ICommand, IMDFeSolicitacaoFiscalEntity>
    {
        private readonly IMDFeSolicitacaoFiscalWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertMDFeSolicitacaoFiscalReceiver(
            IMDFeSolicitacaoFiscalWriteRepository repository,
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

        protected override Task<State<IMDFeSolicitacaoFiscalEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.MDFeSolicitacaoFiscalCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertMDFeSolicitacaoFiscal", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertMDFeSolicitacaoFiscalReceiver), commandName: "Command.Write.MDFeSolicitacaoFiscalCrudCommand");
                 var mdfesolicitacaofiscal = new MDFeSolicitacaoFiscalFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CorrelationId, c.CargaId, c.Ambiente, c.UFCarregamento, c.UFDescarregamento, c.PlacaVeiculo, c.CondutorDocumento, c.DocumentosOriginariosJson, c.TransporteSnapshotJson, c.Status);
                 var domainResult = MDFeSolicitacaoFiscalDomainBehavior.Apply(mdfesolicitacaofiscal, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Insert(mdfesolicitacaofiscal);
                     return Task.FromResult(Success("OK", mdfesolicitacaofiscal));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, mdfesolicitacaofiscal));
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