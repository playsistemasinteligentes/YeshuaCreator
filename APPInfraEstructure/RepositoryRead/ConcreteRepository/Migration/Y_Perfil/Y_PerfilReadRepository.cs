using Dapper;
using Output.Querys.Y_Perfil;
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
    public class Y_PerfilReadRepository : IY_PerfilReadRepository
    {
        protected readonly IDbConnection _connection;

        public Y_PerfilReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<Y_PerfilDTO> getY_Perfil(ICommandRead command)
         {
            if (command is Command.Commands.Read.Y_PerfilReadCommand c)
                return getY_Perfil(c);
            throw new NotImplementedException();
        }
        private DataPagination<Y_PerfilDTO> getY_Perfil(Command.Commands.Read.Y_PerfilReadCommand command)
        {
            var query = new Y_PerfilReadQuery().Y_PerfilQuery(command);

                var itens = _connection.Query<Y_PerfilDTO>(query.Query,query.Parameters);
                return new DataPagination<Y_PerfilDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        public bool ExistsById(int value)
        {
            var query = new Y_PerfilReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescription(string value)
        {
            var query = new Y_PerfilReadQuery().ExistsByDescriptionQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public Y_PerfilDTO FirstById(int value)
        {
            var query = new Y_PerfilReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_PerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_PerfilDTO FirstByDescription(string value)
        {
            var query = new Y_PerfilReadQuery().FirstByDescriptionQuery(value);

                var result = _connection.QueryFirstOrDefault<Y_PerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public Y_PerfilDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration