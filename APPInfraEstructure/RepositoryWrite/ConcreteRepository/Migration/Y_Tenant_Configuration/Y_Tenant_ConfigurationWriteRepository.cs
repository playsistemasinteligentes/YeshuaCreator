using Dapper;
using Dominio.Entitys;
using Input.Querys.Y_Tenant_Configuration;
using Repositorio.Inputs.Repositorio.Y_Tenant_Configuration;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Y_Tenant_Configuration
{
    public class Y_Tenant_ConfigurationWriteRepository : IY_Tenant_ConfigurationWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ICacheService<object> _cacheService;

        public Y_Tenant_ConfigurationWriteRepository(IUnitOfWork unitOfWork, ICacheService<object> cacheService)
        {
             _UnitOfWork= unitOfWork;
             _cacheService = cacheService;
        }

        public void Insert(IY_Tenant_ConfigurationEntity Y_Tenant_Configuration)
        {
            _cacheService.RemoveByPrefix("Y_Tenant_Configuration");
            var query = new Y_Tenant_ConfigurationWriteQuery().InserirY_Tenant_ConfigurationQuery(Y_Tenant_Configuration);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IY_Tenant_ConfigurationEntity Y_Tenant_Configuration)
        {
            _cacheService.RemoveByPrefix("Y_Tenant_Configuration");
            var query = new Y_Tenant_ConfigurationWriteQuery().UpdateY_Tenant_ConfigurationQuery(Y_Tenant_Configuration);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IY_Tenant_ConfigurationEntity Y_Tenant_Configuration)
        {
            _cacheService.RemoveByPrefix("Y_Tenant_Configuration");
            var query = new Y_Tenant_ConfigurationWriteQuery().DeleteY_Tenant_ConfigurationQuery(Y_Tenant_Configuration);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration