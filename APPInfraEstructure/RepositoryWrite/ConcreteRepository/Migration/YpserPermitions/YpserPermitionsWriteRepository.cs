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

namespace Input.Repository.YpserPermitions
{
    public class YpserPermitionsWriteRepository : IYpserPermitionsWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IYpserPermitionsQueryWrite _query; 

        public YpserPermitionsWriteRepository(IUnitOfWork unitOfWork,IYpserPermitionsQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IYpserPermitionsEntity YpserPermitions)
        {
            var query = _query.InserirYpserPermitionsQuery(YpserPermitions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYpserPermitionsEntity YpserPermitions)
        {
            var query = _query.UpdateYpserPermitionsQuery(YpserPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYpserPermitionsEntity YpserPermitions)
        {
            var query = _query.DeleteYpserPermitionsQuery(YpserPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserId(IYpserPermitionsEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePermitionsId(IYpserPermitionsEntity entity)
        {
            var query = _query.UpdatePermitionsId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration