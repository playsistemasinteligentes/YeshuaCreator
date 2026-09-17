// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

namespace IRepository.Write
{
    public partial interface IyInboxWriteRepository
    {
        void MarkApplied(int id, int? sagaId, int? sagaStepId, int appliedStatus);
        void MarkDeadLetter(int id, string error, int deadLetterStatus);
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
