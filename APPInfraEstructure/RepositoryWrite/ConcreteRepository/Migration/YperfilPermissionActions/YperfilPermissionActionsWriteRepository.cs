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

namespace Input.Repository.YperfilPermissionActions
{
    public class YperfilPermissionActionsWriteRepository : IYperfilPermissionActionsWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IYperfilPermissionActionsQueryWrite _query; 

        public YperfilPermissionActionsWriteRepository(IUnitOfWork unitOfWork,IYperfilPermissionActionsQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IYperfilPermissionActionsEntity YperfilPermissionActions)
        {
            var query = _query.InserirYperfilPermissionActionsQuery(YperfilPermissionActions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYperfilPermissionActionsEntity YperfilPermissionActions)
        {
            var query = _query.UpdateYperfilPermissionActionsQuery(YperfilPermissionActions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYperfilPermissionActionsEntity YperfilPermissionActions)
        {
            var query = _query.DeleteYperfilPermissionActionsQuery(YperfilPermissionActions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePerfilId(IYperfilPermissionActionsEntity entity)
        {
            var query = _query.UpdatePerfilId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatepermissionActionsId(IYperfilPermissionActionsEntity entity)
        {
            var query = _query.UpdatepermissionActionsId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateGrant(IYperfilPermissionActionsEntity entity)
        {
            var query = _query.UpdateGrant(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateCreate(IYperfilPermissionActionsEntity entity)
        {
            var query = _query.UpdateCreate(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateRead(IYperfilPermissionActionsEntity entity)
        {
            var query = _query.UpdateRead(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUpdate(IYperfilPermissionActionsEntity entity)
        {
            var query = _query.UpdateUpdate(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDelete(IYperfilPermissionActionsEntity entity)
        {
            var query = _query.UpdateDelete(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateValidUntil(IYperfilPermissionActionsEntity entity)
        {
            var query = _query.UpdateValidUntil(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration