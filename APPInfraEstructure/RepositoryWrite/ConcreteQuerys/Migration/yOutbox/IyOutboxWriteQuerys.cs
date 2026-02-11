using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyOutboxQueryWrite 
     {
        public QueryModel InseriryOutboxQuery(IyOutboxEntity yOutbox);
        public QueryModel UpdateyOutboxQuery(IyOutboxEntity yOutbox);
        public QueryModel UpdateMessageId(IyOutboxEntity entity);
        public QueryModel UpdateJobId(IyOutboxEntity entity);
        public QueryModel UpdateCorrelationId(IyOutboxEntity entity);
        public QueryModel UpdateType(IyOutboxEntity entity);
        public QueryModel UpdatePayload(IyOutboxEntity entity);
        public QueryModel UpdateStatus(IyOutboxEntity entity);
        public QueryModel UpdateCreatedAt(IyOutboxEntity entity);
        public QueryModel UpdateSentAt(IyOutboxEntity entity);
        public QueryModel UpdateRetryCount(IyOutboxEntity entity);
        public QueryModel UpdateLastError(IyOutboxEntity entity);
        public QueryModel UpdateTenantID(IyOutboxEntity entity);
        public QueryModel UpdateDeleted(IyOutboxEntity entity);
        public QueryModel UpdateChanged(IyOutboxEntity entity);
        public QueryModel UpdateUserId(IyOutboxEntity entity);
        public QueryModel DeleteyOutboxQuery(IyOutboxEntity yOutbox);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration