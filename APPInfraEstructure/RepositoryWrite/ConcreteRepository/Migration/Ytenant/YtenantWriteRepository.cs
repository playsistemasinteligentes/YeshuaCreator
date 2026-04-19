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

namespace Input.Repository.yTenant
{
    public partial class yTenantWriteRepository : IyTenantWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyTenantQueryWrite _query; 

        public yTenantWriteRepository(IUnitOfWork unitOfWork,IyTenantQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyTenantEntity yTenant)
        {
            var query = _query.InseriryTenantQuery(yTenant);
        yTenant.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IyTenantEntity yTenant)
        {
            var query = _query.UpdateyTenantQuery(yTenant);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyTenantEntity yTenant)
        {
            var query = _query.DeleteyTenantQuery(yTenant);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCnpjCpf(IyTenantEntity entity)
        {
            var query = _query.UpdateCnpjCpf(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNome(IyTenantEntity entity)
        {
            var query = _query.UpdateNome(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IyTenantEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IyTenantEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IyTenantEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration