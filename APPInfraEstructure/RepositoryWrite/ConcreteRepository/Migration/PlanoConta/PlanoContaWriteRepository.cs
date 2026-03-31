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

namespace Input.Repository.PlanoConta
{
    public class PlanoContaWriteRepository : IPlanoContaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPlanoContaQueryWrite _query; 

        public PlanoContaWriteRepository(IUnitOfWork unitOfWork,IPlanoContaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPlanoContaEntity PlanoConta)
        {
            var query = _query.InserirPlanoContaQuery(PlanoConta);
        PlanoConta.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IPlanoContaEntity PlanoConta)
        {
            var query = _query.UpdatePlanoContaQuery(PlanoConta);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPlanoContaEntity PlanoConta)
        {
            var query = _query.DeletePlanoContaQuery(PlanoConta);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCodigo(IPlanoContaEntity entity)
        {
            var query = _query.UpdateCodigo(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNome(IPlanoContaEntity entity)
        {
            var query = _query.UpdateNome(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTipo(IPlanoContaEntity entity)
        {
            var query = _query.UpdateTipo(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IPlanoContaEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IPlanoContaEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IPlanoContaEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IPlanoContaEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration