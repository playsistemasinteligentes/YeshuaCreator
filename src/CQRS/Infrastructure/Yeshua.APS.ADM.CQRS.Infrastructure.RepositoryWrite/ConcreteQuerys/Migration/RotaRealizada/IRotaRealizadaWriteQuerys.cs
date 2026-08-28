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

    public interface IRotaRealizadaQueryWrite 
     {
        public QueryModel InserirRotaRealizadaQuery(IRotaRealizadaEntity RotaRealizada);
        public QueryModel UpdateRotaRealizadaQuery(IRotaRealizadaEntity RotaRealizada);
        QueryModel UpdateCAR_ID(int rot_id, string value);
        QueryModel UpdateROT_DATA_HORA(int rot_id, DateTime value);
        QueryModel UpdateROT_LAT(int rot_id, Decimal value);
        QueryModel UpdateROT_LONG(int rot_id, Decimal value);
        QueryModel UpdateTenantID(int rot_id, int value);
        QueryModel UpdateDeleted(int rot_id, bool value);
        QueryModel UpdateChanged(int rot_id, DateTime value);
        QueryModel UpdateUserId(int rot_id, int value);
        public QueryModel DeleteRotaRealizadaQuery(IRotaRealizadaEntity RotaRealizada);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration