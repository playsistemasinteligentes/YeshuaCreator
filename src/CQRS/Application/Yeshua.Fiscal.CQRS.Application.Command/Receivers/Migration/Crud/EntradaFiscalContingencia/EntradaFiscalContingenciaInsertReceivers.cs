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
    public class InsertEntradaFiscalContingenciaReceiver : ReciverBase<ICommand, IEntradaFiscalContingenciaEntity>
    {
        private readonly IEntradaFiscalContingenciaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertEntradaFiscalContingenciaReceiver(
            IEntradaFiscalContingenciaWriteRepository repository,
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

        protected override Task<State<IEntradaFiscalContingenciaEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.EntradaFiscalContingenciaCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertEntradaFiscalContingencia", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertEntradaFiscalContingenciaReceiver), commandName: "Command.Write.EntradaFiscalContingenciaCrudCommand");
                 var entradafiscalcontingencia = new EntradaFiscalContingenciaFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CorrelationId, c.CargaId, c.TipoSolicitante, c.Ambiente, c.SourceApplication, c.SourceModule, c.SourceMessageId, c.EmitenteFiscalDocumento, c.TomadorDocumento, c.TransportadorDocumento, c.RemetenteDocumento, c.DestinatarioDocumento, c.UFInicio, c.UFFim, c.MunicipioInicioCodigoIbge, c.MunicipioFimCodigoIbge, c.RNTRC, c.PlacaVeiculo, c.UFVeiculo, c.CondutorDocumento, c.CondutorNome, c.QuantidadeDocumentos, c.ValorCarga, c.PesoBruto, c.Volume, c.PendenciasJson, c.SnapshotJson, c.EmissaoFiscalCorrelationId, c.EmissaoFiscalSagaId, c.CriadoEmUtc, c.AtualizadoEmUtc, c.Status);
                 var domainResult = EntradaFiscalContingenciaDomainBehavior.Apply(entradafiscalcontingencia, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Insert(entradafiscalcontingencia);
                     return Task.FromResult(Success("OK", entradafiscalcontingencia));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, entradafiscalcontingencia));
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