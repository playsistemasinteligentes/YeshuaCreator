using Shered.DB;
namespace IQuery.Read
{
    public interface IYtenantQueryRead 
    {
        public QueryModel YtenantQuery(Command.Read.YtenantReadCommand Command);
        public QueryModel YtenantUserIDAdminQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByCnpjCpfQuery(int value);
        public QueryModel ExistsByNomeQuery(string value);
        public QueryModel ExistsByUserIDAdminQuery(int value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByCnpjCpfQuery(int value);
        public QueryModel FirstByNomeQuery(string value);
        public QueryModel FirstByUserIDAdminQuery(int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration