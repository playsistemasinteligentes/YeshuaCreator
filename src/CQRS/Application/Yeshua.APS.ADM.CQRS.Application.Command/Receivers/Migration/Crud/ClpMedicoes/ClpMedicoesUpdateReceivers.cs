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
    public class UpdateClpMedicoesReceiver : ReciverBase<ICommand, IClpMedicoesEntity>
    {
        private readonly IClpMedicoesWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateClpMedicoesReceiver(
            IClpMedicoesWriteRepository repository,
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

        protected override Task<State<IClpMedicoesEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ClpMedicoesCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateClpMedicoes", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateClpMedicoesReceiver), commandName: "Command.Write.ClpMedicoesCrudCommand");
                 var clpmedicoes = new ClpMedicoesFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.Id2, c.MaquinaId, c.DataInicio, c.DataFim, c.Emissao, c.Quantidade, c.Grupo, c.Status, c.TurnoId, c.TurmaId, c.IdLoteClp, c.OcorrenciaId, c.Fase, c.ClpOrigem, c.CLP_LOTE, c.COMPACTA, c.BOL_ID, c.COR_SEQUENCIA);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", clpmedicoes.OperationalEntityId);
                 var domainResult = ClpMedicoesDomainBehavior.Apply(clpmedicoes, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Update(clpmedicoes);
                     return Task.FromResult(Success("OK", clpmedicoes));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, clpmedicoes));
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