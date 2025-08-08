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

namespace Input.Repository.yUserModule
{
    public class yUserModuleWriteRepository : IyUserModuleWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyUserModuleQueryWrite _query; 

        public yUserModuleWriteRepository(IUnitOfWork unitOfWork,IyUserModuleQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyUserModuleEntity yUserModule)
        {
            var query = _query.InseriryUserModuleQuery(yUserModule);
        yUserModule.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IyUserModuleEntity yUserModule)
        {
            var query = _query.UpdateyUserModuleQuery(yUserModule);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IyUserModuleEntity yUserModule)
        {
            var query = _query.DeleteyUserModuleQuery(yUserModule);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateModuleId(IyUserModuleEntity entity)
        {
            var query = _query.UpdateModuleId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserId(IyUserModuleEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateValidUntil(IyUserModuleEntity entity)
        {
            var query = _query.UpdateValidUntil(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IyUserModuleEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDeleted(IyUserModuleEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateChanged(IyUserModuleEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration