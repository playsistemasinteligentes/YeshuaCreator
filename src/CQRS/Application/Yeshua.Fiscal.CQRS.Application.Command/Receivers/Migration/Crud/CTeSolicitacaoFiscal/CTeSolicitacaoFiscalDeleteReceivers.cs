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
    public class DeleteCTeSolicitacaoFiscalReceiver : ReciverBase<ICommand, ICTeSolicitacaoFiscalEntity>
    {
        private readonly ICTeSolicitacaoFiscalWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteCTeSolicitacaoFiscalReceiver(
            ICTeSolicitacaoFiscalWriteRepository repository,
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

        protected override async Task<State<ICTeSolicitacaoFiscalEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CTeSolicitacaoFiscalCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteCTeSolicitacaoFiscal", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteCTeSolicitacaoFiscalReceiver), commandName: "Command.Write.CTeSolicitacaoFiscalCrudCommand");
                 var ctesolicitacaofiscal = new CTeSolicitacaoFiscalFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.EntradaOficialId, c.RomaneioConsolidadoId, c.CorrelationId, c.Ambiente, c.UFEmitente, c.EmitenteDocumento, c.ProdutoFiscal, c.TipoCTe, c.TipoServico, c.Modal, c.Globalizado, c.UFInicio, c.UFFim, c.MunicipioInicioCodigoIbge, c.MunicipioFimCodigoIbge, c.ValorServico, c.ValorCarga, c.PreferenciasManifestoJson, c.Status);
                 var domainResult = CTeSolicitacaoFiscalDomainBehavior.Apply(ctesolicitacaofiscal, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(ctesolicitacaofiscal);
                     return Success("OK", ctesolicitacaofiscal);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ctesolicitacaofiscal);
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