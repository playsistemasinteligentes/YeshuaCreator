using Dapper;
using Dominio.Entitys.DisponibilidadeAgenda;
using Input.Querys.DisponibilidadeAgenda;
using Repositorio.Inputs.Repositorio.DisponibilidadeAgenda;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.DisponibilidadeAgenda
{
    public class DisponibilidadeAgendaWriteRepository : IDisponibilidadeAgendaWriteRepository
    {
        private readonly IDbConnection _Connection;

        public DisponibilidadeAgendaWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(DisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = new DisponibilidadeAgendaWriteQuery().InserirDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void Update(DisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = new DisponibilidadeAgendaWriteQuery().UpdateDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
        public void Delete(DisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = new DisponibilidadeAgendaWriteQuery().DeleteDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration