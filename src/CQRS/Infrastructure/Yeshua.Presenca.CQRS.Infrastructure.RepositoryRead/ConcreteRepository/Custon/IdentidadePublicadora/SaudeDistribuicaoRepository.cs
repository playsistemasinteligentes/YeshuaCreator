using RepositoryInterfaces.Patterns.Worker;
namespace Read.Repository;
public partial class IdentidadePublicadoraReadRepository
{
 private const string QueueProjectionBody=@"WITH q AS(SELECT d.Estado DeliveryState,o.EntityId,o.Type,o.Id,o.TenantID,o.Status,o.RetryCount,o.CreatedAt,o.NextAttemptAt,o.ProcessingAt,o.OperationalEntityId,o.RootOperationId,o.ExecutionId,o.LastError,CASE WHEN d.NaturezaFalha IN('Technical','Business') THEN d.NaturezaFalha ELSE 'Unknown' END FailureCategory,
  CASE WHEN o.Status=0 AND (o.NextAttemptAt IS NULL OR o.NextAttemptAt<=SYSUTCDATETIME()) THEN 1 ELSE 0 END Eligible,
  COALESCE(o.NextAttemptAt,o.CreatedAt) EligibleSince,
  CASE WHEN o.Status=3 THEN 5 WHEN o.Status=2 AND o.ProcessingAt<DATEADD(second,-120,SYSUTCDATETIME()) THEN 2
   WHEN o.Status<>1 AND o.RetryCount>=2 THEN 4 WHEN o.Status=0 AND COALESCE(o.NextAttemptAt,o.CreatedAt)<DATEADD(second,-900,SYSUTCDATETIME()) THEN 1 ELSE 0 END Disease
  FROM yOutbox o LEFT JOIN PublicacaoDestino d ON d.Id=o.EntityId AND d.TenantID=o.TenantID WHERE o.ProcessingScope=@scope AND o.Deleted=0 AND o.Type IN('Presenca.Publicacao.v1','PublicacaoEducacionalAtualizada.v1')";
 private const string QueueProjection=QueueProjectionBody+") ";
 public WorkerQueueHealthSnapshot SaudeDistribuicao()
 {
  var r=_unitOfWork.Query<HealthRow>(QueueProjection+@"SELECT COALESCE(SUM(Eligible),0) Eligible,COALESCE(MAX(CASE WHEN Eligible=1 THEN DATEDIFF_BIG(second,EligibleSince,SYSUTCDATETIME()) ELSE 0 END),0) Age,
   COALESCE(SUM(CASE WHEN Disease<>0 THEN 1 ELSE 0 END),0) Sick,COALESCE(SUM(CASE WHEN Disease=1 THEN 1 ELSE 0 END),0) Wait,
   COALESCE(SUM(CASE WHEN Disease=2 THEN 1 ELSE 0 END),0) Stale,COALESCE(SUM(CASE WHEN Disease=4 THEN 1 ELSE 0 END),0) Repeated,COALESCE(SUM(CASE WHEN Disease=5 THEN 1 ELSE 0 END),0) Terminal FROM q",new {scope=_executionContext.ProcessingScope}).Single();
  return new(r.Eligible,r.Age,r.Sick,r.Wait,r.Stale,0,r.Repeated,r.Terminal);
 }
 public IReadOnlyList<WorkerQueueSickItem> ItensDoentesDistribuicao(int limit)
 {
  var rows=_unitOfWork.Query<SickRow>(QueueProjection+@"SELECT TOP(@limit) Id,TenantID,Disease,RetryCount,OperationalEntityId,RootOperationId,ExecutionId,FailureCategory,
   CASE WHEN Eligible=1 THEN DATEDIFF_BIG(second,EligibleSince,SYSUTCDATETIME()) ELSE 0 END EligibleAge,
   COALESCE(DATEDIFF_BIG(second,ProcessingAt,SYSUTCDATETIME()),0) ProcessingAge,
   CONVERT(varchar(64),HASHBYTES('SHA2_256',COALESCE(LastError,'')),2) ErrorSignature FROM q WHERE Disease<>0 ORDER BY Disease DESC,EligibleSince,Id",new{scope=_executionContext.ProcessingScope,limit=Math.Clamp(limit,1,25)}).ToList();
  return rows.Select(r=>new WorkerQueueSickItem(r.TenantID,r.Id.ToString(System.Globalization.CultureInfo.InvariantCulture),"yOutbox",(WorkerQueueItemDisease)r.Disease,"error",r.EligibleAge,r.ProcessingAge,r.RetryCount,r.RetryCount,"Failed",r.OperationalEntityId,r.RootOperationId,r.ExecutionId,r.ErrorSignature,r.FailureCategory,r.FailureCategory=="Unknown"?null:r.FailureCategory,null,null,null,null)).ToList();
 }
 public sealed class HealthRow {public long Eligible {get;set;}public long Age {get;set;}public long Sick {get;set;}public long Wait {get;set;}public long Stale {get;set;}public long Repeated {get;set;}public long Terminal {get;set;}}
 public sealed class SickRow {public int Id {get;set;}public int TenantID {get;set;}public int Disease {get;set;}public int RetryCount {get;set;}public long EligibleAge {get;set;}public long ProcessingAge {get;set;}public string OperationalEntityId {get;set;}="";public string RootOperationId {get;set;}="";public string ExecutionId {get;set;}="";public string ErrorSignature {get;set;}="";public string FailureCategory {get;set;}="Unknown";}
}
