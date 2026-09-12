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
    public class InsertCTeRomaneioConsolidadoReceiver : ReciverBase<ICommand, ICTeRomaneioConsolidadoEntity>
    {
        private readonly ICTeRomaneioConsolidadoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertCTeRomaneioConsolidadoReceiver(
            ICTeRomaneioConsolidadoWriteRepository repository,
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

        protected override Task<State<ICTeRomaneioConsolidadoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CTeRomaneioConsolidadoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertCTeRomaneioConsolidado", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertCTeRomaneioConsolidadoReceiver), commandName: "Command.Write.CTeRomaneioConsolidadoCrudCommand");
                 var cteromaneioconsolidado = new CTeRomaneioConsolidadoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.EntradaOficialId, c.CorrelationId, c.RomaneioId, c.CargaId, c.ConsolidadoEmUtc, c.UFInicio, c.UFFim, c.MunicipioInicioCodigoIbge, c.MunicipioFimCodigoIbge, c.EmitenteDocumento, c.TomadorDocumento, c.RotaSnapshotJson, c.CargaSnapshotJson, c.PreferenciasFiscaisJson, c.Status);
                 var domainResult = CTeRomaneioConsolidadoDomainBehavior.Apply(cteromaneioconsolidado, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Insert(cteromaneioconsolidado);
                     return Task.FromResult(Success("OK", cteromaneioconsolidado));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, cteromaneioconsolidado));
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