using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyInboxQueryWrite 
     {
        public QueryModel InseriryInboxQuery(IyInboxEntity yInbox);
        public QueryModel UpdateyInboxQuery(IyInboxEntity yInbox);
        public QueryModel UpdateMessageId(IyInboxEntity entity);
        public QueryModel UpdateType(IyInboxEntity entity);
        public QueryModel UpdateEntityType(IyInboxEntity entity);
        public QueryModel UpdateEntityId(IyInboxEntity entity);
        public QueryModel UpdatePayload(IyInboxEntity entity);
        public QueryModel UpdateStatus(IyInboxEntity entity);
        public QueryModel UpdateCreatedAt(IyInboxEntity entity);
        public QueryModel UpdateSentAt(IyInboxEntity entity);
        public QueryModel UpdateRetryCount(IyInboxEntity entity);
        public QueryModel UpdateLastError(IyInboxEntity entity);
        public QueryModel UpdateSagaId(IyInboxEntity entity);
        public QueryModel UpdateSagaStepId(IyInboxEntity entity);
        public QueryModel UpdateTenantID(IyInboxEntity entity);
        public QueryModel UpdateDeleted(IyInboxEntity entity);
        public QueryModel UpdateChanged(IyInboxEntity entity);
        public QueryModel UpdateUserId(IyInboxEntity entity);
        public QueryModel DeleteyInboxQuery(IyInboxEntity yInbox);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration