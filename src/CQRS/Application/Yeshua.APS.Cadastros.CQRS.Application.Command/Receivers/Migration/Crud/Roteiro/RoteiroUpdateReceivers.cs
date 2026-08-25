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
    public class UpdateRoteiroReceiver : ReciverBase<ICommand, IRoteiroEntity>
    {
        private readonly IRoteiroWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateRoteiroReceiver(
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
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateRoteiro", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateRoteiroReceiver), commandName: "Command.Write.RoteiroCrudCommand");
                 var roteiro = new RoteiroFactory(_logger, _domainTrackingPolicy).Create(context, c.MAQ_ID, c.PRO_ID, c.ROT_SEQ_TRANFORMACAO, c.GMA_ID, c.ROT_PECAS_POR_PULSO, c.ROT_PRIORIDADE_INFORMADA, c.ROT_ACAO, c.ROT_PERFORMANCE, c.ROT_TEMPO_SETUP, c.ROT_TEMPO_SETUP_AJUSTE, c.ROT_VA_PARA_SEQ_TRANSFORMACAO, c.ROT_STATUS, c.ROT_HIERARQUIA_SEQ_TRANSFORMACAO, c.ROT_AVALIA_CUSTO, c.ROT_OPERACOES, c.ROT_EXCECAO_OPERACOES, c.ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR, c.ROT_LINHA_DIRETA, c.TEM_ID);
                 var domainResult = RoteiroDomainBehavior.Apply(roteiro, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(roteiro);
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