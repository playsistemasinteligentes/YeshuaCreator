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
    public interface IyOutboxReadRepository
    {
        public DataPagination<yOutboxDTO> getyOutbox(ICommandRead command );
        public IEnumerable<yOutboxTenantIDDTO> getyOutboxReadFKTenantID(object command );
        public IEnumerable<yOutboxUserIdDTO> getyOutboxReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByMessageId(string value );
        public bool ExistsByJobId(string value );
        public bool ExistsByCorrelationId(string value );
        public bool ExistsByType(string value );
        public bool ExistsByPayload(string value );
        public bool ExistsByStatus(int value );
        public bool ExistsByCreatedAt(DateTime value );
        public bool ExistsBySentAt(DateTime value );
        public bool ExistsByRetryCount(int value );
        public bool ExistsByLastError(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public yOutboxDTO FirstById(int value );
        public yOutboxDTO FirstByMessageId(string value );
        public yOutboxDTO FirstByJobId(string value );
        public yOutboxDTO FirstByCorrelationId(string value );
        public yOutboxDTO FirstByType(string value );
        public yOutboxDTO FirstByPayload(string value );
        public yOutboxDTO FirstByStatus(int value );
        public yOutboxDTO FirstByCreatedAt(DateTime value );
        public yOutboxDTO FirstBySentAt(DateTime value );
        public yOutboxDTO FirstByRetryCount(int value );
        public yOutboxDTO FirstByLastError(string value );
        public yOutboxDTO FirstByTenantID(int value );
        public yOutboxDTO FirstByDeleted(bool value );
        public yOutboxDTO FirstByChanged(DateTime value );
        public yOutboxDTO FirstByUserId(int value );
        public IEnumerable<yOutboxDTO> GetAllById(int value );
        public IEnumerable<yOutboxDTO> GetAllByMessageId(string value );
        public IEnumerable<yOutboxDTO> GetAllByJobId(string value );
        public IEnumerable<yOutboxDTO> GetAllByCorrelationId(string value );
        public IEnumerable<yOutboxDTO> GetAllByType(string value );
        public IEnumerable<yOutboxDTO> GetAllByPayload(string value );
        public IEnumerable<yOutboxDTO> GetAllByStatus(int value );
        public IEnumerable<yOutboxDTO> GetAllByCreatedAt(DateTime value );
        public IEnumerable<yOutboxDTO> GetAllBySentAt(DateTime value );
        public IEnumerable<yOutboxDTO> GetAllByRetryCount(int value );
        public IEnumerable<yOutboxDTO> GetAllByLastError(string value );
        public IEnumerable<yOutboxDTO> GetAllByTenantID(int value );
        public IEnumerable<yOutboxDTO> GetAllByDeleted(bool value );
        public IEnumerable<yOutboxDTO> GetAllByChanged(DateTime value );
        public IEnumerable<yOutboxDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration