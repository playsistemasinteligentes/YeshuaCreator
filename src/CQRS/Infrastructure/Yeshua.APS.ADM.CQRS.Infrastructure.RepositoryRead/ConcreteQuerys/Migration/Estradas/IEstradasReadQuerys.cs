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
    public interface IEstradasQueryRead 
    {
        public QueryModel EstradasQuery(Command.Read.EstradasReadCommand Command );
        public QueryModel EstradasTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EstradasUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByEST_IDQuery(int value );
        public QueryModel ExistsByEST_DESCRICAOQuery(string value );
        public QueryModel ExistsByEST_ID_LIGACAO_PONTO_AQuery(int value );
        public QueryModel ExistsByEST_ID_LIGACAO_PONTO_BQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByEST_IDQuery(int value );
        public QueryModel FirstByEST_DESCRICAOQuery(string value );
        public QueryModel FirstByEST_ID_LIGACAO_PONTO_AQuery(int value );
        public QueryModel FirstByEST_ID_LIGACAO_PONTO_BQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration