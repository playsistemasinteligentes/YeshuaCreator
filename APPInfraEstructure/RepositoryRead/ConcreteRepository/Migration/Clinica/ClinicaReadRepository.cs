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
    public class ClinicaReadRepository : IClinicaReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IClinicaQueryRead _query;

        public ClinicaReadRepository(SqlFactory factory, ICurrentUser correntUser,IClinicaQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<ClinicaDTO> getClinica(ICommandRead command )
         {
            if (command is Command.Read.ClinicaReadCommand c)
                return getClinica(c );
            throw new NotImplementedException();
        }
        private DataPagination<ClinicaDTO> getClinica(Command.Read.ClinicaReadCommand command )
        {
            var query = _query.ClinicaQuery(command );

                var itens = _connection.Query<ClinicaDTO>(query.Query,query.Parameters);
                return new DataPagination<ClinicaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ClinicaTenantIDDTO> getClinicaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ClinicaTenantIDDTO> lista;
            var query = _query.ClinicaTenantIDQuery(command );

                lista = _connection.Query<ClinicaTenantIDDTO>(query.Query,query.Parameters) as List<ClinicaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ClinicaTenantIDDTO> getClinicaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getClinicaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ClinicaUserIdDTO> getClinicaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ClinicaUserIdDTO> lista;
            var query = _query.ClinicaUserIdQuery(command );

                lista = _connection.Query<ClinicaUserIdDTO>(query.Query,query.Parameters) as List<ClinicaUserIdDTO>;
            return lista;
        }

        public IEnumerable<ClinicaUserIdDTO> getClinicaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getClinicaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value )
        {
            var query = _query.ExistsByNomeQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEndereco(string value )
        {
            var query = _query.ExistsByEnderecoQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTelefone(string value )
        {
            var query = _query.ExistsByTelefoneQuery(value );

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

        public ClinicaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO FirstByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO FirstByEndereco(string value )
        {
            var query = _query.FirstByEnderecoQuery(value );

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO FirstByTelefone(string value )
        {
            var query = _query.FirstByTelefoneQuery(value );

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ClinicaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<ClinicaDTO>(query.Query,query.Parameters) as List<ClinicaDTO>;
                return result;
        }

        public IEnumerable<ClinicaDTO> GetAllByNome(string value )
        {
            var query = _query.FirstByNomeQuery(value );

                var result = _connection.Query<ClinicaDTO>(query.Query,query.Parameters) as List<ClinicaDTO>;
                return result;
        }

        public IEnumerable<ClinicaDTO> GetAllByEndereco(string value )
        {
            var query = _query.FirstByEnderecoQuery(value );

                var result = _connection.Query<ClinicaDTO>(query.Query,query.Parameters) as List<ClinicaDTO>;
                return result;
        }

        public IEnumerable<ClinicaDTO> GetAllByTelefone(string value )
        {
            var query = _query.FirstByTelefoneQuery(value );

                var result = _connection.Query<ClinicaDTO>(query.Query,query.Parameters) as List<ClinicaDTO>;
                return result;
        }

        public IEnumerable<ClinicaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<ClinicaDTO>(query.Query,query.Parameters) as List<ClinicaDTO>;
                return result;
        }

        public IEnumerable<ClinicaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<ClinicaDTO>(query.Query,query.Parameters) as List<ClinicaDTO>;
                return result;
        }

        public IEnumerable<ClinicaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<ClinicaDTO>(query.Query,query.Parameters) as List<ClinicaDTO>;
                return result;
        }

        public IEnumerable<ClinicaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<ClinicaDTO>(query.Query,query.Parameters) as List<ClinicaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration