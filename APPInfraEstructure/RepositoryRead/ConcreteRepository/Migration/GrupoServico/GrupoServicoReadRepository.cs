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
    public class GrupoServicoReadRepository : IGrupoServicoReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IGrupoServicoQueryRead _query;

        public GrupoServicoReadRepository(SqlFactory factory, ICurrentUser correntUser,IGrupoServicoQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<GrupoServicoDTO> getGrupoServico(ICommandRead command)
         {
            if (command is Command.Read.GrupoServicoReadCommand c)
                return getGrupoServico(c);
            throw new NotImplementedException();
        }
        private DataPagination<GrupoServicoDTO> getGrupoServico(Command.Read.GrupoServicoReadCommand command)
        {
            var query = _query.GrupoServicoQuery(command);

                var itens = _connection.Query<GrupoServicoDTO>(query.Query,query.Parameters);
                return new DataPagination<GrupoServicoDTO>(
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

        public bool ExistsByDescricao(string value)
        {
            var query = _query.ExistsByDescricaoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public GrupoServicoDTO FirstById(int value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<GrupoServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoServicoDTO FirstByDescricao(string value)
        {
            var query = _query.FirstByDescricaoQuery(value);

                var result = _connection.QueryFirstOrDefault<GrupoServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoServicoDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration