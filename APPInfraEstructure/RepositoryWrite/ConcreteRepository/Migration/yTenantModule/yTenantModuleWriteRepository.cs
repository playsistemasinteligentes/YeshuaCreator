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

namespace Input.Repository.yTenantModule
{
    public class yTenantModuleWriteRepository : IyTenantModuleWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyTenantModuleQueryWrite _query; 

        public yTenantModuleWriteRepository(IUnitOfWork unitOfWork,IyTenantModuleQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyTenantModuleEntity yTenantModule)
        {
            var query = _query.InseriryTenantModuleQuery(yTenantModule);
        yTenantModule.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IyTenantModuleEntity yTenantModule)
        {
            var query = _query.UpdateyTenantModuleQuery(yTenantModule);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IyTenantModuleEntity yTenantModule)
        {
            var query = _query.DeleteyTenantModuleQuery(yTenantModule);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateModuleId(IyTenantModuleEntity entity)
        {
            var query = _query.UpdateModuleId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IyTenantModuleEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateValidUntil(IyTenantModuleEntity entity)
        {
            var query = _query.UpdateValidUntil(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDeleted(IyTenantModuleEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateChanged(IyTenantModuleEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserId(IyTenantModuleEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration