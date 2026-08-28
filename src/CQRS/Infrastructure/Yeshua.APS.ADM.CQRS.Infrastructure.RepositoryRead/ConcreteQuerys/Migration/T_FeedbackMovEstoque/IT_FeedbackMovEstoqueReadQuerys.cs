// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

using Shered.DB;
namespace IQuery.Read
{
    public interface IT_FeedbackMovEstoqueQueryRead 
    {
        public QueryModel T_FeedbackMovEstoqueQuery(Command.Read.T_FeedbackMovEstoqueReadCommand Command );
        public QueryModel T_FeedbackMovEstoqueFeedbackIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_FeedbackMovEstoqueMovimentoEstoqueIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_FeedbackMovEstoqueTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_FeedbackMovEstoqueUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByFeedbackIdQuery(int value );
        public QueryModel ExistsByMovimentoEstoqueIdQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByFeedbackIdQuery(int value );
        public QueryModel FirstByMovimentoEstoqueIdQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration