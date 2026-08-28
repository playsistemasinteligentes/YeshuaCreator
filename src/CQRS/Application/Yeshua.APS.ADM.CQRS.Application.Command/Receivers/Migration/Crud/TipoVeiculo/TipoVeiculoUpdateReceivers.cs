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
    public class UpdateTipoVeiculoReceiver : ReciverBase<ICommand, ITipoVeiculoEntity>
    {
        private readonly ITipoVeiculoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateTipoVeiculoReceiver(
            ITipoVeiculoWriteRepository repository,
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

        protected override async Task<State<ITipoVeiculoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.TipoVeiculoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateTipoVeiculo", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateTipoVeiculoReceiver), commandName: "Command.Write.TipoVeiculoCrudCommand");
                 var tipoveiculo = new TipoVeiculoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.TIP_ID, c.TIP_DESCRICAO, c.TIP_QTD_DISPONIVEL, c.TIP_VALOR_KM, c.TIP_VALOR_DIARIA, c.TIP_VALOR_AJUDANTE, c.TIP_QTD_EIXOS, c.TIP_VELOCIDADE_MEDIA, c.TIP_CAPACIDADE_ALTURA, c.TIP_CAPACIDADE_COMPRIMENTO, c.TIP_CAPACIDADE_LARGURA, c.TIP_CAPACIDADE_ALTURA_PESCOCO_E, c.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E, c.TIP_CAPACIDADE_LARGURA_PESCOCO_E, c.TIP_CAPACIDADE_ALTURA_PESCOCO_D, c.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D, c.TIP_CAPACIDADE_LARGURA_PESCOCO_D, c.TIP_CAPACIDADE_M3);
                 var domainResult = TipoVeiculoDomainBehavior.Apply(tipoveiculo, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(tipoveiculo);
                     return Success("OK", tipoveiculo);
                 }
                 catch (Exception e)
                 {
                    return Error(e, tipoveiculo);
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