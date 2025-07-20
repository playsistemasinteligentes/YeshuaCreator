using Shered.DB;
namespace IQuery.Read
{
    public interface IYStandardFieldsQueryRead 
    {
        public QueryModel YStandardFieldsQuery(Command.Read.YStandardFieldsReadCommand Command);
        public QueryModel ExistsByDeletedQuery(bool value);
        public QueryModel FirstByDeletedQuery(bool value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration