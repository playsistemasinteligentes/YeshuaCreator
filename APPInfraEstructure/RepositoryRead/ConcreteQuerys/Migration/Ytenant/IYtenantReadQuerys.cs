using Shered.DB;
namespace IQuery.Read
{
    public interface IYtenantQueryRead 
    {
        public QueryModel YtenantQuery(Command.Read.YtenantReadCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByCnpjCpfQuery(int value);
        public QueryModel ExistsByNomeQuery(string value);
        public QueryModel ExistsByUserIdQuery(int value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByCnpjCpfQuery(int value);
        public QueryModel FirstByNomeQuery(string value);
        public QueryModel FirstByUserIdQuery(int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration