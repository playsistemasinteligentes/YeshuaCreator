using Shered.DB;
namespace IQuery.Read
{
    public interface IyUserModuleQueryRead 
    {
        public QueryModel yUserModuleQuery(Command.Read.yUserModuleReadCommand Command );
        public QueryModel yUserModuleModuleIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel yUserModuleUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel yUserModuleTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByModuleIdQuery(string value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel ExistsByValidUntilQuery(DateTime value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByModuleIdQuery(string value );
        public QueryModel FirstByUserIdQuery(int value );
        public QueryModel FirstByValidUntilQuery(DateTime value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration