// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

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
    public partial interface IyInboxReadRepository
    {
        public DataPagination<yInboxDTO> getyInbox(ICommandRead command , bool TakeOffTenantID = false);
        public IEnumerable<yInboxSagaIdDTO> getyInboxReadFKSagaId(object command , bool TakeOffTenantID = false);
        public IEnumerable<yInboxSagaStepIdDTO> getyInboxReadFKSagaStepId(object command , bool TakeOffTenantID = false);
        public IEnumerable<yInboxTenantIDDTO> getyInboxReadFKTenantID(object command , bool TakeOffTenantID = false);
        public IEnumerable<yInboxUserIdDTO> getyInboxReadFKUserId(object command , bool TakeOffTenantID = false);
        public bool ExistsById(int value , bool TakeOffTenantID = false);
        public bool ExistsByMessageId(string value , bool TakeOffTenantID = false);
        public bool ExistsByType(string value , bool TakeOffTenantID = false);
        public bool ExistsByEntityType(string value , bool TakeOffTenantID = false);
        public bool ExistsByEntityId(string value , bool TakeOffTenantID = false);
        public bool ExistsByCorrelationId(string value , bool TakeOffTenantID = false);
        public bool ExistsByPayload(string value , bool TakeOffTenantID = false);
        public bool ExistsByStatus(int value , bool TakeOffTenantID = false);
        public bool ExistsByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByRetryCount(int value , bool TakeOffTenantID = false);
        public bool ExistsByLastError(string value , bool TakeOffTenantID = false);
        public bool ExistsByProcessingAt(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByNextAttemptAt(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsBySagaId(int value , bool TakeOffTenantID = false);
        public bool ExistsBySagaStepId(int value , bool TakeOffTenantID = false);
        public bool ExistsByTenantID(int value , bool TakeOffTenantID = false);
        public bool ExistsByDeleted(bool value , bool TakeOffTenantID = false);
        public bool ExistsByChanged(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByUserId(int value , bool TakeOffTenantID = false);
        public yInboxDTO FirstById(int value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByMessageId(string value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByType(string value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByEntityType(string value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByEntityId(string value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByCorrelationId(string value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByPayload(string value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByStatus(int value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByRetryCount(int value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByLastError(string value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByProcessingAt(DateTime value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByNextAttemptAt(DateTime value , bool TakeOffTenantID = false);
        public yInboxDTO FirstBySagaId(int value , bool TakeOffTenantID = false);
        public yInboxDTO FirstBySagaStepId(int value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByTenantID(int value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByDeleted(bool value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false);
        public yInboxDTO FirstByUserId(int value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllById(int value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByMessageId(string value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByType(string value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByEntityType(string value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByEntityId(string value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByCorrelationId(string value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByPayload(string value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByStatus(int value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByRetryCount(int value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByLastError(string value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByProcessingAt(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByNextAttemptAt(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllBySagaId(int value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllBySagaStepId(int value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yInboxDTO> GetAllByUserId(int value , bool TakeOffTenantID = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration