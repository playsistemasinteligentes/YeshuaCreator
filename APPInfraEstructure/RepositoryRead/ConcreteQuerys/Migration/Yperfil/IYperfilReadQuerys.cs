using Shered.DB;
namespace IQuery.Read
{
    public interface IYperfilQueryRead 
    {
        public QueryModel YperfilQuery(Command.Read.YperfilReadCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByDescriptionQuery(string value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByDescriptionQuery(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration