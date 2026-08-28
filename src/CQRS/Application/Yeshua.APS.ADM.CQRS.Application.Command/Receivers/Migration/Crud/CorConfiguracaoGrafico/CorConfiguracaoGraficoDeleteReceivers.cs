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
    public class DeleteCorConfiguracaoGraficoReceiver : ReciverBase<ICommand, ICorConfiguracaoGraficoEntity>
    {
        private readonly ICorConfiguracaoGraficoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteCorConfiguracaoGraficoReceiver(
            ICorConfiguracaoGraficoWriteRepository repository,
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

        protected override async Task<State<ICorConfiguracaoGraficoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CorConfiguracaoGraficoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteCorConfiguracaoGrafico", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteCorConfiguracaoGraficoReceiver), commandName: "Command.Write.CorConfiguracaoGraficoCrudCommand");
                 var corconfiguracaografico = new CorConfiguracaoGraficoFactory(_logger, _domainTrackingPolicy).Create(context, c.COR_ID, c.COR_PERCENTUAL_INI, c.COR_PERCENTUAL_FIM, c.COR_DESCRICAO);
                 var domainResult = CorConfiguracaoGraficoDomainBehavior.Apply(corconfiguracaografico, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(corconfiguracaografico);
                     return Success("OK", corconfiguracaografico);
                 }
                 catch (Exception e)
                 {
                    return Error(e, corconfiguracaografico);
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