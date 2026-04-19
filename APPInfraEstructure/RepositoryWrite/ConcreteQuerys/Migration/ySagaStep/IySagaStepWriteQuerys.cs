using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IySagaStepQueryWrite 
     {
        public QueryModel InserirySagaStepQuery(IySagaStepEntity ySagaStep);
        public QueryModel UpdateySagaStepQuery(IySagaStepEntity ySagaStep);
        public QueryModel UpdateSagaId(IySagaStepEntity entity);
        public QueryModel UpdateKey(IySagaStepEntity entity);
        public QueryModel UpdateOrder(IySagaStepEntity entity);
        public QueryModel UpdateCorrelationId(IySagaStepEntity entity);
        public QueryModel UpdateStatus(IySagaStepEntity entity);
        public QueryModel UpdateExecutionCount(IySagaStepEntity entity);
        public QueryModel UpdateLastExecutionAt(IySagaStepEntity entity);
        public QueryModel UpdateCompletedAt(IySagaStepEntity entity);
        public QueryModel UpdateErrorMessage(IySagaStepEntity entity);
        public QueryModel UpdatePayload(IySagaStepEntity entity);
        public QueryModel UpdateRetryCount(IySagaStepEntity entity);
        public QueryModel UpdateTenantID(IySagaStepEntity entity);
        public QueryModel UpdateDeleted(IySagaStepEntity entity);
        public QueryModel UpdateChanged(IySagaStepEntity entity);
        public QueryModel UpdateUserId(IySagaStepEntity entity);
        public QueryModel DeleteySagaStepQuery(IySagaStepEntity ySagaStep);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration