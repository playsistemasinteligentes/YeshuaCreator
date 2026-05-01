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
        public void UpdateMessageId(int id, string value)
        {
            var query = _query.UpdateMessageId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateType(int id, string value)
        {
            var query = _query.UpdateType(id, value);
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
        public void UpdateCorrelationId(int id, string value)
        {
            var query = _query.UpdateCorrelationId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePayload(int id, string value)
        {
            var query = _query.UpdatePayload(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(int id, int value)
        {
            var query = _query.UpdateStatus(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTransportType(int id, int value)
        {
            var query = _query.UpdateTransportType(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTransportData(int id, string value)
        {
            var query = _query.UpdateTransportData(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCreatedAt(int id, DateTime value)
        {
            var query = _query.UpdateCreatedAt(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSentAt(int id, DateTime value)
        {
            var query = _query.UpdateSentAt(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRetryCount(int id, int value)
        {
            var query = _query.UpdateRetryCount(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLastError(int id, string value)
        {
            var query = _query.UpdateLastError(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProcessingAt(int id, DateTime value)
        {
            var query = _query.UpdateProcessingAt(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNextAttemptAt(int id, DateTime value)
        {
            var query = _query.UpdateNextAttemptAt(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSagaId(int id, int value)
        {
            var query = _query.UpdateSagaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSagaStepId(int id, int value)
        {
            var query = _query.UpdateSagaStepId(id, value);
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