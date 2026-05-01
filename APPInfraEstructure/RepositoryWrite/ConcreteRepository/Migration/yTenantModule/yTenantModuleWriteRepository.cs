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
    public partial class yTenantModuleWriteRepository : IyTenantModuleWriteRepository
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
        yTenantModule.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IyTenantModuleEntity yTenantModule)
        {
            var query = _query.UpdateyTenantModuleQuery(yTenantModule);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyTenantModuleEntity yTenantModule)
        {
            var query = _query.DeleteyTenantModuleQuery(yTenantModule);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateModuleId(int id, string value)
        {
            var query = _query.UpdateModuleId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValidUntil(int id, DateTime value)
        {
            var query = _query.UpdateValidUntil(id, value);
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