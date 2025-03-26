using Dapper;
using Dominio.Entitys.Y_Permtions;
using Input.Querys.Y_Permtions;
using Repositorio.Inputs.Repositorio.Y_Permtions;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Y_Permtions
{
    public class Y_PermtionsWriteRepository : IY_PermtionsWriteRepository
    {
        private readonly IDbConnection _Connection;

        public Y_PermtionsWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(Y_PermtionsEntity Y_Permtions)
        {
            var query = new Y_PermtionsWriteQuery().InserirY_PermtionsQuery(Y_Permtions);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void Update(Y_PermtionsEntity Y_Permtions)
        {
            var query = new Y_PermtionsWriteQuery().UpdateY_PermtionsQuery(Y_Permtions);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
        public void Delete(Y_PermtionsEntity Y_Permtions)
        {
            var query = new Y_PermtionsWriteQuery().DeleteY_PermtionsQuery(Y_Permtions);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration