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
        void UpdateMessageId(int id, string value);
        void UpdateType(int id, string value);
        void UpdateEntityType(int id, string value);
        void UpdateEntityId(int id, string value);
        void UpdateCorrelationId(int id, string value);
        void UpdatePayload(int id, string value);
        void UpdateStatus(int id, int value);
        void UpdateTransportType(int id, int value);
        void UpdateTransportData(int id, string value);
        void UpdateCreatedAt(int id, DateTime value);
        void UpdateSentAt(int id, DateTime value);
        void UpdateRetryCount(int id, int value);
        void UpdateLastError(int id, string value);
        void UpdateProcessingAt(int id, DateTime value);
        void UpdateNextAttemptAt(int id, DateTime value);
        void UpdateSagaId(int id, int value);
        void UpdateSagaStepId(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration