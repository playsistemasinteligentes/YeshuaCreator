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
        public void UpdateType(IyFileUploadEntity entity);
        public void UpdateStatus(IyFileUploadEntity entity);
        public void UpdateFilePath(IyFileUploadEntity entity);
        public void UpdateFileSize(IyFileUploadEntity entity);
        public void UpdateCreatedAt(IyFileUploadEntity entity);
        public void UpdateCompletedAt(IyFileUploadEntity entity);
        public void UpdateTenantID(IyFileUploadEntity entity);
        public void UpdateDeleted(IyFileUploadEntity entity);
        public void UpdateChanged(IyFileUploadEntity entity);
        public void UpdateUserId(IyFileUploadEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration