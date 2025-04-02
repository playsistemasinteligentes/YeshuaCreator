using Dapper;
using Dominio.Entitys.Y_UserPermitions;
using Input.Querys.Y_UserPermitions;
using Repositorio.Inputs.Repositorio.Y_UserPermitions;
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
        private readonly IDbConnection _Connection;

        public Y_UserPermitionsWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(Y_UserPermitionsEntity Y_UserPermitions)
        {
            var query = new Y_UserPermitionsWriteQuery().InserirY_UserPermitionsQuery(Y_UserPermitions);
                _Connection.Execute(query.Query, query.Parameters);
        }

        public void Update(Y_UserPermitionsEntity Y_UserPermitions)
        {
            var query = new Y_UserPermitionsWriteQuery().UpdateY_UserPermitionsQuery(Y_UserPermitions);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
        public void Delete(Y_UserPermitionsEntity Y_UserPermitions)
        {
            var query = new Y_UserPermitionsWriteQuery().DeleteY_UserPermitionsQuery(Y_UserPermitions);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration