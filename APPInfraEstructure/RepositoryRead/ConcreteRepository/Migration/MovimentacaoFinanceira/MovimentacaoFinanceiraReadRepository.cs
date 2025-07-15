using Dapper;
using Output.Querys.MovimentacaoFinanceira;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using Read.RepositoryInterfaces;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
{
    public class MovimentacaoFinanceiraReadRepository : IMovimentacaoFinanceiraReadRepository
    {
        protected readonly IDbConnection _connection;

        public MovimentacaoFinanceiraReadRepository(SqlFactory factory)
        {
            _connection = factory.SqlConnection();
        }

        public DataPagination<MovimentacaoFinanceiraDTO> getMovimentacaoFinanceira(ICommandRead command)
         {
            if (command is Command.Commands.Read.MovimentacaoFinanceiraReadCommand c)
                return getMovimentacaoFinanceira(c);
            throw new NotImplementedException();
        }
        private DataPagination<MovimentacaoFinanceiraDTO> getMovimentacaoFinanceira(Command.Commands.Read.MovimentacaoFinanceiraReadCommand command)
        {
            var query = new MovimentacaoFinanceiraReadQuery().MovimentacaoFinanceiraQuery(command);

                var itens = _connection.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters);
                return new DataPagination<MovimentacaoFinanceiraDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MovimentacaoFinanceiraPacienteIdDTO> getMovimentacaoFinanceiraReadFKPacienteId(Command.Patterns.Command.SearchFKCommand command)
        {
            List<MovimentacaoFinanceiraPacienteIdDTO> lista;
            var query = new MovimentacaoFinanceiraReadQuery().MovimentacaoFinanceiraPacienteIdQuery(command);

                lista = _connection.Query<MovimentacaoFinanceiraPacienteIdDTO>(query.Query,query.Parameters) as List<MovimentacaoFinanceiraPacienteIdDTO>;
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

                lista = _connection.Query<MovimentacaoFinanceiraServicoIdDTO>(query.Query,query.Parameters) as List<MovimentacaoFinanceiraServicoIdDTO>;
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

        public bool ExistsById(int value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().ExistsByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPacienteId(int value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().ExistsByPacienteIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByServicoId(int value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().ExistsByServicoIdQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValor(Decimal value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().ExistsByValorQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTipoMovimentacao(int value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().ExistsByTipoMovimentacaoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataMovimentacao(DateTime value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().ExistsByDataMovimentacaoQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySaldoAtual(Decimal value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().ExistsBySaldoAtualQuery(value);

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public MovimentacaoFinanceiraDTO FirstById(int value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().FirstByIdQuery(value);

                var result = _connection.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByPacienteId(int value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().FirstByPacienteIdQuery(value);

                var result = _connection.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByServicoId(int value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().FirstByServicoIdQuery(value);

                var result = _connection.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByValor(Decimal value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().FirstByValorQuery(value);

                var result = _connection.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByTipoMovimentacao(int value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().FirstByTipoMovimentacaoQuery(value);

                var result = _connection.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByDataMovimentacao(DateTime value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().FirstByDataMovimentacaoQuery(value);

                var result = _connection.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstBySaldoAtual(Decimal value)
        {
            var query = new MovimentacaoFinanceiraReadQuery().FirstBySaldoAtualQuery(value);

                var result = _connection.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO getById()
        {
            throw new NotImplementedException();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration