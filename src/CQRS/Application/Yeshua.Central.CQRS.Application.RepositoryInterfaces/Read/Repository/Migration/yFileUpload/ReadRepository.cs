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
    public partial interface IyFileUploadReadRepository
    {
        public DataPagination<yFileUploadDTO> getyFileUpload(ICommandRead command , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadTenantIDDTO> getyFileUploadReadFKTenantID(object command , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadUserIdDTO> getyFileUploadReadFKUserId(object command , bool TakeOffTenantID = false);
        public bool ExistsById(int value , bool TakeOffTenantID = false);
        public bool ExistsByType(string value , bool TakeOffTenantID = false);
        public bool ExistsByStatus(int value , bool TakeOffTenantID = false);
        public bool ExistsByFilePath(string value , bool TakeOffTenantID = false);
        public bool ExistsByFileSize(long value , bool TakeOffTenantID = false);
        public bool ExistsByEntityType(string value , bool TakeOffTenantID = false);
        public bool ExistsByEntityId(string value , bool TakeOffTenantID = false);
        public bool ExistsByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByCompletedAt(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByTenantID(int value , bool TakeOffTenantID = false);
        public bool ExistsByDeleted(bool value , bool TakeOffTenantID = false);
        public bool ExistsByChanged(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByUserId(int value , bool TakeOffTenantID = false);
        public yFileUploadDTO FirstById(int value , bool TakeOffTenantID = false);
        public yFileUploadDTO FirstByType(string value , bool TakeOffTenantID = false);
        public yFileUploadDTO FirstByStatus(int value , bool TakeOffTenantID = false);
        public yFileUploadDTO FirstByFilePath(string value , bool TakeOffTenantID = false);
        public yFileUploadDTO FirstByFileSize(long value , bool TakeOffTenantID = false);
        public yFileUploadDTO FirstByEntityType(string value , bool TakeOffTenantID = false);
        public yFileUploadDTO FirstByEntityId(string value , bool TakeOffTenantID = false);
        public yFileUploadDTO FirstByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public yFileUploadDTO FirstByCompletedAt(DateTime value , bool TakeOffTenantID = false);
        public yFileUploadDTO FirstByTenantID(int value , bool TakeOffTenantID = false);
        public yFileUploadDTO FirstByDeleted(bool value , bool TakeOffTenantID = false);
        public yFileUploadDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false);
        public yFileUploadDTO FirstByUserId(int value , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadDTO> GetAllById(int value , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadDTO> GetAllByType(string value , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadDTO> GetAllByStatus(int value , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadDTO> GetAllByFilePath(string value , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadDTO> GetAllByFileSize(long value , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadDTO> GetAllByEntityType(string value , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadDTO> GetAllByEntityId(string value , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadDTO> GetAllByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadDTO> GetAllByCompletedAt(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yFileUploadDTO> GetAllByUserId(int value , bool TakeOffTenantID = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration