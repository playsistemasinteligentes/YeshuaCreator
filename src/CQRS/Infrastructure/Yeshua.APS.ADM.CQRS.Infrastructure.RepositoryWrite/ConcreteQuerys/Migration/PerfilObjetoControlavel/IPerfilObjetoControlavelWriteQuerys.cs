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

    public interface IPerfilObjetoControlavelQueryWrite 
     {
        public QueryModel InserirPerfilObjetoControlavelQuery(IPerfilObjetoControlavelEntity PerfilObjetoControlavel);
        public QueryModel UpdatePerfilObjetoControlavelQuery(IPerfilObjetoControlavelEntity PerfilObjetoControlavel);
        QueryModel UpdatePER_ID(int id, int value);
        QueryModel UpdateOBJ_ID(int id, string value);
        QueryModel UpdatePEO_ACAO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeletePerfilObjetoControlavelQuery(IPerfilObjetoControlavelEntity PerfilObjetoControlavel);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration