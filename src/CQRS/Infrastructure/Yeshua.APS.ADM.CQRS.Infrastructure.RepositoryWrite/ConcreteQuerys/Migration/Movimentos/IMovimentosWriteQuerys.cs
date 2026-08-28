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

    public interface IMovimentosQueryWrite 
     {
        public QueryModel InserirMovimentosQuery(IMovimentosEntity Movimentos);
        public QueryModel UpdateMovimentosQuery(IMovimentosEntity Movimentos);
        QueryModel UpdateMOV_DATA(int mov_id, string value);
        QueryModel UpdateMOV_VALOR(int mov_id, Decimal value);
        QueryModel UpdateMOV_PLAID(int mov_id, int value);
        QueryModel UpdateMOV_UNID(int mov_id, int value);
        QueryModel UpdateTr_Unidade_UNI_ID(int mov_id, int value);
        QueryModel UpdateTenantID(int mov_id, int value);
        QueryModel UpdateDeleted(int mov_id, bool value);
        QueryModel UpdateChanged(int mov_id, DateTime value);
        QueryModel UpdateUserId(int mov_id, int value);
        public QueryModel DeleteMovimentosQuery(IMovimentosEntity Movimentos);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration