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
    public class ProfissionalReadRepository : IProfissionalReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IProfissionalQueryRead _query;

        public ProfissionalReadRepository(SqlFactory factory, ICurrentUser correntUser,IProfissionalQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<ProfissionalDTO> getProfissional(ICommandRead command)
         {
            if (command is Command.Read.ProfissionalReadCommand c)
                return getProfissional(c);
            throw new NotImplementedException();
        }
        private DataPagination<ProfissionalDTO> getProfissional(Command.Read.ProfissionalReadCommand command)
        {
            var query = _query.ProfissionalQuery(command);

                var itens = _connection.Query<ProfissionalDTO>(query.Query,query.Parameters);
                return new DataPagination<ProfissionalDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ProfissionalEspecialidadeIdDTO> getProfissionalReadFKEspecialidadeId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<ProfissionalEspecialidadeIdDTO> lista;
            var query = _query.ProfissionalEspecialidadeIdQuery(command);

                lista = _connection.Query<ProfissionalEspecialidadeIdDTO>(query.Query,query.Parameters) as List<ProfissionalEspecialidadeIdDTO>;
            return lista;
        }

        public IEnumerable<ProfissionalEspecialidadeIdDTO> getProfissionalReadFKEspecialidadeId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProfissionalReadFKEspecialidadeId(c);
            }
            throw new NotImplementedException();
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

        public bool ExistsByEspecialidadeId(int value)
        {
            var query = _query.ExistsByEspecialidadeIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTelefone(string value)
        {
            var query = _query.ExistsByTelefoneQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public ProfissionalDTO FirstById(int value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<ProfissionalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProfissionalDTO FirstByNome(string value)
        {
            var query = _query.FirstByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<ProfissionalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProfissionalDTO FirstByEspecialidadeId(int value)
        {
            var query = _query.FirstByEspecialidadeIdQuery(value);

                var result = _connection.QueryFirstOrDefault<ProfissionalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProfissionalDTO FirstByTelefone(string value)
        {
            var query = _query.FirstByTelefoneQuery(value);

                var result = _connection.QueryFirstOrDefault<ProfissionalDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProfissionalDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration