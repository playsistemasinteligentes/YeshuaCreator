using Dapper;
using Output.Querys.Sesoes;
using Repositorio.Outputs.DTOs.Sesoes;
using RepositoryInterfaces.Read.Repository.Sesoes;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Sesoes
{
    public class SesoesReadRepository : ISesoesReadRepository
    {
        protected readonly IDbConnection _connection;

        public SesoesReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<SesoesDTO> getAllSesoes()
        {
            List<SesoesDTO> lista;
            var query = new SesoesReadQuery().SelectAllSesoesQuery();

            using (_connection)
            {
                lista = _connection.Query<SesoesDTO>(query.Query) as List<SesoesDTO>;
            }
            return lista;
        }

        public SesoesDTO getById()
        {
            throw new NotImplementedException();
        }
        public SesoesDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration