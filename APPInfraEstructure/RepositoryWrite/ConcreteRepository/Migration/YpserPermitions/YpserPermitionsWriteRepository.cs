using Dapper;
using Dominio.Entitys;
using Input.Querys.YpserPermitions;
using Repositorio.Inputs.Repositorio.YpserPermitions;
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

        public YpserPermitionsWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IYpserPermitionsEntity YpserPermitions)
        {
            var query = new YpserPermitionsWriteQuery().InserirYpserPermitionsQuery(YpserPermitions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYpserPermitionsEntity YpserPermitions)
        {
            var query = new YpserPermitionsWriteQuery().UpdateYpserPermitionsQuery(YpserPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYpserPermitionsEntity YpserPermitions)
        {
            var query = new YpserPermitionsWriteQuery().DeleteYpserPermitionsQuery(YpserPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserId(IYpserPermitionsEntity entity)
        {
            var query = new YpserPermitionsWriteQuery().UpdateUserId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePermitionsId(IYpserPermitionsEntity entity)
        {
            var query = new YpserPermitionsWriteQuery().UpdatePermitionsId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration