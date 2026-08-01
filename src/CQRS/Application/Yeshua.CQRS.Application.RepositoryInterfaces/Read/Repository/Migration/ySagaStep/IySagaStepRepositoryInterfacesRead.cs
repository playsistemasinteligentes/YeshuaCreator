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
    public partial interface IySagaStepReadRepository
    {
        public DataPagination<ySagaStepDTO> getySagaStep(ICommandRead command , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepSagaIdDTO> getySagaStepReadFKSagaId(object command , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepTenantIDDTO> getySagaStepReadFKTenantID(object command , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepUserIdDTO> getySagaStepReadFKUserId(object command , bool TakeOffTenantID = false);
        public bool ExistsById(int value , bool TakeOffTenantID = false);
        public bool ExistsBySagaId(int value , bool TakeOffTenantID = false);
        public bool ExistsByStepKey(string value , bool TakeOffTenantID = false);
        public bool ExistsByIndexOrder(int value , bool TakeOffTenantID = false);
        public bool ExistsByCorrelationId(string value , bool TakeOffTenantID = false);
        public bool ExistsByStatus(int value , bool TakeOffTenantID = false);
        public bool ExistsByExecutionCount(int value , bool TakeOffTenantID = false);
        public bool ExistsByLastExecutionAt(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByCompletedAt(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByErrorMessage(string value , bool TakeOffTenantID = false);
        public bool ExistsByPayload(string value , bool TakeOffTenantID = false);
        public bool ExistsByRetryCount(int value , bool TakeOffTenantID = false);
        public bool ExistsByTenantID(int value , bool TakeOffTenantID = false);
        public bool ExistsByDeleted(bool value , bool TakeOffTenantID = false);
        public bool ExistsByChanged(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByUserId(int value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstById(int value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstBySagaId(int value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByStepKey(string value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByIndexOrder(int value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByCorrelationId(string value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByStatus(int value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByExecutionCount(int value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByLastExecutionAt(DateTime value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByCompletedAt(DateTime value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByErrorMessage(string value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByPayload(string value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByRetryCount(int value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByTenantID(int value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByDeleted(bool value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false);
        public ySagaStepDTO FirstByUserId(int value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllById(int value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllBySagaId(int value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByStepKey(string value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByIndexOrder(int value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByCorrelationId(string value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByStatus(int value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByExecutionCount(int value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByLastExecutionAt(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByCompletedAt(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByErrorMessage(string value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByPayload(string value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByRetryCount(int value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaStepDTO> GetAllByUserId(int value , bool TakeOffTenantID = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration