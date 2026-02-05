using Dapper;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using IRepository.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
{
    public class MovimentoFinanceiroReadRepository : IMovimentoFinanceiroReadRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ICurrentUser _currentUser;
       protected readonly IMovimentoFinanceiroQueryRead _query;

        public MovimentoFinanceiroReadRepository(SqlFactory factory, ICurrentUser currentUser,IMovimentoFinanceiroQueryRead query)
        {
            _connection = factory.SqlConnection();
            _currentUser = currentUser;
            _query = query;
        }

        public DataPagination<MovimentoFinanceiroDTO> getMovimentoFinanceiro(ICommandRead command )
         {
            if (command is Command.Read.MovimentoFinanceiroReadCommand c)
                return getMovimentoFinanceiro(c );
            throw new NotImplementedException();
        }
        private DataPagination<MovimentoFinanceiroDTO> getMovimentoFinanceiro(Command.Read.MovimentoFinanceiroReadCommand command )
        {
            var query = _query.MovimentoFinanceiroQuery(command );

                var itens = _connection.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters);
                return new DataPagination<MovimentoFinanceiroDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MovimentoFinanceiroContaDebitoIdDTO> getMovimentoFinanceiroReadFKContaDebitoId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentoFinanceiroContaDebitoIdDTO> lista;
            var query = _query.MovimentoFinanceiroContaDebitoIdQuery(command );

                lista = _connection.Query<MovimentoFinanceiroContaDebitoIdDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroContaDebitoIdDTO>;
            return lista;
        }

        public IEnumerable<MovimentoFinanceiroContaDebitoIdDTO> getMovimentoFinanceiroReadFKContaDebitoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentoFinanceiroReadFKContaDebitoId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentoFinanceiroContaCreditoIdDTO> getMovimentoFinanceiroReadFKContaCreditoId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentoFinanceiroContaCreditoIdDTO> lista;
            var query = _query.MovimentoFinanceiroContaCreditoIdQuery(command );

                lista = _connection.Query<MovimentoFinanceiroContaCreditoIdDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroContaCreditoIdDTO>;
            return lista;
        }

        public IEnumerable<MovimentoFinanceiroContaCreditoIdDTO> getMovimentoFinanceiroReadFKContaCreditoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentoFinanceiroReadFKContaCreditoId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentoFinanceiroTenantIDDTO> getMovimentoFinanceiroReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentoFinanceiroTenantIDDTO> lista;
            var query = _query.MovimentoFinanceiroTenantIDQuery(command );

                lista = _connection.Query<MovimentoFinanceiroTenantIDDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroTenantIDDTO>;
            return lista;
        }

        public IEnumerable<MovimentoFinanceiroTenantIDDTO> getMovimentoFinanceiroReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentoFinanceiroReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentoFinanceiroUserIdDTO> getMovimentoFinanceiroReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<MovimentoFinanceiroUserIdDTO> lista;
            var query = _query.MovimentoFinanceiroUserIdQuery(command );

                lista = _connection.Query<MovimentoFinanceiroUserIdDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroUserIdDTO>;
            return lista;
        }

        public IEnumerable<MovimentoFinanceiroUserIdDTO> getMovimentoFinanceiroReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentoFinanceiroReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIdOrigem(string value )
        {
            var query = _query.ExistsByIdOrigemQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByContaDebitoId(int value )
        {
            var query = _query.ExistsByContaDebitoIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByContaCreditoId(int value )
        {
            var query = _query.ExistsByContaCreditoIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValor(Decimal value )
        {
            var query = _query.ExistsByValorQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataMovimento(DateTime value )
        {
            var query = _query.ExistsByDataMovimentoQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataVencimento(DateTime value )
        {
            var query = _query.ExistsByDataVencimentoQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value )
        {
            var query = _query.ExistsByStatusQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value )
        {
            var query = _query.ExistsByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value )
        {
            var query = _query.ExistsByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value )
        {
            var query = _query.ExistsByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public MovimentoFinanceiroDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByIdOrigem(string value )
        {
            var query = _query.FirstByIdOrigemQuery(value );

                var result = _connection.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByContaDebitoId(int value )
        {
            var query = _query.FirstByContaDebitoIdQuery(value );

                var result = _connection.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByContaCreditoId(int value )
        {
            var query = _query.FirstByContaCreditoIdQuery(value );

                var result = _connection.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByValor(Decimal value )
        {
            var query = _query.FirstByValorQuery(value );

                var result = _connection.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByDataMovimento(DateTime value )
        {
            var query = _query.FirstByDataMovimentoQuery(value );

                var result = _connection.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByDataVencimento(DateTime value )
        {
            var query = _query.FirstByDataVencimentoQuery(value );

                var result = _connection.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _connection.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _connection.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroDTO>;
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByIdOrigem(string value )
        {
            var query = _query.FirstByIdOrigemQuery(value );

                var result = _connection.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroDTO>;
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByContaDebitoId(int value )
        {
            var query = _query.FirstByContaDebitoIdQuery(value );

                var result = _connection.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroDTO>;
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByContaCreditoId(int value )
        {
            var query = _query.FirstByContaCreditoIdQuery(value );

                var result = _connection.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroDTO>;
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByValor(Decimal value )
        {
            var query = _query.FirstByValorQuery(value );

                var result = _connection.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroDTO>;
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByDataMovimento(DateTime value )
        {
            var query = _query.FirstByDataMovimentoQuery(value );

                var result = _connection.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroDTO>;
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByDataVencimento(DateTime value )
        {
            var query = _query.FirstByDataVencimentoQuery(value );

                var result = _connection.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroDTO>;
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _connection.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroDTO>;
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _connection.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroDTO>;
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _connection.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroDTO>;
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _connection.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroDTO>;
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _connection.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters) as List<MovimentoFinanceiroDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration