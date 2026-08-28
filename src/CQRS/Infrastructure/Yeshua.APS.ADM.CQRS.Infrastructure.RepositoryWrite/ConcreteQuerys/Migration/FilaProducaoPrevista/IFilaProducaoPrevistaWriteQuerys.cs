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

    public interface IFilaProducaoPrevistaQueryWrite 
     {
        public QueryModel InserirFilaProducaoPrevistaQuery(IFilaProducaoPrevistaEntity FilaProducaoPrevista);
        public QueryModel UpdateFilaProducaoPrevistaQuery(IFilaProducaoPrevistaEntity FilaProducaoPrevista);
        QueryModel UpdateORD_ID(int id, string value);
        QueryModel UpdateROT_PRO_ID(int id, string value);
        QueryModel UpdateFPR_QUANTIDADE_PREVISTA(int id, Decimal value);
        QueryModel UpdateROT_MAQ_ID(int id, string value);
        QueryModel UpdateFPR_DATA_INICIO_PREVISTA(int id, DateTime value);
        QueryModel UpdateFPR_DATA_FIM_PREVISTA(int id, DateTime value);
        QueryModel UpdateFPR_DATA_FIM_MAXIMA(int id, DateTime value);
        QueryModel UpdateROT_SEQ_TRANFORMACAO(int id, int value);
        QueryModel UpdateFPR_SEQ_REPETICAO(int id, int value);
        QueryModel UpdateFPR_OBS_PRODUCAO(int id, string value);
        QueryModel UpdateFPR_STATUS(int id, string value);
        QueryModel UpdateFPR_TEMPO_DECORRIDO_SETUP(int id, Decimal value);
        QueryModel UpdateFPR_TEMPO_DECORRIDO_SETUPA(int id, Decimal value);
        QueryModel UpdateFPR_TEMPO_DECORRIDO_PERFORMANC(int id, Decimal value);
        QueryModel UpdateFPR_TEMPO_DECO_PEQUENA_PARADA(int id, Decimal value);
        QueryModel UpdateFPR_QTD_PERFORMANCE(int id, Decimal value);
        QueryModel UpdateFPR_QTD_SETUP(int id, Decimal value);
        QueryModel UpdateFPR_QTD_PRODUZIDA(int id, Decimal value);
        QueryModel UpdateFPR_TEMPO_TEORICO_PERFORMANCE(int id, Decimal value);
        QueryModel UpdateFPR_TEMPO_RESTANTE_PERFORMANC(int id, Decimal value);
        QueryModel UpdateFPR_VELOCIDADE_P_ATINGIR_META(int id, Decimal value);
        QueryModel UpdateFPR_QTD_RESTANTE(int id, Decimal value);
        QueryModel UpdateFPR_VELO_ATU_PC_SEGUNDO(int id, Decimal value);
        QueryModel UpdateFPR_PERFORMANCE_PROJETADA(int id, Decimal value);
        QueryModel UpdateFPR_TEMPO_RESTANTE_TOTAL(int id, Decimal value);
        QueryModel UpdateFPR_FIM_PREVISTO_ATUAL(int id, DateTime value);
        QueryModel UpdateFPR_PRODUZINDO(int id, int value);
        QueryModel UpdateFPR_ORDEM_NA_FILA(int id, Decimal value);
        QueryModel UpdateFPR_ID_INTEGRACAO(int id, string value);
        QueryModel UpdateFPR_TRUNCADO(int id, string value);
        QueryModel UpdateFPR_DATA_TRUNC_INI(int id, DateTime value);
        QueryModel UpdateFPR_DATA_TRUNC_FIM(int id, DateTime value);
        QueryModel UpdateFPR_ID(int id, int value);
        QueryModel UpdateFPR_COR_FILA(int id, string value);
        QueryModel UpdateMAQ_ID_MANUAL(int id, string value);
        QueryModel UpdateMAQ_ID_RESTRINGIDA(int id, string value);
        QueryModel UpdateFPR_PREVISAO_MATERIA_PRIMA(int id, DateTime value);
        QueryModel UpdateFPR_DATA_NECESSIDADE_INICIO_PRODUCAO(int id, DateTime value);
        QueryModel UpdateFPR_DATA_NECESSIDADE_FIM_PRODUCAO(int id, DateTime value);
        QueryModel UpdateFPR_GRUPO_PRODUTIVO(int id, Decimal value);
        QueryModel UpdateFPR_INICIO_GRUPO_PRODUTIVO(int id, DateTime value);
        QueryModel UpdateFPR_FIM_GRUPO_PRODUTIVO(int id, DateTime value);
        QueryModel UpdateFPR_COR_BICO1(int id, string value);
        QueryModel UpdateFPR_COR_BICO2(int id, string value);
        QueryModel UpdateFPR_COR_BICO3(int id, string value);
        QueryModel UpdateFPR_COR_BICO4(int id, string value);
        QueryModel UpdateFPR_COR_BICO5(int id, string value);
        QueryModel UpdateFPR_META_SETUP(int id, Decimal value);
        QueryModel UpdateFPR_ORD_ID_REPROGRAMADO(int id, string value);
        QueryModel UpdateFPR_PRIORIDADE(int id, int value);
        QueryModel UpdateFPR_SEQ_INCLUSAO_FILA(int id, int value);
        QueryModel UpdateFPR_HIERARQUIA_SEQ_TRANSFORMACAO(int id, int value);
        QueryModel UpdateFPR_ID_ORIGEM(int id, int value);
        QueryModel UpdateFPR_DATA_ENTREGA(int id, DateTime value);
        QueryModel UpdateEQU_ID(int id, string value);
        QueryModel UpdateFPR_GRUPO_PRODUTIVO_MANUAL(int id, Decimal value);
        QueryModel UpdateFPR_EMISSAO(int id, DateTime value);
        QueryModel UpdateFPR_MOTIVO_PULA_FILA(int id, string value);
        QueryModel UpdateOCO_ID(int id, string value);
        QueryModel UpdateFPR_PESO_UNITARIO(int id, string value);
        QueryModel UpdateFPR_M2_UNITARIO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteFilaProducaoPrevistaQuery(IFilaProducaoPrevistaEntity FilaProducaoPrevista);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration