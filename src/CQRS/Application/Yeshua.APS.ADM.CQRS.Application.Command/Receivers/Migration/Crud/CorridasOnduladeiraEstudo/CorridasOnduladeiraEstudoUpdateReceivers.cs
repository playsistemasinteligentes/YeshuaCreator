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
    public class UpdateCorridasOnduladeiraEstudoReceiver : ReciverBase<ICommand, ICorridasOnduladeiraEstudoEntity>
    {
        private readonly ICorridasOnduladeiraEstudoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateCorridasOnduladeiraEstudoReceiver(
            ICorridasOnduladeiraEstudoWriteRepository repository,
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

        protected override async Task<State<ICorridasOnduladeiraEstudoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CorridasOnduladeiraEstudoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateCorridasOnduladeiraEstudo", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateCorridasOnduladeiraEstudoReceiver), commandName: "Command.Write.CorridasOnduladeiraEstudoCrudCommand");
                 var corridasonduladeiraestudo = new CorridasOnduladeiraEstudoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.BOL_ID, c.BOL_ID_ORIGEM, c.PRO_LARGURA_PECA, c.PRO_LARGURA_PECA_PROGRAMADO, c.PRO_COMPRIMENTO_PECA, c.PRO_COMPRIMENTO_PECA_PROGRAMADO, c.PRO_UTILIZOU_REFILE_OBRIGATORIO, c.PRO_VINCOS_RECALCULADOS, c.COR_SOLVER, c.COR_GRAMATURA_PAPEIS_PROGRAMADOS, c.COR_CUSTO_PAPEIS_PROGRAMADOS, c.COR_GRAMATURA_RESINA_PROGRAMADOS, c.COR_CUSTO_RESINA_PROGRAMADOS, c.COR_TOLERANCIA_MENOS, c.COR_TOLERANCIA_MAIS, c.COR_PILHAS_POR_PALETE, c.COR_M_LINEAR_REALIZADO, c.PRO_ID_PALETE, c.COR_STATUS_PALETE, c.COR_GRUPO_PRODUTIVO);
                 var domainResult = CorridasOnduladeiraEstudoDomainBehavior.Apply(corridasonduladeiraestudo, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(corridasonduladeiraestudo);
                     return Success("OK", corridasonduladeiraestudo);
                 }
                 catch (Exception e)
                 {
                    return Error(e, corridasonduladeiraestudo);
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