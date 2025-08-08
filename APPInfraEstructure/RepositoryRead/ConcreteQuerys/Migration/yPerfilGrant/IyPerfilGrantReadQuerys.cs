using Shered.DB;
namespace IQuery.Read
{
    public interface IyPerfilGrantQueryRead 
    {
        public QueryModel yPerfilGrantQuery(Command.Read.yPerfilGrantReadCommand Command );
        public QueryModel yPerfilGrantPerfilIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel yPerfilGrantGrantIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel yPerfilGrantTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel yPerfilGrantUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByPerfilIdQuery(int value );
        public QueryModel ExistsByGrantIdQuery(string value );
        public QueryModel ExistsByGrantQuery(bool value );
        public QueryModel ExistsByCreateQuery(bool value );
        public QueryModel ExistsByReadQuery(bool value );
        public QueryModel ExistsByUpdateQuery(bool value );
        public QueryModel ExistsByDeleteQuery(bool value );
        public QueryModel ExistsByValidUntilQuery(DateTime value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByPerfilIdQuery(int value );
        public QueryModel FirstByGrantIdQuery(string value );
        public QueryModel FirstByGrantQuery(bool value );
        public QueryModel FirstByCreateQuery(bool value );
        public QueryModel FirstByReadQuery(bool value );
        public QueryModel FirstByUpdateQuery(bool value );
        public QueryModel FirstByDeleteQuery(bool value );
        public QueryModel FirstByValidUntilQuery(DateTime value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration