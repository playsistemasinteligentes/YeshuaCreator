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
    public interface IyFileUploadReadRepository
    {
        public DataPagination<yFileUploadDTO> getyFileUpload(ICommandRead command );
        public IEnumerable<yFileUploadTenantIDDTO> getyFileUploadReadFKTenantID(object command );
        public IEnumerable<yFileUploadUserIdDTO> getyFileUploadReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByType(string value );
        public bool ExistsByStatus(int value );
        public bool ExistsByFilePath(string value );
        public bool ExistsByFileSize(long value );
        public bool ExistsByCreatedAt(DateTime value );
        public bool ExistsByCompletedAt(DateTime value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public yFileUploadDTO FirstById(int value );
        public yFileUploadDTO FirstByType(string value );
        public yFileUploadDTO FirstByStatus(int value );
        public yFileUploadDTO FirstByFilePath(string value );
        public yFileUploadDTO FirstByFileSize(long value );
        public yFileUploadDTO FirstByCreatedAt(DateTime value );
        public yFileUploadDTO FirstByCompletedAt(DateTime value );
        public yFileUploadDTO FirstByTenantID(int value );
        public yFileUploadDTO FirstByDeleted(bool value );
        public yFileUploadDTO FirstByChanged(DateTime value );
        public yFileUploadDTO FirstByUserId(int value );
        public IEnumerable<yFileUploadDTO> GetAllById(int value );
        public IEnumerable<yFileUploadDTO> GetAllByType(string value );
        public IEnumerable<yFileUploadDTO> GetAllByStatus(int value );
        public IEnumerable<yFileUploadDTO> GetAllByFilePath(string value );
        public IEnumerable<yFileUploadDTO> GetAllByFileSize(long value );
        public IEnumerable<yFileUploadDTO> GetAllByCreatedAt(DateTime value );
        public IEnumerable<yFileUploadDTO> GetAllByCompletedAt(DateTime value );
        public IEnumerable<yFileUploadDTO> GetAllByTenantID(int value );
        public IEnumerable<yFileUploadDTO> GetAllByDeleted(bool value );
        public IEnumerable<yFileUploadDTO> GetAllByChanged(DateTime value );
        public IEnumerable<yFileUploadDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration