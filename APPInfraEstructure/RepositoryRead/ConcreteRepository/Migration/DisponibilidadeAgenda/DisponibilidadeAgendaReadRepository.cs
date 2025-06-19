using Dapper;
using Output.Querys.DisponibilidadeAgenda;
using Repositorio.Outputs.DTOs.DisponibilidadeAgenda;
using RepositoryInterfaces.Read.Repository.DisponibilidadeAgenda;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
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

        public DataPagination<DisponibilidadeAgendaDTO> getDisponibilidadeAgenda(ICommandRead command)
         {
            if (command is Command.Commands.Read.DisponibilidadeAgendaReadCommand c)
                return getDisponibilidadeAgenda(c);
            throw new NotImplementedException();
        }
        private DataPagination<DisponibilidadeAgendaDTO> getDisponibilidadeAgenda(Command.Commands.Read.DisponibilidadeAgendaReadCommand command)
        {
            var query = new DisponibilidadeAgendaReadQuery().DisponibilidadeAgendaQuery(command);

            using (_connection)
            {
                var itens = _connection.Query<DisponibilidadeAgendaDTO>(query.Query,query.Parameters);
                return new DataPagination<DisponibilidadeAgendaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
            }
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