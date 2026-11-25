using Presenca.Editorial;
namespace Read.Repository;
public partial class IdentidadePublicadoraReadRepository
{
 private const string PublicadorDaSaida=@" AND o.TenantID=@tenant
  AND (EXISTS(SELECT 1 FROM PublicacaoDestino p WHERE p.Id=o.EntityId AND p.TenantID=o.TenantID AND p.IdentidadeId=@identity AND p.Deleted=0)
   OR EXISTS(SELECT 1 FROM Pauta p WHERE p.Id=o.EntityId AND p.TenantID=o.TenantID AND p.IdentidadeId=@identity AND p.Deleted=0))";
 private const string PublicadorDaEntrada=@"i.TenantID=@tenant AND i.ProcessingScope=@ProcessingScope AND i.Deleted=0
  AND i.Type IN('MovimentoFabricaDisponivel.v1','SolicitacaoPublicacaoEducacional.v1')
  AND JSON_VALUE(CASE WHEN ISJSON(i.Payload)=1 THEN i.Payload ELSE '{}' END,'$.IdentidadeId')=@identity";
 private const string OutboxHealth=QueueProjectionBody+PublicadorDaSaida+@")
  SELECT 'Distribuicao' Fila,COALESCE(SUM(Eligible),0) Prontas,
   COALESCE(SUM(CASE WHEN Status=0 AND Eligible=0 THEN 1 ELSE 0 END),0) Agendadas,
   COALESCE(SUM(CASE WHEN Status=2 THEN 1 ELSE 0 END),0) EmProcessamento,
   COALESCE(SUM(CASE WHEN Status=1 THEN 1 ELSE 0 END),0) Concluidas,
   COALESCE(SUM(CASE WHEN Status=3 AND COALESCE(DeliveryState,'')<>'ResultadoIncerto' THEN 1 ELSE 0 END),0) FalhasFinais,
   COALESCE(SUM(CASE WHEN Status=3 AND DeliveryState='ResultadoIncerto' THEN 1 ELSE 0 END),0) ResultadosIncertos,
   COALESCE(MAX(CASE WHEN Eligible=1 THEN DATEDIFF_BIG(second,EligibleSince,SYSUTCDATETIME()) ELSE 0 END),0) MaisAntigaSegundos FROM q";
 private const string InboxHealth=@"SELECT 'Entrada' Fila,
  COALESCE(SUM(CASE WHEN i.Status=0 THEN 1 ELSE 0 END),0) Prontas,
  COALESCE(SUM(CASE WHEN i.Status=1 THEN 1 ELSE 0 END),0) Concluidas,
  COALESCE(SUM(CASE WHEN i.Status=3 THEN 1 ELSE 0 END),0) FalhasFinais,
  COALESCE(MAX(CASE WHEN i.Status=0 THEN DATEDIFF_BIG(second,i.CreatedAt,SYSUTCDATETIME()) ELSE 0 END),0) MaisAntigaSegundos
  FROM yInbox i WHERE "+PublicadorDaEntrada;
 private static readonly string SagaHealth=@"WITH q AS(SELECT s.Status,s.LockedBy,s.LockedAt,s.NextExecutionAt,s.CreatedAt,
  CASE WHEN "+ySagaReadRepository.PredicadoProntoParaSaude+@" THEN 1 ELSE 0 END Eligible
  FROM ySaga s WHERE s.TenantID=@tenant AND s.ProcessingScope=@ProcessingScope AND s.Deleted=0 AND s.Type='"+nameof(Dominio.Saga.ReceberOrigemEditorialSaga)+@"'
   AND EXISTS(SELECT 1 FROM yInbox i WHERE i.SagaId=s.Id AND "+PublicadorDaEntrada+@"))
  SELECT 'Editorial' Fila,COALESCE(SUM(Eligible),0) Prontas,
   COALESCE(SUM(CASE WHEN Status=1 AND Eligible=0 AND LockedBy IS NULL THEN 1 ELSE 0 END),0) Agendadas,
   COALESCE(SUM(CASE WHEN Status=1 AND LockedBy IS NOT NULL AND LockedAt>=@StaleLockLimit THEN 1 ELSE 0 END),0) EmProcessamento,
   COALESCE(SUM(CASE WHEN Status=2 THEN 1 ELSE 0 END),0) Concluidas,
   COALESCE(SUM(CASE WHEN Status=3 THEN 1 ELSE 0 END),0) FalhasFinais,
   COALESCE(MAX(CASE WHEN Eligible=1 THEN DATEDIFF_BIG(second,CASE WHEN NextExecutionAt<=@Now THEN NextExecutionAt ELSE CreatedAt END,@Now) ELSE 0 END),0) MaisAntigaSegundos FROM q";
 // Invoked only after ConsultarOperacao authorizes Operar. No payload/audit content is returned.
 private List<SaudeFilaEditorial> SaudeOperacao(int tenant,string identity)
 {
  var now=DateTime.UtcNow;
  var args=new {tenant,identity,scope=_executionContext.ProcessingScope,ProcessingScope=_executionContext.ProcessingScope,Now=now,StaleLockLimit=now.AddMinutes(-1)};
  return [_unitOfWork.Query<SaudeFilaEditorial>(InboxHealth,args).Single(),
   _unitOfWork.Query<SaudeFilaEditorial>(SagaHealth,args).Single(),
   _unitOfWork.Query<SaudeFilaEditorial>(OutboxHealth,args).Single()];
 }
}
