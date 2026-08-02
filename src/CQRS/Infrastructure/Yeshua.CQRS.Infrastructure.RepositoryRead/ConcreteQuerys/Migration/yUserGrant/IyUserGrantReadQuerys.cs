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
        public QueryModel FirstByIdQuery(int value );
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