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

    public interface ILoockQueryWrite 
     {
        public QueryModel InserirLoockQuery(ILoockEntity Loock);
        public QueryModel UpdateLoockQuery(ILoockEntity Loock);
        QueryModel UpdateLOO_ID(int id, string value);
        QueryModel UpdateLOO_DESCRICAO(int id, string value);
        QueryModel UpdateLOO_CONTEUDO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteLoockQuery(ILoockEntity Loock);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration