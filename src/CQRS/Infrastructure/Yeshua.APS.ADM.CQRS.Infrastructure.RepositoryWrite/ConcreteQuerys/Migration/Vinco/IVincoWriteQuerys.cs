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

    public interface IVincoQueryWrite 
     {
        public QueryModel InserirVincoQuery(IVincoEntity Vinco);
        public QueryModel UpdateVincoQuery(IVincoEntity Vinco);
        QueryModel UpdateVIN_DESCRICAO(int vin_id, string value);
        QueryModel UpdateVIN_ID_DESLOCAMENTO(int vin_id, string value);
        QueryModel UpdateTenantID(int vin_id, int value);
        QueryModel UpdateDeleted(int vin_id, bool value);
        QueryModel UpdateChanged(int vin_id, DateTime value);
        QueryModel UpdateUserId(int vin_id, int value);
        public QueryModel DeleteVincoQuery(IVincoEntity Vinco);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration