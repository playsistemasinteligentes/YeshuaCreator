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
    public class InsertExperienciaPlanejamentoTransporteReceiver : ReciverBase<ICommand, IExperienciaPlanejamentoTransporteEntity>
    {
        private readonly IExperienciaPlanejamentoTransporteWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertExperienciaPlanejamentoTransporteReceiver(
            IExperienciaPlanejamentoTransporteWriteRepository repository,
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

        protected override async Task<State<IExperienciaPlanejamentoTransporteEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ExperienciaPlanejamentoTransporteCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertExperienciaPlanejamentoTransporte", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertExperienciaPlanejamentoTransporteReceiver), commandName: "Command.Write.ExperienciaPlanejamentoTransporteCrudCommand");
                 var experienciaplanejamentotransporte = new ExperienciaPlanejamentoTransporteFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.Tipo, c.Referencia, c.PedidoId, c.ClienteId, c.Municipio, c.Regiao, c.RotaId, c.Peso, c.Volume, c.Observacao, c.CriadoEm, c.CriadoPor);
                 var domainResult = ExperienciaPlanejamentoTransporteDomainBehavior.Apply(experienciaplanejamentotransporte, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(experienciaplanejamentotransporte);
                     return Success("OK", experienciaplanejamentotransporte);
                 }
                 catch (Exception e)
                 {
                    return Error(e, experienciaplanejamentotransporte);
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