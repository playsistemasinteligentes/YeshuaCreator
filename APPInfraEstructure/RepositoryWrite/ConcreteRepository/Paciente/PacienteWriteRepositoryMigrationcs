using Dapper;
using Dominio.Entitys.Paciente;
using Input.Querys.Paciente;
using Repositorio.Inputs.Repositorio.Paciente;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Paciente
{
    public class PacienteWriteRepository : IPacienteWriteRepository
    {
        private readonly IDbConnection _Connection;

        public PacienteWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(PacienteEntity Paciente)
        {
            var query = new PacienteWriteQuery().InserirPacienteQuery(Paciente);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void InsertSmall(PacienteEntity Paciente)
        {
            throw new NotImplementedException();
        }
    }
}
