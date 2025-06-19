using Dapper;
using Output.Querys.Especialidade;
using Repositorio.Outputs.DTOs.Especialidade;
using RepositoryInterfaces.Read.Repository.Especialidade;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Especialidade
{
    public class EspecialidadeReadRepository : IEspecialidadeReadRepository
    {
        protected readonly IDbConnection _connection;

        public EspecialidadeReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<EspecialidadeDTO> getEspecialidade(ICommandRead command)
         {
            if (command is Command.Commands.Read.EspecialidadeReadCommand c)
                return getEspecialidade(c);
            throw new NotImplementedException();
        }
        private DataPagination<EspecialidadeDTO> getEspecialidade(Command.Commands.Read.EspecialidadeReadCommand command)
        {
            var query = new EspecialidadeReadQuery().EspecialidadeQuery(command);

            using (_connection)
            {
                var itens = _connection.Query<EspecialidadeDTO>(query.Query,query.Parameters);
                return new DataPagination<EspecialidadeDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
            }
        }

        public EspecialidadeDTO getById()
        {
            throw new NotImplementedException();
        }
        public EspecialidadeDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration