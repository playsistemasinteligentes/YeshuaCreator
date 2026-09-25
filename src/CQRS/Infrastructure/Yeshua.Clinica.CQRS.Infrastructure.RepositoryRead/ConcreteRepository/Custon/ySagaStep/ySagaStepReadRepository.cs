// pendencia: definir a geracao compartilhada deste repository interno para todos os aplicativos do Studio.
using Aplication.Interfaces.Services;
using IQuery.Read;
using IRepository.Read;
using Repositorio.Outputs;
using System.Collections.Generic;

namespace Read.Repository
{
    public partial class ySagaStepReadRepository 
    {
        public int SetPendingApply()
        {
            var sql = @"
                    BEGIN TRAN

                    UPDATE s
                    SET s.Status = 4, s.Payload = i.Payload
                    FROM ySagaStep s
                    INNER JOIN yInbox i ON i.CorrelationId = s.CorrelationId
                    WHERE i.Status = 0;

                    UPDATE i
                    SET i.Status = 1
                    FROM yInbox i
                    INNER JOIN ySagaStep s ON s.CorrelationId = i.CorrelationId
                    WHERE s.Status = 4 and i.Status = 0;

                    DECLARE @Applied INT = @@ROWCOUNT;

                    COMMIT;
                    SELECT @Applied";

            return _unitOfWork.ExecuteScalar<int>(sql);
        }

        public int SetPendingApplyByInboxId(int inboxId)
        {
            var sql = @"
                UPDATE s
                   SET s.[Status] = 4,
                       s.[Payload] = i.[Payload]
                  FROM [ySagaStep] s
                 INNER JOIN [yInbox] i ON i.[Id] = @InboxId
                                      AND i.[CorrelationId] = s.[CorrelationId]
                                      AND i.[SagaId] = s.[SagaId]
                                      AND i.[SagaStepId] = s.[Id]
                 WHERE i.[Status] = 0
                   AND s.[Status] = 3;

                DECLARE @Applied INT = @@ROWCOUNT;

                UPDATE sg
                   SET sg.[NextExecutionAt] = SYSUTCDATETIME()
                  FROM [ySaga] sg
                 INNER JOIN [yInbox] i ON i.[Id] = @InboxId
                                      AND i.[SagaId] = sg.[Id]
                 WHERE @Applied > 0;

                UPDATE [yInbox]
                   SET [Status] = 1
                 WHERE [Id] = @InboxId
                   AND @Applied > 0;

                SELECT @Applied;";

            return _unitOfWork.ExecuteScalar<int>(sql, new { InboxId = inboxId });
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
