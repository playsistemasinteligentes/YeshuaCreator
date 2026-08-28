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

    public interface IUsuariosCargaQueryWrite 
     {
        public QueryModel InserirUsuariosCargaQuery(IUsuariosCargaEntity UsuariosCarga);
        public QueryModel UpdateUsuariosCargaQuery(IUsuariosCargaEntity UsuariosCarga);
        QueryModel UpdateUSE_ID(int id, int value);
        QueryModel UpdateCAR_ID(int id, string value);
        QueryModel UpdateRGO_ID(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteUsuariosCargaQuery(IUsuariosCargaEntity UsuariosCarga);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration