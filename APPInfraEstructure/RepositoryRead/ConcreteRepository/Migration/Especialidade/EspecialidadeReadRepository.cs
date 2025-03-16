using Dapper;
using Output.Querys.Especialidade;
using Repositorio.Outputs.DTOs.Especialidade;
using RepositoryInterfaces.Read.Repository.Especialidade;
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

        public IEnumerable<EspecialidadeDTO> getEspecialidade(object command)
         {
            if (command is Command.Commands.Read.EspecialidadeReadCommand c)
            {
                return getEspecialidade(c);
            }
            throw new NotImplementedException();
        }
        private IEnumerable<EspecialidadeDTO> getEspecialidade(Command.Commands.Read.EspecialidadeReadCommand command)
        {
            List<EspecialidadeDTO> lista;
            var query = new EspecialidadeReadQuery().EspecialidadeQuery(command);

            using (_connection)
            {
                lista = _connection.Query<EspecialidadeDTO>(query.Query) as List<EspecialidadeDTO>;
            }
            return lista;
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