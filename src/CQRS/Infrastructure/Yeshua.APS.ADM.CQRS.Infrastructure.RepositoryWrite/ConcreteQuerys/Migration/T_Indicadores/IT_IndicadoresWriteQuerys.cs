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

    public interface IT_IndicadoresQueryWrite 
     {
        public QueryModel InserirT_IndicadoresQuery(IT_IndicadoresEntity T_Indicadores);
        public QueryModel UpdateT_IndicadoresQuery(IT_IndicadoresEntity T_Indicadores);
        QueryModel UpdateIND_DESCRICAO(int ind_id, string value);
        QueryModel UpdateNEG_ID(int ind_id, int value);
        QueryModel UpdateDESC_CALCULO(int ind_id, string value);
        QueryModel UpdateIND_TIPOCOMPARADOR(int ind_id, int value);
        QueryModel UpdateIND_GRAFICO(int ind_id, int value);
        QueryModel UpdateIND_CONEXAO(int ind_id, string value);
        QueryModel UpdateIND_DTCRIACAO(int ind_id, DateTime value);
        QueryModel UpdateRESPOSAVELIND(int ind_id, string value);
        QueryModel UpdateRESPOSAVELCARGA(int ind_id, string value);
        QueryModel UpdatePROCEXTRACAO(int ind_id, string value);
        QueryModel UpdatePER_ID(int ind_id, string value);
        QueryModel UpdateDIM_ID(int ind_id, string value);
        QueryModel UpdateDOM_EMPRESA(int ind_id, string value);
        QueryModel UpdateDOM_FILIAL(int ind_id, string value);
        QueryModel UpdateTenantID(int ind_id, int value);
        QueryModel UpdateDeleted(int ind_id, bool value);
        QueryModel UpdateChanged(int ind_id, DateTime value);
        QueryModel UpdateUserId(int ind_id, int value);
        public QueryModel DeleteT_IndicadoresQuery(IT_IndicadoresEntity T_Indicadores);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration