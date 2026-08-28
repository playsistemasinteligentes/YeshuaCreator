// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IMaquinaQueryWrite 
     {
        public QueryModel InserirMaquinaQuery(IMaquinaEntity Maquina);
        public QueryModel UpdateMaquinaQuery(IMaquinaEntity Maquina);
        QueryModel UpdateDescricao(string id, string value);
        QueryModel UpdateStatus(string id, string value);
        QueryModel UpdateTenantID(string id, int value);
        QueryModel UpdateDeleted(string id, bool value);
        QueryModel UpdateChanged(string id, DateTime value);
        QueryModel UpdateUserId(string id, int value);
        QueryModel UpdateCAL_ID(string id, int value);
        QueryModel UpdateMAQ_CONTROL_IP(string id, string value);
        QueryModel UpdateGMA_ID(string id, string value);
        QueryModel UpdateMAQ_ULTIMA_ATUALIZACAO(string id, DateTime value);
        QueryModel UpdateMAQ_SIRENE_SEMAFORO(string id, int value);
        QueryModel UpdateMAQ_COR_SEMAFORO(string id, string value);
        QueryModel UpdateMAQ_ID_MAQ_PAI(string id, string value);
        QueryModel UpdateMAQ_TIPO_CONTADOR(string id, int value);
        QueryModel UpdateMAQ_TIPO_PLANEJAMENTO(string id, string value);
        QueryModel UpdateMAQ_AVALIA_CUSTO(string id, int value);
        QueryModel UpdateFPR_ID_OP_PRODUZINDO(string id, int value);
        QueryModel UpdateMAQ_CONGELA_FILA(string id, int value);
        QueryModel UpdateMAQ_TEMPO_MIN_PARADA(string id, int value);
        QueryModel UpdateMAQ_QTD_CORES(string id, int value);
        QueryModel UpdateMAQ_ID_INTEGRACAO(string id, string value);
        QueryModel UpdateMAQ_ID_INTEGRACAO_ERP(string id, string value);
        QueryModel UpdateMAQ_HIERARQUIA_SEQ_TRANSFORMACAO(string id, Decimal value);
        QueryModel UpdateEQU_ID(string id, string value);
        QueryModel UpdateMAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR(string id, Decimal value);
        QueryModel UpdateMAQ_ACOMPANHA_LOTE_PILOTO(string id, string value);
        QueryModel UpdateMAQ_ID_SENSOR(string id, int value);
        QueryModel UpdateMAQ_DEBOUNCING_LOW(string id, int value);
        QueryModel UpdateMAQ_DEBOUNCING_HIGHT(string id, int value);
        QueryModel UpdateMAQ_TIPO_SINAL(string id, int value);
        QueryModel UpdateTEM_ID(string id, int value);
        QueryModel UpdateMAQ_COMPRIMENTO_CHAPA_DE(string id, Decimal value);
        QueryModel UpdateMAQ_COMPRIMENTO_CHAPA_ATE(string id, Decimal value);
        QueryModel UpdateMAQ_LARGURA_CHAPA_DE(string id, Decimal value);
        QueryModel UpdateMAQ_LARGURA_CHAPA_ATE(string id, Decimal value);
        QueryModel UpdateMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR(string id, Decimal value);
        QueryModel UpdateMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR(string id, Decimal value);
        QueryModel UpdateMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR(string id, Decimal value);
        QueryModel UpdateMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR(string id, Decimal value);
        QueryModel UpdateMAQ_COMPRIMENTO_ENTRE_VINCO_DE(string id, Decimal value);
        QueryModel UpdateMAQ_COMPRIMENTO_ENTRE_VINCO_ATE(string id, Decimal value);
        QueryModel UpdateMAQ_LARGURA_ENTRE_VINCO_DE(string id, Decimal value);
        QueryModel UpdateMAQ_LARGURA_ENTRE_VINCO_ATE(string id, Decimal value);
        QueryModel UpdateMAQ_ALTURA_ENTRE_VINCO_DE(string id, Decimal value);
        QueryModel UpdateMAQ_ALTURA_ENTRE_VINCO_ATE(string id, Decimal value);
        QueryModel UpdateMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE(string id, Decimal value);
        QueryModel UpdateMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE(string id, Decimal value);
        QueryModel UpdateMAQ_ABA_DE(string id, Decimal value);
        QueryModel UpdateMAQ_ABA_ATE(string id, Decimal value);
        QueryModel UpdateMAQ_LAP_DE(string id, Decimal value);
        QueryModel UpdateMAQ_LAP_ATE(string id, Decimal value);
        QueryModel UpdateMAQ_ONDAS(string id, string value);
        QueryModel UpdateMAQ_PROLONGA_LAP(string id, string value);
        QueryModel UpdateMAQ_LARGURA_IMPRESSAO(string id, Decimal value);
        QueryModel UpdateMAQ_COMPRIMENTO_IMPRESSAO(string id, Decimal value);
        QueryModel UpdateMAQ_ROLO_DISPOSITIVO_DE(string id, Decimal value);
        QueryModel UpdateMAQ_ROLO_DISPOSITIVO_ATE(string id, Decimal value);
        QueryModel UpdateMAQ_FAMILIAS(string id, string value);
        QueryModel UpdateMAQ_REFILE_MINIMO(string id, Decimal value);
        QueryModel UpdateMAQ_LARGURA_UTIL(string id, Decimal value);
        QueryModel UpdateMAQ_TOTAL_ACO(string id, Decimal value);
        QueryModel UpdateMAQ_FECHAMENTO(string id, string value);
        QueryModel UpdateMAQ_OPERACAO_VINCAR(string id, Decimal value);
        QueryModel UpdateMAQ_OPERACAO_MONTA_DIVISAO(string id, Decimal value);
        QueryModel UpdateMAQ_OPERACAO_SERRAR(string id, Decimal value);
        QueryModel UpdateMAQ_TIPO_LAP(string id, string value);
        QueryModel UpdateMAQ_INDICE_PARADAS_POR_OP(string id, Decimal value);
        QueryModel UpdateMAQ_PERDA_MAXIMA(string id, int value);
        QueryModel UpdateMAQ_TOTAL_PECAS_REFILANDO(string id, int value);
        QueryModel UpdateMAQ_TOTAL_PECAS_NAO_REFILANDO(string id, int value);
        QueryModel UpdateMAQ_TOTAL_VINCOS(string id, int value);
        public QueryModel DeleteMaquinaQuery(IMaquinaEntity Maquina);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration