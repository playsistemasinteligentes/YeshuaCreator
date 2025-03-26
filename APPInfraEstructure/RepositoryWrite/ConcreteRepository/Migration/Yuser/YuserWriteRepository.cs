using Dapper;
using Dominio.Entitys.Yuser;
using Input.Querys.Yuser;
using Repositorio.Inputs.Repositorio.Yuser;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Yuser
{
    public class YuserWriteRepository : IYuserWriteRepository
    {
        private readonly IDbConnection _Connection;

        public YuserWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(YuserEntity Yuser)
        {
            var query = new YuserWriteQuery().InserirYuserQuery(Yuser);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void Update(YuserEntity Yuser)
        {
            var query = new YuserWriteQuery().UpdateYuserQuery(Yuser);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
        public void Delete(YuserEntity Yuser)
        {
            var query = new YuserWriteQuery().DeleteYuserQuery(Yuser);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration