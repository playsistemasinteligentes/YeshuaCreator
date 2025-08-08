using Dapper;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using IRepository.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
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
        protected readonly ICurrentUser _correntUser;
       protected readonly IDisponibilidadeAgendaQueryRead _query;

        public DisponibilidadeAgendaReadRepository(SqlFactory factory, ICurrentUser correntUser,IDisponibilidadeAgendaQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<DisponibilidadeAgendaDTO> getDisponibilidadeAgenda(ICommandRead command )
         {
            if (command is Command.Read.DisponibilidadeAgendaReadCommand c)
                return getDisponibilidadeAgenda(c );
            throw new NotImplementedException();
        }
        private DataPagination<DisponibilidadeAgendaDTO> getDisponibilidadeAgenda(Command.Read.DisponibilidadeAgendaReadCommand command )
        {
            var query = _query.DisponibilidadeAgendaQuery(command );

                var itens = _connection.Query<DisponibilidadeAgendaDTO>(query.Query,query.Parameters);
                return new DataPagination<DisponibilidadeAgendaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<DisponibilidadeAgendaProfissionalIdDTO> getDisponibilidadeAgendaReadFKProfissionalId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<DisponibilidadeAgendaProfissionalIdDTO> lista;
            var query = _query.DisponibilidadeAgendaProfissionalIdQuery(command );

                lista = _connection.Query<DisponibilidadeAgendaProfissionalIdDTO>(query.Query,query.Parameters) as List<DisponibilidadeAgendaProfissionalIdDTO>;
            return lista;
        }

        public IEnumerable<DisponibilidadeAgendaProfissionalIdDTO> getDisponibilidadeAgendaReadFKProfissionalId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getDisponibilidadeAgendaReadFKProfissionalId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<DisponibilidadeAgendaTenantIDDTO> getDisponibilidadeAgendaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<DisponibilidadeAgendaTenantIDDTO> lista;
            var query = _query.DisponibilidadeAgendaTenantIDQuery(command );

                lista = _connection.Query<DisponibilidadeAgendaTenantIDDTO>(query.Query,query.Parameters) as List<DisponibilidadeAgendaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<DisponibilidadeAgendaTenantIDDTO> getDisponibilidadeAgendaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getDisponibilidadeAgendaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<DisponibilidadeAgendaUserIdDTO> getDisponibilidadeAgendaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<DisponibilidadeAgendaUserIdDTO> lista;
            var query = _query.DisponibilidadeAgendaUserIdQuery(command );

                lista = _connection.Query<DisponibilidadeAgendaUserIdDTO>(query.Query,query.Parameters) as List<DisponibilidadeAgendaUserIdDTO>;
            return lista;
        }

        public IEnumerable<DisponibilidadeAgendaUserIdDTO> getDisponibilidadeAgendaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getDisponibilidadeAgendaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProfissionalId(int value )
        {
            var query = _query.ExistsByProfissionalIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataHora(DateTime value )
        {
            var query = _query.ExistsByDataHoraQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value )
        {
            var query = _query.ExistsByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value )
        {
            var query = _query.ExistsByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value )
        {
            var query = _query.ExistsByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public DisponibilidadeAgendaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<DisponibilidadeAgendaDTO>(query.Query, query.Parameters);
                return result;
        }

        public DisponibilidadeAgendaDTO FirstByProfissionalId(int value )
        {
            var query = _query.FirstByProfissionalIdQuery(value );

                var result = _connection.QueryFirstOrDefault<DisponibilidadeAgendaDTO>(query.Query, query.Parameters);
                return result;
        }

        public DisponibilidadeAgendaDTO FirstByDataHora(DateTime value )
        {
            var query = _query.FirstByDataHoraQuery(value );

                var result = _connection.QueryFirstOrDefault<DisponibilidadeAgendaDTO>(query.Query, query.Parameters);
                return result;
        }

        public DisponibilidadeAgendaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<DisponibilidadeAgendaDTO>(query.Query, query.Parameters);
                return result;
        }

        public DisponibilidadeAgendaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<DisponibilidadeAgendaDTO>(query.Query, query.Parameters);
                return result;
        }

        public DisponibilidadeAgendaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<DisponibilidadeAgendaDTO>(query.Query, query.Parameters);
                return result;
        }

        public DisponibilidadeAgendaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<DisponibilidadeAgendaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<DisponibilidadeAgendaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<DisponibilidadeAgendaDTO>(query.Query,query.Parameters) as List<DisponibilidadeAgendaDTO>;
                return result;
        }

        public IEnumerable<DisponibilidadeAgendaDTO> GetAllByProfissionalId(int value )
        {
            var query = _query.FirstByProfissionalIdQuery(value );

                var result = _connection.Query<DisponibilidadeAgendaDTO>(query.Query,query.Parameters) as List<DisponibilidadeAgendaDTO>;
                return result;
        }

        public IEnumerable<DisponibilidadeAgendaDTO> GetAllByDataHora(DateTime value )
        {
            var query = _query.FirstByDataHoraQuery(value );

                var result = _connection.Query<DisponibilidadeAgendaDTO>(query.Query,query.Parameters) as List<DisponibilidadeAgendaDTO>;
                return result;
        }

        public IEnumerable<DisponibilidadeAgendaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<DisponibilidadeAgendaDTO>(query.Query,query.Parameters) as List<DisponibilidadeAgendaDTO>;
                return result;
        }

        public IEnumerable<DisponibilidadeAgendaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<DisponibilidadeAgendaDTO>(query.Query,query.Parameters) as List<DisponibilidadeAgendaDTO>;
                return result;
        }

        public IEnumerable<DisponibilidadeAgendaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<DisponibilidadeAgendaDTO>(query.Query,query.Parameters) as List<DisponibilidadeAgendaDTO>;
                return result;
        }

        public IEnumerable<DisponibilidadeAgendaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<DisponibilidadeAgendaDTO>(query.Query,query.Parameters) as List<DisponibilidadeAgendaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration