using Dapper;
using Output.Querys.Paciente;
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
    public class PacienteReadRepository : IPacienteReadRepository
    {
        protected readonly IDbConnection _connection;

        public PacienteReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<PacienteDTO> getPaciente(ICommandRead command)
         {
            if (command is Command.Commands.Read.PacienteReadCommand c)
                return getPaciente(c);
            throw new NotImplementedException();
        }
        private DataPagination<PacienteDTO> getPaciente(Command.Commands.Read.PacienteReadCommand command)
        {
            var query = new PacienteReadQuery().PacienteQuery(command);

                var itens = _connection.Query<PacienteDTO>(query.Query,query.Parameters);
                return new DataPagination<PacienteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsById(int value)
        {
            var query = new PacienteReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value)
        {
            var query = new PacienteReadQuery().ExistsByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTelefone(string value)
        {
            var query = new PacienteReadQuery().ExistsByTelefoneQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataNascimento(DateTime value)
        {
            var query = new PacienteReadQuery().ExistsByDataNascimentoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGenero(int value)
        {
            var query = new PacienteReadQuery().ExistsByGeneroQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEscolaridade(string value)
        {
            var query = new PacienteReadQuery().ExistsByEscolaridadeQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProfissao(string value)
        {
            var query = new PacienteReadQuery().ExistsByProfissaoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEndereco(string value)
        {
            var query = new PacienteReadQuery().ExistsByEnderecoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNomeResponsavel(string value)
        {
            var query = new PacienteReadQuery().ExistsByNomeResponsavelQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTelefoneResponsavel(string value)
        {
            var query = new PacienteReadQuery().ExistsByTelefoneResponsavelQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPrincipaisQueixas(string value)
        {
            var query = new PacienteReadQuery().ExistsByPrincipaisQueixasQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByObservacaoAdicional(string value)
        {
            var query = new PacienteReadQuery().ExistsByObservacaoAdicionalQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public PacienteDTO FirstById(int value)
        {
            var query = new PacienteReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByNome(string value)
        {
            var query = new PacienteReadQuery().FirstByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByTelefone(string value)
        {
            var query = new PacienteReadQuery().FirstByTelefoneQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByDataNascimento(DateTime value)
        {
            var query = new PacienteReadQuery().FirstByDataNascimentoQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByGenero(int value)
        {
            var query = new PacienteReadQuery().FirstByGeneroQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByEscolaridade(string value)
        {
            var query = new PacienteReadQuery().FirstByEscolaridadeQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByProfissao(string value)
        {
            var query = new PacienteReadQuery().FirstByProfissaoQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByEndereco(string value)
        {
            var query = new PacienteReadQuery().FirstByEnderecoQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByNomeResponsavel(string value)
        {
            var query = new PacienteReadQuery().FirstByNomeResponsavelQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByTelefoneResponsavel(string value)
        {
            var query = new PacienteReadQuery().FirstByTelefoneResponsavelQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByPrincipaisQueixas(string value)
        {
            var query = new PacienteReadQuery().FirstByPrincipaisQueixasQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByObservacaoAdicional(string value)
        {
            var query = new PacienteReadQuery().FirstByObservacaoAdicionalQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration