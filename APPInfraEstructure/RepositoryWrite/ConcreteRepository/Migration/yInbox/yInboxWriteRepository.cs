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

namespace Input.Repository.yInbox
{
    public class yInboxWriteRepository : IyInboxWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyInboxQueryWrite _query; 

        public yInboxWriteRepository(IUnitOfWork unitOfWork,IyInboxQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyInboxEntity yInbox)
        {
            var query = _query.InseriryInboxQuery(yInbox);
        yInbox.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IyInboxEntity yInbox)
        {
            var query = _query.UpdateyInboxQuery(yInbox);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyInboxEntity yInbox)
        {
            var query = _query.DeleteyInboxQuery(yInbox);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMessageId(IyInboxEntity entity)
        {
            var query = _query.UpdateMessageId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateJobId(IyInboxEntity entity)
        {
            var query = _query.UpdateJobId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCorrelationId(IyInboxEntity entity)
        {
            var query = _query.UpdateCorrelationId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateType(IyInboxEntity entity)
        {
            var query = _query.UpdateType(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePayload(IyInboxEntity entity)
        {
            var query = _query.UpdatePayload(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(IyInboxEntity entity)
        {
            var query = _query.UpdateStatus(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCreatedAt(IyInboxEntity entity)
        {
            var query = _query.UpdateCreatedAt(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSentAt(IyInboxEntity entity)
        {
            var query = _query.UpdateSentAt(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRetryCount(IyInboxEntity entity)
        {
            var query = _query.UpdateRetryCount(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLastError(IyInboxEntity entity)
        {
            var query = _query.UpdateLastError(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IyInboxEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IyInboxEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IyInboxEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IyInboxEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration