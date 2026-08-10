using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyFileUploadWriteRepository
    {
        void Insert(IyFileUploadEntity yfileupload);
        void Update(IyFileUploadEntity yfileupload);
        void Delete(IyFileUploadEntity yfileupload);
        void UpdateType(int id, string value);
        void UpdateStatus(int id, int value);
        void UpdateFilePath(int id, string value);
        void UpdateFileSize(int id, long value);
        void UpdateEntityType(int id, string value);
        void UpdateEntityId(int id, string value);
        void UpdateCreatedAt(int id, DateTime value);
        void UpdateCompletedAt(int id, DateTime value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration