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
                    INNER JOIN ySaga sg ON sg.Id = s.SagaId
                    WHERE i.Status = 0
                      AND i.ProcessingScope = @ProcessingScope
                      AND sg.ProcessingScope = @ProcessingScope;

                    UPDATE i
                    SET i.Status = 1
                    FROM yInbox i
                    INNER JOIN ySagaStep s ON s.CorrelationId = i.CorrelationId
                    INNER JOIN ySaga sg ON sg.Id = s.SagaId
                    WHERE s.Status = 4
                      AND i.Status = 0
                      AND i.ProcessingScope = @ProcessingScope
                      AND sg.ProcessingScope = @ProcessingScope;

                    DECLARE @Applied INT = @@ROWCOUNT;

                    COMMIT;
                    SELECT @Applied";

            return _unitOfWork.ExecuteScalar<int>(sql, new
            {
                ProcessingScope = _executionContext.ProcessingScope
            });
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
                 INNER JOIN [ySaga] sg ON sg.[Id] = s.[SagaId]
                 WHERE i.[Status] = 0
                   AND s.[Status] = 3
                   AND i.[ProcessingScope] = @ProcessingScope
                   AND sg.[ProcessingScope] = @ProcessingScope;

                DECLARE @Applied INT = @@ROWCOUNT;

                UPDATE sg
                   SET sg.[NextExecutionAt] = SYSUTCDATETIME()
                  FROM [ySaga] sg
                 INNER JOIN [yInbox] i ON i.[Id] = @InboxId
                                      AND i.[SagaId] = sg.[Id]
                 WHERE @Applied > 0
                   AND i.[ProcessingScope] = @ProcessingScope
                   AND sg.[ProcessingScope] = @ProcessingScope;

                UPDATE [yInbox]
                   SET [Status] = 1
                 WHERE [Id] = @InboxId
                   AND [ProcessingScope] = @ProcessingScope
                   AND @Applied > 0;

                SELECT @Applied;";

            return _unitOfWork.ExecuteScalar<int>(sql, new
            {
                InboxId = inboxId,
                ProcessingScope = _executionContext.ProcessingScope
            });
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
