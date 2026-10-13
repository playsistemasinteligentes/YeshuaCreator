// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

namespace IRepository.Write;

public partial interface IyFileUploadWriteRepository
{
    bool TryCompletePhotoUpload(
        int uploadId, int albumId, int tenantId, int userId,
        string storageKey, long fileSize, DateTime completedAt, DateTime minimumCreatedAt);
}
