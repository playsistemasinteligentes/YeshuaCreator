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

namespace Input.Repository.YuserPermissionActions
{
    public class YuserPermissionActionsWriteRepository : IYuserPermissionActionsWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IYuserPermissionActionsQueryWrite _query; 

        public YuserPermissionActionsWriteRepository(IUnitOfWork unitOfWork,IYuserPermissionActionsQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IYuserPermissionActionsEntity YuserPermissionActions)
        {
            var query = _query.InserirYuserPermissionActionsQuery(YuserPermissionActions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYuserPermissionActionsEntity YuserPermissionActions)
        {
            var query = _query.UpdateYuserPermissionActionsQuery(YuserPermissionActions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYuserPermissionActionsEntity YuserPermissionActions)
        {
            var query = _query.DeleteYuserPermissionActionsQuery(YuserPermissionActions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePerfilId(IYuserPermissionActionsEntity entity)
        {
            var query = _query.UpdatePerfilId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatepermissionActionsId(IYuserPermissionActionsEntity entity)
        {
            var query = _query.UpdatepermissionActionsId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateGrant(IYuserPermissionActionsEntity entity)
        {
            var query = _query.UpdateGrant(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateCreate(IYuserPermissionActionsEntity entity)
        {
            var query = _query.UpdateCreate(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateRead(IYuserPermissionActionsEntity entity)
        {
            var query = _query.UpdateRead(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUpdate(IYuserPermissionActionsEntity entity)
        {
            var query = _query.UpdateUpdate(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDelete(IYuserPermissionActionsEntity entity)
        {
            var query = _query.UpdateDelete(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateValidUntil(IYuserPermissionActionsEntity entity)
        {
            var query = _query.UpdateValidUntil(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration