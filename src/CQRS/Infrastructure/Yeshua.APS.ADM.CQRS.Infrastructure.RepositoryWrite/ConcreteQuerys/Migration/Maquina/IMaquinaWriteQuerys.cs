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
        QueryModel UpdateDescricao(string id, string value);
        QueryModel UpdateStatus(string id, string value);
        QueryModel UpdateTenantID(string id, int value);
        QueryModel UpdateDeleted(string id, bool value);
        QueryModel UpdateChanged(string id, DateTime value);
        QueryModel UpdateUserId(string id, int value);
        public QueryModel DeleteMaquinaQuery(IMaquinaEntity Maquina);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration