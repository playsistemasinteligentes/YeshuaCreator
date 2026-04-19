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
        public void UpdateSagaId(IySagaEntity entity)
        {
            var query = _query.UpdateSagaId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateType(IySagaEntity entity)
        {
            var query = _query.UpdateType(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(IySagaEntity entity)
        {
            var query = _query.UpdateStatus(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateKeyCurrentStep(IySagaEntity entity)
        {
            var query = _query.UpdateKeyCurrentStep(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCreatedAt(IySagaEntity entity)
        {
            var query = _query.UpdateCreatedAt(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCompletedAt(IySagaEntity entity)
        {
            var query = _query.UpdateCompletedAt(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEntityType(IySagaEntity entity)
        {
            var query = _query.UpdateEntityType(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEntityId(IySagaEntity entity)
        {
            var query = _query.UpdateEntityId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IySagaEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IySagaEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IySagaEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IySagaEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration