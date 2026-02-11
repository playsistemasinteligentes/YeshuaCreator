using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IyFileUploadQueryWrite 
     {
        public QueryModel InseriryFileUploadQuery(IyFileUploadEntity yFileUpload);
        public QueryModel UpdateyFileUploadQuery(IyFileUploadEntity yFileUpload);
        public QueryModel UpdateIdempotencyKey(IyFileUploadEntity entity);
        public QueryModel UpdateType(IyFileUploadEntity entity);
        public QueryModel UpdateStatus(IyFileUploadEntity entity);
        public QueryModel UpdateFilePath(IyFileUploadEntity entity);
        public QueryModel UpdateFileSize(IyFileUploadEntity entity);
        public QueryModel UpdateContentType(IyFileUploadEntity entity);
        public QueryModel UpdateCreatedAt(IyFileUploadEntity entity);
        public QueryModel UpdateCompletedAt(IyFileUploadEntity entity);
        public QueryModel UpdateTenantID(IyFileUploadEntity entity);
        public QueryModel UpdateDeleted(IyFileUploadEntity entity);
        public QueryModel UpdateChanged(IyFileUploadEntity entity);
        public QueryModel UpdateUserId(IyFileUploadEntity entity);
        public QueryModel DeleteyFileUploadQuery(IyFileUploadEntity yFileUpload);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration