using Repositorio.Outputs;
namespace Read.Repository;
public partial class ySagaStepReadRepository
{
 // This saga has no external wait. Inbox-to-saga bridge is explicit in ProcessarPresenca.
 public int SetPendingApply()=>0;
 public int SetPendingApplyByInboxId(int inboxId)=>0;
 public ySagaStepDTO? GetFirstBySagaStepKeyAndStatuses(int sagaId,string stepKey,IEnumerable<int> statuses)=>
  _unitOfWork.Query<ySagaStepDTO>(@"SELECT TOP(1) st.* FROM ySagaStep st JOIN ySaga s ON s.Id=st.SagaId WHERE s.Id=@sagaId AND st.StepKey=@stepKey AND st.Status IN @statuses AND s.TenantID=@tenant AND s.ProcessingScope=@scope ORDER BY st.IndexOrder",new{sagaId,stepKey,statuses,tenant=_executionContext.TenantID,scope=_executionContext.ProcessingScope}).SingleOrDefault();
}
