using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public partial interface IyOutboxReadRepository
    {
        public DataPagination<yOutboxDTO> getyOutbox(ICommandRead command , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxSagaIdDTO> getyOutboxReadFKSagaId(object command , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxSagaStepIdDTO> getyOutboxReadFKSagaStepId(object command , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxTenantIDDTO> getyOutboxReadFKTenantID(object command , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxUserIdDTO> getyOutboxReadFKUserId(object command , bool TakeOffTenantID = false);
        public bool ExistsById(int value , bool TakeOffTenantID = false);
        public bool ExistsByMessageId(string value , bool TakeOffTenantID = false);
        public bool ExistsByType(string value , bool TakeOffTenantID = false);
        public bool ExistsByEntityType(string value , bool TakeOffTenantID = false);
        public bool ExistsByEntityId(string value , bool TakeOffTenantID = false);
        public bool ExistsByPayload(string value , bool TakeOffTenantID = false);
        public bool ExistsByStatus(int value , bool TakeOffTenantID = false);
        public bool ExistsByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsBySentAt(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByRetryCount(int value , bool TakeOffTenantID = false);
        public bool ExistsByLastError(string value , bool TakeOffTenantID = false);
        public bool ExistsBySagaId(int value , bool TakeOffTenantID = false);
        public bool ExistsBySagaStepId(int value , bool TakeOffTenantID = false);
        public bool ExistsByTenantID(int value , bool TakeOffTenantID = false);
        public bool ExistsByDeleted(bool value , bool TakeOffTenantID = false);
        public bool ExistsByChanged(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByUserId(int value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstById(int value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstByMessageId(string value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstByType(string value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstByEntityType(string value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstByEntityId(string value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstByPayload(string value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstByStatus(int value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstBySentAt(DateTime value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstByRetryCount(int value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstByLastError(string value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstBySagaId(int value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstBySagaStepId(int value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstByTenantID(int value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstByDeleted(bool value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false);
        public yOutboxDTO FirstByUserId(int value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllById(int value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllByMessageId(string value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllByType(string value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllByEntityType(string value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllByEntityId(string value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllByPayload(string value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllByStatus(int value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllBySentAt(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllByRetryCount(int value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllByLastError(string value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllBySagaId(int value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllBySagaStepId(int value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yOutboxDTO> GetAllByUserId(int value , bool TakeOffTenantID = false);
        public DataPagination<yOutboxStandardDTO> GetyOutboxProximaPendente(ICommandRead command , bool TakeOffTenantID = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration