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

    public interface ICanhotosQueryWrite 
     {
        public QueryModel InserirCanhotosQuery(ICanhotosEntity Canhotos);
        public QueryModel UpdateCanhotosQuery(ICanhotosEntity Canhotos);
        QueryModel UpdateCAR_ID(int id, string value);
        QueryModel UpdateORD_ID(int id, string value);
        QueryModel UpdateNOT_ID(int id, string value);
        QueryModel UpdateCAN_DATA_ENTREGA(int id, DateTime value);
        QueryModel UpdateCAN_IMG(int id, string value);
        QueryModel UpdateCAN_LAT_ENTREGA(int id, Decimal value);
        QueryModel UpdateCAN_LONG_ENTREGA(int id, Decimal value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCanhotosQuery(ICanhotosEntity Canhotos);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration