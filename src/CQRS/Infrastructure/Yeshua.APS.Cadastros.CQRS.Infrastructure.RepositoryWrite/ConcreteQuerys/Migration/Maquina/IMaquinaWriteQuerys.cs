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

    public interface IMaquinaQueryWrite 
     {
        public QueryModel InserirMaquinaQuery(IMaquinaEntity Maquina);
        public QueryModel UpdateMaquinaQuery(IMaquinaEntity Maquina);
        QueryModel UpdateMAQ_DESCRICAO(string maq_id, string value);
        QueryModel UpdateMAQ_STATUS(string maq_id, string value);
        QueryModel UpdateTenantID(string maq_id, int value);
        QueryModel UpdateDeleted(string maq_id, bool value);
        QueryModel UpdateChanged(string maq_id, DateTime value);
        QueryModel UpdateUserId(string maq_id, int value);
        public QueryModel DeleteMaquinaQuery(IMaquinaEntity Maquina);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration