using Shered.DB;
namespace IQuery.Read
{
    public interface IYconfigArctetureQueryRead 
    {
        public QueryModel YconfigArctetureQuery(Command.Read.YconfigArctetureReadCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByAuditTrackerActivedQuery(int value);
        public QueryModel ExistsByAuditCRUDActivedQuery(int value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByAuditTrackerActivedQuery(int value);
        public QueryModel FirstByAuditCRUDActivedQuery(int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration