using Dapper;
using Output.Querys.Profissional;
using Repositorio.Outputs.DTOs.Profissional;
using RepositoryInterfaces.Read.Repository.Profissional;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.Profissional
{
    public class ProfissionalReadRepository : IProfissionalReadRepository
    {
        protected readonly IDbConnection _connection;

        public ProfissionalReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<ProfissionalDTO> getProfissional(object command)
         {
            if (command is Command.Commands.Read.ProfissionalReadCommand c)
            {
                return getProfissional(c);
            }
            throw new NotImplementedException();
        }
        private IEnumerable<ProfissionalDTO> getProfissional(Command.Commands.Read.ProfissionalReadCommand command)
        {
            List<ProfissionalDTO> lista;
            var query = new ProfissionalReadQuery().ProfissionalQuery(command);

            using (_connection)
            {
                lista = _connection.Query<ProfissionalDTO>(query.Query,query.Parameters) as List<ProfissionalDTO>;
            }
            return lista;
        }

        private IEnumerable<ProfissionalEspecialidadeIdDTO> getProfissionalReadFKEspecialidadeId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<ProfissionalEspecialidadeIdDTO> lista;
            var query = new ProfissionalReadQuery().ProfissionalEspecialidadeIdQuery(command);

            using (_connection)
            {
                lista = _connection.Query<ProfissionalEspecialidadeIdDTO>(query.Query,query.Parameters) as List<ProfissionalEspecialidadeIdDTO>;
            }
            return lista;
        }

        public IEnumerable<ProfissionalEspecialidadeIdDTO> getProfissionalReadFKEspecialidadeId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProfissionalReadFKEspecialidadeId(c);
            }
            throw new NotImplementedException();
        }

        public ProfissionalDTO getById()
        {
            throw new NotImplementedException();
        }
        public ProfissionalDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration