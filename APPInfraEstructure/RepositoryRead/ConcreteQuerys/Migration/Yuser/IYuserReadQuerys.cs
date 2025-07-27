using Shered.DB;
namespace IQuery.Read
{
    public interface IYuserQueryRead 
    {
        public QueryModel YuserQuery(Command.Read.YuserReadCommand Command);
        public QueryModel YuserTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByNomeQuery(string value);
        public QueryModel ExistsByEmailQuery(string value);
        public QueryModel ExistsBySenhaQuery(string value);
        public QueryModel ExistsByTenantIDQuery(int value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByNomeQuery(string value);
        public QueryModel FirstByEmailQuery(string value);
        public QueryModel FirstBySenhaQuery(string value);
        public QueryModel FirstByTenantIDQuery(int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration