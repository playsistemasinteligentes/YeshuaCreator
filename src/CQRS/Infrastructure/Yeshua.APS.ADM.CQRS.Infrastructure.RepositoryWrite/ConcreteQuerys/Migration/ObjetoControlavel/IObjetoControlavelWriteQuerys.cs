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

    public interface IObjetoControlavelQueryWrite 
     {
        public QueryModel InserirObjetoControlavelQuery(IObjetoControlavelEntity ObjetoControlavel);
        public QueryModel UpdateObjetoControlavelQuery(IObjetoControlavelEntity ObjetoControlavel);
        QueryModel UpdateOBJ_ID(int id, string value);
        QueryModel UpdateOBJ_DESCRICAO(int id, string value);
        QueryModel UpdateOBJ_TIPO(int id, string value);
        QueryModel UpdateOBJ_GRUPO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteObjetoControlavelQuery(IObjetoControlavelEntity ObjetoControlavel);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration