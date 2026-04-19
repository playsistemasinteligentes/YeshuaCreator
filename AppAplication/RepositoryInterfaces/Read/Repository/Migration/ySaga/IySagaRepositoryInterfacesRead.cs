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
    public partial interface IySagaReadRepository
    {
        public DataPagination<ySagaDTO> getySaga(ICommandRead command , bool TakeOffTenantID = false);
        public IEnumerable<ySagaTenantIDDTO> getySagaReadFKTenantID(object command , bool TakeOffTenantID = false);
        public IEnumerable<ySagaUserIdDTO> getySagaReadFKUserId(object command , bool TakeOffTenantID = false);
        public bool ExistsById(int value , bool TakeOffTenantID = false);
        public bool ExistsBySagaId(string value , bool TakeOffTenantID = false);
        public bool ExistsByType(string value , bool TakeOffTenantID = false);
        public bool ExistsByStatus(int value , bool TakeOffTenantID = false);
        public bool ExistsByKeyCurrentStep(string value , bool TakeOffTenantID = false);
        public bool ExistsByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByCompletedAt(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByEntityType(string value , bool TakeOffTenantID = false);
        public bool ExistsByEntityId(string value , bool TakeOffTenantID = false);
        public bool ExistsByTenantID(int value , bool TakeOffTenantID = false);
        public bool ExistsByDeleted(bool value , bool TakeOffTenantID = false);
        public bool ExistsByChanged(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByUserId(int value , bool TakeOffTenantID = false);
        public ySagaDTO FirstById(int value , bool TakeOffTenantID = false);
        public ySagaDTO FirstBySagaId(string value , bool TakeOffTenantID = false);
        public ySagaDTO FirstByType(string value , bool TakeOffTenantID = false);
        public ySagaDTO FirstByStatus(int value , bool TakeOffTenantID = false);
        public ySagaDTO FirstByKeyCurrentStep(string value , bool TakeOffTenantID = false);
        public ySagaDTO FirstByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public ySagaDTO FirstByCompletedAt(DateTime value , bool TakeOffTenantID = false);
        public ySagaDTO FirstByEntityType(string value , bool TakeOffTenantID = false);
        public ySagaDTO FirstByEntityId(string value , bool TakeOffTenantID = false);
        public ySagaDTO FirstByTenantID(int value , bool TakeOffTenantID = false);
        public ySagaDTO FirstByDeleted(bool value , bool TakeOffTenantID = false);
        public ySagaDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false);
        public ySagaDTO FirstByUserId(int value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaDTO> GetAllById(int value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaDTO> GetAllBySagaId(string value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaDTO> GetAllByType(string value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaDTO> GetAllByStatus(int value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaDTO> GetAllByKeyCurrentStep(string value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaDTO> GetAllByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaDTO> GetAllByCompletedAt(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaDTO> GetAllByEntityType(string value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaDTO> GetAllByEntityId(string value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<ySagaDTO> GetAllByUserId(int value , bool TakeOffTenantID = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration