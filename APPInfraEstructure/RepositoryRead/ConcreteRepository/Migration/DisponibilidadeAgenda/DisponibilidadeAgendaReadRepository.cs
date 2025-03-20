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

        public IEnumerable<DisponibilidadeAgendaDTO> getDisponibilidadeAgenda(object command)
         {
            if (command is Command.Commands.Read.DisponibilidadeAgendaReadCommand c)
            {
                return getDisponibilidadeAgenda(c);
            }
            throw new NotImplementedException();
        }
        private IEnumerable<DisponibilidadeAgendaDTO> getDisponibilidadeAgenda(Command.Commands.Read.DisponibilidadeAgendaReadCommand command)
        {
            List<DisponibilidadeAgendaDTO> lista;
            var query = new DisponibilidadeAgendaReadQuery().DisponibilidadeAgendaQuery(command);

            using (_connection)
            {
                lista = _connection.Query<DisponibilidadeAgendaDTO>(query.Query,query.Parameters) as List<DisponibilidadeAgendaDTO>;
            }
            return lista;
        }

        private IEnumerable<DisponibilidadeAgendaProfissionalIdDTO> getDisponibilidadeAgendaReadFKProfissionalId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<DisponibilidadeAgendaProfissionalIdDTO> lista;
            var query = new DisponibilidadeAgendaReadQuery().DisponibilidadeAgendaProfissionalIdQuery(command);

            using (_connection)
            {
                lista = _connection.Query<DisponibilidadeAgendaProfissionalIdDTO>(query.Query,query.Parameters) as List<DisponibilidadeAgendaProfissionalIdDTO>;
            }
            return lista;
        }

        public IEnumerable<DisponibilidadeAgendaProfissionalIdDTO> getDisponibilidadeAgendaReadFKProfissionalId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getDisponibilidadeAgendaReadFKProfissionalId(c);
            }
            throw new NotImplementedException();
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