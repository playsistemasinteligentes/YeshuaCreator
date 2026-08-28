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
    public interface IPerfilQueryRead 
    {
        public QueryModel PerfilQuery(Command.Read.PerfilReadCommand Command );
        public QueryModel PerfilTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PerfilUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByPER_IDQuery(int value );
        public QueryModel ExistsByPER_NOMEQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByPER_IDQuery(int value );
        public QueryModel FirstByPER_NOMEQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration