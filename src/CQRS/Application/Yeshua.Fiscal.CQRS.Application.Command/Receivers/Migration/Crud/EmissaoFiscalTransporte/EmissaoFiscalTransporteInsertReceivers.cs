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
    public class InsertEmissaoFiscalTransporteReceiver : ReciverBase<ICommand, IEmissaoFiscalTransporteEntity>
    {
        private readonly IEmissaoFiscalTransporteWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertEmissaoFiscalTransporteReceiver(
            IEmissaoFiscalTransporteWriteRepository repository,
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

        protected override Task<State<IEmissaoFiscalTransporteEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.EmissaoFiscalTransporteCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertEmissaoFiscalTransporte", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertEmissaoFiscalTransporteReceiver), commandName: "Command.Write.EmissaoFiscalTransporteCrudCommand");
                 var emissaofiscaltransporte = new EmissaoFiscalTransporteFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CorrelationId, c.OrigemFluxo, c.CargaId, c.RomaneioId, c.Ambiente, c.EmitenteDocumento, c.TomadorDocumento, c.TransportadorDocumento, c.UFInicio, c.UFFim, c.MunicipioInicioCodigoIbge, c.MunicipioFimCodigoIbge, c.QuantidadeNFe, c.QuantidadeCTe, c.QuantidadeMDFe, c.ValorCarga, c.PesoBruto, c.Volume, c.UltimaMensagem, c.CriadoEmUtc, c.AtualizadoEmUtc, c.ConcluidoEmUtc, c.Status);
                 var domainResult = EmissaoFiscalTransporteDomainBehavior.Apply(emissaofiscaltransporte, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Insert(emissaofiscaltransporte);
                     return Task.FromResult(Success("OK", emissaofiscaltransporte));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, emissaofiscaltransporte));
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