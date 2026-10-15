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

public partial interface IAlbumFotoWriteRepository
{
    bool TrySetRotation(int albumPhotoId, int tenantId, int userId, int rotation, DateTime now);
}

//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
