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

    public interface IItensCalendarioQueryWrite 
     {
        public QueryModel InserirItensCalendarioQuery(IItensCalendarioEntity ItensCalendario);
        public QueryModel UpdateItensCalendarioQuery(IItensCalendarioEntity ItensCalendario);
        QueryModel UpdateICA_DATA_DE(int ica_id, DateTime value);
        QueryModel UpdateICA_DATA_ATE(int ica_id, DateTime value);
        QueryModel UpdateICA_OBSERVACAO(int ica_id, string value);
        QueryModel UpdateICA_TIPO(int ica_id, int value);
        QueryModel UpdateURM_ID(int ica_id, string value);
        QueryModel UpdateURN_ID(int ica_id, string value);
        QueryModel UpdateCAL_ID(int ica_id, int value);
        QueryModel UpdateMAQ_ID(int ica_id, string value);
        QueryModel UpdatePRO_ID(int ica_id, string value);
        QueryModel UpdateICA_LIMPESA_MAQUINA(int ica_id, int value);
        QueryModel UpdateTenantID(int ica_id, int value);
        QueryModel UpdateDeleted(int ica_id, bool value);
        QueryModel UpdateChanged(int ica_id, DateTime value);
        QueryModel UpdateUserId(int ica_id, int value);
        public QueryModel DeleteItensCalendarioQuery(IItensCalendarioEntity ItensCalendario);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration