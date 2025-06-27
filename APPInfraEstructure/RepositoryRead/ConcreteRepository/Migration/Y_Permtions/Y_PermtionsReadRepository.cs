using Dapper;
using Output.Querys.Y_Permtions;
using Repositorio.Outputs.DTOs.Y_Permtions;
using RepositoryInterfaces.Read.Repository.Y_Permtions;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Y_Permtions
{
    public class Y_PermtionsReadRepository : IY_PermtionsReadRepository
    {
        protected readonly IDbConnection _connection;

        public Y_PermtionsReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<Y_PermtionsDTO> getY_Permtions(ICommandRead command)
         {
            if (command is Command.Commands.Read.Y_PermtionsReadCommand c)
                return getY_Permtions(c);
            throw new NotImplementedException();
        }
        private DataPagination<Y_PermtionsDTO> getY_Permtions(Command.Commands.Read.Y_PermtionsReadCommand command)
        {
            var query = new Y_PermtionsReadQuery().Y_PermtionsQuery(command);

            using (_connection)
            {
                var itens = _connection.Query<Y_PermtionsDTO>(query.Query,query.Parameters);
                return new DataPagination<Y_PermtionsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
            }
        }

        public Y_PermtionsDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration