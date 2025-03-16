using Dapper;
using Output.Querys.MovimentacaoFinanceira;
using Repositorio.Outputs.DTOs.MovimentacaoFinanceira;
using RepositoryInterfaces.Read.Repository.MovimentacaoFinanceira;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.ConcreteRepository.MovimentacaoFinanceira
{
    public class MovimentacaoFinanceiraReadRepository : IMovimentacaoFinanceiraReadRepository
    {
        protected readonly IDbConnection _connection;

        public MovimentacaoFinanceiraReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> getMovimentacaoFinanceira(object command)
         {
            if (command is Command.Commands.Read.MovimentacaoFinanceiraReadCommand c)
            {
                return getMovimentacaoFinanceira(c);
            }
            throw new NotImplementedException();
        }
        private IEnumerable<MovimentacaoFinanceiraDTO> getMovimentacaoFinanceira(Command.Commands.Read.MovimentacaoFinanceiraReadCommand command)
        {
            List<MovimentacaoFinanceiraDTO> lista;
            var query = new MovimentacaoFinanceiraReadQuery().MovimentacaoFinanceiraQuery(command);

            using (_connection)
            {
                lista = _connection.Query<MovimentacaoFinanceiraDTO>(query.Query) as List<MovimentacaoFinanceiraDTO>;
            }
            return lista;
        }

        private IEnumerable<MovimentacaoFinanceiraPacienteIdDTO> getMovimentacaoFinanceiraReadFKPacienteId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<MovimentacaoFinanceiraPacienteIdDTO> lista;
            var query = new MovimentacaoFinanceiraReadQuery().MovimentacaoFinanceiraPacienteIdQuery(command);

            using (_connection)
            {
                lista = _connection.Query<MovimentacaoFinanceiraPacienteIdDTO>(query.Query) as List<MovimentacaoFinanceiraPacienteIdDTO>;
            }
            return lista;
        }

        public IEnumerable<MovimentacaoFinanceiraPacienteIdDTO> getMovimentacaoFinanceiraReadFKPacienteId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentacaoFinanceiraReadFKPacienteId(c);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentacaoFinanceiraServicoIdDTO> getMovimentacaoFinanceiraReadFKServicoId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<MovimentacaoFinanceiraServicoIdDTO> lista;
            var query = new MovimentacaoFinanceiraReadQuery().MovimentacaoFinanceiraServicoIdQuery(command);

            using (_connection)
            {
                lista = _connection.Query<MovimentacaoFinanceiraServicoIdDTO>(query.Query) as List<MovimentacaoFinanceiraServicoIdDTO>;
            }
            return lista;
        }

        public IEnumerable<MovimentacaoFinanceiraServicoIdDTO> getMovimentacaoFinanceiraReadFKServicoId(object command)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentacaoFinanceiraReadFKServicoId(c);
            }
            throw new NotImplementedException();
        }

        public MovimentacaoFinanceiraDTO getById()
        {
            throw new NotImplementedException();
        }
        public MovimentacaoFinanceiraDTO GetById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration