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
    public interface IyInboxReadRepository
    {
        public DataPagination<yInboxDTO> getyInbox(ICommandRead command );
        public IEnumerable<yInboxTenantIDDTO> getyInboxReadFKTenantID(object command );
        public IEnumerable<yInboxUserIdDTO> getyInboxReadFKUserId(object command );
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
        public yInboxDTO FirstById(int value );
        public yInboxDTO FirstByMessageId(string value );
        public yInboxDTO FirstByJobId(string value );
        public yInboxDTO FirstByCorrelationId(string value );
        public yInboxDTO FirstByType(string value );
        public yInboxDTO FirstByPayload(string value );
        public yInboxDTO FirstByStatus(int value );
        public yInboxDTO FirstByCreatedAt(DateTime value );
        public yInboxDTO FirstBySentAt(DateTime value );
        public yInboxDTO FirstByRetryCount(int value );
        public yInboxDTO FirstByLastError(string value );
        public yInboxDTO FirstByTenantID(int value );
        public yInboxDTO FirstByDeleted(bool value );
        public yInboxDTO FirstByChanged(DateTime value );
        public yInboxDTO FirstByUserId(int value );
        public IEnumerable<yInboxDTO> GetAllById(int value );
        public IEnumerable<yInboxDTO> GetAllByMessageId(string value );
        public IEnumerable<yInboxDTO> GetAllByJobId(string value );
        public IEnumerable<yInboxDTO> GetAllByCorrelationId(string value );
        public IEnumerable<yInboxDTO> GetAllByType(string value );
        public IEnumerable<yInboxDTO> GetAllByPayload(string value );
        public IEnumerable<yInboxDTO> GetAllByStatus(int value );
        public IEnumerable<yInboxDTO> GetAllByCreatedAt(DateTime value );
        public IEnumerable<yInboxDTO> GetAllBySentAt(DateTime value );
        public IEnumerable<yInboxDTO> GetAllByRetryCount(int value );
        public IEnumerable<yInboxDTO> GetAllByLastError(string value );
        public IEnumerable<yInboxDTO> GetAllByTenantID(int value );
        public IEnumerable<yInboxDTO> GetAllByDeleted(bool value );
        public IEnumerable<yInboxDTO> GetAllByChanged(DateTime value );
        public IEnumerable<yInboxDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration