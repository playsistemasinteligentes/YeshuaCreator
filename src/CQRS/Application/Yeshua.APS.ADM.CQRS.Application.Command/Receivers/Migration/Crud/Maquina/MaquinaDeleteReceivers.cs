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
    public class DeleteMaquinaReceiver : ReciverBase<ICommand, IMaquinaEntity>
    {
        private readonly IMaquinaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteMaquinaReceiver(
            IMaquinaWriteRepository repository,
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

        protected override async Task<State<IMaquinaEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.MaquinaCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteMaquina", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteMaquinaReceiver), commandName: "Command.Write.MaquinaCrudCommand");
                 var maquina = new MaquinaFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.Descricao, c.Status, c.CAL_ID, c.MAQ_CONTROL_IP, c.GMA_ID, c.MAQ_ULTIMA_ATUALIZACAO, c.MAQ_SIRENE_SEMAFORO, c.MAQ_COR_SEMAFORO, c.MAQ_ID_MAQ_PAI, c.MAQ_TIPO_CONTADOR, c.MAQ_TIPO_PLANEJAMENTO, c.MAQ_AVALIA_CUSTO, c.FPR_ID_OP_PRODUZINDO, c.MAQ_CONGELA_FILA, c.MAQ_TEMPO_MIN_PARADA, c.MAQ_QTD_CORES, c.MAQ_ID_INTEGRACAO, c.MAQ_ID_INTEGRACAO_ERP, c.MAQ_HIERARQUIA_SEQ_TRANSFORMACAO, c.EQU_ID, c.MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR, c.MAQ_ACOMPANHA_LOTE_PILOTO, c.MAQ_ID_SENSOR, c.MAQ_DEBOUNCING_LOW, c.MAQ_DEBOUNCING_HIGHT, c.MAQ_TIPO_SINAL, c.TEM_ID, c.MAQ_COMPRIMENTO_CHAPA_DE, c.MAQ_COMPRIMENTO_CHAPA_ATE, c.MAQ_LARGURA_CHAPA_DE, c.MAQ_LARGURA_CHAPA_ATE, c.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR, c.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR, c.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR, c.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR, c.MAQ_COMPRIMENTO_ENTRE_VINCO_DE, c.MAQ_COMPRIMENTO_ENTRE_VINCO_ATE, c.MAQ_LARGURA_ENTRE_VINCO_DE, c.MAQ_LARGURA_ENTRE_VINCO_ATE, c.MAQ_ALTURA_ENTRE_VINCO_DE, c.MAQ_ALTURA_ENTRE_VINCO_ATE, c.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE, c.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE, c.MAQ_ABA_DE, c.MAQ_ABA_ATE, c.MAQ_LAP_DE, c.MAQ_LAP_ATE, c.MAQ_ONDAS, c.MAQ_PROLONGA_LAP, c.MAQ_LARGURA_IMPRESSAO, c.MAQ_COMPRIMENTO_IMPRESSAO, c.MAQ_ROLO_DISPOSITIVO_DE, c.MAQ_ROLO_DISPOSITIVO_ATE, c.MAQ_FAMILIAS, c.MAQ_REFILE_MINIMO, c.MAQ_LARGURA_UTIL, c.MAQ_TOTAL_ACO, c.MAQ_FECHAMENTO, c.MAQ_OPERACAO_VINCAR, c.MAQ_OPERACAO_MONTA_DIVISAO, c.MAQ_OPERACAO_SERRAR, c.MAQ_TIPO_LAP, c.MAQ_INDICE_PARADAS_POR_OP, c.MAQ_PERDA_MAXIMA, c.MAQ_TOTAL_PECAS_REFILANDO, c.MAQ_TOTAL_PECAS_NAO_REFILANDO, c.MAQ_TOTAL_VINCOS);
                 var domainResult = MaquinaDomainBehavior.Apply(maquina, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(maquina);
                     return Success("OK", maquina);
                 }
                 catch (Exception e)
                 {
                    return Error(e, maquina);
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