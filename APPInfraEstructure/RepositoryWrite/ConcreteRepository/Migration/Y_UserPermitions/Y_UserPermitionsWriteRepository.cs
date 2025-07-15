using Dapper;
using Dominio.Entitys;
using Input.Querys.Y_UserPermitions;
using Repositorio.Inputs.Repositorio.Y_UserPermitions;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Y_UserPermitions
{
    public class Y_UserPermitionsWriteRepository : IY_UserPermitionsWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public Y_UserPermitionsWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IY_UserPermitionsEntity Y_UserPermitions)
        {
            var query = new Y_UserPermitionsWriteQuery().InserirY_UserPermitionsQuery(Y_UserPermitions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IY_UserPermitionsEntity Y_UserPermitions)
        {
            var query = new Y_UserPermitionsWriteQuery().UpdateY_UserPermitionsQuery(Y_UserPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IY_UserPermitionsEntity Y_UserPermitions)
        {
            var query = new Y_UserPermitionsWriteQuery().DeleteY_UserPermitionsQuery(Y_UserPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserId(IY_UserPermitionsEntity entity)
        {
            var query = new Y_UserPermitionsWriteQuery().UpdateUserId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePermitionsId(IY_UserPermitionsEntity entity)
        {
            var query = new Y_UserPermitionsWriteQuery().UpdatePermitionsId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration