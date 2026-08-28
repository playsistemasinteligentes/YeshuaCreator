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

    public interface IUniuserQueryWrite 
     {
        public QueryModel InserirUniuserQuery(IUniuserEntity Uniuser);
        public QueryModel UpdateUniuserQuery(IUniuserEntity Uniuser);
        QueryModel UpdateUNI_ID(int usergru_id, int value);
        QueryModel UpdateUSE_ID(int usergru_id, int value);
        QueryModel UpdateTenantID(int usergru_id, int value);
        QueryModel UpdateDeleted(int usergru_id, bool value);
        QueryModel UpdateChanged(int usergru_id, DateTime value);
        QueryModel UpdateUserId(int usergru_id, int value);
        public QueryModel DeleteUniuserQuery(IUniuserEntity Uniuser);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration