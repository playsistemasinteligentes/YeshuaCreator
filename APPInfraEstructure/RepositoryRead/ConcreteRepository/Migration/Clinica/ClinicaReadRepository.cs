using Dapper;
using Output.Querys.Clinica;
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
    public class ClinicaReadRepository : IClinicaReadRepository
    {
        protected readonly IDbConnection _connection;

        public ClinicaReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<ClinicaDTO> getClinica(ICommandRead command)
         {
            if (command is Command.Commands.Read.ClinicaReadCommand c)
                return getClinica(c);
            throw new NotImplementedException();
        }
        private DataPagination<ClinicaDTO> getClinica(Command.Commands.Read.ClinicaReadCommand command)
        {
            var query = new ClinicaReadQuery().ClinicaQuery(command);

                var itens = _connection.Query<ClinicaDTO>(query.Query,query.Parameters);
                return new DataPagination<ClinicaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsById(int value)
        {
            var query = new ClinicaReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value)
        {
            var query = new ClinicaReadQuery().ExistsByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEndereco(string value)
        {
            var query = new ClinicaReadQuery().ExistsByEnderecoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTelefone(string value)
        {
            var query = new ClinicaReadQuery().ExistsByTelefoneQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public ClinicaDTO FirstById(int value)
        {
            var query = new ClinicaReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO FirstByNome(string value)
        {
            var query = new ClinicaReadQuery().FirstByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO FirstByEndereco(string value)
        {
            var query = new ClinicaReadQuery().FirstByEnderecoQuery(value);

                var result = _connection.QueryFirstOrDefault<ClinicaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ClinicaDTO FirstByTelefone(string value)
        {
            var query = new ClinicaReadQuery().FirstByTelefoneQuery(value);

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