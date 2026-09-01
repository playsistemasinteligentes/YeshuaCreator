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
    public partial class TiposVincoGruposProdutosReadRepository : ITiposVincoGruposProdutosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITiposVincoGruposProdutosQueryRead _query;

        public TiposVincoGruposProdutosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITiposVincoGruposProdutosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTiposVincoGruposProdutosCustom(Command.Read.TiposVincoGruposProdutosReadCommand command, ref DataPagination<TiposVincoGruposProdutosDTO> result, ref bool handled);

        public DataPagination<TiposVincoGruposProdutosDTO> getTiposVincoGruposProdutos(ICommandRead command )
         {
            if (command is Command.Read.TiposVincoGruposProdutosReadCommand c)
                return getTiposVincoGruposProdutos(c );
            throw new NotImplementedException();
        }
        private DataPagination<TiposVincoGruposProdutosDTO> getTiposVincoGruposProdutos(Command.Read.TiposVincoGruposProdutosReadCommand command )
        {
            DataPagination<TiposVincoGruposProdutosDTO> customResult = null;
            var customHandled = false;
            TryGetTiposVincoGruposProdutosCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TiposVincoGruposProdutosQuery(command );

                var itens = _unitOfWork.Query<TiposVincoGruposProdutosDTO>(query.Query,query.Parameters);
                return new DataPagination<TiposVincoGruposProdutosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TiposVincoGruposProdutosTenantIDDTO> getTiposVincoGruposProdutosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TiposVincoGruposProdutosTenantIDDTO> lista;
            var query = _query.TiposVincoGruposProdutosTenantIDQuery(command );

                lista = _unitOfWork.Query<TiposVincoGruposProdutosTenantIDDTO>(query.Query,query.Parameters) as List<TiposVincoGruposProdutosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TiposVincoGruposProdutosTenantIDDTO> getTiposVincoGruposProdutosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTiposVincoGruposProdutosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TiposVincoGruposProdutosUserIdDTO> getTiposVincoGruposProdutosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TiposVincoGruposProdutosUserIdDTO> lista;
            var query = _query.TiposVincoGruposProdutosUserIdQuery(command );

                lista = _unitOfWork.Query<TiposVincoGruposProdutosUserIdDTO>(query.Query,query.Parameters) as List<TiposVincoGruposProdutosUserIdDTO>;
            return lista;
        }

        public IEnumerable<TiposVincoGruposProdutosUserIdDTO> getTiposVincoGruposProdutosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTiposVincoGruposProdutosReadFKUserId(c );
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

        public TiposVincoGruposProdutosDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoGruposProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoGruposProdutosDTO FirstById2(int value )
        {
            var query = _query.FirstById2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoGruposProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoGruposProdutosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoGruposProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoGruposProdutosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoGruposProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoGruposProdutosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoGruposProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoGruposProdutosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoGruposProdutosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TiposVincoGruposProdutosDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TiposVincoGruposProdutosDTO>(query.Query,query.Parameters) as List<TiposVincoGruposProdutosDTO>;
                return result;
        }

        public IEnumerable<TiposVincoGruposProdutosDTO> GetAllById2(int value )
        {
            var query = _query.FirstById2Query(value );

                var result = _unitOfWork.Query<TiposVincoGruposProdutosDTO>(query.Query,query.Parameters) as List<TiposVincoGruposProdutosDTO>;
                return result;
        }

        public IEnumerable<TiposVincoGruposProdutosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TiposVincoGruposProdutosDTO>(query.Query,query.Parameters) as List<TiposVincoGruposProdutosDTO>;
                return result;
        }

        public IEnumerable<TiposVincoGruposProdutosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TiposVincoGruposProdutosDTO>(query.Query,query.Parameters) as List<TiposVincoGruposProdutosDTO>;
                return result;
        }

        public IEnumerable<TiposVincoGruposProdutosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TiposVincoGruposProdutosDTO>(query.Query,query.Parameters) as List<TiposVincoGruposProdutosDTO>;
                return result;
        }

        public IEnumerable<TiposVincoGruposProdutosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TiposVincoGruposProdutosDTO>(query.Query,query.Parameters) as List<TiposVincoGruposProdutosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration