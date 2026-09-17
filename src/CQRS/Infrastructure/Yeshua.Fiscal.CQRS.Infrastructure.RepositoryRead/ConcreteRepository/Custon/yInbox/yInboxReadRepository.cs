// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

using Repositorio.Outputs;
using System;
using System.Collections.Generic;

namespace Read.Repository
{
    public partial class yInboxReadRepository
    {
        public IEnumerable<yInboxDTO> ClaimPendingByType(
            string type,
            int limit,
            int pendingStatus,
            int processingStatus,
            DateTime processingAt)
        {
            const string sql = @"
                WITH NextInbox AS
                (
                    SELECT TOP (@Limit) *
                      FROM [yInbox] WITH (UPDLOCK, READPAST, ROWLOCK)
                     WHERE [Status] = @PendingStatus
                       AND [Type] = @Type
                     ORDER BY [CreatedAt]
                )
                UPDATE NextInbox
                   SET [Status] = @ProcessingStatus,
                       [ProcessingAt] = @ProcessingAt,
                       [RetryCount] = ISNULL([RetryCount], 0) + 1
                OUTPUT inserted.*;";

            return _unitOfWork.Query<yInboxDTO>(sql, new
            {
                Limit = limit <= 0 ? 10 : limit,
                Type = type,
                PendingStatus = pendingStatus,
                ProcessingStatus = processingStatus,
                ProcessingAt = processingAt
            });
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
