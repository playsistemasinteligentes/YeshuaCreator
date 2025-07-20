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
    public class PacienteReadRepository : IPacienteReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IPacienteQueryRead _query;

        public PacienteReadRepository(SqlFactory factory, ICurrentUser correntUser,IPacienteQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<PacienteDTO> getPaciente(ICommandRead command)
         {
            if (command is Command.Read.PacienteReadCommand c)
                return getPaciente(c);
            throw new NotImplementedException();
        }
        private DataPagination<PacienteDTO> getPaciente(Command.Read.PacienteReadCommand command)
        {
            var query = _query.PacienteQuery(command);

                var itens = _connection.Query<PacienteDTO>(query.Query,query.Parameters);
                return new DataPagination<PacienteDTO>(
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

        public bool ExistsByTelefone(string value)
        {
            var query = _query.ExistsByTelefoneQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataNascimento(DateTime value)
        {
            var query = _query.ExistsByDataNascimentoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGenero(int value)
        {
            var query = _query.ExistsByGeneroQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEscolaridade(string value)
        {
            var query = _query.ExistsByEscolaridadeQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByProfissao(string value)
        {
            var query = _query.ExistsByProfissaoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEndereco(string value)
        {
            var query = _query.ExistsByEnderecoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNomeResponsavel(string value)
        {
            var query = _query.ExistsByNomeResponsavelQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTelefoneResponsavel(string value)
        {
            var query = _query.ExistsByTelefoneResponsavelQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPrincipaisQueixas(string value)
        {
            var query = _query.ExistsByPrincipaisQueixasQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByObservacaoAdicional(string value)
        {
            var query = _query.ExistsByObservacaoAdicionalQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public PacienteDTO FirstById(int value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByNome(string value)
        {
            var query = _query.FirstByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByTelefone(string value)
        {
            var query = _query.FirstByTelefoneQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByDataNascimento(DateTime value)
        {
            var query = _query.FirstByDataNascimentoQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByGenero(int value)
        {
            var query = _query.FirstByGeneroQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByEscolaridade(string value)
        {
            var query = _query.FirstByEscolaridadeQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByProfissao(string value)
        {
            var query = _query.FirstByProfissaoQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByEndereco(string value)
        {
            var query = _query.FirstByEnderecoQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByNomeResponsavel(string value)
        {
            var query = _query.FirstByNomeResponsavelQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByTelefoneResponsavel(string value)
        {
            var query = _query.FirstByTelefoneResponsavelQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByPrincipaisQueixas(string value)
        {
            var query = _query.FirstByPrincipaisQueixasQuery(value);

                var result = _connection.QueryFirstOrDefault<PacienteDTO>(query.Query, query.Parameters);
                return result;
        }

        public PacienteDTO FirstByObservacaoAdicional(string value)
        {
            var query = _query.FirstByObservacaoAdicionalQuery(value);

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