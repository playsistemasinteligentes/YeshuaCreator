using Shered.DB;
namespace IQuery.Read
{
    public interface IYpermtionsQueryRead 
    {
        public QueryModel YpermtionsQuery(Command.Read.YpermtionsReadCommand Command);
        public QueryModel ExistsByIdQuery(string value);
        public QueryModel ExistsByDescriptionQuery(string value);
        public QueryModel FirstByIdQuery(string value);
        public QueryModel FirstByDescriptionQuery(string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration