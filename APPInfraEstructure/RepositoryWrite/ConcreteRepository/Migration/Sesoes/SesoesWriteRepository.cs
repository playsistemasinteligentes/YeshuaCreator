using Dapper;
using Dominio.Entitys.Sesoes;
using Input.Querys.Sesoes;
using Repositorio.Inputs.Repositorio.Sesoes;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Sesoes
{
    public class SesoesWriteRepository : ISesoesWriteRepository
    {
        private readonly IDbConnection _Connection;

        public SesoesWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(SesoesEntity Sesoes)
        {
            var query = new SesoesWriteQuery().InserirSesoesQuery(Sesoes);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void Update(SesoesEntity Sesoes)
        {
            var query = new SesoesWriteQuery().UpdateSesoesQuery(Sesoes);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
        public void Delete(SesoesEntity Sesoes)
        {
            var query = new SesoesWriteQuery().DeleteSesoesQuery(Sesoes);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
    }
}
