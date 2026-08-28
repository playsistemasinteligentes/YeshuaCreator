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

    public interface ILogsDatabaseQueryWrite 
     {
        public QueryModel InserirLogsDatabaseQuery(ILogsDatabaseEntity LogsDatabase);
        public QueryModel UpdateLogsDatabaseQuery(ILogsDatabaseEntity LogsDatabase);
        QueryModel UpdateLOGS_TABLE(int logs_id, string value);
        QueryModel UpdateLOGS_KEY(int logs_id, string value);
        QueryModel UpdateLOGS_KEY1(int logs_id, string value);
        QueryModel UpdateLOGS_KEY2(int logs_id, string value);
        QueryModel UpdateLOGS_KEY3(int logs_id, string value);
        QueryModel UpdateLOGS_KEY4(int logs_id, string value);
        QueryModel UpdateLOGS_COLUMN(int logs_id, string value);
        QueryModel UpdateLOGS_BEFORE(int logs_id, string value);
        QueryModel UpdateLOGS_AFTER(int logs_id, string value);
        QueryModel UpdateLOGS_ACTION(int logs_id, string value);
        QueryModel UpdateLOGS_DATE(int logs_id, DateTime value);
        QueryModel UpdateUSE_ID(int logs_id, int value);
        QueryModel UpdateLOGS_ORIGEM(int logs_id, string value);
        QueryModel UpdateTenantID(int logs_id, int value);
        QueryModel UpdateDeleted(int logs_id, bool value);
        QueryModel UpdateChanged(int logs_id, DateTime value);
        QueryModel UpdateUserId(int logs_id, int value);
        public QueryModel DeleteLogsDatabaseQuery(ILogsDatabaseEntity LogsDatabase);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration