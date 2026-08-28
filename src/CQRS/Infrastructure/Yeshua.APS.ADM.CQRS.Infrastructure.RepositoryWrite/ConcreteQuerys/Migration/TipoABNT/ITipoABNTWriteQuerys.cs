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

    public interface ITipoABNTQueryWrite 
     {
        public QueryModel InserirTipoABNTQuery(ITipoABNTEntity TipoABNT);
        public QueryModel UpdateTipoABNTQuery(ITipoABNTEntity TipoABNT);
        QueryModel UpdateABN_ID(int id, string value);
        QueryModel UpdateABN_DESCRICAO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteTipoABNTQuery(ITipoABNTEntity TipoABNT);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration