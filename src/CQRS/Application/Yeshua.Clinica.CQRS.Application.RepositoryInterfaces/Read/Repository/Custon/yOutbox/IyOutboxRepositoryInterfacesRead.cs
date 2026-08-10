using Repositorio.Outputs;
using System.Collections.Generic;

namespace IRepository.Read
{
    public partial interface IyOutboxReadRepository
    {
        public List<yOutboxDTO> ClaimBatch(int batchSize);
        public void MarkAsDone(int id, DateTime sentAt);
        public void MarkAsRetry(int id, int retryCount, DateTime nextAttempt, string error);
        public void MarkAsDeadLetter(int id, string error, int retryCount);

    }
}
