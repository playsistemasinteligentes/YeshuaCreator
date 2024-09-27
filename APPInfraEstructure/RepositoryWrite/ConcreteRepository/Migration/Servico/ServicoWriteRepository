using Dapper;
using Dominio.Entitys.Servico;
using Input.Querys.Servico;
using Repositorio.Inputs.Repositorio.Servico;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Servico
{
    public class ServicoWriteRepository : IServicoWriteRepository
    {
        private readonly IDbConnection _Connection;

        public ServicoWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(ServicoEntity Servico)
        {
            var query = new ServicoWriteQuery().InserirServicoQuery(Servico);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void InsertSmall(ServicoEntity Servico)
        {
            throw new NotImplementedException();
        }
    }
}
