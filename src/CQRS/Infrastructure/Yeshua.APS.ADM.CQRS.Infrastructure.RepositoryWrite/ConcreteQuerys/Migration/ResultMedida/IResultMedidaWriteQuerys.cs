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

    public interface IResultMedidaQueryWrite 
     {
        public QueryModel InserirResultMedidaQuery(IResultMedidaEntity ResultMedida);
        public QueryModel UpdateResultMedidaQuery(IResultMedidaEntity ResultMedida);
        QueryModel UpdateRSM_ID(int id, int value);
        QueryModel UpdateRL_ID(int id, int value);
        QueryModel UpdateMDT_ID(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteResultMedidaQuery(IResultMedidaEntity ResultMedida);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration