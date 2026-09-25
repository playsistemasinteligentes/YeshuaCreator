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

    public interface IyTokenQueryWrite 
     {
        public QueryModel InseriryTokenQuery(IyTokenEntity yToken);
        public QueryModel UpdateyTokenQuery(IyTokenEntity yToken);
        QueryModel UpdateTokenHash(int id, string value);
        QueryModel UpdateDescription(int id, string value);
        QueryModel UpdateConnectorKey(int id, string value);
        QueryModel UpdateActive(int id, bool value);
        QueryModel UpdateValidUntil(int id, DateTime value);
        QueryModel UpdateCreatedAt(int id, DateTime value);
        QueryModel UpdateLastUsedAt(int id, DateTime value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateUserId(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        public QueryModel DeleteyTokenQuery(IyTokenEntity yToken);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration