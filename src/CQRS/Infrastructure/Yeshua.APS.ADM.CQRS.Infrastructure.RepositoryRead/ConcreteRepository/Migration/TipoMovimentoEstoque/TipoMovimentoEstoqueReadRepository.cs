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
    public partial class TipoMovimentoEstoqueReadRepository : ITipoMovimentoEstoqueReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITipoMovimentoEstoqueQueryRead _query;

        public TipoMovimentoEstoqueReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITipoMovimentoEstoqueQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTipoMovimentoEstoqueCustom(Command.Read.TipoMovimentoEstoqueReadCommand command, ref DataPagination<TipoMovimentoEstoqueDTO> result, ref bool handled);

        public DataPagination<TipoMovimentoEstoqueDTO> getTipoMovimentoEstoque(ICommandRead command )
         {
            if (command is Command.Read.TipoMovimentoEstoqueReadCommand c)
                return getTipoMovimentoEstoque(c );
            throw new NotImplementedException();
        }
        private DataPagination<TipoMovimentoEstoqueDTO> getTipoMovimentoEstoque(Command.Read.TipoMovimentoEstoqueReadCommand command )
        {
            DataPagination<TipoMovimentoEstoqueDTO> customResult = null;
            var customHandled = false;
            TryGetTipoMovimentoEstoqueCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TipoMovimentoEstoqueQuery(command );

                var itens = _unitOfWork.Query<TipoMovimentoEstoqueDTO>(query.Query,query.Parameters);
                return new DataPagination<TipoMovimentoEstoqueDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TipoMovimentoEstoqueTenantIDDTO> getTipoMovimentoEstoqueReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoMovimentoEstoqueTenantIDDTO> lista;
            var query = _query.TipoMovimentoEstoqueTenantIDQuery(command );

                lista = _unitOfWork.Query<TipoMovimentoEstoqueTenantIDDTO>(query.Query,query.Parameters) as List<TipoMovimentoEstoqueTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TipoMovimentoEstoqueTenantIDDTO> getTipoMovimentoEstoqueReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoMovimentoEstoqueReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TipoMovimentoEstoqueUserIdDTO> getTipoMovimentoEstoqueReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoMovimentoEstoqueUserIdDTO> lista;
            var query = _query.TipoMovimentoEstoqueUserIdQuery(command );

                lista = _unitOfWork.Query<TipoMovimentoEstoqueUserIdDTO>(query.Query,query.Parameters) as List<TipoMovimentoEstoqueUserIdDTO>;
            return lista;
        }

        public IEnumerable<TipoMovimentoEstoqueUserIdDTO> getTipoMovimentoEstoqueReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoMovimentoEstoqueReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByTIP_ID(string value )
        {
            var query = _query.ExistsByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_DESCRICAO(string value )
        {
            var query = _query.ExistsByTIP_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_TYPE(int value )
        {
            var query = _query.ExistsByTIP_TYPEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySPR(int value )
        {
            var query = _query.ExistsBySPRQuery(value );

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

        public TipoMovimentoEstoqueDTO FirstByTIP_ID(string value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoMovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoMovimentoEstoqueDTO FirstByTIP_DESCRICAO(string value )
        {
            var query = _query.FirstByTIP_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoMovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoMovimentoEstoqueDTO FirstByTIP_TYPE(int value )
        {
            var query = _query.FirstByTIP_TYPEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoMovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoMovimentoEstoqueDTO FirstBySPR(int value )
        {
            var query = _query.FirstBySPRQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoMovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoMovimentoEstoqueDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoMovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoMovimentoEstoqueDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoMovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoMovimentoEstoqueDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoMovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoMovimentoEstoqueDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoMovimentoEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByTIP_ID(string value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.Query<TipoMovimentoEstoqueDTO>(query.Query,query.Parameters) as List<TipoMovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByTIP_DESCRICAO(string value )
        {
            var query = _query.FirstByTIP_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<TipoMovimentoEstoqueDTO>(query.Query,query.Parameters) as List<TipoMovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByTIP_TYPE(int value )
        {
            var query = _query.FirstByTIP_TYPEQuery(value );

                var result = _unitOfWork.Query<TipoMovimentoEstoqueDTO>(query.Query,query.Parameters) as List<TipoMovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllBySPR(int value )
        {
            var query = _query.FirstBySPRQuery(value );

                var result = _unitOfWork.Query<TipoMovimentoEstoqueDTO>(query.Query,query.Parameters) as List<TipoMovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TipoMovimentoEstoqueDTO>(query.Query,query.Parameters) as List<TipoMovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TipoMovimentoEstoqueDTO>(query.Query,query.Parameters) as List<TipoMovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TipoMovimentoEstoqueDTO>(query.Query,query.Parameters) as List<TipoMovimentoEstoqueDTO>;
                return result;
        }

        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TipoMovimentoEstoqueDTO>(query.Query,query.Parameters) as List<TipoMovimentoEstoqueDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration