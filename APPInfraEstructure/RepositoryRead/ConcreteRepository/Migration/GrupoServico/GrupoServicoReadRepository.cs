using Dapper;
using Output.Querys.GrupoServico;
using Repositorio.Outputs.DTOs.GrupoServico;
using RepositoryInterfaces.Read.Repository.GrupoServico;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.GrupoServico
{
    public class GrupoServicoReadRepository : IGrupoServicoReadRepository
    {
        protected readonly IDbConnection _connection;

        public GrupoServicoReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<GrupoServicoDTO> getGrupoServico(ICommandRead command)
         {
            if (command is Command.Commands.Read.GrupoServicoReadCommand c)
                return getGrupoServico(c);
            throw new NotImplementedException();
        }
        private DataPagination<GrupoServicoDTO> getGrupoServico(Command.Commands.Read.GrupoServicoReadCommand command)
        {
            var query = new GrupoServicoReadQuery().GrupoServicoQuery(command);

            using (_connection)
            {
                var itens = _connection.Query<GrupoServicoDTO>(query.Query,query.Parameters);
                return new DataPagination<GrupoServicoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
            }
        }

        public GrupoServicoDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration