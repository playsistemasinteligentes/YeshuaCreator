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
    public class UpdateCompensacaoReceiver : ReciverBase<ICommand, ICompensacaoEntity>
    {
        private readonly ICompensacaoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateCompensacaoReceiver(
            ICompensacaoWriteRepository repository,
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

        protected override async Task<State<ICompensacaoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CompensacaoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateCompensacao", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateCompensacaoReceiver), commandName: "Command.Write.CompensacaoCrudCommand");
                 var compensacao = new CompensacaoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.COM_ID, c.GRP_ID, c.OND_ID, c.COM_VINCO1_OND, c.COM_VINCO2_OND, c.COM_VINCO3_OND, c.COM_VINCO4_OND, c.COM_VINCO5_OND, c.COM_VINCO6_OND, c.COM_VINCO7_OND, c.COM_VINCO8_OND, c.COM_VINCO9_OND, c.COM_VINCO10_OND, c.COM_VINCO1_CONVERSAO, c.COM_VINCO2_CONVERSAO, c.COM_VINCO3_CONVERSAO, c.COM_VINCO4_CONVERSAO, c.COM_VINCO5_CONVERSAO, c.COM_VINCO6_CONVERSAO, c.COM_VINCO7_CONVERSAO, c.COM_VINCO8_CONVERSAO, c.COM_VINCO9_CONVERSAO, c.COM_VINCO10_CONVERSAO);
                 var domainResult = CompensacaoDomainBehavior.Apply(compensacao, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(compensacao);
                     return Success("OK", compensacao);
                 }
                 catch (Exception e)
                 {
                    return Error(e, compensacao);
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