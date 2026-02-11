using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyOutboxWriteRepository
    {
        void Insert(IyOutboxEntity youtbox);
        void Update(IyOutboxEntity youtbox);
        void Delete(IyOutboxEntity youtbox);
        public void UpdateMessageId(IyOutboxEntity entity);
        public void UpdateJobId(IyOutboxEntity entity);
        public void UpdateCorrelationId(IyOutboxEntity entity);
        public void UpdateType(IyOutboxEntity entity);
        public void UpdatePayload(IyOutboxEntity entity);
        public void UpdateStatus(IyOutboxEntity entity);
        public void UpdateCreatedAt(IyOutboxEntity entity);
        public void UpdateSentAt(IyOutboxEntity entity);
        public void UpdateRetryCount(IyOutboxEntity entity);
        public void UpdateLastError(IyOutboxEntity entity);
        public void UpdateTenantID(IyOutboxEntity entity);
        public void UpdateDeleted(IyOutboxEntity entity);
        public void UpdateChanged(IyOutboxEntity entity);
        public void UpdateUserId(IyOutboxEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration