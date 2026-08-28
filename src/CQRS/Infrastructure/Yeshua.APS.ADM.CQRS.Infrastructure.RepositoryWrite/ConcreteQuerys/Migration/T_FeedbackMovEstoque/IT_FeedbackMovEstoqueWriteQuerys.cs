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

    public interface IT_FeedbackMovEstoqueQueryWrite 
     {
        public QueryModel InserirT_FeedbackMovEstoqueQuery(IT_FeedbackMovEstoqueEntity T_FeedbackMovEstoque);
        public QueryModel UpdateT_FeedbackMovEstoqueQuery(IT_FeedbackMovEstoqueEntity T_FeedbackMovEstoque);
        QueryModel UpdateFeedbackId(int id, int value);
        QueryModel UpdateMovimentoEstoqueId(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteT_FeedbackMovEstoqueQuery(IT_FeedbackMovEstoqueEntity T_FeedbackMovEstoque);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration