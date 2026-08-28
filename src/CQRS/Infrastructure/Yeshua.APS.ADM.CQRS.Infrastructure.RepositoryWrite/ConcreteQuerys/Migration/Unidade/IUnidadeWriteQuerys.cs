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

    public interface IUnidadeQueryWrite 
     {
        public QueryModel InserirUnidadeQuery(IUnidadeEntity Unidade);
        public QueryModel UpdateUnidadeQuery(IUnidadeEntity Unidade);
        QueryModel UpdateDEESCRICAO(int uni_id, string value);
        QueryModel UpdateUN(int uni_id, string value);
        QueryModel UpdateTenantID(int uni_id, int value);
        QueryModel UpdateDeleted(int uni_id, bool value);
        QueryModel UpdateChanged(int uni_id, DateTime value);
        QueryModel UpdateUserId(int uni_id, int value);
        public QueryModel DeleteUnidadeQuery(IUnidadeEntity Unidade);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration