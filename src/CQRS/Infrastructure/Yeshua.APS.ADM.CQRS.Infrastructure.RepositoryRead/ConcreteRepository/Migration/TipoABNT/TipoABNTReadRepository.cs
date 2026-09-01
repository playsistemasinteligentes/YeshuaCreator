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
    public partial class TipoABNTReadRepository : ITipoABNTReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITipoABNTQueryRead _query;

        public TipoABNTReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITipoABNTQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTipoABNTCustom(Command.Read.TipoABNTReadCommand command, ref DataPagination<TipoABNTDTO> result, ref bool handled);

        public DataPagination<TipoABNTDTO> getTipoABNT(ICommandRead command )
         {
            if (command is Command.Read.TipoABNTReadCommand c)
                return getTipoABNT(c );
            throw new NotImplementedException();
        }
        private DataPagination<TipoABNTDTO> getTipoABNT(Command.Read.TipoABNTReadCommand command )
        {
            DataPagination<TipoABNTDTO> customResult = null;
            var customHandled = false;
            TryGetTipoABNTCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TipoABNTQuery(command );

                var itens = _unitOfWork.Query<TipoABNTDTO>(query.Query,query.Parameters);
                return new DataPagination<TipoABNTDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TipoABNTTenantIDDTO> getTipoABNTReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoABNTTenantIDDTO> lista;
            var query = _query.TipoABNTTenantIDQuery(command );

                lista = _unitOfWork.Query<TipoABNTTenantIDDTO>(query.Query,query.Parameters) as List<TipoABNTTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TipoABNTTenantIDDTO> getTipoABNTReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoABNTReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TipoABNTUserIdDTO> getTipoABNTReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoABNTUserIdDTO> lista;
            var query = _query.TipoABNTUserIdQuery(command );

                lista = _unitOfWork.Query<TipoABNTUserIdDTO>(query.Query,query.Parameters) as List<TipoABNTUserIdDTO>;
            return lista;
        }

        public IEnumerable<TipoABNTUserIdDTO> getTipoABNTReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoABNTReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByABN_ID(string value )
        {
            var query = _query.ExistsByABN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByABN_DESCRICAO(string value )
        {
            var query = _query.ExistsByABN_DESCRICAOQuery(value );

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

        public TipoABNTDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoABNTDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoABNTDTO FirstByABN_ID(string value )
        {
            var query = _query.FirstByABN_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoABNTDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoABNTDTO FirstByABN_DESCRICAO(string value )
        {
            var query = _query.FirstByABN_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoABNTDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoABNTDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoABNTDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoABNTDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoABNTDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoABNTDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoABNTDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoABNTDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoABNTDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TipoABNTDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TipoABNTDTO>(query.Query,query.Parameters) as List<TipoABNTDTO>;
                return result;
        }

        public IEnumerable<TipoABNTDTO> GetAllByABN_ID(string value )
        {
            var query = _query.FirstByABN_IDQuery(value );

                var result = _unitOfWork.Query<TipoABNTDTO>(query.Query,query.Parameters) as List<TipoABNTDTO>;
                return result;
        }

        public IEnumerable<TipoABNTDTO> GetAllByABN_DESCRICAO(string value )
        {
            var query = _query.FirstByABN_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<TipoABNTDTO>(query.Query,query.Parameters) as List<TipoABNTDTO>;
                return result;
        }

        public IEnumerable<TipoABNTDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TipoABNTDTO>(query.Query,query.Parameters) as List<TipoABNTDTO>;
                return result;
        }

        public IEnumerable<TipoABNTDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TipoABNTDTO>(query.Query,query.Parameters) as List<TipoABNTDTO>;
                return result;
        }

        public IEnumerable<TipoABNTDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TipoABNTDTO>(query.Query,query.Parameters) as List<TipoABNTDTO>;
                return result;
        }

        public IEnumerable<TipoABNTDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TipoABNTDTO>(query.Query,query.Parameters) as List<TipoABNTDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration