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
    public partial class TiposVincoProdutosReadRepository : ITiposVincoProdutosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITiposVincoProdutosQueryRead _query;

        public TiposVincoProdutosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITiposVincoProdutosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<TiposVincoProdutosDTO> getTiposVincoProdutos(ICommandRead command )
         {
            if (command is Command.Read.TiposVincoProdutosReadCommand c)
                return getTiposVincoProdutos(c );
            throw new NotImplementedException();
        }
        private DataPagination<TiposVincoProdutosDTO> getTiposVincoProdutos(Command.Read.TiposVincoProdutosReadCommand command )
        {
            var query = _query.TiposVincoProdutosQuery(command );

                var itens = _unitOfWork.Query<TiposVincoProdutosDTO>(query.Query,query.Parameters);
                return new DataPagination<TiposVincoProdutosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TiposVincoProdutosTenantIDDTO> getTiposVincoProdutosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TiposVincoProdutosTenantIDDTO> lista;
            var query = _query.TiposVincoProdutosTenantIDQuery(command );

                lista = _unitOfWork.Query<TiposVincoProdutosTenantIDDTO>(query.Query,query.Parameters) as List<TiposVincoProdutosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TiposVincoProdutosTenantIDDTO> getTiposVincoProdutosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTiposVincoProdutosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TiposVincoProdutosUserIdDTO> getTiposVincoProdutosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TiposVincoProdutosUserIdDTO> lista;
            var query = _query.TiposVincoProdutosUserIdQuery(command );

                lista = _unitOfWork.Query<TiposVincoProdutosUserIdDTO>(query.Query,query.Parameters) as List<TiposVincoProdutosUserIdDTO>;
            return lista;
        }

        public IEnumerable<TiposVincoProdutosUserIdDTO> getTiposVincoProdutosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTiposVincoProdutosReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsById2(int value )
        {
            var query = _query.ExistsById2Query(value );

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

        public TiposVincoProdutosDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoProdutosDTO FirstById2(int value )
        {
            var query = _query.FirstById2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoProdutosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoProdutosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoProdutosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoProdutosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TiposVincoProdutosDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TiposVincoProdutosDTO>(query.Query,query.Parameters) as List<TiposVincoProdutosDTO>;
                return result;
        }

        public IEnumerable<TiposVincoProdutosDTO> GetAllById2(int value )
        {
            var query = _query.FirstById2Query(value );

                var result = _unitOfWork.Query<TiposVincoProdutosDTO>(query.Query,query.Parameters) as List<TiposVincoProdutosDTO>;
                return result;
        }

        public IEnumerable<TiposVincoProdutosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TiposVincoProdutosDTO>(query.Query,query.Parameters) as List<TiposVincoProdutosDTO>;
                return result;
        }

        public IEnumerable<TiposVincoProdutosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TiposVincoProdutosDTO>(query.Query,query.Parameters) as List<TiposVincoProdutosDTO>;
                return result;
        }

        public IEnumerable<TiposVincoProdutosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TiposVincoProdutosDTO>(query.Query,query.Parameters) as List<TiposVincoProdutosDTO>;
                return result;
        }

        public IEnumerable<TiposVincoProdutosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TiposVincoProdutosDTO>(query.Query,query.Parameters) as List<TiposVincoProdutosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration