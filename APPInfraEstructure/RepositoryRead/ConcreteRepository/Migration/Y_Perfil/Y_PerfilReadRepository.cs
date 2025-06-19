using Dapper;
using Output.Querys.Y_Perfil;
using Repositorio.Outputs.DTOs.Y_Perfil;
using RepositoryInterfaces.Read.Repository.Y_Perfil;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Y_Perfil
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

            using (_connection)
            {
                var itens = _connection.Query<Y_PerfilDTO>(query.Query,query.Parameters);
                return new DataPagination<Y_PerfilDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
            }
        }

        public Y_PerfilDTO getById()
        {
            throw new NotImplementedException();
        }
        public Y_PerfilDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration