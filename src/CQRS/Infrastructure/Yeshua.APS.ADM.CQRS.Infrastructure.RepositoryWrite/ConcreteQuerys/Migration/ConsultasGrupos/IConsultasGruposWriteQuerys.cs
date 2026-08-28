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

    public interface IConsultasGruposQueryWrite 
     {
        public QueryModel InserirConsultasGruposQuery(IConsultasGruposEntity ConsultasGrupos);
        public QueryModel UpdateConsultasGruposQuery(IConsultasGruposEntity ConsultasGrupos);
        QueryModel UpdateCON_ID(int id, int value);
        QueryModel UpdateGRU_ID(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteConsultasGruposQuery(IConsultasGruposEntity ConsultasGrupos);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration