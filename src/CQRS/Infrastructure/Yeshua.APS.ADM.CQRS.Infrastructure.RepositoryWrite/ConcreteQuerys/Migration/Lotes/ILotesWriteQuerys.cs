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

    public interface ILotesQueryWrite 
     {
        public QueryModel InserirLotesQuery(ILotesEntity Lotes);
        public QueryModel UpdateLotesQuery(ILotesEntity Lotes);
        QueryModel UpdateMOV_LOTE(int id, string value);
        QueryModel UpdateMOV_SUB_LOTE(int id, string value);
        QueryModel UpdateLOT_LARGURA(int id, Decimal value);
        QueryModel UpdateLOT_COMPRIMENTO(int id, Decimal value);
        QueryModel UpdateLOT_DIAMETRO(int id, Decimal value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteLotesQuery(ILotesEntity Lotes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration