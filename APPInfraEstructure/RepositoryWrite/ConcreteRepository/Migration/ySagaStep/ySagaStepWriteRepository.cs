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
        public void UpdateSagaId(IySagaStepEntity entity)
        {
            var query = _query.UpdateSagaId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateKey(IySagaStepEntity entity)
        {
            var query = _query.UpdateKey(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOrder(IySagaStepEntity entity)
        {
            var query = _query.UpdateOrder(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCorrelationId(IySagaStepEntity entity)
        {
            var query = _query.UpdateCorrelationId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(IySagaStepEntity entity)
        {
            var query = _query.UpdateStatus(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateExecutionCount(IySagaStepEntity entity)
        {
            var query = _query.UpdateExecutionCount(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLastExecutionAt(IySagaStepEntity entity)
        {
            var query = _query.UpdateLastExecutionAt(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCompletedAt(IySagaStepEntity entity)
        {
            var query = _query.UpdateCompletedAt(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateErrorMessage(IySagaStepEntity entity)
        {
            var query = _query.UpdateErrorMessage(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePayload(IySagaStepEntity entity)
        {
            var query = _query.UpdatePayload(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRetryCount(IySagaStepEntity entity)
        {
            var query = _query.UpdateRetryCount(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IySagaStepEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IySagaStepEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IySagaStepEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IySagaStepEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration