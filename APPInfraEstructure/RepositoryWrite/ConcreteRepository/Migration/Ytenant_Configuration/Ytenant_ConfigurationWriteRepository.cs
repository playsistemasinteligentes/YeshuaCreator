using Dapper;
using Dominio.Entitys;
using Input.Querys.Ytenant_Configuration;
using Repositorio.Inputs.Repositorio.Ytenant_Configuration;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Ytenant_Configuration
{
    public class Ytenant_ConfigurationWriteRepository : IYtenant_ConfigurationWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ICacheService<object> _cacheService;

        public Ytenant_ConfigurationWriteRepository(IUnitOfWork unitOfWork, ICacheService<object> cacheService)
        {
             _UnitOfWork= unitOfWork;
             _cacheService = cacheService;
        }

        public void Insert(IYtenant_ConfigurationEntity Ytenant_Configuration)
        {
            _cacheService.RemoveByPrefix("Ytenant_Configuration");
            var query = new Ytenant_ConfigurationWriteQuery().InserirYtenant_ConfigurationQuery(Ytenant_Configuration);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYtenant_ConfigurationEntity Ytenant_Configuration)
        {
            _cacheService.RemoveByPrefix("Ytenant_Configuration");
            var query = new Ytenant_ConfigurationWriteQuery().UpdateYtenant_ConfigurationQuery(Ytenant_Configuration);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYtenant_ConfigurationEntity Ytenant_Configuration)
        {
            _cacheService.RemoveByPrefix("Ytenant_Configuration");
            var query = new Ytenant_ConfigurationWriteQuery().DeleteYtenant_ConfigurationQuery(Ytenant_Configuration);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateAuditTrackerActived(IYtenant_ConfigurationEntity entity)
        {
            _cacheService.RemoveByPrefix("Ytenant_Configuration");
            var query = new Ytenant_ConfigurationWriteQuery().UpdateAuditTrackerActived(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateAuditCRUDActived(IYtenant_ConfigurationEntity entity)
        {
            _cacheService.RemoveByPrefix("Ytenant_Configuration");
            var query = new Ytenant_ConfigurationWriteQuery().UpdateAuditCRUDActived(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IYtenant_ConfigurationEntity entity)
        {
            _cacheService.RemoveByPrefix("Ytenant_Configuration");
            var query = new Ytenant_ConfigurationWriteQuery().UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration