// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class MaquinaQueryWrite : QueryBase, IMaquinaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MaquinaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMaquinaQuery(IMaquinaEntity Maquina)
        {
            this.Query = $@" INSERT INTO Maquina (Id, Descricao, Status, TenantID, Deleted, Changed, UserId, CAL_ID, MAQ_CONTROL_IP, GMA_ID, MAQ_ULTIMA_ATUALIZACAO, MAQ_SIRENE_SEMAFORO, MAQ_COR_SEMAFORO, MAQ_ID_MAQ_PAI, MAQ_TIPO_CONTADOR, MAQ_TIPO_PLANEJAMENTO, MAQ_AVALIA_CUSTO, FPR_ID_OP_PRODUZINDO, MAQ_CONGELA_FILA, MAQ_TEMPO_MIN_PARADA, MAQ_QTD_CORES, MAQ_ID_INTEGRACAO, MAQ_ID_INTEGRACAO_ERP, MAQ_HIERARQUIA_SEQ_TRANSFORMACAO, EQU_ID, MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR, MAQ_ACOMPANHA_LOTE_PILOTO, MAQ_ID_SENSOR, MAQ_DEBOUNCING_LOW, MAQ_DEBOUNCING_HIGHT, MAQ_TIPO_SINAL, TEM_ID, MAQ_COMPRIMENTO_CHAPA_DE, MAQ_COMPRIMENTO_CHAPA_ATE, MAQ_LARGURA_CHAPA_DE, MAQ_LARGURA_CHAPA_ATE, MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR, MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR, MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR, MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR, MAQ_COMPRIMENTO_ENTRE_VINCO_DE, MAQ_COMPRIMENTO_ENTRE_VINCO_ATE, MAQ_LARGURA_ENTRE_VINCO_DE, MAQ_LARGURA_ENTRE_VINCO_ATE, MAQ_ALTURA_ENTRE_VINCO_DE, MAQ_ALTURA_ENTRE_VINCO_ATE, MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE, MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE, MAQ_ABA_DE, MAQ_ABA_ATE, MAQ_LAP_DE, MAQ_LAP_ATE, MAQ_ONDAS, MAQ_PROLONGA_LAP, MAQ_LARGURA_IMPRESSAO, MAQ_COMPRIMENTO_IMPRESSAO, MAQ_ROLO_DISPOSITIVO_DE, MAQ_ROLO_DISPOSITIVO_ATE, MAQ_FAMILIAS, MAQ_REFILE_MINIMO, MAQ_LARGURA_UTIL, MAQ_TOTAL_ACO, MAQ_FECHAMENTO, MAQ_OPERACAO_VINCAR, MAQ_OPERACAO_MONTA_DIVISAO, MAQ_OPERACAO_SERRAR, MAQ_TIPO_LAP, MAQ_INDICE_PARADAS_POR_OP, MAQ_PERDA_MAXIMA, MAQ_TOTAL_PECAS_REFILANDO, MAQ_TOTAL_PECAS_NAO_REFILANDO, MAQ_TOTAL_VINCOS) VALUES(@Id, @Descricao, @Status, @TenantID, @Deleted, @Changed, @UserId, @CAL_ID, @MAQ_CONTROL_IP, @GMA_ID, @MAQ_ULTIMA_ATUALIZACAO, @MAQ_SIRENE_SEMAFORO, @MAQ_COR_SEMAFORO, @MAQ_ID_MAQ_PAI, @MAQ_TIPO_CONTADOR, @MAQ_TIPO_PLANEJAMENTO, @MAQ_AVALIA_CUSTO, @FPR_ID_OP_PRODUZINDO, @MAQ_CONGELA_FILA, @MAQ_TEMPO_MIN_PARADA, @MAQ_QTD_CORES, @MAQ_ID_INTEGRACAO, @MAQ_ID_INTEGRACAO_ERP, @MAQ_HIERARQUIA_SEQ_TRANSFORMACAO, @EQU_ID, @MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR, @MAQ_ACOMPANHA_LOTE_PILOTO, @MAQ_ID_SENSOR, @MAQ_DEBOUNCING_LOW, @MAQ_DEBOUNCING_HIGHT, @MAQ_TIPO_SINAL, @TEM_ID, @MAQ_COMPRIMENTO_CHAPA_DE, @MAQ_COMPRIMENTO_CHAPA_ATE, @MAQ_LARGURA_CHAPA_DE, @MAQ_LARGURA_CHAPA_ATE, @MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR, @MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR, @MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR, @MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR, @MAQ_COMPRIMENTO_ENTRE_VINCO_DE, @MAQ_COMPRIMENTO_ENTRE_VINCO_ATE, @MAQ_LARGURA_ENTRE_VINCO_DE, @MAQ_LARGURA_ENTRE_VINCO_ATE, @MAQ_ALTURA_ENTRE_VINCO_DE, @MAQ_ALTURA_ENTRE_VINCO_ATE, @MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE, @MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE, @MAQ_ABA_DE, @MAQ_ABA_ATE, @MAQ_LAP_DE, @MAQ_LAP_ATE, @MAQ_ONDAS, @MAQ_PROLONGA_LAP, @MAQ_LARGURA_IMPRESSAO, @MAQ_COMPRIMENTO_IMPRESSAO, @MAQ_ROLO_DISPOSITIVO_DE, @MAQ_ROLO_DISPOSITIVO_ATE, @MAQ_FAMILIAS, @MAQ_REFILE_MINIMO, @MAQ_LARGURA_UTIL, @MAQ_TOTAL_ACO, @MAQ_FECHAMENTO, @MAQ_OPERACAO_VINCAR, @MAQ_OPERACAO_MONTA_DIVISAO, @MAQ_OPERACAO_SERRAR, @MAQ_TIPO_LAP, @MAQ_INDICE_PARADAS_POR_OP, @MAQ_PERDA_MAXIMA, @MAQ_TOTAL_PECAS_REFILANDO, @MAQ_TOTAL_PECAS_NAO_REFILANDO, @MAQ_TOTAL_VINCOS) ";
            this.Parameters = new
            {
                Id = Maquina.Id,
                Descricao = Maquina.Descricao,
                Status = Maquina.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
                CAL_ID = Maquina.CAL_ID,
                MAQ_CONTROL_IP = Maquina.MAQ_CONTROL_IP,
                GMA_ID = Maquina.GMA_ID,
                MAQ_ULTIMA_ATUALIZACAO = Maquina.MAQ_ULTIMA_ATUALIZACAO,
                MAQ_SIRENE_SEMAFORO = Maquina.MAQ_SIRENE_SEMAFORO,
                MAQ_COR_SEMAFORO = Maquina.MAQ_COR_SEMAFORO,
                MAQ_ID_MAQ_PAI = Maquina.MAQ_ID_MAQ_PAI,
                MAQ_TIPO_CONTADOR = Maquina.MAQ_TIPO_CONTADOR,
                MAQ_TIPO_PLANEJAMENTO = Maquina.MAQ_TIPO_PLANEJAMENTO,
                MAQ_AVALIA_CUSTO = Maquina.MAQ_AVALIA_CUSTO,
                FPR_ID_OP_PRODUZINDO = Maquina.FPR_ID_OP_PRODUZINDO,
                MAQ_CONGELA_FILA = Maquina.MAQ_CONGELA_FILA,
                MAQ_TEMPO_MIN_PARADA = Maquina.MAQ_TEMPO_MIN_PARADA,
                MAQ_QTD_CORES = Maquina.MAQ_QTD_CORES,
                MAQ_ID_INTEGRACAO = Maquina.MAQ_ID_INTEGRACAO,
                MAQ_ID_INTEGRACAO_ERP = Maquina.MAQ_ID_INTEGRACAO_ERP,
                MAQ_HIERARQUIA_SEQ_TRANSFORMACAO = Maquina.MAQ_HIERARQUIA_SEQ_TRANSFORMACAO,
                EQU_ID = Maquina.EQU_ID,
                MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR = Maquina.MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR,
                MAQ_ACOMPANHA_LOTE_PILOTO = Maquina.MAQ_ACOMPANHA_LOTE_PILOTO,
                MAQ_ID_SENSOR = Maquina.MAQ_ID_SENSOR,
                MAQ_DEBOUNCING_LOW = Maquina.MAQ_DEBOUNCING_LOW,
                MAQ_DEBOUNCING_HIGHT = Maquina.MAQ_DEBOUNCING_HIGHT,
                MAQ_TIPO_SINAL = Maquina.MAQ_TIPO_SINAL,
                TEM_ID = Maquina.TEM_ID,
                MAQ_COMPRIMENTO_CHAPA_DE = Maquina.MAQ_COMPRIMENTO_CHAPA_DE,
                MAQ_COMPRIMENTO_CHAPA_ATE = Maquina.MAQ_COMPRIMENTO_CHAPA_ATE,
                MAQ_LARGURA_CHAPA_DE = Maquina.MAQ_LARGURA_CHAPA_DE,
                MAQ_LARGURA_CHAPA_ATE = Maquina.MAQ_LARGURA_CHAPA_ATE,
                MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR = Maquina.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR,
                MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR = Maquina.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR,
                MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR = Maquina.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR,
                MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR = Maquina.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR,
                MAQ_COMPRIMENTO_ENTRE_VINCO_DE = Maquina.MAQ_COMPRIMENTO_ENTRE_VINCO_DE,
                MAQ_COMPRIMENTO_ENTRE_VINCO_ATE = Maquina.MAQ_COMPRIMENTO_ENTRE_VINCO_ATE,
                MAQ_LARGURA_ENTRE_VINCO_DE = Maquina.MAQ_LARGURA_ENTRE_VINCO_DE,
                MAQ_LARGURA_ENTRE_VINCO_ATE = Maquina.MAQ_LARGURA_ENTRE_VINCO_ATE,
                MAQ_ALTURA_ENTRE_VINCO_DE = Maquina.MAQ_ALTURA_ENTRE_VINCO_DE,
                MAQ_ALTURA_ENTRE_VINCO_ATE = Maquina.MAQ_ALTURA_ENTRE_VINCO_ATE,
                MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE = Maquina.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE,
                MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE = Maquina.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE,
                MAQ_ABA_DE = Maquina.MAQ_ABA_DE,
                MAQ_ABA_ATE = Maquina.MAQ_ABA_ATE,
                MAQ_LAP_DE = Maquina.MAQ_LAP_DE,
                MAQ_LAP_ATE = Maquina.MAQ_LAP_ATE,
                MAQ_ONDAS = Maquina.MAQ_ONDAS,
                MAQ_PROLONGA_LAP = Maquina.MAQ_PROLONGA_LAP,
                MAQ_LARGURA_IMPRESSAO = Maquina.MAQ_LARGURA_IMPRESSAO,
                MAQ_COMPRIMENTO_IMPRESSAO = Maquina.MAQ_COMPRIMENTO_IMPRESSAO,
                MAQ_ROLO_DISPOSITIVO_DE = Maquina.MAQ_ROLO_DISPOSITIVO_DE,
                MAQ_ROLO_DISPOSITIVO_ATE = Maquina.MAQ_ROLO_DISPOSITIVO_ATE,
                MAQ_FAMILIAS = Maquina.MAQ_FAMILIAS,
                MAQ_REFILE_MINIMO = Maquina.MAQ_REFILE_MINIMO,
                MAQ_LARGURA_UTIL = Maquina.MAQ_LARGURA_UTIL,
                MAQ_TOTAL_ACO = Maquina.MAQ_TOTAL_ACO,
                MAQ_FECHAMENTO = Maquina.MAQ_FECHAMENTO,
                MAQ_OPERACAO_VINCAR = Maquina.MAQ_OPERACAO_VINCAR,
                MAQ_OPERACAO_MONTA_DIVISAO = Maquina.MAQ_OPERACAO_MONTA_DIVISAO,
                MAQ_OPERACAO_SERRAR = Maquina.MAQ_OPERACAO_SERRAR,
                MAQ_TIPO_LAP = Maquina.MAQ_TIPO_LAP,
                MAQ_INDICE_PARADAS_POR_OP = Maquina.MAQ_INDICE_PARADAS_POR_OP,
                MAQ_PERDA_MAXIMA = Maquina.MAQ_PERDA_MAXIMA,
                MAQ_TOTAL_PECAS_REFILANDO = Maquina.MAQ_TOTAL_PECAS_REFILANDO,
                MAQ_TOTAL_PECAS_NAO_REFILANDO = Maquina.MAQ_TOTAL_PECAS_NAO_REFILANDO,
                MAQ_TOTAL_VINCOS = Maquina.MAQ_TOTAL_VINCOS,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMaquinaQuery(IMaquinaEntity Maquina)
        {
            this.Query = $@" UPDATE Maquina SET Descricao = @Descricao, Status = @Status, Changed = @Changed, UserId = @UserId, CAL_ID = @CAL_ID, MAQ_CONTROL_IP = @MAQ_CONTROL_IP, GMA_ID = @GMA_ID, MAQ_ULTIMA_ATUALIZACAO = @MAQ_ULTIMA_ATUALIZACAO, MAQ_SIRENE_SEMAFORO = @MAQ_SIRENE_SEMAFORO, MAQ_COR_SEMAFORO = @MAQ_COR_SEMAFORO, MAQ_ID_MAQ_PAI = @MAQ_ID_MAQ_PAI, MAQ_TIPO_CONTADOR = @MAQ_TIPO_CONTADOR, MAQ_TIPO_PLANEJAMENTO = @MAQ_TIPO_PLANEJAMENTO, MAQ_AVALIA_CUSTO = @MAQ_AVALIA_CUSTO, FPR_ID_OP_PRODUZINDO = @FPR_ID_OP_PRODUZINDO, MAQ_CONGELA_FILA = @MAQ_CONGELA_FILA, MAQ_TEMPO_MIN_PARADA = @MAQ_TEMPO_MIN_PARADA, MAQ_QTD_CORES = @MAQ_QTD_CORES, MAQ_ID_INTEGRACAO = @MAQ_ID_INTEGRACAO, MAQ_ID_INTEGRACAO_ERP = @MAQ_ID_INTEGRACAO_ERP, MAQ_HIERARQUIA_SEQ_TRANSFORMACAO = @MAQ_HIERARQUIA_SEQ_TRANSFORMACAO, EQU_ID = @EQU_ID, MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR = @MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR, MAQ_ACOMPANHA_LOTE_PILOTO = @MAQ_ACOMPANHA_LOTE_PILOTO, MAQ_ID_SENSOR = @MAQ_ID_SENSOR, MAQ_DEBOUNCING_LOW = @MAQ_DEBOUNCING_LOW, MAQ_DEBOUNCING_HIGHT = @MAQ_DEBOUNCING_HIGHT, MAQ_TIPO_SINAL = @MAQ_TIPO_SINAL, TEM_ID = @TEM_ID, MAQ_COMPRIMENTO_CHAPA_DE = @MAQ_COMPRIMENTO_CHAPA_DE, MAQ_COMPRIMENTO_CHAPA_ATE = @MAQ_COMPRIMENTO_CHAPA_ATE, MAQ_LARGURA_CHAPA_DE = @MAQ_LARGURA_CHAPA_DE, MAQ_LARGURA_CHAPA_ATE = @MAQ_LARGURA_CHAPA_ATE, MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR = @MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR, MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR = @MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR, MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR = @MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR, MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR = @MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR, MAQ_COMPRIMENTO_ENTRE_VINCO_DE = @MAQ_COMPRIMENTO_ENTRE_VINCO_DE, MAQ_COMPRIMENTO_ENTRE_VINCO_ATE = @MAQ_COMPRIMENTO_ENTRE_VINCO_ATE, MAQ_LARGURA_ENTRE_VINCO_DE = @MAQ_LARGURA_ENTRE_VINCO_DE, MAQ_LARGURA_ENTRE_VINCO_ATE = @MAQ_LARGURA_ENTRE_VINCO_ATE, MAQ_ALTURA_ENTRE_VINCO_DE = @MAQ_ALTURA_ENTRE_VINCO_DE, MAQ_ALTURA_ENTRE_VINCO_ATE = @MAQ_ALTURA_ENTRE_VINCO_ATE, MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE = @MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE, MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE = @MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE, MAQ_ABA_DE = @MAQ_ABA_DE, MAQ_ABA_ATE = @MAQ_ABA_ATE, MAQ_LAP_DE = @MAQ_LAP_DE, MAQ_LAP_ATE = @MAQ_LAP_ATE, MAQ_ONDAS = @MAQ_ONDAS, MAQ_PROLONGA_LAP = @MAQ_PROLONGA_LAP, MAQ_LARGURA_IMPRESSAO = @MAQ_LARGURA_IMPRESSAO, MAQ_COMPRIMENTO_IMPRESSAO = @MAQ_COMPRIMENTO_IMPRESSAO, MAQ_ROLO_DISPOSITIVO_DE = @MAQ_ROLO_DISPOSITIVO_DE, MAQ_ROLO_DISPOSITIVO_ATE = @MAQ_ROLO_DISPOSITIVO_ATE, MAQ_FAMILIAS = @MAQ_FAMILIAS, MAQ_REFILE_MINIMO = @MAQ_REFILE_MINIMO, MAQ_LARGURA_UTIL = @MAQ_LARGURA_UTIL, MAQ_TOTAL_ACO = @MAQ_TOTAL_ACO, MAQ_FECHAMENTO = @MAQ_FECHAMENTO, MAQ_OPERACAO_VINCAR = @MAQ_OPERACAO_VINCAR, MAQ_OPERACAO_MONTA_DIVISAO = @MAQ_OPERACAO_MONTA_DIVISAO, MAQ_OPERACAO_SERRAR = @MAQ_OPERACAO_SERRAR, MAQ_TIPO_LAP = @MAQ_TIPO_LAP, MAQ_INDICE_PARADAS_POR_OP = @MAQ_INDICE_PARADAS_POR_OP, MAQ_PERDA_MAXIMA = @MAQ_PERDA_MAXIMA, MAQ_TOTAL_PECAS_REFILANDO = @MAQ_TOTAL_PECAS_REFILANDO, MAQ_TOTAL_PECAS_NAO_REFILANDO = @MAQ_TOTAL_PECAS_NAO_REFILANDO, MAQ_TOTAL_VINCOS = @MAQ_TOTAL_VINCOS WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = Maquina.Descricao,
                Status = Maquina.Status,
                Changed = Maquina.Changed,
                UserId = _executionContext.UserId,
                CAL_ID = Maquina.CAL_ID,
                MAQ_CONTROL_IP = Maquina.MAQ_CONTROL_IP,
                GMA_ID = Maquina.GMA_ID,
                MAQ_ULTIMA_ATUALIZACAO = Maquina.MAQ_ULTIMA_ATUALIZACAO,
                MAQ_SIRENE_SEMAFORO = Maquina.MAQ_SIRENE_SEMAFORO,
                MAQ_COR_SEMAFORO = Maquina.MAQ_COR_SEMAFORO,
                MAQ_ID_MAQ_PAI = Maquina.MAQ_ID_MAQ_PAI,
                MAQ_TIPO_CONTADOR = Maquina.MAQ_TIPO_CONTADOR,
                MAQ_TIPO_PLANEJAMENTO = Maquina.MAQ_TIPO_PLANEJAMENTO,
                MAQ_AVALIA_CUSTO = Maquina.MAQ_AVALIA_CUSTO,
                FPR_ID_OP_PRODUZINDO = Maquina.FPR_ID_OP_PRODUZINDO,
                MAQ_CONGELA_FILA = Maquina.MAQ_CONGELA_FILA,
                MAQ_TEMPO_MIN_PARADA = Maquina.MAQ_TEMPO_MIN_PARADA,
                MAQ_QTD_CORES = Maquina.MAQ_QTD_CORES,
                MAQ_ID_INTEGRACAO = Maquina.MAQ_ID_INTEGRACAO,
                MAQ_ID_INTEGRACAO_ERP = Maquina.MAQ_ID_INTEGRACAO_ERP,
                MAQ_HIERARQUIA_SEQ_TRANSFORMACAO = Maquina.MAQ_HIERARQUIA_SEQ_TRANSFORMACAO,
                EQU_ID = Maquina.EQU_ID,
                MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR = Maquina.MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR,
                MAQ_ACOMPANHA_LOTE_PILOTO = Maquina.MAQ_ACOMPANHA_LOTE_PILOTO,
                MAQ_ID_SENSOR = Maquina.MAQ_ID_SENSOR,
                MAQ_DEBOUNCING_LOW = Maquina.MAQ_DEBOUNCING_LOW,
                MAQ_DEBOUNCING_HIGHT = Maquina.MAQ_DEBOUNCING_HIGHT,
                MAQ_TIPO_SINAL = Maquina.MAQ_TIPO_SINAL,
                TEM_ID = Maquina.TEM_ID,
                MAQ_COMPRIMENTO_CHAPA_DE = Maquina.MAQ_COMPRIMENTO_CHAPA_DE,
                MAQ_COMPRIMENTO_CHAPA_ATE = Maquina.MAQ_COMPRIMENTO_CHAPA_ATE,
                MAQ_LARGURA_CHAPA_DE = Maquina.MAQ_LARGURA_CHAPA_DE,
                MAQ_LARGURA_CHAPA_ATE = Maquina.MAQ_LARGURA_CHAPA_ATE,
                MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR = Maquina.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR,
                MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR = Maquina.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR,
                MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR = Maquina.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR,
                MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR = Maquina.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR,
                MAQ_COMPRIMENTO_ENTRE_VINCO_DE = Maquina.MAQ_COMPRIMENTO_ENTRE_VINCO_DE,
                MAQ_COMPRIMENTO_ENTRE_VINCO_ATE = Maquina.MAQ_COMPRIMENTO_ENTRE_VINCO_ATE,
                MAQ_LARGURA_ENTRE_VINCO_DE = Maquina.MAQ_LARGURA_ENTRE_VINCO_DE,
                MAQ_LARGURA_ENTRE_VINCO_ATE = Maquina.MAQ_LARGURA_ENTRE_VINCO_ATE,
                MAQ_ALTURA_ENTRE_VINCO_DE = Maquina.MAQ_ALTURA_ENTRE_VINCO_DE,
                MAQ_ALTURA_ENTRE_VINCO_ATE = Maquina.MAQ_ALTURA_ENTRE_VINCO_ATE,
                MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE = Maquina.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE,
                MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE = Maquina.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE,
                MAQ_ABA_DE = Maquina.MAQ_ABA_DE,
                MAQ_ABA_ATE = Maquina.MAQ_ABA_ATE,
                MAQ_LAP_DE = Maquina.MAQ_LAP_DE,
                MAQ_LAP_ATE = Maquina.MAQ_LAP_ATE,
                MAQ_ONDAS = Maquina.MAQ_ONDAS,
                MAQ_PROLONGA_LAP = Maquina.MAQ_PROLONGA_LAP,
                MAQ_LARGURA_IMPRESSAO = Maquina.MAQ_LARGURA_IMPRESSAO,
                MAQ_COMPRIMENTO_IMPRESSAO = Maquina.MAQ_COMPRIMENTO_IMPRESSAO,
                MAQ_ROLO_DISPOSITIVO_DE = Maquina.MAQ_ROLO_DISPOSITIVO_DE,
                MAQ_ROLO_DISPOSITIVO_ATE = Maquina.MAQ_ROLO_DISPOSITIVO_ATE,
                MAQ_FAMILIAS = Maquina.MAQ_FAMILIAS,
                MAQ_REFILE_MINIMO = Maquina.MAQ_REFILE_MINIMO,
                MAQ_LARGURA_UTIL = Maquina.MAQ_LARGURA_UTIL,
                MAQ_TOTAL_ACO = Maquina.MAQ_TOTAL_ACO,
                MAQ_FECHAMENTO = Maquina.MAQ_FECHAMENTO,
                MAQ_OPERACAO_VINCAR = Maquina.MAQ_OPERACAO_VINCAR,
                MAQ_OPERACAO_MONTA_DIVISAO = Maquina.MAQ_OPERACAO_MONTA_DIVISAO,
                MAQ_OPERACAO_SERRAR = Maquina.MAQ_OPERACAO_SERRAR,
                MAQ_TIPO_LAP = Maquina.MAQ_TIPO_LAP,
                MAQ_INDICE_PARADAS_POR_OP = Maquina.MAQ_INDICE_PARADAS_POR_OP,
                MAQ_PERDA_MAXIMA = Maquina.MAQ_PERDA_MAXIMA,
                MAQ_TOTAL_PECAS_REFILANDO = Maquina.MAQ_TOTAL_PECAS_REFILANDO,
                MAQ_TOTAL_PECAS_NAO_REFILANDO = Maquina.MAQ_TOTAL_PECAS_NAO_REFILANDO,
                MAQ_TOTAL_VINCOS = Maquina.MAQ_TOTAL_VINCOS,
                Id = Maquina.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescricao(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET Descricao = @Descricao WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string id, bool value)
        {
            this.Query = $@" UPDATE Maquina SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string id, DateTime value)
        {
            this.Query = $@" UPDATE Maquina SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAL_ID(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET CAL_ID = @CAL_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CAL_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_CONTROL_IP(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_CONTROL_IP = @MAQ_CONTROL_IP WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_CONTROL_IP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGMA_ID(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET GMA_ID = @GMA_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                GMA_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ULTIMA_ATUALIZACAO(string id, DateTime value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_ULTIMA_ATUALIZACAO = @MAQ_ULTIMA_ATUALIZACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ULTIMA_ATUALIZACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_SIRENE_SEMAFORO(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_SIRENE_SEMAFORO = @MAQ_SIRENE_SEMAFORO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_SIRENE_SEMAFORO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_COR_SEMAFORO(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_COR_SEMAFORO = @MAQ_COR_SEMAFORO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_COR_SEMAFORO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID_MAQ_PAI(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_ID_MAQ_PAI = @MAQ_ID_MAQ_PAI WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ID_MAQ_PAI = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_TIPO_CONTADOR(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_TIPO_CONTADOR = @MAQ_TIPO_CONTADOR WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_TIPO_CONTADOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_TIPO_PLANEJAMENTO(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_TIPO_PLANEJAMENTO = @MAQ_TIPO_PLANEJAMENTO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_TIPO_PLANEJAMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_AVALIA_CUSTO(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_AVALIA_CUSTO = @MAQ_AVALIA_CUSTO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_AVALIA_CUSTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_ID_OP_PRODUZINDO(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET FPR_ID_OP_PRODUZINDO = @FPR_ID_OP_PRODUZINDO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_ID_OP_PRODUZINDO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_CONGELA_FILA(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_CONGELA_FILA = @MAQ_CONGELA_FILA WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_CONGELA_FILA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_TEMPO_MIN_PARADA(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_TEMPO_MIN_PARADA = @MAQ_TEMPO_MIN_PARADA WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_TEMPO_MIN_PARADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_QTD_CORES(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_QTD_CORES = @MAQ_QTD_CORES WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_QTD_CORES = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID_INTEGRACAO(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_ID_INTEGRACAO = @MAQ_ID_INTEGRACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ID_INTEGRACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID_INTEGRACAO_ERP(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_ID_INTEGRACAO_ERP = @MAQ_ID_INTEGRACAO_ERP WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ID_INTEGRACAO_ERP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_HIERARQUIA_SEQ_TRANSFORMACAO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_HIERARQUIA_SEQ_TRANSFORMACAO = @MAQ_HIERARQUIA_SEQ_TRANSFORMACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_HIERARQUIA_SEQ_TRANSFORMACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEQU_ID(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET EQU_ID = @EQU_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                EQU_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR = @MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ACOMPANHA_LOTE_PILOTO(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_ACOMPANHA_LOTE_PILOTO = @MAQ_ACOMPANHA_LOTE_PILOTO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ACOMPANHA_LOTE_PILOTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID_SENSOR(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_ID_SENSOR = @MAQ_ID_SENSOR WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ID_SENSOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_DEBOUNCING_LOW(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_DEBOUNCING_LOW = @MAQ_DEBOUNCING_LOW WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_DEBOUNCING_LOW = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_DEBOUNCING_HIGHT(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_DEBOUNCING_HIGHT = @MAQ_DEBOUNCING_HIGHT WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_DEBOUNCING_HIGHT = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_TIPO_SINAL(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_TIPO_SINAL = @MAQ_TIPO_SINAL WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_TIPO_SINAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTEM_ID(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET TEM_ID = @TEM_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                TEM_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_COMPRIMENTO_CHAPA_DE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_COMPRIMENTO_CHAPA_DE = @MAQ_COMPRIMENTO_CHAPA_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_COMPRIMENTO_CHAPA_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_COMPRIMENTO_CHAPA_ATE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_COMPRIMENTO_CHAPA_ATE = @MAQ_COMPRIMENTO_CHAPA_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_COMPRIMENTO_CHAPA_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_LARGURA_CHAPA_DE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_LARGURA_CHAPA_DE = @MAQ_LARGURA_CHAPA_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_LARGURA_CHAPA_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_LARGURA_CHAPA_ATE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_LARGURA_CHAPA_ATE = @MAQ_LARGURA_CHAPA_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_LARGURA_CHAPA_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR = @MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR = @MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR = @MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR = @MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_COMPRIMENTO_ENTRE_VINCO_DE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_COMPRIMENTO_ENTRE_VINCO_DE = @MAQ_COMPRIMENTO_ENTRE_VINCO_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_COMPRIMENTO_ENTRE_VINCO_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_COMPRIMENTO_ENTRE_VINCO_ATE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_COMPRIMENTO_ENTRE_VINCO_ATE = @MAQ_COMPRIMENTO_ENTRE_VINCO_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_COMPRIMENTO_ENTRE_VINCO_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_LARGURA_ENTRE_VINCO_DE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_LARGURA_ENTRE_VINCO_DE = @MAQ_LARGURA_ENTRE_VINCO_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_LARGURA_ENTRE_VINCO_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_LARGURA_ENTRE_VINCO_ATE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_LARGURA_ENTRE_VINCO_ATE = @MAQ_LARGURA_ENTRE_VINCO_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_LARGURA_ENTRE_VINCO_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ALTURA_ENTRE_VINCO_DE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_ALTURA_ENTRE_VINCO_DE = @MAQ_ALTURA_ENTRE_VINCO_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ALTURA_ENTRE_VINCO_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ALTURA_ENTRE_VINCO_ATE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_ALTURA_ENTRE_VINCO_ATE = @MAQ_ALTURA_ENTRE_VINCO_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ALTURA_ENTRE_VINCO_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE = @MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE = @MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ABA_DE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_ABA_DE = @MAQ_ABA_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ABA_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ABA_ATE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_ABA_ATE = @MAQ_ABA_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ABA_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_LAP_DE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_LAP_DE = @MAQ_LAP_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_LAP_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_LAP_ATE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_LAP_ATE = @MAQ_LAP_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_LAP_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ONDAS(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_ONDAS = @MAQ_ONDAS WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ONDAS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_PROLONGA_LAP(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_PROLONGA_LAP = @MAQ_PROLONGA_LAP WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_PROLONGA_LAP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_LARGURA_IMPRESSAO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_LARGURA_IMPRESSAO = @MAQ_LARGURA_IMPRESSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_LARGURA_IMPRESSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_COMPRIMENTO_IMPRESSAO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_COMPRIMENTO_IMPRESSAO = @MAQ_COMPRIMENTO_IMPRESSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_COMPRIMENTO_IMPRESSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ROLO_DISPOSITIVO_DE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_ROLO_DISPOSITIVO_DE = @MAQ_ROLO_DISPOSITIVO_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ROLO_DISPOSITIVO_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ROLO_DISPOSITIVO_ATE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_ROLO_DISPOSITIVO_ATE = @MAQ_ROLO_DISPOSITIVO_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ROLO_DISPOSITIVO_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_FAMILIAS(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_FAMILIAS = @MAQ_FAMILIAS WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_FAMILIAS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_REFILE_MINIMO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_REFILE_MINIMO = @MAQ_REFILE_MINIMO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_REFILE_MINIMO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_LARGURA_UTIL(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_LARGURA_UTIL = @MAQ_LARGURA_UTIL WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_LARGURA_UTIL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_TOTAL_ACO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_TOTAL_ACO = @MAQ_TOTAL_ACO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_TOTAL_ACO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_FECHAMENTO(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_FECHAMENTO = @MAQ_FECHAMENTO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_FECHAMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_OPERACAO_VINCAR(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_OPERACAO_VINCAR = @MAQ_OPERACAO_VINCAR WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_OPERACAO_VINCAR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_OPERACAO_MONTA_DIVISAO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_OPERACAO_MONTA_DIVISAO = @MAQ_OPERACAO_MONTA_DIVISAO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_OPERACAO_MONTA_DIVISAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_OPERACAO_SERRAR(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_OPERACAO_SERRAR = @MAQ_OPERACAO_SERRAR WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_OPERACAO_SERRAR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_TIPO_LAP(string id, string value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_TIPO_LAP = @MAQ_TIPO_LAP WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_TIPO_LAP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_INDICE_PARADAS_POR_OP(string id, Decimal value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_INDICE_PARADAS_POR_OP = @MAQ_INDICE_PARADAS_POR_OP WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_INDICE_PARADAS_POR_OP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_PERDA_MAXIMA(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_PERDA_MAXIMA = @MAQ_PERDA_MAXIMA WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_PERDA_MAXIMA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_TOTAL_PECAS_REFILANDO(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_TOTAL_PECAS_REFILANDO = @MAQ_TOTAL_PECAS_REFILANDO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_TOTAL_PECAS_REFILANDO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_TOTAL_PECAS_NAO_REFILANDO(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_TOTAL_PECAS_NAO_REFILANDO = @MAQ_TOTAL_PECAS_NAO_REFILANDO WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_TOTAL_PECAS_NAO_REFILANDO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_TOTAL_VINCOS(string id, int value)
        {
            this.Query = $@" UPDATE Maquina SET MAQ_TOTAL_VINCOS = @MAQ_TOTAL_VINCOS WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_TOTAL_VINCOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMaquinaQuery(IMaquinaEntity Maquina)
        {
            this.Query = $@" DELETE FROM Maquina WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Maquina.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration