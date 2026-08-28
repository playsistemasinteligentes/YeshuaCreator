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
    public interface IEnderecosQueryRead 
    {
        public QueryModel EnderecosQuery(Command.Read.EnderecosReadCommand Command );
        public QueryModel EnderecosTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EnderecosUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByEND_IDQuery(string value );
        public QueryModel ExistsByEND_GRUPOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByEND_IDQuery(string value );
        public QueryModel FirstByEND_GRUPOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration