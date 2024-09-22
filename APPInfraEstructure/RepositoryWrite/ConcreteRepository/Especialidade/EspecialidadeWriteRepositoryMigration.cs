using Dapper;
using Dominio.Entitys.Especialidade;
using Input.Querys.Especialidade;
using Repositorio.Inputs.Repositorio.Especialidade;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Especialidade
{
    public class EspecialidadeWriteRepository : IEspecialidadeWriteRepository
    {
        private readonly IDbConnection _Connection;

        public EspecialidadeWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(EspecialidadeEntity Especialidade)
        {
            var query = new EspecialidadeWriteQuery().InserirEspecialidadeQuery(Especialidade);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void InsertSmall(EspecialidadeEntity Especialidade)
        {
            throw new NotImplementedException();
        }
    }
}
