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

namespace Input.Repository.YuserPermitions
{
    public class YuserPermitionsWriteRepository : IYuserPermitionsWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IYuserPermitionsQueryWrite _query; 

        public YuserPermitionsWriteRepository(IUnitOfWork unitOfWork,IYuserPermitionsQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IYuserPermitionsEntity YuserPermitions)
        {
            var query = _query.InserirYuserPermitionsQuery(YuserPermitions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYuserPermitionsEntity YuserPermitions)
        {
            var query = _query.UpdateYuserPermitionsQuery(YuserPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYuserPermitionsEntity YuserPermitions)
        {
            var query = _query.DeleteYuserPermitionsQuery(YuserPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePermitionsId(IYuserPermitionsEntity entity)
        {
            var query = _query.UpdatePermitionsId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserId(IYuserPermitionsEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration