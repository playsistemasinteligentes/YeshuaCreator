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
    public class UpdateContingenciaFiscalReceiver : ReciverBase<ICommand, IContingenciaFiscalEntity>
    {
        private readonly IContingenciaFiscalWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateContingenciaFiscalReceiver(
            IContingenciaFiscalWriteRepository repository,
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

        protected override Task<State<IContingenciaFiscalEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ContingenciaFiscalCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateContingenciaFiscal", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateContingenciaFiscalReceiver), commandName: "Command.Write.ContingenciaFiscalCrudCommand");
                 var contingenciafiscal = new ContingenciaFiscalFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.EmissaoFiscalTransporteId, c.EntradaFiscalContingenciaId, c.CorrelationId, c.CargaId, c.TipoSolicitante, c.Ambiente, c.EmitenteDocumento, c.TomadorDocumento, c.TransportadorDocumento, c.QuantidadeDocumentos, c.QuantidadeCTe, c.QuantidadeMDFe, c.ValorCarga, c.PesoBruto, c.UltimaMensagem, c.CriadoEmUtc, c.AtualizadoEmUtc, c.ConcluidoEmUtc, c.Status);
                 var domainResult = ContingenciaFiscalDomainBehavior.Apply(contingenciafiscal, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Update(contingenciafiscal);
                     return Task.FromResult(Success("OK", contingenciafiscal));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, contingenciafiscal));
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