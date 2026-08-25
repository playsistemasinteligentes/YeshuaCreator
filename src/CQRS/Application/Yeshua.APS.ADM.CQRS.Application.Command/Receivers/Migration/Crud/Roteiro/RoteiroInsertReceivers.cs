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
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertRoteiroReceiver : ReciverBase<ICommand, IRoteiroEntity>
    {
        private readonly IRoteiroWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertRoteiroReceiver(
            IRoteiroWriteRepository repository,
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

        protected override State<IRoteiroEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.RoteiroCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertRoteiro", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertRoteiroReceiver), commandName: "Command.Write.RoteiroCrudCommand");
                 var roteiro = new RoteiroFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.MaquinaId, c.ProdutoId, c.SequenciaTransformacao, c.GrupoMaquinaId, c.PecasPorPulso, c.PrioridadeInformada, c.Acao, c.Performance, c.TempoSetup, c.TempoSetupAjuste, c.ProximaSequenciaTransformacao, c.Status, c.HierarquiaSequenciaTransformacao, c.AvaliaCusto, c.Operacoes, c.ExcecaoOperacoes, c.PercentualInicioPassoAnterior, c.LinhaDireta, c.TemplateDeTestesId);
                 var domainResult = RoteiroDomainBehavior.Apply(roteiro, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(roteiro);
                     return Success("OK", roteiro);
                 }
                 catch (Exception e)
                 {
                    return Error(e, roteiro);
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