using Dapper;
using Dominio.Entitys;
using Input.Querys.Y_UserPermitions;
using Repositorio.Inputs.Repositorio.Y_UserPermitions;
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

        public void Insert(Y_UserPermitionsEntity Y_UserPermitions)
        {
            var query = new Y_UserPermitionsWriteQuery().InserirY_UserPermitionsQuery(Y_UserPermitions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }

        public void Update(Y_UserPermitionsEntity Y_UserPermitions)
        {
            var query = new Y_UserPermitionsWriteQuery().UpdateY_UserPermitionsQuery(Y_UserPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
        public void Delete(Y_UserPermitionsEntity Y_UserPermitions)
        {
            var query = new Y_UserPermitionsWriteQuery().DeleteY_UserPermitionsQuery(Y_UserPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration