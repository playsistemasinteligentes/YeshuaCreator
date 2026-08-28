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

    public interface ITempoSetupOnduladeiraQueryWrite 
     {
        public QueryModel InserirTempoSetupOnduladeiraQuery(ITempoSetupOnduladeiraEntity TempoSetupOnduladeira);
        public QueryModel UpdateTempoSetupOnduladeiraQuery(ITempoSetupOnduladeiraEntity TempoSetupOnduladeira);
        QueryModel UpdateOND_ID_DE(int tem_id, string value);
        QueryModel UpdateOND_ID_PARA(int tem_id, string value);
        QueryModel UpdateTEM_RESINA_DE(int tem_id, string value);
        QueryModel UpdateTEM_RESINA_PARA(int tem_id, string value);
        QueryModel UpdateTEM_TEMPO(int tem_id, int value);
        QueryModel UpdateTenantID(int tem_id, int value);
        QueryModel UpdateDeleted(int tem_id, bool value);
        QueryModel UpdateChanged(int tem_id, DateTime value);
        QueryModel UpdateUserId(int tem_id, int value);
        public QueryModel DeleteTempoSetupOnduladeiraQuery(ITempoSetupOnduladeiraEntity TempoSetupOnduladeira);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration