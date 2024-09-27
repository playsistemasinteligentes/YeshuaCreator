using Dapper;
using Dominio.Entitys.Agendamentos;
using Input.Querys.Agendamentos;
using Repositorio.Inputs.Repositorio.Agendamentos;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Agendamentos
{
    public class AgendamentosWriteRepository : IAgendamentosWriteRepository
    {
        private readonly IDbConnection _Connection;

        public AgendamentosWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(AgendamentosEntity Agendamentos)
        {
            var query = new AgendamentosWriteQuery().InserirAgendamentosQuery(Agendamentos);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void InsertSmall(AgendamentosEntity Agendamentos)
        {
            throw new NotImplementedException();
        }
    }
}
