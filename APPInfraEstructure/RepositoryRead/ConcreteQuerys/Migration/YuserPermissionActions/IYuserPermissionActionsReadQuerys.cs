using Shered.DB;
namespace IQuery.Read
{
    public interface IYuserPermissionActionsQueryRead 
    {
        public QueryModel YuserPermissionActionsQuery(Command.Read.YuserPermissionActionsReadCommand Command);
        public QueryModel YuserPermissionActionsPerfilIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel YuserPermissionActionspermissionActionsIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel ExistsByPerfilIdQuery(int value);
        public QueryModel ExistsBypermissionActionsIdQuery(string value);
        public QueryModel ExistsByGrantQuery(bool value);
        public QueryModel ExistsByCreateQuery(bool value);
        public QueryModel ExistsByReadQuery(bool value);
        public QueryModel ExistsByUpdateQuery(bool value);
        public QueryModel ExistsByDeleteQuery(bool value);
        public QueryModel ExistsByValidUntilQuery(DateTime value);
        public QueryModel FirstByPerfilIdQuery(int value);
        public QueryModel FirstBypermissionActionsIdQuery(string value);
        public QueryModel FirstByGrantQuery(bool value);
        public QueryModel FirstByCreateQuery(bool value);
        public QueryModel FirstByReadQuery(bool value);
        public QueryModel FirstByUpdateQuery(bool value);
        public QueryModel FirstByDeleteQuery(bool value);
        public QueryModel FirstByValidUntilQuery(DateTime value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration