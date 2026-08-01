using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IySagaStepQueryWrite 
     {
        public QueryModel InserirySagaStepQuery(IySagaStepEntity ySagaStep);
        public QueryModel UpdateySagaStepQuery(IySagaStepEntity ySagaStep);
        QueryModel UpdateSagaId(int id, int value);
        QueryModel UpdateStepKey(int id, string value);
        QueryModel UpdateIndexOrder(int id, int value);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateExecutionCount(int id, int value);
        QueryModel UpdateLastExecutionAt(int id, DateTime value);
        QueryModel UpdateCompletedAt(int id, DateTime value);
        QueryModel UpdateErrorMessage(int id, string value);
        QueryModel UpdatePayload(int id, string value);
        QueryModel UpdateRetryCount(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteySagaStepQuery(IySagaStepEntity ySagaStep);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration