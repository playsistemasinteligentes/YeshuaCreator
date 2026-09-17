// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

namespace Input.Repository.yInbox
{
    public partial class yInboxWriteRepository
    {
        public void MarkApplied(int id, int? sagaId, int? sagaStepId, int appliedStatus)
        {
            const string sql = @"
                UPDATE [yInbox]
                   SET [Status] = @AppliedStatus,
                       [SagaId] = COALESCE(@SagaId, [SagaId]),
                       [SagaStepId] = COALESCE(@SagaStepId, [SagaStepId])
                 WHERE [Id] = @Id;";

            _UnitOfWork.Execute(sql, new
            {
                Id = id,
                SagaId = sagaId,
                SagaStepId = sagaStepId,
                AppliedStatus = appliedStatus
            });
        }

        public void MarkDeadLetter(int id, string error, int deadLetterStatus)
        {
            const string sql = @"
                UPDATE [yInbox]
                   SET [Status] = @DeadLetterStatus,
                       [LastError] = @Error
                 WHERE [Id] = @Id;";

            _UnitOfWork.Execute(sql, new
            {
                Id = id,
                Error = error ?? string.Empty,
                DeadLetterStatus = deadLetterStatus
            });
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
