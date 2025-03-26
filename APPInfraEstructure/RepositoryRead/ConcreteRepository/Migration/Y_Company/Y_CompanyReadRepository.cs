using Dapper;
using Output.Querys.Y_Company;
using Repositorio.Outputs.DTOs.Y_Company;
using RepositoryInterfaces.Read.Repository.Y_Company;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Y_Company
{
    public class Y_CompanyReadRepository : IY_CompanyReadRepository
    {
        protected readonly IDbConnection _connection;

        public Y_CompanyReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<Y_CompanyDTO> getY_Company(object command)
         {
            if (command is Command.Commands.Read.Y_CompanyReadCommand c)
            {
                return getY_Company(c);
            }
            throw new NotImplementedException();
        }
        private IEnumerable<Y_CompanyDTO> getY_Company(Command.Commands.Read.Y_CompanyReadCommand command)
        {
            List<Y_CompanyDTO> lista;
            var query = new Y_CompanyReadQuery().Y_CompanyQuery(command);

            using (_connection)
            {
                lista = _connection.Query<Y_CompanyDTO>(query.Query,query.Parameters) as List<Y_CompanyDTO>;
            }
            return lista;
        }

        private IEnumerable<Y_CompanyUserIDAdminDTO> getY_CompanyReadFKUserIDAdmin(Command.Patterns.Command.SearchFKCommand command)
        {
            List<Y_CompanyUserIDAdminDTO> lista;
            var query = new Y_CompanyReadQuery().Y_CompanyUserIDAdminQuery(command);

            using (_connection)
            {
                lista = _connection.Query<Y_CompanyUserIDAdminDTO>(query.Query,query.Parameters) as List<Y_CompanyUserIDAdminDTO>;
            }
            return lista;
        }

        public IEnumerable<Y_CompanyUserIDAdminDTO> getY_CompanyReadFKUserIDAdmin(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getY_CompanyReadFKUserIDAdmin(c);
            }
            throw new NotImplementedException();
        }

        public Y_CompanyDTO getById()
        {
            throw new NotImplementedException();
        }
        public Y_CompanyDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration