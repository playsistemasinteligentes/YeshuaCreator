using Dapper;
using Output.Querys.Yuser;
using Repositorio.Outputs.DTOs.Yuser;
using RepositoryInterfaces.Read.Repository.Yuser;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Yuser
{
    public class YuserReadRepository : IYuserReadRepository
    {
        protected readonly IDbConnection _connection;

        public YuserReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<YuserDTO> getYuser(object command)
         {
            if (command is Command.Commands.Read.YuserReadCommand c)
            {
                return getYuser(c);
            }
            throw new NotImplementedException();
        }
        private IEnumerable<YuserDTO> getYuser(Command.Commands.Read.YuserReadCommand command)
        {
            List<YuserDTO> lista;
            var query = new YuserReadQuery().YuserQuery(command);

            using (_connection)
            {
                lista = _connection.Query<YuserDTO>(query.Query,query.Parameters) as List<YuserDTO>;
            }
            return lista;
        }

        public YuserDTO getById()
        {
            throw new NotImplementedException();
        }
        public YuserDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration