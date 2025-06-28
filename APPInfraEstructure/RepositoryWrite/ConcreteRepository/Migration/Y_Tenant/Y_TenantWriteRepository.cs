using Dapper;
using Dominio.Entitys;
using Input.Querys.Y_Tenant;
using Repositorio.Inputs.Repositorio.Y_Tenant;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Y_Tenant
{
    public class Y_TenantWriteRepository : IY_TenantWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public Y_TenantWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(Y_TenantEntity Y_Tenant)
        {
            var query = new Y_TenantWriteQuery().InserirY_TenantQuery(Y_Tenant);
        Y_Tenant.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(Y_TenantEntity Y_Tenant)
        {
            var query = new Y_TenantWriteQuery().UpdateY_TenantQuery(Y_Tenant);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(Y_TenantEntity Y_Tenant)
        {
            var query = new Y_TenantWriteQuery().DeleteY_TenantQuery(Y_Tenant);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration