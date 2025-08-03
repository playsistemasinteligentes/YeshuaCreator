using Shered.DB;
namespace IQuery.Read
{
    public interface IYtenantPermissionMudulesQueryRead 
    {
        public QueryModel YtenantPermissionMudulesQuery(Command.Read.YtenantPermissionMudulesReadCommand Command);
        public QueryModel YtenantPermissionMudulespermissionModulesIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel YtenantPermissionMudulesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsBypermissionModulesIdQuery(string value);
        public QueryModel ExistsByTenantIDQuery(int value);
        public QueryModel ExistsByValidUntilQuery(DateTime value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstBypermissionModulesIdQuery(string value);
        public QueryModel FirstByTenantIDQuery(int value);
        public QueryModel FirstByValidUntilQuery(DateTime value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration