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
    public partial class MovimentacaoFinanceiraReadRepository : IMovimentacaoFinanceiraReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IMovimentacaoFinanceiraQueryRead _query;

        public MovimentacaoFinanceiraReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IMovimentacaoFinanceiraQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetMovimentacaoFinanceiraCustom(Command.Read.MovimentacaoFinanceiraReadCommand command, ref DataPagination<MovimentacaoFinanceiraDTO> result, ref bool handled);

        public DataPagination<MovimentacaoFinanceiraDTO> getMovimentacaoFinanceira(ICommandRead command )
         {
            if (command is Command.Read.MovimentacaoFinanceiraReadCommand c)
                return getMovimentacaoFinanceira(c );
            throw new NotImplementedException();
        }
        private DataPagination<MovimentacaoFinanceiraDTO> getMovimentacaoFinanceira(Command.Read.MovimentacaoFinanceiraReadCommand command )
        {
            var customResult = new DataPagination<MovimentacaoFinanceiraDTO>();
            var customHandled = false;
            TryGetMovimentacaoFinanceiraCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.MovimentacaoFinanceiraQuery(command );

                var itens = _unitOfWork.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters);
                return new DataPagination<MovimentacaoFinanceiraDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<MovimentacaoFinanceiraPacienteIdDTO> getMovimentacaoFinanceiraReadFKPacienteId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MovimentacaoFinanceiraPacienteIdQuery(command );

                var lista = _unitOfWork.Query<MovimentacaoFinanceiraPacienteIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<MovimentacaoFinanceiraPacienteIdDTO> getMovimentacaoFinanceiraReadFKPacienteId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentacaoFinanceiraReadFKPacienteId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentacaoFinanceiraServicoIdDTO> getMovimentacaoFinanceiraReadFKServicoId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MovimentacaoFinanceiraServicoIdQuery(command );

                var lista = _unitOfWork.Query<MovimentacaoFinanceiraServicoIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<MovimentacaoFinanceiraServicoIdDTO> getMovimentacaoFinanceiraReadFKServicoId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentacaoFinanceiraReadFKServicoId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentacaoFinanceiraTenantIDDTO> getMovimentacaoFinanceiraReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MovimentacaoFinanceiraTenantIDQuery(command );

                var lista = _unitOfWork.Query<MovimentacaoFinanceiraTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<MovimentacaoFinanceiraTenantIDDTO> getMovimentacaoFinanceiraReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentacaoFinanceiraReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<MovimentacaoFinanceiraUserIdDTO> getMovimentacaoFinanceiraReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.MovimentacaoFinanceiraUserIdQuery(command );

                var lista = _unitOfWork.Query<MovimentacaoFinanceiraUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<MovimentacaoFinanceiraUserIdDTO> getMovimentacaoFinanceiraReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getMovimentacaoFinanceiraReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPacienteId(int value )
        {
            var query = _query.ExistsByPacienteIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByServicoId(int value )
        {
            var query = _query.ExistsByServicoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValor(Decimal value )
        {
            var query = _query.ExistsByValorQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTipoMovimentacao(int value )
        {
            var query = _query.ExistsByTipoMovimentacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDataMovimentacao(DateTime value )
        {
            var query = _query.ExistsByDataMovimentacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySaldoAtual(Decimal value )
        {
            var query = _query.ExistsBySaldoAtualQuery(value );

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

        public MovimentacaoFinanceiraDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByPacienteId(int value )
        {
            var query = _query.FirstByPacienteIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByServicoId(int value )
        {
            var query = _query.FirstByServicoIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByValor(Decimal value )
        {
            var query = _query.FirstByValorQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByTipoMovimentacao(int value )
        {
            var query = _query.FirstByTipoMovimentacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByDataMovimentacao(DateTime value )
        {
            var query = _query.FirstByDataMovimentacaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstBySaldoAtual(Decimal value )
        {
            var query = _query.FirstBySaldoAtualQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public MovimentacaoFinanceiraDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<MovimentacaoFinanceiraDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByPacienteId(int value )
        {
            var query = _query.FirstByPacienteIdQuery(value );

                var result = _unitOfWork.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByServicoId(int value )
        {
            var query = _query.FirstByServicoIdQuery(value );

                var result = _unitOfWork.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByValor(Decimal value )
        {
            var query = _query.FirstByValorQuery(value );

                var result = _unitOfWork.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByTipoMovimentacao(int value )
        {
            var query = _query.FirstByTipoMovimentacaoQuery(value );

                var result = _unitOfWork.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByDataMovimentacao(DateTime value )
        {
            var query = _query.FirstByDataMovimentacaoQuery(value );

                var result = _unitOfWork.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllBySaldoAtual(Decimal value )
        {
            var query = _query.FirstBySaldoAtualQuery(value );

                var result = _unitOfWork.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<MovimentacaoFinanceiraDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration