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

        public DataPagination<ClinicaDTO> getClinica(ICommandRead command)
         {
            if (command is Command.Read.ClinicaReadCommand c)
                return getClinica(c);
            throw new NotImplementedException();
        }
        private DataPagination<ClinicaDTO> getClinica(Command.Read.ClinicaReadCommand command)
        {
            var query = _query.ClinicaQuery(command);

                var itens = _connection.Query<ClinicaDTO>(query.Query,query.Parameters);
                return new DataPagination<ClinicaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsById(int value)
        {
            var query = _query.ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value)
        {
            var query = _query.ExistsByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEndereco(string value)
        {
            var query = _query.ExistsByEnderecoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTelefone(string value)
        {
            var query = _query.ExistsByTelefoneQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public ClinicaDTO FirstById(int value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO FirstByNome(string value)
        {
            var query = _query.FirstByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO FirstByEndereco(string value)
        {
            var query = _query.FirstByEnderecoQuery(value);

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO FirstByTelefone(string value)
        {
            var query = _query.FirstByTelefoneQuery(value);

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration