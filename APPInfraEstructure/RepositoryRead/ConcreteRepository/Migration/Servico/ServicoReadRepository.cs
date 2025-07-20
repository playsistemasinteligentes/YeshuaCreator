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
    public class ServicoReadRepository : IServicoReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _correntUser;
       protected readonly IServicoQueryRead _query;

        public ServicoReadRepository(SqlFactory factory, ICurrentUser correntUser,IServicoQueryRead query)
        {
            _connection = factory.SqlConnection();
            _correntUser = correntUser;
            _query = query;
        }

        public DataPagination<ServicoDTO> getServico(ICommandRead command)
         {
            if (command is Command.Read.ServicoReadCommand c)
                return getServico(c);
            throw new NotImplementedException();
        }
        private DataPagination<ServicoDTO> getServico(Command.Read.ServicoReadCommand command)
        {
            var query = _query.ServicoQuery(command);

                var itens = _connection.Query<ServicoDTO>(query.Query,query.Parameters);
                return new DataPagination<ServicoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ServicoGrupoServicoIdDTO> getServicoReadFKGrupoServicoId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<ServicoGrupoServicoIdDTO> lista;
            var query = _query.ServicoGrupoServicoIdQuery(command);

                lista = _connection.Query<ServicoGrupoServicoIdDTO>(query.Query,query.Parameters) as List<ServicoGrupoServicoIdDTO>;
            return lista;
        }

        public IEnumerable<ServicoGrupoServicoIdDTO> getServicoReadFKGrupoServicoId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getServicoReadFKGrupoServicoId(c);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value)
        {
            var query = _query.ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGrupoServicoId(int value)
        {
            var query = _query.ExistsByGrupoServicoIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value)
        {
            var query = _query.ExistsByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValor(Decimal value)
        {
            var query = _query.ExistsByValorQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public ServicoDTO FirstById(int value)
        {
            var query = _query.FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO FirstByGrupoServicoId(int value)
        {
            var query = _query.FirstByGrupoServicoIdQuery(value);

                var result = _connection.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO FirstByNome(string value)
        {
            var query = _query.FirstByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO FirstByValor(Decimal value)
        {
            var query = _query.FirstByValorQuery(value);

                var result = _connection.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration