using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyInboxWriteRepository
    {
        void Insert(IyInboxEntity yinbox);
        void Update(IyInboxEntity yinbox);
        void Delete(IyInboxEntity yinbox);
        public void UpdateMessageId(IyInboxEntity entity);
        public void UpdateType(IyInboxEntity entity);
        public void UpdateEntityType(IyInboxEntity entity);
        public void UpdateEntityId(IyInboxEntity entity);
        public void UpdatePayload(IyInboxEntity entity);
        public void UpdateStatus(IyInboxEntity entity);
        public void UpdateCreatedAt(IyInboxEntity entity);
        public void UpdateSentAt(IyInboxEntity entity);
        public void UpdateRetryCount(IyInboxEntity entity);
        public void UpdateLastError(IyInboxEntity entity);
        public void UpdateSagaId(IyInboxEntity entity);
        public void UpdateSagaStepId(IyInboxEntity entity);
        public void UpdateTenantID(IyInboxEntity entity);
        public void UpdateDeleted(IyInboxEntity entity);
        public void UpdateChanged(IyInboxEntity entity);
        public void UpdateUserId(IyInboxEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration