using Dapper;
using Output.Querys.Servico;
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
    public class ServicoReadRepository : IServicoReadRepository
    {
        protected readonly IDbConnection _connection;

        public ServicoReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<ServicoDTO> getServico(ICommandRead command)
         {
            if (command is Command.Commands.Read.ServicoReadCommand c)
                return getServico(c);
            throw new NotImplementedException();
        }
        private DataPagination<ServicoDTO> getServico(Command.Commands.Read.ServicoReadCommand command)
        {
            var query = new ServicoReadQuery().ServicoQuery(command);

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
            var query = new ServicoReadQuery().ServicoGrupoServicoIdQuery(command);

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
            var query = new ServicoReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGrupoServicoId(int value)
        {
            var query = new ServicoReadQuery().ExistsByGrupoServicoIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNome(string value)
        {
            var query = new ServicoReadQuery().ExistsByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValor(Decimal value)
        {
            var query = new ServicoReadQuery().ExistsByValorQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public ServicoDTO FirstById(int value)
        {
            var query = new ServicoReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO FirstByGrupoServicoId(int value)
        {
            var query = new ServicoReadQuery().FirstByGrupoServicoIdQuery(value);

                var result = _connection.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO FirstByNome(string value)
        {
            var query = new ServicoReadQuery().FirstByNomeQuery(value);

                var result = _connection.QueryFirstOrDefault<ServicoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ServicoDTO FirstByValor(Decimal value)
        {
            var query = new ServicoReadQuery().FirstByValorQuery(value);

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