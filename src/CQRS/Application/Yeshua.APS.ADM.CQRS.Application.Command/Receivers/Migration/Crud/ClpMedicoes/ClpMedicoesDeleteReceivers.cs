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
    public class DeleteClpMedicoesReceiver : ReciverBase<ICommand, IClpMedicoesEntity>
    {
        private readonly IClpMedicoesWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteClpMedicoesReceiver(
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

        protected override async Task<State<IClpMedicoesEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ClpMedicoesCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteClpMedicoes", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteClpMedicoesReceiver), commandName: "Command.Write.ClpMedicoesCrudCommand");
                 var clpmedicoes = new ClpMedicoesFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.Id2, c.MaquinaId, c.DataInicio, c.DataFim, c.Emissao, c.Quantidade, c.Grupo, c.Status, c.TurnoId, c.TurmaId, c.IdLoteClp, c.OcorrenciaId, c.Fase, c.ClpOrigem, c.CLP_LOTE, c.COMPACTA, c.BOL_ID, c.COR_SEQUENCIA);
                 var domainResult = ClpMedicoesDomainBehavior.Apply(clpmedicoes, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(clpmedicoes);
                     return Success("OK", clpmedicoes);
                 }
                 catch (Exception e)
                 {
                    return Error(e, clpmedicoes);
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