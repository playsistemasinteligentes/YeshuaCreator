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
    public class DeleteEstruturaCustoReceiver : ReciverBase<ICommand, IEstruturaCustoEntity>
    {
        private readonly IEstruturaCustoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteEstruturaCustoReceiver(
            IEstruturaCustoWriteRepository repository,
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

        protected override async Task<State<IEstruturaCustoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.EstruturaCustoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteEstruturaCusto", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteEstruturaCustoReceiver), commandName: "Command.Write.EstruturaCustoCrudCommand");
                 var estruturacusto = new EstruturaCustoFactory(_logger, _domainTrackingPolicy).Create(context, c.EST_ID, c.ITO_ID, c.ORD_ID, c.PRO_ID, c.PRO_ID_PRODUTO, c.PRO_ID_COMPONENTE, c.PRO_TIPO_CUSTO, c.PRO_GRUPO_CONTABIL, c.EST_ORDEM, c.EST_GRUPO, c.EST_QUANT, c.EST_VALOR_TOTAL, c.EST_DATA_BASE, c.EST_BASE_PRODUCAO, c.EST_NIVEL, c.FPR_SEQ_REPETICAO);
                 var domainResult = EstruturaCustoDomainBehavior.Apply(estruturacusto, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(estruturacusto);
                     return Success("OK", estruturacusto);
                 }
                 catch (Exception e)
                 {
                    return Error(e, estruturacusto);
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