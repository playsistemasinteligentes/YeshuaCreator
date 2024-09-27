using Dapper;
using Dominio.Entitys.Clinica;
using Input.Querys.Clinica;
using Repositorio.Inputs.Repositorio.Clinica;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Clinica
{
    public class ClinicaWriteRepository : IClinicaWriteRepository
    {
        private readonly IDbConnection _Connection;

        public ClinicaWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(ClinicaEntity Clinica)
        {
            var query = new ClinicaWriteQuery().InserirClinicaQuery(Clinica);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void InsertSmall(ClinicaEntity Clinica)
        {
            throw new NotImplementedException();
        }
    }
}
