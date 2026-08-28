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

    public interface IVisoesQueryWrite 
     {
        public QueryModel InserirVisoesQuery(IVisoesEntity Visoes);
        public QueryModel UpdateVisoesQuery(IVisoesEntity Visoes);
        QueryModel UpdateVIS_PLANID(int vis_id, int value);
        QueryModel UpdateVIS_FORMULA(int vis_id, string value);
        QueryModel UpdateCAB_ID(int vis_id, int value);
        QueryModel UpdateTenantID(int vis_id, int value);
        QueryModel UpdateDeleted(int vis_id, bool value);
        QueryModel UpdateChanged(int vis_id, DateTime value);
        QueryModel UpdateUserId(int vis_id, int value);
        public QueryModel DeleteVisoesQuery(IVisoesEntity Visoes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration