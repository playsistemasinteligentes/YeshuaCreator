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

    public interface IT_USER_GRUPOQueryWrite 
     {
        public QueryModel InserirT_USER_GRUPOQuery(IT_USER_GRUPOEntity T_USER_GRUPO);
        public QueryModel UpdateT_USER_GRUPOQuery(IT_USER_GRUPOEntity T_USER_GRUPO);
        QueryModel UpdateGRU_ID(int id, int value);
        QueryModel UpdateID_USUARIO(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteT_USER_GRUPOQuery(IT_USER_GRUPOEntity T_USER_GRUPO);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration