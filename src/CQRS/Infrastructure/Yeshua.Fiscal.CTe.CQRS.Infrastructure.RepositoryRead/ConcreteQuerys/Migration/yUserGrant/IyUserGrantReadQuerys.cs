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
    public interface IyUserGrantQueryRead 
    {
        public QueryModel yUserGrantQuery(Command.Read.yUserGrantReadCommand Command );
        public QueryModel yUserGrantPerfilIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel yUserGrantGrantIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel yUserGrantTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel yUserGrantUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByPerfilIdQuery(int value );
        public QueryModel ExistsByGrantIdQuery(string value );
        public QueryModel ExistsByCanGrantQuery(bool value );
        public QueryModel ExistsByCanCreateQuery(bool value );
        public QueryModel ExistsByCanReadQuery(bool value );
        public QueryModel ExistsByCanUpdateQuery(bool value );
        public QueryModel ExistsByCanDeleteQuery(bool value );
        public QueryModel ExistsByValidUntilQuery(DateTime value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByPerfilIdQuery(int value );
        public QueryModel FirstByGrantIdQuery(string value );
        public QueryModel FirstByCanGrantQuery(bool value );
        public QueryModel FirstByCanCreateQuery(bool value );
        public QueryModel FirstByCanReadQuery(bool value );
        public QueryModel FirstByCanUpdateQuery(bool value );
        public QueryModel FirstByCanDeleteQuery(bool value );
        public QueryModel FirstByValidUntilQuery(DateTime value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration