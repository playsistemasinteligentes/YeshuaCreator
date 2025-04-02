using Dapper;
using Dominio.Entitys.Y_User;
using Input.Querys.Y_User;
using Repositorio.Inputs.Repositorio.Y_User;
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
        private readonly IDbConnection _Connection;

        public Y_UserWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(Y_UserEntity Y_User)
        {
            var query = new Y_UserWriteQuery().InserirY_UserQuery(Y_User);
        Y_User.Id =  _Connection.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(Y_UserEntity Y_User)
        {
            var query = new Y_UserWriteQuery().UpdateY_UserQuery(Y_User);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
        public void Delete(Y_UserEntity Y_User)
        {
            var query = new Y_UserWriteQuery().DeleteY_UserQuery(Y_User);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration