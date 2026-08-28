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

    public interface ISubOcorrenciaQueryWrite 
     {
        public QueryModel InserirSubOcorrenciaQuery(ISubOcorrenciaEntity SubOcorrencia);
        public QueryModel UpdateSubOcorrenciaQuery(ISubOcorrenciaEntity SubOcorrencia);
        QueryModel UpdateSUB_ID(int id, string value);
        QueryModel UpdateSUB_DESCRICAO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteSubOcorrenciaQuery(ISubOcorrenciaEntity SubOcorrencia);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration