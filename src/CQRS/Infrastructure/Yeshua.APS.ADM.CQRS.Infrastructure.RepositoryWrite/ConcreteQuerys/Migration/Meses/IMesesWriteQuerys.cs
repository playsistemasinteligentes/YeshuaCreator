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

    public interface IMesesQueryWrite 
     {
        public QueryModel InserirMesesQuery(IMesesEntity Meses);
        public QueryModel UpdateMesesQuery(IMesesEntity Meses);
        QueryModel Updatefator(string mes, int value);
        QueryModel UpdateTenantID(string mes, int value);
        QueryModel UpdateDeleted(string mes, bool value);
        QueryModel UpdateChanged(string mes, DateTime value);
        QueryModel UpdateUserId(string mes, int value);
        public QueryModel DeleteMesesQuery(IMesesEntity Meses);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration