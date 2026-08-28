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

    public interface IPerfilQueryWrite 
     {
        public QueryModel InserirPerfilQuery(IPerfilEntity Perfil);
        public QueryModel UpdatePerfilQuery(IPerfilEntity Perfil);
        QueryModel UpdatePER_NOME(int per_id, string value);
        QueryModel UpdateTenantID(int per_id, int value);
        QueryModel UpdateDeleted(int per_id, bool value);
        QueryModel UpdateChanged(int per_id, DateTime value);
        QueryModel UpdateUserId(int per_id, int value);
        public QueryModel DeletePerfilQuery(IPerfilEntity Perfil);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration