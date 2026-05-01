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

namespace Input.Repository.ySaga
{
    public partial class ySagaWriteRepository : IySagaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IySagaQueryWrite _query; 

        public ySagaWriteRepository(IUnitOfWork unitOfWork,IySagaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IySagaEntity ySaga)
        {
            var query = _query.InserirySagaQuery(ySaga);
        ySaga.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IySagaEntity ySaga)
        {
            var query = _query.UpdateySagaQuery(ySaga);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IySagaEntity ySaga)
        {
            var query = _query.DeleteySagaQuery(ySaga);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCorrelationId(int id, string value)
        {
            var query = _query.UpdateCorrelationId(id, value);
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
        public void UpdateKeyCurrentStep(int id, string value)
        {
            var query = _query.UpdateKeyCurrentStep(id, value);
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
        public void UpdateNextExecutionAt(int id, DateTime value)
        {
            var query = _query.UpdateNextExecutionAt(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLockedAt(int id, DateTime value)
        {
            var query = _query.UpdateLockedAt(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLockedBy(int id, string value)
        {
            var query = _query.UpdateLockedBy(id, value);
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