using Dapper;
using Dominio.Entitys.Atendimento;
using Input.Querys.Atendimento;
using Repositorio.Inputs.Repositorio.Atendimento;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Atendimento
{
    public class AtendimentoWriteRepository : IAtendimentoWriteRepository
    {
        private readonly IDbConnection _Connection;

        public AtendimentoWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(AtendimentoEntity Atendimento)
        {
            var query = new AtendimentoWriteQuery().InserirAtendimentoQuery(Atendimento);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void InsertSmall(AtendimentoEntity Atendimento)
        {
            throw new NotImplementedException();
        }
    }
}
