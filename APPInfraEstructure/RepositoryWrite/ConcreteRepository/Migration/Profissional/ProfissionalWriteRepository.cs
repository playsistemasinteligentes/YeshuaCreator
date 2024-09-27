using Dapper;
using Dominio.Entitys.Profissional;
using Input.Querys.Profissional;
using Repositorio.Inputs.Repositorio.Profissional;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Profissional
{
    public class ProfissionalWriteRepository : IProfissionalWriteRepository
    {
        private readonly IDbConnection _Connection;

        public ProfissionalWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(ProfissionalEntity Profissional)
        {
            var query = new ProfissionalWriteQuery().InserirProfissionalQuery(Profissional);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void InsertSmall(ProfissionalEntity Profissional)
        {
            throw new NotImplementedException();
        }
    }
}
