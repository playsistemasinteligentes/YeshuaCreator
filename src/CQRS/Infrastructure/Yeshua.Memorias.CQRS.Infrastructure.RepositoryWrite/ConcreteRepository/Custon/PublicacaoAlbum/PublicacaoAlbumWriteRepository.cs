// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

namespace Input.Repository.PublicacaoAlbum;

public partial class PublicacaoAlbumWriteRepository
{
    // A transacao do command mantem a trava ate gravar a publicacao e a saga.
    public bool CanRequestPublication(int albumId, int tenantId, int userId, DateTime requestedAfterUtc)
    {
        const string sql = """
            DECLARE @LockedAlbumId int;
            SELECT @LockedAlbumId = Id FROM Album WITH (UPDLOCK, HOLDLOCK)
             WHERE Id = @AlbumId AND TenantID = @TenantId AND UserId = @UserId AND Deleted = 0;
            SELECT CASE WHEN @LockedAlbumId IS NOT NULL AND NOT EXISTS (
                SELECT 1 FROM PublicacaoAlbum
                 WHERE AlbumId = @LockedAlbumId AND TenantID = @TenantId AND UserId = @UserId
                   AND SolicitadaEmUtc > @RequestedAfterUtc
            ) THEN 1 ELSE 0 END;
            """;
        return _UnitOfWork.ExecuteScalar<int>(sql, new
        {
            AlbumId = albumId, TenantId = tenantId, UserId = userId, RequestedAfterUtc = requestedAfterUtc
        }) == 1;
    }

    public bool ScheduleYouTubeResume(int publicationId, int tenantId, int userId, string processingScope, DateTime now,
        string connectionId, string channelId, int credentialUserId)
    {
        const string sql = """
            DECLARE @SagaId int;
            SELECT @SagaId = s.Id
              FROM ySaga s WITH (UPDLOCK, HOLDLOCK)
              JOIN PublicacaoAlbum p WITH (UPDLOCK, HOLDLOCK)
                ON s.EntityId = CONVERT(varchar(20), p.Id)
               AND s.EntityType = 'PublicacaoAlbumEntity'
             WHERE p.Id = @PublicationId AND p.TenantID = @TenantId AND p.UserId = @UserId
               AND p.Deleted = 0 AND p.Status = 45
               AND (NULLIF(p.ConexaoYouTubeId, '') IS NULL
                    OR (p.ConexaoYouTubeId = @ConnectionId AND p.CanalYouTubeId = @ChannelId
                        AND p.YouTubeCredentialUserId = @CredentialUserId))
               AND NULLIF(p.VideoStorageKey, '') IS NOT NULL
               AND NULLIF(p.YouTubeVideoId, '') IS NULL
               AND s.Type = 'PublicarAlbumYouTubeSaga' AND s.Deleted = 0
               AND s.TenantID = @TenantId AND s.UserId = @UserId
               AND s.ProcessingScope = @ProcessingScope AND s.Status IN (1, 2, 3)
               AND (s.LockedBy IS NULL OR s.LockedAt < DATEADD(minute, -1, @Now))
               AND EXISTS (SELECT 1 FROM ySagaStep st WHERE st.SagaId = s.Id
                            AND st.StepKey = 'RenderizarVideoAlbum' AND st.Status = 5)
               AND EXISTS (SELECT 1 FROM ySagaStep st WHERE st.SagaId = s.Id
                            AND st.StepKey = 'EnviarVideoParaYouTube' AND st.Status IN (3, 5, 6));
            IF @SagaId IS NULL BEGIN SELECT 0; RETURN; END;

            UPDATE ySagaStep SET Status = CASE WHEN StepKey = 'EnviarVideoParaYouTube' THEN 1 ELSE 0 END,
                   CompletedAt = NULL, RetryCount = 0, ErrorMessage = NULL, Changed = @Now
             WHERE SagaId = @SagaId AND StepKey IN ('EnviarVideoParaYouTube', 'FinalizarPublicacaoAlbum');
            UPDATE ySaga SET Status = 1, KeyCurrentStep = 'EnviarVideoParaYouTube',
                   CompletedAt = NULL, NextExecutionAt = @Now, LockedBy = NULL, LockedAt = NULL, Changed = @Now
             WHERE Id = @SagaId;
            UPDATE PublicacaoAlbum SET Status = 40, Mensagem = 'Envio ao YouTube agendado.', Changed = @Now,
                   ConexaoYouTubeId = @ConnectionId, CanalYouTubeId = @ChannelId,
                   YouTubeCredentialUserId = @CredentialUserId
             WHERE Id = @PublicationId AND TenantID = @TenantId AND UserId = @UserId;
            SELECT 1;
            """;
        return _UnitOfWork.ExecuteScalar<int>(sql, new
        {
            PublicationId = publicationId, TenantId = tenantId, UserId = userId,
            ProcessingScope = processingScope, Now = now,
            ConnectionId = connectionId, ChannelId = channelId, CredentialUserId = credentialUserId
        }) == 1;
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
