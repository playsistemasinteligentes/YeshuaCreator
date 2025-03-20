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

        public IEnumerable<SesoesDTO> getSesoes(object command)
         {
            if (command is Command.Commands.Read.SesoesReadCommand c)
            {
                return getSesoes(c);
            }
            throw new NotImplementedException();
        }
        private IEnumerable<SesoesDTO> getSesoes(Command.Commands.Read.SesoesReadCommand command)
        {
            List<SesoesDTO> lista;
            var query = new SesoesReadQuery().SesoesQuery(command);

            using (_connection)
            {
                lista = _connection.Query<SesoesDTO>(query.Query,query.Parameters) as List<SesoesDTO>;
            }
            return lista;
        }

        private IEnumerable<SesoesPacienteIdDTO> getSesoesReadFKPacienteId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<SesoesPacienteIdDTO> lista;
            var query = new SesoesReadQuery().SesoesPacienteIdQuery(command);

            using (_connection)
            {
                lista = _connection.Query<SesoesPacienteIdDTO>(query.Query,query.Parameters) as List<SesoesPacienteIdDTO>;
            }
            return lista;
        }

        public IEnumerable<SesoesPacienteIdDTO> getSesoesReadFKPacienteId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKPacienteId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SesoesProfissionalIdDTO> getSesoesReadFKProfissionalId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<SesoesProfissionalIdDTO> lista;
            var query = new SesoesReadQuery().SesoesProfissionalIdQuery(command);

            using (_connection)
            {
                lista = _connection.Query<SesoesProfissionalIdDTO>(query.Query,query.Parameters) as List<SesoesProfissionalIdDTO>;
            }
            return lista;
        }

        public IEnumerable<SesoesProfissionalIdDTO> getSesoesReadFKProfissionalId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKProfissionalId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SesoesServicoIdDTO> getSesoesReadFKServicoId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<SesoesServicoIdDTO> lista;
            var query = new SesoesReadQuery().SesoesServicoIdQuery(command);

            using (_connection)
            {
                lista = _connection.Query<SesoesServicoIdDTO>(query.Query,query.Parameters) as List<SesoesServicoIdDTO>;
            }
            return lista;
        }

        public IEnumerable<SesoesServicoIdDTO> getSesoesReadFKServicoId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKServicoId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<SesoesMovimentacaoFinanceiraIdDTO> getSesoesReadFKMovimentacaoFinanceiraId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<SesoesMovimentacaoFinanceiraIdDTO> lista;
            var query = new SesoesReadQuery().SesoesMovimentacaoFinanceiraIdQuery(command);

            using (_connection)
            {
                lista = _connection.Query<SesoesMovimentacaoFinanceiraIdDTO>(query.Query,query.Parameters) as List<SesoesMovimentacaoFinanceiraIdDTO>;
            }
            return lista;
        }

        public IEnumerable<SesoesMovimentacaoFinanceiraIdDTO> getSesoesReadFKMovimentacaoFinanceiraId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getSesoesReadFKMovimentacaoFinanceiraId(c);
            }
            throw new NotImplementedException();
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