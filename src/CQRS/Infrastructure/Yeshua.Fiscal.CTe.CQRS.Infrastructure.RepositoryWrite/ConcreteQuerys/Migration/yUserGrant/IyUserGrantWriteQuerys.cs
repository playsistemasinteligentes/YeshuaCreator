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

    public interface IyUserGrantQueryWrite 
     {
        public QueryModel InseriryUserGrantQuery(IyUserGrantEntity yUserGrant);
        public QueryModel UpdateyUserGrantQuery(IyUserGrantEntity yUserGrant);
        QueryModel UpdatePerfilId(int id, int value);
        QueryModel UpdateGrantId(int id, string value);
        QueryModel UpdateCanGrant(int id, bool value);
        QueryModel UpdateCanCreate(int id, bool value);
        QueryModel UpdateCanRead(int id, bool value);
        QueryModel UpdateCanUpdate(int id, bool value);
        QueryModel UpdateCanDelete(int id, bool value);
        QueryModel UpdateValidUntil(int id, DateTime value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteyUserGrantQuery(IyUserGrantEntity yUserGrant);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration