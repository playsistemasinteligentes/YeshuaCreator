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

    public interface IEstradasQueryWrite 
     {
        public QueryModel InserirEstradasQuery(IEstradasEntity Estradas);
        public QueryModel UpdateEstradasQuery(IEstradasEntity Estradas);
        QueryModel UpdateEST_ID(int id, int value);
        QueryModel UpdateEST_DESCRICAO(int id, string value);
        QueryModel UpdateEST_ID_LIGACAO_PONTO_A(int id, int value);
        QueryModel UpdateEST_ID_LIGACAO_PONTO_B(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteEstradasQuery(IEstradasEntity Estradas);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration