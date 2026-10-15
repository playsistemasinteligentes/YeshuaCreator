// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

namespace Input.Repository.AlbumFoto;

public partial class AlbumFotoWriteRepository
{
    public bool TrySetRotation(int albumPhotoId, int tenantId, int userId, int rotation, DateTime now)
    {
        const string sql = """
            UPDATE af SET Rotacao = @Rotation, Changed = @Now
              FROM AlbumFoto af
              JOIN Album a ON a.Id = af.AlbumId AND a.TenantID = af.TenantID AND a.UserId = af.UserId
             WHERE af.Id = @AlbumPhotoId AND af.TenantID = @TenantId AND af.UserId = @UserId
               AND af.Deleted = 0 AND a.Deleted = 0 AND @Rotation IN (0, 90, 180, 270)
               AND NOT EXISTS (
                   SELECT 1 FROM PublicacaoAlbum p WITH (UPDLOCK, HOLDLOCK)
                    WHERE p.AlbumId = af.AlbumId AND p.TenantID = @TenantId
                      AND p.Deleted = 0 AND (p.Status IN (10, 20, 30, 40, 45, 50)
                          OR (p.Status = 90 AND EXISTS (
                              SELECT 1 FROM ySaga s WITH (UPDLOCK, HOLDLOCK)
                               WHERE s.EntityId = CONVERT(varchar(20), p.Id)
                                 AND s.EntityType = 'PublicacaoAlbumEntity'
                                 AND s.Type = 'PublicarAlbumYouTubeSaga'
                                 AND s.TenantID = @TenantId AND s.Deleted = 0 AND s.Status = 1))));
            SELECT @@ROWCOUNT;
            """;
        return _UnitOfWork.ExecuteScalar<int>(sql, new
        {
            AlbumPhotoId = albumPhotoId, TenantId = tenantId, UserId = userId, Rotation = rotation, Now = now
        }) == 1;
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
