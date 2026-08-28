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

    public interface IUsuarioQueryWrite 
     {
        public QueryModel InserirUsuarioQuery(IUsuarioEntity Usuario);
        public QueryModel UpdateUsuarioQuery(IUsuarioEntity Usuario);
        QueryModel UpdateUSE_NOME(int use_id, string value);
        QueryModel UpdateUSE_EMAIL(int use_id, string value);
        QueryModel UpdateUSE_SENHA(int use_id, string value);
        QueryModel UpdateTURM_ID(int use_id, string value);
        QueryModel UpdateUSE_ATIVO(int use_id, int value);
        QueryModel UpdateUSE_CODERP(int use_id, string value);
        QueryModel UpdateTenantID(int use_id, int value);
        QueryModel UpdateDeleted(int use_id, bool value);
        QueryModel UpdateChanged(int use_id, DateTime value);
        QueryModel UpdateUserId(int use_id, int value);
        public QueryModel DeleteUsuarioQuery(IUsuarioEntity Usuario);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration