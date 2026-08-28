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

    public interface ISemaforoQueryWrite 
     {
        public QueryModel InserirSemaforoQuery(ISemaforoEntity Semaforo);
        public QueryModel UpdateSemaforoQuery(ISemaforoEntity Semaforo);
        QueryModel UpdateSEM_ID(int id, string value);
        QueryModel UpdateSEM_STATUS(int id, string value);
        QueryModel UpdateSEM_ORIGEM(int id, string value);
        QueryModel UpdateSEM_EMISSAO(int id, DateTime value);
        QueryModel UpdateSEM_ID_CONEXAO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteSemaforoQuery(ISemaforoEntity Semaforo);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration