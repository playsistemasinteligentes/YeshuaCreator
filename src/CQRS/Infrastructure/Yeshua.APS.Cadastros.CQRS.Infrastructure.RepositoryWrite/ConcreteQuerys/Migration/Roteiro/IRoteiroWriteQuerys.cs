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

    public interface IRoteiroQueryWrite 
     {
        public QueryModel InserirRoteiroQuery(IRoteiroEntity Roteiro);
        public QueryModel UpdateRoteiroQuery(IRoteiroEntity Roteiro);
        QueryModel UpdateGMA_ID(string maq_id, string pro_id, int rot_seq_tranformacao, string value);
        QueryModel UpdateROT_PECAS_POR_PULSO(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        QueryModel UpdateROT_PRIORIDADE_INFORMADA(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        QueryModel UpdateROT_ACAO(string maq_id, string pro_id, int rot_seq_tranformacao, string value);
        QueryModel UpdateROT_PERFORMANCE(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        QueryModel UpdateROT_TEMPO_SETUP(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        QueryModel UpdateROT_TEMPO_SETUP_AJUSTE(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        QueryModel UpdateROT_VA_PARA_SEQ_TRANSFORMACAO(string maq_id, string pro_id, int rot_seq_tranformacao, int value);
        QueryModel UpdateROT_STATUS(string maq_id, string pro_id, int rot_seq_tranformacao, string value);
        QueryModel UpdateROT_HIERARQUIA_SEQ_TRANSFORMACAO(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        QueryModel UpdateROT_AVALIA_CUSTO(string maq_id, string pro_id, int rot_seq_tranformacao, int value);
        QueryModel UpdateROT_OPERACOES(string maq_id, string pro_id, int rot_seq_tranformacao, string value);
        QueryModel UpdateROT_EXCECAO_OPERACOES(string maq_id, string pro_id, int rot_seq_tranformacao, string value);
        QueryModel UpdateROT_PERCENTUAL_INICIO_PASSO_ANTERIOR(string maq_id, string pro_id, int rot_seq_tranformacao, Decimal value);
        QueryModel UpdateROT_LINHA_DIRETA(string maq_id, string pro_id, int rot_seq_tranformacao, string value);
        QueryModel UpdateTEM_ID(string maq_id, string pro_id, int rot_seq_tranformacao, int value);
        QueryModel UpdateTenantID(string maq_id, string pro_id, int rot_seq_tranformacao, int value);
        QueryModel UpdateDeleted(string maq_id, string pro_id, int rot_seq_tranformacao, bool value);
        QueryModel UpdateChanged(string maq_id, string pro_id, int rot_seq_tranformacao, DateTime value);
        QueryModel UpdateUserId(string maq_id, string pro_id, int rot_seq_tranformacao, int value);
        public QueryModel DeleteRoteiroQuery(IRoteiroEntity Roteiro);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration