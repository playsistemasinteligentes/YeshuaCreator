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
    public partial class yUserModuleWriteRepository : IyUserModuleWriteRepository
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
        yUserModule.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IyUserModuleEntity yUserModule)
        {
            var query = _query.UpdateyUserModuleQuery(yUserModule);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyUserModuleEntity yUserModule)
        {
            var query = _query.DeleteyUserModuleQuery(yUserModule);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateModuleId(IyUserModuleEntity entity)
        {
            var query = _query.UpdateModuleId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IyUserModuleEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValidUntil(IyUserModuleEntity entity)
        {
            var query = _query.UpdateValidUntil(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IyUserModuleEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IyUserModuleEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IyUserModuleEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration