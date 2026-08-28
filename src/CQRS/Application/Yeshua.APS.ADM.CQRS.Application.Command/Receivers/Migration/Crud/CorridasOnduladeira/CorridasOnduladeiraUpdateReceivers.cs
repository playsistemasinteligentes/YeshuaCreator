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
    public class UpdateCorridasOnduladeiraReceiver : ReciverBase<ICommand, ICorridasOnduladeiraEntity>
    {
        private readonly ICorridasOnduladeiraWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateCorridasOnduladeiraReceiver(
            ICorridasOnduladeiraWriteRepository repository,
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

        protected override async Task<State<ICorridasOnduladeiraEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CorridasOnduladeiraCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateCorridasOnduladeira", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateCorridasOnduladeiraReceiver), commandName: "Command.Write.CorridasOnduladeiraCrudCommand");
                 var corridasonduladeira = new CorridasOnduladeiraFactory(_logger, _domainTrackingPolicy).Create(context, c.BOL_ID, c.BOL_ID_ORIGEM, c.PRO_LARGURA_PECA, c.PRO_LARGURA_PECA_PROGRAMADO, c.PRO_COMPRIMENTO_PECA, c.PRO_COMPRIMENTO_PECA_PROGRAMADO, c.PRO_UTILIZOU_REFILE_OBRIGATORIO, c.PRO_VINCOS_RECALCULADOS, c.COR_SOLVER, c.COR_GRAMATURA_PAPEIS_PROGRAMADOS, c.COR_CUSTO_PAPEIS_PROGRAMADOS, c.COR_GRAMATURA_RESINA_PROGRAMADOS, c.COR_CUSTO_RESINA_PROGRAMADOS, c.COR_TOLERANCIA_MENOS, c.COR_TOLERANCIA_MAIS, c.COR_PILHAS_POR_PALETE, c.COR_COR_FILA, c.COR_M_LINEAR_REALIZADO, c.PRO_ID_PALETE, c.COR_STATUS_PALETE, c.COR_GRUPO_PRODUTIVO, c.COR_ID, c.COR_STATUS, c.COR_STATUS_INTERFACE, c.MAQ_ID, c.COR_ID_INTERFACE, c.COR_SEQUENCIA, c.COR_SEQUENCIA_ORIGEM, c.ORD_ID, c.FPR_SEQ_REPETICAO, c.ROT_SEQ_TRANFORMACAO, c.COR_FACAO, c.COR_FORMATO_BOBINA, c.COR_INICIO_PREVISTO, c.COR_FIM_PREVISTO, c.PRO_ID, c.COR_QTD_PLANEJADO, c.PRO_QTD_PACAS, c.COR_PECAS_LARGURA);
                 var domainResult = CorridasOnduladeiraDomainBehavior.Apply(corridasonduladeira, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(corridasonduladeira);
                     return Success("OK", corridasonduladeira);
                 }
                 catch (Exception e)
                 {
                    return Error(e, corridasonduladeira);
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