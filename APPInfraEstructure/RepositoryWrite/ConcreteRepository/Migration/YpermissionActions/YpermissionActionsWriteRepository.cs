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

namespace Input.Repository.YpermissionActions
{
    public class YpermissionActionsWriteRepository : IYpermissionActionsWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IYpermissionActionsQueryWrite _query; 

        public YpermissionActionsWriteRepository(IUnitOfWork unitOfWork,IYpermissionActionsQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IYpermissionActionsEntity YpermissionActions)
        {
            var query = _query.InserirYpermissionActionsQuery(YpermissionActions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYpermissionActionsEntity YpermissionActions)
        {
            var query = _query.UpdateYpermissionActionsQuery(YpermissionActions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYpermissionActionsEntity YpermissionActions)
        {
            var query = _query.DeleteYpermissionActionsQuery(YpermissionActions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDescription(IYpermissionActionsEntity entity)
        {
            var query = _query.UpdateDescription(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration