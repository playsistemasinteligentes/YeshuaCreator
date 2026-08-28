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
    public class UpdateFilaProducaoPrevistaReceiver : ReciverBase<ICommand, IFilaProducaoPrevistaEntity>
    {
        private readonly IFilaProducaoPrevistaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateFilaProducaoPrevistaReceiver(
            IFilaProducaoPrevistaWriteRepository repository,
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

        protected override async Task<State<IFilaProducaoPrevistaEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.FilaProducaoPrevistaCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateFilaProducaoPrevista", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateFilaProducaoPrevistaReceiver), commandName: "Command.Write.FilaProducaoPrevistaCrudCommand");
                 var filaproducaoprevista = new FilaProducaoPrevistaFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.ORD_ID, c.ROT_PRO_ID, c.FPR_QUANTIDADE_PREVISTA, c.ROT_MAQ_ID, c.FPR_DATA_INICIO_PREVISTA, c.FPR_DATA_FIM_PREVISTA, c.FPR_DATA_FIM_MAXIMA, c.ROT_SEQ_TRANFORMACAO, c.FPR_SEQ_REPETICAO, c.FPR_OBS_PRODUCAO, c.FPR_STATUS, c.FPR_TEMPO_DECORRIDO_SETUP, c.FPR_TEMPO_DECORRIDO_SETUPA, c.FPR_TEMPO_DECORRIDO_PERFORMANC, c.FPR_TEMPO_DECO_PEQUENA_PARADA, c.FPR_QTD_PERFORMANCE, c.FPR_QTD_SETUP, c.FPR_QTD_PRODUZIDA, c.FPR_TEMPO_TEORICO_PERFORMANCE, c.FPR_TEMPO_RESTANTE_PERFORMANC, c.FPR_VELOCIDADE_P_ATINGIR_META, c.FPR_QTD_RESTANTE, c.FPR_VELO_ATU_PC_SEGUNDO, c.FPR_PERFORMANCE_PROJETADA, c.FPR_TEMPO_RESTANTE_TOTAL, c.FPR_FIM_PREVISTO_ATUAL, c.FPR_PRODUZINDO, c.FPR_ORDEM_NA_FILA, c.FPR_ID_INTEGRACAO, c.FPR_TRUNCADO, c.FPR_DATA_TRUNC_INI, c.FPR_DATA_TRUNC_FIM, c.FPR_ID, c.FPR_COR_FILA, c.MAQ_ID_MANUAL, c.MAQ_ID_RESTRINGIDA, c.FPR_PREVISAO_MATERIA_PRIMA, c.FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, c.FPR_DATA_NECESSIDADE_FIM_PRODUCAO, c.FPR_GRUPO_PRODUTIVO, c.FPR_INICIO_GRUPO_PRODUTIVO, c.FPR_FIM_GRUPO_PRODUTIVO, c.FPR_COR_BICO1, c.FPR_COR_BICO2, c.FPR_COR_BICO3, c.FPR_COR_BICO4, c.FPR_COR_BICO5, c.FPR_META_SETUP, c.FPR_ORD_ID_REPROGRAMADO, c.FPR_PRIORIDADE, c.FPR_SEQ_INCLUSAO_FILA, c.FPR_HIERARQUIA_SEQ_TRANSFORMACAO, c.FPR_ID_ORIGEM, c.FPR_DATA_ENTREGA, c.EQU_ID, c.FPR_GRUPO_PRODUTIVO_MANUAL, c.FPR_EMISSAO, c.FPR_MOTIVO_PULA_FILA, c.OCO_ID, c.FPR_PESO_UNITARIO, c.FPR_M2_UNITARIO);
                 var domainResult = FilaProducaoPrevistaDomainBehavior.Apply(filaproducaoprevista, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(filaproducaoprevista);
                     return Success("OK", filaproducaoprevista);
                 }
                 catch (Exception e)
                 {
                    return Error(e, filaproducaoprevista);
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