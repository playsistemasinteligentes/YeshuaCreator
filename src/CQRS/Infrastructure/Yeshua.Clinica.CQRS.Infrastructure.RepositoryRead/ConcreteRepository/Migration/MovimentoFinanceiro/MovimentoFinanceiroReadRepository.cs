// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using IRepository.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
{
    public partial class MovimentoFinanceiroReadRepository : IMovimentoFinanceiroReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMovimentoFinanceiroQueryRead _query;

        public MovimentoFinanceiroReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMovimentoFinanceiroQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetMovimentoFinanceiroCustom(Command.Read.MovimentoFinanceiroReadCommand command, ref DataPagination<MovimentoFinanceiroDTO> result, ref bool handled);

        public DataPagination<MovimentoFinanceiroDTO> getMovimentoFinanceiro(ICommandRead command )
         {
            if (command is Command.Read.MovimentoFinanceiroReadCommand c)
                return getMovimentoFinanceiro(c );
            throw new NotImplementedException();
        }
        private DataPagination<MovimentoFinanceiroDTO> getMovimentoFinanceiro(Command.Read.MovimentoFinanceiroReadCommand command )
        {
            var customResult = new DataPagination<MovimentoFinanceiroDTO>();
            var customHandled = false;
            TryGetMovimentoFinanceiroCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.MovimentoFinanceiroQuery(command );

                var itens = _unitOfWork.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters);
                return new DataPagination<MovimentoFinanceiroDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MovimentoFinanceiroContaDebitoIdDTO> getMovimentoFinanceiroReadFKContaDebitoId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MovimentoFinanceiroContaDebitoIdQuery(command );

                var lista = _unitOfWork.Query<MovimentoFinanceiroContaDebitoIdDTO>(query.Query,query.Parameters).ToList();
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

        private IEnumerable<MovimentoFinanceiroTenantIDDTO> getMovimentoFinanceiroReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MovimentoFinanceiroTenantIDQuery(command );

                var lista = _unitOfWork.Query<MovimentoFinanceiroTenantIDDTO>(query.Query,query.Parameters).ToList();
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
            var query = _query.MovimentoFinanceiroUserIdQuery(command );

                var lista = _unitOfWork.Query<MovimentoFinanceiroUserIdDTO>(query.Query,query.Parameters).ToList();
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

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIdOrigem(string value )
        {
            var query = _query.ExistsByIdOrigemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByContaDebitoId(int value )
        {
            var query = _query.ExistsByContaDebitoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValor(Decimal value )
        {
            var query = _query.ExistsByValorQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataMovimento(DateTime value )
        {
            var query = _query.ExistsByDataMovimentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataVencimento(DateTime value )
        {
            var query = _query.ExistsByDataVencimentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value )
        {
            var query = _query.ExistsByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOperationalEntityId(string value )
        {
            var query = _query.ExistsByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value )
        {
            var query = _query.ExistsByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value )
        {
            var query = _query.ExistsByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value )
        {
            var query = _query.ExistsByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public MovimentoFinanceiroDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByIdOrigem(string value )
        {
            var query = _query.FirstByIdOrigemQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByContaDebitoId(int value )
        {
            var query = _query.FirstByContaDebitoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByValor(Decimal value )
        {
            var query = _query.FirstByValorQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByDataMovimento(DateTime value )
        {
            var query = _query.FirstByDataMovimentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByDataVencimento(DateTime value )
        {
            var query = _query.FirstByDataVencimentoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentoFinanceiroDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentoFinanceiroDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByIdOrigem(string value )
        {
            var query = _query.FirstByIdOrigemQuery(value );

                var result = _unitOfWork.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByContaDebitoId(int value )
        {
            var query = _query.FirstByContaDebitoIdQuery(value );

                var result = _unitOfWork.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByValor(Decimal value )
        {
            var query = _query.FirstByValorQuery(value );

                var result = _unitOfWork.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByDataMovimento(DateTime value )
        {
            var query = _query.FirstByDataMovimentoQuery(value );

                var result = _unitOfWork.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByDataVencimento(DateTime value )
        {
            var query = _query.FirstByDataVencimentoQuery(value );

                var result = _unitOfWork.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentoFinanceiroDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MovimentoFinanceiroDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration