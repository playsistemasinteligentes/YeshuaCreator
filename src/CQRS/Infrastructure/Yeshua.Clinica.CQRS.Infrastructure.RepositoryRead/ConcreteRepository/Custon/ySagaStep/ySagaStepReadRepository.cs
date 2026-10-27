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
                SET XACT_ABORT ON;
                BEGIN TRAN;
                DECLARE @applied TABLE (InboxId int, SagaId int);
                UPDATE st SET Status = 4, Payload = i.Payload
                  OUTPUT i.Id, inserted.SagaId INTO @applied
                  FROM ySagaStep st WITH (UPDLOCK)
                  INNER JOIN ySaga sg WITH (UPDLOCK) ON sg.Id = st.SagaId
                  CROSS APPLY (SELECT TOP 1 * FROM yInbox i WHERE i.CorrelationId = st.CorrelationId
                    AND i.SagaId = st.SagaId AND i.SagaStepId = st.Id AND i.Status = 0
                    AND i.ProcessingScope = @ProcessingScope AND i.TenantID = sg.TenantID
                    ORDER BY i.Id) i
                 WHERE st.Status = 3 AND sg.Status = 1 AND st.Deleted = 0 AND sg.Deleted = 0
                   AND sg.ProcessingScope = @ProcessingScope;
                UPDATE sg SET NextExecutionAt = SYSUTCDATETIME()
                  FROM ySaga sg INNER JOIN @applied a ON a.SagaId = sg.Id;
                UPDATE i SET Status = 1 FROM yInbox i INNER JOIN @applied a ON a.InboxId = i.Id;
                DECLARE @count int = (SELECT COUNT(*) FROM @applied);
                COMMIT;
                SELECT @count;";
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
