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

public partial interface IPublicacaoAlbumWriteRepository
{
    bool CanRequestPublication(int albumId, int tenantId, int userId, DateTime requestedAfterUtc);

    bool ScheduleYouTubeResume(int publicationId, int tenantId, int userId, string processingScope, DateTime now,
        string connectionId, string channelId, int credentialUserId);
}

//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
