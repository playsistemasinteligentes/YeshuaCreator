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

    public interface ITemposLogisticosQueryWrite 
     {
        public QueryModel InserirTemposLogisticosQuery(ITemposLogisticosEntity TemposLogisticos);
        public QueryModel UpdateTemposLogisticosQuery(ITemposLogisticosEntity TemposLogisticos);
        QueryModel UpdateTMP_TIPO_TEMPO(int id, string value);
        QueryModel UpdateTMP_TIPO_CARGA(int id, string value);
        QueryModel UpdateTMP_TEMPO_MEDIO_UNITARIO(int id, Decimal value);
        QueryModel UpdateCLI_ID(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteTemposLogisticosQuery(ITemposLogisticosEntity TemposLogisticos);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration