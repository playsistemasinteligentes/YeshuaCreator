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
    public interface IProdutoQueryRead 
    {
        public QueryModel ProdutoQuery(Command.Read.ProdutoReadCommand Command );
        public QueryModel ProdutoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ProdutoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByPRO_IDQuery(string value );
        public QueryModel ExistsByPRO_DESCRICAOQuery(string value );
        public QueryModel ExistsByPRO_STATUSQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByPRO_IDQuery(string value );
        public QueryModel FirstByPRO_DESCRICAOQuery(string value );
        public QueryModel FirstByPRO_STATUSQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration