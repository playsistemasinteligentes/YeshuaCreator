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

namespace Input.Repository.yOutbox
{
    public partial class yOutboxWriteRepository : IyOutboxWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyOutboxQueryWrite _query; 

        public yOutboxWriteRepository(IUnitOfWork unitOfWork,IyOutboxQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyOutboxEntity yOutbox)
        {
            var query = _query.InseriryOutboxQuery(yOutbox);
        yOutbox.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IyOutboxEntity yOutbox)
        {
            var query = _query.UpdateyOutboxQuery(yOutbox);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyOutboxEntity yOutbox)
        {
            var query = _query.DeleteyOutboxQuery(yOutbox);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMessageId(IyOutboxEntity entity)
        {
            var query = _query.UpdateMessageId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateType(IyOutboxEntity entity)
        {
            var query = _query.UpdateType(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEntityType(IyOutboxEntity entity)
        {
            var query = _query.UpdateEntityType(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEntityId(IyOutboxEntity entity)
        {
            var query = _query.UpdateEntityId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePayload(IyOutboxEntity entity)
        {
            var query = _query.UpdatePayload(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(IyOutboxEntity entity)
        {
            var query = _query.UpdateStatus(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTransportType(IyOutboxEntity entity)
        {
            var query = _query.UpdateTransportType(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTransportData(IyOutboxEntity entity)
        {
            var query = _query.UpdateTransportData(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCreatedAt(IyOutboxEntity entity)
        {
            var query = _query.UpdateCreatedAt(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSentAt(IyOutboxEntity entity)
        {
            var query = _query.UpdateSentAt(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRetryCount(IyOutboxEntity entity)
        {
            var query = _query.UpdateRetryCount(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLastError(IyOutboxEntity entity)
        {
            var query = _query.UpdateLastError(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProcessingAt(IyOutboxEntity entity)
        {
            var query = _query.UpdateProcessingAt(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNextAttemptAt(IyOutboxEntity entity)
        {
            var query = _query.UpdateNextAttemptAt(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSagaId(IyOutboxEntity entity)
        {
            var query = _query.UpdateSagaId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSagaStepId(IyOutboxEntity entity)
        {
            var query = _query.UpdateSagaStepId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IyOutboxEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IyOutboxEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IyOutboxEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IyOutboxEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration