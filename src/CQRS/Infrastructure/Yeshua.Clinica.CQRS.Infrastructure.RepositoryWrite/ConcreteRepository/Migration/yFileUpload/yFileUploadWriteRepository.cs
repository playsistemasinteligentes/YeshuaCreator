// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

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
    public partial class yFileUploadWriteRepository : IyFileUploadWriteRepository
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
        public void UpdateType(int id, string value)
        {
            var query = _query.UpdateType(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(int id, int value)
        {
            var query = _query.UpdateStatus(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFilePath(int id, string value)
        {
            var query = _query.UpdateFilePath(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFileSize(int id, long value)
        {
            var query = _query.UpdateFileSize(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEntityType(int id, string value)
        {
            var query = _query.UpdateEntityType(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEntityId(int id, string value)
        {
            var query = _query.UpdateEntityId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCreatedAt(int id, DateTime value)
        {
            var query = _query.UpdateCreatedAt(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCompletedAt(int id, DateTime value)
        {
            var query = _query.UpdateCompletedAt(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration