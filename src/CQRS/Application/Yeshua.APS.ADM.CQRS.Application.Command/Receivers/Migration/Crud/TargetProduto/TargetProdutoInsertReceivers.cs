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
    public class InsertTargetProdutoReceiver : ReciverBase<ICommand, ITargetProdutoEntity>
    {
        private readonly ITargetProdutoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertTargetProdutoReceiver(
            ITargetProdutoWriteRepository repository,
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

        protected override async Task<State<ITargetProdutoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.TargetProdutoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertTargetProduto", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertTargetProdutoReceiver), commandName: "Command.Write.TargetProdutoCrudCommand");
                 var targetproduto = new TargetProdutoFactory(_logger, _domainTrackingPolicy).Create(context, c.TAR_ID, c.MOV_ID, c.ORD_ID, c.PRO_ID, c.MAQ_ID, c.UNI_ID, c.TURM_ID, c.TURN_ID, c.USE_ID, c.TAR_DIA_TURMA, c.TAR_META_PERFORMANCE, c.TAR_REALIZADO_PERFORMANCE, c.TAR_PERCENTUAL_REALIZADO_PERFORMANCE, c.TAR_PROXIMA_META_PERFORMANCE, c.TAR_META_TEMPO_SETUP, c.TAR_REALIZADO_TEMPO_SETUP, c.TAR_PROXIMA_META_TEMPO_SETUP, c.TAR_META_TEMPO_SETUP_AJUSTE, c.TAR_REALIZADO_TEMPO_SETUP_AJUSTE, c.TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE, c.OCO_ID_PERFORMANCE, c.TAR_OBS_PERFORMANCE, c.OCO_ID_SETUP, c.TAR_OBS_SETUP, c.OCO_ID_SETUPA, c.TAR_OBS_SETUPA, c.TAR_TIPO_FEEDBACK_PERFORMANCE, c.TAR_TIPO_FEEDBACK_SETUP, c.TAR_TIPO_FEEDBACK_SETUP_AJUSTE, c.TAR_QTD_SETUP_AJUSTE, c.TAR_QTD, c.TAR_PARAMETRO_TIME_WORK_STOP_MACHINE, c.TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE, c.ROT_SEQ_TRANFORMACAO, c.FPR_SEQ_REPETICAO, c.TAR_PERFORMANCE_MAX_VERDE, c.TAR_PERFORMANCE_MIN_VERDE, c.TAR_SETUP_MAX_VERDE, c.TAR_SETUP_MIN_VERDE, c.TAR_SETUPA_MAX_VERDE, c.TAR_SETUPA_MIN_VERDE, c.TAR_PERFORMANCE_MIN_AMARELO, c.TAR_SETUP_MAX_AMARELO, c.TAR_SETUPA_MAX_AMARELO, c.TAR_OBS_OP_PARCIAL, c.TAR_OCO_ID_OP_PARCIAL, c.TAR_COR_PERFORMANCE, c.TAR_COR_SETUP_GERAL, c.TAR_COR_SETUP, c.TAR_COR_SETUPA, c.TAR_DIA_TURMA_D, c.FEE_QTD_PECAS_POR_PULSO, c.TAR_QTD_PERDAS, c.TAR_DATA_INICIAL, c.TAR_DATA_FINAL, c.TAR_APROVADO, c.TAR_TEMPO_PRODUZINDO);
                 var domainResult = TargetProdutoDomainBehavior.Apply(targetproduto, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(targetproduto);
                     return Success("OK", targetproduto);
                 }
                 catch (Exception e)
                 {
                    return Error(e, targetproduto);
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