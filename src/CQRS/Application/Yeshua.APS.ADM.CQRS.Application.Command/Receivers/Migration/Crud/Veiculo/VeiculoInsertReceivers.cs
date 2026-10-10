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
    public class InsertVeiculoReceiver : ReciverBase<ICommand, IVeiculoEntity>
    {
        private readonly IVeiculoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertVeiculoReceiver(
            IVeiculoWriteRepository repository,
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

        protected override Task<State<IVeiculoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.VeiculoCrudCommand c) 
             {    
                 var trackingMask = _domainTrackingPolicy.GetMask("Veiculo", "InsertVeiculo", null);
                 var hasExecutionIdentity = _executionContext.TryGetOperationalIdentity(out var executionIdentity);
                 using var domainTrackingExecutionScope = !hasExecutionIdentity && trackingMask != 0UL ? _executionContext.BeginOperationalExecution("Command.Write.VeiculoCrudCommand") : null;
                 if (!hasExecutionIdentity && trackingMask != 0UL)
                     executionIdentity = _executionContext.OperationalIdentity;
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertVeiculo", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertVeiculoReceiver), commandName: "Command.Write.VeiculoCrudCommand", rootOperationId: executionIdentity.RootOperationId, operationId: executionIdentity.OperationId, executionId: executionIdentity.ExecutionId, causationId: executionIdentity.CausationId);
                 var veiculo = new VeiculoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.VEI_PLACA, c.VEI_UF, c.TIP_ID, c.VEI_CAPACIDADE_M3, c.VEI_CAPACIDADE_LARGURA, c.VEI_CAPACIDADE_COMPRIMENTO, c.VEI_CAPACIDADE_ALTURA, c.VEI_MODELO, c.VEI_NOME_MOTORISTA, c.VEI_DADOS_CONTATO, c.VEI_CPF_MOTORISTA, c.TCA_ID, c.VEI_EMISSAO, c.VEI_VENCIMENTO, c.VEI_STATUS, trackingMask: trackingMask);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", veiculo.OperationalEntityId);
                 var domainResult = VeiculoDomainBehavior.Apply(veiculo, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Insert(veiculo);
                     return Task.FromResult(Success("OK", veiculo));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, veiculo));
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