using IRepository.Read;

namespace Read.Repository;

public partial class ChamadoSuporteReadRepository
{
    public SupportTicketData? BuscarDoUsuario(string id)
        => _unitOfWork.Query<SupportTicketData>(@"
            SELECT t.Id,t.Aplicativo,t.Modulo,t.Tela,t.TituloTela,t.Rota,t.Caminho,t.Versao,
                t.FusoHorario,t.MomentoClienteUtc,t.Assunto,t.Descricao,t.Status,
                u.Id AS UploadId,u.Status AS UploadStatus,s.Id AS SagaId,s.Status AS SagaStatus,
                step.Status AS StepStatus,step.Payload AS TranscriptPayload
            FROM ChamadoSuporte t
            OUTER APPLY (SELECT TOP(1) f.Id,f.Status,f.OperationalEntityId FROM yFileUpload f
                WHERE f.EntityType='ChamadoSuporte' AND f.EntityId=t.Id
                  AND f.TenantID=@TenantID AND f.UserId=@UserId AND f.Deleted=0 ORDER BY f.Id DESC) u
            LEFT JOIN ySaga s ON s.EntityType='ChamadoSuporte' AND s.EntityId=t.Id
                AND REPLACE(s.CorrelationId,'-','')=REPLACE(u.OperationalEntityId,'-','')
                AND s.TenantID=@TenantID AND s.ProcessingScope=@Scope AND s.Deleted=0
            LEFT JOIN ySagaStep step ON step.SagaId=s.Id AND step.Deleted=0
            WHERE t.Id=@Id AND t.TenantID=@TenantID AND t.UserId=@UserId AND t.Deleted=0;",
            new { Id = id, TenantID = _executionContext.TenantID, UserId = _executionContext.UserId, Scope = _executionContext.ProcessingScope }).FirstOrDefault();
}
