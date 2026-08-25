// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyInboxQueryWrite 
     {
        public QueryModel InseriryInboxQuery(IyInboxEntity yInbox);
        public QueryModel UpdateyInboxQuery(IyInboxEntity yInbox);
        QueryModel UpdateMessageId(int id, string value);
        QueryModel UpdateType(int id, string value);
        QueryModel UpdateEntityType(int id, string value);
        QueryModel UpdateEntityId(int id, string value);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdatePayload(int id, string value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateCreatedAt(int id, DateTime value);
        QueryModel UpdateRetryCount(int id, int value);
        QueryModel UpdateLastError(int id, string value);
        QueryModel UpdateProcessingAt(int id, DateTime value);
        QueryModel UpdateNextAttemptAt(int id, DateTime value);
        QueryModel UpdateSagaId(int id, int value);
        QueryModel UpdateSagaStepId(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteyInboxQuery(IyInboxEntity yInbox);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration