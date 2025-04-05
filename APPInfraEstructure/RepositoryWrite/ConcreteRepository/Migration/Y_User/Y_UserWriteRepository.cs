using Dapper;
using Dominio.Entitys.Y_User;
using Input.Querys.Y_User;
using Repositorio.Inputs.Repositorio.Y_User;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Y_User
{
    public class Y_UserWriteRepository : IY_UserWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public Y_UserWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(Y_UserEntity Y_User)
        {
            var query = new Y_UserWriteQuery().InserirY_UserQuery(Y_User);
        Y_User.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(Y_UserEntity Y_User)
        {
            var query = new Y_UserWriteQuery().UpdateY_UserQuery(Y_User);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
        public void Delete(Y_UserEntity Y_User)
        {
            var query = new Y_UserWriteQuery().DeleteY_UserQuery(Y_User);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration