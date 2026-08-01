using Microsoft.Data.SqlClient;
using Repositorio.Outputs;
using System.Collections.Generic;
using System.Linq;

namespace Read.Repository
{
    public partial class yOutboxReadRepository
    {
        public List<yOutboxDTO> ClaimBatch(int batchSize)
        {
            var sql = @"
        DECLARE @now DATETIME2 = SYSUTCDATETIME();

        UPDATE TOP (@BatchSize) yOutbox WITH (ROWLOCK, READPAST)
        SET 
            Status = 9,
            ProcessingAt = @now
        OUTPUT inserted.*
        WHERE 
            (
                Status = 0
                OR (
                    Status = 9 
                    AND ProcessingAt < DATEADD(MINUTE, -@TimeoutMinutes, @now)
                )
            )
            AND SagaId is not null 
            AND (NextAttemptAt IS NULL OR NextAttemptAt <= @now)
    ";

            return _unitOfWork.Query<yOutboxDTO>(sql, new
            {
                BatchSize = batchSize,
                TimeoutMinutes = 5
            }).ToList();
        }
        public void MarkAsDone(int id, DateTime sentAt)
        {
            var sql = @"
        UPDATE yOutbox
        SET 
            Status = 1,
            SentAt = @SentAt,
            ProcessingAt = NULL
        WHERE Id = @Id
    ";

            _unitOfWork.Execute(sql, new
            {
                Id = id,
                SentAt = sentAt
            });
        }

        public void MarkAsRetry(int id, int retryCount, DateTime nextAttempt, string error)
        {
            var sql = @"
        UPDATE yOutbox
        SET 
            Status = 0,
            RetryCount = @RetryCount,
            NextAttemptAt = @NextAttemptAt,
            LastError = @LastError,
            ProcessingAt = NULL
        WHERE Id = @Id
    ";

            _unitOfWork.Execute(sql, new
            {
                Id = id,
                RetryCount = retryCount,
                NextAttemptAt = nextAttempt,
                LastError = error ?? ""
            });
        }

        public void MarkAsDeadLetter(int id, string error, int retryCount)
        {
            var sql = @"
        UPDATE yOutbox
        SET 
            Status = 2,
            RetryCount = @RetryCount,
            LastError = @LastError,
            ProcessingAt = NULL
        WHERE Id = @Id
    ";

            _unitOfWork.Execute(sql, new
            {
                Id = id,
                RetryCount = retryCount,
                LastError = error ?? ""
            });
        }
    }
}