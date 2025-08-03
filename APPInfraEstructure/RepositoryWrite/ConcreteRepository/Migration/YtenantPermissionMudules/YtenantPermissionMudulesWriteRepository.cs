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

namespace Input.Repository.YtenantPermissionMudules
{
    public class YtenantPermissionMudulesWriteRepository : IYtenantPermissionMudulesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IYtenantPermissionMudulesQueryWrite _query; 

        public YtenantPermissionMudulesWriteRepository(IUnitOfWork unitOfWork,IYtenantPermissionMudulesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IYtenantPermissionMudulesEntity YtenantPermissionMudules)
        {
            var query = _query.InserirYtenantPermissionMudulesQuery(YtenantPermissionMudules);
        YtenantPermissionMudules.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYtenantPermissionMudulesEntity YtenantPermissionMudules)
        {
            var query = _query.UpdateYtenantPermissionMudulesQuery(YtenantPermissionMudules);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYtenantPermissionMudulesEntity YtenantPermissionMudules)
        {
            var query = _query.DeleteYtenantPermissionMudulesQuery(YtenantPermissionMudules);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatepermissionModulesId(IYtenantPermissionMudulesEntity entity)
        {
            var query = _query.UpdatepermissionModulesId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IYtenantPermissionMudulesEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateValidUntil(IYtenantPermissionMudulesEntity entity)
        {
            var query = _query.UpdateValidUntil(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration