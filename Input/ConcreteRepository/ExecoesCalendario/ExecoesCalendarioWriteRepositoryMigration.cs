using Dapper;
using Dominio.Entitys.ExecoesCalendario;
using Input.Querys.ExecoesCalendario;
using Repositorio.Inputs.Repositorio.ExecoesCalendario;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.ExecoesCalendario
{
    public class ExecoesCalendarioWriteRepository : IExecoesCalendarioWriteRepository
    {
        private readonly IDbConnection _Connection;

        public ExecoesCalendarioWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(ExecoesCalendarioEntity ExecoesCalendario)
        {
            var query = new ExecoesCalendarioWriteQuery().InserirExecoesCalendarioQuery(ExecoesCalendario);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void InsertSmall(ExecoesCalendarioEntity ExecoesCalendario)
        {
            throw new NotImplementedException();
        }
    }
}
