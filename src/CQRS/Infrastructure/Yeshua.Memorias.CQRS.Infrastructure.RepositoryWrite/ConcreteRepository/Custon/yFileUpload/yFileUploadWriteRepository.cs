// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

namespace Input.Repository.yFileUpload;

public partial class yFileUploadWriteRepository
{
    public bool TryCompletePhotoUpload(
        int uploadId, int albumId, int tenantId, int userId,
        string storageKey, long fileSize, DateTime completedAt, DateTime minimumCreatedAt)
    {
        // O lock do album serializa a ordem das fotos ate o commit do receiver.
        const string sql = """
            IF NOT EXISTS (
                SELECT 1 FROM Album WITH (UPDLOCK, HOLDLOCK)
                WHERE Id = @AlbumId AND TenantID = @TenantId
                  AND UserId = @UserId AND Deleted = 0)
            BEGIN
                SELECT 0;
                RETURN;
            END;

            UPDATE yFileUpload
            SET FilePath = @StorageKey, FileSize = @FileSize,
                Status = 1, CompletedAt = @CompletedAt, Changed = @CompletedAt
            WHERE Id = @UploadId AND TenantID = @TenantId AND UserId = @UserId
              AND Deleted = 0 AND Status = 0 AND Type = 'memorias.photo'
              AND EntityType = 'Album' AND EntityId = @AlbumEntityId
              AND CreatedAt >= @MinimumCreatedAt;

            SELECT @@ROWCOUNT;
            """;

        return _UnitOfWork.ExecuteScalar<int>(sql, new
        {
            UploadId = uploadId,
            AlbumId = albumId,
            AlbumEntityId = albumId.ToString(System.Globalization.CultureInfo.InvariantCulture),
            TenantId = tenantId,
            UserId = userId,
            StorageKey = storageKey,
            FileSize = fileSize,
            CompletedAt = completedAt,
            MinimumCreatedAt = minimumCreatedAt
        }) == 1;
    }
}
