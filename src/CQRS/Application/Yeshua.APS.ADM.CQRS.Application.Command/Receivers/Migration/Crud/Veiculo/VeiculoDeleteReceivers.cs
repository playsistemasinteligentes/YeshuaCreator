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
    public class DeleteVeiculoReceiver : ReciverBase<ICommand, IVeiculoEntity>
    {
        private readonly IVeiculoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteVeiculoReceiver(
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

        protected override async Task<State<IVeiculoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.VeiculoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteVeiculo", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteVeiculoReceiver), commandName: "Command.Write.VeiculoCrudCommand");
                 var veiculo = new VeiculoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.VEI_PLACA, c.TIP_ID, c.VEI_CAPACIDADE_M3, c.VEI_CAPACIDADE_LARGURA, c.VEI_CAPACIDADE_COMPRIMENTO, c.VEI_CAPACIDADE_ALTURA, c.VEI_MODELO, c.VEI_NOME_MOTORISTA, c.VEI_DADOS_CONTATO, c.VEI_CPF_MOTORISTA, c.TCA_ID, c.VEI_EMISSAO, c.VEI_VENCIMENTO, c.VEI_STATUS);
                 var domainResult = VeiculoDomainBehavior.Apply(veiculo, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(veiculo);
                     return Success("OK", veiculo);
                 }
                 catch (Exception e)
                 {
                    return Error(e, veiculo);
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