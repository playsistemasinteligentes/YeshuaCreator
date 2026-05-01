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

namespace Input.Repository.ySagaStep
{
    public partial class ySagaStepWriteRepository : IySagaStepWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IySagaStepQueryWrite _query; 

        public ySagaStepWriteRepository(IUnitOfWork unitOfWork,IySagaStepQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IySagaStepEntity ySagaStep)
        {
            var query = _query.InserirySagaStepQuery(ySagaStep);
        ySagaStep.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IySagaStepEntity ySagaStep)
        {
            var query = _query.UpdateySagaStepQuery(ySagaStep);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IySagaStepEntity ySagaStep)
        {
            var query = _query.DeleteySagaStepQuery(ySagaStep);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSagaId(int id, int value)
        {
            var query = _query.UpdateSagaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStepKey(int id, string value)
        {
            var query = _query.UpdateStepKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIndexOrder(int id, int value)
        {
            var query = _query.UpdateIndexOrder(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCorrelationId(int id, string value)
        {
            var query = _query.UpdateCorrelationId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(int id, int value)
        {
            var query = _query.UpdateStatus(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateExecutionCount(int id, int value)
        {
            var query = _query.UpdateExecutionCount(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLastExecutionAt(int id, DateTime value)
        {
            var query = _query.UpdateLastExecutionAt(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCompletedAt(int id, DateTime value)
        {
            var query = _query.UpdateCompletedAt(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateErrorMessage(int id, string value)
        {
            var query = _query.UpdateErrorMessage(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePayload(int id, string value)
        {
            var query = _query.UpdatePayload(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRetryCount(int id, int value)
        {
            var query = _query.UpdateRetryCount(id, value);
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