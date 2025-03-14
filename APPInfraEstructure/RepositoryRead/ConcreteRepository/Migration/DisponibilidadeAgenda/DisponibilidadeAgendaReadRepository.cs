using Dapper;
using Output.Querys.DisponibilidadeAgenda;
using Repositorio.Outputs.DTOs.DisponibilidadeAgenda;
using RepositoryInterfaces.Read.Repository.DisponibilidadeAgenda;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.DisponibilidadeAgenda
{
    public class DisponibilidadeAgendaReadRepository : IDisponibilidadeAgendaReadRepository
    {
        protected readonly IDbConnection _connection;

        public DisponibilidadeAgendaReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<DisponibilidadeAgendaReadDTO> getDisponibilidadeAgenda(object command)
        {
            List<DisponibilidadeAgendaDTO> lista;
            var query = new DisponibilidadeAgendaReadQuery().SelectAllDisponibilidadeAgendaQuery();

            using (_connection)
            {
                lista = _connection.Query<DisponibilidadeAgendaDTO>(query.Query) as List<DisponibilidadeAgendaDTO>;
            }
            return lista;
        }

        public IEnumerable<DisponibilidadeAgendaDTO> getDisponibilidadeAgendaReadFKProfissionalId(object command)
        {
            List<DisponibilidadeAgendaDTO> lista;
            var query = new DisponibilidadeAgendaReadQuery().SelectAllDisponibilidadeAgendaQuery();

            using (_connection)
            {
                lista = _connection.Query<DisponibilidadeAgendaDTO>(query.Query) as List<DisponibilidadeAgendaDTO>;
            }
            return lista;
        }

        public DisponibilidadeAgendaDTO getById()
        {
            throw new NotImplementedException();
        }
        public DisponibilidadeAgendaDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration