using Dapper;
using Output.Querys.DisponibilidadeAgenda;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using Read.RepositoryInterfaces;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
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

                var itens = _connection.Query<DisponibilidadeAgendaDTO>(query.Query,query.Parameters);
                return new DataPagination<DisponibilidadeAgendaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<DisponibilidadeAgendaProfissionalIdDTO> getDisponibilidadeAgendaReadFKProfissionalId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<DisponibilidadeAgendaProfissionalIdDTO> lista;
            var query = new DisponibilidadeAgendaReadQuery().DisponibilidadeAgendaProfissionalIdQuery(command);

                lista = _connection.Query<DisponibilidadeAgendaProfissionalIdDTO>(query.Query,query.Parameters) as List<DisponibilidadeAgendaProfissionalIdDTO>;
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

        public bool ExistsById(int value)
        {
            var query = new DisponibilidadeAgendaReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProfissionalId(int value)
        {
            var query = new DisponibilidadeAgendaReadQuery().ExistsByProfissionalIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataHora(DateTime value)
        {
            var query = new DisponibilidadeAgendaReadQuery().ExistsByDataHoraQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public DisponibilidadeAgendaDTO FirstById(int value)
        {
            var query = new DisponibilidadeAgendaReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<DisponibilidadeAgendaDTO>(query.Query, query.Parameters);
                return result;
        }

        public DisponibilidadeAgendaDTO FirstByProfissionalId(int value)
        {
            var query = new DisponibilidadeAgendaReadQuery().FirstByProfissionalIdQuery(value);

                var result = _connection.QueryFirstOrDefault<DisponibilidadeAgendaDTO>(query.Query, query.Parameters);
                return result;
        }

        public DisponibilidadeAgendaDTO FirstByDataHora(DateTime value)
        {
            var query = new DisponibilidadeAgendaReadQuery().FirstByDataHoraQuery(value);

                var result = _connection.QueryFirstOrDefault<DisponibilidadeAgendaDTO>(query.Query, query.Parameters);
                return result;
        }

        public DisponibilidadeAgendaDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration