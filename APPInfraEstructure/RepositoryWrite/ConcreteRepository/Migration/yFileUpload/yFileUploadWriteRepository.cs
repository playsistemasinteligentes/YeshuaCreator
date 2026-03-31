using Dapper;
using Dominio.Entitys;
using IRepository.Write;
using IQuery.Write;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.yFileUpload
{
    public class yFileUploadWriteRepository : IyFileUploadWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyFileUploadQueryWrite _query; 

        public yFileUploadWriteRepository(IUnitOfWork unitOfWork,IyFileUploadQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyFileUploadEntity yFileUpload)
        {
            var query = _query.InseriryFileUploadQuery(yFileUpload);
        yFileUpload.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IyFileUploadEntity yFileUpload)
        {
            var query = _query.UpdateyFileUploadQuery(yFileUpload);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyFileUploadEntity yFileUpload)
        {
            var query = _query.DeleteyFileUploadQuery(yFileUpload);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateType(IyFileUploadEntity entity)
        {
            var query = _query.UpdateType(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(IyFileUploadEntity entity)
        {
            var query = _query.UpdateStatus(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFilePath(IyFileUploadEntity entity)
        {
            var query = _query.UpdateFilePath(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFileSize(IyFileUploadEntity entity)
        {
            var query = _query.UpdateFileSize(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCreatedAt(IyFileUploadEntity entity)
        {
            var query = _query.UpdateCreatedAt(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCompletedAt(IyFileUploadEntity entity)
        {
            var query = _query.UpdateCompletedAt(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IyFileUploadEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IyFileUploadEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IyFileUploadEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IyFileUploadEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration