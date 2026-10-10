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

    public interface IyUserQueryWrite 
     {
        public QueryModel InseriryUserQuery(IyUserEntity yUser);
        public QueryModel UpdateyUserQuery(IyUserEntity yUser);
        QueryModel UpdateNome(int id, string value);
        QueryModel UpdateEmail(int id, string value);
        QueryModel UpdateSenha(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        public QueryModel DeleteyUserQuery(IyUserEntity yUser);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration